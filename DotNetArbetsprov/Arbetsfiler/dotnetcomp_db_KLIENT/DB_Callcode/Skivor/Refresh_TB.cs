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


namespace DB_Callcode.Skivor
{
    public class Refresh_TB
    {
        //Fungerar som en omstart och rensar alla inmatningsrutor odyl + display:
        public void button_Refresh_TB(HttpServerUtility server, string retursida)
        {

            try
            {
              server.Transfer(retursida);
            }
            finally
            { }


          
        }

    }
}
