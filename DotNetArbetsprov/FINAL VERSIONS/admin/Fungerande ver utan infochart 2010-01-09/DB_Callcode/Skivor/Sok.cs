using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Web.Caching;
using System.Web.UI.HtmlControls;

using DB_proc;
using TF.Namespace.Controls;
using Common_Tasks;

namespace DB_Callcode.Skivor
{

    
    public class Sok
    {    
        Clear clr = new Clear();
        Proc_act db = new Proc_act();
        
        DataSet ds = new DataSet();

        //Tar emot angivelsen av hur lång tid cache:n skall verka
        private double delay;
        public double Delay
        { set { delay = value; }}

        
        //Söker i databas:
        public void button_sok(GridView grdResult, Page sida, 
        HtmlGenericControl display,  TextBox text3_Artist, 
        TextBox text4_Album, DropDownList text5_Format, 
        DropDownList text6_Press, DropDownList text8_ar, 
        TextBox text7_Kommentar) 
        {
            int rowcount = 0;

            string artist = text3_Artist.Text;
            string album = text4_Album.Text;
            string format = text5_Format.Text;
            string press = text6_Press.Text;
            string ar = text8_ar.Text;
            string kommentar = text7_Kommentar.Text;

            string res = "";
            string cnt = "";

            //Använder alla sökkriterier för att generera unika cachenycklar:
            ds = (DataSet)HttpRuntime.Cache["cache" + artist + album + format + press 
                  + ar + kommentar];
            
            if (ds == null)
            {

                try
                {
                    ds = db.SearchRecords(artist, album, format, press, ar, kommentar);

                    //Cache för varje unik sökning + 20 sek timeout (värdet av delay):
                    HttpRuntime.Cache.Insert("cache" + artist + album + format + press + ar + kommentar, ds, 
                    null, DateTime.Now.AddSeconds(delay), TimeSpan.Zero);

                    cnt = HttpRuntime.Cache.Count.ToString();
                    res = "Skapad och adderad till cache."; 
                }
                finally
                { }

           }
            else
            {
                cnt = HttpRuntime.Cache.Count.ToString();
                res = "Hämtad från cache.";
            }  

            grdResult.DataSource = ds;
            grdResult.DataBind();

            //Kollar så dataset har innehåll + exekvering är ok:
            rowcount = ds.Tables[0].Rows.Count;
           

            if (rowcount > 0)
            {
                //Rensar display från text och gridviews 
                clr.Clean_surfaces(sida);
                
                grdResult.Visible = true;
              
                DateTime Now = DateTime.Now;

                string add = "<h1>" + rowcount + " Post(er) hittades:</h1>";
                
                add += "<h2>" + "Cache status: " + res + "<br />";
                add += "Antal objekt i cache: " + cnt + "<br />";
                add += "Delay status: " + delay + "</h2>";
                
                add += "<h3>" + "Sidan skapades: " + Now + "</h3>";
                
                display.InnerHtml = add;
            }
            else
            {
                //Rensar display från text och gridviews 
                clr.Clean_surfaces(sida);
                
                display.InnerHtml = "<h2>Inga erhållna värden från databas.</h2>";
            }
        }



        




    }
}
