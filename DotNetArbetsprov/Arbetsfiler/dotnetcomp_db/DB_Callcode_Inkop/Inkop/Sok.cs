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

using DB_proc_Inkop;
using TF.Namespace.Controls;
using Common_Tasks_Inkop;

namespace DB_Callcode_Inkop.Inkop
{
    public class Sok
    {
        Clear_Inkop clr = new Clear_Inkop();
        DB_proc_Inkop.Inkop db = new DB_proc_Inkop.Inkop();

        DataSet ds = new DataSet();

        //Tar emot angivelsen av hur lång tid cache:n skall verka
        private double delay;
        public double Delay
        { set { delay = value; } get { return delay; }}

        
        //Söker i databas:
        public void button_sok(GridView grdResult_Inkop, Page sida, 
        HtmlGenericControl display, TextBox text3_Artist, TextBox text4_Album, 
        DropDownList text5_Format, DropDownList text6_Press, DropDownList text8_ar, 
        TextBox text7_Kommentar, TextBox text15_Inm_dat, DropDownList text16_Kop_grad, 
        DropDownList text17_Kop_kat, TextBox text18_Ca_pris)
        {
            int rowcount = 0;

            string art_no = text3_Artist.Text;
            string album = text4_Album.Text;
            string format = text5_Format.Text;
            string press = text6_Press.Text;
            string ar = text8_ar.Text;
            string kommentar = text7_Kommentar.Text;
            string inm_dat=text15_Inm_dat.Text;
            string kop_grad=text16_Kop_grad.Text;
            string kop_kat=text17_Kop_kat.Text;
            string ca_pris = text18_Ca_pris.Text;

            string res = "";
            string cnt = "";

            //Använder alla sökkriterier för att generera unika cachenycklar:
            ds = (DataSet)HttpRuntime.Cache["cache" + art_no + album + format + press
                  + ar + kommentar + inm_dat + kop_grad + kop_kat + ca_pris];

            if (ds == null)
            {

                try
                {
                    ds = db.SearchRecords(art_no, album, format, press, ar, kommentar, inm_dat, kop_grad, kop_kat, ca_pris);

                    //Cache för varje unik sökning + 20 sek timeout (värdet av delay):
                    HttpRuntime.Cache.Insert("cache" + art_no + album + format + press + ar + kommentar + inm_dat 
                    + kop_grad + kop_kat + ca_pris, ds, null, DateTime.Now.AddSeconds(delay), TimeSpan.Zero);
                   
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

            grdResult_Inkop.DataSource = ds;
            grdResult_Inkop.DataBind();

            //Kollar så dataset har innehåll + exekvering är ok:
            rowcount = ds.Tables[0].Rows.Count;


            if (rowcount > 0)
            {
                //Rensar display från text och gridviews 
                clr.Clean_surfaces_Inkop(sida);

                grdResult_Inkop.Visible = true;

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
                clr.Clean_surfaces_Inkop(sida);

                display.InnerHtml = "<h2>Inga erhållna värden från databas.</h2>";
            }
        }


    }






}
