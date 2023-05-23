using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using WpfApp1.Class;
using Newtonsoft.Json;
using System.Globalization;


namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        private OpenFileDialog openFileDialog;
        public ObservableCollection<Category> MyCollections { get; } = new ObservableCollection<Category>(Enum.GetValues(typeof(Category)).Cast<Category>());
		public Dictionary<string, Class.Category> dictCategories = new Dictionary<string, Class.Category>()
		{
			{ "Classic", Class.Category.Classic },
			{ "Vegan", Class.Category.Vegan },
			{ "Spicy", Class.Category.Spicy }
		};
		public AddProduct()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void loadimage(object sender, RoutedEventArgs e)
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

        private void Click_Save(object sender, RoutedEventArgs e)
        {
			try
			{
				string name = textBox_Name.Text;
				string description = textBox_Description.Text;

				float price = (float)Convert.ToDecimal(textBox_Price.Text);

				int raiting = Convert.ToInt32(textBox_Rating.Text);

				string img = product_Image.Source.ToString();

				if (name.Length == 0)
				{
					throw new Exception("Введите имя");
				}
				else if(price < 1)
                {
					throw new Exception("Некорректно введена цена");
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
					Product product = new Product();
					product.Name = name;
					product.Description = description;
					product.Price = price;
					product.Img = img;
					product.Rating = raiting;
					product.Count = 1;
					product.Category = dictCategories[Category_product.Text];

					DataFile.JsonSerializeProducts(product);

					MessageBox.Show(product.ToString());

					this.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

        private void Clean(object sender, RoutedEventArgs e)
        {
			textBox_Name.Text = "";
			textBox_Description.Text = "";
			textBox_Price.Text = "";
			textBox_Rating.Text = "";
			product_Image.Source = null;
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

			// Устанавливаем язык приложения
			var dictionary = new ResourceDictionary();

			dictionary.Source = new Uri("ENG.xaml", UriKind.Relative);

			Resources.MergedDictionaries.Add(dictionary);
		}

        private void clean_button_MouseUp(object sender, MouseButtonEventArgs e)
        {
			clean_button.Background = Brushes.Red; 
        }
    }
	
	}
