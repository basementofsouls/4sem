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
using System.Xml.Linq;

namespace LR8v8.Functions
{
    internal class ProductService
    {
        SqlConnection connection;
        static readonly string BD_Key = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public bool Create(Product product)
        {
            using (connection = new SqlConnection(BD_Key))
            {
                try
                {
                    connection.Open();

                    string InputQuery = string.Format(
                           "insert into Product" +
                           "(Image, Name, Size, Weight, Type, Date, Amount, Price, ManufacturerId, StorekeeperId)" +
                           "Values(" +
                           "@Image, @Name, @Size,@Weight, @Type, @Date, @Amount, @Price, @ManufacturerId, @StorekeeperId)"
                           );

                    using (SqlCommand cmd = new SqlCommand(InputQuery, this.connection))
                    {
                        // Добавить параметры
                        cmd.Parameters.AddWithValue("@Image", product.Image);
                        cmd.Parameters.AddWithValue("@Name", product.Name);
                        cmd.Parameters.AddWithValue("@Size", product.Size);
                        cmd.Parameters.AddWithValue("@Weight", product.Weight);
                        cmd.Parameters.AddWithValue("@Type", product.Type);
                        cmd.Parameters.AddWithValue("@Date", product.Date);
                        cmd.Parameters.AddWithValue("@Amount", product.Amount);
                        cmd.Parameters.AddWithValue("@Price", product.Price);
                        cmd.Parameters.AddWithValue("@ManufacturerId", product.ManufacturerId);
                        cmd.Parameters.AddWithValue("@StorekeeperId", product.StorekeeperId);

                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                    return true;
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("Ошибка в ProductService Create\nException: " + ex.Message);
                }
                finally 
                {
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
                    string DeleteQuery = string.Format(
                           "delete product from Product where InventoryNumber = (@id);"
                                                  ); ;

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
            catch(Exception ex) { MessageBox.Show("Ошибка в ProductService Delete\nException: " + ex.Message); }
            finally { connection.Close(); }
            return false;
        }
        public bool Update(Product product)
        {
            using (connection = new SqlConnection(BD_Key))
            {
                try
                {
                    connection.Open();

                    string UpdateQuery = string.Format(
                           "UPDATE Product SET Image = @Image, Name = @Name, Size = @Size, Weight = @Weight, Type = @Type, Date = @Date, Amount = @Amount, Price = @Price, ManufacturerId = @ManufacturerId, StorekeeperId = @StorekeeperId where InventoryNumber = @InventoryNumber"
                           );

                    using (SqlCommand cmd = new SqlCommand(UpdateQuery, this.connection))
                    {
                        // Добавить параметры
                        cmd.Parameters.AddWithValue("@Image", product.Image);
                        cmd.Parameters.AddWithValue("@Name", product.Name.ToString());
                        cmd.Parameters.AddWithValue("@Size", product.Size);
                        cmd.Parameters.AddWithValue("@Weight", product.Weight);
                        cmd.Parameters.AddWithValue("@Type", product.Type);
                        cmd.Parameters.AddWithValue("@Date", product.Date);
                        cmd.Parameters.AddWithValue("@Amount", product.Amount);
                        cmd.Parameters.AddWithValue("@Price", product.Price);
                        cmd.Parameters.AddWithValue("@ManufacturerId", product.ManufacturerId);
                        cmd.Parameters.AddWithValue("@StorekeeperId", product.StorekeeperId);
                        cmd.Parameters.AddWithValue("@InventoryNumber", product.Id);

                        cmd.ExecuteNonQuery();
                    }

                    connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка в ProductService Update\nException: " + ex.Message);
                    return false;
                }
                finally
                {
                    connection.Close();
                }
                return false;
            }
            return false;
        }
        public DataView ReadProductsArray()
        {
            using (connection = new SqlConnection(BD_Key))
            {
                connection.Open();

                string SelectQuery = string.Format(
                       "select * from Product"
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
        public DataView ReadProductsArray(string filter)
        {
            using (connection = new SqlConnection(BD_Key))
            {
                connection.Open();

                string SelectQuery = string.Format(
                       $"select * from Product order by Product.{filter}"
                       );

                using (SqlDataAdapter SDA = new SqlDataAdapter(SelectQuery, this.connection))
                {
                    try
                    {
                        DataSet DS = new DataSet();
                        SDA.Fill(DS);

                        return DS.Tables[0].DefaultView;
                    }
                    catch (Exception ex) { MessageBox.Show("Ошибка в ProductService ReadProductsArray(string filter)\nException: " + ex.Message); }
                }


                connection.Close();
            }
            return null;
        }
    }
}
