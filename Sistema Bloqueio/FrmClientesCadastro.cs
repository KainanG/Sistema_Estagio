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
    public partial class FrmClientesCadastro : Form
    {
        public string nomeUsu { get; set; }

        int id;
        DataTable dt = new DataTable();

        Cliente cliente = new Cliente();
        Endereco enderecoCliente = new Endereco();
        public FrmClientesCadastro(int id)
        {
            InitializeComponent();
            this.id = id;

            if (this.id > 0)
            {
                cliente.GetCliente(this.id);
                lblId.Text = this.id.ToString();
                txtNomeCliente.Text = cliente.Nome;
                txtCnpjCliente.Text = cliente.Cnpj;
                if (cliente.Status == 'S')
                    chkAtivoCliente.Checked = true;

            }
        }

        private void Inicializar()
        {
            dt = Responsavel.GetResponsaveis();
            dgv_Responsavel.DataSource = dt;
            ConfigurarGradeResponsavel();
        }

        private void ConfigurarGradeResponsavel()
        {

            dgv_Responsavel.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgv_Responsavel.DefaultCellStyle.Font = new Font("Arial", 9);
            dgv_Responsavel.RowHeadersWidth = 25;

            dgv_Responsavel.Columns["id"].HeaderText = "ID";
            dgv_Responsavel.Columns["id"].Width = 50;
            dgv_Responsavel.Columns["id"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            //dgv_Clientes.Columns["id"].Visible = false;

            dgv_Responsavel.Columns["nome"].HeaderText = "NOME";
            dgv_Responsavel.Columns["nome"].Width = 300;
            dgv_Responsavel.Columns["nome"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            dgv_Responsavel.Columns["celular"].HeaderText = "CELULAR";
            dgv_Responsavel.Columns["celular"].Width = 90;
            dgv_Responsavel.Columns["celular"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            dgv_Responsavel.Columns["telefone"].HeaderText = "TELEFONE";
            dgv_Responsavel.Columns["telefone"].Width = 90;
            dgv_Responsavel.Columns["telefone"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            dgv_Responsavel.Columns["cpf"].HeaderText = "CPF";
            dgv_Responsavel.Columns["cpf"].Width = 150;
            dgv_Responsavel.Columns["cpf"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            dgv_Responsavel.Columns["rg"].HeaderText = "RG";
            dgv_Responsavel.Columns["rg"].Width = 150;
            dgv_Responsavel.Columns["rg"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            dgv_Responsavel.Columns["bloqueado"].HeaderText = "STATUS";
            dgv_Responsavel.Columns["bloqueado"].Width = 90;
            dgv_Responsavel.Columns["bloqueado"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            dgv_Responsavel.Sort(dgv_Responsavel.Columns["nome"], System.ComponentModel.ListSortDirection.Ascending);


        }

        public FrmClientesCadastro(int id, string nomeUsuario)
        {
            nomeUsu = nomeUsuario;

            InitializeComponent();
            Inicializar();
            this.id = id;

            if (this.id > 0)
            {
                cliente.GetCliente(this.id);
                lblId.Text = this.id.ToString();
                txtNomeCliente.Text = cliente.Nome;
                txtCnpjCliente.Text = cliente.Cnpj;
                if (cliente.Status == 'S')
                    chkAtivoCliente.Checked = true;

            }
        }

        private bool ValidarCadastro()
        {
            if (txtNomeCliente.Text == "")
            {
                MessageBox.Show("Informe o Nome do Cliente!", Program.sistema);
                txtNomeCliente.Focus();
                return false;
            }
            else if (txtCnpjCliente.Text == "")
            {
                MessageBox.Show("Informe o CNPJ do Cliente!", Program.sistema);
                txtCnpjCliente.Focus();
                return false;
            }          
            else
                return true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidarCadastro())
            {
                cliente.Id_responsavel = Convert.ToInt32(dgv_Responsavel.Rows[dgv_Responsavel.CurrentCell.RowIndex].Cells["id"].Value);
                cliente.Nome = txtNomeCliente.Text;             
                cliente.Cnpj = txtCnpjCliente.Text;                                      
                if (chkAtivoCliente.Checked == true)
                    cliente.Status = 'S';
                else
                    cliente.Status = 'N';

                var endereco = new Endereco();
                endereco.Cep = txtCepCliente.Text;
                endereco.Estado = txtEstadoCliente.Text;
                endereco.Cidade = txtCidadeCliente.Text;
                endereco.Bairro = txtBairroCliente.Text;
                endereco.Rua = txtRuaCliente.Text;
                endereco.Numero = Convert.ToInt32(txtNumCliente.Text.ToString());
                endereco.Complemento = txtComplemCliente.Text;

                cliente.Enderecos = new List<Endereco>();
                cliente.Enderecos.Add(endereco);

                cliente.SalvarCliente(nomeUsu);
               
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
