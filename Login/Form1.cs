using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string trackingCode = txtRastreio.Text;

            using (SqlConnection con = new SqlConnection("Data Source=Sasa;Initial Catalog=correxbd;Integrated Security=True"))
            {
                con.Open();

               
                string query = "SELECT nomeProduto, status, localAtual, previsao FROM tabelaProduto WHERE idProduto = @idProduto";

     
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@idProduto", trackingCode);

                   
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string nomeProduto = reader.GetString(0);
                            string status = reader.GetString(1);
                            string localAtual = reader.GetString(2);
                            DateTime previsao = reader.GetDateTime(3);

                            
                            panel1.Controls.Clear();

                            int yPos = 10; 

                            Label lblNomeProduto = new Label();
                            lblNomeProduto.Text = "Nome do Produto: " + nomeProduto;
                            lblNomeProduto.AutoSize = true;
                            lblNomeProduto.Location = new Point(10, yPos);

                            Label lblStatus = new Label();
                            lblStatus.Text = "Status: " + status;
                            lblStatus.AutoSize = true;
                            lblStatus.Location = new Point(10, yPos + 25);

                            Label lblLocalAtual = new Label();
                            lblLocalAtual.Text = "Local Atual: " + localAtual;
                            lblLocalAtual.AutoSize = true;
                            lblLocalAtual.Location = new Point(10, yPos + 50);

                            Label lblPrevisao = new Label();
                            lblPrevisao.Text = "Previsao: " + previsao.ToString();
                            lblPrevisao.AutoSize = true;
                            lblPrevisao.Location = new Point(10, yPos + 75);

                            panel1.Controls.Add(lblNomeProduto);
                            panel1.Controls.Add(lblStatus);
                            panel1.Controls.Add(lblLocalAtual);
                            panel1.Controls.Add(lblPrevisao);
                        }
                        else
                        {
                            MessageBox.Show("Codigo de rastreio nao encontrado.");
                        }
                    }
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Produto prod = new Produto();
            prod.Show();
            this.Hide();
        }
    }
}
