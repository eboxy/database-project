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
    public class dbtn_Kommentar_Output
    {
        Clear clr = new Clear();
        Proc_act db = new Proc_act();


        //Hämtar längre kommentar från skivtabell (via kommentarpanel)
        public void dynbtnKommentarFetch(HtmlGenericControl display, 
        Panel pnlKommentar, TextBox txtKommentar, TextBox txtKommentarNo,
        Page sida)
        {

            int rowcount = 0;

            try
            {
                DataSet ds = new DataSet();

                ds = db.FetchKommentar(Int32.Parse(txtKommentarNo.Text));
                txtKommentar.Text = ds.Tables[0].Rows[0]["Kommentar"].ToString();
                rowcount = int.Parse(ds.Tables[0].Rows.Count.ToString());
            }
            finally
            { }


            if (rowcount == 1)
            {
                //Rensar display från text och gridviews 
                clr.Clean_surfaces(sida);

                pnlKommentar.Visible = true;
            }
            else
            {
                //Rensar display från text och gridviews 
                clr.Clean_surfaces(sida);

                display.InnerHtml = "<h3>Inga erhållna värden från databas.</h3>";
            }
        }


    }
}
