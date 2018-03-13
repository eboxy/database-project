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
    public class dbtn_Kommentar_Input
    {

        Clear clr = new Clear();
        Proc_act db = new Proc_act();


        //Matar in längre kommentar till skivtabell:
        public void dynbtnKommentar(HtmlGenericControl display, 
        TextBox txtKommentar, TextBox txtKommentarNo, Page sida)
        {

            int noaddkommentar = 0;


            try
            {
                noaddkommentar = db.AddKommentar(txtKommentar.Text, Int32.Parse(txtKommentarNo.Text));
            }
            finally
            { }


            if (noaddkommentar > 0)
            {
                //Rensar display från text och gridviews 
                clr.Clean_surfaces(sida);

                DateTime Now = DateTime.Now;

                string add = "<h1>Ny kommentar har lagts till databasen</h1>";
                add += "<h2>Kommentar för artistno: " + txtKommentarNo.Text + "</h2>";
                add += "<h2>Inmatat till DB:</h2> ";
                add += "<div id=kommentarpanel_input>" + txtKommentar.Text + "</div>";

                add += "<h3>" + "Sidan skapades: " + Now + "</h3>";

                display.InnerHtml = add;

            }
            else
            {
                //Rensar display från text och gridviews 
                clr.Clean_surfaces(sida);

                display.InnerHtml = "<h2>Inga erhållna värden från databas.</h2>";
            }





        }

    }
}
