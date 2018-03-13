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
    public class Visa_databas
    {
        Clear clr = new Clear();

        

        //Hämtar hela databasen
        public void button_visa_databas(GridView gridArtister, Page sida)
        {
             if (gridArtister.Visible == false)
            {
                //Rensar display från text och gridviews 
                clr.Clean_surfaces(sida);
                
                gridArtister.Visible = true;
                
            }
        }
    
    }

   
}
