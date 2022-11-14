using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office.CustomUI;
using DocumentFormat.OpenXml.Office2010.Excel;
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
    public partial class FrmLogin : Form
    {
        public MySqlConnection Conexao;
        public string data_source = "datasource=localhost;username=root;password=!Kg!s2601#;database=db_estagioSis";
        public string vldusuario { get; set; }

        public FrmLogin()
        {
            InitializeComponent();
            
        }

        public void bntEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                string senha = Usuario.Criptografar(txtSenha.Text);
                vldusuario = "'" + txtUsuario.Text + "'";
                string sql = "SELECT COUNT(*) FROM usuarios WHERE usuario = " + vldusuario + " and senha =  '" + senha.Replace('\'', ' ').Trim() + "'"; 
                Conexao = new MySqlConnection(data_source);
                Conexao.Open();

                // Comando Insert
                MySqlCommand comando = new MySqlCommand(sql, Conexao);



                DataTable dataTable = new DataTable();
                MySqlDataAdapter Da = new MySqlDataAdapter(comando);
                Da.Fill(dataTable);

                foreach (DataRow list in dataTable.Rows)
                {
                    if (Convert.ToInt32(list.ItemArray[0]) > 0)
                    {
                        var menu = new HomeUsu(vldusuario);
                        menu.Show();
                        this.Hide();

                        string sql2 = "SELECT COUNT(*) FROM usuarios WHERE usuario = " + vldusuario + " and senha = '" + senha.Replace('\'', ' ').Trim() + "' and adm = 'S'";
                        Conexao = new MySqlConnection(data_source);
                        Conexao.Open();                     
                        MySqlCommand comando2 = new MySqlCommand(sql2, Conexao);
                        DataTable dataTable2 = new DataTable();
                        MySqlDataAdapter Da2 = new MySqlDataAdapter(comando2);
                        Da2.Fill(dataTable2);

                        foreach (DataRow list2 in dataTable2.Rows)
                        {
                            if (Convert.ToInt32(list2.ItemArray[0]) > 0)
                            {
                                menu.Visible = false;
                                var menuAdm = new HomeAdm(vldusuario);
                                menuAdm.Show();                              
                            }
                        }


                    }
                    else
                    {
                        MessageBox.Show("Usuário Inválido!", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conexao.Close();
            }
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            int tecla = (int)e.KeyChar;

            if (!char.IsLetterOrDigit(e.KeyChar) && tecla != 08)
            {
                e.Handled = true;
                MessageBox.Show("Digite apenas letras e números!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
