using CompetFácil.Model;
using CompetiFácilLaço.Model;
using Microsoft.EntityFrameworkCore;
using System.IO;
namespace CompetFácil.Persistência
{
    internal class DataBase:DbContext
    {
        public DbSet<Laçador> Laçadores {  get; set; }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public string DbPath { get; }
        public DataBase() {
            //SQLitePCL.raw.SetProvider();
            SQLitePCL.Batteries.Init();
            string fileName = "DataBase.db";
            //criar a folder
            string pathFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");
            Directory.CreateDirectory(pathFolder);
            string path = Path.Combine(pathFolder, fileName);
            DbPath = path;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)=> optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }
}
