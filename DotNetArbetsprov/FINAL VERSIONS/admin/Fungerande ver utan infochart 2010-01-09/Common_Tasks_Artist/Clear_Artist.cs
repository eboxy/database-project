using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Common_Tasks_Artist
{
    public class Clear_Artist
    {
        public void Clean_surfaces_Artist(Page sida)
        {

            UserControl gridArtister_Artist_UCtrl = (UserControl)sida.FindControl("gridArtister_Artist_UCtrl");
            UserControl grdResult_Artist_UCtrl = (UserControl)sida.FindControl("grdResult_Artist_UCtrl");
            UserControl pnlKortbio_UCtrl = (UserControl)sida.FindControl("pnlKortbio_UCtrl");

            GridView gridArtister_Artist = (GridView)gridArtister_Artist_UCtrl.FindControl("gridArtister_Artist");
            GridView grdResult_Artist = (GridView)grdResult_Artist_UCtrl.FindControl("grdResult_Artist");
            Panel pnlKortbio = (Panel)pnlKortbio_UCtrl.FindControl("pnlKortbio");

            HtmlGenericControl display = (HtmlGenericControl)sida.FindControl("display");
            HtmlGenericControl display2 = (HtmlGenericControl)sida.FindControl("display2"); 
            

            gridArtister_Artist.Visible = false;
            grdResult_Artist.Visible = false;
            pnlKortbio.Visible = false;

            display.InnerHtml = "";
            display2.InnerHtml = "";
        }
    }



}
