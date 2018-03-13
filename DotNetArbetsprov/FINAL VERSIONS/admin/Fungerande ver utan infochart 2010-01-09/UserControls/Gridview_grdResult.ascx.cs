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

public partial class UserControls_Gridview_grdResult : System.Web.UI.UserControl
{
    //Instans för rensning av display och gridviews
    Clear clr = new Clear();
    
    protected void Page_Load(object sender, EventArgs e){}

    //Kommentarknapp och Artistknapp: 
    protected void gridResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Leta upp kontroller:
         UserControl grd_Artistdata_UCtrl = (UserControl)Page.FindControl("grd_Artistdata_UCtrl");
         
         GridView grd_Artistdata = (GridView)grd_Artistdata_UCtrl.FindControl("grd_Artistdata");
        
        HtmlGenericControl display = (HtmlGenericControl)Page.FindControl("display");
        HtmlGenericControl display2 = (HtmlGenericControl)Page.FindControl("display2");

        
        
        try
        {
            dbtn_KomArt kart = new dbtn_KomArt();
            kart.gridArtister_RowCommand(grd_Artistdata, display, display2, this.Page ,e);
        }
        catch (FormatException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces(this.Page);
            
            string mess = "<h2>[Uctrl]UserCgrdResult.dbtn_KomArt:FormatException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (MySqlException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces(this.Page);
            
            string mess = "<h2>[UCtrl]UserCgrdResult.dbtn_KomArt:MySqlException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (System.Exception err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces(this.Page);
            
            String mess = "<h2>[UCtrl]UserCgrdResult.dbtn_KomArt:System.Exception</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
    }  

    
    //Kryssruta för gridview gridArtister och grdResult:
    protected void chkCDval_CheckedChanged(object sender, EventArgs e)
    {
        //Leta upp kontroller:
        
        UserControl gridArtister_Uctrl = (UserControl)Page.FindControl("gridArtister_Uctrl");
        
        GridView gridArtister = (GridView)gridArtister_Uctrl.FindControl("gridArtister");
        
        HtmlGenericControl display = (HtmlGenericControl)Page.FindControl("display");
        
        
        try
        {
            chk_Gridviews cgrd = new chk_Gridviews();
            cgrd.chkCDval_CheckedChanged(gridArtister, grdResult);
        }
        catch (FormatException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces(this.Page);
            
            string mess = "<h2>[UCtrl]UserCgrdResult.chk_Gridviews:FormatException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (MySqlException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces(this.Page);
            
            string mess = "<h2>[UCtrl]UserCgrdResult.chk_Gridviews:MySqlException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (System.Exception err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces(this.Page);
            
            string mess = "<h2>[UCtrl]UserCgrdResult.chk_Gridviews:System.Exception</h2>";
            mess +="<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
    }


    
    
    //Headerkryssruta för gridview grdResult:
    public void chkCDvalALLGrdRes_CheckedChanged(object sender, EventArgs e)
    {
        //Leta upp kontroller:
        HtmlGenericControl display = (HtmlGenericControl)Page.FindControl("display");

        try
        {
            hchk_grdResult hchk = new hchk_grdResult();
            hchk.chkCDvalALLGrdRes_CheckedChanged(grdResult, sender);
        }
        catch (FormatException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces(this.Page);
            
            string mess = "<h2>[UCtrl]UserCgrdResult.hchk_grdResult:FormatException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (MySqlException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces(this.Page);
            
            string mess = "<h2>[UCtrl]UserCgrdResult.hchk_grdResult:MySqlException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (System.Exception err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces(this.Page);
            
            String mess = "<h2>[UCtrl]UserCgrdResult.hchk_grdResult:System.Exception</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }

       
    
    }




    



    
    
    //Sortering för gridview som är programatiskt ansluten till databas
    protected void SortSkivor_Command(object sender, CommandEventArgs e)
    {
        //Leta upp kontroller:
        HtmlGenericControl display = (HtmlGenericControl)Page.FindControl("display");
        
        DataSet ds = new DataSet();
        DataView dv = new DataView();

        //Hämta värden så cachekeys kan bli likadana som de vid sökning, 
        //dvs individuella cachekeys
        TextBox artist = (TextBox)Page.FindControl("text3_Artist");
        TextBox album = (TextBox)Page.FindControl("text4_Album");
        DropDownList format = (DropDownList)Page.FindControl("text5_Format");
        DropDownList press = (DropDownList)Page.FindControl("text6_Press");
        DropDownList ar = (DropDownList)Page.FindControl("text8_ar");
        TextBox kommentar = (TextBox)Page.FindControl("text7_Kommentar");

        ds = (DataSet)HttpRuntime.Cache.Get("cache" + artist.Text + album.Text
                       + format.Text + press.Text + ar.Text + kommentar.Text);


        //Första tabellen i datasetet tilldelas till en dataview:
        if (this.Cache["cache" + artist.Text + album.Text
                         + format.Text + press.Text + ar.Text + kommentar.Text] == null)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces(this.Page);
            
            display.InnerHtml = "<h2>Cacheminnets delaytid har gått ut. Genomför en ny sökning</h2>";
        }
        else
            dv = ds.Tables[0].DefaultView;



        //Kollar om rad är sorterbar, vilken rad som i så fall är sorterbar, och om 
        //den skall sorteras mha stigande eller fallande sorteringsordning:
        if (e.CommandName.Equals("Sort"))
        {
            if (this.ViewState["SortExp"] == null)
            {
                this.ViewState["SortExp"] = e.CommandArgument.ToString();
                this.ViewState["SortOrder"] = "ASC";
            }
            else
            {
                if (this.ViewState["SortExp"].ToString() == e.CommandArgument.ToString())
                {
                    if (this.ViewState["SortOrder"].ToString() == "ASC")
                        this.ViewState["SortOrder"] = "DESC";
                    else
                        this.ViewState["SortOrder"] = "ASC";
                }
                else
                {
                    this.ViewState["SortOrder"] = "ASC";
                    this.ViewState["SortExp"] = e.CommandArgument.ToString();
                }
            }


            //Om 'SortExp' (aktuell kolumnrad) är tillgänglig så sorteras 
            //den mha dataview enligt inställningarna ovan:
            if (this.ViewState["SortExp"] != null)
            {
                string errmess = "<h2>Ingen tabell i DataView pga cachminnets ";
                errmess += "delaytid har gått ut. Genomför en ny sökning</h2>";

                if (dv.Table == null)
                {
                    //Rensar display från text och gridviews 
                    clr.Clean_surfaces(this.Page);
                    
                    display.InnerHtml = errmess;
                }
                else
                    dv.Sort = this.ViewState["SortExp"].ToString()
                             + " " + this.ViewState["SortOrder"].ToString();
            }


            //Skapar nytt objekt och adderar sorterade dataview:n till det:
            GridView gr = new GridView();

            //CurrentPageIndex:
            grdResult.DataSource = dv;
            grdResult.DataBind();
            grdResult.Visible = true;



        }
    }







    
    
    //Paging för gridview som är programatiskt ansluten till databas
    protected void grdResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //Leta upp kontroller:
        HtmlGenericControl display = (HtmlGenericControl)Page.FindControl("display");
        
        DataSet ds = new DataSet();
        DataView dv = new DataView();

        //Hämta värden så cachekeys kan bli likadana som de vid sökning, 
        //dvs individuella cachekeys
        TextBox artist = (TextBox)Page.FindControl("text3_Artist");
        TextBox album = (TextBox)Page.FindControl("text4_Album");
        DropDownList format = (DropDownList)Page.FindControl("text5_Format");
        DropDownList press = (DropDownList)Page.FindControl("text6_Press");
        DropDownList ar = (DropDownList)Page.FindControl("text8_ar");
        TextBox kommentar = (TextBox)Page.FindControl("text7_Kommentar");

        ds = (DataSet)HttpRuntime.Cache.Get("cache" + artist.Text + album.Text
                       + format.Text + press.Text + ar.Text + kommentar.Text);

        //Första tabellen i datasetet tilldelas till en dataview:
        if (this.Cache["cache" + artist.Text + album.Text
                       + format.Text + press.Text + ar.Text + kommentar.Text] == null)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces(this.Page);
            
            display.InnerHtml = "<h2>Cacheminnets delaytid har gått ut. Genomför en ny sökning</h2>";
        }
        else
            dv = ds.Tables[0].DefaultView;



