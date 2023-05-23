using WpfApp1.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using System.Globalization;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        private OpenFileDialog openFileDialog;
        public ObservableCollection<Category> MyCollections = new ObservableCollection<Category>(Enum.GetValues(typeof(Category)).Cast<Category>());
        public ObservableCollection<Product> Products { get; set; }

        private string ID { get; set; }
        private Dictionary<string, Class.Category> dictCategories = new Dictionary<string, Category>()
        {
            { "Classic", Category.Classic },
            { "Vegan", Category.Vegan },
            { "Spicy", Category.Spicy }
        };
        public Edit(Product product)
        {
            InitializeComponent();
            Name_product.Text = product.Name;
            Description_product.Text = product.Description;
            Price_product.Text = product.Price.ToString();
            Rating_product.Text = product.Rating.ToString();
            product_Image.Source = new BitmapImage(new Uri(product.Img));
            product.Category = dictCategories[product.Category.ToString()];
            Category_product.Text = product.Category.ToString();
            ID = product.Id;

            DataContext = this;
        }

        private void Clean(object sender, RoutedEventArgs e)
        {
            Name_product.Text = "";
            Description_product.Text = "";
            Price_product.Text = "";
            Rating_product.Text = "";
            product_Image.Source = null;
        }

        private void load_Image(object sender, RoutedEventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image|*.jpg;*.jpeg;*.png;";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    product_Image.Source = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute));

                }
                catch
                {
                    MessageBox.Show("Выберите файл подходящего формата.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = Name_product.Text;
                string description = Description_product.Text;

                float price = (float)Convert.ToDecimal(Price_product.Text);

                int raiting = Convert.ToInt32(Rating_product.Text);

                string img = product_Image.Source.ToString();


                if (name.Length == 0)
                {
                    throw new Exception("Введите имя");

                }
                else if (price < 1)
                {
                    throw new Exception("Некорректная цена");

                }
                else if (description.Length == 0)
                {
                    throw new Exception("Введите описание");

                }
                else if (raiting == 0 || raiting > 10 || raiting < 0)
                {
                    throw new Exception("Введите диапазон значений от 1 до 10");
                }

                else if (img == null)
                {
                    throw new Exception("Загрузите фотографию");
                }
                else
                {
                    Products = DataFile.JsonDeseriazeProducts();

                    foreach (Product p in Products)
                    {
                        if (ID == p.Id)
                        {
                            p.Name = name;
                            p.Description = description;
                            p.Price = price;
                            p.Rating = raiting;
                            p.Category = dictCategories[Category_product.Text];
                            p.Img = img;

                        }

                    }

                    DataFile.JsonSerializeProductsCollection(Products);

                    MessageBox.Show("Данные были изменены");


                    this.Close();

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button_rus(object sender, RoutedEventArgs e)
        {
            var culture = CultureInfo.CurrentCulture;


            var dictionary = new ResourceDictionary();

            dictionary.Source = new Uri("RU.xaml", UriKind.Relative);

            Resources.MergedDictionaries.Add(dictionary);

        }

        private void button_eng(object sender, RoutedEventArgs e)
        {

            var culture = CultureInfo.CurrentCulture;

            var dictionary = new ResourceDictionary();

            dictionary.Source = new Uri("ENG.xaml", UriKind.Relative);

            Resources.MergedDictionaries.Add(dictionary);
        }
    }
}
