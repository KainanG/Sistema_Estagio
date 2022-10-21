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
    public partial class FrmResponsavelCadastro : Form
    {

        int id;
        Responsavel responsavel = new Responsavel();
        Endereco enderecoCliente = new Endereco();

        public FrmResponsavelCadastro()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            responsavel.Nome = txtNomeResp.Text;
            responsavel.Cpf = txtCpfResp.Text;
            responsavel.Celular = txtCelResp.Text;
            responsavel.Telefone = txtTelefResp.Text;
            responsavel.Rg = txtRgResp.Text;
            if (chkAtivoResp.Checked == true)
                responsavel.Status = 'S';
            else
                responsavel.Status = 'N';

            var endereco = new Endereco();
            endereco.Cep = txtCepResp.Text;
            endereco.Estado = txtEstadoResp.Text;
            endereco.Cidade = txtCidadeResp.Text;
            endereco.Bairro = txtBairroResp.Text;
            endereco.Rua = txtRuaResp.Text;
            endereco.Numero = Convert.ToInt32(txtNumResp.Text.ToString());
            endereco.Complemento = txtComplemResp.Text;

            responsavel.Enderecos = new List<Endereco>();
            responsavel.Enderecos.Add(endereco);

            responsavel.SalvarResponsavel();

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
