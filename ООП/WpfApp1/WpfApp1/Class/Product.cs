using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;

namespace WpfApp1.Class
{
    public class Product
    {
        #region Fields

        private string _id;
        private string _name;
        private string _description;
        private string _img;
        private float _price;
        private int _count;
        private int _rating;

        #endregion Fields

        #region Properties

        public Category Category { get; set; }

        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set { _description = value; }
        }

        public string Img
        {
            get
            {
                return _img;
            }
            set
            {
                _img = value;
            }
        }

        public float Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
            }
        }

        public int Rating
        {
            get
            {
                return _rating;
            }
            set
            {
                _rating = value;
            }
        }

        #endregion Properties

        #region Constructor

        public Product(string name, string description, string img, float price, int count, int rating, Category category)
        {
            Name = name;
            Description = description;
            Img = img;
            Price = price;
            Count = count;
            Rating = rating;
            Category = category;
        }

        public Product()
        {
            Id = Guid.NewGuid().ToString();
            Name = "No name";
            Description = "No description";
            Img = "No img";
            Price = 0;
            Count = 0;
            Rating = 0;
            Category = Category.Classic;
        }

        #endregion Constructor

        #region Methods

        public override string ToString()
        {
            return $"Id: {Id} \n" +
                    $"Name: {Name} \n" +
                    $"Description: {Description} \n" +
                    $"Img: {Img} \n" +
                    $"Price: {Price} \n" +
                    $"Count: {Count} \n" +
                    $"Category {Category}\n" +
                    $"Rating: {Rating} \n";
        }

        #endregion Methods
       
    }

    public enum Category
    {
        Classic,
        Vegan,
        Spicy
    }


    static class Products
    {

        public static ObservableCollection<Product> products = new ObservableCollection<Product>();

        public static void AddProduct(Product product)
        {
            products.Add(product);
        }

        public static void RemoveProduct(Product product)
        {
            products.Remove(product);
        }
        public static void ShowProducts()
        {
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
       

    }

}
