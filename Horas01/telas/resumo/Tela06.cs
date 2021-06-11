using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horas01.telas.resumo
{
    public partial class Tela06 : UserControl
    {
        public Tela06()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            carregar();
        }

        private void carregar()
        {
            try
            {
                var horas = Util.ObterHoras();
                string bs = File.ReadAllText("base.txt");
                List<string> divs = new List<string>();
                if (horas != null)
                {
                    var query = horas
                        .SelectMany(x => x.Value)
                        .GroupBy(x => new { x.Inicio.Day, x.Nome })
                        .Select(x => new {
                            TotalP1 = x.SumGetTimeSpan(s => s.P1),
                            TotalP2 = x.SumGetTimeSpan(s => s.P2),
                            TotalP3 = x.SumGetTimeSpan(s => s.P3),
                            TotalP4 = x.SumGetTimeSpan(s => s.P4),
                            P1String = x.SumGetTimeSpan(s => s.P1),
                            P2String = x.SumGetTimeSpan(s => s.P2),
                            P3String = x.SumGetTimeSpan(s => s.P3),
                            P4String = x.SumGetTimeSpan(s => s.P4),
                            Nome = x.Key.Nome,
                            Periodo = x.Select(p => p.Periodo),
                            Data = x.Select(f=>f.Inicio).FirstOrDefault(),
                            Total = x.SumGetTimeSpan(s => s.P1 + s.P2 + s.P3 + s.P4)
                        }).OrderBy(x => x.Nome).ToList();

                    Dictionary<string, List<dynamic>> d = new Dictionary<string, List<dynamic>>();
                    foreach (var q in query)
                    {
                        if (d.ContainsKey(q.Nome)) d[q.Nome].Add(q);
                        else d.Add(q.Nome, new List<dynamic>() { q });
                    }

                    foreach (string n in d.Keys)
                    {
                        List<dynamic> ds = d[n];
                        List<string> lines = new List<string>()
                        {
                            "<tr>",
                            "<td>&nbsp;</td>",
                            "<td>Semana</td>",
                            "<td>P1</td>",
                            "<td>P2</td>",
                            "<td>P3</td>",
                            "<td>P4</td>",
                            "<td>Total</td>",
                        };

                        var args = (
                            d[n].SumGetTimeSpan(x => x.TotalP1),
                            d[n].SumGetTimeSpan(x => x.TotalP2),
                            d[n].SumGetTimeSpan(x => x.TotalP3),
                            d[n].SumGetTimeSpan(x => x.TotalP4),
                            d[n].SumGetTimeSpan(x => x.Total));
                        var p1 = Util.FormatarHoras(args.Item1);
                        var p2 = Util.FormatarHoras(args.Item2);
                        var p3 = Util.FormatarHoras(args.Item3);
                        var p4 = Util.FormatarHoras(args.Item4);
                        var total = Util.FormatarHoras(args.Item5);

                        for (int i = 0; i < ds.Count; i++)
                        {
                            dynamic dy = ds[i];
                            string data = string.Format("{0:D2} de {1}, {2:D2}", dy.Data.Day, Util.ObterNomeMes(dy.Data), dy.Data.Year, Util.ObterNomeSemana(dy.Data));
                            string[] colunas = new string[7] { $"<td>{data}</td>", "<td>&nbsp;</td>", "<td>&nbsp;</td>", "<td>&nbsp;</td>", "<td>&nbsp;</td>", "<td>&nbsp;</td>", "<td>&nbsp;</td>", };
                            colunas[1] = $"<td> {Util.ObterNomeSemanaResumido(dy.Data)}</td>";
                            colunas[2] = $"<td {(dy.P1String != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{dy.P1String}</td>";
                            colunas[3] = $"<td {(dy.P2String != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{dy.P2String}</td>";
                            colunas[4] = $"<td {(dy.P3String != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{dy.P3String}</td>";
                            colunas[5] = $"<td {(dy.P4String != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{dy.P4String}</td>";
                            lines.Add("<tr>");
                            colunas[6] = $"<td {(dy.Total != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{dy.Total}</td>";
                            lines.AddRange(colunas.ToList());
                            lines.Add("</tr>");
                        }
                        lines.AddRange(new List<string>()
                        {
                            $"<tr><td>Total</td><td>&nbsp;</td><td {(args.Item1 != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{p1}</td><td {(args.Item2 != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{p2}</td><td {(args.Item3 != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{p3}</td><td {(args.Item4 != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{p4}</td><td {(args.Item5 != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{total}</td></tr>"
                        });
                        divs.AddRange(new List<string>()
                    {
                        bs,
                        "<div class=\"box\">",
                        $"<h2>Tempo resumido: {n}</h2>",
                        "<table>"
                    });
                        divs.AddRange(lines);
                        divs.Add("</table>");
                        divs.Add("</div>");
                    }
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < divs.Count; i++)
                    {
                        sb.Append(divs[i]);
                    }
                    this.webBrowser1.Navigate("about:blank");
                    this.webBrowser1.Document.Write($"{sb.ToString()}</body></html>");
                    this.webBrowser1.Refresh();
                    this.webBrowser1.Visible = true;
                }

            }
            catch (Exception e)
            {
                Log_Erro.GravarErro(e.Message);
            }
        }
    }
}
