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
    public class Uppdatera
    {
        Clear_Artist clr = new Clear_Artist();

        //Uppdaterar databas:
        public void button_uppdatera(GridView gridArtister_Artist, 
        GridView grdResult_Artist, HtmlGenericControl display, 
        Page sida, TextBox text3_Artist, DropDownList text9_VPfr, 
        DropDownList text10_VPtill, DropDownList text11_Ursland, 
        TextBox text12_Ursstad, DropDownList text13_Musiktyp, 
        TextBox text14_Kortbio)
        {
            Int32 noupdrecs = 0;
            GridView updategrid = new GridView();

            
                if (grdResult_Artist.Visible == true)
                {
                    updategrid = grdResult_Artist;
                }
                else if (gridArtister_Artist.Visible == true)
                {
                    updategrid = gridArtister_Artist;
                }


                foreach (GridViewRow gvRow in updategrid.Rows)
                {

                    DerivCheckBox chksel = (DerivCheckBox)gvRow.FindControl("chkArtval");



                    if (chksel.Checked == true)
                    {
                        DB_proc_Artist.Artist db = new DB_proc_Artist.Artist();

                        Int32 row = Int32.Parse(chksel.UnText);
                        string artist = text3_Artist.Text;
                        string vpfr = text9_VPfr.Text;
                        string vptill = text10_VPtill.Text;
                        string ursland = text11_Ursland.Text;
                        string ursstad = text12_Ursstad.Text;
                        string musiktyp = text13_Musiktyp.Text;
                        string kortbio = text14_Kortbio.Text;


                        try
                        {
                          noupdrecs = db.UpdateRecord(row, artist, vpfr,
                          vptill, ursland, ursstad, musiktyp, kortbio);     
                        }
                        finally
                        { }


                        if (noupdrecs > 0)
                        {
                            //Rensar display från text och gridviews 
                            clr.Clean_surfaces_Artist(sida);

                            DateTime Now = DateTime.Now;

                            string add = "<h1>Post i databas har uppdaterats</h1>";
                            add += "<h2>Data:</h2>";
                            add += "<h2><div id=visakommentar>Artist_no = " + row + "<br />";
                            add += "Artist = " + text3_Artist.Text + "<br />";
                            add += "VPfr = " + text9_VPfr.Text + "<br />";
                            add += "VPtill = " + text10_VPtill.Text + "<br />";
                            add += "Ursland = " + text11_Ursland.Text + "<br />";
                            add += "Ursstad = " + text12_Ursstad.Text + "<br />";
                            add += "Musiktyp = " + text13_Musiktyp.Text + "<br />";
                            add += "Kortbio (se nedan): </div></h2>" + "<div id=visakommentar>"; 
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




}
