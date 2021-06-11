using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horas01
{
    public class InsereHorasArgs
    {
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public TimeSpan Total { get; set; }
        public string Observacao { get; set; }
    }
}
