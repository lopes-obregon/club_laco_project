
namespace CompetFácil.View
{
    partial class ViewEquipeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            competidorCadastradoslistBox = new ListBox();
            nomeEquipeTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            removeMembroButton = new Button();
            adicionarMembroButton = new Button();
            membroslistBox = new ListBox();
            label3 = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            CadastrarEquipe = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 72.78107F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.218935F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 8F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 111F));
            tableLayoutPanel1.Controls.Add(competidorCadastradoslistBox, 0, 2);
            tableLayoutPanel1.Controls.Add(nomeEquipeTextBox, 3, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 2);
            tableLayoutPanel1.Controls.Add(membroslistBox, 3, 2);
            tableLayoutPanel1.Controls.Add(label3, 3, 1);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 28.977272F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 71.02273F));
            tableLayoutPanel1.Size = new Size(279, 223);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // competidorCadastradoslistBox
            // 
            competidorCadastradoslistBox.FormattingEnabled = true;
            competidorCadastradoslistBox.Location = new Point(3, 81);
            competidorCadastradoslistBox.Name = "competidorCadastradoslistBox";
            competidorCadastradoslistBox.Size = new Size(110, 139);
            competidorCadastradoslistBox.TabIndex = 1;
            competidorCadastradoslistBox.DoubleClick += AdicionarCompetidorParaMembrosButton;
            // 
            // nomeEquipeTextBox
            // 
            nomeEquipeTextBox.Location = new Point(170, 3);
            nomeEquipeTextBox.Name = "nomeEquipeTextBox";
            nomeEquipeTextBox.Size = new Size(100, 23);
            nomeEquipeTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 1;
            label1.Text = "Nome da Equipe";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 58);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 1;
            label2.Text = "Competidores";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(removeMembroButton, 0, 1);
            tableLayoutPanel2.Controls.Add(adicionarMembroButton, 0, 0);
            tableLayoutPanel2.Location = new Point(119, 81);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 46.42857F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 53.57143F));
            tableLayoutPanel2.Size = new Size(37, 112);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // removeMembroButton
            // 
            removeMembroButton.Location = new Point(3, 55);
            removeMembroButton.Name = "removeMembroButton";
            removeMembroButton.Size = new Size(31, 23);
            removeMembroButton.TabIndex = 2;
            removeMembroButton.Text = "<<";
            removeMembroButton.UseVisualStyleBackColor = true;
            removeMembroButton.Click += AdicionarMembroParaCompetidoresButton;
            // 
            // adicionarMembroButton
            // 
            adicionarMembroButton.Location = new Point(3, 3);
            adicionarMembroButton.Name = "adicionarMembroButton";
            adicionarMembroButton.Size = new Size(31, 19);
            adicionarMembroButton.TabIndex = 1;
            adicionarMembroButton.Text = ">>";
            adicionarMembroButton.UseVisualStyleBackColor = true;
            adicionarMembroButton.Click += AdicionarCompetidorParaMembrosButton;
            // 
            // membroslistBox
            // 
            membroslistBox.FormattingEnabled = true;
            membroslistBox.Location = new Point(170, 81);
            membroslistBox.Name = "membroslistBox";
            membroslistBox.Size = new Size(106, 139);
            membroslistBox.TabIndex = 1;
            membroslistBox.DoubleClick += AdicionarMembroParaCompetidoresButton;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(170, 58);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 1;
            label3.Text = "Membros";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(CadastrarEquipe, 0, 0);
            tableLayoutPanel3.Location = new Point(15, 241);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(281, 32);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // CadastrarEquipe
            // 
            CadastrarEquipe.Location = new Point(3, 3);
            CadastrarEquipe.Name = "CadastrarEquipe";
            CadastrarEquipe.Size = new Size(75, 23);
            CadastrarEquipe.TabIndex = 0;
            CadastrarEquipe.Text = "Cadastrar";
            CadastrarEquipe.UseVisualStyleBackColor = true;
            CadastrarEquipe.Click += CadastrarEquipeButton;
            // 
            // ViewEquipeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(308, 275);
            Controls.Add(tableLayoutPanel3);
            Controls.Add(tableLayoutPanel1);
            Name = "ViewEquipeForm";
            Text = "EquipeView";
            Load += ViewEquipeForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void ViewEquipeForm_Load(object sender, EventArgs e)
        {
            
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private ListBox membroslistBox;
        private ListBox competidorCadastradoslistBox;
        private Button adicionarMembroButton;
        private TextBox nomeEquipeTextBox;
        private TableLayoutPanel tableLayoutPanel2;
        private Button removeMembroButton;
        private TableLayoutPanel tableLayoutPanel3;
        private Button CadastrarEquipe;
    }
}