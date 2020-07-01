namespace BookReader
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cont = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.Describe = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BookName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.MainTags = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SecondTegs = new System.Windows.Forms.RichTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Url = new System.Windows.Forms.TextBox();
            this.GoBtn = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 511);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Пуск";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Послідня озвучина глава";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(213, 11);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 22);
            this.textBox1.TabIndex = 2;
            // 
            // cont
            // 
            this.cont.Location = new System.Drawing.Point(213, 43);
            this.cont.Margin = new System.Windows.Forms.Padding(4);
            this.cont.Name = "cont";
            this.cont.Size = new System.Drawing.Size(132, 22);
            this.cont.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Озвучити главу";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 395);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Книга";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(213, 390);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 6;
            this.button2.Text = "Обзор";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_ClickAsync);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(213, 426);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 8;
            this.button3.Text = "Обзор";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 431);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Папка збереження";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(213, 461);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 28);
            this.button4.TabIndex = 10;
            this.button4.Text = "Обзор";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 466);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Заставка";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // Describe
            // 
            this.Describe.Location = new System.Drawing.Point(213, 94);
            this.Describe.Name = "Describe";
            this.Describe.Size = new System.Drawing.Size(156, 96);
            this.Describe.TabIndex = 11;
            this.Describe.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 94);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Опис";
            // 
            // BookName
            // 
            this.BookName.Location = new System.Drawing.Point(213, 360);
            this.BookName.Margin = new System.Windows.Forms.Padding(4);
            this.BookName.Name = "BookName";
            this.BookName.Size = new System.Drawing.Size(132, 22);
            this.BookName.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 364);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Назва";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 212);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Основні теги";
            // 
            // MainTags
            // 
            this.MainTags.Location = new System.Drawing.Point(213, 212);
            this.MainTags.MaxLength = 100;
            this.MainTags.Name = "MainTags";
            this.MainTags.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.MainTags.Size = new System.Drawing.Size(156, 27);
            this.MainTags.TabIndex = 15;
            this.MainTags.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 251);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "Другорядні теги";
            // 
            // SecondTegs
            // 
            this.SecondTegs.Location = new System.Drawing.Point(213, 251);
            this.SecondTegs.Name = "SecondTegs";
            this.SecondTegs.Size = new System.Drawing.Size(156, 96);
            this.SecondTegs.TabIndex = 17;
            this.SecondTegs.Text = "";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1063, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(273, 24);
            this.comboBox1.TabIndex = 19;
            // 
            // Url
            // 
            this.Url.Location = new System.Drawing.Point(408, 47);
            this.Url.Margin = new System.Windows.Forms.Padding(4);
            this.Url.Name = "Url";
            this.Url.Size = new System.Drawing.Size(462, 22);
            this.Url.TabIndex = 21;
            // 
            // GoBtn
            // 
            this.GoBtn.Location = new System.Drawing.Point(869, 43);
            this.GoBtn.Margin = new System.Windows.Forms.Padding(4);
            this.GoBtn.Name = "GoBtn";
            this.GoBtn.Size = new System.Drawing.Size(100, 28);
            this.GoBtn.TabIndex = 22;
            this.GoBtn.Text = "Пуск";
            this.GoBtn.UseVisualStyleBackColor = true;
            this.GoBtn.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(579, 4);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 28);
            this.button5.TabIndex = 23;
            this.button5.Text = "Пуск";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 665);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.GoBtn);
            this.Controls.Add(this.Url);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.SecondTegs);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.MainTags);
            this.Controls.Add(this.BookName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Describe);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cont);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Озвучка тексту Yandex Text Spitch";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox cont;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.RichTextBox Describe;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox BookName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox MainTags;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox SecondTegs;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox Url;
        private System.Windows.Forms.Button GoBtn;
        private System.Windows.Forms.Button button5;
    }
}

