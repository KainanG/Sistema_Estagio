using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls.Crypto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Bloqueio
{
     class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email  { get; set; }
        public string Login  { get; set; }
        public string Senha { get; set; }
        public char Adm { get; set; }

        public void GetUsuario(int id)
        {
            var sql = "SELECT * FROM usuarios WHERE id=" + id;

            try
            {
                using(var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();
                    using(var cmd = new MySqlCommand(sql, cn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                this.Id = Convert.ToInt32(dr["id"]);
                                this.Nome = dr["nome"].ToString();
                                this.Email = dr["email"].ToString();
                                this.Login = dr["usuario"].ToString();
                                this.Adm = Convert.ToChar(dr["adm"]);
                                this.Senha = dr["senha"].ToString();
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


        public void SalvarUsuario()
        {
            var sql = "";

            if (this.Id == 0)
            {
                sql = "INSERT INTO usuarios (nome, email, usuario, senha, adm) VALUES (@nome, @email, @usuario, @senha, @adm)";
            }
            else
            {
                sql = "UPDATE usuarios SET nome=@nome, email=@email, usuario=@usuario, senha=@senha, adm=@adm WHERE id=" + this.Id;
            }

            try
            {
                using (var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@nome", this.Nome);
                        cmd.Parameters.AddWithValue("@email", this.Email);
                        cmd.Parameters.AddWithValue("@usuario", this.Login);
                        cmd.Parameters.AddWithValue("@senha", this.Senha);
                        cmd.Parameters.AddWithValue("@adm", this.Adm);

                        cmd.ExecuteNonQuery();
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
            var sql = "DELETE FROM usuarios WHERE id=" + this.Id;
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


        public static DataTable GetUsuarios(string procurar = "")
        {
            var dt = new DataTable();
            var sql = "SELECT id, nome, email, usuario, adm, senha FROM db_estagioSis.usuarios";

            if (procurar != "")
                sql += " WHERE usuario LIKE '%" + procurar + "%' OR nome LIKE '%" + procurar + "%'";

            try
            {
                using(var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();
                    using(var da = new MySqlDataAdapter(sql, cn))
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
