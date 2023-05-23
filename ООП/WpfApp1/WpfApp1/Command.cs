using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using WpfApp1.Class;

namespace WpfApp1
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }

    public class MyViewModel
    {
        public MyViewModel()
        {
            Products = new ObservableCollection<Product>();
            LoadData();
            MyCommand = new RelayCommand(ExecuteMyCommand, CanExecuteMyCommand);
           
        }

        public ObservableCollection<Product> Products { get; set; }

        public ICommand MyCommand { get; }

        private void LoadData()
        {
            DataFile.JsonSerializeProductsCollection(Products);
        }

        public void ExecuteMyCommand(object parameter)
        {
            if (parameter is Product product)
            {
                Products.Remove(product);
                SaveData();
                MessageBox.Show("Продукт удален", "Успешно!", MessageBoxButton.OK);
            }
        }

        private bool CanExecuteMyCommand(object parameter)
        {
            return true;
        }

        private void SaveData()
        {
            DataFile.JsonSerializeProductsCollection(Products);
        }
    }

}