        //Om 'SortExp' (aktuell kolumnrad) är tillgänglig så sorteras 
        //den mha dataview enligt värdena i viewstatevariablerna:
        if (this.ViewState["SortExp"] != null)
        {
            string errmess = "<h2>Ingen tabell i DataView pga cachminnets ";
            errmess += "delaytid har gått ut. Genomför en ny sökning</h2>";

            if (dv.Table == null)
            {
                //Rensar display från text och gridviews 
                clr.Clean_surfaces(this.Page);
                
                display.InnerHtml = errmess;
            }
            else
                dv.Sort = this.ViewState["SortExp"].ToString()
                         + " " + this.ViewState["SortOrder"].ToString();
        }


        //Skapar nytt objekt och ett nytt sidindex så man kan bläddra (paging)
        GridView gr = new GridView();
        
        gr = (GridView)sender;
        gr = grdResult;
        
        RememberOldValues();
        
        gr.PageIndex = e.NewPageIndex;

        
        //CurrentPageIndex
        grdResult.DataSource = dv;
        grdResult.DataBind();

        RePopulateValues();

        grdResult.Visible = true;
        
     }



   

  
    //Sparar kryssrutors state-värden mha bool och Session-objekt:
    protected void RememberOldValues()
    {
        //Lika många utrymmen för kryssrytevärden som antal rader/sid:
        bool[] values = new bool[grdResult.PageSize];
        DerivCheckBox chb;
        
        //Hittar kryssruta och sparar dess statevärde i array:
        for (int i = 0; i < grdResult.Rows.Count; i++)
        {
            chb = (DerivCheckBox)grdResult.Rows[i].FindControl("chkCDval");
            if (chb != null)
            {
                
                values[i] = chb.Checked;
                
            }   

        }
        //Sparar bool-array i Session för senare access:
        Session["page" + grdResult.PageIndex] = values;
    }





    //Återskapar bool-array från Sessionobjekt och dess statevärden 
    //för kryssrutorna på aktuell sida:
    protected void RePopulateValues()
    {

        if (Session["page" + grdResult.PageIndex] != null)
        {
            DerivCheckBox chb;
            bool[] values = (bool[])Session["page" + grdResult.PageIndex];
            for (int i = 0; i < grdResult.Rows.Count; i++)
            {
                chb = (DerivCheckBox)grdResult.Rows[i].FindControl("chkCDval");
                chb.Checked = values[i];
                if (chb.Checked == true)
                {
                    grdResult.Rows[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#738A9C");
                    grdResult.Rows[i].ForeColor = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
                    grdResult.Rows[i].Font.Bold = true;
                }
            }
        }
    }



    
    

}
        