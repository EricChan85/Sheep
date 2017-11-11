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
    public class FoodItemDao
    {
        OleDbConnection conn;
        OleDbDataAdapter adapter;
        OleDbCommand command;
        string connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        public DataTable GetAllFoodItems()
        {
            conn = new OleDbConnection(connectionString);
            conn.Open();

            DataTable dt = new DataTable();

            adapter = new OleDbDataAdapter("SELECT f.*, c.CatName FROM FoodItems f inner join FoodCategory c on f.Category=c.Id where f.HasDeleted = false order by f.Category;", conn);
            adapter.Fill(dt);
            conn.Close();
            return dt;
        }

        public FoodItemsEntity GetFoodItemsById(int id) {
            using (conn = new OleDbConnection(connectionString)) {
                conn.Open();
                using (command = new OleDbCommand("select Id, Name, Description, Category, RetailPrice, PicExtension, CreateTime from FoodItems where Id = " + id, conn)) {
                    using (var reader = command.ExecuteReader()) {
                        if (reader.Read()) { 
                            FoodItemsEntity entity = new FoodItemsEntity();
                            entity.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            entity.Name = !reader.IsDBNull(reader.GetOrdinal("Name")) ?
                                reader.GetString(reader.GetOrdinal("Name")) : "";
                            entity.Description = !reader.IsDBNull(reader.GetOrdinal("Description")) ?
                                reader.GetString(reader.GetOrdinal("Description")) : "";
                            entity.Category = !reader.IsDBNull(reader.GetOrdinal("Category")) ?
                                reader.GetInt32(reader.GetOrdinal("Category")) : 1;
                            entity.RetailPrice = !reader.IsDBNull(reader.GetOrdinal("RetailPrice")) ?
                                reader.GetFloat(reader.GetOrdinal("RetailPrice")) : 0;
                            entity.PicExtension = !reader.IsDBNull(reader.GetOrdinal("PicExtension")) ?
                                reader.GetString(reader.GetOrdinal("PicExtension")) : "";
                            entity.CreateTime = reader.GetDateTime(reader.GetOrdinal("CreateTime"));
                            return entity;
                        }
                        return null;
                    }
                    
                }
            }
        }

        public int AddFoodItems(FoodItemsEntity entity) {
            conn = new OleDbConnection(connectionString);
            conn.Open();
            command = new OleDbCommand();
            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "insert into FoodItems (Name, Description, Category, RetailPrice, PicExtension, CreateTime) values (@name, @des, @cat, @price, @ext, @ctime)";
            command.Parameters.AddWithValue("name", entity.Name);
            command.Parameters.AddWithValue("des", entity.Description);
            command.Parameters.AddWithValue("cat", entity.Category);
            command.Parameters.AddWithValue("price", entity.RetailPrice);
            command.Parameters.AddWithValue("ext", entity.PicExtension);
            command.Parameters.AddWithValue("ctime", entity.CreateTime.ToString());            
            command.ExecuteNonQuery();
            command.CommandText = "SELECT @@IDENTITY;";
            object obj = command.ExecuteScalar();
            conn.Close();
            return (int)obj;
        }

        public void UpdateFoodItems(FoodItemsEntity entity) {
            using (conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string sql = "update FoodItems set Name=@name, Description=@des, Category=@cat, RetailPrice=@price, PicExtension=@ext where Id=" + entity.Id + ";";
                using (command = new OleDbCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("name", entity.Name);
                    command.Parameters.AddWithValue("des", entity.Description);
                    command.Parameters.AddWithValue("cat", entity.Category);
                    command.Parameters.AddWithValue("price", entity.RetailPrice);
                    command.Parameters.AddWithValue("ext", entity.PicExtension);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void DeleteFoodItemsById(int id) {
            using (conn = new OleDbConnection(connectionString)) {
                conn.Open();
                using (command = new OleDbCommand("update FoodItems set HasDeleted=1 where Id = " + id, conn)) {
                    command.ExecuteNonQuery();                    
                }
            }
        }

        public int GetFoodItemsIdentity() {
            conn = new OleDbConnection(connectionString);
            conn.Open();

            command.Connection = conn;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT MAX(Id) from FoodItems;";
            object obj = command.ExecuteScalar();
            conn.Close();
            return (int)obj;
        }
    }
}
