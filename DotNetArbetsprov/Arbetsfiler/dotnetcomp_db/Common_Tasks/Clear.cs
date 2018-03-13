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
            UserControl pnlKommentar_UCtrl = (UserControl)sida.FindControl("pnlKommentar_UCtrl");

            GridView grd_Artistdata = (GridView)grd_Artistdata_UCtrl.FindControl("grd_Artistdata");
            GridView grdResult = (GridView)grdResult_UCtrl.FindControl("grdResult");
            GridView gridArtister = (GridView)gridArtister_Uctrl.FindControl("gridArtister");
            Panel pnlKommentar = (Panel)pnlKommentar_UCtrl.FindControl("pnlKommentar");

            //Chart ch3DPie = (Chart)sida.FindControl("ch3DPie");
            //Label lbl3DPie = (Label)sida.FindControl("lbl3DPie");

            HtmlGenericControl display = (HtmlGenericControl)sida.FindControl("display");
            HtmlGenericControl display2 = (HtmlGenericControl)sida.FindControl("display2"); 
           

            gridArtister.Visible = false;
            grdResult.Visible = false;
            grd_Artistdata.Visible = false;
            pnlKommentar.Visible = false;
            //ch3DPie.Visible = false;
            //lbl3DPie.Visible = false;

            display.InnerHtml = "";
            display2.InnerHtml = "";
        }
    }
}
