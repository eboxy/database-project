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
    public class Uppdatera
    {
        Clear clr = new Clear();
        

        //Uppdaterar databas:
        public void button_uppdatera(GridView gridArtister, GridView grdResult, 
        HtmlGenericControl display, Page sida, TextBox text3_Artist, 
        TextBox text4_Album, DropDownList text5_Format, DropDownList text6_Press, 
        DropDownList text8_ar, TextBox text7_Kommentar)
        {
            Int32 noupdrecs = 0;
            GridView updategrid = new GridView();

            
               
            
                if (grdResult.Visible == true)
                {
                    updategrid = grdResult;
                }
                else if (gridArtister.Visible == true)
                {
                    updategrid = gridArtister;
                }

    
                foreach (GridViewRow gvRow in updategrid.Rows)
                {

                    DerivCheckBox chksel = (DerivCheckBox)gvRow.FindControl("chkCDval");



                    if (chksel.Checked == true)
                    {
                        Proc_act db = new Proc_act();

                        Int32 row = Int32.Parse(chksel.UnText);
                        Int32 artist_no = Int32.Parse(text3_Artist.Text);
                        string album = text4_Album.Text;
                        string format = text5_Format.Text;
                        string press = text6_Press.Text;
                        string ar = text8_ar.Text;
                        string kommentar = text7_Kommentar.Text;


                        try
                        {
                            noupdrecs = db.UpdateRecord(row, artist_no, album, 
                            format, press, ar, kommentar);
                        }
                        finally
                        { }

                        
                        if (noupdrecs > 0)
                        {
                            //Rensar display från text och gridviews 
                            clr.Clean_surfaces(sida);

                            DateTime Now = DateTime.Now;

                            string add = "<h1>Post i databas har uppdaterats</h1>";
                            add += "<h2>Data:</h2>";
                            add += "<h2><div id=visakommentar>Artist_no = " + artist_no + "<br />"; 
                            add += "Skivnummer = " + row + "<br />";
                            add += "Album = " + text4_Album.Text + "<br />"; 
                            add += "Format = " + text5_Format.Text + "<br />";
                            add += "Press = " + text6_Press.Text + "<br />";
                            add += "Ar = " + text8_ar.Text + "<br />";
                            add += "Kommentar (se nedan): </div></h2>";
                            add += "<div id=visakommentar>" + "<div>" + text7_Kommentar.Text + "</div>";

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


    }


}
