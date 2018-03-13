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
using System.Collections;

using DB_proc_Artist;
using TF.Namespace.Controls;
using Common_Tasks_Artist;

namespace DB_Callcode_Artist.Artist
{
    public class Lagg_till
    {
        Clear_Artist clr = new Clear_Artist();
        DB_proc_Artist.Artist db = new DB_proc_Artist.Artist();


        //Lägger till data i databas 
        public void button_lagg_till(HtmlGenericControl display, 
        TextBox text3_Artist, DropDownList text9_VPfr, 
        DropDownList text10_VPtill, DropDownList text11_Ursland, 
        TextBox text12_Ursstad, DropDownList text13_Musiktyp,
        TextBox text14_Kortbio, BaseValidator vldArtistNotEmpty, 
        BaseValidator vldArtistOnlyLetters, Page sida)
        {
            Int32 val = 0; 
            Int32 noaddrecs = 0;
            string errorsum = "";
            int rowcount = 0;

            if (!sida.IsValid)
            {
                Dictionary<BaseValidator, string> dict = new Dictionary<BaseValidator, string>();
                dict.Add(vldArtistNotEmpty, "<h2>Ej matat in artistnamn. Försök igen.</h2>");
                dict.Add(vldArtistOnlyLetters, "<h2>Endast bokstäver är tillåtna vid angivelse av ursprungsstad.</h2>");
                
                rowcount = dict.Count;
                
                
                //Value- och key-kollektioner initieras mha Interface:
                ICollection keyKollektion = dict.Keys;
                ICollection valueKollektion = dict.Values;

                //Skapar arrays och kopierar kollektionerna till desamma:
                BaseValidator[] keys = new BaseValidator[rowcount];
                string[] values = new string[rowcount];
                keyKollektion.CopyTo(keys, 0);
                valueKollektion.CopyTo(values, 0);

                //Utvärderar fält mha validationskontroller och skriver 
                //felmeddelande till gemensam sträng:

                for (int i = 0; i < rowcount; i++)
                {
                    if (!keys[i].IsValid)
                    {
                        errorsum += values[i];
                    }
                }
                

                //Rensar display från text och gridviews 
                clr.Clean_surfaces_Artist(sida);

                //Skriver gemensam felmeddelande-sträng till display:
                display.InnerHtml = errorsum;
            }
            else
            {
                try
                {
                    noaddrecs = db.AddRecord(val, text3_Artist.Text,
                    text9_VPfr.Text, text10_VPtill.Text, text11_Ursland.Text, text12_Ursstad.Text,
                    text13_Musiktyp.Text, text14_Kortbio.Text);
                }
                finally
                { }

                if (noaddrecs > 0)
                {
                    //Rensar display från text och gridviews 
                    clr.Clean_surfaces_Artist(sida);

                    DateTime Now = DateTime.Now;

                    string add = "<h1>Ny post har lagts till databasen</h1>";
                    add += "<h2>Data:</h2>";
                    add += "<h2><div id=visakommentar>KryssruteVärde = " + val + "<br />";
                    add += "Artist = " + text3_Artist.Text + "<br />";
                    add += "VPfr = " + text9_VPfr.Text + "<br />";
                    add += "VPtill = " + text10_VPtill.Text + "<br />";
                    add += "Ursland = " + text11_Ursland.Text + "<br />";
                    add += "Ursstad = " + text12_Ursstad.Text + "<br />";
                    add += "Musiktyp = " + text13_Musiktyp.Text + "<br />";
                    add += "Kortbio (se nedan): </div></h2>" + "<div id=visakortbiodata>";
                    add += text14_Kortbio.Text + "</div>";

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



}
