using CompetiFácilLaço.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetiFácilLaço.Controller
{
    internal class LaçadorController
    {
        //static List<Model.Laçador> laçadores = new List<Model.Laçador>();
        static Laçador laçador;
        internal static string CadastrarCompetidor(string nome_competidor, string tipo_competidor, string irmão, List<string> categorias)
        {
            //Laçadores.Add(new Model.Laçador(nome_competidor, tipo_competidor, irmão, ""));
            laçador = new Laçador(nome_competidor, tipo_competidor, irmão, categorias);
            return laçador.WriteTeste();


        }

       /* internal static string GravarCompetidor()
        {
            foreach (Model.Laçador laçador in laçadores)
            {
                return laçador.WriteTeste();
            }
            return "";
        }*/
    }
}
