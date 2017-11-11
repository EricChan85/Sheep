using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderSheep.Entity;
using System.Data.OleDb;
using System.Data;

namespace OrderSheep.Dao
{
    public class SOrderDao
    {
        OleDbConnection conn;
        OleDbDataAdapter adapter;
        OleDbCommand command;
        string connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

        public int AddSorder(SOrderEntity entity) {
            using (conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                command = new OleDbCommand();
                command.Connection = conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "insert into SOrder (RoomId, Amount, State, UserName, Mobile, StartTime) values (@rId, @amount, @state, @uname, @mobile, @stime)";
                command.Parameters.AddWithValue("rId", entity.RoomId);
                command.Parameters.AddWithValue("amount", entity.Amount == null ? 0 : entity.Amount);
                command.Parameters.AddWithValue("state", entity.State);
                command.Parameters.AddWithValue("uname", entity.UserName == null ? "" : entity.UserName);
                command.Parameters.AddWithValue("mobile", entity.Mobile == null ? "" : entity.Mobile);
                command.Parameters.AddWithValue("stime", entity.StartTime.ToString());
                command.ExecuteNonQuery();
                command.CommandText = "SELECT @@IDENTITY;";
                object obj = command.ExecuteScalar();
                return (int)obj;
            }
        }

        public void StartOrder(SOrderEntity entity) {
            using (conn = new OleDbConnection(connectionString))
            {
                command = new OleDbCommand();
                OleDbTransaction transaction = null;

                // Set the Connection to the new OleDbConnection.
                command.Connection = conn;

                // Open the connection and execute the transaction.
                try
                {
                    conn.Open();

                    // Start a local transaction with ReadCommitted isolation level.
                    transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    // Assign transaction object for a pending local transaction.
                    command.Connection = conn;
                    command.Transaction = transaction;

                    // Execute the commands.
                    command.CommandType = CommandType.Text;
                    command.CommandText = "insert into SOrder (RoomId, Amount, State, UserName, Mobile, StartTime) values (@rId, @amount, @state, @uname, @mobile, @stime)";
                    command.Parameters.AddWithValue("rId", entity.RoomId);
                    command.Parameters.AddWithValue("amount", entity.Amount);
                    command.Parameters.AddWithValue("state", entity.State);
                    command.Parameters.AddWithValue("uname", entity.UserName == null ? "" : entity.UserName);
                    command.Parameters.AddWithValue("mobile", entity.Mobile == null ? "" : entity.Mobile);
                    command.Parameters.AddWithValue("stime", entity.StartTime.ToString());
                    command.ExecuteNonQuery();
                    command.CommandText =
                        "update Room set State = 2 where Id = " +entity.RoomId;
                    command.ExecuteNonQuery();

                    // Commit the transaction.
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    try
                    {
                        // Attempt to roll back the transaction.
                        transaction.Rollback();
                    }
                    catch
                    {
                        // Do nothing here; transaction is not active.
                    }
                }
                // The connection is automatically closed when the
                // code exits the using block.
            }
        }

        public void PayOrder(int roomId)
        {
            using (conn = new OleDbConnection(connectionString))
            {
                command = new OleDbCommand();
                OleDbTransaction transaction = null;

                // Set the Connection to the new OleDbConnection.
                command.Connection = conn;

                // Open the connection and execute the transaction.
                try
                {
                    conn.Open();

                    // Start a local transaction with ReadCommitted isolation level.
                    transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    // Assign transaction object for a pending local transaction.
                    command.Connection = conn;
                    command.Transaction = transaction;

                    // Execute the commands.
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select sum(Amount) from FOrder where HasFinished = false and RoomId =" + roomId;
                    //object obj = command.ExecuteScalar();
                    float amount = Convert.ToSingle(command.ExecuteScalar());
                    command.CommandText =
                        "update SOrder set Amount =@amount, State=2, EndTime=@eTime where RoomId=@roomId and State=1";                    
                    command.Parameters.AddWithValue("amount", amount);
                    command.Parameters.AddWithValue("etime", DateTime.Now.ToString());
                    command.Parameters.AddWithValue("roomId", roomId);
                    command.ExecuteNonQuery();
                    command.CommandText =
                        "update FOrder set HasFinished=true where HasFinished=false and RoomId=" + roomId;
                    command.ExecuteNonQuery();
                    command.CommandText =
                        "update Room set State = 1 where Id = " + roomId;
                    command.ExecuteNonQuery();

                    // Commit the transaction.
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    try
                    {
                        // Attempt to roll back the transaction.
                        transaction.Rollback();
                    }
                    catch
                    {
                        // Do nothing here; transaction is not active.
                    }
                }
                // The connection is automatically closed when the
                // code exits the using block.
            }
        }

        public void QuitOrder(int roomId)
        {
            using (conn = new OleDbConnection(connectionString))
            {
                command = new OleDbCommand();
                OleDbTransaction transaction = null;

                // Set the Connection to the new OleDbConnection.
                command.Connection = conn;

                // Open the connection and execute the transaction.
                try
                {
                    conn.Open();

                    // Start a local transaction with ReadCommitted isolation level.
                    transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);

                    // Assign transaction object for a pending local transaction.
                    command.Connection = conn;
                    command.Transaction = transaction;
                    
                    command.CommandText =
                        "delete from SOrder where RoomId=@roomId and State=1";
                    command.Parameters.AddWithValue("roomId", roomId);
                    command.ExecuteNonQuery();
                    command.CommandText =
                        "delete from FOrder where HasFinished=false and RoomId=" + roomId;
                    command.ExecuteNonQuery();
                    command.CommandText =
                        "update Room set State = 1 where Id = " + roomId;
                    command.ExecuteNonQuery();

                    // Commit the transaction.
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    try
                    {
                        // Attempt to roll back the transaction.
                        transaction.Rollback();
                    }
                    catch
                    {
                        // Do nothing here; transaction is not active.
                    }
                }
                // The connection is automatically closed when the
                // code exits the using block.
            }
        }

        public DataTable GetReportByTime(DateTime start, DateTime end) {
            using (conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                DataTable dt = new DataTable();

                string sql = "SELECT r.RoomName, s.StartTime, s.Amount, s.UserName, s.Mobile FROM SOrder s inner join Room r on s.RoomId=r.Id where s.State = 2 and s.StartTime > #" + start.ToString() + "# and s.StartTime < #" + end.ToString() + "#  order by s.Id desc;";
                adapter = new OleDbDataAdapter(sql,
                    conn);
                adapter.Fill(dt);
                return dt;
            }
        }
    }
}
