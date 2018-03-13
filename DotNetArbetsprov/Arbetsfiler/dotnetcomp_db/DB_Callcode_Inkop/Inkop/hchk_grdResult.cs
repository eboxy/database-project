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
    public class hchk_grdResult
    {
        SetChks_Inkop db = new SetChks_Inkop();

        //Headerkryssruta för gridview grdResult:
        public void chkInkvalALLGrdRes_CheckedChanged(GridView grdResult_Inkop,
        object sender)
        {
            foreach (GridViewRow gvRow in grdResult_Inkop.Rows)
            {
                DerivCheckBox chksel = (DerivCheckBox)(gvRow.Cells[0].FindControl("chkInkval"));
                chksel.Checked = ((DerivCheckBox)sender).Checked;

                if (chksel.Checked == true)
                {

                    Int32 val = 1;
                    Int32 row = Int32.Parse(chksel.UnText);

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
