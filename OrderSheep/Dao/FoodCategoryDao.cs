using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace OrderSheep.Dao
{
    public class FoodCategoryDao
    {
        OleDbConnection conn;
        OleDbDataAdapter adapter;
        string connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        public DataTable GetAllFoodCategory()
        {
            conn = new OleDbConnection(connectionString);
            conn.Open();

            DataTable dt = new DataTable();

            adapter = new OleDbDataAdapter("SELECT * FROM FoodCategory;",
                conn);
            adapter.Fill(dt);
            conn.Close();
            return dt;
        }
    }
}
