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

namespace WpfApp1.UserControls
{
    /// <summary>
    /// Логика взаимодействия для SearchButton.xaml
    /// </summary>
    public partial class SearchButton : UserControl
    {
        public static readonly RoutedEvent ClearClickedEvent = EventManager.RegisterRoutedEvent(
            "ClearClicked",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(SearchButton));

        public event RoutedEventHandler ClearClicked
        {
            add { AddHandler(ClearClickedEvent, value); }
            remove { RemoveHandler(ClearClickedEvent, value); }
        }
        private void RaiseClearClickedEvent()
        {
            RoutedEventArgs args = new RoutedEventArgs(ClearClickedEvent);
            RaiseEvent(args);
        }
        public SearchButton()
        {
            InitializeComponent();
        }








        private void Button_Click(object sender, RoutedEventArgs e)
        {
            text.Text = "";
            RaiseClearClickedEvent();
        }

        private void text_TextChanged(object sender, TextChangedEventArgs e)
        {
            // обработка изменений текста
        }

       
    }
}
