using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

using DB_proc_Inkop;
using TF.Namespace.Controls;

namespace Common_Tasks_Inkop
{
    public class SetChks_Inkop
    {

        private string connectionString;

        //Konstruktorn möjliggör för säker anslutning mot DB via web.config-inställningarna:
        public SetChks_Inkop()
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



        //På- och avmarkera enskilda kryssrutor i inkoptabell samt inkopsökresultat-överlagrad:
        public void UpdateRecord_ChkBox(int row, int val)
        {
            MySqlConnection con = new MySqlConnection(connectionString);

            //Skapa kommandot
            string sql = "update inkop_net set ValInk =@ValInk where Skiv_no =@Row";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ValInk", val);
            cmd.Parameters.AddWithValue("@Row", row);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();

            }
        }

        //På- och avmarkera alla kryssrutor i inkoptabell, även vid inkoprefresh-överlagrad:
        public void UpdateRecord_ChkBox(int val)
        {
            MySqlConnection con = new MySqlConnection(connectionString);

            //Skapa kommandot
            string sql = "update inkop_net set ValInk=@ValInk";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ValInk", val);


            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();

            }
        }



    }








}
