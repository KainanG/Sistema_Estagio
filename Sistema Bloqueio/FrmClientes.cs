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
    public partial class FrmClientes : Form
    {
        DataTable dt = new DataTable();
        public FrmClientes()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            dt = Cliente.GetClientes();
            dgvClientes.DataSource = dt;
            ConfigurarGradeClientes();
        }

        private void ConfigurarGradeClientes()
        {

            dgvClientes.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvClientes.DefaultCellStyle.Font = new Font("Arial", 9);
            dgvClientes.RowHeadersWidth = 25;

            dgvClientes.Columns["id"].HeaderText = "ID";
            dgvClientes.Columns["id"].Visible = false;

            dgvClientes.Columns["status"].HeaderText = "ATIVO";
            dgvClientes.Columns["status"].Width = 90;
            dgvClientes.Columns["status"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            dgvClientes.Columns["nome"].HeaderText = "NOME";
            dgvClientes.Columns["nome"].Width = 300;
            dgvClientes.Columns["nome"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);


            dgvClientes.Columns["cnpj"].HeaderText = "CNPJ";
            dgvClientes.Columns["cnpj"].Width = 200;
            dgvClientes.Columns["cnpj"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            dgvClientes.Columns["fatura"].HeaderText = "FATURA";
            dgvClientes.Columns["fatura"].Width = 300;
            dgvClientes.Columns["fatura"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            dgvClientes.Sort(dgvClientes.Columns["nome"], System.ComponentModel.ListSortDirection.Ascending);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvClientes.Rows[dgvClientes.CurrentCell.RowIndex].Cells["id"].Value);

            using (var frm = new FrmClientesCadastro(id))
            {
                frm.ShowDialog();
                dgvClientes.DataSource = Cliente.GetClientes();
                ConfigurarGradeClientes();
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmClientesCadastro(0))
            {
                frm.ShowDialog();
                dgvClientes.DataSource = Cliente.GetClientes();
                ConfigurarGradeClientes();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dt = Cliente.GetClientes(txtBuscar.Text);
            dgvClientes.DataSource = dt;
            ConfigurarGradeClientes();
        }
    }
}
