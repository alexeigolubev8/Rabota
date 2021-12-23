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
    public partial class Form3 : Form
    {
        #region Переменные
        string AutoId;
        string probeg;
        string bcKilometrs;
        string bcKilometrsOstatok;
        string bcId;
        string bcCount;
        string gbcId;
        string gbcKilom;
        string gbcKilomOstatok;
        string gbcCount;
        string gbcProc;
        string grmCount;
        string grmKilom;
        string grmKilomOstatok;
        string grmProc;
        string grmId;
        string proklKilom;
        string proklKilomOstatok;
        string proklId;
        string proklCount;
        string aromKilom;
        string aromKilomOstatok;
        string aromId;
        string aromCount;
        string breaksuppKilom;
        string breaksuppKilomOstatok;
        string breaksuppId;
        string breaksuppCount;

        string breakdiscKilom;
        string breakdiscKilomOstatok;
        string breakdiscId;
        string breakdiscCount;

        string breakkolKilom;
        string breakkolKilomOstatok;
        string breakkolId;
        string breakkolCount;

        string amorKilom;
        string amorOstatok;
        string amorId;
        string amorCount;

        string podvKilom;
        string podvOstatok;
        string podvId;
        string podvCount;

        string tygiKilom;
        string tygiOstatok;
        string tygiId;
        string tygiCount;

        string radKilom;
        string radOstatok;
        string radId;
        string radCount;

        string terKilom;
        string terOstatok;
        string terId;
        string terCount;

        string pomKilom;
        string pomOstatok;
        string pomId;
        string pomCount;

        string datKilom;
        string datOstatok;
        string datId;
        string datCount;

        string lamKilom;
        string lamOstatok;
        string lamId;
        string lamCount;

        string genKilom;
        string genOstatok;
        string genId;
        string genCount;

        string staKilom;
        string staOstatok;
        string staId;
        string staCount;

        string visKilom;
        string visOstatok;
        string visId;
        string visCount;

        string filKilom;
        string filOstatok;
        string filId;
        string filCount;

        string sveKilom;
        string sveOstatok;
        string sveId;
        string sveCount;
        #endregion

        DataBase database;
        private OleDbConnection connection;

        public Form3()
        {
            InitializeComponent();

            database = new DataBase();

            connection = database.db;

            connection.Open();

            string query = "select КодАвтомобиля, МаркаАвтомобиля from ИнформацияОбАвтомобилях";

            OleDbCommand command = new OleDbCommand(query, connection);

            OleDbDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                string test = reader[0].ToString() + " - " + reader[1].ToString();
                comboBox1.Items.Add(test);
            }

            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void GetAuto_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = comboBox1.SelectedIndex;
            string selectedAuto = comboBox1.Items[selectedIndex].ToString();

            AutoId  = selectedAuto.Substring(0, selectedAuto.IndexOf('-'));

            GetAutoByAutoId(AutoId);
        }

        //получаем ВСЕ детали по текущему автомобилю
        private void GetAutoByAutoId(string autoId)
        {
            List<DetailsId> DetailsIDs = new List<DetailsId>();
            string query = string.Format("select * from ИнформацияОбАвтомобилях where КодАвтомобиля = {0}", autoId);

            connection.Open();

            OleDbCommand command = new OleDbCommand(query, connection);

            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Auto.Text = reader[1].ToString();
                Year.Text = reader[2].ToString();
                Country.Text = reader[3].ToString();
                Number.Text = reader[4].ToString();
                Driver.Text = reader[5].ToString();

                probeg = reader[6].ToString();
                if (probeg != "" && probeg != null)
                {
                    CurProbeg.Text = reader[6].ToString();
                }
                else
                {
                    CurProbeg.Text = "0";
                    probeg = "0";
                }

                DetailsId bc = new DetailsId();
                bc.detaiId = reader[7].ToString();
                bc.detailType = "BC";

                DetailsId gbc = new DetailsId();
                gbc.detaiId = reader[8].ToString();
                gbc.detailType = "GBC";

                DetailsId grm = new DetailsId();
                grm.detaiId = reader[9].ToString();
                grm.detailType = "GRM";

                DetailsId prokl = new DetailsId();
                prokl.detaiId = reader[10].ToString();
                prokl.detailType = "Prokl";

                DetailsId breaksupport = new DetailsId();
                breaksupport.detaiId = reader[11].ToString();
                breaksupport.detailType = "Breaksupport";

                DetailsId breakdisc = new DetailsId();
                breakdisc.detaiId = reader[12].ToString();
                breakdisc.detailType = "BreakDisc";

                DetailsId breakkol = new DetailsId();
                breakkol.detaiId = reader[13].ToString();
                breakkol.detailType = "BreakKol";

                DetailsId amort = new DetailsId();
                amort.detaiId = reader[14].ToString();
                amort.detailType = "Amort";

                DetailsId podv = new DetailsId();
                podv.detaiId = reader[15].ToString();
                podv.detailType = "Podv";

                DetailsId tygi = new DetailsId();
                tygi.detaiId = reader[16].ToString();
                tygi.detailType = "Tygi";

                DetailsId rad = new DetailsId();
                rad.detaiId = reader[17].ToString();
                rad.detailType = "Rad";

                DetailsId ter = new DetailsId();
                ter.detaiId = reader[18].ToString();
                ter.detailType = "Ter";

                DetailsId pom = new DetailsId();
                pom.detaiId = reader[19].ToString();
                pom.detailType = "Pom";

                DetailsId dat = new DetailsId();
                dat.detaiId = reader[20].ToString();
                dat.detailType = "Dat";

                DetailsId lam = new DetailsId();
                lam.detaiId = reader[21].ToString();
                lam.detailType = "Lam";

                DetailsId gen = new DetailsId();
                gen.detaiId = reader[22].ToString();
                gen.detailType = "Gen";

                DetailsId sta = new DetailsId();
                sta.detaiId = reader[23].ToString();
                sta.detailType = "Sta";

                DetailsId vis = new DetailsId();
                vis.detaiId = reader[24].ToString();
                vis.detailType = "Vis";

                DetailsId fil = new DetailsId();
                fil.detaiId = reader[25].ToString();
                fil.detailType = "Fil";

                DetailsId sve = new DetailsId();
                sve.detaiId = reader[26].ToString();
                sve.detailType = "Sve";

                DetailsIDs.Add(bc);
                DetailsIDs.Add(gbc);
                DetailsIDs.Add(grm);
                DetailsIDs.Add(prokl);
                DetailsIDs.Add(breaksupport);
                DetailsIDs.Add(breakdisc);
                DetailsIDs.Add(breakkol);
                DetailsIDs.Add(amort);
                DetailsIDs.Add(podv);
                DetailsIDs.Add(tygi);
                DetailsIDs.Add(rad);
                DetailsIDs.Add(ter);
                DetailsIDs.Add(pom);
                DetailsIDs.Add(dat);
                DetailsIDs.Add(lam);
                DetailsIDs.Add(gen);
                DetailsIDs.Add(sta);
                DetailsIDs.Add(vis);
                DetailsIDs.Add(fil);
                DetailsIDs.Add(sve);
            }

            connection.Close();

            foreach(var item in DetailsIDs)
            {
                LoadDetails(item.detailType, item.detaiId);
            }

        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            //считаем блок цилиндров
            string writeProbeg = Probeg.Text;
            int writeProbegToInt = 0;
            if (writeProbeg != "")
            {
                writeProbegToInt = Convert.ToInt32(writeProbeg);
            }
            else
            {
                MessageBox.Show("Заполните поле!");
            }

            int probegToInt = Convert.ToInt32(probeg);
            probeg = (probegToInt + writeProbegToInt).ToString();

            int resultBC = Convert.ToInt32(bcKilometrsOstatok) - writeProbegToInt;
            if (resultBC < 0)
            {
                resultBC = resultBC * -1;

                int checkOstatokKilometrs = 0;

                int CountToInt = 0;

                do
                {
                    resultBC = Convert.ToInt32(bcKilometrs) - resultBC;
                    if (resultBC < 0)
                    {
                        resultBC = resultBC * -1;
                    }
                    checkOstatokKilometrs = resultBC;
                    bcKilometrsOstatok = resultBC.ToString();
                    CountToInt++;
                }
                while ((Convert.ToInt32(bcKilometrs)) < checkOstatokKilometrs);

                if (Convert.ToInt32(bcKilometrsOstatok) == 0)
                {
                    bcKilometrsOstatok = bcKilometrs;
                }

                bcCount = (Convert.ToInt32(bcCount) + CountToInt).ToString();

                BCCount.Text = bcCount;
                BCKilometrs.Text = bcKilometrsOstatok;

                if (bcKilometrs == bcKilometrsOstatok)
                {
                    BCProcents.Text = string.Format("100 %");
                }
                else
                {
                    int procentKilom = Convert.ToInt32(bcKilometrsOstatok) / (Convert.ToInt32(bcKilometrs) / 100);
                    BCProcents.Text = string.Format("{0} %", procentKilom.ToString());
                }

            }
            else
            {
                bcKilometrsOstatok = resultBC.ToString();

                BCKilometrs.Text = resultBC.ToString();
                int procentKilom = Convert.ToInt32(bcKilometrsOstatok) / (Convert.ToInt32(bcKilometrs) / 100);
                BCProcents.Text = string.Format("{0} %", procentKilom.ToString());
            }

            //считаем ГБЦ

            int resultGBC = Convert.ToInt32(gbcKilomOstatok) - writeProbegToInt;
            if (resultGBC < 0)
            {
                resultGBC = resultGBC * -1;

                int checkOstatokKilometrs = 0;

                int CountToInt = 0;

                do
                {
                    resultGBC = Convert.ToInt32(gbcKilom) - resultGBC;
                    if (resultGBC < 0)
                    {
                        resultGBC = resultGBC * -1;
                    }
                    checkOstatokKilometrs = resultGBC;
                    gbcKilomOstatok = resultGBC.ToString();
                    CountToInt++;
                }
                while ((Convert.ToInt32(gbcKilom)) < checkOstatokKilometrs);

                if (Convert.ToInt32(gbcKilomOstatok) == 0)
                {
                    gbcKilomOstatok = gbcKilom;
                }

                gbcCount = (Convert.ToInt32(gbcCount) + CountToInt).ToString();

                GBCCount.Text = gbcCount;

                GBCKilom.Text = gbcKilomOstatok;

                if (gbcKilom == gbcKilomOstatok)
                {
                    GBCProc.Text = string.Format("100 %");
                }
                else
                {
                    int procentKilom = Convert.ToInt32(gbcKilomOstatok) / (Convert.ToInt32(gbcKilom) / 100);
                    GBCProc.Text = string.Format("{0} %", procentKilom.ToString());
                }

            }
            else
            {
                gbcKilomOstatok = resultGBC.ToString();

                GBCKilom.Text = resultGBC.ToString();
                int procentKilom = Convert.ToInt32(gbcKilomOstatok) / (Convert.ToInt32(gbcKilom) / 100);
                GBCProc.Text = string.Format("{0} %", procentKilom.ToString());
            }

            //Считаем ГРМ

            int resultGRM = Convert.ToInt32(grmKilomOstatok) - writeProbegToInt;
            if (resultGRM < 0)
            {
                resultGRM = resultGRM * -1;

                int checkOstatokKilometrs = 0;

                int CountToInt = 0;

                do
                {
                    resultGRM = Convert.ToInt32(grmKilom) - resultGRM;
                    if (resultGRM < 0)
                    {
                        resultGRM = resultGRM * -1;
                    }
                    checkOstatokKilometrs = resultGRM;
                    grmKilomOstatok = resultGRM.ToString();
                    CountToInt++;
                }
                while ((Convert.ToInt32(grmKilom)) < checkOstatokKilometrs);

                if (Convert.ToInt32(grmKilomOstatok) == 0)
                {
                    grmKilomOstatok = grmKilom;
                }

                grmCount = (Convert.ToInt32(grmCount) + CountToInt).ToString();

                GRMCount.Text = grmCount;

                GRMKillom.Text = grmKilomOstatok;

                if (grmKilom == grmKilomOstatok)
                {
                    GRMProc.Text = string.Format("100 %");
                }
                else
                {
                    int procentKilom = Convert.ToInt32(grmKilomOstatok) / (Convert.ToInt32(grmKilom) / 100);
                    GRMProc.Text = string.Format("{0} %", procentKilom.ToString());
                }

            }
            else
            {
                grmKilomOstatok = resultGRM.ToString();

                GRMKillom.Text = resultGRM.ToString();
                int procentKilom = Convert.ToInt32(grmKilomOstatok) / (Convert.ToInt32(grmKilom) / 100);
                GRMProc.Text = string.Format("{0} %", procentKilom.ToString());
            }

            //Прокладки

            int resultProk = Convert.ToInt32(proklKilomOstatok) - writeProbegToInt;
            if (resultProk < 0)
            {
                resultProk = resultProk * -1;

                int checkOstatokKilometrs = 0;

                int CountToInt = 0;

                do
                {
                    resultProk = Convert.ToInt32(proklKilom) - resultProk;
                    if (resultProk < 0)
                    {
                        resultProk = resultProk * -1;
                    }
                    checkOstatokKilometrs = resultProk;
                    proklKilomOstatok = resultProk.ToString();
                    CountToInt++;
                }
                while ((Convert.ToInt32(proklKilom)) < checkOstatokKilometrs);

                if (Convert.ToInt32(proklKilomOstatok) == 0)
                {
                    proklKilomOstatok = proklKilom;
                }

                proklCount = (Convert.ToInt32(proklCount) + CountToInt).ToString();
                ProkladkiCount.Text = proklCount;

                ProkladkiKM.Text = proklKilomOstatok;

                if (proklKilom == proklKilomOstatok)
                {
                    ProkladkiProc.Text = string.Format("100 %");
                }
                else
                {
                    int procentKilom = Convert.ToInt32(proklKilomOstatok) / (Convert.ToInt32(proklKilom) / 100);
                    ProkladkiProc.Text = string.Format("{0} %", procentKilom.ToString());
                }

            }
            else
            {
                proklKilomOstatok = resultProk.ToString();

                ProkladkiKM.Text = resultProk.ToString();
                int procentKilom = Convert.ToInt32(proklKilomOstatok) / (Convert.ToInt32(proklKilom) / 100);
                ProkladkiProc.Text = string.Format("{0} %", procentKilom.ToString());
            }

            //считаем Тормозные диски

            int resultBRDisc = Convert.ToInt32(breakdiscKilomOstatok) - writeProbegToInt;
            if (resultBRDisc < 0)
            {
                resultBRDisc = resultBRDisc * -1;

                int checkOstatokKilometrs = 0;

                int CountToInt = 0;

                do
                {
                    resultBRDisc = Convert.ToInt32(breakdiscKilom) - resultBRDisc;
                    if (resultBRDisc < 0)
                    {
                        resultBRDisc = resultBRDisc * -1;
                    }
                    checkOstatokKilometrs = resultBRDisc;
                    breakdiscKilomOstatok = resultBRDisc.ToString();
                    CountToInt++;
                }
                while ((Convert.ToInt32(breakdiscKilom)) < checkOstatokKilometrs);

                if (Convert.ToInt32(breakdiscKilomOstatok) == 0)
                {
                    breakdiscKilomOstatok = breakdiscKilom;
                }

                breakdiscCount = (Convert.ToInt32(breakdiscCount) + CountToInt).ToString();

                BreakDiscCount.Text = breakdiscCount;

                BreakDiscKM.Text = breakdiscKilomOstatok;

                if (breakdiscKilom == breakdiscKilomOstatok)
                {
                    BreakDiscProc.Text = string.Format("100 %");
                }
                else
                {
                    int procentKilom = Convert.ToInt32(breakdiscKilomOstatok) / (Convert.ToInt32(breakdiscKilom) / 100);
                    BreakDiscProc.Text = string.Format("{0} %", procentKilom.ToString());
                }

            }
            else
            {
                breakdiscKilomOstatok = resultBRDisc.ToString();

                BreakDiscKM.Text = resultBRDisc.ToString();
                int procentKilom = Convert.ToInt32(breakdiscKilomOstatok) / (Convert.ToInt32(breakdiscKilom) / 100);
                BreakDiscProc.Text = string.Format("{0} %", procentKilom.ToString());
            }

            //считаем Тормозные суппорта

            int resultBRSupp = Convert.ToInt32(breaksuppKilomOstatok) - writeProbegToInt;
            if (resultBRSupp < 0)
            {
                resultBRSupp = resultBRSupp * -1;

                int checkOstatokKilometrs = 0;

                int CountToInt = 0;

                do
                {
                    resultBRSupp = Convert.ToInt32(breaksuppKilom) - resultBRSupp;
                    if (resultBRSupp < 0)
                    {
                        resultBRSupp = resultBRSupp * -1;
                    }
                    checkOstatokKilometrs = resultBRSupp;
                    breaksuppKilomOstatok = resultBRSupp.ToString();
                    CountToInt++;
                }
                while ((Convert.ToInt32(breaksuppKilom)) < checkOstatokKilometrs);

                if (Convert.ToInt32(breaksuppKilomOstatok) == 0)
                {
                    breaksuppKilomOstatok = breaksuppKilom;
                }

                breaksuppCount = (Convert.ToInt32(breaksuppCount) + CountToInt).ToString();

                BreakSuppCount.Text = breaksuppCount;

                BreakSupKM.Text = breaksuppKilomOstatok;

                if (breaksuppKilom == breaksuppKilomOstatok)
                {
                    BreakSuppProc.Text = string.Format("100 %");
                }
                else
                {
                    int procentKilom = Convert.ToInt32(breaksuppKilomOstatok) / (Convert.ToInt32(breaksuppKilom) / 100);
                    BreakSuppProc.Text = string.Format("{0} %", procentKilom.ToString());
                }

            }
            else
            {
                breaksuppKilomOstatok = resultBRSupp.ToString();

                BreakSupKM.Text = resultBRSupp.ToString();
                int procentKilom = Convert.ToInt32(breaksuppKilomOstatok) / (Convert.ToInt32(breaksuppKilom) / 100);
                BreakSuppProc.Text = string.Format("{0} %", procentKilom.ToString());
            }

            //считаем Тормозные Колодки

            int resultBRKol = Convert.ToInt32(breakkolKilomOstatok) - writeProbegToInt;
            if (resultBRKol < 0)
            {
                resultBRKol = resultBRKol * -1;

                int checkOstatokKilometrs = 0;

                int CountToInt = 0;

                do
                {
                    resultBRKol = Convert.ToInt32(breakkolKilom) - resultBRKol;
                    if (resultBRKol < 0)
                    {
                        resultBRKol = resultBRKol * -1;
                    }
                    checkOstatokKilometrs = resultBRKol;
                    breakkolKilomOstatok = resultBRKol.ToString();
                    CountToInt++;
                }
                while ((Convert.ToInt32(breakkolKilom)) < checkOstatokKilometrs);

                if (Convert.ToInt32(breakkolKilomOstatok) == 0)
                {
                    breakkolKilomOstatok = breakkolKilom;
                }

                breakkolCount = (Convert.ToInt32(breakkolCount) + CountToInt).ToString();

                BreakKolCount.Text = breakkolCount;

                BreakKolKM.Text = breakkolKilomOstatok;

                if (breakkolKilom == breakkolKilomOstatok)
                {
                    BreakKolProc.Text = string.Format("100 %");
                }
                else
                {
                    int procentKilom = Convert.ToInt32(breakkolKilomOstatok) / (Convert.ToInt32(breakkolKilom) / 100);
                    BreakKolProc.Text = string.Format("{0} %", procentKilom.ToString());
                }

            }
            else
            {
                breakkolKilomOstatok = resultBRKol.ToString();

                BreakKolKM.Text = resultBRKol.ToString();
                int procentKilom = Convert.ToInt32(breakkolKilomOstatok) / (Convert.ToInt32(breakkolKilom) / 100);
                BreakKolProc.Text = string.Format("{0} %", procentKilom.ToString());
            }

            //считаем Амортизаторы

            int resultAmor = Convert.ToInt32(amorOstatok) - writeProbegToInt;
            if (resultAmor < 0)
            {
                resultAmor = resultAmor * -1;

                int checkOstatokKilometrs = 0;

                int CountToInt = 0;

                do
                {
                    resultAmor = Convert.ToInt32(amorKilom) - resultAmor;
                    if (resultAmor < 0)
                    {
                        resultAmor = resultAmor * -1;
                    }
                    checkOstatokKilometrs = resultAmor;
                    amorOstatok = resultAmor.ToString();
                    CountToInt++;
                }
                while ((Convert.ToInt32(amorKilom)) < checkOstatokKilometrs);

                if (Convert.ToInt32(amorOstatok) == 0)
                {
                    amorOstatok = amorKilom;
                }

                amorCount = (Convert.ToInt32(amorCount) + CountToInt).ToString();

                AmorCount.Text = amorCount;

                AmorKM.Text = amorOstatok;

                if (amorKilom == amorOstatok)
                {
                    AmorProc.Text = string.Format("100 %");
                }
                else
                {
                    int procentKilom = Convert.ToInt32(amorOstatok) / (Convert.ToInt32(amorKilom) / 100);
                    AmorProc.Text = string.Format("{0} %", procentKilom.ToString());
                }

            }
            else
            {
                amorOstatok = resultAmor.ToString();

                AmorKM.Text = resultAmor.ToString();
                int procentKilom = Convert.ToInt32(amorOstatok) / (Convert.ToInt32(amorKilom) / 100);
                AmorProc.Text = string.Format("{0} %", procentKilom.ToString());
            }

            //считаем Детали подвески

            int resultPodv = Convert.ToInt32(podvOstatok) - writeProbegToInt;
            if (resultPodv < 0)
            {
                resultPodv = resultPodv * -1;

                int checkOstatokKilometrs = 0;

                int CountToInt = 0;

                do
                {
                    resultPodv = Convert.ToInt32(podvKilom) - resultPodv;
                    if (resultPodv < 0)
                    {
                        resultPodv = resultPodv * -1;
                    }
                    checkOstatokKilometrs = resultPodv;
                    podvOstatok = resultPodv.ToString();
                    CountToInt++;
                }
                while ((Convert.ToInt32(podvKilom)) < checkOstatokKilometrs);

                if (Convert.ToInt32(podvOstatok) == 0)
                {
                    podvOstatok = podvKilom;
                }

                podvCount = (Convert.ToInt32(podvCount) + CountToInt).ToString();

                PodvCount.Text = podvCount;

                PodvKm.Text = podvOstatok;

                if (podvKilom == podvOstatok)
                {
                    PodvProc.Text = string.Format("100 %");
                }
                else
                {
                    int procentKilom = Convert.ToInt32(podvOstatok) / (Convert.ToInt32(podvKilom) / 100);
                    PodvProc.Text = string.Format("{0} %", procentKilom.ToString());
                }

            }
            else
            {
                podvOstatok = resultPodv.ToString();

                PodvKm.Text = resultPodv.ToString();
                int procentKilom = Convert.ToInt32(podvOstatok) / (Convert.ToInt32(podvKilom) / 100);
                PodvProc.Text = string.Format("{0} %", procentKilom.ToString());
            }

            //считаем Рулевые тяги

            int resultTygi = Convert.ToInt32(tygiOstatok) - writeProbegToInt;
            if (resultTygi < 0)
            {
                resultTygi = resultTygi * -1;

                int checkOstatokKilometrs = 0;

                int CountToInt = 0;

                do
                {
                    resultTygi = Convert.ToInt32(tygiKilom) - resultTygi;
                    if (resultTygi < 0)
                    {
                        resultTygi = resultTygi * -1;
                    }
                    checkOstatokKilometrs = resultTygi;
                    tygiOstatok = resultTygi.ToString();
                    CountToInt++;
                }
                while ((Convert.ToInt32(tygiKilom)) < checkOstatokKilometrs);

                if (Convert.ToInt32(tygiOstatok) == 0)
                {
                    tygiOstatok = tygiKilom;
                }

                tygiCount = (Convert.ToInt32(tygiCount) + CountToInt).ToString();

                TygiCount.Text = tygiCount;

                TygiKM.Text = tygiOstatok;

                if (tygiKilom == tygiOstatok)
                {
                    TygiProc.Text = string.Format("100 %");
                }
                else
                {
                    int procentKilom = Convert.ToInt32(tygiOstatok) / (Convert.ToInt32(tygiKilom) / 100);
                    TygiProc.Text = string.Format("{0} %", procentKilom.ToString());
                }

            }
            else
            {
                tygiOstatok = resultTygi.ToString();

                TygiKM.Text = resultTygi.ToString();
                int procentKilom = Convert.ToInt32(tygiOstatok) / (Convert.ToInt32(tygiKilom) / 100);
                TygiProc.Text = string.Format("{0} %", procentKilom.ToString());
            }

            //считаем Радиаторы

            int resultRad = Convert.ToInt32(radOstatok) - writeProbegToInt;
            if (resultRad < 0)
            {
                resultRad = resultRad * -1;

                int checkOstatokKilometrs = 0;

                int CountToInt = 0;

                do
                {
                    resultRad = Convert.ToInt32(radKilom) - resultRad;
                    if (resultRad < 0)
                    {
                        resultRad = resultRad * -1;
                    }
                    checkOstatokKilometrs = resultRad;
                    radOstatok = resultRad.ToString();
                    CountToInt++;
                }
                while ((Convert.ToInt32(radKilom)) < checkOstatokKilometrs);

                if (Convert.ToInt32(radOstatok) == 0)
                {
                    radOstatok = radKilom;
                }

                radCount = (Convert.ToInt32(radCount) + CountToInt).ToString();

                RadCount.Text = radCount;

                RadKM.Text = radOstatok;

                if (radKilom == radOstatok)
                {
                    RadProc.Text = string.Format("100 %");
                }
                else
                {
                    int procentKilom = Convert.ToInt32(radOstatok) / (Convert.ToInt32(radKilom) / 100);
                    RadProc.Text = string.Format("{0} %", procentKilom.ToString());
                }

            }
            else
            {
                radOstatok = resultRad.ToString();

                RadKM.Text = resultRad.ToString();
                int procentKilom = Convert.ToInt32(radOstatok) / (Convert.ToInt32(radKilom) / 100);
                RadProc.Text = string.Format("{0} %", procentKilom.ToString());
            }

            //считаем Термостаты

            int resultTer = Convert.ToInt32(terOstatok) - writeProbegToInt;
            if (resultTer < 0)
            {
                resultTer = resultTer * -1;

                int checkOstatokKilometrs = 0;

                int CountToInt = 0;

                do
                {
                    resultTer = Convert.ToInt32(terKilom) - resultTer;
                    if (resultTer < 0)
                    {
                        resultTer = resultTer * -1;
                    }
                    checkOstatokKilometrs = resultTer;
                    terOstatok = resultTer.ToString();
                    CountToInt++;
                }
                while ((Convert.ToInt32(terKilom)) < checkOstatokKilometrs);

                if (Convert.ToInt32(terOstatok) == 0)
                {
                    terOstatok = terKilom;
                }

                terCount = (Convert.ToInt32(terCount) + CountToInt).ToString();

                TerCount.Text = terCount;

                TerKM.Text = terOstatok;

                if (terKilom == terOstatok)
                {
                    TerProc.Text = string.Format("100 %");
                }
                else
                {
                    int procentKilom = Convert.ToInt32(terOstatok) / (Convert.ToInt32(terKilom) / 100);
                    TerProc.Text = string.Format("{0} %", procentKilom.ToString());
                }

            }
            else
            {
                terOstatok = resultTer.ToString();

                TerKM.Text = resultTer.ToString();
                int procentKilom = Convert.ToInt32(terOstatok) / (Convert.ToInt32(terKilom) / 100);
                TerProc.Text = string.Format("{0} %", procentKilom.ToString());
            }

            //считаем Водяные помпы

            int resultPom = Convert.ToInt32(pomOstatok) - writeProbegToInt;
            if (resultPom < 0)
            {
                resultPom = resultPom * -1;

                int checkOstatokKilometrs = 0;

                int CountToInt = 0;

                do
                {
                    resultPom = Convert.ToInt32(pomKilom) - resultPom;
                    if (resultPom < 0)
                    {
                        resultPom = resultPom * -1;
                    }
                    checkOstatokKilometrs = resultPom;
                    pomOstatok = resultPom.ToString();
                    CountToInt++;
                }
                while ((Convert.ToInt32(pomKilom)) < checkOstatokKilometrs);

                if (Convert.ToInt32(pomOstatok) == 0)
                {
                    pomOstatok = pomKilom;
                }

                pomCount = (Convert.ToInt32(pomCount) + CountToInt).ToString();

                PomCount.Text = pomCount;

                PomKM.Text = pomOstatok;

                if (pomKilom == pomOstatok)
                {
                    PomProc.Text = string.Format("100 %");
                }
                else
                {
                    int procentKilom = Convert.ToInt32(pomOstatok) / (Convert.ToInt32(pomKilom) / 100);
                    PomProc.Text = string.Format("{0} %", procentKilom.ToString());
                }

            }
            else
            {
                pomOstatok = resultPom.ToString();

                PomKM.Text = resultPom.ToString();
                int procentKilom = Convert.ToInt32(pomOstatok) / (Convert.ToInt32(pomKilom) / 100);
                PomProc.Text = string.Format("{0} %", procentKilom.ToString());
            }

            //считаем Датчики

            int resultDat = Convert.ToInt32(datOstatok) - writeProbegToInt;
            if (resultDat < 0)
            {
                resultDat = resultDat * -1;

                int checkOstatokKilometrs = 0;

                int CountToInt = 0;

                do
                {
                    resultDat = Convert.ToInt32(datKilom) - resultDat;
                    if (resultDat < 0)
                    {
                        resultDat = resultDat * -1;
                    }
                    checkOstatokKilometrs = resultDat;
                    datOstatok = resultDat.ToString();
                    CountToInt++;
                }
                while ((Convert.ToInt32(datKilom)) < checkOstatokKilometrs);

                if (Convert.ToInt32(datOstatok) == 0)
                {
                    datOstatok = datKilom;
                }

                datCount = (Convert.ToInt32(datCount) + CountToInt).ToString();

                DatCount.Text = datCount;

                DatKM.Text = datOstatok;

                if (datKilom == datOstatok)
                {   
                    DatProc.Text = string.Format("100 %");
                }
                else
                {
                    int procentKilom = Convert.ToInt32(datOstatok) / (Convert.ToInt32(datKilom) / 100);
                    DatProc.Text = string.Format("{0} %", procentKilom.ToString());
                }

            }
            else
            {
                datOstatok = resultDat.ToString();

                DatKM.Text = resultDat.ToString();
                int procentKilom = Convert.ToInt32(datOstatok) / (Convert.ToInt32(datKilom) / 100);
                DatProc.Text = string.Format("{0} %", procentKilom.ToString());
            }

            //считаем Лампочки

            int resultLam = Convert.ToInt32(lamOstatok) - writeProbegToInt;
            if (resultLam < 0)
            {
                resultLam = resultLam * -1;

                int checkOstatokKilometrs = 0;

                int CountToInt = 0;

                do
                {
                    resultLam = Convert.ToInt32(lamKilom) - resultLam;
                    if (resultLam < 0)
                    {
                        resultLam = resultLam * -1;
                    }
                    checkOstatokKilometrs = resultLam;
                    lamOstatok = resultLam.ToString();
                    CountToInt++;
                }
                while ((Convert.ToInt32(lamKilom)) < checkOstatokKilometrs);

                if (Convert.ToInt32(lamOstatok) == 0)
                {
                    lamOstatok = lamKilom;
                }

                lamCount = (Convert.ToInt32(lamCount) + CountToInt).ToString();

                LamCount.Text = lamCount;

                LamKM.Text = lamOstatok;

                if (lamKilom == lamOstatok)
                {
                    LamProc.Text = string.Format("100 %");
                }
                else
                {
                    int procentKilom = Convert.ToInt32(lamOstatok) / (Convert.ToInt32(lamKilom) / 100);
                    LamProc.Text = string.Format("{0} %", procentKilom.ToString());
                }

            }
            else
            {
                lamOstatok = resultLam.ToString();

                LamKM.Text = resultLam.ToString();
                int procentKilom = Convert.ToInt32(lamOstatok) / (Convert.ToInt32(lamKilom) / 100);
                LamProc.Text = string.Format("{0} %", procentKilom.ToString());
            }

            //считаем Генераторы

            int resultGen = Convert.ToInt32(genOstatok) - writeProbegToInt;
            if (resultGen < 0)
            {
                resultGen = resultGen * -1;

                int checkOstatokKilometrs = 0;

                int CountToInt = 0;

                do
                {
                    resultGen = Convert.ToInt32(genKilom) - resultGen;
                    if (resultGen < 0)
                    {
                        resultGen = resultGen * -1;
                    }
                    checkOstatokKilometrs = resultGen;
                    genOstatok = resultGen.ToString();
                    CountToInt++;
                }
                while ((Convert.ToInt32(genKilom)) < checkOstatokKilometrs);

                if (Convert.ToInt32(genOstatok) == 0)
                {
                    genOstatok = genKilom;
                }

                genCount = (Convert.ToInt32(genCount) + CountToInt).ToString();

                GenCount.Text = genCount;

                GenKM.Text = genOstatok;

                if (genKilom == genOstatok)
                {
                    GenProc.Text = string.Format("100 %");
                }
                else
                {
                    int procentKilom = Convert.ToInt32(genOstatok) / (Convert.ToInt32(genKilom) / 100);
                    GenProc.Text = string.Format("{0} %", procentKilom.ToString());
                }

            }
            else
            {
                genOstatok = resultGen.ToString();

                GenKM.Text = resultGen.ToString();
                int procentKilom = Convert.ToInt32(genOstatok) / (Convert.ToInt32(genKilom) / 100);
                GenProc.Text = string.Format("{0} %", procentKilom.ToString());
            }

            //считаем Стартеры

            int resultSta = Convert.ToInt32(staOstatok) - writeProbegToInt;
            if (resultSta < 0)
            {
                resultSta = resultSta * -1;

                int checkOstatokKilometrs = 0;

                int CountToInt = 0;

                do
                {
                    resultSta = Convert.ToInt32(staKilom) - resultSta;
                    if (resultSta < 0)
                    {
                        resultSta = resultSta * -1;
                    }
                    checkOstatokKilometrs = resultSta;
                    staOstatok = resultSta.ToString();
                    CountToInt++;
                }
                while ((Convert.ToInt32(staKilom)) < checkOstatokKilometrs);

                if (Convert.ToInt32(staOstatok) == 0)
                {
                    staOstatok = staKilom;
                }

                staCount = (Convert.ToInt32(staCount) + CountToInt).ToString();

                StaCount.Text = staCount;

                StaKM.Text = staOstatok;

                if (staKilom == staOstatok)
                {
                    StaProc.Text = string.Format("100 %");
                }
                else
                {
                    int procentKilom = Convert.ToInt32(staOstatok) / (Convert.ToInt32(staKilom) / 100);
                    StaProc.Text = string.Format("{0} %", procentKilom.ToString());
                }

            }
            else
            {
                staOstatok = resultSta.ToString();

                StaKM.Text = resultSta.ToString();
                int procentKilom = Convert.ToInt32(staOstatok) / (Convert.ToInt32(staKilom) / 100);
                StaProc.Text = string.Format("{0} %", procentKilom.ToString());
            }

            //считаем Высоковольтные провода

            int resultVis = Convert.ToInt32(visOstatok) - writeProbegToInt;
            if (resultVis < 0)
            {
                resultVis = resultVis * -1;

                int checkOstatokKilometrs = 0;

                int CountToInt = 0;

                do
                {
                    resultVis = Convert.ToInt32(visKilom) - resultVis;
                    if (resultVis < 0)
                    {
                        resultVis = resultVis * -1;
                    }
                    checkOstatokKilometrs = resultVis;
                    visOstatok = resultVis.ToString();
                    CountToInt++;
                }
                while ((Convert.ToInt32(visKilom)) < checkOstatokKilometrs);

                if (Convert.ToInt32(visOstatok) == 0)
                {
                    visOstatok = visKilom;
                }

                visCount = (Convert.ToInt32(visCount) + CountToInt).ToString();

                VisCount.Text = visCount;

                VisKm.Text = visOstatok;

                if (visKilom == visOstatok)
                {
                    VisProc.Text = string.Format("100 %");
                }
                else
                {
                    int procentKilom = Convert.ToInt32(visOstatok) / (Convert.ToInt32(visKilom) / 100);
                    VisProc.Text = string.Format("{0} %", procentKilom.ToString());
                }

            }
            else
            {
                visOstatok = resultVis.ToString();

                VisKm.Text = resultVis.ToString();
                int procentKilom = Convert.ToInt32(visOstatok) / (Convert.ToInt32(visKilom) / 100);
                VisProc.Text = string.Format("{0} %", procentKilom.ToString());
            }

            //считаем Фильтра

            int resultFil = Convert.ToInt32(filOstatok) - writeProbegToInt;
            if (resultFil < 0)
            {
                resultFil = resultFil * -1;

                int checkOstatokKilometrs = 0;

                int CountToInt = 0;

                do
                {
                    resultFil = Convert.ToInt32(filKilom) - resultFil;
                    if (resultFil < 0)
                    {
                        resultFil = resultFil * -1;
                    }
                    checkOstatokKilometrs = resultFil;
                    filOstatok = resultFil.ToString();
                    CountToInt++;
                }
                while ((Convert.ToInt32(filKilom)) < checkOstatokKilometrs);

                if (Convert.ToInt32(filOstatok) == 0)
                {
                    filOstatok = filKilom;
                }

                filCount = (Convert.ToInt32(filCount) + CountToInt).ToString();

                FilCount.Text = filCount;

                FilKm.Text = filOstatok;

                if (filKilom == filOstatok)
                {
                    FilProc.Text = string.Format("100 %");
                }
                else
                {
                    int procentKilom = Convert.ToInt32(filOstatok) / (Convert.ToInt32(filKilom) / 100);
                    FilProc.Text = string.Format("{0} %", procentKilom.ToString());
                }

            }
            else
            {
                filOstatok = resultFil.ToString();

                FilKm.Text = resultFil.ToString();
                int procentKilom = Convert.ToInt32(filOstatok) / (Convert.ToInt32(filKilom) / 100);
                FilProc.Text = string.Format("{0} %", procentKilom.ToString());
            }

            //считаем Свечи

            int resultSve = Convert.ToInt32(sveOstatok) - writeProbegToInt;
            if (resultSve < 0)
            {
                resultSve = resultSve * -1;

                int checkOstatokKilometrs = 0;

                int CountToInt = 0;

                do
                {
                    resultSve = Convert.ToInt32(sveKilom) - resultSve;
                    if (resultSve < 0)
                    {
                        resultSve = resultSve * -1;
                    }
                    checkOstatokKilometrs = resultSve;
                    sveOstatok = resultSve.ToString();
                    CountToInt++;
                }
                while ((Convert.ToInt32(sveKilom)) < checkOstatokKilometrs);

                if (Convert.ToInt32(sveOstatok) == 0)
                {
                    sveOstatok = sveKilom;
                }

                sveCount = (Convert.ToInt32(sveCount) + CountToInt).ToString();

                SveCount.Text = sveCount;

                SveKm.Text = sveOstatok;

                if (sveKilom == sveOstatok)
                {
                    SveProc.Text = string.Format("100 %");
                }
                else
                {
                    int procentKilom = Convert.ToInt32(sveOstatok) / (Convert.ToInt32(sveKilom) / 100);
                    SveProc.Text = string.Format("{0} %", procentKilom.ToString());
                }

            }
            else
            {
                sveOstatok = resultSve.ToString();

                SveKm.Text = resultSve.ToString();
                int procentKilom = Convert.ToInt32(sveOstatok) / (Convert.ToInt32(sveKilom) / 100);
                SveProc.Text = string.Format("{0} %", procentKilom.ToString());
            }

            string queryUpdateSve = string.Format("UPDATE Свечи SET ПроизводиласьЗаменаРаз = {0}, ОстаточныйРесурсДетали = {1} WHERE Свечи = {2}", sveCount, sveOstatok, sveId);
            database.Update(queryUpdateSve);

            string queryUpdateFil = string.Format("UPDATE Фильтра SET ПроизводиласьЗаменаРаз = {0}, ОстаточныйРесурсДетали = {1} WHERE Фильтра = {2}", filCount, filOstatok, filId);
            database.Update(queryUpdateFil);

            string queryUpdateVis = string.Format("UPDATE ВысоковольтныеПровода SET ПроизводиласьЗаменаРаз = {0}, ОстаточныйРесурсДетали = {1} WHERE ВысоковольтныеПровода = {2}", visCount, visOstatok, visId);
            database.Update(queryUpdateVis);

            string queryUpdateSta = string.Format("UPDATE Стартеры SET ПроизводиласьЗаменаРаз = {0}, ОстаточныйРесурсДетали = {1} WHERE Стартеры = {2}", staCount, staOstatok, staId);
            database.Update(queryUpdateSta);

            string queryUpdateGen = string.Format("UPDATE Генераторы SET ПроизводиласьЗаменаРаз = {0}, ОстаточныйРесурсДетали = {1} WHERE Генераторы = {2}", genCount, genOstatok, genId);
            database.Update(queryUpdateGen);

            string queryUpdateLam = string.Format("UPDATE Лампочки SET ПроизводиласьЗаменаРаз = {0}, ОстаточныйРесурсДетали = {1} WHERE Лампочки = {2}", lamCount, lamOstatok, lamId);
            database.Update(queryUpdateLam);

            string queryUpdateDat = string.Format("UPDATE Датчики SET ПроизводиласьЗаменаРаз = {0}, ОстаточныйРесурсДетали = {1} WHERE Датчики = {2}", datCount, datOstatok, datId);
            database.Update(queryUpdateDat);

            string queryUpdatePom = string.Format("UPDATE ВодяныеПомпы SET ПроизводиласьЗаменаРаз = {0}, ОстаточныйРесурсДетали = {1} WHERE ВодяныеПомпы = {2}", pomCount, pomOstatok, pomId);
            database.Update(queryUpdatePom);

            string queryUpdateTer = string.Format("UPDATE Термостаты SET ПроизводиласьЗаменаРаз = {0}, ОстаточныйРесурсДетали = {1} WHERE Термостаты = {2}", terCount, terOstatok, terId);
            database.Update(queryUpdateTer);

            string queryUpdateRad = string.Format("UPDATE Радиаторы SET ПроизводиласьЗаменаРаз = {0}, ОстаточныйРесурсДетали = {1} WHERE Радиаторы = {2}", radCount, radOstatok, radId);
            database.Update(queryUpdateRad);

            string queryUpdateTygi = string.Format("UPDATE РулевыеТяги SET ПроизводиласьЗаменаРаз = {0}, ОстаточныйРесурсДетали = {1} WHERE РулевыеТяги = {2}", tygiCount, tygiOstatok, tygiId);
            database.Update(queryUpdateTygi);

            string queryUpdatePodv= string.Format("UPDATE ДеталиПодвески SET ПроизводиласьЗаменаРаз = {0}, ОстаточныйРесурсДетали = {1} WHERE ДеталиПодвески = {2}", podvCount, podvOstatok, podvId);
            database.Update(queryUpdatePodv);

            string queryUpdateAmor = string.Format("UPDATE Амортизаторы SET ПроизводиласьЗаменаРаз = {0}, ОстаточныйРесурсДетали = {1} WHERE Амортизаторы = {2}", amorCount, amorOstatok, amorId);
            database.Update(queryUpdateAmor);

            string queryUpdateBRK = string.Format("UPDATE ТормозныеКолодки SET ПроизводиласьЗаменаРаз = {0}, ОстаточныйРесурсДетали = {1} WHERE ТормозныеКолодки = {2}", breakkolCount, breakkolKilomOstatok, breakkolId);
            database.Update(queryUpdateBRK);

            string queryUpdateBRS = string.Format("UPDATE ТормозныеСуппорта SET ПроизводиласьЗаменаРаз = {0}, ОстаточныйРесурсДетали = {1} WHERE ТормозныеСуппорта = {2}", breaksuppCount, breaksuppKilomOstatok, breaksuppId);
            database.Update(queryUpdateBRS);

            string queryUpdateBRD = string.Format("UPDATE ТормозныеДиски SET ПроизводиласьЗаменаРаз = {0}, ОстаточныйРесурсДетали = {1} WHERE ТормозныеДиски = {2}", breakdiscCount, breakdiscKilomOstatok, breakdiscId);
            database.Update(queryUpdateBRD);

            string queryUpdateProkl = string.Format("UPDATE Прокладки SET ПроизводиласьЗаменаРаз = {0}, ОстаточныйРесурсДетали = {1} WHERE Прокладки = {2}", proklCount, proklKilomOstatok, proklId);
            database.Update(queryUpdateProkl);

            string queryUpdateGRM = string.Format("UPDATE РемниГРМ SET ПроизводиласьЗаменаРаз = {0}, ОстаточныйРесурсДетали = {1} WHERE РемниГРМ = {2}", grmCount, grmKilomOstatok, grmId);
            database.Update(queryUpdateGRM);

            string queryUpdateGBC = string.Format("UPDATE ГБЦ SET ПроизводиласьЗаменаРаз = {0}, ОстаточныйРесурсДетали = {1} WHERE ГБЦ = {2}", gbcCount, gbcKilomOstatok, gbcId);
            database.Update(queryUpdateGBC);

            string queryUpdateBC = string.Format("UPDATE БлокиЦилиндров SET ПроизводиласьЗаменаРаз = {0}, ОстаточныйРесурсДетали = {1} WHERE БлокиЦилиндров = {2}", bcCount, bcKilometrsOstatok, bcId);
            database.Update(queryUpdateBC);

            string queryUpdateProbeg = string.Format("UPDATE ИнформацияОбАвтомобилях SET ПробегАвтомобиля = {0} WHERE КодАвтомобиля = {1}", probeg, AutoId);
            database.Update(queryUpdateProbeg);


            CurProbeg.Text = probeg;


        }

        private void LoadDetails(string detailsType, string idDetails)
        {
            switch(detailsType)
            {
                case "BC":
                    string queryBc = string.Format("select РесурсДетали, ОстаточныйРесурсДетали, ПроизводиласьЗаменаРаз, БлокиЦилиндров from БлокиЦилиндров where БлокиЦилиндров = {0}", idDetails);
                    connection.Open();

                    OleDbCommand commandBc = new OleDbCommand(queryBc, connection);
                    OleDbDataReader readerBc = commandBc.ExecuteReader();

                    while (readerBc.Read())
                    {
                        bcKilometrs = readerBc[0].ToString();
                        bcKilometrsOstatok = readerBc[1].ToString();
                        BCKilometrs.Text = bcKilometrsOstatok;
                        bcCount = readerBc[2].ToString();
                        bcId = readerBc[3].ToString();

                        if (bcCount == "")
                        {
                            bcCount = "0";
                            BCCount.Text = bcCount;
                        }
                        else
                        {
                            BCCount.Text = bcCount;
                        }
                    }

                    if (bcKilometrs == bcKilometrsOstatok)
                    {
                        BCProcents.Text = string.Format("100 %");
                    }
                    else
                    {
                        int procentKilom = Convert.ToInt32(bcKilometrsOstatok) / (Convert.ToInt32(bcKilometrs) / 100);
                        BCProcents.Text = string.Format("{0} %", procentKilom.ToString());
                    }

                    connection.Close();
                    break;

                case "GBC":

                    string queryGbc = string.Format("select РесурсДетали, ОстаточныйРесурсДетали, ПроизводиласьЗаменаРаз, ГБЦ from ГБЦ where ГБЦ = {0}", idDetails);
                    connection.Open();

                    OleDbCommand commandGbc = new OleDbCommand(queryGbc, connection);
                    OleDbDataReader readerGbc = commandGbc.ExecuteReader();

                    while (readerGbc.Read())
                    {
                        gbcKilom = readerGbc[0].ToString();
                        gbcKilomOstatok = readerGbc[1].ToString();
                        GBCKilom.Text = gbcKilomOstatok;
                        gbcCount = readerGbc[2].ToString();
                        gbcId = readerGbc[3].ToString();

                        if (gbcCount == "")
                        {
                            gbcCount = "0";
                            GBCCount.Text = gbcCount;
                        }
                        else
                        {
                           GBCCount.Text = gbcCount;
                        }
                    }

                    if (gbcKilom == gbcKilomOstatok)
                    {
                       GBCProc.Text = string.Format("100 %");
                    }
                    else
                    {
                        int procentGBC = Convert.ToInt32(gbcKilomOstatok) / (Convert.ToInt32(gbcKilom) / 100);
                        GBCProc.Text = string.Format("{0} %", procentGBC.ToString());
                    }

                    connection.Close();

                    break;

                case "GRM":
                    string queryGrm = string.Format("select РесурсДетали, ОстаточныйРесурсДетали, ПроизводиласьЗаменаРаз, РемниГРМ from РемниГРМ where РемниГРМ = {0}", idDetails);
                    connection.Open();

                    OleDbCommand commandGrm = new OleDbCommand(queryGrm, connection);
                    OleDbDataReader readerGrm = commandGrm.ExecuteReader();

                    while (readerGrm.Read())
                    {
                        grmKilom = readerGrm[0].ToString();
                        grmKilomOstatok = readerGrm[1].ToString();
                        GRMKillom.Text = grmKilomOstatok;
                        grmCount = readerGrm[2].ToString();
                        grmId = readerGrm[3].ToString();

                        if (grmCount == "")
                        {
                            grmCount = "0";
                            GRMCount.Text = grmCount;
                        }
                        else
                        {
                            GRMCount.Text = grmCount;
                        }
                    }

                    if (grmKilom == grmKilomOstatok)
                    {
                        GRMProc.Text = string.Format("100 %");
                    }
                    else
                    {
                        int procentGRM = Convert.ToInt32(grmKilomOstatok) / (Convert.ToInt32(grmKilom) / 100);
                        GRMProc.Text = string.Format("{0} %", procentGRM.ToString());
                    }

                    readerGrm.Close();
                    connection.Close();
                    break;

                case "Prokl":
                    string queryProkl = string.Format("select РесурсДетали, ОстаточныйРесурсДетали, ПроизводиласьЗаменаРаз, Прокладки from Прокладки where Прокладки = {0}", idDetails);
                    connection.Open();

                    OleDbCommand commandProkl = new OleDbCommand(queryProkl, connection);
                    OleDbDataReader readerProkl = commandProkl.ExecuteReader();

                    while (readerProkl.Read())
                    {
                        proklKilom = readerProkl[0].ToString();
                        proklKilomOstatok = readerProkl[1].ToString();
                        ProkladkiKM.Text = proklKilomOstatok;
                        proklCount = readerProkl[2].ToString();
                        proklId = readerProkl[3].ToString();

                        if (proklCount == "")
                        {
                            proklCount = "0";
                            ProkladkiCount.Text = proklCount;
                        }
                        else
                        {
                            ProkladkiCount.Text = proklCount;
                        }
                    }

                    if (proklKilom == proklKilomOstatok)
                    {
                        ProkladkiProc.Text = string.Format("100 %");
                    }
                    else
                    {
                        int procentProkl = Convert.ToInt32(proklKilomOstatok) / (Convert.ToInt32(proklKilom) / 100);
                        ProkladkiProc.Text = string.Format("{0} %", procentProkl.ToString());
                    }

                    connection.Close();
                    break;

                case "Breaksupport":

                    string querySupp = string.Format("select РесурсДетали, ОстаточныйРесурсДетали, ПроизводиласьЗаменаРаз, ТормозныеСуппорта from ТормозныеСуппорта WHERE ТормозныеСуппорта = {0} ", idDetails);
                    connection.Open();

                    OleDbCommand commandSupp = new OleDbCommand(querySupp, connection);
                    OleDbDataReader readerSupp = commandSupp.ExecuteReader();

                    while (readerSupp.Read())
                    {
                        breaksuppKilom = readerSupp[0].ToString();
                        breaksuppKilomOstatok = readerSupp[1].ToString();
                        BreakSupKM.Text = breaksuppKilomOstatok;
                        breaksuppCount = readerSupp[2].ToString();
                        breaksuppId = idDetails.ToString();

                        if (breaksuppCount == "")
                        {
                            breaksuppCount = "0";
                            BreakSuppCount.Text = breaksuppCount;
                        }
                        else
                        {
                            BreakSuppCount.Text = breaksuppCount;
                        }
                    }

                    if (breaksuppKilom == breaksuppKilomOstatok)
                    {
                        BreakSuppProc.Text = string.Format("100 %");
                    }
                    else
                    {
                        int procentSupp = Convert.ToInt32(breaksuppKilomOstatok) / (Convert.ToInt32(breaksuppKilom) / 100);
                        BreakSuppProc.Text = string.Format("{0} %", procentSupp.ToString());
                    }

                    connection.Close();
                    break;

                case "BreakDisc":

                    string queryDisc = string.Format("select РесурсДетали, ОстаточныйРесурсДетали, ПроизводиласьЗаменаРаз, ТормозныеДиски from ТормозныеДиски WHERE ТормозныеДиски = {0} ", idDetails);
                    connection.Open();

                    OleDbCommand commandDisc = new OleDbCommand(queryDisc, connection);
                    OleDbDataReader readerDisc = commandDisc.ExecuteReader();

                    while (readerDisc.Read())
                    {
                        breakdiscKilom = readerDisc[0].ToString();
                        breakdiscKilomOstatok = readerDisc[1].ToString();
                        BreakDiscKM.Text = breakdiscKilomOstatok;
                        breakdiscCount = readerDisc[2].ToString();
                        breakdiscId = idDetails.ToString();

                        if (breakdiscCount == "")
                        {
                            breakdiscCount = "0";
                            BreakDiscCount.Text = breakdiscCount;
                        }
                        else
                        {
                            BreakDiscCount.Text = breakdiscCount;
                        }
                    }

                    if (breakdiscKilom == breakdiscKilomOstatok)
                    {
                        BreakDiscProc.Text = string.Format("100 %");
                    }
                    else
                    {
                        int procentDisc = Convert.ToInt32(breakdiscKilomOstatok) / (Convert.ToInt32(breakdiscKilom) / 100);
                        BreakDiscProc.Text = string.Format("{0} %", procentDisc.ToString());
                    }

                    connection.Close();
                    break;

                case "BreakKol":

                    string queryKol = string.Format("select РесурсДетали, ОстаточныйРесурсДетали, ПроизводиласьЗаменаРаз, ТормозныеКолодки from ТормозныеКолодки WHERE ТормозныеКолодки = {0} ", idDetails);
                    connection.Open();

                    OleDbCommand commandKol= new OleDbCommand(queryKol, connection);
                    OleDbDataReader readerKol = commandKol.ExecuteReader();

                    while (readerKol.Read())
                    {
                        breakkolKilom = readerKol[0].ToString();
                        breakkolKilomOstatok = readerKol[1].ToString();
                        BreakKolKM.Text = breakkolKilomOstatok;
                        breakkolCount = readerKol[2].ToString();
                        breakkolId = idDetails.ToString();

                        if (breakkolCount == "")
                        {
                            breakkolCount = "0";
                            BreakKolCount.Text = breakkolCount;
                        }
                        else
                        {
                            BreakKolCount.Text = breakkolCount;
                        }
                    }

                    if (breakkolKilom == breakkolKilomOstatok)
                    {
                        BreakKolProc.Text = string.Format("100 %");
                    }
                    else
                    {
                        int procentKol = Convert.ToInt32(breakkolKilomOstatok) / (Convert.ToInt32(breakkolKilom) / 100);
                        BreakKolProc.Text = string.Format("{0} %", procentKol.ToString());
                    }

                    connection.Close();
                    break;

                case "Amort":

                    string queryAmo = string.Format("select РесурсДетали, ОстаточныйРесурсДетали, ПроизводиласьЗаменаРаз, Амортизаторы from Амортизаторы WHERE Амортизаторы = {0} ", idDetails);
                    connection.Open();

                    OleDbCommand commandAmo = new OleDbCommand(queryAmo, connection);
                    OleDbDataReader readerAmo = commandAmo.ExecuteReader();

                    while (readerAmo.Read())
                    {
                        amorKilom = readerAmo[0].ToString();
                        amorOstatok = readerAmo[1].ToString();
                        AmorKM.Text = amorOstatok;
                        amorCount = readerAmo[2].ToString();
                        amorId = idDetails.ToString();

                        if (amorCount == "")
                        {
                            amorCount = "0";
                            AmorCount.Text = amorCount;
                        }
                        else
                        {
                            AmorCount.Text = amorCount;
                        }
                    }

                    if (amorKilom == amorOstatok)
                    {
                        AmorProc.Text = string.Format("100 %");
                    }
                    else
                    {
                        int procentAmor = Convert.ToInt32(amorOstatok) / (Convert.ToInt32(amorKilom) / 100);
                        AmorProc.Text = string.Format("{0} %", procentAmor.ToString());
                    }

                    connection.Close();
                    break;

                case "Podv":

                    string queryPodv = string.Format("select РесурсДетали, ОстаточныйРесурсДетали, ПроизводиласьЗаменаРаз, ДеталиПодвески from ДеталиПодвески WHERE ДеталиПодвески = {0} ", idDetails);
                    connection.Open();

                    OleDbCommand commandPodv = new OleDbCommand(queryPodv, connection);
                    OleDbDataReader readerPodv = commandPodv.ExecuteReader();

                    while (readerPodv.Read())
                    {
                        podvKilom = readerPodv[0].ToString();
                        podvOstatok = readerPodv[1].ToString();
                        PodvKm.Text = podvOstatok;
                        podvCount = readerPodv[2].ToString();
                        podvId = idDetails.ToString();

                        if (podvCount == "")
                        {
                            podvCount = "0";
                            PodvCount.Text = podvCount;
                        }
                        else
                        {
                            PodvCount.Text = podvCount;
                        }
                    }

                    if (podvKilom == podvOstatok)
                    {
                        PodvProc.Text = string.Format("100 %");
                    }
                    else
                    {
                        int procentPodv = Convert.ToInt32(podvOstatok) / (Convert.ToInt32(podvKilom) / 100);
                        PodvProc.Text = string.Format("{0} %", procentPodv.ToString());
                    }

                    connection.Close();
                    break;

                case "Tygi":

                    string queryTygi = string.Format("select РесурсДетали, ОстаточныйРесурсДетали, ПроизводиласьЗаменаРаз, РулевыеТяги from РулевыеТяги WHERE РулевыеТяги = {0} ", idDetails);
                    connection.Open();

                    OleDbCommand commandTygi = new OleDbCommand(queryTygi, connection);
                    OleDbDataReader readerTygi = commandTygi.ExecuteReader();

                    while (readerTygi.Read())
                    {
                        tygiKilom = readerTygi[0].ToString();
                        tygiOstatok = readerTygi[1].ToString();
                        TygiKM.Text = tygiOstatok;
                        tygiCount = readerTygi[2].ToString();
                        tygiId = idDetails.ToString();

                        if (tygiCount == "")
                        {
                            tygiCount = "0";
                            TygiCount.Text = tygiCount;
                        }
                        else
                        {
                            TygiCount.Text = tygiCount;
                        }
                    }

                    if (tygiKilom == tygiOstatok)
                    {
                        TygiProc.Text = string.Format("100 %");
                    }
                    else
                    {
                        int procentTygi = Convert.ToInt32(tygiOstatok) / (Convert.ToInt32(tygiKilom) / 100);
                        TygiProc.Text = string.Format("{0} %", procentTygi.ToString());
                    }

                    connection.Close();
                    break;

                case "Rad":

                    string queryRad = string.Format("select РесурсДетали, ОстаточныйРесурсДетали, ПроизводиласьЗаменаРаз, Радиаторы from Радиаторы WHERE Радиаторы = {0} ", idDetails);
                    connection.Open();

                    OleDbCommand commandRad= new OleDbCommand(queryRad, connection);
                    OleDbDataReader readerRad= commandRad.ExecuteReader();

                    while (readerRad.Read())
                    {
                        radKilom = readerRad[0].ToString();
                        radOstatok = readerRad[1].ToString();
                        RadKM.Text = radOstatok;
                        radCount = readerRad[2].ToString();
                        radId = idDetails.ToString();

                        if (radCount == "")
                        {
                            radCount = "0";
                            RadCount.Text = radCount;
                        }
                        else
                        {
                            RadCount.Text = radCount;
                        }
                    }

                    if (radKilom == radOstatok)
                    {
                        RadProc.Text = string.Format("100 %");
                    }
                    else
                    {
                        int procentRad = Convert.ToInt32(radOstatok) / (Convert.ToInt32(radKilom) / 100);
                        RadProc.Text = string.Format("{0} %", procentRad.ToString());
                    }

                    connection.Close();
                    break;

                case "Ter":

                    string queryTer = string.Format("select РесурсДетали, ОстаточныйРесурсДетали, ПроизводиласьЗаменаРаз, Термостаты from Термостаты WHERE Термостаты = {0} ", idDetails);
                    connection.Open();

                    OleDbCommand commandTer = new OleDbCommand(queryTer, connection);
                    OleDbDataReader readerTer = commandTer.ExecuteReader();

                    while (readerTer.Read())
                    {
                        terKilom = readerTer[0].ToString();
                        terOstatok = readerTer[1].ToString();
                        TerKM.Text = terOstatok;
                        terCount = readerTer[2].ToString();
                        terId = idDetails.ToString();

                        if (terCount == "")
                        {
                            terCount = "0";
                            TerCount.Text = terCount;
                        }
                        else
                        {
                            TerCount.Text = terCount;
                        }
                    }

                    if (terKilom == terOstatok)
                    {
                        TerProc.Text = string.Format("100 %");
                    }
                    else
                    {
                        int procentTer = Convert.ToInt32(terOstatok) / (Convert.ToInt32(terKilom) / 100);
                        TerProc.Text = string.Format("{0} %", procentTer.ToString());
                    }

                    connection.Close();
                    break;

                case "Pom":

                    string queryPom = string.Format("select РесурсДетали, ОстаточныйРесурсДетали, ПроизводиласьЗаменаРаз, ВодяныеПомпы from ВодяныеПомпы WHERE ВодяныеПомпы = {0} ", idDetails);
                    connection.Open();

                    OleDbCommand commandPom = new OleDbCommand(queryPom, connection);
                    OleDbDataReader readerPom = commandPom.ExecuteReader();

                    while (readerPom.Read())
                    {
                        pomKilom = readerPom[0].ToString();
                        pomOstatok = readerPom[1].ToString();
                        PomKM.Text = pomOstatok;
                        pomCount = readerPom[2].ToString();
                        pomId = idDetails.ToString();

                        if (pomCount == "")
                        {
                            pomCount = "0";
                            PomCount.Text = pomCount;
                        }
                        else
                        {
                            PomCount.Text = pomCount;
                        }
                    }

                    if (pomKilom == pomOstatok)
                    {
                        PomProc.Text = string.Format("100 %");
                    }
                    else
                    {
                        int procentPom = Convert.ToInt32(pomOstatok) / (Convert.ToInt32(pomKilom) / 100);
                        PomProc.Text = string.Format("{0} %", procentPom.ToString());
                    }

                    connection.Close();
                    break;

                case "Dat":

                    string queryDat = string.Format("select РесурсДетали, ОстаточныйРесурсДетали, ПроизводиласьЗаменаРаз, Датчики from Датчики WHERE Датчики = {0} ", idDetails);
                    connection.Open();

                    OleDbCommand commandDat = new OleDbCommand(queryDat, connection);
                    OleDbDataReader readerDat = commandDat.ExecuteReader();

                    while (readerDat.Read())
                    {
                        datKilom = readerDat[0].ToString();
                        datOstatok = readerDat[1].ToString();
                        DatKM.Text = datOstatok;
                        datCount = readerDat[2].ToString();
                        datId = idDetails.ToString();

                        if (datCount == "")
                        {
                            datCount = "0";
                            DatCount.Text = datCount;
                        }
                        else
                        {
                            DatCount.Text = datCount;
                        }
                    }

                    if (datKilom == datOstatok)
                    {
                        DatProc.Text = string.Format("100 %");
                    }
                    else
                    {
                        int procentDat = Convert.ToInt32(datOstatok) / (Convert.ToInt32(datKilom) / 100);
                        DatProc.Text = string.Format("{0} %", procentDat.ToString());
                    }

                    connection.Close();
                    break;

                case "Lam":

                    string queryLam = string.Format("select РесурсДетали, ОстаточныйРесурсДетали, ПроизводиласьЗаменаРаз, Лампочки from Лампочки WHERE Лампочки = {0} ", idDetails);
                    connection.Open();

                    OleDbCommand commandLam = new OleDbCommand(queryLam, connection);
                    OleDbDataReader readerLam = commandLam.ExecuteReader();

                    while (readerLam.Read())
                    {
                        lamKilom = readerLam[0].ToString();
                        lamOstatok = readerLam[1].ToString();
                        LamKM.Text = lamOstatok;
                        lamCount = readerLam[2].ToString();
                        lamId = idDetails.ToString();

                        if (lamCount == "")
                        {
                            lamCount = "0";
                            LamCount.Text = lamCount;
                        }
                        else
                        {
                            LamCount.Text = lamCount;
                        }
                    }

                    if (lamKilom == lamOstatok)
                    {
                        LamProc.Text = string.Format("100 %");
                    }
                    else
                    {
                        int procentLam = Convert.ToInt32(lamOstatok) / (Convert.ToInt32(lamKilom) / 100);
                        LamProc.Text = string.Format("{0} %", procentLam.ToString());
                    }

                    connection.Close();
                    break;

                case "Gen":

                    string queryGen = string.Format("select РесурсДетали, ОстаточныйРесурсДетали, ПроизводиласьЗаменаРаз, Генераторы from Генераторы WHERE Генераторы = {0} ", idDetails);
                    connection.Open();

                    OleDbCommand commandGen = new OleDbCommand(queryGen, connection);
                    OleDbDataReader readerGen = commandGen.ExecuteReader();

                    while (readerGen.Read())
                    {
                        genKilom = readerGen[0].ToString();
                        genOstatok = readerGen[1].ToString();
                        GenKM.Text = genOstatok;
                        genCount = readerGen[2].ToString();
                        genId = idDetails.ToString();

                        if (genCount == "")
                        {
                            genCount = "0";
                            GenCount.Text = genCount;
                        }
                        else
                        {
                            GenCount.Text = genCount;
                        }
                    }

                    if (genKilom == genOstatok)
                    {
                        GenProc.Text = string.Format("100 %");
                    }
                    else
                    {
                        int procentGen = Convert.ToInt32(lamOstatok) / (Convert.ToInt32(genKilom) / 100);
                        GenProc.Text = string.Format("{0} %", procentGen.ToString());
                    }

                    connection.Close();
                    break;

                case "Sta":

                    string querySta = string.Format("select РесурсДетали, ОстаточныйРесурсДетали, ПроизводиласьЗаменаРаз, Стартеры from Стартеры WHERE Стартеры = {0} ", idDetails);
                    connection.Open();

                    OleDbCommand commandSta = new OleDbCommand(querySta, connection);
                    OleDbDataReader readerSta = commandSta.ExecuteReader();

                    while (readerSta.Read())
                    {
                        staKilom = readerSta[0].ToString();
                        staOstatok = readerSta[1].ToString();
                        StaKM.Text = staOstatok;
                        staCount = readerSta[2].ToString();
                        staId = idDetails.ToString();

                        if (staCount == "")
                        {
                            staCount = "0";
                            StaCount.Text = staCount;
                        }
                        else
                        {
                            StaCount.Text = staCount;
                        }
                    }

                    if (staKilom == staOstatok)
                    {
                        StaProc.Text = string.Format("100 %");
                    }
                    else
                    {
                        int procentSta = Convert.ToInt32(staOstatok) / (Convert.ToInt32(staKilom) / 100);
                        StaProc.Text = string.Format("{0} %", procentSta.ToString());
                    }

                    connection.Close();
                    break;

                case "Vis":

                    string queryVis = string.Format("select РесурсДетали, ОстаточныйРесурсДетали, ПроизводиласьЗаменаРаз, ВысоковольтныеПровода from ВысоковольтныеПровода WHERE ВысоковольтныеПровода = {0} ", idDetails);
                    connection.Open();

                    OleDbCommand commandVis = new OleDbCommand(queryVis, connection);
                    OleDbDataReader readerVis = commandVis.ExecuteReader();

                    while (readerVis.Read())
                    {
                        visKilom = readerVis[0].ToString();
                        visOstatok = readerVis[1].ToString();
                        VisKm.Text = visOstatok;
                        visCount = readerVis[2].ToString();
                        visId = idDetails.ToString();

                        if (visCount == "")
                        {
                            visCount = "0";
                            VisCount.Text = visCount;
                        }
                        else
                        {
                            VisCount.Text = visCount;
                        }
                    }

                    if (visKilom == visOstatok)
                    {
                        VisProc.Text = string.Format("100 %");
                    }
                    else
                    {
                        int procentVis = Convert.ToInt32(visOstatok) / (Convert.ToInt32(visKilom) / 100);
                        VisProc.Text = string.Format("{0} %", procentVis.ToString());
                    }

                    connection.Close();
                    break;

                case "Fil":

                    string queryFil = string.Format("select РесурсДетали, ОстаточныйРесурсДетали, ПроизводиласьЗаменаРаз, Фильтра from Фильтра WHERE Фильтра = {0} ", idDetails);
                    connection.Open();

                    OleDbCommand commandFil = new OleDbCommand(queryFil, connection);
                    OleDbDataReader readerFil = commandFil.ExecuteReader();

                    while (readerFil.Read())
                    {
                        filKilom = readerFil[0].ToString();
                        filOstatok = readerFil[1].ToString();
                        FilKm.Text = filOstatok;
                        filCount = readerFil[2].ToString();
                        filId = idDetails.ToString();

                        if (filCount == "")
                        {
                            filCount = "0";
                            FilCount.Text = filCount;
                        }
                        else
                        {
                            FilCount.Text = filCount;
                        }
                    }

                    if (filKilom == filOstatok)
                    {
                        FilProc.Text = string.Format("100 %");
                    }
                    else
                    {
                        int procentFil = Convert.ToInt32(filOstatok) / (Convert.ToInt32(filKilom) / 100);
                        FilProc.Text = string.Format("{0} %", procentFil.ToString());
                    }

                    connection.Close();
                    break;

                case "Sve":

                    string querySve = string.Format("select РесурсДетали, ОстаточныйРесурсДетали, ПроизводиласьЗаменаРаз, Свечи from Свечи WHERE Свечи = {0} ", idDetails);
                    connection.Open();

                    OleDbCommand commandSve = new OleDbCommand(querySve, connection);
                    OleDbDataReader readerSve = commandSve.ExecuteReader();

                    while (readerSve.Read())
                    {
                        sveKilom = readerSve[0].ToString();
                        sveOstatok = readerSve[1].ToString();
                        SveKm.Text = sveOstatok;
                        sveCount = readerSve[2].ToString();
                        sveId = idDetails.ToString();

                        if (sveCount == "")
                        {
                            sveCount = "0";
                            SveCount.Text = sveCount;
                        }
                        else
                        {
                            SveCount.Text = sveCount;
                        }
                    }

                    if (sveKilom == sveOstatok)
                    {
                        SveProc.Text = string.Format("100 %");
                    }
                    else
                    {
                        int procentSve = Convert.ToInt32(sveOstatok) / (Convert.ToInt32(sveKilom) / 100);
                        SveProc.Text = string.Format("{0} %", procentSve.ToString());
                    }

                    connection.Close();
                    break;
            }
        }
    }
}
