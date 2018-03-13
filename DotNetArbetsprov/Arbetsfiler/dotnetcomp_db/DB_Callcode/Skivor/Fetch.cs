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
    public class Fetch
    {
        Clear clr = new Clear();
        Proc_act db = new Proc_act();
        

        //Hämtar en rad från aktuell tabell som skall uppdateras:
        public void button_fetch(GridView gridArtister, GridView grdResult, 
        HtmlGenericControl display, HtmlGenericControl display2, Page sida,
        TextBox text3_Artist, TextBox text4_Album, DropDownList text5_Format, 
        DropDownList text6_Press, DropDownList text8_ar, 
        TextBox text7_Kommentar)
        {
            Proc_act db = new Proc_act();

            GridView fetchgrid = new GridView();

            
            int a = 0;
            int rowcount = 0;
            

            if (grdResult.Visible == true)
            {
                fetchgrid = grdResult;
            }
            else if (gridArtister.Visible == true)
            {
                fetchgrid = gridArtister;
            }



            foreach (GridViewRow gvRow in fetchgrid.Rows)
            {

                DerivCheckBox chksel = (DerivCheckBox)gvRow.FindControl("chkCDval");
               
                if (chksel.Checked == true)
                {
                   a++; 
                }
            }

            if (a == 0)
            {
                //Rensar display från text och gridviews 
                clr.Clean_surfaces(sida);
                
                display.InnerHtml = "<h2>Ingen kryssruta ifylld.</h2>";
            }
            else if (a > 1)
            {
                //Rensar display från text och gridviews 
                clr.Clean_surfaces(sida);
                
                display.InnerHtml = "<h2>Endast EN kryssruta får vara ifylld.</h2>";
            }
            else
            {
                try
                {
                    DataSet ds = new DataSet();
                    ds = db.FetchRecord();
                    
                    grdResult.DataSource = ds;
                    grdResult.DataBind();

                    text3_Artist.Text = ds.Tables[0].Rows[0]["Artist_no"].ToString();
                    text4_Album.Text = ds.Tables[0].Rows[0]["Album"].ToString();
                    text5_Format.Text = ds.Tables[0].Rows[0]["Format"].ToString();
                    text6_Press.Text = ds.Tables[0].Rows[0]["Press"].ToString();
                    text8_ar.Text = ds.Tables[0].Rows[0]["Ar"].ToString();
                    text7_Kommentar.Text = ds.Tables[0].Rows[0]["Kommentar"].ToString();

                    rowcount = int.Parse(ds.Tables[0].Rows.Count.ToString());
                }
                finally
                { }


                if (rowcount == 1)
                {
                    //Rensar display från text och gridviews 
                    clr.Clean_surfaces(sida);


                    grdResult.HeaderRow.FindControl("chkCDval_ALL").Visible = false;
                    
                    
                    grdResult.Visible = true;
                    
                    DateTime Now = DateTime.Now;
                    
                    string add1 = "<h1>Post har hämtats till databas för uppdatering</h1>";
                    string add2 = "<h3>" + "Sidan skapades: " + Now + "</h3>";
                    display.InnerHtml = add1;
                    display2.InnerHtml = add2;
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
}
