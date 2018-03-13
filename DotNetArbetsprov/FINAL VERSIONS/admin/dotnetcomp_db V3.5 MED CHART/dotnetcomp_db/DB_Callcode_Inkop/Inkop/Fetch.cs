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
    public class Fetch
    {
        Clear_Inkop clr = new Clear_Inkop();
        DB_proc_Inkop.Inkop db = new DB_proc_Inkop.Inkop();


        //Hämtar en rad från aktuell tabell som skall uppdateras:
        public void button_fetch(GridView gridArtister_Inkop, GridView grdResult_Inkop,
        HtmlGenericControl display, HtmlGenericControl display2,
        Page sida, TextBox text3_Artist, TextBox text4_Album,
        DropDownList text5_Format, DropDownList text6_Press, DropDownList text8_ar,
        TextBox text7_Kommentar, TextBox text15_Inm_dat, DropDownList text16_Kop_grad, 
        DropDownList text17_Kop_kat, TextBox text18_Ca_pris)
        {
            DB_proc_Inkop.Inkop db = new DB_proc_Inkop.Inkop();

            GridView fetchgrid = new GridView();


            int a = 0;
            int rowcount = 0;


            if (grdResult_Inkop.Visible == true)
            {
                fetchgrid = grdResult_Inkop;
            }
            else if (gridArtister_Inkop.Visible == true)
            {
                fetchgrid = gridArtister_Inkop;
            }



            foreach (GridViewRow gvRow in fetchgrid.Rows)
            {

                DerivCheckBox chksel = (DerivCheckBox)gvRow.FindControl("chkInkval");

                if (chksel.Checked == true)
                {
                    a++;
                }
            }

            if (a == 0)
            {
                //Rensar display från text och gridviews 
                clr.Clean_surfaces_Inkop(sida);

                display.InnerHtml = "<h2>Ingen kryssruta ifylld.</h2>";
            }
            else if (a > 1)
            {
                //Rensar display från text och gridviews 
                clr.Clean_surfaces_Inkop(sida);

                display.InnerHtml = "<h2>Endast EN kryssruta får vara ifylld.</h2>";
            }
            else
            {
                try
                {
                    DataSet ds = new DataSet();
                    ds = db.FetchRecord();

                    grdResult_Inkop.DataSource = ds;
                    grdResult_Inkop.DataBind();

                    text3_Artist.Text = ds.Tables[0].Rows[0]["Art_no"].ToString();
                    text4_Album.Text = ds.Tables[0].Rows[0]["Titel"].ToString();
                    text5_Format.Text = ds.Tables[0].Rows[0]["Form"].ToString();
                    text6_Press.Text = ds.Tables[0].Rows[0]["Land"].ToString();
                    text8_ar.Text = ds.Tables[0].Rows[0]["Utg"].ToString();
                    text7_Kommentar.Text = ds.Tables[0].Rows[0]["Komt"].ToString();
                    text15_Inm_dat.Text = ds.Tables[0].Rows[0]["Inm_dat"].ToString();
                    text16_Kop_grad.Text = ds.Tables[0].Rows[0]["Kop_grad"].ToString();
                    text17_Kop_kat.Text = ds.Tables[0].Rows[0]["Kop_kat"].ToString();
                    text18_Ca_pris.Text = ds.Tables[0].Rows[0]["Ca_pris"].ToString();

                    rowcount = int.Parse(ds.Tables[0].Rows.Count.ToString());
                }
                finally
                { }


                if (rowcount == 1)
                {
                    //Rensar display från text och gridviews 
                    clr.Clean_surfaces_Inkop(sida);

                    grdResult_Inkop.HeaderRow.FindControl("chkInkval_ALL").Visible = false;

                    grdResult_Inkop.Visible = true;

                    DateTime Now = DateTime.Now;

                    string add1 = "<h1>Post har hämtats till databas för uppdatering</h1>";
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
