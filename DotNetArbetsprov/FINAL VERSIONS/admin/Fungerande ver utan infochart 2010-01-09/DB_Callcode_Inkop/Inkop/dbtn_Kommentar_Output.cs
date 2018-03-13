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
    public class dbtn_Kommentar_Output
    {
        Clear_Inkop clr = new Clear_Inkop();
        DB_proc_Inkop.Inkop db = new DB_proc_Inkop.Inkop();


        //Hämtar längre kommentar från skivtabell (via kommentarpanel)
        public void dynbtnKommentarFetch(HtmlGenericControl display, 
        Panel pnlKommentar_Inkop, TextBox txtKommentar, 
        TextBox txtKommentarNo, Page sida)
        {

            int rowcount = 0;

            try
            {
                DataSet ds = new DataSet();

                ds = db.FetchKommentar(Int32.Parse(txtKommentarNo.Text));
                txtKommentar.Text = ds.Tables[0].Rows[0]["Komt"].ToString();
                rowcount = int.Parse(ds.Tables[0].Rows.Count.ToString());
            }
            finally
            { }


            if (rowcount == 1)
            {
                //Rensar display från text och gridviews 
                clr.Clean_surfaces_Inkop(sida);

                pnlKommentar_Inkop.Visible = true;
            }
            else
            {
                //Rensar display från text och gridviews 
                clr.Clean_surfaces_Inkop(sida);

                display.InnerHtml = "<h3>Inga erhållna värden från databas.</h3>";
            }
        }


    }





}
