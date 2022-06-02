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

namespace banco_de_dados
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string str = "";
            str = "Data source = 10.64.45.32, 1433; Initial Catalog = TI41; User Id = aluno; Password = 123456";
            con = new SqlConnection(str);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                MessageBox.Show("A conexão com o banco está aberta.");
            } else if (con.State == ConnectionState.Closed)
            {
                MessageBox.Show("A conexão com o banco está fechada.");
            }
            else 
            {
                MessageBox.Show("A conexão com o banco pode estar corrompida.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            else
            {
                con.Close();
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                SqlCommand cm;
                string sql = "";
                sql = "insert into matheus_cliente (nome,telefone) values (@NOME,@FONE)";
                cm = new SqlCommand(sql, con);

                cm.Parameters.Add("@NOME", SqlDbType.VarChar).Value = txtNome.Text;
                cm.Parameters.Add("@FONE", SqlDbType.VarChar).Value = txtFone.Text;

                int ret = cm.ExecuteNonQuery();
                if (ret > 0)
                {
                    MessageBox.Show("O cliente foi inserido com sucesso!");
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                MessageBox.Show("A conexão com o banco está aberta.");
            }
            else if (con.State == ConnectionState.Closed)
            {
                MessageBox.Show("A conexão com o banco está fechada.");
            }
            else
            {
                MessageBox.Show("A conexão com o banco pode estar corrompida.");
            }
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SqlCommand cm;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable tb = new DataTable();
            string sql = "select * from matheus_cliente";
            cm = new SqlCommand(sql, con);
            da.SelectCommand = cm;
            da.Fill(tb);
            dtgCliente.DataSource = null;
            dtgCliente.DataSource = tb;

        }

        private void dtgCliente_Click(object sender, EventArgs e)
        {
            if (dtgCliente.Rows.Count > 0)
            {
                txtNome.Text = dtgCliente.CurrentRow.Cells[1].Value.ToString();
                txtFone.Text = dtgCliente.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void dtgCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
