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
    public partial class Form4 : Form
    {
        DataBase database;
        private OleDbConnection connection;

        public Form4()
        {
            InitializeComponent();

            database = new DataBase();
            connection = database.db;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            var marka = Marka.Text;
            var year = Year.Text;
            var contry = Contry.Text;
            var number = Number.Text;
            var name = Name.Text;

            string queryString = 
                "INSERT INTO ИнформацияОбАвтомобилях (МаркаАвтомобиля, ГодВыпуска, СтранаПроизводитель, НомерАвтомобиля, ИмяВодителя) VALUES ('" + marka + "','" + year + "','" + contry + "','" + number + "','" + name + "') ";

            connection.Open();
            OleDbCommand commandInser = new OleDbCommand(queryString, connection);
            commandInser.ExecuteNonQuery();
            connection.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.Owner = this;
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
