using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horas01
{
    public static class Util
    {
        private static CultureInfo culture = new CultureInfo("pt-BR");
        private static DateTimeFormatInfo dtfi;
        private static Dictionary<Tipo, List<HorasArgs>> horas;
        private static LimiteHoraArgs limiteHoraArgs;
        public static KeyValuePair<int, int> MesFechamento { get; set; }

        public static LimiteHoraArgs LimiteHoraArgs
        {
            get {
                if (limiteHoraArgs is null) return JsonConvert.DeserializeObject<LimiteHoraArgs>(LerTexto("colors.json"));
                else return limiteHoraArgs;
            }
            set => limiteHoraArgs = JsonConvert.DeserializeObject<LimiteHoraArgs>(LerTexto("colors.txt"));
        }

        public static void GravarObjetosJson(object obj, string caminho)
        {
            if (obj != null)
            {
                File.WriteAllText(caminho, JsonConvert.SerializeObject(obj));
            }
        }

        public static bool ExisteArquivo(string caminho)
        {
            return File.Exists(caminho);
        }
        
        public static string LerTexto(string caminho)
        {
            if (File.Exists(caminho))
            {
                return File.ReadAllText(caminho, Encoding.UTF8);
            }
            return null;
        }

        public static void SetCulture(CultureInfo c)
        {
            culture = c;
        }

        public static string PrimeiraLetraMaiuscula(string nome)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nome.ToLower());
        }

        public static string FormatarHoras(TimeSpan time)
        {
            if (time.Days >= 1)
            {
                int h = time.Days * 24;
                return string.Format("{0:D2}:{1:D2}:{2:D2}", time.Hours + h, time.Minutes, time.Seconds);
            }
            return string.Format("{0:D2}:{1:D2}:{2:D2}", time.Hours, time.Minutes, time.Seconds);
        }

        public static IEnumerable<int> ObterArrayDias()
        {
            for (int i = 1; i <= DateTime.DaysInMonth(MesFechamento.Value, MesFechamento.Key); i++)
            {
                yield return i;
            }
        }

        public static string ObterNomeSemana(DateTime date)
        {
            dtfi = culture.DateTimeFormat;
            return dtfi.GetDayName(date.DayOfWeek);
        }

        public static string ObterNomeSemanaResumido(DateTime data)
        {
            switch (data.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return "Domingo";
                case DayOfWeek.Monday:
                    return "Segunda";
                case DayOfWeek.Tuesday:
                    return "Terça";
                case DayOfWeek.Wednesday:
                    return "Quarta";
                case DayOfWeek.Thursday:
                    return "Quinta";
                case DayOfWeek.Friday:
                    return "Sexta";
                case DayOfWeek.Saturday:
                    return "Sábado";
                default:
                    return null;
            }
        }

        public static string ObterNomeMes(DateTime date)
        {
            dtfi = culture.DateTimeFormat;
            return dtfi.GetMonthName(date.Month);
        }

        public static void SetarFeriado(List<string> feriados)
        {
            File.WriteAllLines("feriados.txt", feriados.ToArray());
        }

        public static IEnumerable<string> ObterFeriados()
        {

            if (!File.Exists("feriados.txt"))
            {
                File.WriteAllText("feriados.txt", "");
                yield return null;
            }
            string[] lines = File.ReadAllLines("feriados.txt", Encoding.Default);
            foreach (string f in lines)
            {
                yield return f;
            }
        }

        public static Periodo ObterPeriodo(DateTime date)
        {
            string semana = ObterNomeSemana(date).ToLower();
            var feriados = ObterFeriados().ToList();
            if (semana == "domingo" || feriados.Contains(date.ToString("dd/MM/yyyy")))
            {
                return Periodo.P4;
            }
            else if (semana == "segunda-feira")
            {
                if (date.Hour >= 17)
                    return Periodo.P2;
                else if (date.Hour >= 8)
                    return Periodo.P1;
                else if (date.Hour >= 0)
                    return Periodo.P4;
            }
            else if (semana == "sábado")
            {
                if (date.Hour >= 8)
                    return Periodo.P4;
                else if (date.Hour >= 0)
                    return Periodo.P3;
            }
            else
            {
                if (date.Hour >= 17)
                    return Periodo.P2;
                else if (date.Hour >= 8)
                    return Periodo.P1;
                else if (date.Hour >= 0)
                    return Periodo.P3;
            }
            return Periodo.NULL;
        }

        public static Periodo ObterPeriodo(DateTime date, bool eferiado)
        {
            string semana = ObterNomeSemana(date).ToLower();
            var feriados = ObterFeriados().ToList();
            if (semana == "domingo" || feriados.Contains(date.ToString("dd/MM/yyyy")) || eferiado)
            {
                return Periodo.P4;
            }
            else if (semana == "segunda-feira")
            {
                if (date.Hour >= 17)
                    return Periodo.P2;
                else if (date.Hour >= 8)
                    return Periodo.P1;
                else if (date.Hour >= 0)
                    return Periodo.P4;
            }
            else if (semana == "sábado")
            {
                if (date.Hour >= 8)
                    return Periodo.P4;
                else if (date.Hour >= 0)
                    return Periodo.P3;
            }
            else
            {
                if (date.Hour >= 17)
                    return Periodo.P2;
                else if (date.Hour >= 8)
                    return Periodo.P1;
                else if (date.Hour >= 0)
                    return Periodo.P3;
            }
            return Periodo.NULL;
        }


        public static void SetHoras(Dictionary<Tipo, List<HorasArgs>> hs)
        {
            horas = hs;
        }
        
        public static Dictionary<Tipo, List<HorasArgs>> ObterHoras()
        {
            return horas;
        }
        
        public static void CarregarDados()
        {
            if (File.Exists("horas.txt"))
            {
                horas = JsonConvert.DeserializeObject<Dictionary<Tipo, List<HorasArgs>>>(File.ReadAllText("horas.txt", Encoding.UTF8));
            }
        }
        
        public static List<string> ObterNomes()
        {
            if (horas != null)
            {
                return horas.SelectMany(x => x.Value).GroupBy(x => new { x.Nome }).Select(x => x.Key.Nome).ToList();
            }
            return null;
        }

    
    }
}
