using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Login
{
    public partial class Produto : Form
    {
        public Produto()
        {
            InitializeComponent();
        }

        private void Produto_Load(object sender, EventArgs e)
        {
            LoadDataToDataGridView();
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnSalvarProd_Click(object sender, EventArgs e)
        {

          

            string idProduto = txtIdProd.Text;

            if (string.IsNullOrEmpty(idProduto))
            {
                MessageBox.Show("Por favor, selecione um produto para excluir.");
                return;
            }

            DialogResult result = MessageBox.Show("Tem certeza de que deseja excluir o produto?", "Confirmação de exclusão", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection("Data Source=Sasa;Initial Catalog=correxbd;Integrated Security=True"))
                {
                    con.Open();

                    string query = "DELETE FROM tabelaProduto WHERE idProduto = @idProduto";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@idProduto", idProduto);

                        cmd.ExecuteNonQuery();
                    }
                }

                ClearForm();
                LoadDataToDataGridView();
            }

        }
        private void ClearForm()
        {
            txtIdProd.Text = "";
            txtNomeProd.Text = "";
            txtStatusProd.Text = "";
            txtLocalAtual.Text = "";
            txtData.Text = "";
            txtTipo.Text = "";
            txtPeso.Text = "";
            txtTamanho.Text = "";
            txtRemetente.Text = "";
            txtDestinatario.Text = "";
            txtCpfDestinatario.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnCod_Click(object sender, EventArgs e)
        {
            string trackingCode = GenerateTrackingCode();

            txtIdProd.Text = trackingCode;

            SaveTrackingCodeToDatabase(trackingCode);

            DialogResult result = MessageBox.Show("Código de rastreio: " + trackingCode + "\n\nDeseja copiar o código?", "Código de rastreio", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Clipboard.SetText(trackingCode);
                MessageBox.Show("O código foi copiado.", "Sucesso!");
            }
        }

        private string GenerateTrackingCode()
        {
            Random random = new Random();
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] codeArray = new char[10];

            for (int i = 0; i < codeArray.Length; i++)
            {
                codeArray[i] = characters[random.Next(characters.Length)];
            }

            string trackingCode = new string(codeArray);
            return trackingCode;
        }

        private void SaveTrackingCodeToDatabase(string trackingCode)
        {
            using (SqlConnection con = new SqlConnection("Data Source=Sasa;Initial Catalog=correxbd;Integrated Security=True"))
            {
                con.Open();

                string query = "INSERT INTO tabelaProduto (idProduto, nomeProduto, status, localAtual, previsao, tipoProduto, peso, tamanho, remetente, destinatario, cpfDestinatario) " +
                               "VALUES (@idProduto, @nomeProduto, @status, @localAtual, @previsao, @tipoProduto, @peso, @tamanho, @remetente, @destinatario, @cpfDestinatario)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    float peso;
                    float tamanho;

                    if (float.TryParse(txtPeso.Text, out peso) && float.TryParse(txtTamanho.Text, out tamanho))
                    {
                        cmd.Parameters.AddWithValue("@peso", peso);
                        cmd.Parameters.AddWithValue("@tamanho", tamanho);
                    }
                    else
                    {
                        MessageBox.Show("Valor de peso ou tamanho inválido. Por favor, insira um valor numérico válido.");
                        return;
                    }

                    cmd.Parameters.AddWithValue("@idProduto", trackingCode);
                    cmd.Parameters.AddWithValue("@nomeProduto", txtNomeProd.Text);
                    cmd.Parameters.AddWithValue("@status", txtStatusProd.Text);
                    cmd.Parameters.AddWithValue("@localAtual", txtLocalAtual.Text);
                    cmd.Parameters.AddWithValue("@tipoProduto", txtTipo.Text);
                    cmd.Parameters.AddWithValue("@remetente", txtRemetente.Text);
                    cmd.Parameters.AddWithValue("@destinatario", txtDestinatario.Text);
                    cmd.Parameters.AddWithValue("@cpfDestinatario", txtCpfDestinatario.Text);

                    DateTime previsao;

                    if (DateTime.TryParse(txtData.Text, out previsao))
                    {
                        cmd.Parameters.AddWithValue("@previsao", previsao);
                    }
                    else
                    {
                        MessageBox.Show("Formato de data inválido. Por favor, insira uma data válida.");
                        return;
                    }

                    cmd.ExecuteNonQuery();
                }
            }

            LoadDataToDataGridView();
        }

        private void LoadDataToDataGridView()
        {
            using (SqlConnection con = new SqlConnection("Data Source=Sasa;Initial Catalog=correxbd;Integrated Security=True"))
            {
                con.Open();

                string query = "SELECT * FROM tabelaProduto";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView.DataSource = dataTable;
                }
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            string idProduto = txtIdProd.Text;

            if (string.IsNullOrEmpty(idProduto))
            {
                MessageBox.Show("Por favor, selecione um produto para atualizar.");
                return;
            }

            using (SqlConnection con = new SqlConnection("Data Source=Sasa;Initial Catalog=correxbd;Integrated Security=True"))
            {
                con.Open();

                string query = "UPDATE tabelaProduto SET nomeProduto = @nomeProduto, status = @status, localAtual = @localAtual, " +
                               "previsao = @previsao, tipoProduto = @tipoProduto, peso = @peso, tamanho = @tamanho, " +
                               "remetente = @remetente, destinatario = @destinatario, cpfDestinatario = @cpfDestinatario " +
                               "WHERE idProduto = @idProduto";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    float peso;
                    float tamanho;

                    if (float.TryParse(txtPeso.Text, out peso) && float.TryParse(txtTamanho.Text, out tamanho))
                    {
                        cmd.Parameters.AddWithValue("@peso", peso);
                        cmd.Parameters.AddWithValue("@tamanho", tamanho);
                    }
                    else
                    {
                        MessageBox.Show("Valor de peso ou tamanho inválido. Por favor, insira um valor numérico válido.");
                        return;
                    }

                    cmd.Parameters.AddWithValue("@idProduto", idProduto);
                    cmd.Parameters.AddWithValue("@nomeProduto", txtNomeProd.Text);
                    cmd.Parameters.AddWithValue("@status", txtStatusProd.Text);
                    cmd.Parameters.AddWithValue("@localAtual", txtLocalAtual.Text);
                    cmd.Parameters.AddWithValue("@tipoProduto", txtTipo.Text);
                    cmd.Parameters.AddWithValue("@remetente", txtRemetente.Text);
                    cmd.Parameters.AddWithValue("@destinatario", txtDestinatario.Text);
                    cmd.Parameters.AddWithValue("@cpfDestinatario", txtCpfDestinatario.Text);

                    DateTime previsao;

                    if (DateTime.TryParse(txtData.Text, out previsao))
                    {
                        cmd.Parameters.AddWithValue("@previsao", previsao);
                    }
                    else
                    {
                        MessageBox.Show("Formato de data inválido. Por favor, insira uma data válida.");
                        return;
                    }

                    cmd.ExecuteNonQuery();
                }
            }

            LoadDataToDataGridView();
        }

        private void maskedTextBox4_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox6_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void btnAtualizar_Click_1(object sender, EventArgs e)
        {
            string idProduto = txtIdProd.Text;

            if (string.IsNullOrEmpty(idProduto))
            {
                MessageBox.Show("Por favor, selecione um produto para atualizar.");
                return;
            }

            using (SqlConnection con = new SqlConnection("Data Source=Sasa;Initial Catalog=correxbd;Integrated Security=True"))
            {
                con.Open();

                string query = "UPDATE tabelaProduto SET nomeProduto = @nomeProduto, status = @status, localAtual = @localAtual, " +
                               "previsao = @previsao, tipoProduto = @tipoProduto, peso = @peso, tamanho = @tamanho, " +
                               "remetente = @remetente, destinatario = @destinatario, cpfDestinatario = @cpfDestinatario " +
                               "WHERE idProduto = @idProduto";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    float peso;
                    float tamanho;

                    if (float.TryParse(txtPeso.Text, out peso) && float.TryParse(txtTamanho.Text, out tamanho))
                    {
                        cmd.Parameters.AddWithValue("@peso", peso);
                        cmd.Parameters.AddWithValue("@tamanho", tamanho);
                    }
                    else
                    {
                        MessageBox.Show("Valor de peso ou tamanho inválido. Por favor, insira um valor numérico válido.");
                        return;
                    }

                    cmd.Parameters.AddWithValue("@idProduto", idProduto);
                    cmd.Parameters.AddWithValue("@nomeProduto", txtNomeProd.Text);
                    cmd.Parameters.AddWithValue("@status", txtStatusProd.Text);
                    cmd.Parameters.AddWithValue("@localAtual", txtLocalAtual.Text);
                    cmd.Parameters.AddWithValue("@tipoProduto", txtTipo.Text);
                    cmd.Parameters.AddWithValue("@remetente", txtRemetente.Text);
                    cmd.Parameters.AddWithValue("@destinatario", txtDestinatario.Text);
                    cmd.Parameters.AddWithValue("@cpfDestinatario", txtCpfDestinatario.Text);

                    DateTime previsao;

                    if (DateTime.TryParse(txtData.Text, out previsao))
                    {
                        cmd.Parameters.AddWithValue("@previsao", previsao);
                    }
                    else
                    {
                        MessageBox.Show("Formato de data inválido. Por favor, insira uma data válida.");
                        return;
                    }

                    cmd.ExecuteNonQuery();
                }
            }

            LoadDataToDataGridView();
        }
    }
}
