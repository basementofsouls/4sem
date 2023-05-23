using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json;
using System.Collections.ObjectModel;
using System.IO;

namespace WpfApp1.Class
{
	public static class DataFile
	{
		private static string _path = "products.json";

        public static List<Product> productList { get; set; } = new List<Product>();

        public static void AddProduct(Product product)
        {
            productList.Add(product);
            using (var sw = new StreamWriter(_path, true))
            {
                var jsonProduct = JsonConvert.SerializeObject(product);
                sw.WriteLine(jsonProduct);
            }
        }
        public static void JsonSerializeProducts(Product product)
		{
			using (var sw = new StreamWriter(_path, true))
			{
				var jsonProduct = JsonConvert.SerializeObject(product);
				sw.WriteLine(jsonProduct);
			}
		}

		public static void JsonSerializeProductsCollection(ObservableCollection<Product> products)
		{
			using (var sw = new StreamWriter(_path))
			{
				foreach (var el in products)
				{
					var json = JsonConvert.SerializeObject(el);
					sw.WriteLine(json);
				}
			}
		}

		public static ObservableCollection<Product> JsonDeseriazeProducts()
		{
			var products = new ObservableCollection<Product>();

			using (var sr = new StreamReader(_path))
			{
				while (!sr.EndOfStream)
				{
					var jsonProduct = sr.ReadLine();
					var product = JsonConvert.DeserializeObject<Product>(jsonProduct);
					products.Add(product);
				}
			}
			return products;
		}
        public static void RemoveProduct(Product prod)
        {
            productList.Remove(prod);
        }
    }
}
