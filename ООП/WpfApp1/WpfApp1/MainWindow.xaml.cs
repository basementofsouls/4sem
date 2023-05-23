using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using System.IO;
using System.ComponentModel;
using Newtonsoft.Json.Linq;
using WpfApp1.UserControls;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class MyData : INotifyPropertyChanged
    {
        private int myValue;
        public int MyValue
        {
            get { return myValue; }
            set
            {
                if (myValue != value)
                {
                    myValue = value;
                    OnPropertyChanged(nameof(MyValue));
                }
            }
        }

        // Реализация интерфейса INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public partial class MainWindow : Window
    {
        private string path = "state.txt";
        private bool isToggle { get; set; }
       

        // Реализация интерфейса INotifyPropertyChanged
       
        public MainWindow()
        {
            InitializeComponent();
          
            toggle.IsChecked = isToggle;
            
        }
      
        private void button_add(object sender, RoutedEventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.Show();
        }

        private void button_show(object sender, RoutedEventArgs e)
        {
            AllProducts allProducts = new AllProducts();
            allProducts.Show();
            this.Close();
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
      
        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            isToggle = true;
            var uri = new Uri("DarkTheme.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
            
        }
       
        private void toggle_Unchecked(object sender, RoutedEventArgs e)
        {
            isToggle = false;
            var uri = new Uri("WhiteTheme.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
           
        }

        private void CustomButton_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void SearchButton_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void SearchButton_ClearClicked(object sender, RoutedEventArgs e)
        {
            ///
        }

        private void Input_TextInput(object sender, TextCompositionEventArgs e)
        {
            Input input = (Input)sender;
            if (Convert.ToInt32(Input.ValueProperty)  > 10)
            {
                input.BorderBrush = Brushes.Red;
            }
            else
            {
                input.BorderBrush = Brushes.Black ;
            }
        }
    }
      
}

