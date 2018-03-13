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
    public class Visa_KommentarPanel
    {
        Clear clr = new Clear();
        Proc_act db = new Proc_act();

        //Visar panel för inmatning av en artist kort-biografi:
        public void button_kommentarpanel(Panel pnlKommentar, Page sida)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces(sida);

            pnlKommentar.Visible = true;
         }

    }
}
