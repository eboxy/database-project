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
using System.Collections;

using DB_proc_Artist;
using TF.Namespace.Controls;
using Common_Tasks_Artist;

using DB_Callcode_Artist.Artist;

public partial class Default2 : System.Web.UI.Page
{
    //Instans för rensning av display och gridviews
    Clear_Artist clr = new Clear_Artist();

    protected void Page_Load(object sender, EventArgs e)
    {}


    
    
    
    
    
//Knappar Rad 1:


    
    //Hämtar hela databasen:
    public void button_visa_databas_Click(object sender, EventArgs e)
    {                                       
        //Leta upp kontroller:
        UserControl gridArtister_Artist_UCtrl = (UserControl)Page.FindControl("gridArtister_Artist_UCtrl");
        
        GridView gridArtister_Artist = (GridView)gridArtister_Artist_UCtrl.FindControl("gridArtister_Artist");
        
       Visa_databas vdb = new Visa_databas();
        vdb.button_visa_databas(gridArtister_Artist, this.Page); 
    }




    //Söker i databas:
    protected void button_sok_Click(object sender, EventArgs e)
    {    
        //Leta upp kontroller:
        GridView grdResult_Artist = (GridView)grdResult_Artist_UCtrl.FindControl("grdResult_Artist");
        
        //Skapar instans av objekt för delayvärde och sök-anrop:
        Sok sk = new Sok();

        //Anger antal sekunder som sökningen skall vara i cache-objektet:
        sk.Delay = 120;

        try
        {   
            
            sk.button_sok(grdResult_Artist, this.Page, display, 
            text3_Artist, text9_VPfr, text10_VPtill, text11_Ursland, text12_Ursstad,
            text13_Musiktyp, vldArtistOnlyLetters);
        }
        catch (FormatException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Artist(this.Page);

            string mess = "<h2>[Page]Artist.Sok_Artist:FormatException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (MySqlException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Artist(this.Page);

            string mess = "<h2>[Page]Artist.Sok_Artist:MySqlException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (System.Exception err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Artist(this.Page);

            string mess = "<h2>[Page]Artist.Sok:System.Exception</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
    }




 
    //Raderar innehållet i alla textrutor och dropdownmenyer:
    protected void button_Borja_om_Click(object sender, EventArgs e)
    {
        Borja_om bro = new Borja_om();
        bro.button_Borja_om();
    }
    
    
    
    
    //Fungerar som en omstart och rensar alla inmatningsrutor odyl + display:
    protected void button_Refresh_TB_Click(object sender, EventArgs e)
    {
        HttpServerUtility server = this.Server;
        String retursida = "~/Default2.aspx";

        try
        {   
            Refresh_TB rtb = new Refresh_TB();
            rtb.button_Refresh_TB(server, retursida);
        }
        catch (FormatException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Artist(this.Page);

            string mess = "<h2>[Page]Artist.Refresh_TB:FormatException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (MySqlException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Artist(this.Page);

            string mess = "<h2>[Page]Artist.Refresh_TB:MySqlException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (System.Exception err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Artist(this.Page);

            string mess = "<h2>[Page]Artist.Refresh_TBSystem.Exception</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
    }


    
    



    
//Växla mellan tabeller:
    
    
    protected void Skivtabell_CheckedChanged(object sender, EventArgs e)
    {
        IDictionaryEnumerator CacheEnum = HttpRuntime.Cache.GetEnumerator();
        while (CacheEnum.MoveNext())
        {
            string key = CacheEnum.Key.ToString();
            HttpRuntime.Cache.Remove(key);
        }
        Server.Transfer("~/Default.aspx");
    }

    protected void Artisttabell_CheckedChanged(object sender, EventArgs e)
    {
        IDictionaryEnumerator CacheEnum = HttpRuntime.Cache.GetEnumerator();
        while (CacheEnum.MoveNext())
        {
            string key = CacheEnum.Key.ToString();
            HttpRuntime.Cache.Remove(key);
        }
        Server.Transfer("~/Default2.aspx");
    }

    
     

}
