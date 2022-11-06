using Google.Protobuf;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Bloqueio
{
    public partial class FrmFaturas : Form
    {
        public string nomeUsuario { get; set; }
        DataTable dt = new DataTable();

        public FrmFaturas()
        {
           
            InitializeComponent();
            Inicializar();
            var sql = "SELECT COUNT(id) AS qtd FROM faturas WHERE faturapaga = \"Não\"";
            string pendentes = "";
            string pagas = "";
            try
            {
                using (var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                pendentes = dr["qtd"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            var sql2 = "SELECT COUNT(id) AS qtd FROM faturas WHERE faturapaga = \"Sim\"";
            try
            {
                using (var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();
                    using (var cmd = new MySqlCommand(sql2, cn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                pagas = dr["qtd"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            lblPago.Text = pagas;
            lblPendente.Text = pendentes;
        }


        public FrmFaturas(string nomeUsu)
        {
            this.nomeUsuario = nomeUsu;
            InitializeComponent();
            Inicializar();
            var sql = "SELECT COUNT(id) AS qtd FROM faturas WHERE faturapaga = \"Não\"";
            string pendentes = "";
            string pagas = "";
            try
            {
                using (var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                pendentes = dr["qtd"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            var sql2 = "SELECT COUNT(id) AS qtd FROM faturas WHERE faturapaga = \"Sim\"";           
            try
            {
                using (var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();
                    using (var cmd = new MySqlCommand(sql2, cn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                pagas = dr["qtd"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            lblPago.Text = pagas;
            lblPendente.Text = pendentes;
        }

       private void Inicializar()
        {
            
            dt = Fatura.GetFaturas();
            dgv_faturas.DataSource = dt;
            ConfigurarGradeFaturas();
            Contar();
            
        }

        private void Contar()
        {    
           
        }

        private void ConfigurarGradeFaturas()
        {
            
            dgv_faturas.Refresh();
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

            dgv_faturas.Columns["nome"].HeaderText = "CLIENTE";
            dgv_faturas.Columns["nome"].Width = 100;
            dgv_faturas.Columns["nome"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);


            

            
            //dgv_faturas.Sort(dgv_faturas.Columns["id"], System.ComponentModel.ListSortDirection.Ascending);           
        }





        private void button2_Click(object sender, EventArgs e)
        {
            

            using (var frm = new FrmFaturasCadastro(0,this.nomeUsuario))
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgv_faturas.Rows[dgv_faturas.CurrentCell.RowIndex].Cells["Id"].Value);
            Fatura faturas = new Fatura();
            faturas.Id = id;
            faturas.Excluir();
            dgv_faturas.DataSource = Fatura.GetFaturas();
            ConfigurarGradeFaturas();
        }

        private void btnPago_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgv_faturas.Rows[dgv_faturas.CurrentCell.RowIndex].Cells["Id"].Value);
            Fatura faturas = new Fatura();
            faturas.Id = id;
            faturas.PagarFatura();
            dgv_faturas.DataSource = Fatura.GetFaturas();
            ConfigurarGradeFaturas();
            foreach (DataGridViewRow dr in dgv_faturas.Rows)
            {

                string text = (string)dr.Cells[5].Value;

                if (text == "Não")
                {
                    dr.DefaultCellStyle.BackColor = Color.FromArgb(255, 250, 128, 114);

                }
                else
                {
                    dr.DefaultCellStyle.BackColor = Color.FromArgb(255, 143, 188, 143);

                }

            }

            var sql = "SELECT COUNT(id) AS qtd FROM faturas WHERE faturapaga = \"Não\"";
            string pendentes = "";
            string pagas = "";
            try
            {
                using (var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                pendentes = dr["qtd"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            var sql2 = "SELECT COUNT(id) AS qtd FROM faturas WHERE faturapaga = \"Sim\"";
            try
            {
                using (var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();
                    using (var cmd = new MySqlCommand(sql2, cn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                pagas = dr["qtd"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            lblPago.Text = pagas;
            lblPendente.Text = pendentes;

        }

        private void btnDestacar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dgv_faturas.Rows)
            {

                string text = (string)dr.Cells[5].Value;

                if (text == "Não")
                {
                    dr.DefaultCellStyle.BackColor = Color.FromArgb(255, 250, 128, 114);
                 
                }
                else
                {
                    dr.DefaultCellStyle.BackColor = Color.FromArgb(255, 143, 188, 143);
                    
                }

            }
        }

        private void btnPendente_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgv_faturas.Rows[dgv_faturas.CurrentCell.RowIndex].Cells["Id"].Value);
            Fatura faturas = new Fatura();
            faturas.Id = id;
            faturas.PagarFatura(true);
            dgv_faturas.DataSource = Fatura.GetFaturas();
            ConfigurarGradeFaturas();

            foreach (DataGridViewRow dr in dgv_faturas.Rows)
            {

                string text = (string)dr.Cells[5].Value;

                if (text == "Não")
                {
                    dr.DefaultCellStyle.BackColor = Color.FromArgb(255, 250, 128, 114);

                }
                else
                {
                    dr.DefaultCellStyle.BackColor = Color.FromArgb(255, 143, 188, 143);

                }

            }

            var sql = "SELECT COUNT(id) AS qtd FROM faturas WHERE faturapaga = \"Não\"";
            string pendentes = "";
            string pagas = "";
            try
            {
                using (var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                pendentes = dr["qtd"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            var sql2 = "SELECT COUNT(id) AS qtd FROM faturas WHERE faturapaga = \"Sim\"";
            try
            {
                using (var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();
                    using (var cmd = new MySqlCommand(sql2, cn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                pagas = dr["qtd"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            lblPago.Text = pagas;
            lblPendente.Text = pendentes;
        }
    }

}
