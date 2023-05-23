using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WpfApp1.Class;

namespace WpfApp1.UserControls
{
    /// <summary>
    /// Логика взаимодействия для Input.xaml
    /// </summary>

    public partial class Input : UserControl
    {
        public Input()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                "Value",
                typeof(int),
                typeof(Input),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    ValuePropertyChanged,
                    ValueCoerce));

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        private static void ValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Обработка события изменения значения свойства


            Input input = (Input)d;
            int newValue = (int)e.NewValue;

            if (newValue > 10)
            {

                input.BorderBrush = Brushes.Red;
            }
            else
            {

                input.BorderBrush = Brushes.Black;
            }
        }

        private static object ValueCoerce(DependencyObject d, object baseValue)
        {
            // Обработка приведения значения свойства
            // Здесь можно выполнить нужные преобразования значения, если требуется

            // Пример приведения значения к диапазону от 0 до 100
            int value = (int)baseValue;
            if (value < 0)
            {
                return 0;
            }
            else if (value > 100)
            {
                return 100;
            }

            return baseValue;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NumericTextBox numericText = new NumericTextBox();

            MessageBox.Show(numericText.Name.ToString());
        }

        private void numericTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            

           

        }
    }
}
