using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI;




namespace Common_Tasks
{
    public class Clear
    {
          public void Clean_surfaces(Page sida)
          {
             
            UserControl grd_Artistdata_UCtrl = (UserControl)sida.FindControl("grd_Artistdata_UCtrl");
            UserControl grdResult_UCtrl = (UserControl)sida.FindControl("grdResult_UCtrl");
            UserControl gridArtister_Uctrl = (UserControl)sida.FindControl("gridArtister_Uctrl");
            
            GridView grd_Artistdata = (GridView)grd_Artistdata_UCtrl.FindControl("grd_Artistdata");
            GridView grdResult = (GridView)grdResult_UCtrl.FindControl("grdResult");
            GridView gridArtister = (GridView)gridArtister_Uctrl.FindControl("gridArtister");
      
            HtmlGenericControl display = (HtmlGenericControl)sida.FindControl("display");
            HtmlGenericControl display2 = (HtmlGenericControl)sida.FindControl("display2"); 
            

            gridArtister.Visible = false;
            grdResult.Visible = false;
            grd_Artistdata.Visible = false;
            
            display.InnerHtml = "";
            display2.InnerHtml = "";
        }
    }
}
