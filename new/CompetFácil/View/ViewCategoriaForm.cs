using CompetFácil.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompetFácil.View
{
    public partial class ViewCategoriaForm : Form
    {
        public ViewCategoriaForm()
        {
            InitializeComponent();
        }
        // string[] categorias = { "Individual", "Pai e Filho", "Pai e Filho Mirim", "Casal Laçador", "Dupla de Irmão", "Pai e Filho Bandeira", "Avó e Neto", "Bandeira", "Mirim", "Amazonas Mirim" };
        private void Cadastrar(object sender, EventArgs e)
        {
            string categoriaNome = textBoxNomeCategoria.Text;
            string mensagem = "";
            if(!String.IsNullOrEmpty(categoriaNome) )
                mensagem = CategoriaController.Cadastrar(categoriaNome);
            MessageBox.Show(mensagem);
        }
    }
}
