using LR8v8.Functions;
using LR8v8.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace LR8v8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SqlConnection connection;

            string BD_Key = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            string createTablesScript = "use Samsonik; create table Manufacturer( Id int IDENTITY(1,1) PRIMARY KEY, organization nvarchar(100), country nvarchar(100), address nvarchar(100), phone int, );  create table Storekeeper(Id int IDENTITY(1,1) PRIMARY KEY, Experience int, FIO nvarchar(100), Adress nvarchar(100), );  create table Product( InventoryNumber int IDENTITY(1,1) PRIMARY KEY,   Image varbinary(MAX), Name varchar(100) , Size int,  Weight int, Type varchar(100), Date date, Amount int,  Price int,  ManufacturerId int REFERENCES Manufacturer (Id), StorekeeperId int REFERENCES Storekeeper (Id), );";
            string createDatabaseScript = "CREATE DATABASE Samsonik";

            using (connection = new SqlConnection(BD_Key))
            {
                try
                {
                    // Открытие подключения
                    connection.Open();
                    MessageBox.Show("Подключение к базе данных успешно установлено.");
                }
                catch (SqlException)
                {
                    // Если произошла ошибка подключения (база данных не найдена), создаем базу данных
                    using (SqlConnection masterConnection = new SqlConnection("Data Source=DOLLOF-CTHULHU;Initial Catalog=master;Integrated Security=True"))
                    {
                        masterConnection.Open();

                        using (SqlCommand command = new SqlCommand(createDatabaseScript, masterConnection))
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("База данных успешно создана.");
                        }
                    }
                    using (SqlConnection masterConnection = new SqlConnection(BD_Key))
                    {
                        masterConnection.Open();

                        using (SqlCommand command = new SqlCommand(createTablesScript, masterConnection))
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Таблицы созданны.");
                        }
                    }
                }
            }
        }

        #region PageProduct
        public ObservableCollection<Product> ProductList { get; set; }
        private ProductService productService = new ProductService();
        private Product product = new Product();
        private int editId;
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                product.Date = DateTime.Parse(DatePickerDate.Text);
            }
            catch { }
            if (productService.Create(product))
            {
                
            }
        }
        private void TextBoxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                product.Name = TextBoxName.Text;
            }
            catch(Exception ex) { }
        }
        private void TextBoxPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                product.Price = Convert.ToInt32(TextBoxPrice.Text);
            }
            catch(Exception ex) { TextBoxPrice.Text = ""; }
        }
        private void TextBoxAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                product.Amount = Convert.ToInt32(TextBoxAmount.Text);
            }
            catch (Exception ex) { TextBoxAmount.Text = ""; }
        }
        private void TextBoxManufacturer_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                product.ManufacturerId = Convert.ToInt32(TextBoxManufacturer.Text);
            }
            catch (Exception ex) { TextBoxManufacturer.Text = ""; }
        }
        private void TextBoxStorekeeper_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                product.StorekeeperId = Convert.ToInt32(TextBoxStorekeeper.Text);
            }
            catch (Exception ex) { TextBoxStorekeeper.Text = ""; }
        }
        private void TextBoxSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                product.Size = Convert.ToInt32(TextBoxSize.Text);
            }
            catch (Exception ex) { TextBoxSize.Text = ""; }
        }
        private void TextBoxWeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                product.Weight = Convert.ToInt32(TextBoxWeight.Text);
            }
            catch (Exception ex) { TextBoxWeight.Text = ""; }
        }
        private void TextBoxType_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                product.Type = TextBoxType.Text;
            }
            catch (Exception ex) { TextBoxWeight.Text = ""; }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                ButtonImaheImageBrush.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName));
                product.Image = File.ReadAllBytes(openFileDialog.FileName);
            }
        }
        private void TextBoxEditId_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                editId = Convert.ToInt32(TextBoxEditId.Text);
                product.Id = editId;
            }
            catch (Exception ex) { TextBoxEditId.Text = ""; }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (productService.Delete(editId)) { }
        }
        private void ButtonEditProduct_Click(object sender, RoutedEventArgs e)
        {
            try{product.Date = DateTime.Parse(DatePickerDate.Text);}
            catch { }
            if (productService.Update(product)) { }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ProductList = new ObservableCollection<Product>
            (
            productService
            .ReadProductsArray()
            .Cast<DataRowView>()
            .ToList()
            .Select
                (t =>
                    new Product
                    ()
                    {
                        Id = Convert.ToInt32(t["InventoryNumber"]),
                        Name = Convert.ToString(t["Name"]),
                        Amount = Convert.ToInt32(t["Amount"]),
                        Price = Convert.ToInt32(t["Price"]),
                        Type = Convert.ToString(t["Type"]),
                        Date = (DateTime)t["Date"],
                        Weight = Convert.ToInt32(t["Weight"]),
                        Size = Convert.ToInt32(t["Size"]),
                        Image = (byte[])t["Image"],
                        ManufacturerId = Convert.ToInt32(t["ManufacturerId"]),
                        StorekeeperId = Convert.ToInt32(t["StorekeeperId"]),
                    }
                )
            .OrderBy(item => item.Id)
            );
            
            ProductListBox.ItemsSource = ProductList;
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
                ProductList = new ObservableCollection<Product>
                (
                productService
                .ReadProductsArray()
                .Cast<DataRowView>()
                .ToList()
                .Select
                    (t =>
                        new Product
                        ()
                        {
                            Id = Convert.ToInt32(t["InventoryNumber"]),
                            Name = Convert.ToString(t["Name"]),
                            Amount = Convert.ToInt32(t["Amount"]),
                            Price = Convert.ToInt32(t["Price"]),
                            Type = Convert.ToString(t["Type"]),
                            Date = (DateTime)t["Date"],
                            Weight = Convert.ToInt32(t["Weight"]),
                            Size = Convert.ToInt32(t["Size"]),
                            Image = (byte[])t["Image"],
                            ManufacturerId = Convert.ToInt32(t["ManufacturerId"]),
                            StorekeeperId = Convert.ToInt32(t["StorekeeperId"]),
                        }
                    )
                .OrderBy(item => item.Price)
                );
            ProductListBox.ItemsSource = ProductList;
        }
        private void Button_Click_Show(object sender, RoutedEventArgs e)
        {
            show();
        }

        public void show()
        {
            ProductList = new ObservableCollection<Product>
                (
                productService
                .ReadProductsArray()
                .Cast<DataRowView>()
                .ToList()
                .Select
                    (t =>
                        new Product
                        ()
                        {
                            Id = Convert.ToInt32(t["InventoryNumber"]),
                            Name = Convert.ToString(t["Name"]),
                            Amount = Convert.ToInt32(t["Amount"]),
                            Price = Convert.ToInt32(t["Price"]),
                            Type = Convert.ToString(t["Type"]),
                            Date = (DateTime)t["Date"],
                            Weight = Convert.ToInt32(t["Weight"]),
                            Size = Convert.ToInt32(t["Size"]),
                            Image = (byte[])t["Image"],
                            ManufacturerId = Convert.ToInt32(t["ManufacturerId"]),
                            StorekeeperId = Convert.ToInt32(t["StorekeeperId"]),
                        }
                    )
                );
            ProductListBox.ItemsSource = ProductList;
        }
        #endregion

        #region PageManufaturer

        private ManufacturerService manufacturerService = new ManufacturerService();
        private Manufacturer manufacturer = new Manufacturer();
        private int manufacturerID;

        private void TextBoxOrganization_TextChanged(object sender, TextChangedEventArgs e)
        {
            manufacturer.Organization = TextBoxOrganization.Text;
        }
        private void TextBoxCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            manufacturer.Country = TextBoxCity.Text;
        }
        private void TextBoxAdress_TextChanged(object sender, TextChangedEventArgs e)
        {
            manufacturer.Adress= TextBoxAdress.Text;
        }
        private void TextBoxPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                manufacturer.phone = Convert.ToInt32(TextBoxPhone.Text);
            }
            catch { TextBoxPhone.Text = ""; };
        }
        private void ButtonAddManufacturer_Click(object sender, RoutedEventArgs e)
        {
            if (manufacturerService.Create(manufacturer))
                DataGridManufacturer.ItemsSource = manufacturerService.ReadArray();
        }
        private void TextBoxManufacturerId_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                manufacturerID = Convert.ToInt32(TextBoxManufacturerId.Text);
                manufacturer.Id = manufacturerID;
            }
            catch { TextBoxManufacturerId.Text = ""; };
        }
        private void ButtonEditManufacturer_Click(object sender, RoutedEventArgs e)
        {
            if(manufacturerService.Update(manufacturer))
                DataGridManufacturer.ItemsSource = manufacturerService.ReadArray();
        }
        private void ButtonDeleteManufacturer_Click(object sender, RoutedEventArgs e)
        {
            if(manufacturerService.Delete(manufacturerID))
                DataGridManufacturer.ItemsSource = manufacturerService.ReadArray();
        }
        private void ButtonWatchManufacturers_Click(object sender, RoutedEventArgs e)
        {
            DataGridManufacturer.ItemsSource = manufacturerService.ReadArray();
        }
        #endregion

        #region PageStorekeeper
        private StorekeeperService StorekeeperService = new StorekeeperService();
        private Storekeeper storekeeper = new Storekeeper();
        private void TextBoxFIO_TextChanged(object sender, TextChangedEventArgs e)
        {
            storekeeper.FIO = TextBoxFIO.Text;
        }

        private void TextBoxAdressSrorekeeper_TextChanged(object sender, TextChangedEventArgs e)
        {
            storekeeper.Adress = TextBoxAdressSrorekeeper.Text;
        }

        private void TextBoxExperience_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                storekeeper.Experience = Convert.ToInt32(TextBoxExperience.Text);
            }
            catch { TextBoxExperience.Text = ""; };
        }

        private void ButtonAddStorekeeper_Click(object sender, RoutedEventArgs e)
        {
            if (StorekeeperService.Create(storekeeper))
                DataGridStorekeeperr.ItemsSource = StorekeeperService.ReadArray();
        }

        private void TextBoxStorekeeperId_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                storekeeper.Id = Convert.ToInt32(TextBoxStorekeeperId.Text);
            }
            catch { TextBoxStorekeeperId.Text = ""; };
        }

        private void ButtonEditStorekeeper_Click(object sender, RoutedEventArgs e)
        {
            if (StorekeeperService.Update(storekeeper))
                DataGridStorekeeperr.ItemsSource = StorekeeperService.ReadArray();
        }

        private void ButtonDeleteStorekeeper_Click(object sender, RoutedEventArgs e)
        {
            if (StorekeeperService.Delete(storekeeper.Id))
                DataGridStorekeeperr.ItemsSource = StorekeeperService.ReadArray();
        }
        private void ButtonWatchStorekeepers_Click(object sender, RoutedEventArgs e)
        {
            DataGridStorekeeperr.ItemsSource = StorekeeperService.ReadArray();
        }

        #endregion

        #region PageЗапрос
        private CustomQueryService customQueryService = new CustomQueryService();
        private string query;
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            query = CustomQuery.Text;
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (customQueryService.Query(query))
                MessageBox.Show("Запрос выполнен успешно");
        }

        #endregion

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=DOLLOF-CTHULHU;Initial Catalog=Samsonik;Integrated Security=True";

            // Имя хранимой процедуры
            //string storedProcedureName = "DeleteProductsByEvenId";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("DeleteProductsByEvenId", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Продукты с четным ID успешно удалены.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении продуктов: " + ex.Message);
            }
        }
    }
}
