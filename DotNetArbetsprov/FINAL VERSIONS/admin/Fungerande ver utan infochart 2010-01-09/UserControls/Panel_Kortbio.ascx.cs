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

public partial class UserControls_Panel_Kortbio : System.Web.UI.UserControl
{
    //Instans för rensning av display och gridviews
    Clear_Artist clr = new Clear_Artist();
    
    protected void Page_Load(object sender, EventArgs e){}

    
    
    //Matar in data till kortibo (via kortbiopanel) i artist-tabell:
    protected void dynbtnKortbio_OnClick(object sender, EventArgs e)
    {
        //Leta upp kontroller:
        HtmlGenericControl display = (HtmlGenericControl)Page.FindControl("display");
        
        try
        {
            dbtn_Kortbio_Input kbin = new dbtn_Kortbio_Input();
            kbin.dynbtnKortbio(display, txtKortbio, txtArtistNo, this.Page);
        }
        catch (FormatException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Artist(this.Page);

            string mess = "<h2>[UCtrl]UserCpnlKortbio_Artist.dbtn_Kortbio_Input:FormatException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (MySqlException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Artist(this.Page);

            string mess = "<h2>[UCtrl]UserCpnlKortbio_Artist.dbtn_Kortbio_Input:MySqlException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (System.Exception err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Artist(this.Page);

            String mess = "<h2>[UCtrl]UserCpnlKortbio_Artist.dbtn_Kortbio_Input:System.Exception</h2>";
            mess+= "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
    }


    
    
    
    //Hämtar kortio från artist-tabell (via kortbiopanel) i artist-tabell::
    protected void dynbtnKortbioFetch_OnClick(object sender, EventArgs e)
    {
        //Leta upp kontroller:
        HtmlGenericControl display = (HtmlGenericControl)Page.FindControl("display");
        
        try
        {
            dbtn_Kortbio_Output kbout = new dbtn_Kortbio_Output();
            kbout.dynbtnKortbioFetch(display, pnlKortbio, txtKortbio, 
            txtArtistNo, this.Page);
        }
        catch (FormatException err)
        {
              //Rensar display från text och gridviews 
              clr.Clean_surfaces_Artist(this.Page);

              string mess = "<h2>[UCtrl]UserCpnlKortbio_Artist.dbtn_Kortbio_Output:FormatException</h2>";
              mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
              display.InnerHtml = mess;
            
        }
        catch (MySqlException err)
        {
              //Rensar display från text och gridviews 
              clr.Clean_surfaces_Artist(this.Page);

              string mess = "<h2>[UCtrl]UserCpnlKortbio_Artist.dbtn_Kortbio_Output:MySqlException</h2>";
              mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
              display.InnerHtml = mess;
            
        }
        catch (System.Exception err)
        {
              //Rensar display från text och gridviews 
              clr.Clean_surfaces_Artist(this.Page);

              String mess = "<h2>[UCtrl]UserCpnlKortbio_Artist.dbtn_Kortbio_Output:System.Exception</h2>";
              mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
              display.InnerHtml = mess;
            
        }
    }

    
    
    //Rensar textytan och artistnummerrutan från text hos kortbiopanelen:
    protected void dynbtnRensaSkarmArtist_OnClick(object sender, EventArgs e)
    {
        txtKortbio.Text = "";
        txtArtistNo.Text = "";
    }


}
