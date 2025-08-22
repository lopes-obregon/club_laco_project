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
        static Equipe? equipe;
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
    }
}
