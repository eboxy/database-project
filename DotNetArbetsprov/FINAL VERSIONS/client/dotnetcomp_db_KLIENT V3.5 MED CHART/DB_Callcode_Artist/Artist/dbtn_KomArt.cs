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
    public class dbtn_KomArt
    {


        Clear_Artist clr = new Clear_Artist();
        DB_proc_Artist.Artist db = new DB_proc_Artist.Artist();
        
        
        //Kommentarknapp och Artistknapp: 
        public void gridArtister_RowCommand(GridView grd_Artistdata_Artist, 
        HtmlGenericControl display, HtmlGenericControl display2, Page sida,
        GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Artist")
            {

                int row = Convert.ToInt32(e.CommandArgument);
                int rowcount = 0;

                try
                {
                    DataSet ds = new DataSet();
                    ds = db.CD_VisaArtistData(row);

                    grd_Artistdata_Artist.DataSource = ds;
                    grd_Artistdata_Artist.DataBind();

                    rowcount = int.Parse(ds.Tables[0].Rows.Count.ToString());

                }
                finally
                { }

                if (rowcount > 0)
                {
                    //Rensar display från text och gridviews 
                    clr.Clean_surfaces_Artist(sida);


                    grd_Artistdata_Artist.Visible = true;


                    DateTime Now = DateTime.Now;

                    string add1 = "<h1>Artistdata No: " + row + "</h1>";
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
