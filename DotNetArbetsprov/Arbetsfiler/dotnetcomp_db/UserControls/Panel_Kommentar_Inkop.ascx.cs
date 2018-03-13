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

public partial class UserControls_Panel_Kommentar_Inkop : System.Web.UI.UserControl
{
    //Instans för rensning av display och gridviews
    Clear_Inkop clr = new Clear_Inkop();

    protected void Page_Load(object sender, EventArgs e) { }

    //Matar in längre kommentarer till Inkoptabell:
    protected void dynbtnKommentar_OnClick(object sender, EventArgs e)
    {
        //Leta upp kontroller:
        HtmlGenericControl display = (HtmlGenericControl)Page.FindControl("display");
        
        try
        {
            dbtn_Kommentar_Input kin = new dbtn_Kommentar_Input();
            kin.dynbtnKommentar(display, txtKommentar, txtKommentarNo, this.Page);

        }
        catch (FormatException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[UCtrl]UserCpnlKommentar_Inkop.dbtn_Kommentar_Input:FormatException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (MySqlException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[UCtrl]UserCpnlKommentar_Inkop.dbtn_Kommentar_Input:MySqlException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (System.Exception err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            String mess = "<h2>[UCtrl]UserCpnlKommentar_Inkop.dbtn_Kommentar_Input:System.Exception</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
    }


    
    
    
    //Hämtar längre kommentarer från Inkoptabell (via kommentarpanel):
    protected void dynbtnFetchKommentar_OnClick(object sender, EventArgs e)
    {
        //Leta upp kontroller:
        HtmlGenericControl display = (HtmlGenericControl)Page.FindControl("display");
        
        try
        {
            dbtn_Kommentar_Output kout = new dbtn_Kommentar_Output();
            kout.dynbtnKommentarFetch( display, pnlKommentar_Inkop, txtKommentar, 
            txtKommentarNo, this.Page);

        }
        catch (FormatException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[UCtrl]UserCpnlKommentar_Inkop.dbtn_Kommentar_Output:FormatException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;

        }
        catch (MySqlException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[UCtrl]UserCpnlKommentar_Inkop.dbtn_Kommentar_Output:MySqlException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;

        }
        catch (System.Exception err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            String mess = "<h2>[UCtrl]UserCpnlKommentar_Inkop.dbtn_Kommentar_Output:System.Exception</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;

        }
    }

    
    
    
    //Rensar textytan och kommentarnummerrutan från text hos kommentarpanelen:
    protected void dynbtnRensaSkarm_Kom_OnClick(object sender, EventArgs e)
    {
        txtKommentar.Text = "";
        txtKommentarNo.Text = "";
    }






}
