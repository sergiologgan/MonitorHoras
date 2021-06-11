using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horas01.telas.gerar
{
    public partial class Tela12 : UserControl
    {
        public Tela12()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            grid.DoubleBuffered(true);
            MesFechamento m = new MesFechamento();
            m.ShowDialog();
            carregar();
        }

        private void carregar()
        {
            try
            {
                this.grid.Rows.Clear();
                var hs = Util.ObterHoras();
                List<HorasArgs> ls = new List<HorasArgs>();
                foreach (var t in hs)
                {
                    ls.AddRange(t.Value);
                }

                var query = ls
                 .GroupBy(x => new { x.Inicio.Day, x.Nome })
                 .Select(x => new
                 {
                     Nome = x.Key.Nome,
                     Day = x.Key.Day,
                     Date = x.Select(i => i.Inicio).FirstOrDefault(),
                     P1 = x.SumGetString(i => i.P1),
                     P2 = x.SumGetString(i => i.P2),
                     P3 = x.SumGetString(i => i.P3),
                     P4 = x.SumGetString(i => i.P4),
                     Total = x.SumGetString(i => i.Total),
                     Semana = x.Select(i => i.Semana).FirstOrDefault(),
                     Args = x.Select(i => i).ToList()
                 })
                 .OrderBy(x => x.Nome)
                 .ThenBy(x => x.Date.Day)
                 .ToList();

                foreach (var q in query)
                {
                    grid.Rows.Add(
                            "TOTVS",
                            q.Nome,
                            q.Date.ToString("dd/MM/yyyy"),
                            q.Total,
                            null,
                            null,
                            null,
                            null,
                            q.P3,
                            q.P1,
                            q.P2,
                            q.P4,
                            null,
                            q.Date.DayOfWeek == DayOfWeek.Sunday || q.Date.DayOfWeek == DayOfWeek.Saturday ? q.Semana : null,
                            q.Total,
                            "00:00:00"
                            );
                }
            }
            catch (Exception e)
            {
                Log_Erro.GravarErro(e.Message);
            }
        }

        private void gerarmes(List<dynamic> list)
        {
            int length = DateTime.DaysInMonth(Util.MesFechamento.Value, Util.MesFechamento.Key);
            Dictionary<int, dynamic> d = new Dictionary<int, dynamic>();
            for (int i = 0; i < length; i++)
            {
                d.Add(i, null);
                if (list.Any(x=>x.Day == i))
                {

                }
            }
        }

        private void carregar(string nome)
        {
            try
            {
                this.grid.Rows.Clear();
                var hss = Util.ObterHoras();
                List<HorasArgs> hs = new List<HorasArgs>();
                foreach (Tipo t in hss.Keys)
                {
                    List<HorasArgs> ls = hss[t];
                    for (int i = 0; i < ls.Count; i++)
                    {
                        if (ls[i].Nome == nome)
                            hs.Add(ls[i]);
                    }
                }

                var query = hs
                 .GroupBy(x => new { x.Inicio.Day, x.Nome })
                 .Select(x => new
                 {
                     Nome = x.Key.Nome,
                     Day = x.Key.Day,
                     Date = x.Select(i => i.Inicio).FirstOrDefault(),
                     P1 = x.SumGetString(i => i.P1),
                     P2 = x.SumGetString(i => i.P2),
                     P3 = x.SumGetString(i => i.P3),
                     P4 = x.SumGetString(i => i.P4),
                     Total = x.SumGetString(i => i.Total),
                     Semana = x.Select(i => i.Semana).FirstOrDefault(),
                     Args = x.Select(i => i).ToList()
                 })
                 .OrderBy(x => x.Nome)
                 .ThenBy(x => x.Date.Day)
                 .ToList();

                foreach (var q in query)
                {
                    grid.Rows.Add(
                            "TOTVS",
                            q.Nome,
                            q.Date.ToString("dd/MM/yyyy"),
                            q.Total,
                            null,
                            null,
                            null,
                            null,
                            q.P3,
                            q.P1,
                            q.P2,
                            q.P4,
                            null,
                            q.Date.DayOfWeek == DayOfWeek.Sunday || q.Date.DayOfWeek == DayOfWeek.Saturday ? q.Semana : null,
                            q.Total,
                            "00:00:00"
                            );
                }
            }
            catch (Exception e)
            {
                Log_Erro.GravarErro(e.Message);
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pindividual_Click(object sender, EventArgs e)
        {
            EscolherNome n = new EscolherNome(Util.ObterNomes());
            n.ShowDialog();
            if (!string.IsNullOrEmpty(n.Valor))
                carregar(n.Valor);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            carregar();
        }
    }
}
