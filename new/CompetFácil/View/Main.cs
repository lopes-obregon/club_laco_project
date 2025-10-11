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
                    foreach (var la in equipe.Laçadores)
                    {
                        dataGridView.Rows.Add(la.Id, la.Nome + " " + la.SobreNome, 0, "", "", "", "", "", "");
                    }
                }
                else
                    labelNomeDaEquipe.Text += "-";
            }
            else
            {
                labelNomeDaEquipe.Text += "-";
            }
            DataGridRefresh();
        }

        private void DataGridRefresh()
        {
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

        private void InitDataGrid()
        {

            for (int i = 0; i < 6; i++)
            {
                var statusColumn = new DataGridViewComboBoxColumn();
                statusColumn.Name = "Ponto " + (i + 1);
                statusColumn.Items.AddRange("Positivo", "Negativo", "");
                dataGridView.Columns.Add(statusColumn);

            }
            // dataGridView.Rows.Add("Jão", 0, "");
            //dataGridView.Rows.Add("Carlos", 0, "");
            //auto ajuste do grid
            // dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; 
            //linhas




        }

        private void MarcarPonto(object sender, DataGridViewCellEventArgs e)
        {
            //verificar se a celula altera está na coluna de ponto
            string nomeColuna = dataGridView.Columns[e.ColumnIndex].Name;
            if (nomeColuna.StartsWith("Ponto"))
            {
                var celula = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                var novoValor = celula.Value?.ToString();
                //se mudou para positivo soma 1
                if (novoValor == "Positivo")
                {
                    var pontoCell = dataGridView.Rows[e.RowIndex].Cells["Pontos"];
                    int pontosAtuais = Convert.ToInt32(pontoCell.Value);
                    pontoCell.Value = pontosAtuais + 1;
                }
            }
        }



        private void VerificarCelulaEditada(object sender, EventArgs e)
        {
            if (dataGridView.IsCurrentCellDirty)
                dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void SalvarTableData(object sender, EventArgs e)
        {

        }
    }
}
