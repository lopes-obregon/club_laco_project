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

namespace CompetiFácilLaço
{
    public partial class ViewCompetidorForm : Form
    {
        public ViewCompetidorForm()
        {
            InitializeComponent();
            string[] irmãos = { "João", "Maria", "José", "Ana" };
            string[] categorias = { "Individual", "Pai e Filho", "Pai e Filho Mirim", "Casal Laçador", "Dupla de Irmão", "Pai e Filho Bandeira", "Avó e Neto", "Bandeira", "Mirim", "Amazonas Mirim" };
            irmãoListBox.Items.AddRange(irmãos);
            categoriasComboBox.Items.AddRange(categorias);
        }

        private void CadastrarCompetidorForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void cadastrarCompetidorButtonClick(object sender, EventArgs e)
        {
            string nome_competidor = nomeTextBox.Text;
            //Console.WriteLine(nome_competidor);
            //seleção do radio button
            //variavel para armazenar qual foi o radio button selecionado
            string tipo_competidor = "";
            foreach (Control control in escalaGroupBox1.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radioButton = control as RadioButton;
                    if (radioButton.Checked)
                    {
                        tipo_competidor = radioButton.Text;
                    }
                }
            }
            //le de categoriasListBox
            List<string> categorias = new List<string>();
            foreach (var item in categoriasListBox.Items)
            {
                categorias.Add(item.ToString());
            }
            //verifica se o irmão foi selecionado
            bool isIrmão = temIrmãoCheckBox.Checked;
            if (isIrmão)
            {
                string irmão = irmãoListBox.SelectedItem.ToString();
                //MessageBox.Show($"Competidor {nome_competidor} de escala {tipo_competidor} cadastrado com sucesso! Irmão: {irmão}");
                string mensagem = LaçadorController.CadastrarCompetidor(nome_competidor, tipo_competidor, irmão, categorias);
                MessageBox.Show(mensagem);

            }
            else
            {
                string mensagem  = LaçadorController.CadastrarCompetidor(nome_competidor, tipo_competidor, "", categorias);
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
            string categoria_selecionado = categoriasComboBox.SelectedItem.ToString();
            categoriasListBox.Items.Add(categoria_selecionado);
        }
        private void categoriaListBox_Remove(object sender, EventArgs e)
        {
            string categoria_selecionado = categoriasListBox.SelectedItem.ToString();
            categoriasListBox.Items.Remove(categoriasListBox.SelectedItem);
            MessageBox.Show($"Categoria {categoria_selecionado} removida com sucesso!");
        }

        private void escalaGroupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void ConsultarCompetidorButtonClick(object sender, EventArgs e)
        {
            string nomeCompetidor = nomeTextBox.Text;
            LaçadorController.ConsultarLaçador(nomeCompetidor);

        }
    }
}
