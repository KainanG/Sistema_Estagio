using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Bloqueio
{
    public partial class FrmClientes : Form
    {
        public string nomeUsu { get; set; }

        DataTable dt = new DataTable();
        public FrmClientes()
        {
            InitializeComponent();
            Inicializar();
        }

        public FrmClientes(string nomeUsuario)
        {
            nomeUsu = nomeUsuario;
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

            dgvClientes.Columns["nome1"].HeaderText = "RESPONSAVEL";
            dgvClientes.Columns["nome1"].Width = 300;
            dgvClientes.Columns["nome1"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            //dgvClientes.Sort(dgvClientes.Columns["nome"], System.ComponentModel.ListSortDirection.Ascending);
        }


        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmClientesCadastro(0, nomeUsu))
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvClientes.Rows[dgvClientes.CurrentCell.RowIndex].Cells["Id"].Value);
            Cliente cliente = new Cliente();
            cliente.Id = id;
            cliente.Excluir();
            dt = Cliente.GetClientes("");
            dgvClientes.DataSource = dt;
            ConfigurarGradeClientes();
        }

        private void btnBloquear_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvClientes.Rows[dgvClientes.CurrentCell.RowIndex].Cells["Id"].Value);
            Cliente clientes = new Cliente();
            clientes.Id = id;
            clientes.BloquearCliente();
            dgvClientes.DataSource = Cliente.GetClientes();
            ConfigurarGradeClientes();
                    
        }

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvClientes.Rows[dgvClientes.CurrentCell.RowIndex].Cells["Id"].Value);
            Cliente clientes = new Cliente();
            clientes.Id = id;
            clientes.BloquearCliente(true);
            dgvClientes.DataSource = Cliente.GetClientes();
            ConfigurarGradeClientes();
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Usuários");

                worksheet.Cell("A1").Value = "ID";
                worksheet.Cell("B1").Value = "NOME";
                worksheet.Cell("C1").Value = "CNPJ";
                worksheet.Cell("D1").Value = "ATIVO";
                           

                var conexao = new MySqlConnection("server=localhost;database=db_estagioSis;uid=root;pwd=!Kg!s2601#");
                string strSQL = "USE `db_estagioSis`; SELECT cliente.id, cliente.nome, cliente.cnpj, cliente.status," +
                    " responsavel.nome FROM clientes as cliente LEFT JOIN responsaveis as responsavel ON responsavel.id = cliente.id_responsavel";

                var comando = new MySqlCommand(strSQL, conexao);
                using (conexao)
                {
                    conexao.Open();
                    var dr = comando.ExecuteReader();
                    int linha = 1;

                    while (dr.Read())
                    {
                        linha++;
                        worksheet.Cell("A" + linha).Value = dr["id"];
                        worksheet.Cell("B" + linha).Value = dr["nome"];
                        worksheet.Cell("C" + linha).Value = dr["cnpj"];
                        worksheet.Cell("D" + linha).Value = dr["status"];
                        
                       
                    }

                    conexao.Close();
                };

                workbook.SaveAs(@"C:\Users\kaina\Downloads\Relatorio_Cliente.xlsx");
            }
            Process.Start(new ProcessStartInfo(@"C:\Users\kaina\Downloads\Relatorio_Cliente.xlsx") { UseShellExecute = true });
        }
    }
}
