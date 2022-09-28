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
        Usuario usuario = new Usuario();
        public FrmUsuariosCadastro(int id)
        {
            InitializeComponent();
            this.id = id;

            if(this.id > 0)
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
        }

        private void btnSalvar_Click(object sender, EventArgs e)
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
}
