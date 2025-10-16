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
                return "Cadastro realizado com sucesso!";
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

        internal static void LoadCategorias()
        {
            categorias = new List<Categoria>();
            var categoriaList = Categoria.GetCategorias();
            if(categoriaList is not null)
                categorias.AddRange(categoriaList);
        }
    }
}
