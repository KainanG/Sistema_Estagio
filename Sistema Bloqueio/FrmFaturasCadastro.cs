using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Bloqueio
{
    public partial class FrmFaturasCadastro : Form
    {
        int id;
        DataTable dt = new DataTable();
        Fatura fatura = new Fatura();

        public FrmFaturasCadastro()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            dt = Cliente.GetClientes();
            dgv_Clientes.DataSource = dt;
            ConfigurarGradeClientes();
        }

        private void ConfigurarGradeClientes()
        {

            dgv_Clientes.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgv_Clientes.DefaultCellStyle.Font = new Font("Arial", 9);
            dgv_Clientes.RowHeadersWidth = 25;

            dgv_Clientes.Columns["id"].HeaderText = "ID";
            dgv_Clientes.Columns["id"].Visible = false;

            dgv_Clientes.Columns["status"].HeaderText = "ATIVO";
            dgv_Clientes.Columns["status"].Width = 90;
            dgv_Clientes.Columns["status"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            dgv_Clientes.Columns["nome"].HeaderText = "NOME";
            dgv_Clientes.Columns["nome"].Width = 300;
            dgv_Clientes.Columns["nome"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);


            dgv_Clientes.Columns["cnpj"].HeaderText = "CNPJ";
            dgv_Clientes.Columns["cnpj"].Width = 200;
            dgv_Clientes.Columns["cnpj"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            dgv_Clientes.Columns["fatura"].HeaderText = "FATURA";
            dgv_Clientes.Columns["fatura"].Width = 300;
            dgv_Clientes.Columns["fatura"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            dgv_Clientes.Sort(dgv_Clientes.Columns["nome"], System.ComponentModel.ListSortDirection.Ascending);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            fatura.Cliente_idcliente = Convert.ToInt32(dgv_Clientes.Rows[dgv_Clientes.CurrentCell.RowIndex].Cells["id"].Value);
            fatura.Mes = txtMes.Text;
            fatura.Valor = txtValor.Text;
            fatura.Vencimento = txtVencimento.Text;
            fatura.Repete = txtRepete.Text;       
            

            fatura.SalvarFatura();

            this.Close();
        }

        private void dgv_Clientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
