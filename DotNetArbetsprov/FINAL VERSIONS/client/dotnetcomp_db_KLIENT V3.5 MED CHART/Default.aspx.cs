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

using DB_proc;
using TF.Namespace.Controls;
using Common_Tasks;
using DB_Callcode.Skivor;

public partial class _Default : System.Web.UI.Page 
{
    
    
       //Instans för rensning av display och gridviews
        Clear clr = new Clear();
        
        protected void Page_Load(object sender, EventArgs e)
        {}
  
    
    
    
    
    
//Knappar Rad 1:
    
            //Hämtar hela databasen:
            public void button_visa_databas_Click(object sender, EventArgs e)
            {
                //Leta upp kontroller:
                UserControl gridArtister_Uctrl = (UserControl)Page.FindControl("gridArtister_Uctrl");
                
                GridView gridArtister = (GridView)gridArtister_Uctrl.FindControl("gridArtister");
                
                Visa_databas vdb = new Visa_databas();
                vdb.button_visa_databas(gridArtister, this.Page);
            }


            
    
            //Söker i databas:
            protected void button_sok_Click(object sender, EventArgs e)
            {
                //Leta upp kontroller:

                UserControl grdResult_UCtrl=(UserControl)Page.FindControl("grdResult_UCtrl");
                GridView grdResult =(GridView)grdResult_UCtrl.FindControl("grdResult");
                
                


                //Skapar instans av objekt för delayvärde och sök-anrop
                Sok sk = new Sok();

                //Anger antal sekunder som sökningen skall vara i cache-objektet:
                sk.Delay = 120;


                
                try
                {
                    
                    sk.button_sok(grdResult, this.Page, display, 
                    text3_Artist, text4_Album, text5_Format, text6_Press, text8_ar, 
                    text7_Kommentar);
                }
                catch (FormatException err)
                {
                    //Rensar display från text och gridviews 
                    clr.Clean_surfaces(this.Page);
                    
                    string mess = "<h2>[Page]Skivor.Sok:FormatException</h2>";
                    mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
                    display.InnerHtml = mess;
                }
                catch (MySqlException err)
                {
                    //Rensar display från text och gridviews 
                    clr.Clean_surfaces(this.Page);
                    
                    string mess = "<h2>[Page]Skivor.Sok:MySqlException</h2>";
                    mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
                    display.InnerHtml = mess;
                }
                catch (System.Exception err)
                {
                    //Rensar display från text och gridviews 
                    clr.Clean_surfaces(this.Page);
                    
                    string mess = "<h2>[Page]Skivor.Sok:System.Exception</h2>";
                    mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
                    display.InnerHtml = mess;
                }
            }

            
     
     
            
            
    
            //Ger information om aktuell data i databas:
            protected void button_info_Click(object sender, EventArgs e)
            {
                
                try
                {
                    Info info = new Info();
                    info.button_info(display, display2, ch3DPie, lbl3DPie, this.Page);  
                }
                catch (FormatException err)
                {
                    //Rensar display från text och gridviews 
                    clr.Clean_surfaces(this.Page);
                    
                    string mess = "<h2>[Page]Skivor.Info:FormatException</h2>";
                    mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
                    display.InnerHtml = mess;
                }
                catch (MySqlException err)
                {
                    //Rensar display från text och gridviews 
                    clr.Clean_surfaces(this.Page);
                    
                    string mess = "<h2>[Page]Skivor.Info:MySqlException</h2>";
                    mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
                    display.InnerHtml = mess;
                }
                catch (System.Exception err)
                {
                    //Rensar display från text och gridviews 
                    clr.Clean_surfaces(this.Page);
                    
                    string mess = "<h2>[Page]Skivor.Info:System.Exception</h2>";
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
                String retursida = "~/Default.aspx";

                try   
                {
                    Refresh_TB rtb = new Refresh_TB();
                    rtb.button_Refresh_TB(server, retursida);
                }
                catch (FormatException err)
                {
                    //Rensar display från text och gridviews 
                    clr.Clean_surfaces(this.Page);
                    
                    string mess = "<h2>[Page]Skivor.Refresh_TB:FormatException</h2>";
                    mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
                    display.InnerHtml = mess;
                }
                catch (MySqlException err)
                {
                    //Rensar display från text och gridviews 
                    clr.Clean_surfaces(this.Page);
                    
                    string mess = "<h2>[Page]Skivor.Refresh_TB:MySqlException</h2>";
                    mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
                    display.InnerHtml = mess;
                }
                catch (System.Exception err)
                {
                    //Rensar display från text och gridviews 
                    clr.Clean_surfaces(this.Page);
                    
                    string mess = "<h2>[Page]Skivor.Refresh_TB:System.Exception</h2>";
                    mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
                    display.InnerHtml = mess;
                }
            }






            
    

    
//Övriga funktioner:


            //Skapar en 3D-piechart: 
            protected void CreateChart(object sender, EventArgs e)
            {

                try
                {
                    InfoPie pie = new InfoPie();
                    pie.GetPie(ch3DPie, lbl3DPie, this.Page);
                }
                catch (FormatException err)
                {
                    //Rensar display från text och gridviews 
                    clr.Clean_surfaces(this.Page);

                    string mess = "<h2>[Page]Skivor.CreateChart:FormatException</h2>";
                    mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
                    display.InnerHtml = mess;
                }
                catch (MySqlException err)
                {
                    //Rensar display från text och gridviews 
                    clr.Clean_surfaces(this.Page);

                    string mess = "<h2>[Page]Skivor.CreateChart:MySqlException</h2>";
                    mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
                    display.InnerHtml = mess;
                }
                catch (System.Exception err)
                {
                    //Rensar display från text och gridviews 
                    clr.Clean_surfaces(this.Page);

                    string mess = "<h2>[Page]Skivor.CreateChart:System.Exception</h2>";
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

        






        
    






