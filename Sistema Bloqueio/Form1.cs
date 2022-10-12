using System.Data;

namespace Sistema_Bloqueio
{
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            dt = Usuario.GetUsuarios();
            dgvUsuarios.DataSource = dt;
            ConfigurarGradeUsuarios();
        }

        private void ConfigurarGradeUsuarios()
        {

            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvUsuarios.DefaultCellStyle.Font = new Font("Arial", 9);
            dgvUsuarios.RowHeadersWidth = 25;

            dgvUsuarios.Columns["id"].HeaderText = "ID";
            dgvUsuarios.Columns["id"].Visible = false;        

            dgvUsuarios.Columns["nome"].HeaderText = "NOME";
            dgvUsuarios.Columns["nome"].Width = 300;
            dgvUsuarios.Columns["nome"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            

            dgvUsuarios.Columns["email"].HeaderText = "E-MAIL";
            dgvUsuarios.Columns["email"].Width = 300;
            dgvUsuarios.Columns["email"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            dgvUsuarios.Columns["usuario"].HeaderText = "USUÁRIO";
            dgvUsuarios.Columns["usuario"].Width = 100;
            dgvUsuarios.Columns["usuario"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            dgvUsuarios.Columns["adm"].HeaderText = "ADM";
            dgvUsuarios.Columns["adm"].Width = 90;
            dgvUsuarios.Columns["adm"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            dgvUsuarios.Columns["senha"].HeaderText = "SENHA";
            dgvUsuarios.Columns["senha"].Visible = false;

            dgvUsuarios.Sort(dgvUsuarios.Columns["nome"], System.ComponentModel.ListSortDirection.Ascending);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvUsuarios.Rows[dgvUsuarios.CurrentCell.RowIndex].Cells["Id"].Value);

            using(var frm = new FrmUsuariosCadastro(id))
            {
                frm.ShowDialog();
                dgvUsuarios.DataSource = Usuario.GetUsuarios();
                ConfigurarGradeUsuarios();
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmUsuariosCadastro(0))
            {
                frm.ShowDialog();
                dgvUsuarios.DataSource = Usuario.GetUsuarios();
                ConfigurarGradeUsuarios();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dt = Usuario.GetUsuarios(txtProcurar.Text);
            dgvUsuarios.DataSource = dt;
            ConfigurarGradeUsuarios();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvUsuarios.Rows[dgvUsuarios.CurrentCell.RowIndex].Cells["Id"].Value);

            using (var frm = new FrmUsuariosCadastro(id, true))
            {
                frm.ShowDialog();
                dgvUsuarios.DataSource = Usuario.GetUsuarios();
                ConfigurarGradeUsuarios();
            }
        }
    }
}