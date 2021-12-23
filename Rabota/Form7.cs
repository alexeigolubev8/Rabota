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
    public partial class Form7 : Form
    {
        DataBase database;
        private OleDbConnection connection;

        private string Authlogin;
        private string Authpassword;

        public Form7(string login, string password)
        {
            InitializeComponent();
            database = new DataBase();
            connection = database.db;

            Login.Text = login;
            Authlogin = login;
            Authpassword = password;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var oldPass = OldPass.Text;
            var newPass = NewPas.Text;

            if(oldPass == Authpassword)
            {
                connection.Open();
                string query = string.Format("UPDATE Пользователи SET Пароль = '{0}' WHERE Логин = '{1}'", newPass, Authlogin);
                OleDbCommand commandUpdateProbeg = new OleDbCommand(query, connection);
                commandUpdateProbeg.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Пароль успешно сменен!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный пароль");
            }
        }
    }
}
