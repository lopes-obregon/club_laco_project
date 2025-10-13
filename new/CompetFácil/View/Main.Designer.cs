namespace CompetiFácilLaço
{
    partial class Main
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            equipeToolStripMenuItem = new ToolStripMenuItem();
            cadastrarToolStripMenuItem = new ToolStripMenuItem();
            competidorToolStripMenuItem = new ToolStripMenuItem();
            cadToolStripMenuItem = new ToolStripMenuItem();
            dataGridView = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            nome = new DataGridViewTextBoxColumn();
            Pontos = new DataGridViewTextBoxColumn();
            labelNomeDaEquipe = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            buttonSalvar = new Button();
            buttonAnterior = new Button();
            buttonProx = new Button();
            labelIdEquipe = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { equipeToolStripMenuItem, competidorToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(1004, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // equipeToolStripMenuItem
            // 
            equipeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cadastrarToolStripMenuItem });
            equipeToolStripMenuItem.Name = "equipeToolStripMenuItem";
            equipeToolStripMenuItem.Size = new Size(55, 20);
            equipeToolStripMenuItem.Text = "Equipe";
            // 
            // cadastrarToolStripMenuItem
            // 
            cadastrarToolStripMenuItem.Name = "cadastrarToolStripMenuItem";
            cadastrarToolStripMenuItem.Size = new Size(124, 22);
            cadastrarToolStripMenuItem.Text = "Cadastrar";
            cadastrarToolStripMenuItem.Click += cadastrarEquipeTollStripMenuItemClick;
            // 
            // competidorToolStripMenuItem
            // 
            competidorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cadToolStripMenuItem });
            competidorToolStripMenuItem.Name = "competidorToolStripMenuItem";
            competidorToolStripMenuItem.Size = new Size(83, 20);
            competidorToolStripMenuItem.Text = "Competidor";
            // 
            // cadToolStripMenuItem
            // 
            cadToolStripMenuItem.Name = "cadToolStripMenuItem";
            cadToolStripMenuItem.Size = new Size(124, 22);
            cadToolStripMenuItem.Text = "Cadastrar";
            cadToolStripMenuItem.Click += cadastrarCompetidorToolStripMenuItem_Click;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { id, nome, Pontos });
            dataGridView.Location = new Point(12, 71);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(244, 284);
            dataGridView.TabIndex = 1;
            dataGridView.CellValueChanged += MarcarPonto;
            dataGridView.CurrentCellDirtyStateChanged += VerificarCelulaEditada;
            // 
            // id
            // 
            id.HeaderText = "ID";
            id.Name = "id";
            id.ReadOnly = true;
            id.Visible = false;
            // 
            // nome
            // 
            nome.HeaderText = "Competidor";
            nome.Name = "nome";
            nome.ReadOnly = true;
            // 
            // Pontos
            // 
            Pontos.HeaderText = "Pontos";
            Pontos.Name = "Pontos";
            Pontos.ReadOnly = true;
            // 
            // labelNomeDaEquipe
            // 
            labelNomeDaEquipe.AutoSize = true;
            labelNomeDaEquipe.Location = new Point(121, 53);
            labelNomeDaEquipe.Name = "labelNomeDaEquipe";
            labelNomeDaEquipe.Size = new Size(49, 15);
            labelNomeDaEquipe.TabIndex = 2;
            labelNomeDaEquipe.Text = "Equipe: ";
            labelNomeDaEquipe.Click += labelNomeDaEquipe_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(buttonSalvar);
            flowLayoutPanel1.Controls.Add(buttonAnterior);
            flowLayoutPanel1.Controls.Add(buttonProx);
            flowLayoutPanel1.Location = new Point(121, 407);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(247, 100);
            flowLayoutPanel1.TabIndex = 3;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // buttonSalvar
            // 
            buttonSalvar.Location = new Point(3, 3);
            buttonSalvar.Name = "buttonSalvar";
            buttonSalvar.Size = new Size(75, 23);
            buttonSalvar.TabIndex = 0;
            buttonSalvar.Text = "Salvar";
            buttonSalvar.UseVisualStyleBackColor = true;
            buttonSalvar.Click += SalvarTableData;
            // 
            // buttonAnterior
            // 
            buttonAnterior.Location = new Point(84, 3);
            buttonAnterior.Name = "buttonAnterior";
            buttonAnterior.Size = new Size(75, 23);
            buttonAnterior.TabIndex = 2;
            buttonAnterior.Text = "Voltar";
            buttonAnterior.UseVisualStyleBackColor = true;
            buttonAnterior.Click += VoltarEquipe;
            // 
            // buttonProx
            // 
            buttonProx.Location = new Point(165, 3);
            buttonProx.Name = "buttonProx";
            buttonProx.Size = new Size(75, 23);
            buttonProx.TabIndex = 1;
            buttonProx.Text = "Próximo";
            buttonProx.UseVisualStyleBackColor = true;
            buttonProx.Click += PróximoEquipe;
            // 
            // labelIdEquipe
            // 
            labelIdEquipe.AutoSize = true;
            labelIdEquipe.Location = new Point(10, 53);
            labelIdEquipe.Name = "labelIdEquipe";
            labelIdEquipe.Size = new Size(38, 15);
            labelIdEquipe.TabIndex = 4;
            labelIdEquipe.Text = "label1";
            labelIdEquipe.Visible = false;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1004, 519);
            Controls.Add(labelIdEquipe);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(labelNomeDaEquipe);
            Controls.Add(dataGridView);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Main";
            Text = "CompetiFácilLaço";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem equipeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem competidorToolStripMenuItem;
        private ToolStripMenuItem cadToolStripMenuItem;
        private DataGridView dataGridView;
        private Label labelNomeDaEquipe;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button buttonSalvar;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn nome;
        private DataGridViewTextBoxColumn Pontos;
        private Label labelIdEquipe;
        private Button buttonProx;
        private Button buttonAnterior;
        //private System.Data.SQLite.SQLiteCommand sqLiteCommand1;
    }
}

