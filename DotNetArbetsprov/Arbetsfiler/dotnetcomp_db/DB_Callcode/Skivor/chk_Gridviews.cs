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
using System.Drawing;


using DB_proc;
using TF.Namespace.Controls;
using Common_Tasks;

namespace DB_Callcode.Skivor
{
    public class chk_Gridviews
    {

        SetChks db = new SetChks();

        //Kryssruta  för gridview gridArtister och grdResult:
        public void chkCDval_CheckedChanged(GridView gridArtister, 
        GridView grdResult)
        {

            GridView crossgrid = new GridView();

            if (grdResult.Visible == true)
            {
                crossgrid = grdResult;
            }
            else if (gridArtister.Visible == true)
            {
                crossgrid = gridArtister;
            }


            foreach (GridViewRow gvRow in crossgrid.Rows)
            {

                DerivCheckBox chksel = (DerivCheckBox)gvRow.FindControl("chkCDval");

                if (chksel.Checked == true)
                {
                    
                    Int32 val = 1;
                    Int32 row = Int32.Parse(chksel.UnText);

                    //Sätter markeringsvärden för markerad rad:
                    gvRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#738A9C");
                    gvRow.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
                    gvRow.Font.Bold = true;
                    
                    try
                    {
                        db.UpdateRecord_ChkBox(row, val);
                    }
                    finally
                    { }

                }
                else if (chksel.Checked == false)
                {
                    
                    Int32 val = 0;
                    Int32 row = Int32.Parse(chksel.UnText);

                    //Sätter tillbaka markeringsvärden för avmarkerad rad:
                    gvRow.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
                    gvRow.ForeColor = System.Drawing.ColorTranslator.FromHtml("#4A3C8C");
                    gvRow.Font.Bold = false;
                    
                    try
                    {
                        db.UpdateRecord_ChkBox(row, val);
                    }
                    finally
                    { }
                }


            }
        }


     
    }
}
