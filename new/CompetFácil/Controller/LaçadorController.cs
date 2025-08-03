using CompetiFácilLaço.Model;

namespace CompetiFácilLaço.Controller
{
    internal class LaçadorController
    {
        //static List<Model.Laçador> laçadores = new List<Model.Laçador>();
        static Laçador laçador;
        internal static string CadastrarCompetidor(string nome_competidor, string sobreNome, string tipo_competidor, string irmão, List<string> categorias)
        {
            //Laçadores.Add(new Model.Laçador(nome_competidor, tipo_competidor, irmão, ""));
            laçador = new Laçador(nome_competidor, sobreNome, tipo_competidor, irmão, categorias);
            //return laçador.WriteTeste();
            //return Laçador.SaveJson(laçador);
            return Laçador.SaveDb(laçador);


        }
        internal static Laçador ConsultarLaçador(string nomeCompetidor)
        {
            Laçador laçador;
            laçador = Laçador.ConsultarLaçador( nomeCompetidor);
            if(laçador == null)
            {
                return null;

            }
            else
            {
                return laçador;
            }
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
