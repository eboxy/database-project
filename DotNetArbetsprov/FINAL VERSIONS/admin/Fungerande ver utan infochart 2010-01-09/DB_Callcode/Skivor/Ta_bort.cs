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
    public class Ta_bort
    {

        Clear clr = new Clear();
        

        //Tar bort data från databas
        public void button_ta_bort(GridView gridArtister, GridView grdResult, 
        HtmlGenericControl display, Page sida)
        
        {
            Proc_act db = new Proc_act();


            Int32 val = 1;
            Int32 nodelrecs = 0;
            Int32 a = 0;


            GridView delgrid = new GridView();

            if (grdResult.Visible == true)
            {
                delgrid = grdResult;
            }
            else if (gridArtister.Visible == true)
            {
                delgrid = gridArtister;
            }



            foreach (GridViewRow gvRow in delgrid.Rows)
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
                
                string mess="<h2>Ej kryssat för någon ruta. ";
                mess +="Inget kan därmed tas bort. Kryssa för minst en ruta</h2>";
                display.InnerHtml = mess;
            }
            else if (a >= 1)
            {

                try
                {
                    nodelrecs = db.DelRecord(val);
                }
                finally
                { }

               
                if (nodelrecs > 0)
                {
                    //Rensar display från text och gridviews 
                    clr.Clean_surfaces(sida);

                    DateTime Now = DateTime.Now;
                    
                    
                    string add = "<h1>" + nodelrecs + " Post(er) har tagits bort från databasen</h1>";
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
}
