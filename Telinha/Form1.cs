using MySql.Data.MySqlClient;
using MySql.Data;
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
            BuscarDados("");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Por favor, preencha o Nome!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtIdade.Text) || !int.TryParse(txtIdade.Text, out int idade) || idade < 0 || idade > 150)
            {
                MessageBox.Show("Por favor, preencha a Idade corretamente (0-150)!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdade.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDataNascimento.Text) || !DateTime.TryParse(txtDataNascimento.Text, out _))
            {
                MessageBox.Show("Por favor, preencha a Data de Nascimento corretamente (DD/MM/YYYY)!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDataNascimento.Focus();
                return false;
            }

            return true;
        }

        private void btnSalva_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            string query = "";
            string mensagem = "";

            if (id == 0)
            {
                query = "INSERT INTO dados(nome, dataNascimento, idade) VALUES" +
                    " (@nome, @dataNascimento, @idade)";
                mensagem = "Cadastro";
            }
            else
            {
                query = "UPDATE dados SET nome = @nome, idade = @idade, dataNascimento = @dataNascimento WHERE id = @id";
                mensagem = "Dados";
            }

            using (MySqlConnection conexaoBD = new MySqlConnection(conexao))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conexaoBD))
                {
                    try
                    {
                        DateTime d = DateTime.Parse(txtDataNascimento.Text);
                        cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                        cmd.Parameters.AddWithValue("@dataNascimento", d);
                        cmd.Parameters.AddWithValue("@idade", int.Parse(txtIdade.Text));

                        if (id != 0)
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                        }

                        conexaoBD.Open();
                        cmd.ExecuteNonQuery();
                        conexaoBD.Close();

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
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao salvar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtIdade.Clear();
            txtDataNascimento.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                txtNome.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDataNascimento.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtIdade.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string busca = txtBuscar.Text;

            BuscarDados(busca);
        }

        public void BuscarDados(string busca)
        {
            string queryPesquisa;

            if (string.IsNullOrEmpty(busca))
            {
                queryPesquisa = "SELECT * FROM dados";
            }
            else
            {
                queryPesquisa = "SELECT * FROM dados WHERE nome LIKE @busca";
            }

            using (MySqlConnection conexaoBD = new MySqlConnection(conexao))
            {
                try
                {
                    conexaoBD.Open();
                    using (MySqlCommand cmd = new MySqlCommand(queryPesquisa, conexaoBD))
                    {
                        if (!string.IsNullOrEmpty(busca))
                        {
                            cmd.Parameters.AddWithValue("@busca", "%" + busca + "%");
                        }

                        try
                        {
                            using (MySqlDataAdapter selectao = new MySqlDataAdapter(cmd))
                            {
                                DataTable tabelagrid = new DataTable();
                                selectao.Fill(tabelagrid);
                                dataGridView1.DataSource = tabelagrid;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocorreu um erro: " + ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao pesquisar: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Selecione um registro na tabela para editar!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidarCampos())
                return;

            string query = "UPDATE dados SET nome = @nome, idade = @idade, dataNascimento = @dataNascimento WHERE id = @id";

            using (MySqlConnection conexaoBD = new MySqlConnection(conexao))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conexaoBD))
                {
                    try
                    {
                        DateTime d = DateTime.Parse(txtDataNascimento.Text);
                        cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                        cmd.Parameters.AddWithValue("@dataNascimento", d);
                        cmd.Parameters.AddWithValue("@idade", int.Parse(txtIdade.Text));
                        cmd.Parameters.AddWithValue("@id", id);

                        conexaoBD.Open();
                        cmd.ExecuteNonQuery();
                        conexaoBD.Close();

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
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao editar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("Selecione um registro na tabela para excluir!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            using (MySqlConnection conexaoBD = new MySqlConnection(conexao))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conexaoBD))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        conexaoBD.Open();
                        cmd.ExecuteNonQuery();
                        conexaoBD.Close();

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
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao deletar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            id = 0;
            BuscarDados("");
        }
    }
}
