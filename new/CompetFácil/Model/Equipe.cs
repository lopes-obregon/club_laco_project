using CompetFácil.Persistência;
using CompetiFácilLaço.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetFácil.Model
{
    
    internal class Equipe
    {


        public int Id { get; private set; }
        public string? NomeEquipe { get; private set; }
        public DateTime DataCriação { get; private set; }
        public List<Laçador> Laçadores { get; private set; } = new List<Laçador>();
        public Equipe() { }
        public Equipe(string equipeNome)
        {
            if (string.IsNullOrEmpty(equipeNome))
                NomeEquipe = "";
            NomeEquipe = equipeNome;
            
        }

        internal static void Cadastrar(string equipeNome, List<string> membrosList)
        {
            throw new NotImplementedException();
        }

        internal void ListStringToLaçador(List<string> membrosList)
        {
            foreach (var item in membrosList)
            {
                //separar pelo hífen
                string[] partes = item.Split('-');
                int id = int.Parse(partes[0].Trim());
                var laçadorNoBanco = Laçador.GetLaçadorComId(id);
                if (laçadorNoBanco is not  null)
                    this.Laçadores.Add(laçadorNoBanco);
                  
            }
        }
        public override string ToString()
        {
            return $"{this.Id} - {this.NomeEquipe}";
        }

        internal static bool Cadastrar(Equipe novaEquipe)
        {
            using DataBase dataBase = new DataBase();
            dataBase.Database.EnsureCreated();// cria as tabelas casa não exista conforme os métodos
            bool sucesso = false;
            try
            {
                novaEquipe.Id = 0;//garantir que sempre vai ter um novo id
                //associar a equipe 
                foreach (var item in novaEquipe.Laçadores)
                {
                    dataBase.Entry(item).State = EntityState.Unchanged;
                }
                dataBase.Equipes.Add(novaEquipe);//adiciona ao contexto
                //salva as alterações
                dataBase.SaveChanges();
                sucesso = true;
            }
            catch { sucesso = false; }
            return sucesso;
        }
    }
}
