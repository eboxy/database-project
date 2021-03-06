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

using DB_proc_Inkop;
using TF.Namespace.Controls;
using Common_Tasks_Inkop;

namespace DB_Callcode_Inkop.Inkop
{
    public class Transfer
    {

        Clear_Inkop clr = new Clear_Inkop();


        //Flyttar post från Inkopstabell till Skivtabell:
        public void button_transfer(GridView gridArtister_Inkop, GridView grdResult_Inkop,
        HtmlGenericControl display, Page sida)
        
        {

            DB_proc_Inkop.Inkop db = new DB_proc_Inkop.Inkop();

            Int32 ValInk = 1;
            Int32 notransfrecs = 0;
            Int32 a = 0;


            GridView delgrid = new GridView();

            if (grdResult_Inkop.Visible == true)
            {
                delgrid = grdResult_Inkop;
            }
            else if (gridArtister_Inkop.Visible == true)
            {
                delgrid = gridArtister_Inkop;
            }



            foreach (GridViewRow gvRow in delgrid.Rows)
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

                string mess = "<h2>Ej kryssat för någon ruta. ";
                mess += "Inget kan därmed flyttas. Kryssa för en ruta</h2>";
                display.InnerHtml = mess;
            }
            else if (a > 1)
            {
                //Rensar display från text och gridviews 
                clr.Clean_surfaces_Inkop(sida);

                string mess = "<h2>Kryssat i mer än en ruta. ";
                mess += "Inget kan därmed flyttas. Kryssa för endast en ruta</h2>";
                display.InnerHtml = mess;

            }
            else if (a == 1)
            {

                try
                {
                    notransfrecs = db.TransferRecord(ValInk);
                }
                finally
                { }


                if (notransfrecs == 1)
                {
                    //Rensar display från text och gridviews 
                    clr.Clean_surfaces_Inkop(sida);

                    DateTime Now = DateTime.Now;


                    string add = "<h1>" + "Post har flyttats till Skivtabell</h1>";
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



        }


    }





}
