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
    public class hchk_gridArtister
    {

        SetChks_Artist db = new SetChks_Artist();

        //Headerkryssruta för gridview gridArtister:
        public void chkArtvalALLMain_CheckedChanged(GridView
        gridArtister_Artist, object sender)
        {

            foreach (GridViewRow gvRow in gridArtister_Artist.Rows)
            {
                DerivCheckBox chksel = (DerivCheckBox)(gvRow.Cells[0].FindControl("chkArtval"));
                chksel.Checked = ((DerivCheckBox)sender).Checked;

                if (chksel.Checked == true)
                {

                    Int32 val = 1;

                    try
                    {
                        db.UpdateRecord_Artist_ChkBox(val);
                    }
                    finally
                    { }

                }
                else if (chksel.Checked == false)
                {

                    Int32 val = 0;

                    try
                    {
                        db.UpdateRecord_Artist_ChkBox(val);
                    }
                    finally
                    { }
                }
            }
        }
    }

}
