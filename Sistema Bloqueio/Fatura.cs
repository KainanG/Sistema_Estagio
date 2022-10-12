using System;
using System.Collections.Generic;
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
        public int Repete { get; set; }

    }
}
