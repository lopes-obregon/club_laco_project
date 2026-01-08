using CompetFácil.Persistência;
using CompetiFácilLaço.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
                foreach (var laçador in novaEquipe.Laçadores)
                {
                    laçador.Equipe = novaEquipe;
                    //contexto precisa saber que houve modificações
                    dataBase.Entry(laçador).State = EntityState.Modified;
                }
                dataBase.Equipes.Add(novaEquipe);//adiciona ao contexto
                //salva as alterações
                dataBase.SaveChanges();
                sucesso = true;
            }
            catch { sucesso = false; }
            return sucesso;
        }

        internal static Equipe? Consultar(string text)
        {
            using DataBase dados = new DataBase();
            try
            {
                var equipeBuscado = dados.Equipes.Include(equipe => equipe.Laçadores).FirstOrDefault(equipe => equipe.NomeEquipe == text);
                Equipe? equipeEncontrada = equipeBuscado as Equipe;
                return equipeEncontrada;
            }
            catch { return null; }
        }

        internal bool AtualizarMembros(List<string> membroList)
        {
            using DataBase dados = new DataBase();
           
            List<Laçador> laçadorNãoRemovido = ListStringToLaçadorList(membroList);
            try
            {
                
                   

                var removidos = Laçadores.Where(original => !laçadorNãoRemovido.Any(atual => atual.Id == original.Id)).ToList();
                foreach (Laçador la in removidos)
                {

                    Laçador? laBanco = dados.Laçadores
                        .Include(l => l.Equipe)
                        .FirstOrDefault(l => l.Id == la.Id);

                    if (laBanco is not null)
                    {
                        laBanco.Equipe = null;//quebra o vinculo
                                              //marca como estado alterado
                        dados.Entry(laBanco).State = EntityState.Modified;
                        //remove da lista
                    }
                    Laçadores.Remove(la);
                    


                }
                //ENTÃO TEMOS QUE ALTERAR OS COMPETIDORES 
                var equipeDb = dados.Equipes.FirstOrDefault(eq => eq.Id == this.Id);
                if (equipeDb is not null)
                {
                    foreach (Laçador la in laçadorNãoRemovido)
                    {
                        var laçadorBuscado = dados.Laçadores.FirstOrDefault(ldb => ldb.Id == la.Id);
                        if (laçadorBuscado is not null && la.Equipe is not null)
                        {
                            la.Equipe = equipeDb;
                            laçadorBuscado.Equipe = equipeDb;
                        }
                    }
                }
                //dados.Equipes.Update(this);
                dados.SaveChanges();
                return true;
              

            }catch { return false; }
        }

        private List<Laçador> ListStringToLaçadorList(List<string> membroList)
        {
            List<Laçador> laçadors = new List<Laçador>();
            foreach (var membro in membroList)
            {
                //separar por hifem
                string[] partes = membro.Split('-');
                //treim para remover espaços
                int id = int.Parse(partes[0].Trim());
                var laçadorBanco = Laçador.GetLaçadorComId(id);
                if(laçadorBanco is not null)
                {
                    laçadors.Add(laçadorBanco as Laçador);
                }
            }
            return laçadors;
        }

        internal bool AtualizarNome(string nameTeam)
        {
           using DataBase dados = new DataBase();
            try
            {
                var equipe = dados.Equipes.Find(this.Id);
                if (equipe is not null)
                {
                    equipe.NomeEquipe = nameTeam;
                    NomeEquipe = nameTeam;
                }
                dados.SaveChanges();
                return true;
            }catch (Exception ex) { return false; }
        }

        internal bool Remove()
        {
            using DataBase data = new DataBase();
            try
            {
                var equipe = data.Equipes
                    .Include(e => e.Laçadores)
                    .FirstOrDefault(eq => eq.Id == Id);
                if( equipe is not null )
                {
                    foreach(Laçador la in equipe.Laçadores)
                    {
                        if( la.Equipe is not null && la.Equipe.Id == Id)
                        {
                            la.Equipe = null;
                        }
                    }


                    data.Equipes.Remove(equipe);
                    data.SaveChanges();
                }
                return true;
            }catch (Exception ex) { return false; }
        }

        internal static IEnumerable<Equipe>? GetEquipes()
        {
            using DataBase db = new DataBase();
            try
            {
                return db.Equipes.Include(e => e.Laçadores).ToList();
            }catch (Exception ex) { return null; }
        }

        internal static Equipe? Exist(string equipeNome)
        {
            using (DataBase db = new DataBase())
            {
                try
                {
                    var equipeExistente = db.Equipes.FirstOrDefault(e => e.NomeEquipe == equipeNome);
                    if (equipeExistente is not null)
                        return null;
                    else
                        return new Equipe(equipeNome);
                }
                catch (Exception ex) { return null; }
            }
        }

        internal static bool SaveDataPntLa(Equipe equipeBuscada)
        {
            bool save = false;
            foreach (var la in equipeBuscada.Laçadores)
            {
                save = Laçador.SavePnt(la);
            }
            return save;
        }

        internal static Equipe? GetEquipe(Equipe? equipeSelecionado)
        {
            using DataBase db = new DataBase();
            Equipe? equipe = null;
            try
            {
                if (equipeSelecionado is not null)
                {
                    var equipeDb = db.Equipes.Include(eq => eq.Laçadores).FirstOrDefault(eq => eq.Id == equipeSelecionado.Id);
                    if (equipeDb is not null)
                        equipe = equipeDb;

                }
                return equipe;
            }
            catch { return equipe; }
        }
    }
}
