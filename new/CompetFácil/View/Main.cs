namespace CompetiFácilLaço
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();


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
