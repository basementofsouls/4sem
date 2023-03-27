namespace WindowsFormsApp2
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.NameSearch = new System.Windows.Forms.TextBox();
            this.TypeSearch = new System.Windows.Forms.TextBox();
            this.PriceSearch1 = new System.Windows.Forms.TextBox();
            this.PriceSearch2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Find = new System.Windows.Forms.Button();
            this.SearchTextBox = new System.Windows.Forms.RichTextBox();
            this.Clear = new System.Windows.Forms.Button();
            this.errorProviderApp = new System.Windows.Forms.ErrorProvider(this.components);
            this.backbutton = new System.Windows.Forms.Button();
            this.nextbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderApp)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(20, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Поиск";
            // 
            // NameSearch
            // 
            this.NameSearch.Location = new System.Drawing.Point(71, 56);
            this.NameSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NameSearch.Name = "NameSearch";
            this.NameSearch.Size = new System.Drawing.Size(117, 22);
            this.NameSearch.TabIndex = 1;
            // 
            // TypeSearch
            // 
            this.TypeSearch.Location = new System.Drawing.Point(71, 92);
            this.TypeSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TypeSearch.Name = "TypeSearch";
            this.TypeSearch.Size = new System.Drawing.Size(117, 22);
            this.TypeSearch.TabIndex = 2;
            this.TypeSearch.Validating += new System.ComponentModel.CancelEventHandler(this.TypeSearch_Validating);
            this.TypeSearch.Validated += new System.EventHandler(this.TypeSearch_Validated);
            // 
            // PriceSearch1
            // 
            this.PriceSearch1.Location = new System.Drawing.Point(114, 134);
            this.PriceSearch1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PriceSearch1.Name = "PriceSearch1";
            this.PriceSearch1.Size = new System.Drawing.Size(73, 22);
            this.PriceSearch1.TabIndex = 3;
            // 
            // PriceSearch2
            // 
            this.PriceSearch2.Location = new System.Drawing.Point(114, 159);
            this.PriceSearch2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PriceSearch2.Name = "PriceSearch2";
            this.PriceSearch2.Size = new System.Drawing.Size(73, 22);
            this.PriceSearch2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Имя:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Тип:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Цена:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "От";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(84, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "До";
            // 
            // Find
            // 
            this.Find.Location = new System.Drawing.Point(24, 200);
            this.Find.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Find.Name = "Find";
            this.Find.Size = new System.Drawing.Size(67, 41);
            this.Find.TabIndex = 10;
            this.Find.Text = "Найти";
            this.Find.UseVisualStyleBackColor = true;
            this.Find.Click += new System.EventHandler(this.Find_Click);
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(256, 20);
            this.SearchTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(389, 202);
            this.SearchTextBox.TabIndex = 11;
            this.SearchTextBox.Text = "";
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(545, 226);
            this.Clear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(100, 35);
            this.Clear.TabIndex = 12;
            this.Clear.Text = "Очистить";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // errorProviderApp
            // 
            this.errorProviderApp.ContainerControl = this;
            // 
            // backbutton
            // 
            this.backbutton.Location = new System.Drawing.Point(256, 237);
            this.backbutton.Name = "backbutton";
            this.backbutton.Size = new System.Drawing.Size(75, 23);
            this.backbutton.TabIndex = 13;
            this.backbutton.Text = "назад";
            this.backbutton.UseVisualStyleBackColor = true;
            this.backbutton.Click += new System.EventHandler(this.backbutton_Click);
            // 
            // nextbutton
            // 
            this.nextbutton.Location = new System.Drawing.Point(349, 237);
            this.nextbutton.Name = "nextbutton";
            this.nextbutton.Size = new System.Drawing.Size(75, 23);
            this.nextbutton.TabIndex = 14;
            this.nextbutton.Text = "вперёд";
            this.nextbutton.UseVisualStyleBackColor = true;
            this.nextbutton.Click += new System.EventHandler(this.nextbutton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.nextbutton);
            this.Controls.Add(this.backbutton);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.Find);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PriceSearch2);
            this.Controls.Add(this.PriceSearch1);
            this.Controls.Add(this.TypeSearch);
            this.Controls.Add(this.NameSearch);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderApp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameSearch;
        private System.Windows.Forms.TextBox TypeSearch;
        private System.Windows.Forms.TextBox PriceSearch1;
        private System.Windows.Forms.TextBox PriceSearch2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Find;
        private System.Windows.Forms.RichTextBox SearchTextBox;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.ErrorProvider errorProviderApp;
        private System.Windows.Forms.Button backbutton;
        private System.Windows.Forms.Button nextbutton;
    }
}