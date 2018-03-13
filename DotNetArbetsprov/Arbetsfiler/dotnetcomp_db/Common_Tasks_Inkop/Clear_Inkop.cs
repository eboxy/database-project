using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI;


namespace Common_Tasks_Inkop
{
    public class Clear_Inkop
    {
        public void Clean_surfaces_Inkop(Page sida)
        {

            UserControl UGridArtister_Inkop_UCtrl = (UserControl)sida.FindControl("UGridArtister_Inkop_UCtrl");
            UserControl grdResult_Inkop_UCtrl = (UserControl)sida.FindControl("grdResult_Inkop_UCtrl");
            UserControl grd_Artistdata_Inkop_UCtrl = (UserControl)sida.FindControl("grd_Artistdata_Inkop_UCtrl");
            UserControl pnlKommentar_Inkop_UCtrl = (UserControl)sida.FindControl("pnlKommentar_Inkop_UCtrl");

            GridView gridArtister_Inkop = (GridView)UGridArtister_Inkop_UCtrl.FindControl("gridArtister_Inkop");
            GridView grdResult_Inkop = (GridView)grdResult_Inkop_UCtrl.FindControl("grdResult_Inkop");
            GridView grd_Artistdata_Inkop = (GridView)grd_Artistdata_Inkop_UCtrl.FindControl("grd_Artistdata_Inkop");
            Panel pnlKommentar_Inkop = (Panel)pnlKommentar_Inkop_UCtrl.FindControl("pnlKommentar_Inkop");

            HtmlGenericControl display = (HtmlGenericControl)sida.FindControl("display");
            HtmlGenericControl display2 = (HtmlGenericControl)sida.FindControl("display2"); 
             

            gridArtister_Inkop.Visible = false;
            grdResult_Inkop.Visible = false;
            grd_Artistdata_Inkop.Visible = false;
            pnlKommentar_Inkop.Visible = false;

            display.InnerHtml = "";
            display2.InnerHtml = "";
        }
    }

}
