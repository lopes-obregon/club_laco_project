using CompetiFácilLaço.Model;

namespace CompetiFácilLaço.Controller
{
    internal class LaçadorController
    {
        //static List<Model.Laçador> laçadores = new List<Model.Laçador>();
        static Laçador? laçador;

        internal static bool AlterarLaçador(Laçador? laçadorEncontrado)
        {
            if (Laçador.AlterarLaçadorDb(laçadorEncontrado))
            {
                return true;
            }else { return false; }
        }

        internal static string CadastrarCompetidor(string nome_competidor, string sobreNome, string tipo_competidor, object? irmão, List<string> categorias)
        {
            //Laçadores.Add(new Model.Laçador(nome_competidor, tipo_competidor, irmão, ""));
            if (irmão == null)
            {
                laçador = new Laçador(nome_competidor, sobreNome, tipo_competidor, null, categorias);

            }
            else { 
                if(irmão is Laçador irmãoLaçador)
                {
                    laçador = new Laçador(nome_competidor, sobreNome, tipo_competidor, irmãoLaçador, categorias);

                }
                else
                {
                    laçador = new Laçador(nome_competidor, sobreNome, tipo_competidor, null, categorias);

                }
                
            }
                //return laçador.WriteTeste();
                //return Laçador.SaveJson(laçador);
                return Laçador.SaveDb(laçador);


        }
        internal static Laçador? ConsultarLaçador(string nomeCompetidor)
        {
            Laçador? laçador;
            laçador = Laçador.ConsultarLaçadorDb( nomeCompetidor);
            if(laçador == null)
            {
                return null;

            }
            else
            {
                return laçador;
            }
        }

        internal static List<Laçador> GetLaçadores()
        {
            List<Laçador> laçadores = Laçador.GetLaçdores();
            if(laçadores == null)
            {
                return null;
            }
            else
            {
                return laçadores;
            }
        }

        internal static bool RemoveLaçador(Laçador? laçador)
        {
            bool laçadorRemovido = Laçador.Remove(laçador);
            if (laçadorRemovido) { return true; }
            else { return false; }
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
