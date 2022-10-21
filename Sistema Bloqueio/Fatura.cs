using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Bloqueio
{
    internal class Fatura
    {
        public int Id { get; set; }
        public string Valor { get; set; }
        public string Mes { get; set; }
        public string Vencimento { get; set; }
        public char FaturaPaga { get; set; }
        public int Cliente_idcliente { get; set; }
        public string Repete { get; set; }

        public void GetFatura(int id)
        {
            var sql = "SELECT * FROM faturas WHERE id=" + id;

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
                                this.Valor = dr["valor"].ToString();
                                this.Mes = dr["mes"].ToString();
                                this.Vencimento = dr["vencimento"].ToString();
                                this.FaturaPaga = Convert.ToChar(dr["faturapaga"]);
                                this.Repete = dr["repete"].ToString();
                                this.Cliente_idcliente = (int)dr["cliente_idcliente"];

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

        public void Excluir()
        {
            var sql = "DELETE FROM faturas WHERE id=" + this.Id;
            try
            {
                using (var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void SalvarFatura()
        {
            var sql = "";

            if (this.Id == 0)
            {
                sql = "INSERT INTO faturas (valor, mes, vencimento, repete, faturapaga, cliente_idcliente) VALUES (@valor, @mes, @vencimento, @repete, @faturapaga, @cliente_idcliente)";
                  
            }
            else
            {
                sql = "UPDATE fatuas SET nome=@valor, mes=@mes, vencimento=@vencimento, repete=@repete WHERE id=" + this.Id;
            }

            try
            {
                using (var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@valor", this.Valor);
                        cmd.Parameters.AddWithValue("@mes", this.Mes);
                        cmd.Parameters.AddWithValue("@vencimento", this.Vencimento);
                        cmd.Parameters.AddWithValue("@repete", this.Repete);
                        cmd.Parameters.AddWithValue("@faturapaga", "Não");
                        cmd.Parameters.AddWithValue("@cliente_idcliente", this.Cliente_idcliente);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public static DataTable GetFaturas(string procurar = "")
        {
            var dt = new DataTable();
            var sql = "USE `db_estagioSis`; SELECT fatura.id, fatura.valor, fatura.mes, fatura.vencimento, fatura.repete, fatura.faturapaga," +
                " cliente.nome FROM faturas as fatura LEFT JOIN clientes as cliente ON fatura.cliente_idcliente = cliente.id";

            if (procurar != "")
                sql += $" WHERE fatura.vencimento LIKE '%{procurar}%' OR fatura.valor LIKE '%{procurar}%' OR fatura.faturapaga LIKE '%{procurar}%' OR cliente.nome LIKE '%{procurar}%' OR fatura.mes LIKE '%{procurar}%'";

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

        public void PagarFatura(bool pendente = false)
        {
            
            
                var sql = "UPDATE faturas SET faturapaga=@faturapaga WHERE id=" + this.Id;
            
            try
            {
                using (var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();
                    using (var cmd = new MySqlCommand(sql, cn))
                    {

                        cmd.Parameters.AddWithValue("@faturapaga", pendente==false?"Sim":"Não");                       
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
