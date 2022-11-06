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
    public partial class HomeAdm : Form
    {
        public string nomeUsu { get; set; }
        public HomeAdm()
        {      
            InitializeComponent();
            
        }

        public HomeAdm(string nomeUsuario)
        {
            InitializeComponent();
            lblUsuario.Text = nomeUsuario.Replace('\'', ' ');
            nomeUsu = nomeUsuario;
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FrmUsuarios frmUsuarios = new FrmUsuarios(nomeUsu);
            frmUsuarios.ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FrmClientes frmClientes = new FrmClientes(nomeUsu);
            frmClientes.ShowDialog();
        }

        private void btnFaturas_Click(object sender, EventArgs e)
        {
            FrmFaturas frmFaturas = new FrmFaturas(nomeUsu);
            frmFaturas.ShowDialog();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void btnResp_Click(object sender, EventArgs e)
        {
            FrmResponsavelCadastro frmRespCad = new FrmResponsavelCadastro(nomeUsu);
            frmRespCad.ShowDialog();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            FrmLogs frmLog = new FrmLogs();
            frmLog.ShowDialog();
        }
    }
}
