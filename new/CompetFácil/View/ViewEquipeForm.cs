using CompetFácil.Controller;
using CompetiFácilLaço.Controller;
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
            if(listCompetidores is not null)
                competidorCadastradoslistBox.Items.AddRange(listCompetidores.ToArray());
        }


        private void AdicionarCompetidorParaMembrosButton(object sender, EventArgs e)
        {
            var competidorSelecionado = competidorCadastradoslistBox?.SelectedItem;
            if (competidorSelecionado is not null)
            {
                membroslistBox.Items.Add(competidorSelecionado);
                competidorCadastradoslistBox?.Items.Remove(competidorSelecionado);



            }
        }

        private void AdicionarMembroParaCompetidoresButton(object sender, EventArgs e)
        {
            var membroSelecionado = membroslistBox?.SelectedItem;
            if (membroSelecionado is not null)
            {
                competidorCadastradoslistBox.Items.Add(membroSelecionado);
                membroslistBox?.Items.Remove(membroSelecionado);
            }
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
    }
}
