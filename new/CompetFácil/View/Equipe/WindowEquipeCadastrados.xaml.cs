using CompetFácil.Controller;
using System.Windows;

namespace CompetFácil.View.Equipe
{
    /// <summary>
    /// Lógica interna para WindowEquipeCadastrados.xaml
    /// </summary>
    public partial class WindowEquipeCadastrados : Window
    {
        public WindowEquipeCadastrados()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            EquipeController.LoadEquipes();
            var equipe = EquipeController.Equipes;
            if (equipe != null)
            {
                ListViewEquipeCadastrados.ItemsSource = equipe;
            }
        }

        private void CadastrarEquipe(object sender, RoutedEventArgs e)
        {
            ViewEquipeForm form = new ViewEquipeForm();
            form.ShowDialog();
        }

        private void AtualizarEquipe(object sender, RoutedEventArgs e)
        {
            var equipeSelecionadoUi = ListViewEquipeCadastrados.SelectedItem;
            if( equipeSelecionadoUi != null)
            {
                ViewEquipeForm form = new ViewEquipeForm(equipeSelecionadoUi);
                form.ShowDialog();
            }
            else
            {
                System.Windows.MessageBox.Show("Selecione Uma Equipe Válida!");
            }
        }
    }
}
