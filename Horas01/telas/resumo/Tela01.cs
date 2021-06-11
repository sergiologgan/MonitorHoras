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
    public partial class Tela01 : UserControl
    {
        public Tela01()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            carregar();
        }



        private void carregar()
        {
            var horas = Util.ObterHoras();
            if (horas != null)
            {
                var query1 = horas
                    .SelectMany(x => x.Value)
                    .GroupBy(x => new { x.Nome })
                    .Select(x=>new { TotalP1 = x.SumGetTimeSpan(s => s.P1),
                                     TotalP2 = x.SumGetTimeSpan(s => s.P2),
                                     TotalP3 = x.SumGetTimeSpan(s => s.P3),
                                     TotalP4 = x.SumGetTimeSpan(s => s.P4),
                                     P1String = x.SumGetString(s => s.P1),
                                     P2String = x.SumGetString(s => s.P2),
                                     P3String = x.SumGetString(s => s.P3),
                                     P4String = x.SumGetString(s => s.P4),
                                     Nome = x.Key.Nome,
                                     Total = x.SumGetTimeSpan(s => s.P1 + s.P2 + s.P3 + s.P4)
                    }).ToList();

                var query2 = horas
                    .SelectMany(x => x.Value)
                    .GroupBy(x => new { x.Nome, x.Requisicao })
                    .Select(x => new
                    {
                        TotalP1 = x.SumGetTimeSpan(s => s.P1),
                        TotalP2 = x.SumGetTimeSpan(s => s.P2),
                        TotalP3 = x.SumGetTimeSpan(s => s.P3),
                        TotalP4 = x.SumGetTimeSpan(s => s.P4),
                        P1String = x.SumGetString(s => s.P1),
                        P2String = x.SumGetString(s => s.P2),
                        P3String = x.SumGetString(s => s.P3),
                        P4String = x.SumGetString(s => s.P4),
                        Tipo = x.Select(s=>s.Tipo).FirstOrDefault(),
                        Nome = x.Key.Nome,
                        Requisicao = x.Key.Requisicao,
                        Total = x.SumGetTimeSpan(s => s.P1 + s.P2 + s.P3 + s.P4)
                    }).OrderBy(x=>x.Nome).ToList();

                var query3 = horas
                   .SelectMany(x => x.Value)
                   .GroupBy(x => new { x.Nome, x.Requisicao })
                   .Select(x => new
                   {
                       TotalP1 = x.Count(c => c.Periodo == Periodo.P1),
                       TotalP2 = x.Count(c => c.Periodo == Periodo.P2),
                       TotalP3 = x.Count(c => c.Periodo == Periodo.P3),
                       TotalP4 = x.Count(c => c.Periodo == Periodo.P4),
                       Tipo = x.Select(s => s.Tipo).FirstOrDefault(),
                       Nome = x.Key.Nome,
                       Requisicao = x.Key.Requisicao,
                       Total = x.Count()
                   }).OrderBy(x => x.Nome).ToList();

                var query4 = horas
                   .SelectMany(x => x.Value)
                   .GroupBy(x => new { x.Requisicao })
                   .Select(x => new
                   {
                       TotalP1 = x.SumGetTimeSpan(s => s.P1),
                       TotalP2 = x.SumGetTimeSpan(s => s.P2),
                       TotalP3 = x.SumGetTimeSpan(s => s.P3),
                       TotalP4 = x.SumGetTimeSpan(s => s.P4),
                       P1String = x.SumGetString(s => s.P1),
                       P2String = x.SumGetString(s => s.P2),
                       P3String = x.SumGetString(s => s.P3),
                       P4String = x.SumGetString(s => s.P4),
                       Requisicao = x.Key.Requisicao,
                       Tipo = x.Select(a=>a.Tipo).FirstOrDefault(),
                       Total = x.SumGetTimeSpan(s => s.P1 + s.P2 + s.P3 + s.P4)
                   }).ToList();

                string bs = File.ReadAllText("base.txt");
                string html1 = null, html2 = null, html3 = null, html4 = null;
                var p1t = query1.SumGetTimeSpan(x => x.TotalP1);
                var p2t = query1.SumGetTimeSpan(x => x.TotalP2);
                var p3t = query1.SumGetTimeSpan(x => x.TotalP3);
                var p4t = query1.SumGetTimeSpan(x => x.TotalP4);
                var totalt = query1.SumGetTimeSpan(x => x.Total);
                int p1c = 0;
                int p2c = 0;
                int p3c = 0;
                int p4c = 0;
                int totalc = 0;

                List<string> lines = new List<string>()
                {
                    "<tr>",
                    "<td>&nbsp;</td>",
                    "<td>P1</td>",
                    "<td>P2</td>",
                    "<td>P3</td>",
                    "<td>P4</td>",
                    "<td>Total</td>",
                    "</tr>"
                };
                foreach (var q in query1)
                {
                    lines.AddRange(new List<string>()
                    {
                        "<tr>",
                        $"<td>{q.Nome}</td>",
                        $"<td {(q.TotalP1 != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{q.P1String}</td>",
                        $"<td {(q.TotalP2 != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{q.P2String}</td>",
                        $"<td {(q.TotalP3 != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{q.P3String}</td>",
                        $"<td {(q.TotalP4 != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{q.P4String}</td>",
                        $"<td {(q.Total != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{Util.FormatarHoras(q.Total)}</td>",
                        "</tr>",
                    });
                }
                List<string> ls = new List<string>()
                {
                    bs,
                    "<div class=\"box\">",
                    "<h2>Tempo dos períodos</h2>",
                    "<table>"
                };

                lines.AddRange(new List<string>()
                {
                    "<tr>",
                    "<td>Total</td>",
                    $"<td {(p1t != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{Util.FormatarHoras(p1t)}</td>",
                    $"<td {(p2t != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{Util.FormatarHoras(p2t)}</td>",
                    $"<td {(p3t != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{Util.FormatarHoras(p3t)}</td>",
                    $"<td {(p4t != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{Util.FormatarHoras(p4t)}</td>",
                    $"<td {(totalt != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{Util.FormatarHoras(totalt)}</td>",
                    "</tr>"
                });

                ls.AddRange(lines);
                ls.Add("</table>");
                ls.Add("</div>");
                for (int i = 0; i < ls.Count; i++)
                {
                    html1 += ls[i];
                }
                //passo2
                lines = new List<string>()
                {
                    "<tr>",
                    "<td>Nome</td>",
                    "<td>Requisição</td>",
                    "<td>Tipo</td>",
                    "<td>P1</td>",
                    "<td>P2</td>",
                    "<td>P3</td>",
                    "<td>P4</td>",
                    "<td>Total</td>",
                    "</tr>"
                };
                foreach (var q in query2)
                {
                    lines.AddRange(new List<string>()
                    {
                        "<tr>",
                        $"<td>{q.Nome}</td>",
                        $"<td>{q.Requisicao}</td>",
                        $"<td>{Util.PrimeiraLetraMaiuscula(q.Tipo.ToString())}</td>",
                        $"<td {(q.TotalP1 != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{q.P1String}</td>",
                        $"<td {(q.TotalP2 != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{q.P2String}</td>",
                        $"<td {(q.TotalP3 != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{q.P3String}</td>",
                        $"<td {(q.TotalP4 != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{q.P4String}</td>",
                        $"<td {(q.Total != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{Util.FormatarHoras(q.Total)}</td>",
                        "</tr>",
                    });
                }
                ls = new List<string>()
                {
                    bs,
                    "<div class=\"box\">",
                    "<h2>Tempo dos períodos</h2>",
                    "<table>"
                };
                p1t = query2.SumGetTimeSpan(x => x.TotalP1);
                p2t = query2.SumGetTimeSpan(x => x.TotalP2);
                p3t = query2.SumGetTimeSpan(x => x.TotalP3);
                p4t = query2.SumGetTimeSpan(x => x.TotalP4);
                totalt = query2.SumGetTimeSpan(x => x.Total);
                lines.AddRange(new List<string>()
                {
                    "<tr>",
                    "<td colspan=\"3\">Total</td>",
                    $"<td {(p1t != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{Util.FormatarHoras(p1t)}</td>",
                    $"<td {(p2t != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{Util.FormatarHoras(p2t)}</td>",
                    $"<td {(p3t != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{Util.FormatarHoras(p3t)}</td>",
                    $"<td {(p4t != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{Util.FormatarHoras(p4t)}</td>",
                    $"<td {(totalt != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{Util.FormatarHoras(totalt)}</td>",
                    "</tr>"
                });

                ls.AddRange(lines);
                ls.Add("</table>");
                ls.Add("</div>");
                for (int i = 0; i < ls.Count; i++)
                {
                    html2 += ls[i];
                }
                //passo3
                lines = new List<string>()
                {
                    "<tr>",
                    "<td>Nome</td>",
                    "<td>Requisição</td>",
                    "<td>Tipo</td>",
                    "<td>P1</td>",
                    "<td>P2</td>",
                    "<td>P3</td>",
                    "<td>P4</td>",
                    "<td>Total</td>",
                    "</tr>"
                };
                foreach (var q in query3)
                {
                    lines.AddRange(new List<string>()
                    {
                        "<tr>",
                        $"<td>{q.Nome}</td>",
                        $"<td>{q.Requisicao}</td>",
                        $"<td>{Util.PrimeiraLetraMaiuscula(q.Tipo.ToString())}</td>",
                        $"<td {(q.TotalP1 > 0 ? "style=\"color:#0094FF;\"" : "")}>{q.TotalP1}</td>",
                        $"<td {(q.TotalP2 > 0 ? "style=\"color:#0094FF;\"" : "")}>{q.TotalP2}</td>",
                        $"<td {(q.TotalP3 > 0 ? "style=\"color:#0094FF;\"" : "")}>{q.TotalP3}</td>",
                        $"<td {(q.TotalP4 > 0 ? "style=\"color:#0094FF;\"" : "")}>{q.TotalP4}</td>",
                        $"<td {(q.Total > 0 ? "style=\"color:#0094FF;\"" : "")}>{q.Total}</td>",
                        "</tr>",
                    });
                }
                ls = new List<string>()
                {
                    bs,
                    "<div class=\"box\">",
                    "<h2>Tempo dos períodos</h2>",
                    "<table>"
                };
                p1c = query3.Select(x => x.TotalP1).Sum();
                p2c = query3.Select(x => x.TotalP2).Sum();
                p3c = query3.Select(x => x.TotalP3).Sum();
                p4c = query3.Select(x => x.TotalP4).Sum();
                totalc = query3.Select(x => x.Total).Sum();
                lines.AddRange(new List<string>()
                {
                    "<tr>",
                    "<td colspan=\"3\">Total</td>",
                    $"<td {(p1c > 0 ? "style=\"color:#0094FF;\"" : "")}>{p1c}</td>",
                    $"<td {(p2c > 0 ? "style=\"color:#0094FF;\"" : "")}>{p2c}</td>",
                    $"<td {(p3c > 0 ? "style=\"color:#0094FF;\"" : "")}>{p3c}</td>",
                    $"<td {(p4c > 0 ? "style=\"color:#0094FF;\"" : "")}>{p4c}</td>",
                    $"<td {(totalc > 0 ? "style=\"color:#0094FF;\"" : "")}>{totalc}</td>",
                    "</tr>"
                });

                ls.AddRange(lines);
                ls.Add("</table>");
                ls.Add("</div>");
                for (int i = 0; i < ls.Count; i++)
                {
                    html3 += ls[i];
                }
                //passo4
                lines = new List<string>()
                {
                    "<tr>",
                    "<td>Requisição</td>",
                    "<td>Tipo</td>",
                    "<td>P1</td>",
                    "<td>P2</td>",
                    "<td>P3</td>",
                    "<td>P4</td>",
                    "<td>Total</td>",
                    "</tr>"
                };
                foreach (var q in query4)
                {
                    lines.AddRange(new List<string>()
                    {
                        "<tr>",
                        $"<td>{q.Requisicao}</td>",
                        $"<td>{Util.PrimeiraLetraMaiuscula(q.Tipo.ToString())}</td>",
                        $"<td {(q.TotalP1 != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{Util.FormatarHoras(q.TotalP1)}</td>",
                        $"<td {(q.TotalP2 != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{Util.FormatarHoras(q.TotalP2)}</td>",
                        $"<td {(q.TotalP3 != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{Util.FormatarHoras(q.TotalP3)}</td>",
                        $"<td {(q.TotalP4 != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{Util.FormatarHoras(q.TotalP4)}</td>",
                        $"<td {(q.Total != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{Util.FormatarHoras(q.Total)}</td>",
                        "</tr>",
                    });
                }
                ls = new List<string>()
                {
                    bs,
                    "<div class=\"box\">",
                    "<h2>Tempo dos períodos</h2>",
                    "<table>"
                };
                p1t = query4.SumGetTimeSpan(x => x.TotalP1);
                p2t = query4.SumGetTimeSpan(x => x.TotalP2);
                p3t = query4.SumGetTimeSpan(x => x.TotalP3);
                p4t = query4.SumGetTimeSpan(x => x.TotalP4);
                totalt = query4.SumGetTimeSpan(x => x.Total);
                lines.AddRange(new List<string>()
                {
                    "<tr>",
                    "<td colspan=\"2\">Total</td>",
                    $"<td {(p1t != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{Util.FormatarHoras(p1t)}</td>",
                    $"<td {(p2t != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{Util.FormatarHoras(p2t)}</td>",
                    $"<td {(p3t != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{Util.FormatarHoras(p3t)}</td>",
                    $"<td {(p4t != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{Util.FormatarHoras(p4t)}</td>",
                    $"<td {(totalt != TimeSpan.Zero ? "style=\"color:#0094FF;\"" : "")}>{Util.FormatarHoras(totalt)}</td>",
                    "</tr>"
                });

                ls.AddRange(lines);
                ls.Add("</table>");
                ls.Add("</div>");
                for (int i = 0; i < ls.Count; i++)
                {
                    html4 += ls[i];
                }

                this.webBrowser1.Navigate("about:blank");
                this.webBrowser1.Document.Write($"{html1}{html2}{html3}{html4}</body></html>");
                this.webBrowser1.Refresh();
                this.webBrowser1.Visible = true;
            }
        }
    }
}
