using WpfApp1.Class;
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
using System.Text.Json.Nodes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AllProducts.xaml
    /// </summary>
	 public interface ICommandk
		{
			void Delete(Product parameter);
			void Find(string parameter);
		}
public partial class AllProducts : Window,ICommandk
    {
		private Dictionary<string, Category> dictCategories = new Dictionary<string, Category>()
		{
			{ "Classic", Category.Classic },
			{ "0", Category.Classic },
			{ "Vegan", Category.Vegan },
			{ "1", Category.Vegan },
			{ "Spicy", Category.Spicy },
			{ "2", Category.Spicy },
		};
		
		public static ObservableCollection<Product> StateOld { get; set; }
		public bool isSort { get; set; }
		public static ObservableCollection<Product> Products { get; set; }
		public ObservableCollection<Category> MyCollections { get; set; }
		public AllProducts()
        {
            InitializeComponent();
			

			Products = DataFile.JsonDeseriazeProducts();
			StateOld = Products;
			DataContext = this;
            

        }

        private Stack<Product> _deletedItems = new Stack<Product>();
        private void delete_product(object sender, RoutedEventArgs e)
        {
            Product itemCopy = (Product)Choise.SelectedItem;
            _deletedItems.Push(itemCopy);
            if (Choise.SelectedItem == null)
			{
				MessageBox.Show("Выберете продукт");
			}
			else
			{
				Delete((Product)Choise.SelectedItem);
			}
            
          
        }

       

        private void edit_button(object sender, RoutedEventArgs e)
        {
			if (Choise.SelectedItem == null)
			{
				MessageBox.Show("Выберете продукт");
			}
			else
			{
				Product product = (Product)Choise.SelectedItem;
				Edit edit = new Edit(product);
				edit.Closing += Edit_Closing;
				edit.Show();
			}
		}
		private void Edit_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{

			Products = DataFile.JsonDeseriazeProducts();
			Choise.ItemsSource = Products;

		}

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

			Find(SearchTextBox.Text);

			
			
		}

        private void PriceSort(object sender, RoutedEventArgs e)
        {
			Raiting.Content = "По рейтингу";
			Name.Content = "По имени";
			if (isSort)
			{

				Price.Content = "По цене ↑";
				isSort = false;
				Choise.ItemsSource = Products.OrderBy(x => x.Price).ToList();
				StateOld = Products;

			}
			else
			{

				Price.Content = "По цене ↓";
				isSort = true;

				Choise.ItemsSource = Products.OrderByDescending(x => x.Price).ToList();
				StateOld = Products;

			}

		}

        private void NameSort(object sender, RoutedEventArgs e)
        {
			Raiting.Content = "По рейтингу";
			Price.Content = "По цене";
			if (isSort)
			{

				Name.Content = "По имени ↑";
				isSort = false;
				Choise.ItemsSource = Products.OrderBy(x => x.Name).ToList();
				StateOld = Products;
			}
			else
			{

				Name.Content = "По имени ↓";
				isSort = true;
				Choise.ItemsSource = Products.OrderByDescending(x => x.Name).ToList();
				StateOld = Products;

			}
		}
	
		private void RatingSort(object sender, RoutedEventArgs e)
        {
			Price.Content = "По цене";
			Name.Content = "По имени";
			if (isSort)
			{

				Raiting.Content = "По рейтингу ↑";
				isSort = false;
				Choise.ItemsSource = Products.OrderBy(x => x.Rating).ToList();
				StateOld = Products;
			}
			else
			{

				Raiting.Content = "По рейтингу ↓";
				isSort = true;
				Choise.ItemsSource = Products.OrderByDescending(x => x.Rating).ToList();
				StateOld = Products;

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

        private void Back_button(object sender, RoutedEventArgs e)
        {
			MainWindow mainWindow = new MainWindow();
			mainWindow.Show();
			this.Close();
		}

        public void Delete(Product parameter)
        {
			Products.Remove(parameter);
			DataFile.JsonSerializeProductsCollection(Products);
			MessageBox.Show("Продукт удален", "Успешно!", MessageBoxButton.OK);
		}

        public void Find(string parameter)
        {
			ObservableCollection<Product> testProduct = new ObservableCollection<Product>();
			foreach (Product el in Products)
			{

				if (el.Name.ToLower() == parameter.ToLower())
				{
					testProduct.Add(el);

				}
				else if (el.Name.ToLower().Contains(parameter.ToLower()))
				{
					testProduct.Add(el);
				}

			}
			Choise.ItemsSource = testProduct;
		}

        private void undo(object sender, RoutedEventArgs e)
        {
            if (_deletedItems.Count > 0)
            {
                Product item = _deletedItems.Pop();
                
                Products.Add(item);
				// Восстанавливаем элемент в коллекцию
				DataFile.JsonSerializeProducts(item);

            }
        }
    }


}
