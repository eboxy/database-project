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

public partial class UserControls_Gridview_grdResult_Inkop : System.Web.UI.UserControl
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

            string mess = "<h2>[Uctrl]UserCgrdResult_Inkop.dbtn_KomArt:FormatException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (MySqlException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[UCtrl]UserCgrdResult_Inkop.dbtn_KomArt:MySqlException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (System.Exception err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            String mess = "<h2>[UCtrl]UserCgrdResult_Inkop.dbtn_KomArt:System.Exception</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
    }


    
    
   //Kryssruta för gridview gridArtister_Inkop och grdResult_Inkop:
    protected void chkInkval_CheckedChanged(object sender, EventArgs e)
    {
        //Leta upp kontroller:
        UserControl UGridArtister_Inkop_UCtrl = (UserControl)Page.FindControl("UGridArtister_Inkop_UCtrl");
   
        GridView gridArtister_Inkop = (GridView)UGridArtister_Inkop_UCtrl.FindControl("gridArtister_Inkop");
        
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

            string mess = "<h2>[UCtrl]UserCgrdResult_Inkop.chk_Gridviews:FormatException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (MySqlException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[UCtrl]UserCgrdResult_Inkop.chk_Gridviews:MySqlException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (System.Exception err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[UCtrl]UserCgrdResult_Inkop.chk_Gridviews:System.Exception</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
    }


    
    
    //Headerkryssruta för gridview grdResult_Inkop:
    protected void chkInkvalALLGrdRes_CheckedChanged(object sender, EventArgs e)
    {
        //Leta upp kontroller:
        HtmlGenericControl display = (HtmlGenericControl)Page.FindControl("display");
        
        try
        {
            hchk_grdResult hchk = new hchk_grdResult();
            hchk.chkInkvalALLGrdRes_CheckedChanged(grdResult_Inkop, sender);
        }
        catch (FormatException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[UCtrl]UserCgrdResult_Inkop.hchk_grdResult:FormatException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (MySqlException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            string mess = "<h2>[UCtrl]UserCgrdResult_Inkop.hchk_grdResult:MySqlException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (System.Exception err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);

            String mess = "<h2>[UCtrl]UserCgrdResult_Inkop.hchk_grdResult:System.Exception</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
    }





    
    
    //Sortering för gridview som är programatiskt ansluten till databas
    protected void SortInkop_Command(object sender, CommandEventArgs e)
    {
        //Leta upp kontroller:
        HtmlGenericControl display = (HtmlGenericControl)Page.FindControl("display");
        
        DataSet ds = new DataSet();
        DataView dv = new DataView();

        //Hämta värden så cachekeys kan bli likadana som de vid sökning, 
        //dvs individuella cachekeys
        TextBox art_no = (TextBox)Page.FindControl("text3_Artist");
        TextBox album = (TextBox)Page.FindControl("text4_Album");
        DropDownList format = (DropDownList)Page.FindControl("text5_Format");
        DropDownList press = (DropDownList)Page.FindControl("text6_Press");
        DropDownList ar = (DropDownList)Page.FindControl("text8_ar");
        TextBox kommentar = (TextBox)Page.FindControl("text7_Kommentar");
        TextBox inm_dat = (TextBox)Page.FindControl("text15_Inm_dat");
        DropDownList kop_grad = (DropDownList)Page.FindControl("text16_Kop_grad");
        DropDownList kop_kat = (DropDownList)Page.FindControl("text17_Kop_kat");
        TextBox ca_pris = (TextBox)Page.FindControl("text18_Ca_pris");
        
        ds = (DataSet)HttpRuntime.Cache.Get("cache" + art_no.Text + album.Text + format.Text + press.Text 
                + ar.Text + kommentar.Text + inm_dat.Text + kop_grad.Text + kop_kat.Text + ca_pris.Text);


        //Första tabellen i datasetet tilldelas till en dataview:
        if (this.Cache["cache" + art_no.Text + album.Text + format.Text + press.Text
                + ar.Text + kommentar.Text + inm_dat.Text + kop_grad.Text + kop_kat.Text + ca_pris.Text] == null)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);
            
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
                    clr.Clean_surfaces_Inkop(this.Page);
                    
                    display.InnerHtml = errmess;
                }
                else
                    dv.Sort = this.ViewState["SortExp"].ToString()
                             + " " + this.ViewState["SortOrder"].ToString();
            }
            

            //Skapar nytt objekt och adderar sorterade dataview:n till det:
            GridView gr = new GridView();

            //CurrentPageIndex:
            grdResult_Inkop.DataSource = dv;
            grdResult_Inkop.DataBind();
            grdResult_Inkop.Visible = true;



        }
    }







    //Paging för gridview som är programatiskt ansluten till databas
    protected void grdResult_Inkop_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //Leta upp kontroller:
        HtmlGenericControl display = (HtmlGenericControl)Page.FindControl("display");
       
        DataSet ds = new DataSet();
        DataView dv = new DataView();
        
        //Hämta värden så cachekeys kan bli likadana som de vid sökning, 
        //dvs individuella cachekeys
        TextBox art_no = (TextBox)Page.FindControl("text3_Artist");
        TextBox album = (TextBox)Page.FindControl("text4_Album");
        DropDownList format = (DropDownList)Page.FindControl("text5_Format");
        DropDownList press = (DropDownList)Page.FindControl("text6_Press");
        DropDownList ar = (DropDownList)Page.FindControl("text8_ar");
        TextBox kommentar = (TextBox)Page.FindControl("text7_Kommentar");
        TextBox inm_dat = (TextBox)Page.FindControl("text15_Inm_dat");
        DropDownList kop_grad = (DropDownList)Page.FindControl("text16_Kop_grad");
        DropDownList kop_kat = (DropDownList)Page.FindControl("text17_Kop_kat");
        TextBox ca_pris = (TextBox)Page.FindControl("text18_Ca_pris");

        ds = (DataSet)HttpRuntime.Cache.Get("cache" + art_no.Text + album.Text + format.Text + press.Text
                + ar.Text + kommentar.Text + inm_dat.Text + kop_grad.Text + kop_kat.Text + ca_pris.Text);

        //Första tabellen i datasetet tilldelas till en dataview:
        if (this.Cache["cache" + art_no.Text + album.Text + format.Text + press.Text
                + ar.Text + kommentar.Text + inm_dat.Text + kop_grad.Text + kop_kat.Text + ca_pris.Text] == null)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Inkop(this.Page);
            
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
                clr.Clean_surfaces_Inkop(this.Page);
                
                display.InnerHtml = errmess;
            }
            else
                dv.Sort = this.ViewState["SortExp"].ToString()
                         + " " + this.ViewState["SortOrder"].ToString();
        }


        //Skapar nytt objekt och ett nytt sidindex så man kan bläddra (paging)
        //inklusive state-värden för kryssrutor (RememberOldValues och RePopulateValues);
        GridView gr = new GridView();

        gr = (GridView)sender;
        gr = grdResult_Inkop;

        RememberOldValues();
        
        gr.PageIndex = e.NewPageIndex;
        
        //CurrentPageIndex
        grdResult_Inkop.DataSource = dv;
        grdResult_Inkop.DataBind();
        
        RePopulateValues();

        grdResult_Inkop.Visible = true; 
        
       

    }  






    //Sparar kryssrutors state-värden mha bool och Session-objekt:
    protected void RememberOldValues()
    {
        //Lika många utrymmen för kryssrytevärden som antal rader/sid:
        bool[] values = new bool[grdResult_Inkop.PageSize];
        DerivCheckBox chb;
        
        //Hittar kryssruta och sparar dess statevärde i array:
        for (int i = 0; i < grdResult_Inkop.Rows.Count; i++)
        {
            chb = (DerivCheckBox)grdResult_Inkop.Rows[i].FindControl("chkInkval");
            if (chb != null)
            {
                values[i] = chb.Checked;
            }
        } 
        //Sparar bool-array i Session för senare access:
        Session["page" + grdResult_Inkop.PageIndex] = values;
    }





    //Återskapar bool-array från Sessionobjekt och dess statevärden 
    //för kryssrutorna på aktuell sida:
    protected void RePopulateValues()
    {
        
        if (Session["page" + grdResult_Inkop.PageIndex] != null)
        {
            DerivCheckBox chb;
            bool[] values = (bool[])Session["page" + grdResult_Inkop.PageIndex];
            for (int i = 0; i < grdResult_Inkop.Rows.Count; i++)
            {
                chb = (DerivCheckBox)grdResult_Inkop.Rows[i].FindControl("chkInkval");
                chb.Checked = values[i];
                if (chb.Checked == true)
                {
                    grdResult_Inkop.Rows[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#738A9C");
                    grdResult_Inkop.Rows[i].ForeColor = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
                    grdResult_Inkop.Rows[i].Font.Bold = true;
                }
            }
        }
    }













}
