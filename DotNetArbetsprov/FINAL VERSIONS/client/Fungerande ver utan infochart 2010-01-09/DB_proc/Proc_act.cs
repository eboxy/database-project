using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Collections.Generic;
using System.Web.Caching;
using System.Collections;
using System.Collections.Specialized;

using MySql.Data.MySqlClient;

namespace DB_proc
{
    public class Proc_act
    {
//Anslutning mot DB:        
        
        
        
        //Anslutningssträng mot DB
        private string connectionString;
        
        //Anslutning mot DB inkl felhantering:
        public Proc_act()
        {
            if (WebConfigurationManager.ConnectionStrings["PaServer"] == null)
            {
                throw new ApplicationException("ConnectionString saknas i web.config.");
            }
            else
            {
                connectionString = WebConfigurationManager.ConnectionStrings["PaServer"].ConnectionString;
                
            }
      }


        

        

        
//Allmänna DB-funktioner för "knapptsatsen":  
       
        
        
        //Visa hela DB:
        public DataSet GetWholeDB()
        {
            string query = "select Val, Artist, Album, Format, Press, Ar, Kommentar, `#`, Artist_no from cd_net, artist_net where Artist_no=No order by Artist, Album asc";

           MySqlCommand cmd = new MySqlCommand(query);

           return FillDataSet(cmd, "whole");
        }


        
        //Söker i DB:
        public DataSet SearchRecords(string artist, string album, string format, string press,
                       string ar, string kommentar)
        {

            string query = "select Artist, Album, Format, Press, Ar, Kommentar, Val,`#`, Artist_no FROM cd_net, artist_net where Artist ";
            query += "in (select Artist from artist_net where Artist_no=No) and Artist like @Artist and Album ";
            query += "like @Album and Format like @Format and Press like @Press and Ar like @Ar ";
            query += "and Kommentar like @Kommentar order by album";

            MySqlCommand cmd = new MySqlCommand(query);

            cmd.Parameters.AddWithValue("@Artist", "%" + artist + "%");
            cmd.Parameters.AddWithValue("@Album", "%" + album + "%");
            cmd.Parameters.AddWithValue("@Format", "%" + format + "%");
            cmd.Parameters.AddWithValue("@Press", "%" + press + "%");
            cmd.Parameters.AddWithValue("@Ar", "%" + ar + "%");
            cmd.Parameters.AddWithValue("@Kommentar", "%" + kommentar + "%");

            return FillDataSet(cmd, "Search");
        }


        
        
        
        //Lämnar information om innehåll i skivtabell:
        public OrderedDictionary GetInfo()
        {
            MySqlConnection con = new MySqlConnection(connectionString);

            //Dictionary<string, int> dictRec = new Dictionary<string, int>();
            OrderedDictionary dictRec = new OrderedDictionary();


            //Ansamlar de aktuella formaten:
            string[] formatx ={"CD", "CDS", "CDM", "2CD", "LCDM", "XLCDM", "DVDS", 
            "CD+DVD", "DVD/SACD", "CDM/DVD", "dEP", "LP", "2LP", "BOX", "12", "L12", 
            "XL12", "L12num", "TwinSetL12", "TwinSetL12num", "Promo", "7", "aEP", 
            "mp3"};


            //Skapar Sql-satser:
            string[] sqlquery = new string[formatx.Length];

            for (int i = 0; i < formatx.Length; i++)
            {
                sqlquery[i] = "select count(Format) from cd_net where Format='" + formatx[i] + "'";
            }


            //Skapa MySql-kommandon:
            MySqlCommand[] mysqlcmd = new MySqlCommand[formatx.Length];

            for (int i = 0; i < formatx.Length; i++)
            {
                mysqlcmd[i] = new MySqlCommand(sqlquery[i], con);
            }


            try
            {
                con.Open();

                //Exekverar kommandon samt adderar till kollektion:
                for (int i = 0; i < formatx.Length; i++)
                {
                    dictRec.Add(formatx[i], Convert.ToInt32((mysqlcmd[i]).ExecuteScalar()));

                }
                return dictRec;

            }
            finally
            { con.Close(); }

        }





        //Data till PieChart(på info-sidan):
        public OrderedDictionary GetWholePie()
        {
            MySqlConnection con = new MySqlConnection(connectionString);

            //Dictionary<string, int> dictRec = new Dictionary<string, int>();
            OrderedDictionary dictPieSlizes = new OrderedDictionary();


            //Ansamlar de aktuella musikstilarna:
            string[] musiktypx ={"Cyberpunk", "EBM", "EuroDisco", "Gothrock", "HipHop",
            "Industri", "New Wave", "Pop", "Punk", "RnB", "Rock", "Synth", "Synthpop"};


            //Skapar Sql-satser:
            string[] sqlquery = new string[musiktypx.Length];

            for (int i = 0; i < musiktypx.Length; i++)
            {
                sqlquery[i] = "select count(Musiktyp) from artist_net where Musiktyp='" + musiktypx[i] + "'";
            }


            //Skapa MySql-kommandon:
            MySqlCommand[] mysqlcmd = new MySqlCommand[musiktypx.Length];

            for (int i = 0; i < musiktypx.Length; i++)
            {
                mysqlcmd[i] = new MySqlCommand(sqlquery[i], con);
            }


            try
            {
                con.Open();

                //Exekverar kommandon samt adderar till kollektion:
                for (int i = 0; i < musiktypx.Length; i++)
                {
                    dictPieSlizes.Add(musiktypx[i], Convert.ToInt32((mysqlcmd[i]).ExecuteScalar()));

                }
                return dictPieSlizes;

            }
            finally
            { con.Close(); }


        }



        
        
        



        
        
//Användarkontrolls-funktioner:


        
        
        //Visar en artist kort-biografi:
        public DataSet CD_VisaKortBio(string row)
        {
            string query = "select Artist, Kortbio from artist_net where Artist=@Row";

            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@Row", row);

            return FillDataSet(cmd, "cd_visakortbio");
        }


        
        
        
        //Visar kommentar om en enhet:
        public DataSet CD_Kommentarer(int row)
        {
            string query = "select `#`,Kommentar FROM cd_net WHERE `#`=@Row";

            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@Row", row);

            return FillDataSet(cmd, "cd_komtr");
        }



         
        
        //Visar fakta om en artist:
         public DataSet CD_VisaArtistData(int row)
         {
             string query = "select No, Artist, VPfr, Vptill, Ursland, Ursstad, Musiktyp from artist_net where No=@Row";

             MySqlCommand cmd = new MySqlCommand(query);
             cmd.Parameters.AddWithValue("@Row", row);

             return FillDataSet(cmd, "cd_visaartistdata");
         }





        
//Övriga  funktioner:
        
        
    
        
        
         //Exekverar alla funktioner (ovan) med en SELECT-sats:
         private DataSet FillDataSet(MySqlCommand cmd, string tableName)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            cmd.Connection = con;
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            
               try
               {
                 con.Open();
                 adapter.Fill(ds, tableName);
                 
                }
                finally
                {
                   con.Close();
                 }
                
                return ds;

          }

       
    
    
    
    
    
    
    }

}

    






