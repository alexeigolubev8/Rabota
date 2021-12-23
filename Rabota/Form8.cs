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
    public partial class Form8 : Form
    {
        DataBase database;
        private OleDbConnection connection;

        public Form8()
        {
            InitializeComponent();

            database = new DataBase();
            connection = database.db;
        }

        private void add_Click(object sender, EventArgs e)
        {
            var login = Login.Text;
            var password = Password.Text;
            var fio = FIO.Text;

            database = new DataBase();

            connection = database.db;

            connection.Open();

            string query = string.Format("select Логин from Пользователи where Логин = '{0}' ", login);

            OleDbCommand command = new OleDbCommand(query, connection);

            OleDbDataReader reader = command.ExecuteReader();

            string checkLogin = string.Empty;
            while (reader.Read())
            {
                checkLogin = reader[0].ToString();
            }

            connection.Close();

            if(checkLogin == login)
            {
                MessageBox.Show("Такой пользователь уже есть!");
            }
            else
            {
                string queryString =
                "INSERT INTO Пользователи (Логин, Пароль, ФИО) VALUES ('" + login + "','" + password + "','" + fio + "') ";

                connection.Open();
                OleDbCommand commandInser = new OleDbCommand(queryString, connection);
                commandInser.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Пользователь добавлен");
                this.Close();
            }
        }
    }
}
