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
    public class Visa_databas
    {
        Clear_Inkop clr = new Clear_Inkop(); 



        //Hämtar hela databasen
        public void button_visa_databas(GridView gridArtister_Inkop, Page sida)
        {
            if (gridArtister_Inkop.Visible == false)
            {
                //Rensar display från text och gridviews 
                clr.Clean_surfaces_Inkop(sida);

                gridArtister_Inkop.Visible = true;

            }
        }

    }

}
