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
using System.Collections.Specialized;
using System.Collections;

using DB_proc;
using TF.Namespace.Controls;
using Common_Tasks;

namespace DB_Callcode.Skivor
{
    public class Info
    {
        Clear clr = new Clear();
        Proc_act db = new Proc_act();
        

        
        //Ger information om aktuell data i databas:
        public void button_info(HtmlGenericControl display, HtmlGenericControl display2,
        Page sida)
        {
            OrderedDictionary dictRec = new OrderedDictionary();
            int rowcount = 0;

            try
            {
                dictRec = db.GetInfo();
                rowcount = dictRec.Count;
            }
            finally
            { }


            //Value- och key-kollektioner initieras mha Interface:
            ICollection keyKollektion = dictRec.Keys;
            ICollection valueKollektion = dictRec.Values;

            //Skapar arrays och kopierar kollektionerna till desamma:
            String[] keys = new String[rowcount];
            int[] values = new int[rowcount];
            keyKollektion.CopyTo(keys, 0);
            valueKollektion.CopyTo(values, 0);
            
            
            if (rowcount > 0)
            {
                //Rensar display från text och gridviews 
                clr.Clean_surfaces(sida);
                
                DateTime Now = DateTime.Now;
                
                //Skapar de olika tabellerna:
                Table tblCDDVD = new Table();
                Table tblVinyl = new Table();
                Table tblDataMeida = new Table();
                Table tblKluster = new Table();

                int sum_cddvd = 0;
                int sum_vinyl = 0;
                int sum_datamedia = 0;
               
                //Rubrik för infosidan:
                string add = "<h1>Följande info för tabeller finns: </h1>";
                display.InnerHtml = add; 

               
                //Skriver ut CD/DVD-info om skivtabell:
                //Rubrikrad:
                TableRow rubrikrad_cddvd = new TableRow();
                tblCDDVD.Controls.Add(rubrikrad_cddvd);

                TableHeaderCell hcell_cddvd = new TableHeaderCell();
                //hcell_cddvd.BorderWidth = 1;
                hcell_cddvd.HorizontalAlign = HorizontalAlign.Left;
                hcell_cddvd.Text = "CD/DVD:";
                rubrikrad_cddvd.Controls.Add(hcell_cddvd);

                 //Tabellinnehåll:
                for (int i = 0; i < 11; i++)
                {
                    TableRow rad = new TableRow();
                    tblCDDVD.Controls.Add(rad);

                    TableCell cell = new TableCell();
                    //cell.BorderWidth = 1;
                    cell.Text = "Antal " + keys[i] + ": " + "<b>" + values[i] + "</b>";
                    rad.Controls.Add(cell);
                    sum_cddvd+=values[i];
                }
                
                //Summeringsrad:
                TableRow sumrad_cddvd = new TableRow();

                TableHeaderCell hsumma_cddvd = new TableHeaderCell();
                hsumma_cddvd.HorizontalAlign = HorizontalAlign.Left;
                hsumma_cddvd.Text ="Summa: " + sum_cddvd.ToString() + " cd/dvd(s)";
                sumrad_cddvd.Controls.Add(hsumma_cddvd);
                tblCDDVD.Controls.Add(sumrad_cddvd);

                
                
                //Skriver ut vinyl-info om skivtabell:
                //Rubrikrad:
                TableRow rubrikrad_vinyl = new TableRow();
                tblVinyl.Controls.Add(rubrikrad_vinyl);

                TableHeaderCell hcell_vinyl = new TableHeaderCell();
                //hcell_vinyl.BorderWidth = 1;
                hcell_vinyl.HorizontalAlign = HorizontalAlign.Left;
                hcell_vinyl.Text = "Vinyl:";
                rubrikrad_vinyl.Controls.Add(hcell_vinyl);


                //Tabellinnehåll:
                for (int i = 11; i < 23; i++)
                {
                    TableRow rad = new TableRow();
                    tblVinyl.Controls.Add(rad);

                    TableCell cell = new TableCell();
                    //cell.BorderWidth = 1;
                    cell.Text = "Antal " + keys[i] + ": " + "<b>" + values[i] + "</b>";
                    rad.Controls.Add(cell);
                    sum_vinyl += values[i];
                    
                }

                //Summeringsrad:
                TableRow sumrad_vinyl = new TableRow();

                TableHeaderCell hsumma_vinyl = new TableHeaderCell();
                hsumma_vinyl.HorizontalAlign = HorizontalAlign.Left;
                hsumma_vinyl.Text = "Summa: " + sum_vinyl.ToString() + " vinyl(er)";
                sumrad_vinyl.Controls.Add(hsumma_vinyl);
                tblVinyl.Controls.Add(sumrad_vinyl);
               

                 
                
                //Skriver ut datamedia-info om skivtabell:
                //Rubrikrad:
                TableRow rubrikrad_datam = new TableRow();
                tblDataMeida.Controls.Add(rubrikrad_datam);

                TableHeaderCell hcell_datam = new TableHeaderCell();
                //hcell_datam.BorderWidth = 1;
                hcell_datam.HorizontalAlign = HorizontalAlign.Left;
                hcell_datam.Text = "Datamedia:";
                rubrikrad_datam.Controls.Add(hcell_datam);


                //Tabellinnehåll:
                //for (int i = 11; i < 23; i++)
                //{
                TableRow rad_datam = new TableRow();
                tblDataMeida.Controls.Add(rad_datam);

                    TableCell cell_datam = new TableCell();
                    //cell_datam.BorderWidth = 1;
                    cell_datam.Text = "Antal " + keys[23] + ": " + "<b>" + values[23] + "</b>";
                    rad_datam.Controls.Add(cell_datam);
                    sum_datamedia += values[23];
                //}

                //Summeringsrad:
                TableRow sumrad_datamedia = new TableRow();

                TableHeaderCell hsumma_datamedia = new TableHeaderCell();
                hsumma_datamedia.HorizontalAlign = HorizontalAlign.Left;
                hsumma_datamedia.Text = "Summa: " + sum_datamedia.ToString() + " mp3(s)";
                sumrad_datamedia.Controls.Add(hsumma_datamedia);
                tblDataMeida.Controls.Add(sumrad_datamedia);
                
                            
                  
                  
                //Sätter upp layouten för ovanstående tabeller:
                TableRow rad_Kluster = new TableRow();
                   
                TableCell cell1_Kluster = new TableCell();
                TableCell cell2_Kluster = new TableCell();
                TableCell cell3_Kluster = new TableCell();
                
                cell1_Kluster.Controls.Add(tblCDDVD);
                cell2_Kluster.Controls.Add(tblVinyl);
                cell3_Kluster.Controls.Add(tblDataMeida);
                
                cell1_Kluster.VerticalAlign = VerticalAlign.Top;
                cell2_Kluster.VerticalAlign = VerticalAlign.Top;
                cell3_Kluster.VerticalAlign = VerticalAlign.Top;
                
                rad_Kluster.Controls.Add(cell1_Kluster);
                rad_Kluster.Controls.Add(cell2_Kluster);
                rad_Kluster.Controls.Add(cell3_Kluster);
                
                
                tblKluster.Controls.Add(rad_Kluster);

                  
                   
               //Visar alla tabeller inkl. layout på displayen: 
               display.Controls.Add(tblKluster);
                    
              //Totalsumma för antal skivor i skivtabell:
              int totalsumma = sum_cddvd + sum_vinyl + sum_datamedia; 
               
              
              //Visar tid när sidan skapades och totalsumma för skivdatabas:
               string add2 = "<h3 id=nogreen> Totalsumma för skivdatabas: " + totalsumma + " enheter </h3>"; 
               add2 += "<h3>" + "Sidan skapades: " + Now + "</h3>";
               display2.InnerHtml = add2;

              //Visar 3D-piechart + dess label: 
               //ch3DPie.Visible = true;
               //lbl3DPie.Visible = true;
              
           }
           else
           {
                //Rensar display från text och gridviews 
               clr.Clean_surfaces(sida);
                
                display.InnerHtml = "<h2>Inga erhållna värden från databas.</h2>";
           }  

       }




  }
}
