using Google.Protobuf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Bloqueio
{
     class Cliente
     {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public char Status { get; set; }
        public string usuario { get; set; } 

        public List<Endereco> Enderecos { get; set; }
        public List<Responsavel> Responsaveis { get; set; }


        public void GetCliente(int id)
        {
            var sql = "SELECT * FROM clientes WHERE id=" + id;

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
                                this.Cnpj = dr["cnpj"].ToString();
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


        public void SalvarCliente(string nomeUsuario)
        {
            var sql = "";

            if (this.Id == 0)
            {
                sql = "INSERT INTO clientes (nome, cnpj, status) VALUES (@nome, @cnpj, @status);" +
                    "INSERT INTO enderecos (cep, estado, cidade, bairro, rua, numero, complemento, cliente_idcliente)" +
                    "VALUES (@cep, @estado, @cidade, @bairro, @rua, @numero, @complemento, LAST_INSERT_ID());" +
                    "INSERT INTO logs (usuario, data, form) VALUES (@usuario, @data, @form)";
            }
            else
            {
                sql = "UPDATE clientes SET nome=@nome, cnpj=@cnpj, status=@status WHERE id=" + this.Id;
            }

            try
            {
                using (var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@nome", this.Nome);                      
                        cmd.Parameters.AddWithValue("@cnpj", this.Cnpj);
                        cmd.Parameters.AddWithValue("@status", this.Status);
                        cmd.Parameters.AddWithValue("@cep", this.Enderecos.FirstOrDefault().Cep);
                        cmd.Parameters.AddWithValue("@estado", this.Enderecos.FirstOrDefault().Estado);
                        cmd.Parameters.AddWithValue("@cidade", this.Enderecos.FirstOrDefault().Cidade);
                        cmd.Parameters.AddWithValue("@bairro", this.Enderecos.FirstOrDefault().Bairro);
                        cmd.Parameters.AddWithValue("@rua", this.Enderecos.FirstOrDefault().Rua);
                        cmd.Parameters.AddWithValue("@numero", this.Enderecos.FirstOrDefault().Numero);
                        cmd.Parameters.AddWithValue("@complemento", this.Enderecos.FirstOrDefault().Complemento);
                        cmd.Parameters.AddWithValue("@usuario", nomeUsuario);
                        cmd.Parameters.AddWithValue("@data", DateTime.Today.ToString("dd/MM/yyyy"));
                        cmd.Parameters.AddWithValue("@form", "Clientes");





                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public static DataTable GetClientes(string procurar = "")
        {
            

            var dt = new DataTable();
            var sql = "SELECT id, nome, cnpj, status FROM db_estagioSis.clientes";

            if (procurar != "")
                sql += " WHERE nome LIKE '%" + procurar + "%' OR cnpj LIKE '%" + procurar + "%'";

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
