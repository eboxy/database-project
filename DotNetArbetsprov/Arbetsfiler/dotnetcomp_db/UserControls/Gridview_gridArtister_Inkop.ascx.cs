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

using DB_Callcode_Inkop.Inkop;


public partial class UserControls_Gridview_gridArtister_Inkop : System.Web.UI.UserControl
{
    //Instans för rensning av display och gridviews
    Clear_Inkop clr = new Clear_Inkop(); 

    protected void Page_Load(object sender, EventArgs e) { }

    //Kommentarknapp och Artistknapp: 
    protected void gridArtister_Inkop_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Leta upp kontroller:
        UserControl grd_Artistdata_Inkop_UCtrl = (UserControl)Page.FindControl("grd_Artistdata_Inkop_UCtrl"); 
        
        GridView grd_Artistdata_Inkop = (GridView)grd_Artistdata_Inkop_UCtrl.FindControl("grd_Artistdata_Inkop");
        
        HtmlGenericControl display = (HtmlGenericControl)Page.FindControl("display");
        HtmlGenericControl display2 = (HtmlGenericControl)Page.FindControl("display2");


        try
        {
            dbtn_KomArt kart = new dbtn_KomArt();
            kart.gridArtister_Inkop_RowCommand(grd_Artistdata_Inkop, display, display2, this.Page, e);
        }
        catch (FormatException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[UCtrl]UserCgridArtister_Inkop.dbtn_KomArt:FormatException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (MySqlException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[UCtrl]UserCgridArtister_Inkop.dbtn_KomArt:MySqlException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (System.Exception err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            String mess = "<h2>[UCtrl]UserCgridArtister_Inkop.dbtn_KomArt:System.Exception</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
    }

    
    
    
    
    //Headerkryssruta för gridview gridArtister_Inkop:
    protected void chkInkvalALLMain_CheckedChanged(object sender, EventArgs e)
    {
        //Leta upp kontroller:
        HtmlGenericControl display = (HtmlGenericControl)Page.FindControl("display");
        
        try
        {
            hchk_gridArtister hchk = new hchk_gridArtister();
            hchk.chkInkvalALLMain_CheckedChanged(gridArtister_Inkop, sender);
        }
        catch (FormatException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[UCtrl]UserCgridArtister_Inkop.hchk_gridArtister:FormatException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (MySqlException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[UCtrl]UserCgridArtister_Inkop.hchk_gridArtister:MySqlException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (System.Exception err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            String mess = "<h2>[UCtrl]UserCgridArtister_Inkop.hchk_gridArtister:System.Exception</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
    }


    
    
    
    //Kryssruta  för gridview gridArtister_Inkop och grdResult_Inkop:
    protected void chkInkval_CheckedChanged(object sender, EventArgs e)
    {
        //Leta upp kontroller:
        UserControl grdResult_Inkop_UCtrl = (UserControl)Page.FindControl("grdResult_Inkop_UCtrl");
        
        GridView grdResult_Inkop = (GridView)grdResult_Inkop_UCtrl.FindControl("grdResult_Inkop");
        
        HtmlGenericControl display = (HtmlGenericControl)Page.FindControl("display");
        

        try
        {
            chk_Gridviews cgrd = new chk_Gridviews();
            cgrd.chkInkval_CheckedChanged(gridArtister_Inkop, grdResult_Inkop);
        }
        catch (FormatException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[UCtrl]UserCgridArtister_Inkop.chk_Gridviews:FormatException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (MySqlException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[UCtrl]UserCgridArtister_Inkop.chk_Gridviews:MySqlException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (System.Exception err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            String mess = "<h2>[UCtrl]UserCgridArtister_Inkop.chk_Gridviews:System.Exception</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
    }


    
    
    //Fångar exceptions från objectdatasourcs selectmetod i komponent:
    protected void ObjectDataSourceMain_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        //Leta upp kontroller:
        HtmlGenericControl display = (HtmlGenericControl)Page.FindControl("display");
        
        if (e.Exception != null)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            gridArtister_Inkop.Visible = true;

            string mess = "<h2>[UCtrl]UserCgridArtister_Inkop.ObjektDataSource: Exception</h2>";
            mess += "<h2>Felmeddelande: <br />" + e.Exception.ToString() + "</h2>";
            display.InnerHtml = mess;

            e.ExceptionHandled = true;
        }
    }





}
