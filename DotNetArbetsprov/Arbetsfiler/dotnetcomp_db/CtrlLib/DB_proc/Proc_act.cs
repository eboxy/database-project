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
            if (WebConfigurationManager.ConnectionStrings["lokal"] == null)
            {
                throw new ApplicationException("ConnectionString saknas i web.config.");
            }
            else
            {
                connectionString = WebConfigurationManager.ConnectionStrings["lokal"].ConnectionString;
                
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


        
        
        //Lägga till post i DB:
        public int AddRecord(int val, int artist_no, string album, string format,
                              string press, string ar, string kommentar)
        {
            MySqlConnection con = new MySqlConnection(connectionString);

            int noaddrecs = 0;

            //Skapa kommandot
            string sql = "insert into cd_net";
            sql += "(Val, Artist_no, Album, Format, Press, Ar, Kommentar)";
            sql += " values(@Val, @Artist_no, @Album, @Format, @Press, @Ar, @Kommentar)";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Val", val);
            cmd.Parameters.AddWithValue("@Artist_no", artist_no);
            cmd.Parameters.AddWithValue("@Album", album);
            cmd.Parameters.AddWithValue("@Format", format);
            cmd.Parameters.AddWithValue("@Press", press);
            cmd.Parameters.AddWithValue("@Ar", ar);
            cmd.Parameters.AddWithValue("@Kommentar", kommentar);

            try
            {
                con.Open();
                noaddrecs = cmd.ExecuteNonQuery();
                return noaddrecs;
            }
            finally
            {
                con.Close();
            }

        }


        
        
        //Hämtar min- och maxgränser för rangevalidator gällande begränsingar 
        //av artisttabellens omfång (antal f.n inmatade artister)
        //Arbetar i samband med AddRecord-funktionen ovan:
        public int[] GetAggCDNet()
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            int min = 0;
            int max = 0;
            int[] aggstore = new int[2];


            string queryMIN = "SELECT MIN(No) FROM artist_net";
            string queryMAX = "SELECT MAX(No) FROM artist_net";

            MySqlCommand cmdMIN = new MySqlCommand(queryMIN, con);
            MySqlCommand cmdMAX = new MySqlCommand(queryMAX, con);

            try
            {
                con.Open();

                min = (int)cmdMIN.ExecuteScalar();
                max = (int)cmdMAX.ExecuteScalar();
                aggstore[0] = min;
                aggstore[1] = max;

                return aggstore;
            }
            finally
            {

                con.Close();

            }

        }


        
        
        //Tar bort post(er) i DB:
        public int DelRecord(int val)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            int nodelrecs = 0;

            //Skapa kommandot
            string sql = "Delete from cd_net where Val=@Val";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Val", val);

            try
            {
                con.Open();
                nodelrecs = cmd.ExecuteNonQuery();
                return nodelrecs;
            }
            finally
            {

                con.Close();

            }

        }


        
        
        //Uppdaterar post i DB:
        public int UpdateRecord(int row, int artist_no, string album, string format, string press,
                                string ar, string kommentar)
        {
            MySqlConnection con = new MySqlConnection(connectionString);

            //Skapa kommandot
            string sql = "update cd_net set Artist_no=@Artist_no, Album=@Album, ";
            sql += "Format=@Format, Press=@Press, Ar=@Ar, Kommentar=@Kommentar where `#`=@Row";

            MySqlCommand cmd = new MySqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@Row", row);

            cmd.Parameters.AddWithValue("@Artist_no", artist_no);
            cmd.Parameters.AddWithValue("@Album", album);
            cmd.Parameters.AddWithValue("@Format", format);
            cmd.Parameters.AddWithValue("@Press", press);
            cmd.Parameters.AddWithValue("@Ar", ar);
            cmd.Parameters.AddWithValue("@Kommentar", kommentar);


            try
            {
                con.Open();
                int noupdrecs = cmd.ExecuteNonQuery();
                return noupdrecs;
            }
            finally
            {
                con.Close();
            }
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



        
        
        //Hämtar vald post för uppdatering:
        public DataSet FetchRecord()
        {
            string query = "SELECT Artist, Artist_no, Album, Format, Press, Ar, Kommentar, Val, `#` FROM cd_net, ";
            query += "artist_net WHERE Artist IN (SELECT Artist FROM artist_net WHERE Artist_no=No) and val=1;";
            MySqlCommand cmd = new MySqlCommand(query);

            return FillDataSet(cmd, "Fetch_row");
        }



        
        
        //HÄR SKALL ÖVERFÖR-FUNKTIONEN VARA!!!!!!!!!!!!!!!!!!!!!!!!!OSBS!!!!!!!!!!!!!!!!!!



        
        


        
        

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




         
        
        


        
        
        //Lägger till längre kommentar till DB:
        public int AddKommentar(string kommentar, int kommentar_no)
        {
            MySqlConnection con = new MySqlConnection(connectionString);

            int noaddrecs = 0;

            //Skapa kommandot
            string sql = "update cd_net";
            sql += " set Kommentar=@Kommentar where `#`=@Kommentar_no";

            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Kommentar", kommentar);
            cmd.Parameters.AddWithValue("@Kommentar_no", kommentar_no);


            try
            {
                con.Open();
                noaddrecs = cmd.ExecuteNonQuery();
                return noaddrecs;
            }
            finally
            {
                con.Close();
            }

        }
        
      
        
        
        
        //Hämtar längre kommentar från DB:
        public DataSet FetchKommentar(int kommentar_no)
        {
            string query = "SELECT Kommentar FROM cd_net WHERE `#`=@kommentar_no";

            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@kommentar_no", kommentar_no);

            return FillDataSet(cmd, "Fetch_kommentar");
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

    






