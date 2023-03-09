namespace WindowsFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.errorProviderApp = new System.Windows.Forms.ErrorProvider(this.components);
            this.textBoxNum = new System.Windows.Forms.TextBox();
            this.hScrollBarSize_Scroll = new System.Windows.Forms.HScrollBar();
            this.labelSize = new System.Windows.Forms.Label();
            this.groupBoxType = new System.Windows.Forms.GroupBox();
            this.radioButtonService = new System.Windows.Forms.RadioButton();
            this.radioButtonClothes = new System.Windows.Forms.RadioButton();
            this.radioButtonFood = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBoxWeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.textBoxProducer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxOrganization = new System.Windows.Forms.TextBox();
            this.textBoxCountry = new System.Windows.Forms.TextBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderApp)).BeginInit();
            this.groupBoxType.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(92, 48);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(154, 26);
            this.textBoxName.TabIndex = 0;
            this.textBoxName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxName_Validating);
            this.textBoxName.Validated += new System.EventHandler(this.textBoxName_Validated);
            // 
            // errorProviderApp
            // 
            this.errorProviderApp.ContainerControl = this;
            // 
            // textBoxNum
            // 
            this.textBoxNum.Location = new System.Drawing.Point(92, 94);
            this.textBoxNum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxNum.Name = "textBoxNum";
            this.textBoxNum.Size = new System.Drawing.Size(154, 26);
            this.textBoxNum.TabIndex = 1;
            this.textBoxNum.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxNum_Validating);
            this.textBoxNum.Validated += new System.EventHandler(this.textBoxNum_Validated);
            // 
            // hScrollBarSize_Scroll
            // 
            this.hScrollBarSize_Scroll.Location = new System.Drawing.Point(39, 155);
            this.hScrollBarSize_Scroll.Name = "hScrollBarSize_Scroll";
            this.hScrollBarSize_Scroll.Size = new System.Drawing.Size(232, 21);
            this.hScrollBarSize_Scroll.TabIndex = 2;
            this.hScrollBarSize_Scroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarSize_Scroll_Scroll);
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(135, 131);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(73, 20);
            this.labelSize.TabIndex = 3;
            this.labelSize.Text = "labelSize";
            // 
            // groupBoxType
            // 
            this.groupBoxType.Controls.Add(this.radioButtonService);
            this.groupBoxType.Controls.Add(this.radioButtonClothes);
            this.groupBoxType.Controls.Add(this.radioButtonFood);
            this.groupBoxType.Location = new System.Drawing.Point(39, 190);
            this.groupBoxType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxType.Name = "groupBoxType";
            this.groupBoxType.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBoxType.Size = new System.Drawing.Size(225, 151);
            this.groupBoxType.TabIndex = 4;
            this.groupBoxType.TabStop = false;
            this.groupBoxType.Text = "Type";
            this.groupBoxType.Leave += new System.EventHandler(this.groupBoxType_Leave);
            // 
            // radioButtonService
            // 
            this.radioButtonService.AutoSize = true;
            this.radioButtonService.Location = new System.Drawing.Point(8, 119);
            this.radioButtonService.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButtonService.Name = "radioButtonService";
            this.radioButtonService.Size = new System.Drawing.Size(82, 24);
            this.radioButtonService.TabIndex = 2;
            this.radioButtonService.TabStop = true;
            this.radioButtonService.Text = "Service";
            this.radioButtonService.UseVisualStyleBackColor = true;
            // 
            // radioButtonClothes
            // 
            this.radioButtonClothes.AutoSize = true;
            this.radioButtonClothes.Location = new System.Drawing.Point(7, 74);
            this.radioButtonClothes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButtonClothes.Name = "radioButtonClothes";
            this.radioButtonClothes.Size = new System.Drawing.Size(84, 24);
            this.radioButtonClothes.TabIndex = 1;
            this.radioButtonClothes.TabStop = true;
            this.radioButtonClothes.Text = "Clothes";
            this.radioButtonClothes.UseVisualStyleBackColor = true;
            // 
            // radioButtonFood
            // 
            this.radioButtonFood.AutoSize = true;
            this.radioButtonFood.Location = new System.Drawing.Point(8, 28);
            this.radioButtonFood.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButtonFood.Name = "radioButtonFood";
            this.radioButtonFood.Size = new System.Drawing.Size(67, 24);
            this.radioButtonFood.TabIndex = 0;
            this.radioButtonFood.TabStop = true;
            this.radioButtonFood.Text = "Food";
            this.radioButtonFood.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Number";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(34, 384);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(224, 26);
            this.dateTimePicker1.TabIndex = 7;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // textBoxWeight
            // 
            this.textBoxWeight.Location = new System.Drawing.Point(92, 418);
            this.textBoxWeight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxWeight.Name = "textBoxWeight";
            this.textBoxWeight.Size = new System.Drawing.Size(154, 26);
            this.textBoxWeight.TabIndex = 8;
            this.textBoxWeight.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxWeight_Validating);
            this.textBoxWeight.Validated += new System.EventHandler(this.textBoxWeight_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 421);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Weight";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(92, 452);
            this.textBoxCount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(154, 26);
            this.textBoxCount.TabIndex = 10;
            this.textBoxCount.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxCount_Validating);
            this.textBoxCount.Validated += new System.EventHandler(this.textBoxCount_Validated);
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(92, 488);
            this.textBoxPrice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(154, 26);
            this.textBoxPrice.TabIndex = 11;
            this.textBoxPrice.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxPrice_Validating);
            this.textBoxPrice.Validated += new System.EventHandler(this.textBoxPrice_Validated);
            // 
            // textBoxProducer
            // 
            this.textBoxProducer.Location = new System.Drawing.Point(92, 522);
            this.textBoxProducer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxProducer.Name = "textBoxProducer";
            this.textBoxProducer.Size = new System.Drawing.Size(154, 26);
            this.textBoxProducer.TabIndex = 12;
            this.textBoxProducer.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxProducer_Validating);
            this.textBoxProducer.Validated += new System.EventHandler(this.textBoxProducer_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 456);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Count";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 488);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 522);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Producer";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(135, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 25);
            this.label7.TabIndex = 16;
            this.label7.Text = "GOOD";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(598, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 25);
            this.label8.TabIndex = 17;
            this.label8.Text = "PRODUCER";
            // 
            // textBoxOrganization
            // 
            this.textBoxOrganization.Location = new System.Drawing.Point(604, 48);
            this.textBoxOrganization.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxOrganization.Name = "textBoxOrganization";
            this.textBoxOrganization.Size = new System.Drawing.Size(154, 26);
            this.textBoxOrganization.TabIndex = 18;
            this.textBoxOrganization.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxOrganization_Validating);
            this.textBoxOrganization.Validated += new System.EventHandler(this.textBoxOrganization_Validated);
            // 
            // textBoxCountry
            // 
            this.textBoxCountry.Location = new System.Drawing.Point(604, 90);
            this.textBoxCountry.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxCountry.Name = "textBoxCountry";
            this.textBoxCountry.Size = new System.Drawing.Size(154, 26);
            this.textBoxCountry.TabIndex = 19;
            this.textBoxCountry.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxCountry_Validating);
            this.textBoxCountry.Validated += new System.EventHandler(this.textBoxCountry_Validated);
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(604, 131);
            this.textBoxAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(154, 26);
            this.textBoxAddress.TabIndex = 20;
            this.textBoxAddress.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxAddress_Validating);
            this.textBoxAddress.Validated += new System.EventHandler(this.textBoxAddress_Validated);
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(604, 171);
            this.textBoxPhone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(154, 26);
            this.textBoxPhone.TabIndex = 21;
            this.textBoxPhone.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxPhone_Validating);
            this.textBoxPhone.Validated += new System.EventHandler(this.textBoxPhone_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(505, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 20);
            this.label9.TabIndex = 22;
            this.label9.Text = "Organization";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(539, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 20);
            this.label10.TabIndex = 23;
            this.label10.Text = "Country";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(539, 131);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 20);
            this.label11.TabIndex = 24;
            this.label11.Text = "Address";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(546, 175);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 20);
            this.label12.TabIndex = 25;
            this.label12.Text = "Phone";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(346, 205);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(143, 50);
            this.buttonSave.TabIndex = 26;
            this.buttonSave.Text = "SAVE";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSaveClick);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(346, 263);
            this.buttonLoad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(143, 50);
            this.buttonLoad.TabIndex = 27;
            this.buttonLoad.Text = "LOAD";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(36, 360);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 20);
            this.label13.TabIndex = 28;
            this.label13.Text = "Delivery Date";
            // 
            // richTextBox
            // 
            this.richTextBox.Location = new System.Drawing.Point(586, 206);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(284, 344);
            this.richTextBox.TabIndex = 29;
            this.richTextBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.textBoxCountry);
            this.Controls.Add(this.textBoxOrganization);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxProducer);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxWeight);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBoxType);
            this.Controls.Add(this.labelSize);
            this.Controls.Add(this.hScrollBarSize_Scroll);
            this.Controls.Add(this.textBoxNum);
            this.Controls.Add(this.textBoxName);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderApp)).EndInit();
            this.groupBoxType.ResumeLayout(false);
            this.groupBoxType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.ErrorProvider errorProviderApp;
        private System.Windows.Forms.TextBox textBoxNum;
        private System.Windows.Forms.HScrollBar hScrollBarSize_Scroll;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.GroupBox groupBoxType;
        private System.Windows.Forms.RadioButton radioButtonFood;
        private System.Windows.Forms.RadioButton radioButtonClothes;
        private System.Windows.Forms.RadioButton radioButtonService;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxWeight;
        private System.Windows.Forms.TextBox textBoxProducer;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.TextBox textBoxCountry;
        private System.Windows.Forms.TextBox textBoxOrganization;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RichTextBox richTextBox;
    }
}

