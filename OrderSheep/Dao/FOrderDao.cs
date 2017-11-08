using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderSheep.Entity;

namespace OrderSheep.Dao
{
    public class FOrderDao
    {
        OleDbConnection conn;
        OleDbDataAdapter adapter;
        OleDbCommand command;
        string connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        public DataTable GetOrderByRoomId(int roomId) { 
            using (conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                DataTable dt = new DataTable();
                string sql = "SELECT o.Id, f.Name, o.Quantity, o.Price, o.Amount from FOrder o inner join FoodItems f on o.FoodId=f.Id where o.HasFinished = false and o.roomId=" + roomId;
                adapter = new OleDbDataAdapter(sql, conn);
                adapter.Fill(dt);
                return dt;
            }
        }

        public FOrderEntity GetOpenFOrder(int roomId, int foodId)
        {
            using (conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (command = new OleDbCommand("select * from FOrder where HasFinished = false and RoomId=" + roomId + " and FoodId=" + foodId, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            FOrderEntity entity = new FOrderEntity();
                            entity.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            entity.RoomId = reader.GetInt32(reader.GetOrdinal("RoomId"));
                            entity.FoodId = reader.GetInt32(reader.GetOrdinal("FoodId"));
                            entity.Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
                            entity.Price = reader.GetFloat(reader.GetOrdinal("Price"));
                            entity.Amount = reader.GetFloat(reader.GetOrdinal("Amount"));
                            return entity;
                        }
                        return null;
                    }

                }
            }
        }

        public int AddFOrder(FOrderEntity entity)
        {
            using (conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (command = new OleDbCommand()) {
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "insert into FOrder (RoomId, FoodId, Quantity, Price, Amount, StartTime) values (@rid, @fid, @quantity, @price, @amount, @stime)";
                    command.Parameters.AddWithValue("rid", entity.RoomId);
                    command.Parameters.AddWithValue("fid", entity.FoodId);
                    command.Parameters.AddWithValue("quantity", entity.Quantity);
                    command.Parameters.AddWithValue("price", entity.Price);
                    command.Parameters.AddWithValue("amount", entity.Amount);
                    command.Parameters.AddWithValue("stime", entity.StartTime.ToString());
                    command.ExecuteNonQuery();
                    command.CommandText = "SELECT @@IDENTITY;";
                    object obj = command.ExecuteScalar();
                    return (int)obj;
                }
            }
        }

        public void ResetFOrderQuantity(FOrderEntity entity) {
            using (conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (command = new OleDbCommand())
                {
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "update FOrder set Quantity=@qua, Amount=@amo where Id=@id;";
                    command.Parameters.AddWithValue("qua", entity.Quantity);
                    command.Parameters.AddWithValue("amo", entity.Amount);
                    command.Parameters.AddWithValue("id", entity.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteFOrderById(int id)
        {
            using (conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (command = new OleDbCommand("delete from FOrder where Id = " + id, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
