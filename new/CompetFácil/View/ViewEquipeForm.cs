using CompetFácil.Controller;
using CompetiFácilLaço.Controller;

namespace CompetFácil.View
{
    public partial class ViewEquipeForm : Form
    {

        public ViewEquipeForm()
        {
            InitializeComponent();
            InitialList();
        }

        private void InitialList()
        {
            var listCompetidores = LaçadorController.GetLaçadores();
            if (listCompetidores is not null)
                competidorCadastradoslistBox.Items.AddRange(listCompetidores.ToArray());
        }


        private void AdicionarCompetidorParaMembrosButton(object sender, EventArgs e)
        {
            var competidorSelecionado = competidorCadastradoslistBox?.SelectedItem;
            if (competidorSelecionado is not null)
            {
                if (!MembroListBoxExiste(competidorSelecionado))
                {
                    membroslistBox.Items.Add(competidorSelecionado);
                    competidorCadastradoslistBox?.Items.Remove(competidorSelecionado);
                }


            }
        }

        private bool MembroListBoxExiste(object competidorSelecionado)
        {
            bool jáExiste = false;
            foreach (var item in membroslistBox.Items)
            {
                if (item is not null)
                {
                    if (String.Equals(item.ToString(), competidorSelecionado.ToString()))
                    {
                        jáExiste = true;
                    }
                }
            }
            return jáExiste;
        }

        private void AdicionarMembroParaCompetidoresButton(object sender, EventArgs e)
        {
            var membroSelecionado = membroslistBox?.SelectedItem;
            if (membroSelecionado is not null)
            {
                if (competidorCadastradosExisteListBox(membroSelecionado))
                {
                    membroslistBox?.Items.Remove(membroSelecionado);
                }
                else
                {
                    competidorCadastradoslistBox.Items.Add(membroSelecionado);
                    membroslistBox?.Items.Remove(membroSelecionado);
                }
            }
        }

        private bool competidorCadastradosExisteListBox(object membroSelecionado)
        {
            bool jáExiste = false;
            foreach (var item in competidorCadastradoslistBox.Items)
            {
                if (item is not null)
                {
                    if (String.Equals(item.ToString(), membroSelecionado.ToString()))
                    {
                        jáExiste = true;
                    }
                }
            }
            return jáExiste;
        }

        private void CadastrarEquipeButton(object sender, EventArgs e)
        {
            string equipeNome = nomeEquipeTextBox.Text;
            List<string> membrosList = new List<string>();
            membrosList = GetMembrosListBox();
            string mensagemCadastro = EquipeController.CadastrarEquipe(equipeNome, membrosList);
            if (!String.IsNullOrEmpty(mensagemCadastro))
            {
                MessageBox.Show(mensagemCadastro);
            }
        }

        private List<string> GetMembrosListBox()
        {
            List<string> list = new List<string>();
            foreach (var laçador in membroslistBox.Items)
            {
                if (laçador is not null)
                {
                    list.Add(laçador.ToString());
                }
            }
            return list;
        }

        private void ConsultarEquipeButton(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(nomeEquipeTextBox.Text))
            {
                //pesquisa pelo nome da equipe
                EquipeController.ConsultarEquipe(nomeEquipeTextBox.Text);
                if (EquipeController.equipe is not null)
                {
                    nomeEquipeTextBox.Text = EquipeController.equipe.NomeEquipe;
                    //inserir no box
                    membroslistBox.Items.AddRange(EquipeController.equipe.Laçadores.ToArray());
                }

                }
                
        }
    }
}
