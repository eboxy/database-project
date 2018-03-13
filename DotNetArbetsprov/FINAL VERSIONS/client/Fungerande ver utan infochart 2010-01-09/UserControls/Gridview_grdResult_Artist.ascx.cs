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






    
    
    
    //Sortering för gridview som är programatiskt ansluten till databas
    protected void SortArtist_Command(object sender, CommandEventArgs e)
    {
        //Leta upp kontroller:
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


        //Skapar nytt objekt och ett nytt sidindex så man kan bläddra (paging)
        GridView gr = new GridView();

        gr = (GridView)sender;
        gr = grdResult_Artist;
        gr.PageIndex = e.NewPageIndex;

        //CurrentPageIndex
        grdResult_Artist.DataSource = dv;
        grdResult_Artist.DataBind();
        grdResult_Artist.Visible = true;

    }





}
