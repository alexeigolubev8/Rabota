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
    public partial class Form6 : Form
    {
        DataBase database;
        private OleDbConnection connection;
        string AutoId;

        public Form6()
        {
            InitializeComponent();

            database = new DataBase();

            connection = database.db;

            connection.Open();

            string query = "select КодАвтомобиля, МаркаАвтомобиля, БлокиЦилиндров from ИнформацияОбАвтомобилях";

            OleDbCommand command = new OleDbCommand(query, connection);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string test = reader[0].ToString() + " - " + reader[1].ToString();
                comboBox1.Items.Add(test);
            }

            connection.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = comboBox1.SelectedIndex;
            string selectedAuto = comboBox1.Items[selectedIndex].ToString();

            AutoId = selectedAuto.Substring(0, selectedAuto.IndexOf('-'));

            connection.Open();

            string query = "select ИмяВодителя, НомерАвтомобиля from ИнформацияОбАвтомобилях where КодАвтомобиля = " + AutoId + " ";

            OleDbCommand command = new OleDbCommand(query, connection);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Name.Text = reader[0].ToString();
                Num.Text = reader[1].ToString();
            }

            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        //меняем имя водителя на новое
        private void button1_Click(object sender, EventArgs e)
        {
            var name = Name.Text;
            var num = Num.Text;

            connection.Open();
            string query = string.Format("UPDATE ИнформацияОбАвтомобилях SET НомерАвтомобиля = '{0}', ИмяВодителя = '{1}' WHERE КодАвтомобиля = {2}", num, name, AutoId);
            OleDbCommand commandUpdateProbeg = new OleDbCommand(query, connection);
            commandUpdateProbeg.ExecuteNonQuery();
            connection.Close();
        }
    }
}
