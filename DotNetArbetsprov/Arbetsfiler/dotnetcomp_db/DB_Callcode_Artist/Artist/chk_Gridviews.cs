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
    public class chk_Gridviews
    {

        SetChks_Artist db = new SetChks_Artist();

        //Kryssruta  för gridview gridArtister och grdResult:
        public void chkArtval_CheckedChanged(GridView gridArtister_Artist,
        GridView grdResult_Artist)
        {

            GridView crossgrid = new GridView();

            if (grdResult_Artist.Visible == true)
            {
                crossgrid = grdResult_Artist;
            }
            else if (gridArtister_Artist.Visible == true)
            {
                crossgrid = gridArtister_Artist;
            }


            foreach (GridViewRow gvRow in crossgrid.Rows)
            {

                DerivCheckBox chksel = (DerivCheckBox)gvRow.FindControl("chkArtval");

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
                        db.UpdateRecord_Artist_ChkBox(row, val);
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
                        db.UpdateRecord_Artist_ChkBox(row, val);
                    }
                    finally
                    { }
                }


            }
        }



    }

}
