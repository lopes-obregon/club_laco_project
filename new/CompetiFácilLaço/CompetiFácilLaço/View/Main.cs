using CompetiFácilLaço.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompetiFácilLaço
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
           DataBase dataBase = new DataBase();
            dataBase.Init();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void cadastrarCompetidorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewCompetidorForm cadastrarCompetidorForm = new ViewCompetidorForm();
            cadastrarCompetidorForm.Show();
        }
    }
}
