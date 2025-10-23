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
        public static Categoria? CategoriaAtual { get;  private set; }
        

        public static List<Categoria>? Categorias { get;  private set; }
        internal static string Cadastrar(string categoriaNome)
        {
            bool sucesso = false;
            CategoriaAtual = new Categoria(categoriaNome);
            sucesso = Categoria.Cadastrar(CategoriaAtual);
            if (sucesso)
            {
                if(Categorias is not null)
                {
                    Categorias.Add(CategoriaAtual);
                }
                return "Cadastro realizado com sucesso!";
            }
            else return "Erro ao cadastrar!";
        }

        internal static void CategoriaSelecionado(object categoriaSelecionadoUi)
        {
            Categoria? categoriaSelecionado = categoriaSelecionadoUi as Categoria;
            if(categoriaSelecionado != null)
            {
                if(Categorias is not null  && Categorias.Count > 0)
                CategoriaAtual = Categorias.Find(ca => ca.Id == categoriaSelecionado.Id);
            }
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
            Categorias = new List<Categoria>();
            var categoriaList = Categoria.GetCategorias();
            if(categoriaList is not null)
                Categorias.AddRange(categoriaList);
        }

        internal static string RemoverCategoria(object? categoriaSelecionada)
        {
            var categoria = categoriaSelecionada as Categoria;
            bool removido = false;
            if (categoria == null) return "Algo deu errado Para remover a categoria!";
            removido = Categoria.Remove(categoria);
            if (removido){ 
                if(Categorias is not null)
                {
                    Categorias.Remove(categoria); 

                }
                return "Categoria Removido Com Sucesso!"; 
            }
            else return "Algo Deu Errado Para remover a categoria!";
        }

        internal static string RemoverCategoria()
        {
            bool sucess = false;
            if(CategoriaAtual is not null)
            {
                sucess = Categoria.Remove(CategoriaAtual);
                if (sucess) return "Categoria Removido Com sucesso!";
                else return "Erro ao remover a categoria!";
            }
            return string.Empty;
        }
    }
}
