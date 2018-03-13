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

using DB_Callcode_Artist.Artist;

public partial class UserControls_Gridview_gridArtister_Artist : System.Web.UI.UserControl
{
    
    //Instans för rensning av display och gridviews
    Clear_Artist clr = new Clear_Artist();
    
    protected void Page_Load(object sender, EventArgs e){}


    //Artistknapp: 
    protected void gridArtister_Artist_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Leta upp kontroller:
        UserControl grd_Artistdata_Artist_UCtrl = (UserControl)Page.FindControl("grd_Artistdata_Artist_UCtrl");
        
        GridView grd_Artistdata_Artist = (GridView)grd_Artistdata_Artist_UCtrl.FindControl("grd_Artistdata_Artist");
        
        HtmlGenericControl display = (HtmlGenericControl)Page.FindControl("display");
        HtmlGenericControl display2 = (HtmlGenericControl)Page.FindControl("display2");



        try
        {
            dbtn_KomArt kart = new dbtn_KomArt();
            kart.gridArtister_RowCommand(grd_Artistdata_Artist, display, display2, this.Page, e);
        }
        catch (FormatException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Artist(this.Page);

            string mess = "<h2>[UCtrl]UserCgridArtister_Artist.dbtn_KomArt:FormatException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (MySqlException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Artist(this.Page);

            string mess = "<h2>[UCtrl]UserCgridArtister_Artist.dbtn_KomArt:MySqlException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (System.Exception err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Artist(this.Page);

            String mess = "<h2>[UCtrl]UserCgridArtister_Artist.dbtn_KomArt:System.Exception</h2>";
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
            clr.Clean_surfaces_Artist(this.Page);

            gridArtister_Artist.Visible = true;

            string mess = "<h2>[UCtrl]UserCgridArtister_Artist.ObjektDataSource: Exception</h2>";
            mess += "<h2>Felmeddelande: <br />" + e.Exception.ToString() + "</h2>";
            display.InnerHtml = mess;
            
            e.ExceptionHandled = true;
        }
    }






}





