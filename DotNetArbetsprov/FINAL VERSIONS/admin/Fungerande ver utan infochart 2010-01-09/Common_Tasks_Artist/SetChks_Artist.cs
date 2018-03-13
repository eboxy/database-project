using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

using DB_proc_Artist;
using TF.Namespace.Controls;

namespace Common_Tasks_Artist
{
    public class SetChks_Artist
    {
         private string connectionString;

        //Konstruktorn möjliggör för säker anslutning mot DB via web.config-inställningarna:
         public SetChks_Artist()
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



        //På- och avmarkera enskilda kryssrutor i artisttabell samt artistsökresultat-överlagrad:
        public void UpdateRecord_Artist_ChkBox(int row, int val)
        {
            MySqlConnection con = new MySqlConnection(connectionString);

            //Skapa kommandot
            string sql = "update artist_net set ValArt=@Val where No=@Row";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Val", val);
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

        //På- och avmarkera alla kryssrutor i artisttabell, även vid artistrefresh-överlagrad:
        public void UpdateRecord_Artist_ChkBox(int val)
        {
            MySqlConnection con = new MySqlConnection(connectionString);

            //Skapa kommandot
            string sql = "update artist_net set ValArt=@Val";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Val", val);


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
