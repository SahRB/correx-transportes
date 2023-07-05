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
    public partial class Form3 : Form
    {
        private SqlConnection con;

        public Form3()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSalvarProd_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=Sasa;Initial Catalog=correxbd;Integrated Security=True");
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();

            string nome = txtNome.Text;
            string cpfCnpj = txtCpfCnpj.Text;
            string tipoUsuario = cmbTipoUsuario.SelectedItem.ToString();
            string endereco = txtEndereco.Text;
            string estado = txtEstado.Text;
            string cidade = txtCidade.Text;
            string telefone = txtTelefone.Text;
            string senha = txtSenha.Text;

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(cpfCnpj) || string.IsNullOrWhiteSpace(tipoUsuario) ||
                string.IsNullOrWhiteSpace(endereco) || string.IsNullOrWhiteSpace(estado) || string.IsNullOrWhiteSpace(cidade) ||
                string.IsNullOrWhiteSpace(telefone) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            try
            {
                con.Open();

                string query = "INSERT INTO Users (Nome, CpfCnpj, TipoUsuario, Endereco, Estado, Cidade, Telefone, Senha) " +
                               "VALUES (@nome, @cpfCnpj, @tipoUsuario, @endereco, @estado, @cidade, @telefone, @senha)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@cpfCnpj", cpfCnpj);
                    cmd.Parameters.AddWithValue("@tipoUsuario", tipoUsuario);
                    cmd.Parameters.AddWithValue("@endereco", endereco);
                    cmd.Parameters.AddWithValue("@estado", estado);
                    cmd.Parameters.AddWithValue("@cidade", cidade);
                    cmd.Parameters.AddWithValue("@telefone", telefone);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Usuario Registrado com sucesso.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro durante o registro: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }


    }

}
