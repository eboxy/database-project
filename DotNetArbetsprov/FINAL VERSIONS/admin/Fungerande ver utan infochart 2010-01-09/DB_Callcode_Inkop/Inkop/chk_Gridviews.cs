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
    public class chk_Gridviews
    {

        SetChks_Inkop db = new SetChks_Inkop();

        //Kryssruta  för gridview gridArtister och grdResult:
        public void chkInkval_CheckedChanged(GridView gridArtister_Inkop,
        GridView grdResult_Inkop)
        {

            GridView crossgrid = new GridView();

            if (grdResult_Inkop.Visible == true)
            {
                crossgrid = grdResult_Inkop;
            }
            else if (gridArtister_Inkop.Visible == true)
            {
                crossgrid = gridArtister_Inkop;
            }


            foreach (GridViewRow gvRow in crossgrid.Rows)
            {

                DerivCheckBox chksel = (DerivCheckBox)gvRow.FindControl("chkInkval");

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
