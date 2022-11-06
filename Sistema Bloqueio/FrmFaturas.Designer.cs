namespace Sistema_Bloqueio
{
    partial class FrmFaturas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_faturas = new System.Windows.Forms.DataGridView();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnPago = new System.Windows.Forms.Button();
            this.btnDestacar = new System.Windows.Forms.Button();
            this.btnPendente = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lblPago = new System.Windows.Forms.Label();
            this.lblPendente = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_faturas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_faturas
            // 
            this.dgv_faturas.AllowUserToAddRows = false;
            this.dgv_faturas.AllowUserToDeleteRows = false;
            this.dgv_faturas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_faturas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_faturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_faturas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_faturas.Location = new System.Drawing.Point(12, 115);
            this.dgv_faturas.Name = "dgv_faturas";
            this.dgv_faturas.ReadOnly = true;
            this.dgv_faturas.RowTemplate.Height = 25;
            this.dgv_faturas.Size = new System.Drawing.Size(670, 441);
            this.dgv_faturas.TabIndex = 0;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(250, 86);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(270, 23);
            this.txtBuscar.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(526, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pesquise pelo Código ou Cliente";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Cadastrar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(93, 12);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 5;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnPago
            // 
            this.btnPago.Location = new System.Drawing.Point(174, 12);
            this.btnPago.Name = "btnPago";
            this.btnPago.Size = new System.Drawing.Size(75, 23);
            this.btnPago.TabIndex = 6;
            this.btnPago.Text = "Pago";
            this.btnPago.UseVisualStyleBackColor = true;
            this.btnPago.Click += new System.EventHandler(this.btnPago_Click);
            // 
            // btnDestacar
            // 
            this.btnDestacar.Location = new System.Drawing.Point(336, 12);
            this.btnDestacar.Name = "btnDestacar";
            this.btnDestacar.Size = new System.Drawing.Size(75, 23);
            this.btnDestacar.TabIndex = 7;
            this.btnDestacar.Text = "Destacar";
            this.btnDestacar.UseVisualStyleBackColor = true;
            this.btnDestacar.Click += new System.EventHandler(this.btnDestacar_Click);
            // 
            // btnPendente
            // 
            this.btnPendente.Location = new System.Drawing.Point(255, 12);
            this.btnPendente.Name = "btnPendente";
            this.btnPendente.Size = new System.Drawing.Size(75, 23);
            this.btnPendente.TabIndex = 8;
            this.btnPendente.Text = "Pendente";
            this.btnPendente.UseVisualStyleBackColor = true;
            this.btnPendente.Click += new System.EventHandler(this.btnPendente_Click);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbl1.Location = new System.Drawing.Point(12, 47);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(82, 15);
            this.lbl1.TabIndex = 9;
            this.lbl1.Text = "Faturas Pagas:";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.ForeColor = System.Drawing.Color.Red;
            this.lbl2.Location = new System.Drawing.Point(12, 66);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(106, 15);
            this.lbl2.TabIndex = 10;
            this.lbl2.Text = "Faturas Pendentes:";
            // 
            // lblPago
            // 
            this.lblPago.AutoSize = true;
            this.lblPago.Location = new System.Drawing.Point(93, 47);
            this.lblPago.Name = "lblPago";
            this.lblPago.Size = new System.Drawing.Size(0, 15);
            this.lblPago.TabIndex = 11;
            // 
            // lblPendente
            // 
            this.lblPendente.AutoSize = true;
            this.lblPendente.Location = new System.Drawing.Point(114, 66);
            this.lblPendente.Name = "lblPendente";
            this.lblPendente.Size = new System.Drawing.Size(0, 15);
            this.lblPendente.TabIndex = 12;
            // 
            // FrmFaturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 570);
            this.Controls.Add(this.lblPendente);
            this.Controls.Add(this.lblPago);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.btnPendente);
            this.Controls.Add(this.btnDestacar);
            this.Controls.Add(this.btnPago);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.dgv_faturas);
            this.Name = "FrmFaturas";
            this.Text = "FrmFaturas";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_faturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgv_faturas;
        private TextBox txtBuscar;
        private Button button1;
        private Label label1;
        private Button button2;
        private Button btnExcluir;
        private Button btnPago;
        private Button btnDestacar;
        private Button btnPendente;
        private Label lbl1;
        private Label lbl2;
        private Label lblPago;
        private Label lblPendente;
    }
}