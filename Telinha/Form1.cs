using MySql.Data.MySqlClient;
using System.Data;

namespace Telinha
{
    public partial class Form1 : Form
    {
        public int id = 0;
        public string conexao = "server=localhost;database=CadastroPessoal;uid=root;pwd=;";

        public Form1()
        {
            InitializeComponent();

            dtpDataNascimento.Format = DateTimePickerFormat.Custom;
            dtpDataNascimento.CustomFormat = "dd/MM/yyyy";

            BuscarDados("");
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show(
                    "Por favor, preencha o Nome!",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtNome.Focus();
                return false;
            }

            if (!int.TryParse(txtIdade.Text.Trim(), out int idade) || idade < 0 || idade > 150)
            {
                MessageBox.Show(
                    "Por favor, informe uma idade válida entre 0 e 150!",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtIdade.Focus();
                return false;
            }

            return true;
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            string query;
            string mensagem;

            if (id == 0)
            {
                query = @"INSERT INTO dados
                          (nome, dataNascimento, idade)
                          VALUES
                          (@nome, @dataNascimento, @idade)";

                mensagem = "Cadastro";
            }
            else
            {
                query = @"UPDATE dados
                          SET nome = @nome,
                              dataNascimento = @dataNascimento,
                              idade = @idade
                          WHERE id = @id";

                mensagem = "Atualização";
            }

            try
            {
                using (MySqlConnection conexaoBD = new MySqlConnection(conexao))
                using (MySqlCommand cmd = new MySqlCommand(query, conexaoBD))
                {
                    cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value =
                        txtNome.Text.Trim();

                    cmd.Parameters.Add("@dataNascimento", MySqlDbType.Date).Value =
                        dtpDataNascimento.Value.Date;

                    cmd.Parameters.Add("@idade", MySqlDbType.Int32).Value =
                        int.Parse(txtIdade.Text.Trim());

                    if (id != 0)
                    {
                        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    }

                    conexaoBD.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        $"{mensagem} realizado com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    LimparCampos();
                    id = 0;
                    BuscarDados("");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erro no banco de dados:\n\n" + ex.Message,
                    "Erro MySQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao salvar:\n\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtIdade.Clear();
            dtpDataNascimento.Value = DateTime.Today;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                id = Convert.ToInt32(
                    dataGridView1.Rows[e.RowIndex].Cells[0].Value
                );

                txtNome.Text = Convert.ToString(
                    dataGridView1.Rows[e.RowIndex].Cells[1].Value
                );

                if (DateTime.TryParse(
                    Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value),
                    out DateTime dataNascimento))
                {
                    dtpDataNascimento.Value = dataNascimento;
                }

                txtIdade.Text = Convert.ToString(
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao selecionar o registro:\n\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            BuscarDados(txtBuscar.Text.Trim());
        }

        public void BuscarDados(string busca)
        {
            string queryPesquisa;

            if (string.IsNullOrWhiteSpace(busca))
            {
                queryPesquisa = "SELECT * FROM dados";
            }
            else
            {
                queryPesquisa = "SELECT * FROM dados WHERE nome LIKE @busca";
            }

            try
            {
                using (MySqlConnection conexaoBD = new MySqlConnection(conexao))
                using (MySqlCommand cmd = new MySqlCommand(queryPesquisa, conexaoBD))
                {
                    if (!string.IsNullOrWhiteSpace(busca))
                    {
                        cmd.Parameters.Add("@busca", MySqlDbType.VarChar).Value =
                            "%" + busca + "%";
                    }

                    using (MySqlDataAdapter selecao = new MySqlDataAdapter(cmd))
                    {
                        DataTable tabelaGrid = new DataTable();

                        selecao.Fill(tabelaGrid);

                        dataGridView1.DataSource = tabelaGrid;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erro ao pesquisar no banco de dados:\n\n" + ex.Message,
                    "Erro MySQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao pesquisar:\n\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show(
                    "Selecione um registro na tabela antes de editar!",
                    "Informação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            if (!ValidarCampos())
                return;

            string query = @"UPDATE dados
                             SET nome = @nome,
                                 idade = @idade,
                                 dataNascimento = @dataNascimento
                             WHERE id = @id";

            try
            {
                using (MySqlConnection conexaoBD = new MySqlConnection(conexao))
                using (MySqlCommand cmd = new MySqlCommand(query, conexaoBD))
                {
                    cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value =
                        txtNome.Text.Trim();

                    cmd.Parameters.Add("@idade", MySqlDbType.Int32).Value =
                        int.Parse(txtIdade.Text.Trim());

                    cmd.Parameters.Add("@dataNascimento", MySqlDbType.Date).Value =
                        dtpDataNascimento.Value.Date;

                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                    conexaoBD.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Registro atualizado com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    LimparCampos();
                    id = 0;
                    BuscarDados("");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erro no banco de dados:\n\n" + ex.Message,
                    "Erro MySQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao atualizar:\n\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show(
                    "Selecione um registro na tabela para excluir!",
                    "Informação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return;
            }

            DialogResult resultado = MessageBox.Show(
                $"Tem certeza que deseja excluir '{txtNome.Text}'?",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.No)
                return;

            string query = "DELETE FROM dados WHERE id = @id";

            try
            {
                using (MySqlConnection conexaoBD = new MySqlConnection(conexao))
                using (MySqlCommand cmd = new MySqlCommand(query, conexaoBD))
                {
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                    conexaoBD.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Registro deletado com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    LimparCampos();
                    id = 0;
                    BuscarDados("");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erro no banco de dados:\n\n" + ex.Message,
                    "Erro MySQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao deletar:\n\n" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            id = 0;
            BuscarDados("");
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtpDataNascimento.Format = DateTimePickerFormat.Custom;
            dtpDataNascimento.CustomFormat = "dd/MM/yyyy";
        }
    }
}
