using LR8v8.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LR8v8.Functions
{
    internal class StorekeeperService
    {
        SqlConnection connection;
        static readonly string BD_Key = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public bool Create(Storekeeper storekeeper)
        {
            using (connection = new SqlConnection(BD_Key))
            {
                try
                {
                    connection.Open();

                    string InputQuery = string.Format(
                           "insert into Storekeeper" +
                           "(FIO, Experience, adress)" +
                           "Values" +
                           "(@FIO, @Experience, @address)"
                           );
                    using (SqlCommand cmd = new SqlCommand(InputQuery, this.connection))
                    {
                        // Добавить параметры
                        cmd.Parameters.AddWithValue("@FIO", storekeeper.FIO);
                        cmd.Parameters.AddWithValue("@Experience", storekeeper.Experience);
                        cmd.Parameters.AddWithValue("@address", storekeeper.Adress);


                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                    return true;
                }
                catch (Exception ex) { MessageBox.Show("Ошибка в StorekeeperService Create\nException: " + ex.Message); }
                finally
                {
                    connection.Close();
                }
                return false;
            }
        }
        //Транзакция
        public bool Delete(int id)
        {
            //Транзакция
            try
            {
                using (connection = new SqlConnection(BD_Key))
                {
                    connection.Open();

                    SqlTransaction transaction = connection.BeginTransaction("DeleteTransaction");

                    SqlCommand command1 = new SqlCommand($"delete Storekeeper from Storekeeper where Id = {id}", connection);

                    command1.Transaction = transaction;
                    command1.ExecuteNonQuery();

                    transaction.Commit();
                }
                connection.Close();
                return true;
            }
            catch (Exception ex) { MessageBox.Show("Ошибка в StorekeeperService Delete\nException: " + ex.Message); }
            finally
            {
                connection.Close();
            }
            return false;
            /*
            //Обычынй вариант
            try
            {
                using (connection = new SqlConnection(BD_Key))
                {
                    connection.Open();
                    string DeleteQuery = string.Format("delete Storekeeper from Storekeeper where Id = (@id)"); ;

                    using (SqlCommand cmd = new SqlCommand(DeleteQuery, this.connection))
                    {
                        // Добавить параметры
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("dbo.Product"))
                    MessageBox.Show("Нельзя удалить объект, он используется таблицей Product");
                else
                    MessageBox.Show("Ошибка в StorekeeperService Delete\nException: " + ex.Message);
            }
            finally { connection.Close(); }
            return false;
             */
        }

        public DataView ReadArray()
        {
            using (connection = new SqlConnection(BD_Key))
            {
                connection.Open();

                string SelectQuery = string.Format(
                       "select * from Storekeeper"
                       );

                using (SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, this.connection))
                {
                    try
                    {
                        DataSet DS = new DataSet();
                        SDA.Fill(DS);

                        return DS.Tables[0].DefaultView;
                    }
                    catch (Exception ex) { }
                }


                connection.Close();
            }
            return null;
        }

        public bool Update(Storekeeper storekeeper)
        {
            try
            {
                using (connection = new SqlConnection(BD_Key))
                {
                    connection.Open();

                    string UpdateQuery = string.Format(
                           "UPDATE Storekeeper SET FIO = @FIO, Experience = @Experience, adress = @adress WHERE Id = @id"
                           ); ;
                    using (SqlCommand cmd = new SqlCommand(UpdateQuery, this.connection))
                    {
                        // Добавить параметры
                        cmd.Parameters.AddWithValue("@FIO", storekeeper.FIO);
                        cmd.Parameters.AddWithValue("@Experience", storekeeper.Experience);
                        cmd.Parameters.AddWithValue("@adress", storekeeper.Adress);
                        cmd.Parameters.AddWithValue("@Id", storekeeper.Id);


                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex) { MessageBox.Show("Ошибка в StorekeeperService Create\nException: " + ex.Message); }
            finally
            {
                connection.Close();
            }
            return false;
        }
    }
}
