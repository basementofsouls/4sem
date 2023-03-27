using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Text.Json;
using Newtonsoft.Json;

namespace WindowsFormsApp2
{

	public partial class Form2 : Form
	{
		
		public List<string> textbox = new List<string>();
		public List<Good> goods_ = new List<Good>();
		public Form2()
		{
			InitializeComponent();

			using (var fs = new StreamReader("good.json"))
			{

				while (!fs.EndOfStream)
				{
					var json = fs.ReadLine();

					var good_ = JsonConvert.DeserializeObject<Good>(json);

					goods_.Add(good_);
				}


			}

			PriceSearch1.Text = "0";
			PriceSearch2.Text = "0";
		}

		private void Find_Click(object sender, EventArgs e)
		{

			string name = NameSearch.Text;
			string type = TypeSearch.Text;
			int price1 = int.Parse(PriceSearch1.Text);
			int price2 = int.Parse(PriceSearch2.Text);
			//регурялное выражение для ввода букв и цифп
			Regex regex = new Regex(@"^[a-zA-Z0-9]+$");



			SearchTextBox.Text = "";
			if (name != "" && type == "" && price1 == 0 && price2 == 0)
			{


				var query = from el in goods_
							where el.Name.Contains(name)
							select el;
				foreach (var el in query)
				{
					SearchTextBox.Text += el.ToString();
				}
				using (var fs = new StreamWriter("search.json", true))
				{
					foreach (var el in query)
					{
						var json = JsonConvert.SerializeObject(el);
						fs.WriteLine(json);

					}
				}
			}
			else if (name == "" && type != "" && regex.IsMatch(type) && price1 == 0 && price2 == 0)
			{
				var query = from el in goods_
							where (int)el.Type == int.Parse(type)
							select el;

				foreach (var el in query)
				{
					SearchTextBox.Text += el.ToString();
				}
				using (var fs = new StreamWriter("search.json", true))
				{
					foreach (var el in query)
					{
						var json = JsonConvert.SerializeObject(el);
						fs.WriteLine(json);

					}
				}


			}
			else if (name == "" && type == "" && price1 != 0 && price2 != 0)
			{
				var query = from el in goods_
							where el.Price >= price1 && el.Price <= price2
							select el;
				foreach (var el in query)
				{
					SearchTextBox.Text += el.ToString();
				}
				using (var fs = new StreamWriter("search.json", true))
				{
					foreach (var el in query)
					{
						var json = JsonConvert.SerializeObject(el);
						fs.WriteLine(json);

					}
				}

			}
			else if (name != "" && type != "" && regex.IsMatch(type) && regex.IsMatch(name) && price1 == 0 && price2 == 0)
			{
				var query = from el in goods_
							where (int)el.Type == int.Parse(type) && el.Name.Contains(name)
							select el;

				foreach (var el in query)
				{
					SearchTextBox.Text += el.ToString();
				}

				using (var fs = new StreamWriter("search.json", true))
				{
					foreach (var el in query)
					{
						var json = JsonConvert.SerializeObject(el);
						fs.WriteLine(json);

					}
				}


			}
			else if (name != "" && type != "" && regex.IsMatch(type) && regex.IsMatch(name) && price2 != 0)
			{
				var query = from el in goods_
							where (int)el.Type == int.Parse(type) && el.Name.Contains(name) && el.Price >= price1 && el.Price <= price2
							select el;

				foreach (var el in query)
				{
					SearchTextBox.Text += el.ToString();
				}

				using (var fs = new StreamWriter("search.json", true))
				{
					foreach (var el in query)
					{
						var json = JsonConvert.SerializeObject(el);
						fs.WriteLine(json);

					}
				}


			}
			else if (name != "" && type == "" && regex.IsMatch(name) && price2 != 0)
			{
				var query = from el in goods_
							where el.Name.Contains(name) && el.Price >= price1 && el.Price <= price2
							select el;

				foreach (var el in query)
				{
					SearchTextBox.Text += el.ToString();
				}

				using (var fs = new StreamWriter("search.json", true))
				{
					foreach (var el in query)
					{
						var json = JsonConvert.SerializeObject(el);
						fs.WriteLine(json);

					}
				}


			}
			else if (name == "" && type != "" && regex.IsMatch(type) && price2 != 0)
			{
				var query = from el in goods_
							where (int)el.Type == int.Parse(type) && el.Price >= price1 && el.Price <= price2
							select el;

				foreach (var el in query)
				{
					SearchTextBox.Text += el.ToString();
				}

				using (var fs = new StreamWriter("search.json", true))
				{
					foreach (var el in query)
					{
						var json = JsonConvert.SerializeObject(el);
						fs.WriteLine(json);

					}
				}


			}
			else
			{
				MessageBox.Show("Неверный ввод");


			}
			if(SearchTextBox.Text != "")textbox.Add(SearchTextBox.Text);
			
		}
		
		private void Clear_Click(object sender, EventArgs e)
		{
			SearchTextBox.Clear();
		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void TypeSearch_Validating(object sender, CancelEventArgs e)
		{
			if (!TypeSearch.Text.Contains('2') && !TypeSearch.Text.Contains('1') && !TypeSearch.Text.Contains('0'))
			{

				errorProviderApp.SetError(TypeSearch, "Тип может быть только 0, 1 или 2");

				e.Cancel = true;

			}
			if (TypeSearch.Text == "") e.Cancel = false;
		}

		private void TypeSearch_Validated(object sender, EventArgs e)
		{
			errorProviderApp.SetError(TypeSearch, "");
		}



		private void backbutton_Click(object sender, EventArgs e)
		{
			if(SearchTextBox.Text == "")
            {
				try
				{
					SearchTextBox.Text = textbox.Last();
				}
				catch(Exception ex)
                {
					MessageBox.Show(ex.Message);
                }
            }

			try
			{
				SearchTextBox.Text = textbox[textbox.LastIndexOf(SearchTextBox.Text) - 1];
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

        private void nextbutton_Click(object sender, EventArgs e)
        {
			if (SearchTextBox.Text == "")
			{
				try
				{
					SearchTextBox.Text = textbox.Last();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
			try
			{
				SearchTextBox.Text = textbox[textbox.LastIndexOf(SearchTextBox.Text) + 1];
			}
			catch(Exception ex)
            {
				MessageBox.Show(ex.Message);
            }
		}
    }
}
