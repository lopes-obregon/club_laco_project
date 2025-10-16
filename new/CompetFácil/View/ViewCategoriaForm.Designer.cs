namespace CompetFácil.View
{
    partial class ViewCategoriaForm
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
            label1 = new Label();
            textBoxNomeCategoria = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            buttonCadastrar = new Button();
            listBoxCategoriasCadastradas = new ListBox();
            label2 = new Label();
            buttonRemover = new Button();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 29);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            // 
            // textBoxNomeCategoria
            // 
            textBoxNomeCategoria.Location = new Point(93, 29);
            textBoxNomeCategoria.Name = "textBoxNomeCategoria";
            textBoxNomeCategoria.Size = new Size(100, 23);
            textBoxNomeCategoria.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(buttonCadastrar);
            flowLayoutPanel1.Controls.Add(buttonRemover);
            flowLayoutPanel1.Location = new Point(47, 98);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(200, 100);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // buttonCadastrar
            // 
            buttonCadastrar.Location = new Point(3, 3);
            buttonCadastrar.Name = "buttonCadastrar";
            buttonCadastrar.Size = new Size(75, 23);
            buttonCadastrar.TabIndex = 0;
            buttonCadastrar.Text = "Cadastrar";
            buttonCadastrar.UseVisualStyleBackColor = true;
            buttonCadastrar.Click += Cadastrar;
            // 
            // listBoxCategoriasCadastradas
            // 
            listBoxCategoriasCadastradas.FormattingEnabled = true;
            listBoxCategoriasCadastradas.Location = new Point(329, 53);
            listBoxCategoriasCadastradas.Name = "listBoxCategoriasCadastradas";
            listBoxCategoriasCadastradas.Size = new Size(120, 94);
            listBoxCategoriasCadastradas.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(317, 20);
            label2.Name = "label2";
            label2.Size = new Size(131, 15);
            label2.TabIndex = 4;
            label2.Text = "Categorias Cadastrados";
            label2.Click += label2_Click;
            // 
            // buttonRemover
            // 
            buttonRemover.Location = new Point(84, 3);
            buttonRemover.Name = "buttonRemover";
            buttonRemover.Size = new Size(75, 23);
            buttonRemover.TabIndex = 1;
            buttonRemover.Text = "Remover";
            buttonRemover.UseVisualStyleBackColor = true;
            buttonRemover.Click += RemoverCategoria;
            // 
            // ViewCategoriaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(listBoxCategoriasCadastradas);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(textBoxNomeCategoria);
            Controls.Add(label1);
            Name = "ViewCategoriaForm";
            Text = "Categoria";
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxNomeCategoria;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button buttonCadastrar;
        private ListBox listBoxCategoriasCadastradas;
        private Label label2;
        private Button buttonRemover;
    }
}