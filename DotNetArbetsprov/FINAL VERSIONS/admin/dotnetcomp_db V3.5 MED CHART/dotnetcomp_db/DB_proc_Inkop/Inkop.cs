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

namespace DB_proc_Inkop
{
    public class Inkop
    {

//Anslutning mot DB:        
        
        
        
        //Anslutningssträng mot DB
        private string connectionString;
        
        //Anslutning mot DB inkl felhantering:
        public Inkop()
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

            string query = "SELECT Skiv_no, ValInk , Art_no, Titel, Form, Land, Utg, Komt, Inm_dat, Kop_grad, Kop_kat, CAST(Ca_pris AS UNSIGNED INT) AS Ca_pris, No, Artist FROM inkop_net, artist_net  WHERE No=Art_no ORDER BY Artist, Titel asc";
            MySqlCommand cmd = new MySqlCommand(query);
            
            return FillDataSet(cmd, "whole");
        }


        
        
        
        //Lägga till post i DB:
        public int AddRecord(int val, int artist_no, string album, string format,
        string press, string ar, string kommentar, string inm_dat, string kop_grad,
        string kop_kat, string ca_pris)
        {
            MySqlConnection con = new MySqlConnection(connectionString);

            int noaddrecs = 0;

            //Skapa kommandot
            string sql = "insert into inkop_net";
            sql += "(ValInk, Art_no, Titel, Form, Land, Utg, Komt, Inm_dat, ";
            sql +="Kop_grad, Kop_kat, Ca_pris)";
            sql += " values(@ValInk, @Art_no, @Titel, @Form, @Land, @Utg, @Komt, ";
            sql +="@Inm_dat, @Kop_grad, @Kop_kat, @Ca_pris)";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ValInk", val);
            cmd.Parameters.AddWithValue("@Art_no", artist_no);
            cmd.Parameters.AddWithValue("@Titel", album);
            cmd.Parameters.AddWithValue("@Form", format);
            cmd.Parameters.AddWithValue("@Land", press);
            cmd.Parameters.AddWithValue("@Utg", ar);
            cmd.Parameters.AddWithValue("@Komt", kommentar);
            cmd.Parameters.AddWithValue("@Inm_dat", inm_dat);
            cmd.Parameters.AddWithValue("@Kop_grad", kop_grad);
            cmd.Parameters.AddWithValue("@Kop_kat", kop_kat);
            cmd.Parameters.AddWithValue("@Ca_pris", ca_pris);

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
            string sql = "Delete from inkop_net where ValInk=@ValInk";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ValInk", val);

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
                                string ar, string kommentar, string inm_dat, string kop_grad, 
                                string Kop_kat, string Ca_pris)
            {
            MySqlConnection con = new MySqlConnection(connectionString);

            //Skapa kommandot
            string sql = "update inkop_net set Art_no =@Art_no, Titel=@Titel, ";
            sql += "Form=@Form, Land=@Land, Utg=@Utg, Komt=@Komt, ";
            sql += "Inm_dat=@Inm_dat, Kop_grad=@Kop_grad, Kop_kat=@Kop_kat, ";
            sql += "Ca_pris=@Ca_pris where Skiv_no=@Row";

            MySqlCommand cmd = new MySqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@Row", row);

            cmd.Parameters.AddWithValue("@Art_no", artist_no);
            cmd.Parameters.AddWithValue("@Titel", album);
            cmd.Parameters.AddWithValue("@Form", format);
            cmd.Parameters.AddWithValue("@Land", press);
            cmd.Parameters.AddWithValue("@Utg", ar);
            cmd.Parameters.AddWithValue("@Komt", kommentar);
            cmd.Parameters.AddWithValue("@Inm_dat", inm_dat);
            cmd.Parameters.AddWithValue("@Kop_grad", kop_grad);
            cmd.Parameters.AddWithValue("@Kop_kat", Kop_kat);
            cmd.Parameters.AddWithValue("@Ca_pris", Ca_pris);


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
        public DataSet SearchRecords(string art_no, string album, string format, string press,
                       string ar, string kommentar, string inm_dat, string kop_grad, 
                       string kop_kat, string ca_pris)
            {

                string query = "select Skiv_no, ValInk, Art_no, Titel, Form, Land, Utg, Komt, Inm_dat, Kop_grad, ";
                query += "Kop_kat, CAST(Ca_pris AS UNSIGNED INT) AS Ca_pris, Artist FROM inkop_net, artist_net where Artist ";
                query += "in (select Artist from artist_net where Art_no=No) and Artist like @Artist and Titel ";
                query += "like @Titel and Form like @Form and Land like @Land and Utg like @Utg ";
                query += "and Komt like @Komt and Inm_dat like @Inm_dat and Kop_grad like @Kop_grad and ";
                query += "Kop_kat like @Kop_kat and Ca_pris like @Ca_pris order by Titel";

            MySqlCommand cmd = new MySqlCommand(query);

            cmd.Parameters.AddWithValue("@Artist", "%" + art_no + "%");
            cmd.Parameters.AddWithValue("@Titel", "%" + album + "%");
            cmd.Parameters.AddWithValue("@Form", "%" + format + "%");
            cmd.Parameters.AddWithValue("@Land", "%" + press + "%");
            cmd.Parameters.AddWithValue("@Utg", "%" + ar + "%");
            cmd.Parameters.AddWithValue("@Komt", "%" + kommentar + "%");
            cmd.Parameters.AddWithValue("@Inm_dat", "%" + inm_dat + "%");
            cmd.Parameters.AddWithValue("@Kop_grad", "%" + kop_grad + "%");
            cmd.Parameters.AddWithValue("@Kop_kat", "%" + kop_kat + "%");
            cmd.Parameters.AddWithValue("@Ca_pris", "%" + ca_pris + "%");

            return FillDataSet(cmd, "Search");
        }







        //Hämtar vald post för uppdatering:
        public DataSet FetchRecord()
        {
            string query = "SELECT Skiv_no, ValInk, Art_no, Titel, Form, Land, Utg, Komt, Inm_dat, Kop_grad, Kop_kat, "; 
            query +="Ca_pris, Artist FROM inkop_net, ";
            query += "artist_net WHERE Artist IN (SELECT Artist FROM artist_net WHERE Art_no=No) and ValInk=1;";
            MySqlCommand cmd = new MySqlCommand(query);

            return FillDataSet(cmd, "Fetch_row");
        }




        
        
        
        //Överför post från Inkopstabell till Skivtabell:
        public int TransferRecord(int valink)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            int notransfrecs = 0;
            
            //Väljer ut post i inkoptabell och kopierar den till skivtabell:
            string sql = "insert into cd_net";
            sql += "(Artist_no, Album, Format, Press, Ar, Kommentar) ";
            sql += "select Art_no, Titel, Form, Land, Utg, Komt ";
            sql += "from inkop_net where ValInk=@ValInk";

            //Tar bort överförd post i inkopstabell:
            string sql2 = "delete from inkop_net where ValInk=1";
            
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlCommand cmd2 = new MySqlCommand(sql2, con);

            cmd.Parameters.AddWithValue("@ValInk", valink);
            
            try
            {
                con.Open();
                notransfrecs = cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                
                return notransfrecs;
            }
            finally
            {
                con.Close();
            }
        
        
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
            string query = "select Skiv_no, Komt FROM inkop_net WHERE Skiv_no =@Row";

            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@Row", row);

            return FillDataSet(cmd, "inkop_komtr");
        }



        //Visar fakta om en artist:
        public DataSet CD_VisaArtistData(int row)
        {
            string query = "select No, Artist, VPfr, Vptill, Ursland, Ursstad, Musiktyp from artist_net where No=@Row";

            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@Row", row);

            return FillDataSet(cmd, "inkop_visaartistdata");
        }





        //Lägger till längre kommentar till DB:
        public int AddKommentar(string kommentar, int kommentar_no)
        {
            MySqlConnection con = new MySqlConnection(connectionString);

            int noaddrecs = 0;

            //Skapa kommandot
            string sql = "update inkop_net";
            sql += " set Komt=@Komt where Skiv_no=@Kommentar_no";

            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Komt", kommentar);
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
            string query = "SELECT Komt FROM inkop_net WHERE Skiv_no=@kommentar_no";

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
