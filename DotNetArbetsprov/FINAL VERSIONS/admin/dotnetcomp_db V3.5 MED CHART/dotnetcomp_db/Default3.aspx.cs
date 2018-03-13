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

using DB_proc_Inkop;
using TF.Namespace.Controls;
using Common_Tasks_Inkop;
using DB_Callcode_Inkop.Inkop;

public partial class Default3 : System.Web.UI.Page
{
    //Instans för rensning av display och gridviews
    Clear_Inkop clr = new Clear_Inkop(); 

    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            
            //Initisiering av range-värden för validering av artistnummer 
            //vid tilläggg av enhet(Lagg_till funktionen):
            Inkop aggz = new Inkop();
            int[] aggvalues = new int[2];
            aggvalues = aggz.GetAggCDNet();

            int minvalue = aggvalues[0];
            int maxvalue = aggvalues[1];

            vldArtistValidRange.MinimumValue = minvalue.ToString();

            if (maxvalue <= int.MaxValue)
            {
                vldArtistValidRange.MaximumValue = maxvalue.ToString();
            }

        }
         
    }

//Knappar Rad 1:

    //Hämtar hela databasen:
    public void button_visa_databas_Click(object sender, EventArgs e)
    {
        //Leta upp kontroller:
        UserControl UGridArtister_Inkop_UCtrl = (UserControl)Page.FindControl("UGridArtister_Inkop_UCtrl");
        
        GridView gridArtister_Inkop = (GridView)UGridArtister_Inkop_UCtrl.FindControl("gridArtister_Inkop");
        
        Visa_databas vdb = new Visa_databas();

        vdb.button_visa_databas(gridArtister_Inkop, this.Page);
    }




    //Lägger till data i databas:
    protected void button_lagg_till_Click(object sender, EventArgs e)
    {
        try
        {
            Lagg_till lt = new Lagg_till();
            lt.button_lagg_till(display, text3_Artist, text4_Album, text5_Format,
             text6_Press, text8_ar, text7_Kommentar, text15_Inm_dat, text16_Kop_grad,
             text17_Kop_kat, text18_Ca_pris, vldDatum, vldCaPris, vldArtistOnlyNum,
             vldArtistNotEmpty, vldArtistValidRange, this.Page);
        }
        catch (FormatException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[Page]Inkop.Lagg_till: FormatException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;

        }

        catch (MySqlException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[Page]Inkop.Lagg_till:MySqlException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }

        catch (System.Exception err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[Page]Inkop.Lagg_till:System.Exception</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
    }




    
    //Tar bort data från databas:
    protected void button_ta_bort_Click(object sender, EventArgs e)
    {
        //Leta upp kontroller:
        GridView gridArtister_Inkop = (GridView)UGridArtister_Inkop_UCtrl.FindControl("gridArtister_Inkop");
        GridView grdResult_Inkop = (GridView)grdResult_Inkop_UCtrl.FindControl("grdResult_Inkop");
        

        try
        {
           Ta_bort tb = new Ta_bort();
            tb.button_ta_bort(gridArtister_Inkop, grdResult_Inkop, 
            display, this.Page);
        }
        catch (FormatException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[Page]Inkop.Ta_bort:FormatException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (MySqlException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[Page]Inkop.Ta_bort:MySqlException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (System.Exception err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[Page]Inkop.Ta_bort:System.Exception</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
    }



    
    
    //Uppdaterar databas: 
    protected void button_uppdatera_Click(object sender, EventArgs e)
    {
        //Leta upp kontroller:
        GridView gridArtister_Inkop = (GridView)UGridArtister_Inkop_UCtrl.FindControl("gridArtister_Inkop");
        GridView grdResult_Inkop = (GridView)grdResult_Inkop_UCtrl.FindControl("grdResult_Inkop");
        
        try
        {
            Uppdatera upd = new Uppdatera();
            upd.button_uppdatera(gridArtister_Inkop, grdResult_Inkop, 
            display, this.Page, text3_Artist, text4_Album, text5_Format,
            text6_Press, text8_ar, text7_Kommentar, text15_Inm_dat, 
            text16_Kop_grad, text17_Kop_kat, text18_Ca_pris);
        }
        catch (FormatException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[Page]Inkop.Uppdatera:FormatException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (MySqlException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[Page]Inkop.Uppdatera:MySqlException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (System.Exception err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[Page]Inkop.Uppdatera:System.Exception</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
    }





    //Söker i databas:
    protected void button_sok_Click(object sender, EventArgs e)
    {
        //Leta upp kontroller:
        GridView grdResult_Inkop = (GridView)grdResult_Inkop_UCtrl.FindControl("grdResult_Inkop");
        
        //Skapar instans av objekt för delayvärde och sök-anrop:
        Sok sk = new Sok();
        
        //Anger antal sekunder som sökningen skall vara i cache-objektet:
        sk.Delay = 20;
        
        try
        {
            
            sk.button_sok(grdResult_Inkop, this.Page,
            display, text3_Artist, text4_Album, text5_Format, 
            text6_Press, text8_ar, text7_Kommentar, text15_Inm_dat, 
            text16_Kop_grad, text17_Kop_kat, text18_Ca_pris);
        }
        catch (FormatException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[Page]Inkop.Sok:FormatException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (MySqlException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[Page]Inkop.Sok:MySqlException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (System.Exception err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[Page]Inkop.Sok:System.Exception</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
    }




   



    
//Knappar Rad 2:



    //Hämtar en rad från aktuell tabell som skall uppdateras:
    protected void button_fetch_Click(object sender, EventArgs e)
    {
        //Leta upp kontroller:
        GridView gridArtister_Inkop = (GridView)UGridArtister_Inkop_UCtrl.FindControl("gridArtister_Inkop");
        GridView grdResult_Inkop = (GridView)grdResult_Inkop_UCtrl.FindControl("grdResult_Inkop");


        try
        {
            Fetch fch = new Fetch();
            fch.button_fetch(gridArtister_Inkop, grdResult_Inkop, 
            display, display2, this.Page, text3_Artist, text4_Album, text5_Format,
            text6_Press, text8_ar, text7_Kommentar, text15_Inm_dat, text16_Kop_grad,
            text17_Kop_kat, text18_Ca_pris);
        }
        catch (FormatException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[Page]Inkop.Fetch:FormatException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (MySqlException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[Page]Inkop.Fetch:MySqlException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (System.Exception err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[Page]Inkop.Fetch:System.Exception</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
    }



    
    
    
    //Visar panel för inmatning av längre kommmentarer till Inkopstabell:
    protected void button_Kommentar_Click(object sender, EventArgs e)
    {
        //Leta upp kontroller:
        Panel pnlKommentar_Inkop = (Panel)pnlKommentar_Inkop_UCtrl.FindControl("pnlKommentar_Inkop");

        try
        {
            Visa_KommentarPanel kpnl = new Visa_KommentarPanel();
            kpnl.button_kommentarpanel(pnlKommentar_Inkop, this.Page);
            
        }
        catch (FormatException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[Page]Inkop.Kommentar:FormatException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (MySqlException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[Page]Inkop.Kommentar:MySqlException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (System.Exception err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[Page]Inkop.Kommentar:System.Exception</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }



    }




    
    
    
    //Överför vald post från Inkopstabell till skivtabell:
    protected void button_transfer_Click(object sender, EventArgs e)
    {
        //Leta upp kontroller:
        GridView gridArtister_Inkop = (GridView)UGridArtister_Inkop_UCtrl.FindControl("gridArtister_Inkop");
        GridView grdResult_Inkop = (GridView)grdResult_Inkop_UCtrl.FindControl("grdResult_Inkop");

        try
        {
            Transfer trf = new Transfer();    
            trf.button_transfer(gridArtister_Inkop, grdResult_Inkop,
            display, this.Page);
        }
        catch (FormatException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[Page]Inkop.Transfer:FormatException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (MySqlException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[Page]Inkop.Transfer:MySqlException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (System.Exception err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[Page]Inkop.Transfer:System.Exception</h2>";
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
        String retursida = "~/Default3.aspx";

        try
        {
            Refresh_TB rtb = new Refresh_TB();
            rtb.button_Refresh_TB(server, retursida);
        }
        catch (FormatException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[Page]Inkop.Refresh_TB:FormatException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (MySqlException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[Page]Inkop.Refresh_TB:MySqlException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (System.Exception err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[Page]Inkop.Refresh_TB:System.Exception</h2>";
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

    protected void Inkoptabell_CheckedChanged(object sender, EventArgs e)
    {
        IDictionaryEnumerator CacheEnum = HttpRuntime.Cache.GetEnumerator();
        while (CacheEnum.MoveNext())
        {
            string key = CacheEnum.Key.ToString();
            HttpRuntime.Cache.Remove(key);
        }
        Server.Transfer("~/Default3.aspx");
    }







}
