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
        DataTable dt = new DataTable();
        public FrmFaturas()
        {
            InitializeComponent();
            Inicializar();
        }

       private void Inicializar()
        {
            dt = Fatura.GetFaturas();
            dgv_faturas.DataSource = dt;
            ConfigurarGradeFaturas();
        }

        private void ConfigurarGradeFaturas()
        {

            dgv_faturas.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgv_faturas.DefaultCellStyle.Font = new Font("Arial", 9);
            dgv_faturas.RowHeadersWidth = 25;

            dgv_faturas.Columns["id"].HeaderText = "ID";
            dgv_faturas.Columns["id"].Width = 50;
            dgv_faturas.Columns["id"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            //dgv_faturas.Columns["id"].Visible = false;

            dgv_faturas.Columns["valor"].HeaderText = "VALOR";
            dgv_faturas.Columns["valor"].Width = 100;
            dgv_faturas.Columns["valor"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            dgv_faturas.Columns["mes"].HeaderText = "MÊS";
            dgv_faturas.Columns["mes"].Width = 100;
            dgv_faturas.Columns["mes"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);


            dgv_faturas.Columns["vencimento"].HeaderText = "VENCIMENTO";
            dgv_faturas.Columns["vencimento"].Width = 100;
            dgv_faturas.Columns["vencimento"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            dgv_faturas.Columns["repete"].HeaderText = "PARCELAS";
            dgv_faturas.Columns["repete"].Width = 100;
            dgv_faturas.Columns["repete"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            dgv_faturas.Columns["faturapaga"].HeaderText = "PAGO";
            dgv_faturas.Columns["faturapaga"].Width = 100;
            dgv_faturas.Columns["faturapaga"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            dgv_faturas.Columns["cliente_idcliente"].HeaderText = "CLIENTE";
            dgv_faturas.Columns["cliente_idcliente"].Width = 100;
            dgv_faturas.Columns["cliente_idcliente"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);



            dgv_faturas.Sort(dgv_faturas.Columns["id"], System.ComponentModel.ListSortDirection.Ascending);
        }





        private void button2_Click(object sender, EventArgs e)
        {
            

            using (var frm = new FrmFaturasCadastro(0))
            {
                frm.ShowDialog();
                dgv_faturas.DataSource = Fatura.GetFaturas();
                ConfigurarGradeFaturas();
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt = Fatura.GetFaturas(txtBuscar.Text);
            dgv_faturas.DataSource = dt;
            ConfigurarGradeFaturas();
        }
    }

}
