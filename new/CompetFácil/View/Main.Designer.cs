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
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { equipeToolStripMenuItem, competidorToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(933, 24);
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
            cadastrarToolStripMenuItem.Size = new Size(180, 22);
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
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Main";
            Text = "CompetiFácilLaço";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem equipeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem competidorToolStripMenuItem;
        private ToolStripMenuItem cadToolStripMenuItem;
        //private System.Data.SQLite.SQLiteCommand sqLiteCommand1;
    }
}

