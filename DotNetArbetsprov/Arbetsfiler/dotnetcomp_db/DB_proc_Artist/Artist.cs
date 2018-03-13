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

namespace DB_proc_Artist
{
    public class Artist
    {
//Anslutning mot DB:        
        
        
        
        //Anslutningssträng mot DB
        private string connectionString;
        
        //Anslutning mot DB inkl felhantering:
        public Artist()
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
            string query = "select No, ValArt ,Artist, VPfr, VPtill, Ursland, Ursstad, Musiktyp, Kortbio  from artist_net order by Artist asc";

            MySqlCommand cmd = new MySqlCommand(query);

            return FillDataSet(cmd, "whole");
        }



        //Lägga till post i DB:
        public int AddRecord(int val, string artist, string text9_VPfr, string text10_VPtill,
                              string text11_Ursland, string text12_Ursstad, string text13_Musiktyp,
                              string text14_Kortbio)
        {
            MySqlConnection con = new MySqlConnection(connectionString);

            int noaddrecs = 0;

            //Skapa kommandot
            string sql = "insert into artist_net ";
            sql += "(ValArt, Artist, VPfr, VPtill, Ursland, Ursstad, Musiktyp, Kortbio)";
            sql += " values(@ValArt, @Artist, @VPfr, @VPtill, @Ursland, @Ursstad, @Musiktyp, @Kortbio)";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ValArt", val);
            cmd.Parameters.AddWithValue("@Artist", artist);
            cmd.Parameters.AddWithValue("@VPfr", text9_VPfr);
            cmd.Parameters.AddWithValue("@VPtill", text10_VPtill);
            cmd.Parameters.AddWithValue("@Ursland", text11_Ursland);
            cmd.Parameters.AddWithValue("@Ursstad", text12_Ursstad);
            cmd.Parameters.AddWithValue("@Musiktyp", text13_Musiktyp);
            cmd.Parameters.AddWithValue("@Kortbio", text14_Kortbio);

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




        //Tar bort post(er) i DB:
        public int DelRecord(int val)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            int nodelrecs = 0;

            //Skapa kommandot
            string sql = "Delete from artist_net where ValArt=@ValArt";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ValArt", val);

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
        public int UpdateRecord(int row, string artist, string vpfr,
                   string vptill, string ursland, string ursstad, 
                   string musiktyp, string kortbio)   
            {
            MySqlConnection con = new MySqlConnection(connectionString);

            //Skapa kommandot
            string sql = "update artist_net set Artist=@Artist, Vpfr=@Vpfr, ";
            sql += "Vptill=@Vptill, Ursland=@Ursland, Ursstad=@Ursstad, ";
            sql += "Musiktyp=@Musiktyp, Kortbio=@Kortbio where No=@Row";

            MySqlCommand cmd = new MySqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@Row", row);

            cmd.Parameters.AddWithValue("@Artist", artist);
            cmd.Parameters.AddWithValue("@Vpfr", vpfr);
            cmd.Parameters.AddWithValue("@Vptill", vptill);
            cmd.Parameters.AddWithValue("@Ursland", ursland);
            cmd.Parameters.AddWithValue("@Ursstad", ursstad);
            cmd.Parameters.AddWithValue("@Musiktyp", musiktyp);
            cmd.Parameters.AddWithValue("@Kortbio", kortbio);

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
        public DataSet SearchRecords(string artist, string vpfr, string vptill, string ursland,
                       string ursstad, string musiktyp, string kortbio)
        {

            string query = "select No, ValArt, Artist, VPfr, VPtill, Ursland, Ursstad, Musiktyp FROM artist_net ";
            query += "where Artist like @Artist and VPfr ";
            query += "like @VPfr and VPtill like @VPtill and Ursland like @Ursland and Ursstad like @Ursstad ";
            query += "and Musiktyp like @Musiktyp and Kortbio like @Kortbio order by Artist";

            MySqlCommand cmd = new MySqlCommand(query);

            cmd.Parameters.AddWithValue("@Artist", "%" + artist + "%");
            cmd.Parameters.AddWithValue("@VPfr", "%" + vpfr + "%");
            cmd.Parameters.AddWithValue("@VPtill", "%" + vptill + "%");
            cmd.Parameters.AddWithValue("@Ursland", "%" + ursland + "%");
            cmd.Parameters.AddWithValue("@Ursstad", "%" + ursstad + "%");
            cmd.Parameters.AddWithValue("@Musiktyp", "%" + musiktyp + "%");
            cmd.Parameters.AddWithValue("@Kortbio", "%" + kortbio + "%");

            return FillDataSet(cmd, "Search");
        }



        //Hämtar vald post för uppdatering:
        public DataSet FetchRecord()
        {
            string query="select * from artist_net where ValArt=1";
            
            MySqlCommand cmd = new MySqlCommand(query);

            return FillDataSet(cmd, "Fetch_row");
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
        
        
        
        //Visar fakta om en artist:
        public DataSet CD_VisaArtistData(int row)
        {
            string query = "select No, Artist, VPfr, Vptill, Ursland, Ursstad, Musiktyp from artist_net where No=@Row";

            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@Row", row);

            return FillDataSet(cmd, "cd_visaartistdata");
        }


        //Adderar en kortbio-post till artisttabellen:
        public int AddKortbio(string kortbio, int artist_no)
        {
            MySqlConnection con = new MySqlConnection(connectionString);

            int noaddrecs = 0;

            //Skapa kommandot
            string sql = "update artist_net";
            sql += " set Kortbio=@Kortbio where No=@No";

            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Kortbio", kortbio);
            cmd.Parameters.AddWithValue("@No", artist_no);


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




        //Hämtar en kortbio från DB:
        public DataSet FetchKortbio(int artist_no)
        {
            string query = "SELECT Kortbio FROM artist_net WHERE No=@No";

            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@No", artist_no);

            return FillDataSet(cmd, "Fetch_kortbio");
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
