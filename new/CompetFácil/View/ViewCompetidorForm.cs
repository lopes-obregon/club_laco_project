using CompetFácil.Controller;
using CompetiFácilLaço.Controller;

namespace CompetiFácilLaço
{
    public partial class ViewCompetidorForm : Form
    {
        private List<object?> laçadoresList;
        public ViewCompetidorForm()
        {
            InitializeComponent();
            laçadoresList = new List<object?>();
            string[] irmãos = { "João", "Maria", "José", "Ana" };
            var irmãosLaçadores = LaçadorController.GetLaçadores();
            //string[] categorias = { "Individual", "Pai e Filho", "Pai e Filho Mirim", "Casal Laçador", "Dupla de Irmão", "Pai e Filho Bandeira", "Avó e Neto", "Bandeira", "Mirim", "Amazonas Mirim" };
            //irmãoListBox.Items.AddRange(irmãos);
            CategoriaController.LoadCategorias();
            if (irmãosLaçadores is not null) 
                irmãoListBox.Items.AddRange(irmãosLaçadores.ToArray());
            if (CategoriaController.Categorias is not null)
            {
                categoriasComboBox.DisplayMember = "Nome";
                categoriasComboBox.Items.AddRange(CategoriaController.Categorias.ToArray());
            }
        }

        private void CadastrarCompetidorForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void cadastrarCompetidorButtonClick(object sender, EventArgs e)
        {
            string nome_competidor = nomeTextBox.Text;
            string sobreNome = sobreNomeTextBox.Text;
            //Console.WriteLine(nome_competidor);
            //seleção do radio button
            //variavel para armazenar qual foi o radio button selecionado
            string tipo_competidor = "";
            foreach (Control control in escalaGroupBox1.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton? radioButton = control as RadioButton;
                    if (radioButton.Checked)
                    {
                        tipo_competidor = radioButton.Text;
                    }
                }
            }

            //le de categoriasListBox
            var categorias = categoriasListBox.Items;
            
            /*
            List<string> categorias = new List<string>();
            foreach (var item in categoriasListBox.Items)
            {
                categorias.Add(item.ToString());
            }*/
            //verifica se o irmão foi selecionado
            bool isIrmão = temIrmãoCheckBox.Checked;
            if (isIrmão)
            {
                var irmãoSelecionado = irmãoListBox.SelectedItem;
                //MessageBox.Show($"Competidor {nome_competidor} de escala {tipo_competidor} cadastrado com sucesso! Irmão: {irmão}");
                string mensagem = LaçadorController.CadastrarCompetidor(nome_competidor, sobreNome, tipo_competidor, irmãoSelecionado, categorias);
                MessageBox.Show(mensagem);

            }
            else
            {
                string mensagem = LaçadorController.CadastrarCompetidor(nome_competidor, sobreNome, tipo_competidor, null, categorias);
                //MessageBox.Show($"Competidor {nome_competidor} de escala {tipo_competidor} cadastrado com sucesso!");
                MessageBox.Show(mensagem);



            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void captãoRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void irmãoListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void temIrmãoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            irmãoListBox.Visible = temIrmãoCheckBox.Checked;
        }

        private void categoriasComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var  categoriaSelecionado = categoriasComboBox.SelectedItem;
            categoriasListBox.DisplayMember = "Nome";
            if(categoriaSelecionado is not null)
                categoriasListBox.Items.Add(categoriaSelecionado);
        }
        private void categoriaListBox_Remove(object sender, EventArgs e)
        {
            var categoriaSelecionado = categoriasListBox.SelectedItem;
            
            categoriasListBox.Items.Remove(categoriasListBox.SelectedItem ??"");
            if(categoriaSelecionado is not null)
                MessageBox.Show($"Categoria {categoriaSelecionado.ToString()} removida com sucesso!");
        }

