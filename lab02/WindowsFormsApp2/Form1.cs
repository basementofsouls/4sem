using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;



namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private Good _good;
        private Producer _producer;
        public Form1(Good good, Producer producer)
        {
            InitializeComponent();
            _good = good;
            _producer = producer;

           

        }

        private void textBoxName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                errorProviderApp.SetError(textBoxName, "Name should not be left blank!");

                e.Cancel = true;
                textBoxName.Select(0, textBoxName.Text.Length);
            }
        }

        private void textBoxName_Validated(object sender, EventArgs e)
        {
            _good.Name = textBoxName.Text;

            errorProviderApp.SetError(textBoxName, "");
        }

        private void textBoxNum_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxNum.Text))
            {
                errorProviderApp.SetError(textBoxNum, "Number should not be left blank!");

                e.Cancel = true;
                textBoxNum.Select(0, textBoxNum.Text.Length);
            }
            if (!int.TryParse(textBoxNum.Text, out _))
            {
                errorProviderApp.SetError(textBoxNum, "Pages should contain a number!");

                e.Cancel = true;
                textBoxNum.Select(0, textBoxNum.Text.Length);
            }
        }

        private void textBoxNum_Validated(object sender, EventArgs e)
        {
            _good.Num = Convert.ToInt32(textBoxNum.Text);

            errorProviderApp.SetError(textBoxNum, "");
        }

        private void hScrollBarSize_Scroll_Scroll(object sender, ScrollEventArgs e)
        {
            switch ((int)(hScrollBarSize_Scroll.Value / 20))
            {
                case 0:
                    labelSize.Text = "Good size: small";
                    _good.Sizes = Good.GoodSizes.Small;
                    break;
                case 1:
                    labelSize.Text = "Good size: average";
                    _good.Sizes = Good.GoodSizes.Average;
                    break;
                case 2:
                    labelSize.Text = "Good size: big";
                    _good.Sizes = Good.GoodSizes.Big;
                    break;
                case 3:
                    labelSize.Text = "Good size: very big";
                    _good.Sizes = Good.GoodSizes.VeryBig;
                    break;
                case 4:
                    labelSize.Text = "Good size: huge";
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

        private void textBoxWeight_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxWeight.Text))
            {
                errorProviderApp.SetError(textBoxWeight, "Number should not be left blank!");

                e.Cancel = true;
                textBoxWeight.Select(0, textBoxWeight.Text.Length);
            }
            if (!int.TryParse(textBoxNum.Text, out _))
            {
                errorProviderApp.SetError(textBoxNum, "Weight should contain a number!");

                e.Cancel = true;
                textBoxWeight.Select(0, textBoxWeight.Text.Length);
            }
        }

        private void textBoxWeight_Validated(object sender, EventArgs e)
        {
            _good.Weight = Convert.ToInt32(textBoxWeight.Text);

            errorProviderApp.SetError(textBoxWeight, "");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if(dateTimePicker1.Value <= DateTime.Now)
            _good.DateTime = dateTimePicker1.Value;
            else{ MessageBox.Show("Check Date"); }
        }

        private void textBoxCount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxCount.Text))
            {
                errorProviderApp.SetError(textBoxCount, "Number should not be left blank!");

                e.Cancel = true;
                textBoxCount.Select(0, textBoxWeight.Text.Length);
            }
            if (!int.TryParse(textBoxNum.Text, out _))
            {
                errorProviderApp.SetError(textBoxCount, "Number should contain a number!");

                e.Cancel = true;
                textBoxCount.Select(0, textBoxCount.Text.Length);
            }
        }

        private void textBoxCount_Validated(object sender, EventArgs e)
        {
            _good.Count = Convert.ToInt32(textBoxCount.Text);

            errorProviderApp.SetError(textBoxCount, "");
        }

        private void textBoxPrice_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPrice.Text))
            {
                errorProviderApp.SetError(textBoxPrice, "Price should not be left blank!");

                e.Cancel = true;
                textBoxPrice.Select(0, textBoxPrice.Text.Length);
            }
            if (!int.TryParse(textBoxPrice.Text, out _))
            {
                errorProviderApp.SetError(textBoxCount, "Price should contain a number!");

                e.Cancel = true;
                textBoxPrice.Select(0, textBoxPrice.Text.Length);
            }
        }

        private void textBoxPrice_Validated(object sender, EventArgs e)
        {
            _good.Price = Convert.ToInt32(textBoxPrice.Text);

            errorProviderApp.SetError(textBoxPrice, "");
        }

        private void textBoxProducer_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPrice.Text))
            {
                errorProviderApp.SetError(textBoxPrice, "Price should not be left blank!");

                e.Cancel = true;
                textBoxPrice.Select(0, textBoxPrice.Text.Length);
            }
        }

        private void textBoxProducer_Validated(object sender, EventArgs e)
        {
            _good.Producer = textBoxProducer.Text;

            errorProviderApp.SetError(textBoxProducer, "");
        }

        private void textBoxOrganization_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxOrganization.Text))
            {
                errorProviderApp.SetError(textBoxOrganization, "Organization should not be left blank!");

                e.Cancel = true;
                textBoxOrganization.Select(0, textBoxOrganization.Text.Length);
            }
        }

        private void textBoxOrganization_Validated(object sender, EventArgs e)
        {
            _producer.Organization = textBoxOrganization.Text;

            errorProviderApp.SetError(textBoxOrganization, "");
        }

        private void textBoxCountry_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxCountry.Text))
            {
                errorProviderApp.SetError(textBoxCountry, "Country should not be left blank!");

                e.Cancel = true;
                textBoxCountry.Select(0, textBoxCountry.Text.Length);
            }
        }

        private void textBoxCountry_Validated(object sender, EventArgs e)
        {
            _producer.Country = textBoxCountry.Text;

            errorProviderApp.SetError(textBoxCountry, "");
        }

        private void textBoxAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxAddress.Text))
            {
                errorProviderApp.SetError(textBoxAddress, "Address should not be left blank!");

                e.Cancel = true;
                textBoxAddress.Select(0, textBoxAddress.Text.Length);
            }
        }

        private void textBoxAddress_Validated(object sender, EventArgs e)
        {
            _producer.Address = textBoxAddress.Text;

            errorProviderApp.SetError(textBoxAddress, "");
        }

        private void textBoxPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPhone.Text))
            {
                errorProviderApp.SetError(textBoxPhone, "Phone should not be left blank!");

                e.Cancel = true;
                textBoxPhone.Select(0, textBoxPhone.Text.Length);
            }
        }

        private void textBoxPhone_Validated(object sender, EventArgs e)
        {
            _producer.Phone = textBoxPhone.Text;

            errorProviderApp.SetError(textBoxPhone, "");
        }

        private bool Save()
        {
            try
            {
                string producerJSON = JsonSerializer.Serialize(_producer);
                File.WriteAllText(@"../../../../producer.json", producerJSON);

                string goodJSON = JsonSerializer.Serialize(_good);
                File.WriteAllText(@"../../../../good.json", goodJSON);

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
            if (ValidateChildren())
            {
                if (Save())
                {
                    MessageBox.Show("Saved successfully", "Saved");
                }
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string producerJSON = File.ReadAllText(@"../../../../producer.json");
                _producer = JsonSerializer.Deserialize<Producer>(producerJSON);
                textBoxOrganization.Text = _producer.Organization;
                textBoxCountry.Text = _producer.Country;
                textBoxAddress.Text = _producer.Address;
                textBoxPhone.Text = _producer.Phone;

                string goodJSON = File.ReadAllText(@"../../../../good.json");
                _good = JsonSerializer.Deserialize<Good>(goodJSON);
                switch (_good.Type)
                {
                    case Good.Types.Food:
                        radioButtonFood.Checked = true;
                        break;
                    case Good.Types.Clothes:
                        radioButtonClothes.Checked = true;
                        break;
                    case Good.Types.Service:
                        radioButtonService.Checked = true;
                        break;
                }
               
                dateTimePicker1.Value = _good.DateTime;
                switch (_good.Sizes)
                {
                    case Good.GoodSizes.Small:
                        labelSize.Text = "File size: small";
                        hScrollBarSize_Scroll.Value = 0;
                        break;
                    case Good.GoodSizes.Average:
                        labelSize.Text = "File size: average";
                        hScrollBarSize_Scroll.Value = 21;
                        break;
                    case Good.GoodSizes.Big:
                        labelSize.Text = "File size: big";
                        hScrollBarSize_Scroll.Value = 41;
                        break;
                    case Good.GoodSizes.VeryBig:
                        labelSize.Text = "File size: very big";
                        hScrollBarSize_Scroll.Value = 61;
                        break;
                    case Good.GoodSizes.Huge:
                        labelSize.Text = "File size: huge";
                        hScrollBarSize_Scroll.Value = 81;
                        break;
                }
                textBoxWeight.Text = _good.Weight.ToString();
                textBoxName.Text = _good.Name;
                textBoxNum.Text = _good.Num.ToString();
                textBoxProducer.Text = _good.Producer;
                textBoxCount.Text = _good.Count.ToString();
                textBoxPrice.Text = _good.Price.ToString();
                if (!richTextBox.Text.ToString().Contains(goodJSON))
                {
                    richTextBox.AppendText(producerJSON);
                    richTextBox.AppendText(goodJSON);
                    MessageBox.Show("Loaded successfully", "Error");
                }
                else
                {
                    MessageBox.Show("Good already exist");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
