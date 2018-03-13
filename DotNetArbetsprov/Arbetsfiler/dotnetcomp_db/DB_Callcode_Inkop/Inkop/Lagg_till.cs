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

using DB_proc_Inkop;
using TF.Namespace.Controls;
using Common_Tasks_Inkop;

namespace DB_Callcode_Inkop.Inkop
{
    public class Lagg_till
    {
        Clear_Inkop clr = new Clear_Inkop();
        DB_proc_Inkop.Inkop db = new DB_proc_Inkop.Inkop(); 
        
        //Lägger till data i databas 
        public void button_lagg_till(HtmlGenericControl display, TextBox text3_Artist, 
        TextBox text4_Album, DropDownList text5_Format, DropDownList text6_Press, 
        DropDownList text8_ar, TextBox text7_Kommentar, TextBox text15_Inm_dat, 
        DropDownList text16_Kop_grad, DropDownList text17_Kop_kat, TextBox text18_Ca_pris, 
        BaseValidator vldDatum, BaseValidator vldCaPris, BaseValidator vldArtistOnlyNum, 
        BaseValidator vldArtistNotEmpty, BaseValidator vldArtistValidRange, Page sida)
        {
            Int32 val = 0;
            Int32 noaddrecs = 0;
            string errorsum = "";
            int rowcount = 0;

            string vldArtistValidRangeErrText = "<h2>Artistnummer utanför registrerade värden ";
            vldArtistValidRangeErrText += "i databas. Kolla i artisttabellen och försök igen.</h2>";


            if (!sida.IsValid)
            {
                Dictionary<BaseValidator, string> dict = new Dictionary<BaseValidator, string>();
                dict.Add(vldArtistNotEmpty, "<h2>Ej matat in artistnummer. Kolla i artisttabellen och försök igen.</h2>");
                dict.Add(vldArtistOnlyNum, "<h2>Endast siffor är tillåtna som artistnummer.</h2>");
                dict.Add(vldDatum, "<h2>Ej tillåtet datumformat angivet.</h2>");
                dict.Add(vldCaPris, "<h2>Ej tillåtet format för cirkapris angivet.</h2>");
                dict.Add(vldArtistValidRange, vldArtistValidRangeErrText);

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
                for (int i = 0; i < rowcount-1; i++)
                {
                    if (!keys[i].IsValid)
                    {
                        errorsum += values[i];
                    }
                }

                if (!keys[rowcount-1].IsValid && keys[1].IsValid)
                    errorsum += values[rowcount-1];


               
                //Rensar display från text och gridviews 
                clr.Clean_surfaces_Inkop(sida);

                //Skriver gemensam felmeddelande-sträng till display:
                display.InnerHtml = errorsum;
            }
            else
            {
                try
                {
                    noaddrecs = db.AddRecord(val, Int32.Parse(text3_Artist.Text),
                    text4_Album.Text, text5_Format.Text, text6_Press.Text, text8_ar.Text,
                    text7_Kommentar.Text, text15_Inm_dat.Text, text16_Kop_grad.Text, 
                    text17_Kop_kat.Text, text18_Ca_pris.Text);

                }   
                finally
                { }

                if (noaddrecs > 0)
                {
                    //Rensar display från text och gridviews 
                    clr.Clean_surfaces_Inkop(sida);

                    DateTime Now = DateTime.Now;

                    string add = "<h1>Ny post har lagts till databasen</h1>";
                    add += "<h2>Data:</h2>";
                    add += "<h2><div id=visakommentar>KryssruteVärde = " + val + "<br />";
                    add += "Artist_no = " + text3_Artist.Text + "<br />";
                    add += "Album = " + text4_Album.Text + "<br />";
                    add += "Format = " + text5_Format.Text + "<br />";
                    add += "Press = " + text6_Press.Text + "<br />";
                    add += "År = " + text8_ar.Text + "<br />";
                    add += "Inmatningsdatum = " + text15_Inm_dat.Text + "<br />";
                    add += "Köpgrad = " + text16_Kop_grad.Text + "<br />";
                    add += "Köpkategori = " + text17_Kop_kat.Text + "<br />";
                    add += "Cirkapris = " + text18_Ca_pris.Text + "<br />";
                    add += "Kommentar (se nedan): </div></h2>";
                    add += "<div id=visakommentar>" + text7_Kommentar.Text + "</div>";
                    
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






}
