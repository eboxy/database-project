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
    public class dbtn_Kortbio_Output
    {

        Clear_Artist clr = new Clear_Artist();
        DB_proc_Artist.Artist db = new DB_proc_Artist.Artist();


        //Hämtar kortio från artist-tabell (via kortbiopanel)
        public void dynbtnKortbioFetch(HtmlGenericControl display, 
        Panel pnlKortbio, TextBox txtKortbio, TextBox txtArtistNo, 
        Page sida)
        {

            int rowcount = 0;

            try
            {
                DataSet ds = new DataSet();

                ds = db.FetchKortbio(Int32.Parse(txtArtistNo.Text));
                txtKortbio.Text = ds.Tables[0].Rows[0]["Kortbio"].ToString();
                rowcount = int.Parse(ds.Tables[0].Rows.Count.ToString());
            }
            finally
            { }


            if (rowcount == 1)
            {
                //Rensar display från text och gridviews 
                clr.Clean_surfaces_Artist(sida);

                pnlKortbio.Visible = true;
            }
            else
            {
                //Rensar display från text och gridviews 
                clr.Clean_surfaces_Artist(sida);

                display.InnerHtml = "<h3>Inga erhållna värden från databas.</h3>";
            }
        }
    }




}
