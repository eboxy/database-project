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

using DB_proc_Artist;
using TF.Namespace.Controls;
using Common_Tasks_Artist;

namespace DB_Callcode_Artist.Artist
{
    public class Sok
    {

        Clear_Artist clr = new Clear_Artist();
        DB_proc_Artist.Artist db = new DB_proc_Artist.Artist();

        DataSet ds = new DataSet();

        //Tar emot angivelsen av hur lång tid cache:n skall verka
        private double delay;
        public double Delay
        { set { delay = value; }}


        //Söker i databas:
        public void button_sok(GridView grdResult_Artist, Page sida,
        HtmlGenericControl display, TextBox text3_Artist, 
        DropDownList text9_VPfr, DropDownList text10_VPtill, 
        DropDownList text11_Ursland, TextBox text12_Ursstad,
        DropDownList text13_Musiktyp, TextBox text14_Kortbio)
        {
            int rowcount = 0;

            string artist = text3_Artist.Text;
            string vpfr = text9_VPfr.Text;
            string vptill = text10_VPtill.Text;
            string ursland = text11_Ursland.Text;
            string ursstad = text12_Ursstad.Text;
            string musiktyp = text13_Musiktyp.Text;
            string kortbio = text14_Kortbio.Text;
            
            string res = "";
            string cnt = "";

            //Använder alla sökkriterier för att generera unika cachenycklar:
            ds = (DataSet)HttpRuntime.Cache["cache" + artist + vpfr + vptill + ursland
                  + ursstad + musiktyp + kortbio];

            if (ds == null)
            {

                try
                {
                    ds = db.SearchRecords(artist, vpfr, vptill, ursland
                        , ursstad, musiktyp, kortbio);

                    //Cache för varje unik sökning + 20 sek timeout (värdet av delay):
                    HttpRuntime.Cache.Insert("cache" + artist + vpfr + vptill + ursland
                    + ursstad + musiktyp + kortbio, ds, null, DateTime.Now.AddSeconds(delay), 
                    TimeSpan.Zero);

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

            grdResult_Artist.DataSource = ds;
            grdResult_Artist.DataBind();

            //Kollar så dataset har innehåll + exekvering är ok:
            rowcount = ds.Tables[0].Rows.Count;


            if (rowcount > 0)
            {
                //Rensar display från text och gridviews 
                clr.Clean_surfaces_Artist(sida);

                grdResult_Artist.Visible = true;

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
                clr.Clean_surfaces_Artist(sida);

                display.InnerHtml = "<h2>Inga erhållna värden från databas.</h2>";
            }
        }


    }





}
