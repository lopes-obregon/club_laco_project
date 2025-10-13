using CompetFácil.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace CompetFácil.Controller
{
    internal class EquipeController
    {
        public static Equipe? equipe { get; private set; } =  null;
        private static List<Equipe>? equipes = null;
        private static int indexEquipes = 0;
        public static List<Equipe>? Equipes { get => equipes; set => equipes = value; }
        internal static string? AtualizarEquipe(string nameTeam, List<string> membroList)
        {
            //se equipe não é nulo e string são iguais
            //caso em que alterou o membro list apenas.
            if(equipe is not null && String.Equals(nameTeam, equipe.NomeEquipe) )
            {
                //alterou apenas os membros da equipe
                bool membrosAtualizados = equipe.AtualizarMembros(membroList);
                if (membrosAtualizados)
                    return "Membros Atualizados com sucesso!";
                else
                    return "Falha em atualizar a equipe!";
            }else if(equipe is not null && !String.Equals(nameTeam, equipe.NomeEquipe))
            {
                //alterou o nome da equipe
                bool nomeAtualizado = equipe.AtualizarNome(nameTeam);
                if (nomeAtualizado) return "Nome atualizado com sucesso!";
                else return "Falha ao atualizar o nome!";
            }
                return null;
        }

        internal static string CadastrarEquipe(string equipeNome, List<string> membrosList)
        {
            if(!string.IsNullOrEmpty(equipeNome) && membrosList != null)
            {
                equipe = Equipe.Exist(equipeNome);
                if(equipe is not null)
                {
                    equipe.ListStringToLaçador(membrosList);
                    
                    if(Equipe.Cadastrar(equipe))
                        return $"Equipe: {equipe} cadastrado com sucesso!";
                }
                else { return "Erro no cadastro da equipe" ; }
            }
            return "Algum item faltando";

        }
        //limpa a referencia do objeto ou seja libera o objeto
        internal static void Clear()
        {
            if(equipe is not null)
                equipe = null;
        }

        internal static void ConsultarEquipe(string text)
        {
            if (!String.IsNullOrEmpty(text))
            {
                if (equipe is null)
                {
                    equipe = Equipe.Consultar(text);
                    
                }
                else
                {
                    if (!String.Equals(equipe.NomeEquipe, text))
                    {
                        equipe = Equipe.Consultar(text);
                    }
                }
            }
           
        }

        internal static void LoadEquipes()
        {
            equipes = new List<Equipe>();
            var equipeList = Equipe.GetEquipes();
            if(equipeList is not null)
                equipes.AddRange(equipeList);
        }

        internal static string? Remover(string equipeNome)
        {
            bool remove = false;
            if (equipe is null)
                return "Algo deu errado!";
            else if(!String.IsNullOrEmpty(equipeNome))
            {
                if (equipe is not null)
                {
                    if(equipe.NomeEquipe == equipeNome)
                    {
                         remove = equipe.Remove();
                        equipe = null;
                    }
                }
                if(remove)
                    return "Equipe Removida com sucesso!";
            }
            return null;
        }

        internal static void SetTableData(int id, int idEquipe, List<string> pontos)
        {
            List<byte> pontosMarcados = new List<byte>();
            if(equipes is not null)
            {
                var equipeBuscada = equipes.Find(e => e.Id == idEquipe);
                if (equipeBuscada is not null)
                {
                    var laBuscado = equipeBuscada.Laçadores.Find(la => la.Id == id);
                    if (laBuscado is not null)
                    {
                        foreach (var pnt in pontos)
                        {
                            if (pnt == "Positivo")
                                pontosMarcados.Add(1);
                            else if (pnt == "Negativo")
                                pontosMarcados.Add(2);
                            else if (pnt == "")
                                pontosMarcados.Add(0);
                        }
                        laBuscado.Pontos = pontosMarcados.ToArray();
                    }
                }
            }
        }

        internal static string SaveDataLa(int idEquipe)
        {
            bool save = false;
           if(equipes is not null)
            {
                var equipeBuscada = equipes.Find(e => e.Id ==idEquipe);
                if (equipeBuscada is not null)
                {
                    save = Equipe.SaveDataPntLa(equipeBuscada);
                }

            }
            if (save)
                return "Dados Salvo Com Sucesso!";
            else
                return "Erro ao Salvar os dados";
        }

        internal static Equipe? EquipesGetCurrent()
        {
            Equipe? equipe = null;
            if(equipes is not null)
            {

                equipe = equipes[indexEquipes];
                return equipe;

            }
            else
            {
                return null;
            }
        }

        internal static void PróximaEquipe()
        {
            if (equipes is not null && indexEquipes < equipes.Count - 1)
                indexEquipes++;
            else if (equipes is not null && indexEquipes > equipes.Count - 1)
                indexEquipes = equipes.Count - 1;
           
        }

        internal static void VoltarEquipes()
        {
            if(equipes is not null && indexEquipes > 0)
                indexEquipes--;
            else if (equipes is not null && indexEquipes == 0)
                indexEquipes = 0;
        }
    }
}
