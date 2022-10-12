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
        int id;
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

                cliente.SalvarCliente();
               
                this.Close();
            }
        }
    }
}