        private void escalaGroupBox1_Enter(object sender, EventArgs e)
        {

        }
        //método para consultar o competidor
        private bool ConsultarCompetidor(object sender, EventArgs e)
        {

            string nomeCompetidor = nomeTextBox.Text;
            var laçadorEncontrado = LaçadorController.ConsultarLaçador(nomeCompetidor);
            if (laçadorEncontrado == null) { MessageBox.Show("Competidor não encontrado"); return false; }
            else
            {
                laçadoresList.Add(laçadorEncontrado);
                nomeTextBox.Text = laçadorEncontrado.Nome;
                sobreNomeTextBox.Text = laçadorEncontrado.SobreNome;
                //parte para setar o radio
                SetRadioButtonGroup(laçadorEncontrado.Escala);
                if (laçadorEncontrado.Irmão != null)
                {
                    temIrmãoCheckBox.Checked = true;
                    //aparece a caixa
                    temIrmãoCheckBox_CheckedChanged(sender, e);
                    foreach (var laçador in irmãoListBox.Items)
                    {
                        if (LaçadorController.GetIdLaçador(laçador) == laçadorEncontrado.Irmão.Id)
                        {
                            irmãoListBox.SelectedItem = laçador;
                            break;
                        }
                    }

                }
                //categorialistbox
                foreach (var categoria in laçadorEncontrado.Categorias)
                {
                    if (categoria is string)
                    {
                        categoriasListBox.Items.Add(categoria.ToString());

                    }
                }
                return true;
               

            }
            
        }
        private void ConsultarCompetidorButtonClick(object sender, EventArgs e)
        {
            ConsultarCompetidor(sender, e);
        }
        //setar o RadioButtonGroup para escala indicada da pesquisa
        private void SetRadioButtonGroup(string escala)
        {
            foreach (Control control in escalaGroupBox1.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton? radioButton = control as RadioButton;
                    if (radioButton != null)
                    {
                        if (String.Equals(radioButton.Text, escala))
                        {
                            radioButton.Checked = true;
                            break;
                        }

                    }
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void LimparButton_Click(object sender, EventArgs e)
        {
            //clear 
            nomeTextBox.Text = string.Empty;
            sobreNomeTextBox.Text = string.Empty;
            //clear radio
            foreach (Control control in escalaGroupBox1.Controls)
            {
                if (control is RadioButton radioButton)
                {
                    radioButton.Checked = false;
                }
            }
            temIrmãoCheckBox.Checked = false;
            //categorias list box
            categoriasListBox.Items.Clear();

        }
        private void AlterarButton_Click(Object sender, EventArgs e)
        {
            //verificar se os dados estão vazios
            if (IsDadosVazios())
            {
                MessageBox.Show("Dados Vazio por favor faça a consulta antes");
            }
            else
            {
                //Verificar se os dados foram alterados
                string posição = GetPosiçãoLaçador();
                object? irmãoSelecionado;
                //List<string> categorias = GetCategorias();
                var categorias = categoriasListBox.Items;
                if (temIrmãoCheckBox.Checked)
                {
                    irmãoSelecionado = irmãoListBox.SelectedItem;
                }
                else { irmãoSelecionado = null; }
                //nome ok sobrenome ok posição no time
                if (LaçadorController.AlterarLaçador(laçadoresList, nomeTextBox.Text, sobreNomeTextBox.Text, posição, temIrmãoCheckBox.Checked, irmãoSelecionado, categorias)) { MessageBox.Show("Laçador Atualizado com sucesso!"); }
                else { MessageBox.Show("Algo deu errado desculpe!"); }
                
            }
        }

        private List<string> GetCategorias()
        {
            var lista = new List<string>();
            foreach (var item in categoriasListBox.Items)
            {
                lista.Add(item.ToString());
            }
            return lista;
        }

        private string GetPosiçãoLaçador()
        {
            foreach (Control control in escalaGroupBox1.Controls)
            {
                if (control is RadioButton radioButton)
                {
                    if (radioButton.Checked)
                    {
                        return radioButton.Text;
                    }
                }
            }
            return "";
        }

        private bool IsDadosVazios()
        {
            if (string.IsNullOrEmpty(nomeTextBox.Text) || string.IsNullOrEmpty(sobreNomeTextBox.Text)) return true;
            else return false;
        }

        private void RemoverButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(nomeTextBox.Text)) { MessageBox.Show("Preciso de pelomenos um nome!"); }
            else
            {



                //primeiro caso se tem irmão 
                var laçador = LaçadorController.ConsultarLaçador(nomeTextBox.Text, sobreNomeTextBox.Text);
                //apagando
                if (LaçadorController.RemoveLaçador(laçador))
                    MessageBox.Show("Competidor removido com sucesso!");
                else
                    MessageBox.Show("Algo deu errado não consegui remover!");



            }
        }
    }

}
