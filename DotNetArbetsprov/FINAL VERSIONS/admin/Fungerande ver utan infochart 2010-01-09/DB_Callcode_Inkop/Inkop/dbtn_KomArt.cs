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
    public class dbtn_KomArt
    {
        Clear_Inkop clr = new Clear_Inkop(); 
        DB_proc_Inkop.Inkop db = new DB_proc_Inkop.Inkop();


        //Kommentarknapp och Artistknapp: 
        public void gridArtister_Inkop_RowCommand(
        GridView grd_Artistdata_Inkop,  HtmlGenericControl display,
        HtmlGenericControl display2, Page sida, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "Kommentar")
            {

                int row = Convert.ToInt32(e.CommandArgument);
                string kom = "";
                int rowcount = 0;

                try
                {
                    DataSet ds = new DataSet();
                    ds = db.CD_Kommentarer(row);
                    kom = ds.Tables[0].Rows[0]["Komt"].ToString();
                    rowcount = int.Parse(ds.Tables[0].Rows.Count.ToString());
                }
                finally
                { }

                if (rowcount > 0)
                {
                    //Rensar display från text och gridviews 
                    clr.Clean_surfaces_Inkop(sida);

                    DateTime Now = DateTime.Now;

                    string add = "<h1>Kommentar No: " + row + "</h1>";
                    add += "<div id=visakommentar>" + kom + "</div>";
                    add += "<h3>" + "Sidan skapades: " + Now + "</h3>";
                    display.InnerHtml = add;
                }
                else
                {
                    //Rensar display från text och gridviews 
                    clr.Clean_surfaces_Inkop(sida);

                    display.InnerHtml = "<h2>Inga erhållna värden från databas.</h2>";
                }

            }
            else if (e.CommandName == "Artist")
            {

                int row = Convert.ToInt32(e.CommandArgument);
                int rowcount = 0;

                try
                {
                    DataSet ds = new DataSet();
                    ds = db.CD_VisaArtistData(row);

                    grd_Artistdata_Inkop.DataSource = ds;
                    grd_Artistdata_Inkop.DataBind();

                    rowcount = int.Parse(ds.Tables[0].Rows.Count.ToString());

                }
                finally
                { }

                if (rowcount > 0)
                {
                    //Rensar display från text och gridviews 
                    clr.Clean_surfaces_Inkop(sida);


                    grd_Artistdata_Inkop.Visible = true;


                    DateTime Now = DateTime.Now;

                    string add1 = "<h1>Artistdata No: " + row + "</h1>";
                    string add2 = "<h3>" + "Sidan skapades: " + Now + "</h3>";

                    display.InnerHtml = add1;
                    display2.InnerHtml = add2;
                }
                else
                {
                    //Rensar display från text och gridviews 
                    clr.Clean_surfaces_Inkop(sida);

                    display.InnerHtml = "<h2>Inga erhållna värden från databas.</h2>";
                }
            }


        }


    }






}
