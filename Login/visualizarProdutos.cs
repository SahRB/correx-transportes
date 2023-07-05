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
    public partial class visualizarProdutos : Form
    {
        private SqlConnection con;
        public visualizarProdutos()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRastreio_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=Sasa;Initial Catalog=correxbd;Integrated Security=True");
            con.Open();

            string query = "SELECT * FROM tabelaProduto";
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            
            DataGridView dataGridView1 = new DataGridView();

            dataGridView1.AutoGenerateColumns = true;

            
            dataGridView1.DataSource = dt;

          
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Produto productManagementForm = new Produto();
            productManagementForm.Show();
            this.Hide();
        }
    }
}
