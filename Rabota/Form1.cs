using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rabota
{
    public partial class Form1 : Form
    {

        DataBase database;
        private OleDbConnection connection;

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                string login = textBox1.Text;
                string password = textBox2.Text;
                string passwordInDB = string.Empty;
                string loginInDB = string.Empty;

                database = new DataBase();

                connection = database.db;

                connection.Open();

                string query = string.Format("select Логин, Пароль from Пользователи where Логин = '{0}' ", login);

                OleDbCommand command = new OleDbCommand(query, connection);

                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    loginInDB = reader[0].ToString();
                    passwordInDB = reader[1].ToString();
                }

                connection.Close();

                if (loginInDB == login && passwordInDB == password)
                {
                    Form2 frm = new Form2(login, password);
                    frm.Owner = this;
                    this.Hide();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
        }

    }
}
