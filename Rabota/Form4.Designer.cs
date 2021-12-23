namespace Rabota
{
    partial class Form4
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
            this.label3 = new System.Windows.Forms.Label();
            this.Marka = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Year = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Contry = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Number = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Name = new System.Windows.Forms.TextBox();
            this.Add = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Марка Автомобиля";
            // 
            // Marka
            // 
            this.Marka.Location = new System.Drawing.Point(21, 46);
            this.Marka.Name = "Marka";
            this.Marka.Size = new System.Drawing.Size(210, 22);
            this.Marka.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Год выпуска";
            // 
            // Year
            // 
            this.Year.Location = new System.Drawing.Point(21, 110);
            this.Year.Mask = "00/00/0000";
            this.Year.Name = "Year";
            this.Year.Size = new System.Drawing.Size(100, 22);
            this.Year.TabIndex = 24;
            this.Year.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "Страна производитель";
            // 
            // Contry
            // 
            this.Contry.Location = new System.Drawing.Point(22, 176);
            this.Contry.Name = "Contry";
            this.Contry.Size = new System.Drawing.Size(210, 22);
            this.Contry.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 17);
            this.label4.TabIndex = 28;
            this.label4.Text = "Номер Автомобиля";
            // 
            // Number
            // 
            this.Number.Location = new System.Drawing.Point(22, 242);
            this.Number.Name = "Number";
            this.Number.Size = new System.Drawing.Size(210, 22);
            this.Number.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 279);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 17);
            this.label5.TabIndex = 30;
            this.label5.Text = "Имя водителя";
            // 
            // Name
            // 
            this.Name.Location = new System.Drawing.Point(22, 309);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(210, 22);
            this.Name.TabIndex = 29;
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(20, 356);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(101, 41);
            this.Add.TabIndex = 31;
            this.Add.Text = "Добавить";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(206, 26);
            this.button1.TabIndex = 32;
            this.button1.Text = "Добавить запчасти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(127, 356);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 41);
            this.button2.TabIndex = 33;
            this.button2.Text = "Выход";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 460);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Number);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Contry);
            this.Controls.Add(this.Year);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Marka);
            //this.Name = "Form4";
            this.Text = "Добавить автомобиль";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Marka;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox Year;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Contry;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Number;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Name;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}