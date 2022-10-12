using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Bloqueio
{
    internal class Endereco
    {
        public int Id { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Resp { get; set; }



        public void GetEnderecoCliente(int id)
        {
            var sql = "SELECT * FROM enderecos WHERE id=" + id;

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
                                this.Cep = dr["cep"].ToString();
                                this.Estado = dr["estado"].ToString();
                                this.Cidade = dr["cidade"].ToString();                             
                                this.Bairro = dr["bairro"].ToString();
                                this.Rua = dr["rua"].ToString();
                                this.Numero = Convert.ToInt32(dr["numero"]);
                                this.Complemento = dr["complemento"].ToString();
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

        public void SalvarEnderecoCliente(int id)
        {
            var sql = "";

            if (this.Id == 0)
            {
                sql = "INSERT INTO enderecos (cep, estado, cidade, bairro, rua, numero, complemento, cliente_idcliente) VALUES (@cep, @estado, @cidade, @bairro, @rua, @numero, @complemento, @cliente_idcliente)";
            }
            else
            {
                sql = "UPDATE enderecos SET cep=@cep, estado=@estado, cidade=@cidade, bairro=@bairro, rua=@rua, numero=@numero, complemento=@complemento, cliente_idcliente=@cliente_idcliente WHERE id=" + this.Id;
            }

            try
            {
                using (var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();
                    using (var cmd = new MySqlCommand(sql, cn))
                    {                     
                        cmd.Parameters.AddWithValue("@cep", this.Cep);
                        cmd.Parameters.AddWithValue("@estado", this.Estado);
                        cmd.Parameters.AddWithValue("@cidade", this.Cidade);
                        cmd.Parameters.AddWithValue("@bairro", this.Bairro);
                        cmd.Parameters.AddWithValue("@rua", this.Rua);
                        cmd.Parameters.AddWithValue("@numero", this.Numero);
                        cmd.Parameters.AddWithValue("@complemento", this.Complemento);
                        cmd.Parameters.AddWithValue("@cliente_idcliente", this.Id_Cliente);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
