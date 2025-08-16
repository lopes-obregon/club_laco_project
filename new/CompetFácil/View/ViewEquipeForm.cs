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
    }
}
