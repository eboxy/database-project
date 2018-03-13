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
    public class Visa_KortBioPanel
    {
        Clear_Artist clr = new Clear_Artist();
        DB_proc_Artist.Artist db = new DB_proc_Artist.Artist();

        //Visar panel för inmatning av en artist kort-biografi:
        public void button_kortbiopanel(Panel pnlKortbio, Page sida)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Artist(sida);

            pnlKortbio.Visible = true;
        }

    }

}
