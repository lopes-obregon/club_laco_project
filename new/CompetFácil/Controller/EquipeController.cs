using CompetFácil.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetFácil.Controller
{
    internal class EquipeController
    {
        public static Equipe? equipe { get; private set; } =  null;

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
            }
                return null;
        }

        internal static string CadastrarEquipe(string equipeNome, List<string> membrosList)
        {
            if(!string.IsNullOrEmpty(equipeNome) && membrosList != null)
            {
                equipe = new Equipe(equipeNome);
                equipe.ListStringToLaçador(membrosList);
                if(equipe is not null)
                {
                    
                    if(Equipe.Cadastrar(equipe))
                        return $"Equipe: {equipe} cadastrado com sucesso!";
                }
                else { return "Erro no cadastro da equipe" ; }
            }
            return "Algum item faltando";

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
    }
}
