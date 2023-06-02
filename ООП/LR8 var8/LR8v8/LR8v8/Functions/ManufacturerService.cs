using LR8v8.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LR8v8.Functions
{
    internal class ManufacturerService
    {
        SqlConnection connection;
        static readonly string BD_Key = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public bool Create(Manufacturer manufacturer)
        {
            using (connection = new SqlConnection(BD_Key))
            {
                try
                {
                    connection.Open();

                    string InputQuery = string.Format(
                           "insert into Manufacturer" +
                           "(organization, country, address, phone)" +
                           "Values" +
                           "(@organization, @country, @address, @phone)"
                           );
                    using (SqlCommand cmd = new SqlCommand(InputQuery, this.connection))
                    {
                        // Добавить параметры
                        cmd.Parameters.AddWithValue("@organization", manufacturer.Organization);
                        cmd.Parameters.AddWithValue("@country", manufacturer.Country);
                        cmd.Parameters.AddWithValue("@address", manufacturer.Adress);
                        cmd.Parameters.AddWithValue("@phone", manufacturer.phone);


                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                    return true;
                }
                catch (Exception ex) { MessageBox.Show("Ошибка в ManufacturerService Create\nException: " + ex.Message); }
                finally { 
                    connection.Close(); 
                }
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (connection = new SqlConnection(BD_Key))
                {
                    connection.Open();
                    string DeleteQuery = string.Format("delete Manufacturer from Manufacturer where Id = (@id)"); ;

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
                    MessageBox.Show("Ошибка в ManufacturerService Delete\nException: " + ex.Message); 
            }
            finally { connection.Close(); }
            return false;
        }

        public DataView ReadArray()
        {
            using (connection = new SqlConnection(BD_Key))
            {
                connection.Open();

                string SelectQuery = string.Format(
                       "select * from Manufacturer"
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

        public bool Update(Manufacturer manufacturer)
        {
            try
            {
                using (connection = new SqlConnection(BD_Key))
                {
                    connection.Open();

                    string UpdateQuery = string.Format(
                           "UPDATE Manufacturer SET organization = @organization, country = @country, address = @address, phone = @phone WHERE Id = @id"
                           ); ;
                    using (SqlCommand cmd = new SqlCommand(UpdateQuery, this.connection))
                    {
                        // Добавить параметры
                        cmd.Parameters.AddWithValue("@organization", manufacturer.Organization);
                        cmd.Parameters.AddWithValue("@country", manufacturer.Country);
                        cmd.Parameters.AddWithValue("@address", manufacturer.Adress);
                        cmd.Parameters.AddWithValue("@phone", manufacturer.phone);
                        cmd.Parameters.AddWithValue("@Id", manufacturer.Id);


                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex) { MessageBox.Show("Ошибка в ManufacturerService Create\nException: " + ex.Message); }
            finally
            {
                connection.Close();
            }
            return false;
        }
    }
}
