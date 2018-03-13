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
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;

using DB_proc;
using TF.Namespace.Controls;
using Common_Tasks;

namespace DB_Callcode.Skivor
{
    public class InfoPie
    {

        Clear clr = new Clear();
        Proc_act db = new Proc_act();


        public void GetPie(Chart ch3DPie, Label lbl3DPie, Page sida)
        {
            

            OrderedDictionary dictPieSlizes = new OrderedDictionary();
            int rowcount = 0;

            try
            {
                dictPieSlizes = db.GetWholePie();
                rowcount = dictPieSlizes.Count;
            }
            finally
            { }


            //Value- och key-kollektioner initieras mha Interface:
            ICollection keyKollektion = dictPieSlizes.Keys;
            ICollection valueKollektion = dictPieSlizes.Values;

            //Skapar arrays och kopierar kollektionerna till desamma:
            String[] keys = new String[rowcount];
            int[] values = new int[rowcount];
            keyKollektion.CopyTo(keys, 0);
            valueKollektion.CopyTo(values, 0);


            if (rowcount > 0)
            {
                
                //Fyller pajen:
                for (int i = 0; i < rowcount; i++)
                {
                    ch3DPie.Series["Series1"].Points.AddXY(keys[i], values[i]);
                }

                
                //Div inställningar för pajen:
                ch3DPie.Series["Series1"].ChartType = SeriesChartType.Pie;// Set the Pie width

                ch3DPie.Series["Series1"]["PointWidth"] = "0.5";//Ange punktbredd

                ch3DPie.Series["Series1"].IsValueShownAsLabel = true;//Visa datapunkter som labels

                ch3DPie.Series["Series1"]["BarLabelStyle"] = "Center";//Sätt datapunkter label style

                ch3DPie.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;//Visa paj som 3D

                ch3DPie.Series["Series1"]["DrawingStyle"] = "Cylinder";//Rita ut paj som 3D 

                ch3DPie.Series["Series1"].Font = new Font("Times New Roman", 8, FontStyle.Bold);

                ch3DPie.Series["Series1"].Label = "#VALY"; //Värden som anges på paj:
                
                ch3DPie.Series["Series1"].LabelForeColor = ColorTranslator.FromHtml("#F7F7F7");//Sätta label-färg


                //Addera kolumn med färgsymboler:     
                LegendCellColumn firstColumn = new LegendCellColumn();
                firstColumn.ColumnType = LegendCellColumnType.SeriesSymbol;
                firstColumn.HeaderText = "Färg";
                firstColumn.HeaderBackColor = ColorTranslator.FromHtml("#D8D8D8");
                firstColumn.HeaderFont = new Font("Times New Roman", 8, FontStyle.Bold);
                ch3DPie.Legends["Musiktyp"].CellColumns.Add(firstColumn);

                // Addera textkolumn med musiktyper som ingår i piechart:   
                LegendCellColumn secondColumn = new LegendCellColumn();
                secondColumn.ColumnType = LegendCellColumnType.Text;
                secondColumn.Font = new Font("Times New Roman", 8, FontStyle.Regular);
                secondColumn.HeaderText = "Musiktyp";
                secondColumn.Alignment = ContentAlignment.BottomLeft;
                secondColumn.HeaderFont = new Font("Times New Roman", 8, FontStyle.Bold);
                secondColumn.Text = "#VALX";
                secondColumn.HeaderBackColor = ColorTranslator.FromHtml("#D8D8D8");
                ch3DPie.Legends["Musiktyp"].CellColumns.Add(secondColumn);

            }

          }

    
    
    
    
    }
}
