﻿using System;
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
    public class dbtn_Visa_Kortbio
    {

        Clear_Artist clr = new Clear_Artist();
        DB_proc_Artist.Artist db = new DB_proc_Artist.Artist();



        //Visar en artists kortbiografi:
        public void grd_Artistdata_Artist_RowCommand(HtmlGenericControl display, 
        GridViewCommandEventArgs e, Page sida)
        {

            if (e.CommandName == "Artist_kortbio")
            {


                string row = (string)e.CommandArgument;
                string kortbio = "";
                string artist = "";
                int rowcount = 0;

                try
                {
                    DataSet ds = new DataSet();
                    ds = db.CD_VisaKortBio(row);

                    kortbio = ds.Tables[0].Rows[0]["Kortbio"].ToString();
                    artist = ds.Tables[0].Rows[0]["Artist"].ToString();

                    rowcount = int.Parse(ds.Tables[0].Rows.Count.ToString());

                }
                finally
                { }

                if (rowcount > 0)
                {
                    //Rensar display från text och gridviews 
                    clr.Clean_surfaces_Artist(sida);

                    DateTime Now = DateTime.Now;

                    string add = "<h1>Kort biografi om " + artist + ":</h1>";
                    add += "<div id=visakortbiodata>" + kortbio + "</div>";

                    display.InnerHtml = add;

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
