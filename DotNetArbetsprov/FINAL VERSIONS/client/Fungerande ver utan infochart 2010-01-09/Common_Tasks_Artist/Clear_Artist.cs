﻿using System;
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

            UserControl grdResult_Artist_UCtrl = (UserControl)sida.FindControl("grdResult_Artist_UCtrl");
            UserControl gridArtister_Artist_UCtrl = (UserControl)sida.FindControl("gridArtister_Artist_UCtrl");

            GridView grdResult_Artist = (GridView)grdResult_Artist_UCtrl.FindControl("grdResult_Artist");
            GridView gridArtister_Artist = (GridView)gridArtister_Artist_UCtrl.FindControl("gridArtister_Artist");
            
            HtmlGenericControl display = (HtmlGenericControl)sida.FindControl("display");
            HtmlGenericControl display2 = (HtmlGenericControl)sida.FindControl("display2");
            

            gridArtister_Artist.Visible = false;
            grdResult_Artist.Visible = false;
            
            display.InnerHtml = "";
            display2.InnerHtml = "";
        }
    }



}
