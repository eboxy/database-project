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
    public class hchk_grdResult
    {
        SetChks db = new SetChks();

        //Headerkryssruta för gridview grdResult:
        public void chkCDvalALLGrdRes_CheckedChanged(GridView grdResult, 
        object sender)
        {
        
            foreach (GridViewRow gvRow in grdResult.Rows)
            {
                DerivCheckBox chksel = (DerivCheckBox)(gvRow.Cells[0].FindControl("chkCDval"));
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
