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
    public class Fetch
    {
        Clear_Artist clr = new Clear_Artist();
        DB_proc_Artist.Artist db = new DB_proc_Artist.Artist();
         
        //Hämtar en rad från aktuell tabell som skall uppdateras:
        public void button_fetch(GridView gridArtister_Artist, 
        GridView grdResult_Artist, HtmlGenericControl display, 
        HtmlGenericControl display2, Page sida, TextBox text3_Artist, 
        DropDownList text9_VPfr, DropDownList text10_VPtill, 
        DropDownList text11_Ursland, TextBox text12_Ursstad,
        DropDownList text13_Musiktyp, TextBox text14_Kortbio)
        {
            


            GridView fetchgrid = new GridView();


            int a = 0;
            int rowcount = 0;


            if (grdResult_Artist.Visible == true)
            {
                fetchgrid = grdResult_Artist;
            }
            else if (gridArtister_Artist.Visible == true)
            {
                fetchgrid = gridArtister_Artist;
            }



            foreach (GridViewRow gvRow in fetchgrid.Rows)
            {

                DerivCheckBox chksel = (DerivCheckBox)gvRow.FindControl("chkArtval");

                if (chksel.Checked == true)
                {
                    a++;
                }
            }

            if (a == 0)
            {
                //Rensar display från text och gridviews 
                clr.Clean_surfaces_Artist(sida);

                display.InnerHtml = "<h2>Ingen kryssruta ifylld.</h2>";
            }
            else if (a > 1)
            {
                //Rensar display från text och gridviews 
                clr.Clean_surfaces_Artist(sida);

                display.InnerHtml = "<h2>Endast EN kryssruta får vara ifylld.</h2>";
            }
            else
            {
                try
                {
                    DataSet ds = new DataSet();
                    ds = db.FetchRecord();

                    grdResult_Artist.DataSource = ds;
                    grdResult_Artist.DataBind();

                    text3_Artist.Text = ds.Tables[0].Rows[0]["Artist"].ToString();
                    text9_VPfr.Text = ds.Tables[0].Rows[0]["VPfr"].ToString();
                    text10_VPtill.Text = ds.Tables[0].Rows[0]["VPtill"].ToString();
                    text11_Ursland.Text = ds.Tables[0].Rows[0]["Ursland"].ToString();
                    text12_Ursstad.Text = ds.Tables[0].Rows[0]["Ursstad"].ToString();
                    text13_Musiktyp.Text = ds.Tables[0].Rows[0]["Musiktyp"].ToString();
                    text14_Kortbio.Text = ds.Tables[0].Rows[0]["Kortbio"].ToString();

                    rowcount = int.Parse(ds.Tables[0].Rows.Count.ToString());
                }
                finally
                { }


                if (rowcount == 1)
                {
                    //Rensar display från text och gridviews 
                    clr.Clean_surfaces_Artist(sida);


                    grdResult_Artist.HeaderRow.FindControl("chkArtval_ALL").Visible = false;

                    grdResult_Artist.Visible = true;

                    DateTime Now = DateTime.Now;

                    string add1 = "<h1>Post har hämtats till databas för uppdatering</h1>";
                    string add2 = "<h3>" + "Sidan skapades: " + Now + "</h3>";
                    display.InnerHtml = add1;
                    display2.InnerHtml = add2;
                }
                else
                {
                    //Rensar display från text och gridviews 
                    clr.Clean_surfaces_Artist(sida);

                    display.InnerHtml = "<h2>Inga erhållna värden från databas.</h2>";
                }

            }

        }

    }





}
