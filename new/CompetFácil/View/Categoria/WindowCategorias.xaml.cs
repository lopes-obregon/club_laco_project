using CompetFácil.Controller;
using System.Windows;

namespace CompetFácil.View.Categoria
{
    /// <summary>
    /// Lógica interna para WindowCategorias.xaml
    /// </summary>
    public partial class WindowCategorias : Window
    {
        public WindowCategorias()
        {
            InitializeComponent();
            
            AtualizarCategorias();
        }

        private void AtualizarCategorias()
        {
            CategoriaController.LoadCategorias();
            listBoxCategorias.ItemsSource = CategoriaController.Categorias;
        }

        private void FormCadastro(object sender, RoutedEventArgs e)
        {
            var form = new ViewCategoriaForm();
            form.ShowDialog();
            AtualizarCategorias();
        }

        private void ExcluirCategoria(object sender, RoutedEventArgs e)
        {
            var categoriaSelecionado = listBoxCategorias.SelectedItem;
            if(categoriaSelecionado != null)
            {
                CategoriaController.CategoriaSelecionado(categoriaSelecionado);
                if(CategoriaController.CategoriaAtual is not null)
                {
                    string mensagem = $"Deseja Realmente Excluir a Categoria:{CategoriaController.CategoriaAtual.Nome} ?";
                    var res = System.Windows.MessageBox.Show(mensagem, "Pergunta", System.Windows.MessageBoxButton.YesNoCancel);
                    if(res == MessageBoxResult.Yes)
                    {
                        mensagem = CategoriaController.RemoverCategoria();
                        System.Windows.MessageBox.Show(mensagem);
                        AtualizarCategorias();
                    }

                }
            }
        }
    }
}
