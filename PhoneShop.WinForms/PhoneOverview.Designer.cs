namespace Phoneshop.WinForms
{
    partial class PhoneOverview
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Description_Box_Label = new System.Windows.Forms.Label();
            this.Brand_Label = new System.Windows.Forms.Label();
            this.Type_Label = new System.Windows.Forms.Label();
            this.Price_Label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Stock_Label = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Phones_Listbox = new System.Windows.Forms.ListBox();
            this.Search_Textbox = new System.Windows.Forms.TextBox();
            this.Exit_Button = new System.Windows.Forms.Button();
            this.Remove_Phone_Button = new System.Windows.Forms.Button();
            this.AddPhone_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(357, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Brand:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(357, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(357, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Description:";
            // 
            // Description_Box_Label
            // 
            this.Description_Box_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Description_Box_Label.Location = new System.Drawing.Point(357, 138);
            this.Description_Box_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Description_Box_Label.Name = "Description_Box_Label";
            this.Description_Box_Label.Size = new System.Drawing.Size(763, 330);
            this.Description_Box_Label.TabIndex = 4;
            this.Description_Box_Label.Text = "Description";
            // 
            // Brand_Label
            // 
            this.Brand_Label.AutoSize = true;
            this.Brand_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Brand_Label.Location = new System.Drawing.Point(480, 15);
            this.Brand_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Brand_Label.Name = "Brand_Label";
            this.Brand_Label.Size = new System.Drawing.Size(60, 27);
            this.Brand_Label.TabIndex = 5;
            this.Brand_Label.Text = "Brand";
            // 
            // Type_Label
            // 
            this.Type_Label.AutoSize = true;
            this.Type_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Type_Label.Location = new System.Drawing.Point(480, 60);
            this.Type_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Type_Label.Name = "Type_Label";
            this.Type_Label.Size = new System.Drawing.Size(51, 27);
            this.Type_Label.TabIndex = 6;
            this.Type_Label.Text = "Type";
            // 
            // Price_Label
            // 
            this.Price_Label.AutoSize = true;
            this.Price_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Price_Label.Location = new System.Drawing.Point(939, 15);
            this.Price_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Price_Label.Name = "Price_Label";
            this.Price_Label.Size = new System.Drawing.Size(51, 27);
            this.Price_Label.TabIndex = 8;
            this.Price_Label.Text = "Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(856, 15);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Price:";
            // 
            // Stock_Label
            // 
            this.Stock_Label.AutoSize = true;
            this.Stock_Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Stock_Label.Location = new System.Drawing.Point(939, 57);
            this.Stock_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Stock_Label.Name = "Stock_Label";
            this.Stock_Label.Size = new System.Drawing.Size(124, 27);
            this.Stock_Label.TabIndex = 10;
            this.Stock_Label.Text = "Stock amount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(856, 57);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = "Stock:";
            // 
            // Phones_Listbox
            // 
            this.Phones_Listbox.FormattingEnabled = true;
            this.Phones_Listbox.ItemHeight = 25;
            this.Phones_Listbox.Location = new System.Drawing.Point(17, 63);
            this.Phones_Listbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Phones_Listbox.Name = "Phones_Listbox";
            this.Phones_Listbox.Size = new System.Drawing.Size(318, 404);
            this.Phones_Listbox.TabIndex = 11;
            this.Phones_Listbox.SelectedIndexChanged += new System.EventHandler(this.LstPhones_SelectedIndexChanged);
            // 
            // Search_Textbox
            // 
            this.Search_Textbox.Location = new System.Drawing.Point(17, 15);
            this.Search_Textbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Search_Textbox.Name = "Search_Textbox";
            this.Search_Textbox.PlaceholderText = "Search";
            this.Search_Textbox.Size = new System.Drawing.Size(318, 31);
            this.Search_Textbox.TabIndex = 12;
            this.Search_Textbox.TextChanged += new System.EventHandler(this.Search_Textbox_TextChanged);
            // 
            // Exit_Button
            // 
            this.Exit_Button.Location = new System.Drawing.Point(1014, 475);
            this.Exit_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.Size = new System.Drawing.Size(107, 38);
            this.Exit_Button.TabIndex = 13;
            this.Exit_Button.Text = "Exit";
            this.Exit_Button.UseVisualStyleBackColor = true;
            this.Exit_Button.Click += new System.EventHandler(this.Exit_Button_Click);
            // 
            // Remove_Phone_Button
            // 
            this.Remove_Phone_Button.Enabled = false;
            this.Remove_Phone_Button.Location = new System.Drawing.Point(61, 480);
            this.Remove_Phone_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Remove_Phone_Button.Name = "Remove_Phone_Button";
            this.Remove_Phone_Button.Size = new System.Drawing.Size(36, 42);
            this.Remove_Phone_Button.TabIndex = 14;
            this.Remove_Phone_Button.Text = "-";
            this.Remove_Phone_Button.UseVisualStyleBackColor = true;
            this.Remove_Phone_Button.Click += new System.EventHandler(this.Remove_Phone_Button_Click);
            // 
            // AddPhone_Button
            // 
            this.AddPhone_Button.Location = new System.Drawing.Point(17, 480);
            this.AddPhone_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddPhone_Button.Name = "AddPhone_Button";
            this.AddPhone_Button.Size = new System.Drawing.Size(36, 42);
            this.AddPhone_Button.TabIndex = 15;
            this.AddPhone_Button.Text = "+";
            this.AddPhone_Button.UseVisualStyleBackColor = true;
            this.AddPhone_Button.Click += new System.EventHandler(this.AddPhone_Button_Click);
            // 
            // PhoneOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 532);
            this.Controls.Add(this.AddPhone_Button);
            this.Controls.Add(this.Remove_Phone_Button);
            this.Controls.Add(this.Exit_Button);
            this.Controls.Add(this.Search_Textbox);
            this.Controls.Add(this.Phones_Listbox);
            this.Controls.Add(this.Stock_Label);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Price_Label);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Type_Label);
            this.Controls.Add(this.Brand_Label);
            this.Controls.Add(this.Description_Box_Label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PhoneOverview";
            this.Text = "Phone Application";
            this.Load += new System.EventHandler(this.PhoneOverviewStart);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Description_Box_Label;
        private System.Windows.Forms.Label Brand_Label;
        private System.Windows.Forms.Label Type_Label;
        private System.Windows.Forms.Label Price_Label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Stock_Label;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox Phones_Listbox;
        private System.Windows.Forms.TextBox Search_Textbox;
        private System.Windows.Forms.Button Exit_Button;
        private System.Windows.Forms.Button Remove_Phone_Button;
        private System.Windows.Forms.Button AddPhone_Button;
    }
}

