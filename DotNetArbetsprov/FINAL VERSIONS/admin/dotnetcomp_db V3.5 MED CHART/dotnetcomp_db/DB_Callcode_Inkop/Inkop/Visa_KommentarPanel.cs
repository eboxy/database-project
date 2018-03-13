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
    public class Visa_KommentarPanel
    {
        Clear_Inkop clr = new Clear_Inkop(); 
        DB_proc_Inkop.Inkop db = new DB_proc_Inkop.Inkop();

        //Visar panel för inmatning av en artist kort-biografi:
        public void button_kommentarpanel(Panel pnlKommentar_Inkop, Page sida)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(sida);

            pnlKommentar_Inkop.Visible = true;
        }

    }




}
