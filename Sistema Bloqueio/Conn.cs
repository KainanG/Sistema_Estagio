using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Bloqueio
{
    static class Conn
    {
        private const string servidor = "localhost";
        private const string bancoDados = "db_estagioSis";
        private const string usuario = "root";
        private const string senha = "!Kg!s2601#";

        static public string strConn = $"server={servidor};User Id={usuario};database={bancoDados};password={senha}";
    }
}
