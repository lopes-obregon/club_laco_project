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
            competidorCadastradoslistBox.Items.AddRange(listCompetidores.ToArray());
        }
        private void AdicionarMembrosButton(object sender, EventArgs e)
        {
            var membroSelecionado = competidorCadastradoslistBox?.SelectedItem;
            if (membroSelecionado is not null)
            {
                string? membroSelecionadoString = membroSelecionado?.ToString();
                if( membroSelecionadoString is not null)
                    membroslistBox.Items.Add(membroSelecionadoString);
                competidorCadastradoslistBox?.Items.Remove(membroSelecionado);
                
            }
            
        }
    }
}
