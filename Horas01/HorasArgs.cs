using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horas01
{
    public class HorasArgs
    {
        public string Requisicao { get; set; }
        public string Nome { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public TimeSpan Total { get; set; }
        public Periodo Periodo { get; set; }
        public Tipo Tipo { get; set; }
        public TimeSpan P1 { get; set; }
        public TimeSpan P2 { get; set; }
        public TimeSpan P3 { get; set; }
        public TimeSpan P4 { get; set; }
        public string Semana { get; set; }
    }
}
