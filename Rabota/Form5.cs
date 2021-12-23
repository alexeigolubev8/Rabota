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
    public partial class Form5 : Form
    {
        DataBase database;
        private OleDbConnection connection;
        string AutoId;

        public Form5()
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
                //берем только те автомобили, у которых нету деталей
                string check = reader[2].ToString();
                if (check == "")
                {
                    string test = reader[0].ToString() + " - " + reader[1].ToString();
                    comboBox1.Items.Add(test);
                }
            }

            connection.Close();
        }

        //формируем выпадающий список
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = comboBox1.SelectedIndex;
            string selectedAuto = comboBox1.Items[selectedIndex].ToString();

            AutoId = selectedAuto.Substring(0, selectedAuto.IndexOf('-'));
        }

        //здесь мы используем общие методы для запросов и туда подставляем колонки относящиеся к конкретной запчасти
        private void Add_Click(object sender, EventArgs e)
        {
            //добавляем новую деталь
            database.AddDetails(AmoNum.Text, AmoKM.Text, "Амортизаторы");
            //получаем номер новой детали
            var amorId = database.GetLastDetailId("Амортизаторы");
            //добавляем новую деталь к текущему автомобилю
            database.UpdateAutoDetail(AutoId, amorId, "Амортизаторы");

            database.AddDetails(vpNum.Text, vpKm.Text, "ВодяныеПомпы");
            var vpId = database.GetLastDetailId("ВодяныеПомпы");
            database.UpdateAutoDetail(AutoId, vpId, "ВодяныеПомпы");

            database.AddDetails(provNum.Text, provKm.Text, "ВысоковольтныеПровода");
            var provId = database.GetLastDetailId("ВысоковольтныеПровода");
            database.UpdateAutoDetail(AutoId, provId, "ВысоковольтныеПровода");

            database.AddDetails(gbcNum.Text, gbcKm.Text, "ГБЦ");
            var gbcId = database.GetLastDetailId("ГБЦ");
            database.UpdateAutoDetail(AutoId, gbcId, "ГБЦ");

            database.AddDetails(genNum.Text, genKm.Text, "Генераторы");
            var genId = database.GetLastDetailId("Генераторы");
            database.UpdateAutoDetail(AutoId, genId, "Генераторы");

            database.AddDetails(datNum.Text, datKm.Text, "Датчики");
            var datId = database.GetLastDetailId("Датчики");
            database.UpdateAutoDetail(AutoId, datId, "Датчики");

            database.AddDetails(podNum.Text, podKm.Text, "ДеталиПодвески");
            var podId = database.GetLastDetailId("ДеталиПодвески");
            database.UpdateAutoDetail(AutoId, podId, "ДеталиПодвески");

            database.AddDetails(lamNum.Text, lamKm.Text, "Лампочки");
            var lamId = database.GetLastDetailId("Лампочки");
            database.UpdateAutoDetail(AutoId, lamId, "Лампочки");

            database.AddDetails(prokNum.Text, prokKm.Text, "Прокладки");
            var prokId = database.GetLastDetailId("Прокладки");
            database.UpdateAutoDetail(AutoId, prokId, "Прокладки");

            database.AddDetails(radNum.Text, radKm.Text, "Радиаторы");
            var radId = database.GetLastDetailId("Радиаторы");
            database.UpdateAutoDetail(AutoId, radId, "Радиаторы");

            database.AddDetails(grmNum.Text, grmKm.Text, "РемниГРМ");
            var grmId = database.GetLastDetailId("РемниГРМ");
            database.UpdateAutoDetail(AutoId, grmId, "РемниГРМ");

            database.AddDetails(tugNum.Text, tugKm.Text, "РулевыеТяги");
            var tugId = database.GetLastDetailId("РулевыеТяги");
            database.UpdateAutoDetail(AutoId, tugId, "РулевыеТяги");

            database.AddDetails(svNum.Text, svKm.Text, "Свечи");
            var svId = database.GetLastDetailId("Свечи");
            database.UpdateAutoDetail(AutoId, svId, "Свечи");

            database.AddDetails(starNum.Text, starKm.Text, "Стартеры");
            var starId = database.GetLastDetailId("Стартеры");
            database.UpdateAutoDetail(AutoId, starId, "Стартеры");

            database.AddDetails(termNum.Text, termKm.Text, "Термостаты");
            var termId = database.GetLastDetailId("Термостаты");
            database.UpdateAutoDetail(AutoId, termId, "Термостаты");

            database.AddDetails(disNum.Text, disKm.Text, "ТормозныеДиски");
            var disId = database.GetLastDetailId("ТормозныеДиски");
            database.UpdateAutoDetail(AutoId, disId, "ТормозныеДиски");

            database.AddDetails(kolNum.Text, kolKM.Text, "ТормозныеКолодки");
            var kolId = database.GetLastDetailId("ТормозныеКолодки");
            database.UpdateAutoDetail(AutoId, kolId, "ТормозныеКолодки");

            database.AddDetails(supNum.Text, supKM.Text, "ТормозныеСуппорта");
            var supId = database.GetLastDetailId("ТормозныеСуппорта");
            database.UpdateAutoDetail(AutoId, supId, "ТормозныеСуппорта");

            database.AddDetails(filNum.Text, filKM.Text, "Фильтра");
            var filId = database.GetLastDetailId("Фильтра");
            database.UpdateAutoDetail(AutoId, filId, "Фильтра");

            database.AddDetails(bcNum.Text, bcKM.Text, "БлокиЦилиндров");
            var bcId = database.GetLastDetailId("БлокиЦилиндров");
            database.UpdateAutoDetail(AutoId, bcId, "БлокиЦилиндров");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
