using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSheep.Dao
{
    public class RoomStateDao
    {
        OleDbConnection conn;
        OleDbDataAdapter adapter;
        string connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        public DataTable GetAllRoomStates()
        {
            using (conn = new OleDbConnection(connectionString)) {
                conn.Open();
                DataTable dt = new DataTable();

                adapter = new OleDbDataAdapter("SELECT * FROM RoomState;",
                    conn);
                adapter.Fill(dt);
                return dt;
            }
        }
    }
}
