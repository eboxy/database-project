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
using DB_Callcode.Skivor;

public partial class UserControls_Gridview_gridArtister : System.Web.UI.UserControl
{
    //Instans för rensning av display och gridviews
    Clear clr = new Clear();
    
    protected void Page_Load(object sender, EventArgs e){}

    //Kommentarknapp och Artistknapp: 
    protected void gridArtister_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Leta upp kontroller:
        UserControl grd_Artistdata_UCtrl=(UserControl)Page.FindControl("grd_Artistdata_UCtrl");
        
        GridView grd_Artistdata = (GridView)grd_Artistdata_UCtrl.FindControl("grd_Artistdata");
        
        HtmlGenericControl display = (HtmlGenericControl)Page.FindControl("display");
        HtmlGenericControl display2 = (HtmlGenericControl)Page.FindControl("display2");


        
        try
        {
            dbtn_KomArt kart = new dbtn_KomArt();
            kart.gridArtister_RowCommand(grd_Artistdata, display, display2, this.Page, e);
        }
        catch (FormatException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces(this.Page);
            
            string mess = "<h2>[UCtrl]UserCgridArtister.dbtn_KomArt:FormatException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (MySqlException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces(this.Page);
            
            string mess = "<h2>[UCtrl]UserCgridArtister.dbtn_KomArt:MySqlException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (System.Exception err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces(this.Page);
            
            String mess = "<h2>[UCtrl]UserCgridArtister.dbtn_KomArt:System.Exception</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
    }

    


    

    //Fångar exceptions från objectdatasourcs selectmetod i komponent:
    protected void ObjectDataSourceMain_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        HtmlGenericControl display = (HtmlGenericControl)Page.FindControl("display");
        
        if (e.Exception != null)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces(this.Page);

            gridArtister.Visible = true;

            string mess = "<h2>[UCtrl]UserCgridArtister.ObjektDataSource: Exception</h2>";
            mess += "<h2>Felmeddelande: <br />" + e.Exception.ToString() + "</h2>";
            display.InnerHtml = mess;
            
            e.ExceptionHandled = true;
        }
    }



}
