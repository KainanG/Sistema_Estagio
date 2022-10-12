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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FrmClientes frmClientes = new FrmClientes();
            frmClientes.ShowDialog();
        }

        private void btnFaturas_Click(object sender, EventArgs e)
        {
            FrmFaturas frmFaturas = new FrmFaturas();
            frmFaturas.ShowDialog();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnResp_Click(object sender, EventArgs e)
        {
            FrmResponsavelCadastro frmRespCad = new FrmResponsavelCadastro();
            frmRespCad.ShowDialog();
        }
    }
}
