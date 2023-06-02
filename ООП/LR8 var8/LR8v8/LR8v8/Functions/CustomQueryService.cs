using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LR8v8.Functions
{
    internal class CustomQueryService
    {
        SqlConnection connection;
        static readonly string BD_Key = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public bool Query(string query)
        {
            //Транзакция
            try
            {
                using (connection = new SqlConnection(BD_Key))
                {
                    connection.Open();

                    SqlTransaction transaction = connection.BeginTransaction("Transaction");

                    SqlCommand command1 = new SqlCommand($"{query}", connection);

                    command1.Transaction = transaction;
                    command1.ExecuteNonQuery();

                    transaction.Commit();
                }
                connection.Close();
                return true;
            }
            catch (Exception ex) { MessageBox.Show("Ошибка в CustomQueryService Query\nException: " + ex.Message); }
            finally
            {
                connection.Close();
            }
            return false;

        }
    }
}
