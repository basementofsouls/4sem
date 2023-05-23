﻿using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public List<Good> goods_ = new List<Good>();
        private Good _good;
        private Producer _producer;
        public Form1(Good good, Producer producer)
        {
            InitializeComponent();
            _good = good;
            _producer = producer;
            using (var fs = new StreamReader("good.json"))
            {
               
                while (!fs.EndOfStream)
                {
                    var json = fs.ReadLine();

                    var good_ = JsonConvert.DeserializeObject<Good>(json);

                    goods_.Add(good_);
                }
            }


            toolStripStatusLabel2.Text = "Запуск приложения";
        }

               
        

     
        private void hScrollBarSize_Scroll_Scroll(object sender, ScrollEventArgs e)
        {
            switch ((int)(hScrollBarSize_Scroll.Value / 20))
            {
                case 0:
                    Размер.Text = "Размер товара: мал.";
                    _good.Sizes = Good.GoodSizes.Small;
                    break;
                case 1:
                    Размер.Text = "Размер товара: средн.";
                    _good.Sizes = Good.GoodSizes.Average;
                    break;
                case 2:
                    Размер.Text = "Размер товара: больш.";
                    _good.Sizes = Good.GoodSizes.Big;
                    break;
                case 3:
                    Размер.Text = "Размер товара: очень больш.";
                    _good.Sizes = Good.GoodSizes.VeryBig;
                    break;
                case 4:
                    Размер.Text = "Размер товара: огромн.";
                    _good.Sizes = Good.GoodSizes.Huge;
                    break;
            }
        }

        private void groupBoxType_Leave(object sender, EventArgs e)
        {
            if (radioButtonFood.Checked)
            {
                _good.Type = Good.Types.Food;
            }
            if (radioButtonClothes.Checked)
            {
                _good.Type = Good.Types.Clothes;
            }
            if (radioButtonService.Checked)
            {
                _good.Type = Good.Types.Service;
            }
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value <= DateTime.Now)
            {
                _good.DateTime = dateTimePicker1.Value;
            }
            else { MessageBox.Show("Check Date"); }
        }

    

   




         private bool Save()
        {
            try
            {
                
                using (var fs = new StreamWriter("producer.json", true))
                {
                    var json = JsonConvert.SerializeObject(_producer);
                    fs.WriteLine(json);
                }
                _producer = new Producer();
               
                using (var fs = new StreamWriter("good.json", true))
                {
                    var json = JsonConvert.SerializeObject(_good);
                    fs.WriteLine(json);
                }
                _good = new Good();

               

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return false;
            }
        }

        private void buttonSaveClick(object sender, EventArgs e)
        {
            try
            {
                Good myClass = new Good();


                ValidationContext context = new ValidationContext(myClass, null, null);
                try
                {
                    Validator.ValidateObject(myClass, context, true);
                }
                catch (ValidationException ex)
                {
                    MessageBox.Show("Возникла ошибка: " + ex.Message);

                }
                try
                {
                    myClass.Num = Convert.ToInt32(textBoxNum.Text);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Возникла ошибка: " + ex.Message);

                }
                if (textBoxName.Text == null)
                {
                    throw new Exception("Поля не заполнены");
                }
                try
                {
                    _good.Count = Convert.ToInt32(textBoxCount.Text);
                    if (_good.Count < 1)
                    {
                        throw new Exception("Количество не может быть 0 или меньше нуля");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                try
                {
                    _good.Price = Convert.ToInt32(textBoxPrice.Text);
                    if(_good.Price < 1)
                    {
                        throw new Exception("Цена не может быть 0 или отрицательной");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                try
                {
                    _good.Weight = Convert.ToInt32(textBoxWeight.Text);
                    if(_good.Weight < 0)
                    {
                        throw new Exception("Вес не может быть отрицательным");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                _good.Producer = textBoxProducer.Text;
                _good.Name = textBoxName.Text;
                _good.Num = Convert.ToInt32(textBoxNum.Text);
                _producer.Address = textBoxAddress.Text;
                    _producer.Country = textBoxCountry.Text;
                _producer.Organization = textBoxOrganization.Text;
               
                if (ValidateChildren())
                {

                    if (Save())
                    {
                        MessageBox.Show("Валидация прошла успешно.");
                      
                        toolStripStatusLabel2.Text = "Данные сохранены";
                    }
                    else
                    {
                        MessageBox.Show("Данные не введены или введены неверно");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            try
            {
                List<Good> goods_ = new List<Good>();
                List<Producer> producers_ = new List<Producer>();


                using (var fs = new StreamReader("good.json"))
                {

                    while (!fs.EndOfStream)
                    {
                        var json = fs.ReadLine();

                        var good_ = JsonConvert.DeserializeObject<Good>(json);
                        richTextBox.Text += good_.ToString();
                        goods_.Add(good_);
                    }
                    //foreach (var el in goods_)
                    //{
                        
                    //    richTextBox.AppendText(el.Name.ToString());
                    //    richTextBox.AppendText(el.Type.ToString());
                    //    richTextBox.AppendText(el.Price.ToString());
                    //}
                }
                

                using (var fs = new StreamReader("producer.json"))
                {

                    while (!fs.EndOfStream)
                    {
                        var json = fs.ReadLine();

                        var producer_ = JsonConvert.DeserializeObject<Producer>(json);
                        //richTextBox.Text += producer_.ToString();
                        producers_.Add(producer_);
                    }
                  
                }


                toolStripStatusLabel2.Text = "Вывод данных";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                toolStripStatusLabel2.Text = "Попытка вывода данных";
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 search = new Form2();
            search.Show();
        }

        private void dateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Text = "";
            var query = from el in goods_
                        orderby el.DateTime
                        select el;
            foreach(var el in query)
            {
                richTextBox.Text += el.ToString();
            }
        }

        private void nameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox.Text = "";
            var query = from el in goods_
                        orderby el.Name
                        select el;
            foreach (var el in query)
            {
                richTextBox.Text += el.ToString();
            }
        }

        private void pricesortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Text = "";
            var query = from el in goods_
                        orderby el.Price
                        select el;
            foreach (var el in query)
            {
                richTextBox.Text += el.ToString();
            }
        }

        private void aboutProgrammToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Разработчик: Самсоник А.И.");
        }

        private void labelSize_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void validatebutton_Click(object sender, EventArgs e)
        {

           
        }
    }
   
}
