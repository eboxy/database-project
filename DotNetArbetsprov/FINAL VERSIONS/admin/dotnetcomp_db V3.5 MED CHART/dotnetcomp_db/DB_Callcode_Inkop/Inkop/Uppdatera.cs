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
    public class Uppdatera
    {
        Clear_Inkop clr = new Clear_Inkop();

        //Uppdaterar databas:
        public void button_uppdatera(GridView gridArtister_Inkop, GridView grdResult_Inkop,
        HtmlGenericControl display, Page sida, TextBox text3_Artist, TextBox text4_Album,
        DropDownList text5_Format, DropDownList text6_Press, DropDownList text8_ar,
        TextBox text7_Kommentar, TextBox text15_Inm_dat, DropDownList text16_Kop_grad,
        DropDownList text17_Kop_kat, TextBox text18_Ca_pris)
        {
            Int32 noupdrecs = 0;
            GridView updategrid = new GridView();

           
                if (grdResult_Inkop.Visible == true)
                {
                    updategrid = grdResult_Inkop;
                }
                else if (gridArtister_Inkop.Visible == true)
                {
                    updategrid = gridArtister_Inkop;
                }


                foreach (GridViewRow gvRow in updategrid.Rows)
                {

                    DerivCheckBox chksel = (DerivCheckBox)gvRow.FindControl("chkInkval");



                    if (chksel.Checked == true)
                    {
                        DB_proc_Inkop.Inkop db = new DB_proc_Inkop.Inkop();

                        Int32 row = Int32.Parse(chksel.UnText);
                        Int32 artist_no = Int32.Parse(text3_Artist.Text);
                        string album = text4_Album.Text;
                        string format = text5_Format.Text;
                        string press = text6_Press.Text;
                        string ar = text8_ar.Text;
                        string kommentar = text7_Kommentar.Text;
                        string Inm_dat = text15_Inm_dat.Text;
                        string Kop_grad = text16_Kop_grad.Text;
                        string Kop_kat = text17_Kop_kat.Text;
                        string Ca_pris = text18_Ca_pris.Text;

                        try
                        {
                            noupdrecs = db.UpdateRecord(row, artist_no, album,
                            format, press, ar, kommentar, Inm_dat, Kop_grad, 
                            Kop_kat, Ca_pris);
                        }
                        finally
                        { }


                        if (noupdrecs > 0)
                        {
                            //Rensar display från text och gridviews 
                            clr.Clean_surfaces_Inkop(sida);

                            DateTime Now = DateTime.Now;

                            string add = "<h1>Post i databas har uppdaterats</h1>";
                            add += "<h2>Data:</h2>";
                            add += "<h2><div id=visakommentar>Artist_no = " + artist_no + "<br />";
                            add += "Skivnummer = " + row + "<br />";
                            add += "Album = " + text4_Album.Text + "<br />";
                            add += "Format = " + text5_Format.Text + "<br />";
                            add += "Press = " + text6_Press.Text + "<br />";
                            add += "Ar = " + text8_ar.Text + "<br />";
                            add += "Inmatningsdatum = " + text15_Inm_dat.Text + "<br />";
                            add += "Köpgrad = " + text16_Kop_grad.Text + "<br />";
                            add += "Köpkategori = " + text17_Kop_kat.Text + "<br />";
                            add += "Cirkapris = " + text18_Ca_pris.Text + "<br />";
                            add += "Kommentar (se nedan): </div></h2>";
                            add += "<div id=visakommentar>" + "<div>" + text7_Kommentar.Text + "</div>";

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






}
