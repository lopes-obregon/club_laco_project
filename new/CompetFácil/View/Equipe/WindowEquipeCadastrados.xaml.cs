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

        private void RemoverEquipe(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBoxResult result =  System.Windows.MessageBox.Show("Deseja realmente remover ?", "Confirmação", MessageBoxButton.YesNo);
            bool sucess = false;
            if (result == MessageBoxResult.Yes) {
                var equipeToRemoveUi = ListViewEquipeCadastrados.SelectedItem;
                if (equipeToRemoveUi != null)
                {
                    sucess = EquipeController.Remover(equipeToRemoveUi);
                }
                if (sucess)
                {
                    System.Windows.MessageBox.Show("Equipe Removido com sucesso!");
                }
                else
                {
                    System.Windows.MessageBox.Show("Algo deu errado para remover a equipe!");
                }
            
            }
        }
    }
}
