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
    public partial class FrmFaturas : Form
    {
        public FrmFaturas()
        {
            InitializeComponent();
            Inicializar();
        }

       /* private void Inicializar()
        {
            dt = Fatura.GetUsuarios();
            dgvUsuarios.DataSource = dt;
            ConfigurarGradeUsuarios();
        }*/

        private void button2_Click(object sender, EventArgs e)
        {
            FrmFaturasCadastro frmFaturasCadastro = new FrmFaturasCadastro();
            frmFaturasCadastro.ShowDialog();
        }
    }
}
