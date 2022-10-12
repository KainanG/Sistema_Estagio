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
    public partial class FrmUsuariosCadastro : Form
    {
        int id;
        bool excluir = false;
        Usuario usuario = new Usuario();
        public FrmUsuariosCadastro(int id, bool excluir = false)
        {
            InitializeComponent();
            this.id = id;
            this.excluir = excluir;

            if (this.id > 0)
            {
                usuario.GetUsuario(this.id);
                lblId.Text = this.id.ToString();
                txtNome.Text = usuario.Nome;
                txtEmail.Text = usuario.Email;
                txtSenha.Text = usuario.Senha;
                txtUsuario.Text = usuario.Login;

                if (usuario.Adm == 'S')
                    chkAdm.Checked = true;

            }

            if (this.excluir)
            {
                TravarControles();
                btnSalvar.Visible = false;
                btnExcluir.Visible = true;
            }    
        }

        private void TravarControles()
        {
            txtEmail.Enabled = false;
            txtNome.Enabled = false;
            txtSenha.Enabled = false;
            txtUsuario.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            if (ValidarCadastro())
            {
                usuario.Nome = txtNome.Text;
                usuario.Email = txtEmail.Text;
                usuario.Senha = txtSenha.Text;
                usuario.Login = txtUsuario.Text;
                if (chkAdm.Checked == true)
                    usuario.Adm = 'S';
                else
                    usuario.Adm = 'N';

                usuario.SalvarUsuario();
                this.Close();
            }
        }

        private bool ValidarCadastro()
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("Informe o Nome do Usuário!", Program.sistema);
                txtNome.Focus();
                return false;
            }
            else if (txtUsuario.Text == "")
            {
                MessageBox.Show("Informe o Usuário!", Program.sistema);
                txtUsuario.Focus();
                return false;
            } 
            else if (txtSenha.Text == "")
            {
                MessageBox.Show("Informe uma Senha!", Program.sistema);
                txtSenha.Focus();
                return false;
            }
            else
                return true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {               
            usuario.Excluir();
            this.Close();
        }
    }
}
