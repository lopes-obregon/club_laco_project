using CompetFácil.Controller;
using CompetFácil.View;
using System.Windows.Forms;

namespace CompetiFácilLaço
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            Init();

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
        private void cadastrarEquipeTollStripMenuItemClick(object sender, EventArgs e)
        {
            ViewEquipeForm equipeForm = new ViewEquipeForm();
            equipeForm.Show();
        }
        private void Init()
        {
            InitDataGrid();
            //carregar as equipes
            EquipeController.LoadEquipes();
            //fazer a consulta do objeto 
            if (EquipeController.Equipes is not null)
            {
                var equipe = EquipeController.Equipes.FirstOrDefault();
                if (equipe != null)
                {
                    labelNomeDaEquipe.Text += equipe.NomeEquipe;
                }
                else
                    labelNomeDaEquipe.Text += "-";
            }else
            {
                labelNomeDaEquipe.Text += "-";
            }
        }
        private void InitDataGrid()
        {
            dataGridView.Columns.Add("Nome", "Competidor");
            dataGridView.Columns.Add("Pontos", "Pontos");
            for(int i = 0; i < 6; i++)
            {
                var statusColumn = new DataGridViewComboBoxColumn();
                statusColumn.Name = "Ponto " + (i+1);
                statusColumn.Items.AddRange("Positivo", "Negativo", "");
                dataGridView.Columns.Add(statusColumn);

            }
           // dataGridView.Rows.Add("Jão", 0, "");
            //dataGridView.Rows.Add("Carlos", 0, "");
            //auto ajuste do grid
           // dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; 
            //linhas
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
             int alturaTotal = dataGridView.Rows.GetRowsHeight(DataGridViewElementStates.Visible)
                 + dataGridView.ColumnHeadersHeight;
           // int alturaTotal = dataGridView.ColumnHeadersHeight;

            int larguraTotal = dataGridView.RowHeadersWidth;
            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                larguraTotal += col.Width;
                
            }


            dataGridView.AllowUserToAddRows = false;
            dataGridView.Height = alturaTotal;
            dataGridView.Width = larguraTotal;
            dataGridView.ScrollBars = ScrollBars.None;
            //dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            //dataGridView.ScrollBars = ScrollBars.Vertical;
            //exemplo
            dataGridView.Refresh();



        }
    }
}
