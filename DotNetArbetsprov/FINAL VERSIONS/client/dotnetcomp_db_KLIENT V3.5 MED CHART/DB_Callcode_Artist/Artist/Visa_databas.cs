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
    public class Visa_databas
    {
        Clear_Artist clr = new Clear_Artist();

        //Hämtar hela databasen
        public void button_visa_databas(GridView gridArtister_Artist, Page sida)
        {
            if (gridArtister_Artist.Visible == false)
            {
                //Rensar display från text och gridviews 
                clr.Clean_surfaces_Artist(sida);

                gridArtister_Artist.Visible = true;

            }
        }

    }
}
