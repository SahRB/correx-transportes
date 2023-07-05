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
    public partial class Form4 : Form
    {

        private SqlConnection con;
        public Form4()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCod_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void btnSalvarProd_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=Sasa;Initial Catalog=correxbd;Integrated Security=True");
          

            string cpfCnpj = txtLoginCpfCnpj.Text;
            string senha = txtLoginSenha.Text;

            if (string.IsNullOrWhiteSpace(cpfCnpj) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Entre com seu CPF para usuario/ CNPJ para empresa e senha.");
                return;
            }

            try
            {
                con.Open();

                string query = "SELECT TipoUsuario FROM Users WHERE CpfCnpj = @cpfCnpj AND Senha = @senha";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@cpfCnpj", cpfCnpj);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string tipoUsuario = result.ToString();                                                                                                                                             

                        if (tipoUsuario == "Usuario")
                        {
                            
                            Form1 f1 = new Form1();
                            f1.Show();
                            this.Hide();
                        }
                        else if (tipoUsuario == "Transportadora")
                        {
                            Produto produto = new Produto();
                            produto.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cpf/ Cnpj ou senha invalido(s).");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro durante login.: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

    }
    }

