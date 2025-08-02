using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
namespace CompetiFácilLaço.Model
{
    internal class DataBase
    {
        public void Init()
    {
            string connectionString = "Data Source=competi_facil_laco.db;Version=3;";
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Laçadores (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT,
                    Escala TEXT,
                    Irmao TEXT,
                    Categoria TEXT
                );
            ";
                using (SQLiteCommand cmd = new SQLiteCommand(createTableQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Tabela já criado ou existe");
                }
            }

        }
        
    }
}
