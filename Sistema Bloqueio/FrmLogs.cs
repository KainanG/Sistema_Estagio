using MySql.Data.MySqlClient;
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
    public partial class FrmLogs : Form
    {
        public FrmLogs()
        {
            InitializeComponent();

            var dt = new DataTable();
            var sql = "SELECT idlogs, usuario, data, form FROM db_estagioSis.logs";
        
            try
            {
                using (var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();
                    using (var da = new MySqlDataAdapter(sql, cn))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dgvLogs.DataSource = dt;
            ConfigurarGradeLogs();

        }

        private void ConfigurarGradeLogs()
        {

            dgvLogs.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvLogs.DefaultCellStyle.Font = new Font("Arial", 9);
            dgvLogs.RowHeadersWidth = 25;

            dgvLogs.Columns["idlogs"].HeaderText = "ID";
            dgvLogs.Columns["idlogs"].Width = 90;
            dgvLogs.Columns["idlogs"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            dgvLogs.Columns["usuario"].HeaderText = "USUARIO";
            dgvLogs.Columns["usuario"].Width = 300;
            dgvLogs.Columns["usuario"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            dgvLogs.Columns["data"].HeaderText = "DATA";
            dgvLogs.Columns["data"].Width = 100;
            dgvLogs.Columns["data"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);


            dgvLogs.Columns["form"].HeaderText = "TELA";
            dgvLogs.Columns["form"].Width = 200;
            dgvLogs.Columns["form"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            /*dgvClientes.Columns["fatura"].HeaderText = "FATURA";
            dgvClientes.Columns["fatura"].Width = 300;
            dgvClientes.Columns["fatura"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);*/

            dgvLogs.Sort(dgvLogs.Columns["data"], System.ComponentModel.ListSortDirection.Ascending);
        }


    }
}
