using CompetFácil.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetFácil.Controller
{
    internal class CategoriaController
    {
        private static Categoria? categoria = null;
        private static List<Categoria>? categorias = null;

        public static List<Categoria>? Categorias { get => categorias; set => categorias = value; }
        internal static string Cadastrar(string categoriaNome)
        {
            bool sucesso = false;
            categoria = new Categoria(categoriaNome);
            sucesso = Categoria.Cadastrar(categoria);
            if (sucesso)
            {
                if(categorias is not null)
                {
                    categorias.Add(categoria);
                }
                return "Cadastro realizado com sucesso!";
            }
            else return "Erro ao cadastrar!";
        }

        internal static bool LaçadorExisteNessaCategoria(object comboBoxCategoriaSelecionado, int idLa)
        {
            var categoriaSelecionado = comboBoxCategoriaSelecionado as Categoria;
            bool existeLaçador = false;
            if(categoriaSelecionado is null) {  return false; }
            existeLaçador = categoriaSelecionado.Laçadores.Exists(l => l.Id == idLa);
            return existeLaçador;
        }
        //carrega as categorias em memoria em uma lista com todas as categorias
        internal static void LoadCategorias()
        {
            categorias = new List<Categoria>();
            var categoriaList = Categoria.GetCategorias();
            if(categoriaList is not null)
                categorias.AddRange(categoriaList);
        }

        internal static string RemoverCategoria(object? categoriaSelecionada)
        {
            var categoria = categoriaSelecionada as Categoria;
            bool removido = false;
            if (categoria == null) return "Algo deu errado Para remover a categoria!";
            removido = Categoria.Remove(categoria);
            if (removido){ 
                if(categorias is not null)
                {
                    categorias.Remove(categoria); 

                }
                return "Categoria Removido Com Sucesso!"; 
            }
            else return "Algo Deu Errado Para remover a categoria!";
        }
    }
}
