using OrderSheep.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSheep.Dao
{
    public class RoomDao
    {
        OleDbConnection conn;
        OleDbDataAdapter adapter;
        OleDbCommand command;
        string connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

        public DataTable GetAllRooms()
        {
            using (conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                DataTable dt = new DataTable();

                adapter = new OleDbDataAdapter("SELECT r.*, s.StateName FROM Room r left join RoomState s on r.State=s.Id where HasDeleted = false order by r.Id desc;",
                    conn);
                adapter.Fill(dt);
                return dt;
            }
        }

        public RoomEntity GetRoomById(int id)
        {
            using (conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (command = new OleDbCommand("select Id, RoomName, Description, State, CreateTime from Room where Id = " + id, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            RoomEntity entity = new RoomEntity();
                            entity.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            entity.Name = !reader.IsDBNull(reader.GetOrdinal("RoomName")) ?
                                reader.GetString(reader.GetOrdinal("RoomName")) : "";
                            entity.Description = !reader.IsDBNull(reader.GetOrdinal("Description")) ?
                                reader.GetString(reader.GetOrdinal("Description")) : "";
                            entity.State = !reader.IsDBNull(reader.GetOrdinal("State")) ?
                                reader.GetInt32(reader.GetOrdinal("State")) : 1;
                            entity.CreateTime = reader.GetDateTime(reader.GetOrdinal("CreateTime"));
                            return entity;
                        }
                        return null;
                    }

                }
            }
        }

        public int AddRoom(RoomEntity entity)
        {
            using (conn = new OleDbConnection(connectionString)) { 
                conn.Open();
                command = new OleDbCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "insert into Room (RoomName, Description, State, CreateTime) values (@name, @des, @state, @ctime)";
                command.Parameters.AddWithValue("name", entity.Name);
                command.Parameters.AddWithValue("des", entity.Description);
                command.Parameters.AddWithValue("state", entity.State);
                command.Parameters.AddWithValue("ctime", entity.CreateTime.ToString());
                command.ExecuteNonQuery();
                command.CommandText = "SELECT @@IDENTITY;";
                object obj = command.ExecuteScalar();
                return (int)obj;
            }
            
        }

        public void UpdateRoom(RoomEntity entity)
        {
            using (conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string sql = "update Room set RoomName=@name, Description=@des, State=@state where Id=" + entity.Id + ";";
                using (command = new OleDbCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("name", entity.Name);
                    command.Parameters.AddWithValue("des", entity.Description);
                    command.Parameters.AddWithValue("state", entity.State);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteRoomById(int id)
        {
            using (conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (command = new OleDbCommand("update Room set HasDeleted=1 where Id = " + id, conn))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
