using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

using DB_proc;
using TF.Namespace.Controls;


namespace Common_Tasks
{
    public class SetChks
    {
        
        private string connectionString;

        //Konstruktorn möjliggör för säker anslutning mot DB via web.config-inställningarna:
        public SetChks()
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
        
      

        //På- och avmarkera enskilda kryssrutor i skivtabell samt skivsökresultat-överlagrad:
        public void UpdateRecord_ChkBox(int row, int val)
        {
            MySqlConnection con = new MySqlConnection(connectionString);

            //Skapa kommandot
            string sql = "update cd_net set Val=@Val where `#`=@Row";
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

        //På- och avmarkera alla kryssrutor i skivtabell, även vid skivrefresh-överlagrad:
        public void UpdateRecord_ChkBox(int val)
        {
            MySqlConnection con = new MySqlConnection(connectionString);

            //Skapa kommandot
            string sql = "update cd_net set Val=@Val";
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
