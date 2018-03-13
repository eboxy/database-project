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

public partial class UserControls_Gridview_grdResult_Artist : System.Web.UI.UserControl
{

    //Instans för rensning av display och gridviews
    Clear_Artist clr = new Clear_Artist();

    protected void Page_Load(object sender, EventArgs e) { }

    //Artistknapp: 
    protected void gridResult_RowCommand_Artist(object sender, GridViewCommandEventArgs e)
    {
        //Leta upp kontroller:
        
        HtmlGenericControl display = (HtmlGenericControl)Page.FindControl("display");
        
        try
        {
            dbtn_Visa_Kortbio vkb = new dbtn_Visa_Kortbio();
            vkb.grd_Artistdata_Artist_RowCommand(display, e, this.Page);
        }
        catch (FormatException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Artist(this.Page);

            string mess = "<h2>[Uctrl]UserCgrdResult_Artist.dbtn_KomArt:FormatException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (MySqlException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Artist(this.Page);

            string mess = "<h2>[UCtrl]UserCgrdResult_Artist.dbtn_KomArt:MySqlException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (System.Exception err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Artist(this.Page);

            String mess = "<h2>[UCtrl]UserCgrdResult_Artist.dbtn_KomArt:System.Exception</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
    }


    
    
    //Kryssruta för gridview gridArtister_Artist och grdResult_Artist:
    protected void chkArtval_CheckedChanged(object sender, EventArgs e)
    {
        //Leta upp kontroller:
        
        UserControl gridArtister_Artist_UCtrl = (UserControl)Page.FindControl("gridArtister_Artist_UCtrl");
        UserControl pnlKortbio_UCtrl = (UserControl)Page.FindControl("pnlKortbio_UCtrl");

        GridView gridArtister_Artist = (GridView)gridArtister_Artist_UCtrl.FindControl("gridArtister_Artist");
        Panel pnlKortbio = (Panel)pnlKortbio_UCtrl.FindControl("pnlKortbio");
        
        HtmlGenericControl display = (HtmlGenericControl)Page.FindControl("display");
        

        try
        {
            chk_Gridviews cgrd = new chk_Gridviews();
            cgrd.chkArtval_CheckedChanged(gridArtister_Artist, grdResult_Artist);
        }
        catch (FormatException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Artist(this.Page);

            string mess = "<h2>[UCtrl]UserCgrdResult_Artist.chk_Gridviews:FormatException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (MySqlException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Artist(this.Page);

            string mess = "<h2>[UCtrl]UserCgrdResult_Artist.chk_Gridviews:MySqlException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (System.Exception err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Artist(this.Page);

            string mess = "<h2>[UCtrl]UserCgrdResult_Artist.chk_Gridviews:System.Exception</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
    }


    
    
    //Headerkryssruta för gridview grdResult_Artist:
    protected void chkArtvalALLGrdRes_CheckedChanged(object sender, EventArgs e)
    {
        //Leta upp kontroller:
        UserControl grdResult_Artist_UCtrl = (UserControl)Page.FindControl("grdResult_Artist_UCtrl");
        
        GridView grdResult_Artist = (GridView)grdResult_Artist_UCtrl.FindControl("grdResult_Artist");        
        
        HtmlGenericControl display = (HtmlGenericControl)Page.FindControl("display");
        
        try
        {
            hchk_grdResult hchk = new hchk_grdResult();
            hchk.chkArtvalALLGrdRes_CheckedChanged(grdResult_Artist, sender);
        }
        catch (FormatException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Artist(this.Page);

            string mess = "<h2>[UCtrl]UserCgrdResult_Artist.hchk_grdResult:FormatException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (MySqlException err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Artist(this.Page);

            string mess = "<h2>[UCtrl]UserCgrdResult_Artist.hchk_grdResult:MySqlException</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
        catch (System.Exception err)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Artist(this.Page);

            String mess = "<h2>[UCtrl]UserCgrdResult_Artist.hchk_grdResult:System.Exception</h2>";
            mess += "<h2>Felmeddelande: " + err.Message + "</h2>";
            display.InnerHtml = mess;
        }
    }





    //Sortering för gridview som är programatiskt ansluten till databas
    protected void SortArtist_Command(object sender, CommandEventArgs e)
    {
        //Leta upp kontroller:
        UserControl grdResult_Artist_UCtrl = (UserControl)Page.FindControl("grdResult_Artist_UCtrl");
        
        GridView grdResult_Artist = (GridView)grdResult_Artist_UCtrl.FindControl("grdResult_Artist");
        
        HtmlGenericControl display = (HtmlGenericControl)Page.FindControl("display");
        
        
        DataSet ds = new DataSet();
        DataView dv = new DataView();

        //Hämta värden så cachekeys kan bli likadana som de vid sökning, 
        //dvs individuella cachekeys
        TextBox artist = (TextBox)Page.FindControl("text3_Artist");
        DropDownList vpfr = (DropDownList)Page.FindControl("text9_VPfr");
        DropDownList vptill = (DropDownList)Page.FindControl("text10_VPtill");
        DropDownList ursland = (DropDownList)Page.FindControl("text11_Ursland");
        TextBox ursstad = (TextBox)Page.FindControl("text12_Ursstad");
        DropDownList musiktyp = (DropDownList)Page.FindControl("text13_Musiktyp");

        ds = (DataSet)HttpRuntime.Cache.Get("cache" + artist.Text + vpfr.Text + vptill.Text + ursland.Text
                         + ursstad.Text + musiktyp.Text);


        //Första tabellen i datasetet tilldelas till en dataview:
        if (this.Cache["cache" + artist.Text + vpfr.Text + vptill.Text + ursland.Text
                        + ursstad.Text + musiktyp.Text] == null)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Artist(this.Page);
            
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
                    clr.Clean_surfaces_Artist(this.Page);
                    
                    display.InnerHtml = errmess;
                }
                else
                    dv.Sort = this.ViewState["SortExp"].ToString()
                             + " " + this.ViewState["SortOrder"].ToString();
            }



            //Skapar nytt objekt och adderar sorterade dataview:n till det:
            GridView gr = new GridView();

            //CurrentPageIndex:

            grdResult_Artist.DataSource = dv;
            grdResult_Artist.DataBind();
            grdResult_Artist.Visible = true;



        }
    }







    //Paging för gridview som är programatiskt ansluten till databas
    protected void grdResultArtist_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //Leta upp kontroller:
        UserControl grdResult_Artist_UCtrl = (UserControl)Page.FindControl("grdResult_Artist_UCtrl");
        
        GridView grdResult_Artist = (GridView)grdResult_Artist_UCtrl.FindControl("grdResult_Artist");
        
        HtmlGenericControl display = (HtmlGenericControl)Page.FindControl("display");
        
      
        DataSet ds = new DataSet();
        DataView dv = new DataView();

        //Hämta värden så cachekeys kan bli likadana som de vid sökning, 
        //dvs individuella cachekeys
        TextBox artist = (TextBox)Page.FindControl("text3_Artist");
        DropDownList vpfr = (DropDownList)Page.FindControl("text9_VPfr");
        DropDownList vptill = (DropDownList)Page.FindControl("text10_VPtill");
        DropDownList ursland = (DropDownList)Page.FindControl("text11_Ursland");
        TextBox ursstad = (TextBox)Page.FindControl("text12_Ursstad");
        DropDownList musiktyp = (DropDownList)Page.FindControl("text13_Musiktyp");

        ds = (DataSet)HttpRuntime.Cache.Get("cache" + artist.Text + vpfr.Text + vptill.Text + ursland.Text
                         + ursstad.Text + musiktyp.Text);


        //Första tabellen i datasetet tilldelas till en dataview:
        if (this.Cache["cache" + artist.Text + vpfr.Text + vptill.Text + ursland.Text
                        + ursstad.Text + musiktyp.Text] == null)
        {
            //Rensar display från text och gridviews 
            clr.Clean_surfaces_Artist(this.Page);
            
            display.InnerHtml = "<h2>Cacheminnets delaytid har gått ut. Genomför en ny sökning</h2>";
        }
        else
            dv = ds.Tables[0].DefaultView;



        //Om 'SortExp' (aktuell kolumnrad) är tillgänglig så sorteras 
        //den mha dataview enligt värdena i viewstatevariablerna:
        if (this.ViewState["SortExp"] != null)
        {
            string errmess= "<h2>Ingen tabell i DataView pga cachminnets ";
            errmess +="delaytid har gått ut. Genomför en ny sökning</h2>";

            if (dv.Table == null)
            {
                //Rensar display från text och gridviews 
                clr.Clean_surfaces_Artist(this.Page);
                
                display.InnerHtml = errmess;
            }
            else
                dv.Sort = this.ViewState["SortExp"].ToString()
                         + " " + this.ViewState["SortOrder"].ToString();
        }


        //Skapar nytt objekt och ett nytt sidindex så man kan bläddra (paging)
        GridView gr = new GridView();

        gr = (GridView)sender;
        gr = grdResult_Artist;
        
        RememberOldValues();
        
        gr.PageIndex = e.NewPageIndex;

        //CurrentPageIndex
        grdResult_Artist.DataSource = dv;
        grdResult_Artist.DataBind();
        
         RePopulateValues();
        
        grdResult_Artist.Visible = true;

    }




  
    
    //Sparar kryssrutors state-värden mha bool och Session-objekt:
    protected void RememberOldValues()
    {
        //Lika många utrymmen för kryssrytevärden som antal rader/sid:
        bool[] values = new bool[grdResult_Artist.PageSize];
        DerivCheckBox chb;
        
        //Hittar kryssruta och sparar dess statevärde i array:
        for (int i = 0; i < grdResult_Artist.Rows.Count; i++)
        {
            chb = (DerivCheckBox)grdResult_Artist.Rows[i].FindControl("chkArtval");
            if (chb != null)
            {
                values[i] = chb.Checked;
            }
        }
        //Sparar bool-array i Session för senare access:
        Session["page" + grdResult_Artist.PageIndex] = values;
    }





    //Återskapar bool-array från Sessionobjekt och dess statevärden 
    //för kryssrutorna på aktuell sida:
    protected void RePopulateValues()
    {

        if (Session["page" + grdResult_Artist.PageIndex] != null)
        {
            DerivCheckBox chb;
            bool[] values = (bool[])Session["page" + grdResult_Artist.PageIndex];
            for (int i = 0; i < grdResult_Artist.Rows.Count; i++)
            {
                chb = (DerivCheckBox)grdResult_Artist.Rows[i].FindControl("chkArtval");
                chb.Checked = values[i];
                if (chb.Checked == true)
                {
                    grdResult_Artist.Rows[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#738A9C");
                    grdResult_Artist.Rows[i].ForeColor = System.Drawing.ColorTranslator.FromHtml("#F7F7F7");
                    grdResult_Artist.Rows[i].Font.Bold = true;
                }
            }
        }
    }








}
