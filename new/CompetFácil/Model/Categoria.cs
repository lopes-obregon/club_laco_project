using CompetiFácilLaço.Model;
using CompetFácil.Persistência;
using Microsoft.EntityFrameworkCore;

namespace CompetFácil.Model
{
    internal class Categoria
    {
        private int id;
        private string nome = "";
        private List<Laçador>? laçadores = new();
        
        public Categoria()
        {
          
        }
        public Categoria(int id)
        {
            this.id = id;
        }
        public Categoria(string nome)
        {
            this.nome = nome;
        }
        public Categoria(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }
        public int Id { get => id; set => id = value; }
        //public gett sett
        public string Nome { get => nome; set => nome = value; }
        public List<Laçador> Laçadores { get { return laçadores; } set => laçadores = value; }
        //cadastra a categoria no banco de dados.
        internal static bool Cadastrar(Categoria novaCategoria)
        {
            using DataBase db = new DataBase();
            try
            {
                //cria as tabelas caso a inda não criou
                db.Database.EnsureCreated();
                novaCategoria.Id = 0; //GARANTINDO QUE VAI ter novo id
                db.Categorias.Add(novaCategoria);
                db.SaveChanges();
                return true;
            }
            catch {  return false; }
        }

        internal static IEnumerable<Categoria>? GetCategorias()
        {
            using DataBase dataBase = new DataBase();
            try
            {
                return dataBase.Categorias.Include(c => c.Laçadores).ToList();
            }
            catch { return null; }
        }

        internal static bool Remove(Categoria categoria)
        {
            using DataBase db = new DataBase();
            try
            {
                if(categoria is not null)
                {
                    categoria.laçadores = null;
                    db.Categorias.Remove(categoria);
                    db.SaveChanges();
                    return true;
                }
            }catch { return false; }
            return false;
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
