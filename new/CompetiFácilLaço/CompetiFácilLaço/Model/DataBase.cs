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
            string connectionString = "Data Source=competi_facil_laco.sqlite;Version=3;";
            using (SQLiteConnection conn = new SQLiteConnection(connectionString));

    }
    }
}
