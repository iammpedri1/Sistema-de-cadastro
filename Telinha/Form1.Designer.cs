namespace Telinha
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtNome = new TextBox();
            txtIdade = new TextBox();
            lblNome = new Label();
            lblIdade = new Label();
            lblNasci = new Label();
            btnSalva = new Button();
            dataGridView1 = new DataGridView();
            txtBuscar = new TextBox();
            label1 = new Label();
            btnPesquisar = new Button();
            btnEditar = new Button();
            btnExcluir = new Button();
            btnCancelar = new Button();
            dtpDataNascimento = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // txtNome
            // 
            txtNome.Location = new Point(28, 305);
            txtNome.Name = "txtNome";
            txtNome.PlaceholderText = "Digite seu nome";
            txtNome.Size = new Size(250, 23);
            txtNome.TabIndex = 0;
            // 
            // txtIdade
            // 
            txtIdade.Location = new Point(308, 305);
            txtIdade.Name = "txtIdade";
            txtIdade.Size = new Size(54, 23);
            txtIdade.TabIndex = 1;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNome.Location = new Point(28, 275);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(56, 18);
            lblNome.TabIndex = 3;
            lblNome.Text = "Nome";
            lblNome.Click += label1_Click;
            // 
            // lblIdade
            // 
            lblIdade.AutoSize = true;
            lblIdade.Font = new Font("Verdana", 11.25F, FontStyle.Bold);
            lblIdade.Location = new Point(306, 266);
            lblIdade.Name = "lblIdade";
            lblIdade.Size = new Size(56, 18);
            lblIdade.TabIndex = 4;
            lblIdade.Text = "Idade";
            // 
            // lblNasci
            // 
            lblNasci.AutoSize = true;
            lblNasci.Font = new Font("Verdana", 11.25F, FontStyle.Bold);
            lblNasci.Location = new Point(400, 266);
            lblNasci.Name = "lblNasci";
            lblNasci.Size = new Size(173, 18);
            lblNasci.TabIndex = 5;
            lblNasci.Text = "Data de Nascimento";
            // 
            // btnSalva
            // 
            btnSalva.BackColor = Color.FromArgb(0, 150, 0);
            btnSalva.FlatStyle = FlatStyle.Flat;
            btnSalva.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalva.ForeColor = Color.White;
            btnSalva.Location = new Point(28, 360);
            btnSalva.Name = "btnSalva";
            btnSalva.Size = new Size(110, 40);
            btnSalva.TabIndex = 6;
            btnSalva.Text = "Salvar";
            btnSalva.UseVisualStyleBackColor = false;
            btnSalva.Click += btnSalva_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 84);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(731, 150);
            dataGridView1.TabIndex = 7;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(12, 37);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Digite um nome para pesquisar";
            txtBuscar.Size = new Size(207, 23);
            txtBuscar.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(81, 18);
            label1.TabIndex = 9;
            label1.Text = "Pesquisa";
            // 
            // btnPesquisar
            // 
            btnPesquisar.BackColor = Color.FromArgb(0, 120, 212);
            btnPesquisar.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPesquisar.ForeColor = Color.White;
            btnPesquisar.Location = new Point(228, 31);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(110, 35);
            btnPesquisar.TabIndex = 10;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = false;
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.Orange;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditar.ForeColor = SystemColors.Window;
            btnEditar.Location = new Point(168, 360);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(110, 40);
            btnEditar.TabIndex = 11;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.BackColor = Color.FromArgb(192, 0, 0);
            btnExcluir.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExcluir.ForeColor = Color.White;
            btnExcluir.Location = new Point(308, 360);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(110, 40);
            btnExcluir.TabIndex = 12;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = false;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(128, 128, 128);
            btnCancelar.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(444, 360);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(110, 40);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // dtpDataNascimento
            // 
            dtpDataNascimento.Location = new Point(400, 305);
            dtpDataNascimento.Name = "dtpDataNascimento";
            dtpDataNascimento.Size = new Size(230, 23);
            dtpDataNascimento.TabIndex = 14;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(755, 427);
            Controls.Add(dtpDataNascimento);
            Controls.Add(btnCancelar);
            Controls.Add(btnExcluir);
            Controls.Add(btnEditar);
            Controls.Add(btnPesquisar);
            Controls.Add(label1);
            Controls.Add(txtBuscar);
            Controls.Add(dataGridView1);
            Controls.Add(btnSalva);
            Controls.Add(lblNasci);
            Controls.Add(lblIdade);
            Controls.Add(lblNome);
            Controls.Add(txtIdade);
            Controls.Add(txtNome);
            Name = "Form1";
            Text = "Sistema de Cadastro - Pessoal";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNome;
        private TextBox txtIdade;
        private Label lblNome;
        private Label lblIdade;
        private Label lblNasci;
        private Button btnSalva;
        private DataGridView dataGridView1;
        private TextBox txtBuscar;
        private Label label1;
        private Button btnPesquisar;
        private Button btnEditar;
        private Button btnExcluir;
        private Button btnCancelar;
        private DateTimePicker dtpDataNascimento;
    }
}
