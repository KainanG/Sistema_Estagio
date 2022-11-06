using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Bloqueio
{
    internal class Responsavel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public char Status { get; set; }
        public List<Endereco> Enderecos { get; set; }


        public void GetResponsavel(int id)
        {
            var sql = "SELECT * FROM responsaveis WHERE id=" + id;

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
                                this.Id = Convert.ToInt32(dr["id"]);
                                this.Nome = dr["nome"].ToString();
                                this.Celular = dr["celular"].ToString();
                                this.Telefone = dr["telefone"].ToString();
                                this.Cpf = dr["cpf"].ToString();
                                this.Rg = dr["rg"].ToString();
                                this.Status = Convert.ToChar(dr["status"]);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SalvarResponsavel(string nomeUsuario)
        {
            var sql = "";

            /*if (this.Id == 0)
            {*/
                sql = "INSERT INTO responsaveis (nome, celular, telefone, cpf, rg, bloqueado) VALUES (@nome, @celular, @telefone, @cpf, @rg, @status);" +
                    "INSERT INTO enderecos (cep, estado, cidade, bairro, rua, numero, complemento, id_responsavel)" +
                    "VALUES (@cep, @estado, @cidade, @bairro, @rua, @numero, @complemento, LAST_INSERT_ID());" +
                    "INSERT INTO logs (usuario, data, form) VALUES (@usuario, @data, @form)";
           /* }
            else
            {
                sql = "UPDATE responsaveis SET nome=@nome, cnpj=@cnpj, status=@status WHERE id=" + this.Id;
            }*/

            try
            {
                using (var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@nome", this.Nome);
                        cmd.Parameters.AddWithValue("@celular", this.Celular);
                        cmd.Parameters.AddWithValue("@telefone", this.Telefone);
                        cmd.Parameters.AddWithValue("@cpf", this.Cpf);
                        cmd.Parameters.AddWithValue("@rg", this.Rg);
                        cmd.Parameters.AddWithValue("@status", this.Status);
                        cmd.Parameters.AddWithValue("@cep", this.Enderecos.FirstOrDefault().Cep);
                        cmd.Parameters.AddWithValue("@estado", this.Enderecos.FirstOrDefault().Estado);
                        cmd.Parameters.AddWithValue("@cidade", this.Enderecos.FirstOrDefault().Cidade);
                        cmd.Parameters.AddWithValue("@bairro", this.Enderecos.FirstOrDefault().Bairro);
                        cmd.Parameters.AddWithValue("@rua", this.Enderecos.FirstOrDefault().Rua);
                        cmd.Parameters.AddWithValue("@numero", this.Enderecos.FirstOrDefault().Numero);
                        cmd.Parameters.AddWithValue("@complemento", this.Enderecos.FirstOrDefault().Complemento);
                        cmd.Parameters.AddWithValue("@usuario", nomeUsuario.Replace('\'', ' ').Trim());
                        cmd.Parameters.AddWithValue("@data", DateTime.Today.ToString("dd/MM/yyyy"));
                        cmd.Parameters.AddWithValue("@form", "Responsável");



                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public static DataTable GetResponsaveis(string procurar = "")
        {
            var dt = new DataTable();
            var sql = "SELECT id, nome, celular, telefone, cpf, rg, status FROM db_estagioSis.responsaveis";

            if (procurar != "")
                sql += " WHERE nome LIKE '%" + procurar + "%' OR cpf LIKE '%" + procurar + "%'";

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
            return dt;
        }


    }
}
