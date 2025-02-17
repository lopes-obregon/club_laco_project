namespace CompetiFácilLaço
{
    partial class CadastrarCompetidorForm
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
            this.nomeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.captãoRadioButton = new System.Windows.Forms.RadioButton();
            this.trio1RadioButton = new System.Windows.Forms.RadioButton();
            this.trio2RadioButton = new System.Windows.Forms.RadioButton();
            this.trio3RadioButton = new System.Windows.Forms.RadioButton();
            this.fechaRoascaRadioButton = new System.Windows.Forms.RadioButton();
            this.escalaGroupBox1 = new System.Windows.Forms.GroupBox();
            this.cadastrarButton = new System.Windows.Forms.Button();
            this.temIrmãoCheckBox = new System.Windows.Forms.CheckBox();
            this.irmãoListBox = new System.Windows.Forms.ListBox();
            this.categoriasComboBox = new System.Windows.Forms.ComboBox();
            this.categoriasListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.escalaGroupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // nomeTextBox
            // 
            this.nomeTextBox.Location = new System.Drawing.Point(47, 3);
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.Size = new System.Drawing.Size(93, 20);
            this.nomeTextBox.TabIndex = 0;
            this.nomeTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // captãoRadioButton
            // 
            this.captãoRadioButton.AutoSize = true;
            this.captãoRadioButton.Location = new System.Drawing.Point(46, 41);
            this.captãoRadioButton.Name = "captãoRadioButton";
            this.captãoRadioButton.Size = new System.Drawing.Size(59, 17);
            this.captãoRadioButton.TabIndex = 2;
            this.captãoRadioButton.TabStop = true;
            this.captãoRadioButton.Text = "Captão";
            this.captãoRadioButton.UseVisualStyleBackColor = true;
            this.captãoRadioButton.CheckedChanged += new System.EventHandler(this.captãoRadioButton_CheckedChanged);
            // 
            // trio1RadioButton
            // 
            this.trio1RadioButton.AutoSize = true;
            this.trio1RadioButton.Location = new System.Drawing.Point(111, 41);
            this.trio1RadioButton.Name = "trio1RadioButton";
            this.trio1RadioButton.Size = new System.Drawing.Size(52, 17);
            this.trio1RadioButton.TabIndex = 3;
            this.trio1RadioButton.TabStop = true;
            this.trio1RadioButton.Text = "Trio-1";
            this.trio1RadioButton.UseVisualStyleBackColor = true;
            // 
            // trio2RadioButton
            // 
            this.trio2RadioButton.AutoSize = true;
            this.trio2RadioButton.Location = new System.Drawing.Point(169, 41);
            this.trio2RadioButton.Name = "trio2RadioButton";
            this.trio2RadioButton.Size = new System.Drawing.Size(52, 17);
            this.trio2RadioButton.TabIndex = 4;
            this.trio2RadioButton.TabStop = true;
            this.trio2RadioButton.Text = "Trio-2";
            this.trio2RadioButton.UseVisualStyleBackColor = true;
            // 
            // trio3RadioButton
            // 
            this.trio3RadioButton.AutoSize = true;
            this.trio3RadioButton.Location = new System.Drawing.Point(46, 64);
            this.trio3RadioButton.Name = "trio3RadioButton";
            this.trio3RadioButton.Size = new System.Drawing.Size(52, 17);
            this.trio3RadioButton.TabIndex = 5;
            this.trio3RadioButton.TabStop = true;
            this.trio3RadioButton.Text = "Trio-3";
            this.trio3RadioButton.UseVisualStyleBackColor = true;
            // 
            // fechaRoascaRadioButton
            // 
            this.fechaRoascaRadioButton.AutoSize = true;
            this.fechaRoascaRadioButton.Location = new System.Drawing.Point(104, 64);
            this.fechaRoascaRadioButton.Name = "fechaRoascaRadioButton";
            this.fechaRoascaRadioButton.Size = new System.Drawing.Size(89, 17);
            this.fechaRoascaRadioButton.TabIndex = 6;
            this.fechaRoascaRadioButton.TabStop = true;
            this.fechaRoascaRadioButton.Text = "Fecha Rosca";
            this.fechaRoascaRadioButton.UseVisualStyleBackColor = true;
            // 
            // escalaGroupBox1
            // 
            this.escalaGroupBox1.Controls.Add(this.trio1RadioButton);
            this.escalaGroupBox1.Controls.Add(this.fechaRoascaRadioButton);
            this.escalaGroupBox1.Controls.Add(this.trio3RadioButton);
            this.escalaGroupBox1.Controls.Add(this.captãoRadioButton);
            this.escalaGroupBox1.Controls.Add(this.trio2RadioButton);
            this.escalaGroupBox1.Location = new System.Drawing.Point(3, 55);
            this.escalaGroupBox1.Name = "escalaGroupBox1";
            this.escalaGroupBox1.Size = new System.Drawing.Size(229, 85);
            this.escalaGroupBox1.TabIndex = 8;
            this.escalaGroupBox1.TabStop = false;
            this.escalaGroupBox1.Text = "Escala";
            // 
            // cadastrarButton
            // 
            this.cadastrarButton.Location = new System.Drawing.Point(388, 415);
            this.cadastrarButton.Name = "cadastrarButton";
            this.cadastrarButton.Size = new System.Drawing.Size(75, 23);
            this.cadastrarButton.TabIndex = 9;
            this.cadastrarButton.Text = "Cadastrar";
            this.cadastrarButton.UseVisualStyleBackColor = true;
            this.cadastrarButton.Click += new System.EventHandler(this.cadastrarCompetidorButtonClick);
            // 
            // temIrmãoCheckBox
            // 
            this.temIrmãoCheckBox.AutoSize = true;
            this.temIrmãoCheckBox.Location = new System.Drawing.Point(3, 3);
            this.temIrmãoCheckBox.Name = "temIrmãoCheckBox";
            this.temIrmãoCheckBox.Size = new System.Drawing.Size(76, 17);
            this.temIrmãoCheckBox.TabIndex = 10;
            this.temIrmãoCheckBox.Text = "Tem Irmão";
            this.temIrmãoCheckBox.UseVisualStyleBackColor = true;
            this.temIrmãoCheckBox.CheckedChanged += new System.EventHandler(this.temIrmãoCheckBox_CheckedChanged);
            // 
            // irmãoListBox
            // 
            this.irmãoListBox.FormattingEnabled = true;
            this.irmãoListBox.Location = new System.Drawing.Point(127, 3);
            this.irmãoListBox.Name = "irmãoListBox";
            this.irmãoListBox.Size = new System.Drawing.Size(118, 95);
            this.irmãoListBox.TabIndex = 11;
            this.irmãoListBox.Visible = false;
            this.irmãoListBox.SelectedIndexChanged += new System.EventHandler(this.irmãoListBox_SelectedIndexChanged);
            // 
            // categoriasComboBox
            // 
            this.categoriasComboBox.FormattingEnabled = true;
            this.categoriasComboBox.Location = new System.Drawing.Point(3, 17);
            this.categoriasComboBox.Name = "categoriasComboBox";
            this.categoriasComboBox.Size = new System.Drawing.Size(121, 21);
            this.categoriasComboBox.TabIndex = 12;
            this.categoriasComboBox.SelectedIndexChanged += new System.EventHandler(this.categoriasComboBox_SelectedIndexChanged);
            // 
            // categoriasListBox
            // 
            this.categoriasListBox.FormattingEnabled = true;
            this.categoriasListBox.Location = new System.Drawing.Point(147, 17);
            this.categoriasListBox.Name = "categoriasListBox";
            this.categoriasListBox.Size = new System.Drawing.Size(120, 95);
            this.categoriasListBox.TabIndex = 13;
            this.categoriasListBox.DoubleClick += new System.EventHandler(this.categoriaListBox_Remove);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Categorias";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Categorias Selecionadas";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.41131F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.escalaGroupBox1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(281, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.61538F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.38461F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(295, 397);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.tableLayoutPanel2.Controls.Add(this.nomeTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(143, 27);
            this.tableLayoutPanel2.TabIndex = 17;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.temIrmãoCheckBox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.irmãoListBox, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 155);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(248, 104);
            this.tableLayoutPanel3.TabIndex = 17;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.categoriasComboBox, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.categoriasListBox, 1, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 266);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.51515F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.48485F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(289, 128);
            this.tableLayoutPanel4.TabIndex = 17;
            // 
            // CadastrarCompetidorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.cadastrarButton);
            this.Name = "CadastrarCompetidorForm";
            this.Text = "CadastrarCompetidorForm";
            this.Load += new System.EventHandler(this.CadastrarCompetidorForm_Load);
            this.escalaGroupBox1.ResumeLayout(false);
            this.escalaGroupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

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
    }
}