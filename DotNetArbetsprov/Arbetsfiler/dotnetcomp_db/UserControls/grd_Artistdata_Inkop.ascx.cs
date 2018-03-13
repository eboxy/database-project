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

public partial class UserControls_grd_Artistdata_Inkop : System.Web.UI.UserControl
{
    //Instans för rensning av display och gridviews
    Clear_Inkop clr = new Clear_Inkop(); 

    protected void Page_Load(object sender, EventArgs e) { }

    //Visar en artists kortbiografi:
    protected void grd_Artistdata_Inkop_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Leta upp kontroller:
        HtmlGenericControl display = (HtmlGenericControl)Page.FindControl("display");
            
        try
        {
            dbtn_Visa_Kortbio vkb = new dbtn_Visa_Kortbio();
            vkb.grd_Artistdata_Inkop_RowCommand(display, e, this.Page);
            
        }
        catch (FormatException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[Uctrl]UCtrlgrdArtistdata_Inkop.dbtn_Visa_Kortbio:FormatException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (MySqlException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[Uctrl]UCtrlgrdArtistdata_Inkop.dbtn_Visa_Kortbio:MySqlException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (System.Exception err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[Uctrl]UCtrlgrdArtistdata_Inkop.dbtn_Visa_Kortbio:System.Exception</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
    }








}
