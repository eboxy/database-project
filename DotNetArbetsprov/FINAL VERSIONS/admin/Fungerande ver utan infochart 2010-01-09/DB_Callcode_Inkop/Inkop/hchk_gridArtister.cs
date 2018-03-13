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
    public class hchk_gridArtister
    {
        SetChks_Inkop db = new SetChks_Inkop();

        //Headerkryssruta för gridview gridArtister:
        public void chkInkvalALLMain_CheckedChanged(GridView
        gridArtister_Inkop, object sender)
        {

            foreach (GridViewRow gvRow in gridArtister_Inkop.Rows)
            {
                DerivCheckBox chksel = (DerivCheckBox)(gvRow.Cells[0].FindControl("chkInkval"));
                chksel.Checked = ((DerivCheckBox)sender).Checked;

                if (chksel.Checked == true)
                {

                    Int32 val = 1;

                    try
                    {
                        db.UpdateRecord_ChkBox(val);
                    }
                    finally
                    { }

                }
                else if (chksel.Checked == false)
                {

                    Int32 val = 0;

                    try
                    {
                        db.UpdateRecord_ChkBox(val);
                    }
                    finally
                    { }
                }
            }
        }
    }







}
