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



        
        //Söker i DB:
        public DataSet SearchRecords(string artist, string vpfr, string vptill, string ursland,
                       string ursstad, string musiktyp)
        {

            string query = "select No, ValArt, Artist, VPfr, VPtill, Ursland, Ursstad, Musiktyp FROM artist_net ";
            query += "where Artist like @Artist and VPfr ";
            query += "like @VPfr and VPtill like @VPtill and Ursland like @Ursland and Ursstad like @Ursstad ";
            query += "and Musiktyp like @Musiktyp order by Artist";

            MySqlCommand cmd = new MySqlCommand(query);

            cmd.Parameters.AddWithValue("@Artist", "%" + artist + "%");
            cmd.Parameters.AddWithValue("@VPfr", "%" + vpfr + "%");
            cmd.Parameters.AddWithValue("@VPtill", "%" + vptill + "%");
            cmd.Parameters.AddWithValue("@Ursland", "%" + ursland + "%");
            cmd.Parameters.AddWithValue("@Ursstad", "%" + ursstad + "%");
            cmd.Parameters.AddWithValue("@Musiktyp", "%" + musiktyp + "%");
            
            return FillDataSet(cmd, "Search");
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
