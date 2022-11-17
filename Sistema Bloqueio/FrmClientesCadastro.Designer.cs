namespace Sistema_Bloqueio
{
    partial class FrmClientesCadastro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmClientesCadastro));
            this.label1 = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkAtivoCliente = new System.Windows.Forms.CheckBox();
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.txtCnpjCliente = new System.Windows.Forms.TextBox();
            this.txtCepCliente = new System.Windows.Forms.TextBox();
            this.txtEstadoCliente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCidadeCliente = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBairroCliente = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRuaCliente = new System.Windows.Forms.TextBox();
            this.txtNumCliente = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.txtComplemCliente = new System.Windows.Forms.TextBox();
            this.dgv_Responsavel = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Responsavel)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // lblId
            // 
            this.lblId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblId.Location = new System.Drawing.Point(43, 10);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(66, 23);
            this.lblId.TabIndex = 1;
            this.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "CEP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(424, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "CNPJ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(226, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 21);
            this.label5.TabIndex = 5;
            this.label5.Text = "Estado";
            // 
            // chkAtivoCliente
            // 
            this.chkAtivoCliente.AutoSize = true;
            this.chkAtivoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkAtivoCliente.Location = new System.Drawing.Point(121, 12);
            this.chkAtivoCliente.Name = "chkAtivoCliente";
            this.chkAtivoCliente.Size = new System.Drawing.Size(51, 19);
            this.chkAtivoCliente.TabIndex = 6;
            this.chkAtivoCliente.Text = "Ativo";
            this.chkAtivoCliente.UseVisualStyleBackColor = true;
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.Location = new System.Drawing.Point(12, 64);
            this.txtNomeCliente.MaxLength = 500;
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Size = new System.Drawing.Size(369, 23);
            this.txtNomeCliente.TabIndex = 7;
            // 
            // txtCnpjCliente
            // 
            this.txtCnpjCliente.Location = new System.Drawing.Point(424, 64);
            this.txtCnpjCliente.MaxLength = 14;
            this.txtCnpjCliente.Name = "txtCnpjCliente";
            this.txtCnpjCliente.Size = new System.Drawing.Size(265, 23);
            this.txtCnpjCliente.TabIndex = 8;
            // 
            // txtCepCliente
            // 
            this.txtCepCliente.Location = new System.Drawing.Point(12, 155);
            this.txtCepCliente.MaxLength = 8;
            this.txtCepCliente.Name = "txtCepCliente";
            this.txtCepCliente.Size = new System.Drawing.Size(173, 23);
            this.txtCepCliente.TabIndex = 9;
            // 
            // txtEstadoCliente
            // 
            this.txtEstadoCliente.Location = new System.Drawing.Point(226, 155);
            this.txtEstadoCliente.MaxLength = 100;
            this.txtEstadoCliente.Name = "txtEstadoCliente";
            this.txtEstadoCliente.Size = new System.Drawing.Size(155, 23);
            this.txtEstadoCliente.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(424, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Cidade";
            // 
            // txtCidadeCliente
            // 
            this.txtCidadeCliente.Location = new System.Drawing.Point(424, 155);
            this.txtCidadeCliente.MaxLength = 200;
            this.txtCidadeCliente.Name = "txtCidadeCliente";
            this.txtCidadeCliente.Size = new System.Drawing.Size(175, 23);
            this.txtCidadeCliente.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(645, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 21);
            this.label7.TabIndex = 13;
            this.label7.Text = "Bairro";
            // 
            // txtBairroCliente
            // 
            this.txtBairroCliente.Location = new System.Drawing.Point(645, 155);
            this.txtBairroCliente.MaxLength = 200;
            this.txtBairroCliente.Name = "txtBairroCliente";
            this.txtBairroCliente.Size = new System.Drawing.Size(182, 23);
            this.txtBairroCliente.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(12, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 21);
            this.label8.TabIndex = 15;
            this.label8.Text = "Rua";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(424, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 21);
            this.label9.TabIndex = 16;
            this.label9.Text = "N°";
            // 
            // txtRuaCliente
            // 
            this.txtRuaCliente.Location = new System.Drawing.Point(12, 231);
            this.txtRuaCliente.MaxLength = 350;
            this.txtRuaCliente.Name = "txtRuaCliente";
            this.txtRuaCliente.Size = new System.Drawing.Size(369, 23);
            this.txtRuaCliente.TabIndex = 17;
            // 
            // txtNumCliente
            // 
            this.txtNumCliente.Location = new System.Drawing.Point(424, 231);
            this.txtNumCliente.MaxLength = 5;
            this.txtNumCliente.Name = "txtNumCliente";
            this.txtNumCliente.Size = new System.Drawing.Size(100, 23);
            this.txtNumCliente.TabIndex = 18;
            // 
            // btnSalvar
            // 
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Location = new System.Drawing.Point(662, 652);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 42;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Location = new System.Drawing.Point(752, 652);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 43;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label22.Location = new System.Drawing.Point(579, 207);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(109, 21);
            this.label22.TabIndex = 46;
            this.label22.Text = "Complemento";
            // 
            // txtComplemCliente
            // 
            this.txtComplemCliente.Location = new System.Drawing.Point(579, 231);
            this.txtComplemCliente.MaxLength = 200;
            this.txtComplemCliente.Name = "txtComplemCliente";
            this.txtComplemCliente.Size = new System.Drawing.Size(248, 23);
            this.txtComplemCliente.TabIndex = 47;
            // 
            // dgv_Responsavel
            // 
            this.dgv_Responsavel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Responsavel.Location = new System.Drawing.Point(12, 277);
            this.dgv_Responsavel.Name = "dgv_Responsavel";
            this.dgv_Responsavel.RowTemplate.Height = 25;
            this.dgv_Responsavel.Size = new System.Drawing.Size(815, 359);
            this.dgv_Responsavel.TabIndex = 48;
            // 
            // FrmClientesCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 687);
            this.Controls.Add(this.dgv_Responsavel);
            this.Controls.Add(this.txtComplemCliente);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtNumCliente);
            this.Controls.Add(this.txtRuaCliente);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBairroCliente);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCidadeCliente);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEstadoCliente);
            this.Controls.Add(this.txtCepCliente);
            this.Controls.Add(this.txtCnpjCliente);
            this.Controls.Add(this.txtNomeCliente);
            this.Controls.Add(this.chkAtivoCliente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmClientesCadastro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Responsavel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label lblId;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private CheckBox chkAtivoCliente;
        private TextBox txtNomeCliente;
        private TextBox txtCnpjCliente;
        private TextBox txtCepCliente;
        private TextBox txtEstadoCliente;
        private Label label6;
        private TextBox txtCidadeCliente;
        private Label label7;
        private TextBox txtBairroCliente;
        private Label label8;
        private Label label9;
        private TextBox txtRuaCliente;
        private TextBox txtNumCliente;
        private Button btnSalvar;
        private Button btnCancelar;
        private Label label22;
        private TextBox txtComplemCliente;
        private DataGridView dgv_Responsavel;
    }
}