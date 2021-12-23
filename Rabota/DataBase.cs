using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabota
{
    public class DataBase
    {
        public OleDbConnection db;
        private static string database = @"C:\database\db.accdb";
        private static string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = " + database + "; Persist Security Info=True";

        public DataBase()
        {
            db = new OleDbConnection(connection);
        }

        public void Update(string query)
        {
            db.Open();
            OleDbCommand commandUpdateProbeg = new OleDbCommand(query, db);
            commandUpdateProbeg.ExecuteNonQuery();
            db.Close();
        }

        public void AddDetails(string num, string km, string table)
        {
            db.Open();
            string query = "INSERT INTO " + table + " (Номер, РесурсДетали, ОстаточныйРесурсДетали) VALUES ('" + num + "','" + km + "','" + km + "') ";
            OleDbCommand commandUpdateProbeg = new OleDbCommand(query, db);
            commandUpdateProbeg.ExecuteNonQuery();
            db.Close();
        }

        public string GetLastDetailId(string table)
        {
            db.Open();

            string query = "select max (" + table + ") from " + table + "";

            OleDbCommand command = new OleDbCommand(query, db);

            OleDbDataReader reader = command.ExecuteReader();

            string result = string.Empty;
            while (reader.Read())
            {
                result = reader[0].ToString();
            }

            db.Close();
            return result;
        }

        public void UpdateAutoDetail(string autoId, string detailId, string detail)
        {
            db.Open();
            string query = string.Format("UPDATE ИнформацияОбАвтомобилях SET {0} = {1} WHERE КодАвтомобиля = {2}", detail, detailId, autoId);
            OleDbCommand commandUpdateProbeg = new OleDbCommand(query, db);
            commandUpdateProbeg.ExecuteNonQuery();
            db.Close();
        }
    }
}
