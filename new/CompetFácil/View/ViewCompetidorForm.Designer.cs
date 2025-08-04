namespace CompetiFácilLaço
{
    partial class ViewCompetidorForm
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
            nomeTextBox = new TextBox();
            label1 = new Label();
            captãoRadioButton = new RadioButton();
            trio1RadioButton = new RadioButton();
            trio2RadioButton = new RadioButton();
            trio3RadioButton = new RadioButton();
            fechaRoascaRadioButton = new RadioButton();
            escalaGroupBox1 = new GroupBox();
            cadastrarButton = new Button();
            temIrmãoCheckBox = new CheckBox();
            irmãoListBox = new ListBox();
            categoriasComboBox = new ComboBox();
            categoriasListBox = new ListBox();
            label2 = new Label();
            label3 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label4 = new Label();
            sobreNomeTextBox = new TextBox();
            consultarButton = new Button();
            LimparButton = new Button();
            escalaGroupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // nomeTextBox
            // 
            nomeTextBox.Location = new Point(156, 3);
            nomeTextBox.Margin = new Padding(4, 3, 4, 3);
            nomeTextBox.Name = "nomeTextBox";
            nomeTextBox.Size = new Size(107, 23);
            nomeTextBox.TabIndex = 0;
            nomeTextBox.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 1;
            label1.Text = "Nome ";
            label1.Click += label1_Click;
            // 
            // captãoRadioButton
            // 
            captãoRadioButton.AutoSize = true;
            captãoRadioButton.Location = new Point(54, 47);
            captãoRadioButton.Margin = new Padding(4, 3, 4, 3);
            captãoRadioButton.Name = "captãoRadioButton";
            captãoRadioButton.Size = new Size(63, 19);
            captãoRadioButton.TabIndex = 2;
            captãoRadioButton.TabStop = true;
            captãoRadioButton.Text = "Captão";
            captãoRadioButton.UseVisualStyleBackColor = true;
            captãoRadioButton.CheckedChanged += captãoRadioButton_CheckedChanged;
            // 
            // trio1RadioButton
            // 
            trio1RadioButton.AutoSize = true;
            trio1RadioButton.Location = new Point(130, 47);
            trio1RadioButton.Margin = new Padding(4, 3, 4, 3);
            trio1RadioButton.Name = "trio1RadioButton";
            trio1RadioButton.Size = new Size(56, 19);
            trio1RadioButton.TabIndex = 3;
            trio1RadioButton.TabStop = true;
            trio1RadioButton.Text = "Trio-1";
            trio1RadioButton.UseVisualStyleBackColor = true;
            // 
            // trio2RadioButton
            // 
            trio2RadioButton.AutoSize = true;
            trio2RadioButton.Location = new Point(197, 47);
            trio2RadioButton.Margin = new Padding(4, 3, 4, 3);
            trio2RadioButton.Name = "trio2RadioButton";
            trio2RadioButton.Size = new Size(56, 19);
            trio2RadioButton.TabIndex = 4;
            trio2RadioButton.TabStop = true;
            trio2RadioButton.Text = "Trio-2";
            trio2RadioButton.UseVisualStyleBackColor = true;
            // 
            // trio3RadioButton
            // 
            trio3RadioButton.AutoSize = true;
            trio3RadioButton.Location = new Point(54, 74);
            trio3RadioButton.Margin = new Padding(4, 3, 4, 3);
            trio3RadioButton.Name = "trio3RadioButton";
            trio3RadioButton.Size = new Size(56, 19);
            trio3RadioButton.TabIndex = 5;
            trio3RadioButton.TabStop = true;
            trio3RadioButton.Text = "Trio-3";
            trio3RadioButton.UseVisualStyleBackColor = true;
            // 
            // fechaRoascaRadioButton
            // 
            fechaRoascaRadioButton.AutoSize = true;
            fechaRoascaRadioButton.Location = new Point(121, 74);
            fechaRoascaRadioButton.Margin = new Padding(4, 3, 4, 3);
            fechaRoascaRadioButton.Name = "fechaRoascaRadioButton";
            fechaRoascaRadioButton.Size = new Size(90, 19);
            fechaRoascaRadioButton.TabIndex = 6;
            fechaRoascaRadioButton.TabStop = true;
            fechaRoascaRadioButton.Text = "Fecha Rosca";
            fechaRoascaRadioButton.UseVisualStyleBackColor = true;
            // 
            // escalaGroupBox1
            // 
            escalaGroupBox1.Controls.Add(trio1RadioButton);
            escalaGroupBox1.Controls.Add(fechaRoascaRadioButton);
            escalaGroupBox1.Controls.Add(trio3RadioButton);
            escalaGroupBox1.Controls.Add(captãoRadioButton);
            escalaGroupBox1.Controls.Add(trio2RadioButton);
            escalaGroupBox1.Location = new Point(4, 64);
            escalaGroupBox1.Margin = new Padding(4, 3, 4, 3);
            escalaGroupBox1.Name = "escalaGroupBox1";
            escalaGroupBox1.Padding = new Padding(4, 3, 4, 3);
            escalaGroupBox1.Size = new Size(267, 98);
            escalaGroupBox1.TabIndex = 8;
            escalaGroupBox1.TabStop = false;
            escalaGroupBox1.Text = "Posição";
            escalaGroupBox1.Enter += escalaGroupBox1_Enter;
            // 
            // cadastrarButton
            // 
            cadastrarButton.Location = new Point(92, 480);
            cadastrarButton.Margin = new Padding(4, 3, 4, 3);
            cadastrarButton.Name = "cadastrarButton";
            cadastrarButton.Size = new Size(88, 27);
            cadastrarButton.TabIndex = 9;
            cadastrarButton.Text = "Cadastrar";
            cadastrarButton.UseVisualStyleBackColor = true;
            cadastrarButton.Click += cadastrarCompetidorButtonClick;
            // 
            // temIrmãoCheckBox
            // 
            temIrmãoCheckBox.AutoSize = true;
            temIrmãoCheckBox.Location = new Point(4, 3);
            temIrmãoCheckBox.Margin = new Padding(4, 3, 4, 3);
            temIrmãoCheckBox.Name = "temIrmãoCheckBox";
            temIrmãoCheckBox.Size = new Size(83, 19);
            temIrmãoCheckBox.TabIndex = 10;
            temIrmãoCheckBox.Text = "Tem Irmão";
            temIrmãoCheckBox.UseVisualStyleBackColor = true;
            temIrmãoCheckBox.CheckedChanged += temIrmãoCheckBox_CheckedChanged;
            // 
            // irmãoListBox
            // 
            irmãoListBox.FormattingEnabled = true;
            irmãoListBox.Location = new Point(148, 3);
            irmãoListBox.Margin = new Padding(4, 3, 4, 3);
            irmãoListBox.Name = "irmãoListBox";
            irmãoListBox.Size = new Size(137, 109);
            irmãoListBox.TabIndex = 11;
            irmãoListBox.Visible = false;
            irmãoListBox.SelectedIndexChanged += irmãoListBox_SelectedIndexChanged;
            // 
            // categoriasComboBox
            // 
            categoriasComboBox.FormattingEnabled = true;
            categoriasComboBox.Location = new Point(4, 20);
            categoriasComboBox.Margin = new Padding(4, 3, 4, 3);
            categoriasComboBox.Name = "categoriasComboBox";
            categoriasComboBox.Size = new Size(140, 23);
            categoriasComboBox.TabIndex = 12;
            categoriasComboBox.SelectedIndexChanged += categoriasComboBox_SelectedIndexChanged;
            // 
            // categoriasListBox
            // 
            categoriasListBox.FormattingEnabled = true;
            categoriasListBox.Location = new Point(172, 20);
            categoriasListBox.Margin = new Padding(4, 3, 4, 3);
            categoriasListBox.Name = "categoriasListBox";
            categoriasListBox.Size = new Size(139, 109);
            categoriasListBox.TabIndex = 13;
            categoriasListBox.DoubleClick += categoriaListBox_Remove;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 0);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 14;
            label2.Text = "Categorias";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(172, 0);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(134, 15);
            label3.TabIndex = 15;
            label3.Text = "Categorias Selecionadas";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60.41131F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 0, 3);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(escalaGroupBox1, 0, 1);
            tableLayoutPanel1.Location = new Point(13, 12);
            tableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 34.61538F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 65.38461F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 128F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 153F));
            tableLayoutPanel1.Size = new Size(344, 458);
            tableLayoutPanel1.TabIndex = 16;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(label2, 0, 0);
            tableLayoutPanel4.Controls.Add(label3, 1, 0);
            tableLayoutPanel4.Controls.Add(categoriasComboBox, 0, 1);
            tableLayoutPanel4.Controls.Add(categoriasListBox, 1, 1);
            tableLayoutPanel4.Location = new Point(4, 307);
            tableLayoutPanel4.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 11.51515F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 88.48485F));
            tableLayoutPanel4.Size = new Size(336, 148);
            tableLayoutPanel4.TabIndex = 17;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(temIrmãoCheckBox, 0, 0);
            tableLayoutPanel3.Controls.Add(irmãoListBox, 1, 0);
            tableLayoutPanel3.Location = new Point(4, 179);
            tableLayoutPanel3.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(289, 120);
            tableLayoutPanel3.TabIndex = 17;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 115F));
            tableLayoutPanel2.Controls.Add(label4, 0, 1);
            tableLayoutPanel2.Controls.Add(nomeTextBox, 1, 0);
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(sobreNomeTextBox, 1, 1);
            tableLayoutPanel2.Location = new Point(4, 3);
            tableLayoutPanel2.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(267, 55);
            tableLayoutPanel2.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(4, 35);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 2;
            label4.Text = "Sobre Nome";
            label4.Click += label4_Click;
            // 
            // sobreNomeTextBox
            // 
            sobreNomeTextBox.Location = new Point(156, 38);
            sobreNomeTextBox.Margin = new Padding(4, 3, 4, 3);
            sobreNomeTextBox.Name = "sobreNomeTextBox";
            sobreNomeTextBox.Size = new Size(107, 23);
            sobreNomeTextBox.TabIndex = 3;
            // 
            // consultarButton
            // 
            consultarButton.Location = new Point(194, 480);
            consultarButton.Margin = new Padding(4, 3, 4, 3);
            consultarButton.Name = "consultarButton";
            consultarButton.Size = new Size(88, 27);
            consultarButton.TabIndex = 17;
            consultarButton.Text = "Consultar";
            consultarButton.UseVisualStyleBackColor = true;
            consultarButton.Click += ConsultarCompetidorButtonClick;
            // 
            // LimparButton
            // 
            LimparButton.Location = new Point(289, 484);
            LimparButton.Name = "LimparButton";
            LimparButton.Size = new Size(75, 23);
            LimparButton.TabIndex = 18;
            LimparButton.Text = "Limpar";
            LimparButton.UseVisualStyleBackColor = true;
            LimparButton.Click += LimparButton_Click;
            // 
            // ViewCompetidorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(397, 512);
            Controls.Add(LimparButton);
            Controls.Add(consultarButton);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(cadastrarButton);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ViewCompetidorForm";
            Text = "Competidor";
            Load += CadastrarCompetidorForm_Load;
            escalaGroupBox1.ResumeLayout(false);
            escalaGroupBox1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox nomeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton captãoRadioButton;
        private System.Windows.Forms.RadioButton trio1RadioButton;
        private System.Windows.Forms.RadioButton trio2RadioButton;
        private System.Windows.Forms.RadioButton trio3RadioButton;
        private System.Windows.Forms.RadioButton fechaRoascaRadioButton;
        private System.Windows.Forms.GroupBox escalaGroupBox1;
        private System.Windows.Forms.Button cadastrarButton;
        private System.Windows.Forms.CheckBox temIrmãoCheckBox;
        private System.Windows.Forms.ListBox irmãoListBox;
        private System.Windows.Forms.ComboBox categoriasComboBox;
        private System.Windows.Forms.ListBox categoriasListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button consultarButton;
        private Label label4;
        private TextBox sobreNomeTextBox;
        private Button LimparButton;
    }
}