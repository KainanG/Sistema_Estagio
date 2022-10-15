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


        public void SalvarFatura()
        {
            var sql = "";

            if (this.Id == 0)
            {
                sql = "INSERT INTO faturas (valor, mes, vencimento, repete, faturapaga, cliente_idcliente) VALUES (@valor, @mes, @vencimento, @repete, @faturapaga, @cliente_idcliente)";
                  
            }
            else
            {
                sql = "UPDATE faturas SET nome=@nome, email=@email, usuario=@usuario, senha=@senha, adm=@adm WHERE id=" + this.Id;
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
            var sql = "SELECT id, valor, mes, vencimento, repete, faturapaga, cliente_idcliente FROM db_estagioSis.faturas";

            if (procurar != "")
                sql += " WHERE vencimento LIKE '%" + procurar + "%' OR valor LIKE '%" + procurar + "%'";

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
