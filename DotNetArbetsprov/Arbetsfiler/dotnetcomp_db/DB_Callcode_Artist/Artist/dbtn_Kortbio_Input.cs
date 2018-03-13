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
    public class dbtn_Kortbio_Input
    {
        Clear_Artist clr = new Clear_Artist();
        DB_proc_Artist.Artist db = new DB_proc_Artist.Artist();
        

        //Matar in data till kortibo (via kortbiopanel) i artist-tabell 
        public void dynbtnKortbio(HtmlGenericControl display, 
       TextBox txtKortbio, TextBox txtArtistNo, Page sida)
        {

            int noaddkortbio = 0;


            try
            {
                noaddkortbio = db.AddKortbio(txtKortbio.Text, Int32.Parse(txtArtistNo.Text));
            }
            finally
            { }


            if (noaddkortbio > 0)
            {
                //Rensar display från text och gridviews 
                clr.Clean_surfaces_Artist(sida);

                DateTime Now = DateTime.Now;

                string add = "<h1>Ny Kortbio har lagts till databasen</h1>";
                add += "<h2>Kortbio för artistno: " + txtArtistNo.Text + "</h2>";
                add += "<h2>Inmatat till DB:</h2> ";
                add += "<div id=kortbiopanel_input>" + txtKortbio.Text + "</div>";

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
