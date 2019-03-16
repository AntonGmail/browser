using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Browser.Models
{
    class DbContext
    {
        private string conn_str;
        private SqlConnection conn;

        public List<category> Categories { get; set; }
        public List<site> Sites { get; set; }
        
        public DbContext()
        {
            Categories = new List<category>();
            Sites = new List<site>();
            conn_str = ConfigurationManager.ConnectionStrings["conn1"].ConnectionString;
            conn = new SqlConnection(conn_str);

        }

        private void Load()
        {
            
            

            conn.Open();
            string query1 = "select * from Categories";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            while(reader1.Read())
            {
                Categories.Add(new category()
                {
                    id = (int)reader1["id"],
                    name = reader1["name"].ToString()
                });

            }
            conn.Close();
            conn.Open();
            string query2 = "select * from Sites";
            SqlCommand cmd2 = new SqlCommand(query2, conn);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                Sites.Add(new site()
                {
                    id = (int)reader2["id"],
                    name = reader2["name"].ToString(),
                    address = reader2["address"].ToString(),
                    categoryid = (int)reader2["categoryid"]
                });

            }
            conn.Close();
        }

        public void Save()
        {

        }
    }
}
