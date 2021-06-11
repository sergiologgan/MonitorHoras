using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horas01
{
    public class Log_Erro
    {
        public static void GravarErro(string erro)
        {
            if (File.Exists("erro.log"))
            {
                string t = File.ReadAllText("erro.log", Encoding.Default);
                File.WriteAllText("erro.log", $"{t}\n{DateTime.Now}\n{erro}");
                return;
            }
            File.WriteAllText("erro.log", $"{DateTime.Now}\n{erro}");
        }
    }
}
