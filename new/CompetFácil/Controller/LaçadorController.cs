using CompetFácil.Model;
using CompetiFácilLaço.Model;

namespace CompetiFácilLaço.Controller
{
    internal class LaçadorController
    {
        //static List<Model.Laçador> laçadores = new List<Model.Laçador>();
        static Laçador? laçador;

        /*internal static bool AlterarLaçador(Laçador? laçadorEncontrado, object? irmão)
        {
            if(irmão == null)
            if (Laçador.AlterarLaçadorDb(laçadorEncontrado))
            {
                return true;
            }else { return false; }
        }*/

        internal static bool AlterarLaçador(List<object?> laçadoresList, string nomeTextBox, string sobreNomeTexBox, string posição, bool temIrmão, object? irmãoSelecionado, ListBox.ObjectCollection categoriasObject)
        {
            bool result = false;
            sbyte contadorDeSucesso = 0;
            var categorias = categoriasObject.Cast<Categoria>().ToList();
            foreach (Laçador? la in laçadoresList)
            {
                if (la == null)
                {
                    result = false;
                }
                else
                {
                    if (!String.IsNullOrEmpty(nomeTextBox) && !String.Equals(la.Nome, nomeTextBox))
                    {
                        contadorDeSucesso += Laçador.AlterarLaçadorDb(la, nomeTextBox, null, "", null, null);
                        
                    }
                    if (!String.IsNullOrEmpty(sobreNomeTexBox) && !String.Equals(la.SobreNome, sobreNomeTexBox))
                    {

                        contadorDeSucesso += Laçador.AlterarLaçadorDb(la, null, sobreNomeTexBox, "", null, null);

                    }
                    if (!String.IsNullOrEmpty(posição) && !String.Equals(la.Escala, posição))
                    {


                        contadorDeSucesso += Laçador.AlterarLaçadorDb(la, null, null, posição, null, null);

                    }
                    if (temIrmão) { 
                        if(irmãoSelecionado is Laçador)
                        {
                            contadorDeSucesso += Laçador.AlterarLaçadorDb(la, null, null, null, irmãoSelecionado, null);
                        }
                    
                    }
                    if(categorias != null)
                    {
                        if(la.Categorias is not null)
                        {
                            var listaAntiga = la.Categorias.Except(categorias).ToList();
                            var listaNova = categorias.Except(la.Categorias).ToList();
                            bool sãoDiferentes = listaAntiga.Any() || listaNova.Any();
                                //se são diferentes então salva
                                if (sãoDiferentes)
                                    contadorDeSucesso += Laçador.AlterarLaçadorDb(la, null, null, null, null, categorias);
                        }
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            if(contadorDeSucesso > 0)
            {
                result = true; //tivemos alterão bem sucedidas
            }else { result = false; }
                return result;
        }

        internal static string CadastrarCompetidor(string nome_competidor, string sobreNome, string tipo_competidor, object? irmão, ListBox.ObjectCollection ?categorias)
        {
            //Laçadores.Add(new Model.Laçador(nome_competidor, tipo_competidor, irmão, ""));
            
            var categoriasList = categorias?.Cast<Categoria>().ToList();
            if (irmão == null)
            {
               
                    laçador = new Laçador(nome_competidor, sobreNome, tipo_competidor, null, null);

            }
            else { 
                if(irmão is Laçador irmãoLaçador)
                {
                    laçador = new Laçador(nome_competidor, sobreNome, tipo_competidor, irmãoLaçador, null);

                }
                else
                {
                    laçador = new Laçador(nome_competidor, sobreNome, tipo_competidor, null, null);

                }
                
            }
                //return laçador.WriteTeste();
                //return Laçador.SaveJson(laçador);
                return Laçador.SaveDb(laçador, categoriasList);


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

        internal static Laçador? ConsultarLaçador(string nome, string sobreNome)
        {
            Laçador? laçadorBuscado = null;
            if(!String.IsNullOrEmpty(nome) && !String.IsNullOrEmpty(sobreNome))
            {
                laçadorBuscado = Laçador.ConsultarLaçadorDb(nome, sobreNome);
               
            }
            laçador = laçadorBuscado;
            return laçadorBuscado;
        }

        internal static void FreeLaçador()
        {
            if (laçador is null)
                laçador = null;
        }

        internal static int GetIdLaçador(object? laçador)
        {
            if(laçador != null)
            {
                Laçador? la = laçador as Laçador;
                if(la != null)
                    return la.Id;

            }
            else
            {
                return -1;
            }
            return 0;
        }

        internal static List<Laçador>? GetLaçadores()
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

        internal static bool RemoveLaçador()
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
