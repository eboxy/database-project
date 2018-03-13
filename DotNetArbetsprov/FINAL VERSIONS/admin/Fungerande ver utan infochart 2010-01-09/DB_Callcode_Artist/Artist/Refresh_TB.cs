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
    public class Refresh_TB
    {
        //Fungerar som en omstart och rensar alla inmatningsrutor odyl + display:
        public void button_Refresh_TB(HttpServerUtility server, string retursida)
        {
            SetChks_Artist db = new SetChks_Artist();
            Int32 val = 0;

            try
            {
                db.UpdateRecord_Artist_ChkBox(val);
                server.Transfer(retursida);
            }
            finally
            { }



        }

    }
}
