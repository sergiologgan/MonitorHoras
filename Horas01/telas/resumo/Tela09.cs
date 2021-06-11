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
    public partial class Tela09 : UserControl
    {
        public Tela09()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            var nomes = Util.ObterNomes();
            EscolherNome e = new EscolherNome(nomes);
            e.ShowDialog();
            if (string.IsNullOrEmpty(e.Valor)) return;
            carregar(e.Valor);
        }
        private void carregar(string nome)
        {
            try
            {
                var horas = Util.ObterHoras();
                List<string> divs = new List<string>();
                string bs = File.ReadAllText("base.txt");
                if (horas != null)
                {
                    var query = horas
                        .SelectMany(x => x.Value)
                        .Where(x=>x.Nome == nome)
                        .GroupBy(x => new { x.Inicio.Day, x.Nome })
                        .Select(x => new
                        {
                            Args = x.Select(a => a).ToList(),
                            Nome = x.Key.Nome,
                            Dia = x.Key.Day,
                            Total = x.SumGetTimeSpan(s => s.Total)
                        }).OrderBy(x => x.Nome).ToList();
                    if (query.Count <= 0) return;

                    Dictionary<string, List<dynamic>> d = new Dictionary<string, List<dynamic>>();
                    foreach (var q in query)
                    {
                        if (d.ContainsKey(q.Nome)) d[q.Nome].Add(q);
                        else d.Add(q.Nome, new List<dynamic>() { q });
                    }

                    foreach (string n in d.Keys)
                    {
                        List<dynamic> ds = d[n];
                        List<string> corpo = new List<string>();

                        for (int i = 0; i < ds.Count; i++)
                        {
                            dynamic dy = ds[i];
                            List<string[]> colunas = new List<string[]>();
                            for (int a = 0; a < dy.Args.Count; a++)
                            {
                                HorasArgs h = dy.Args[a];
                                colunas.Add(new string[7]
                                {
                                 $"<tr>",
                                 $"<td>{h.Requisicao}</td>",
                                 $"<td>{h.Periodo}</td>",
                                 $"<td>{h.Inicio}</td>",
                                 $"<td>{h.Fim}</td>",
                                 $"<td>{h.Total}</td>",
                                 $"</tr>",
                                });
                            }
                            corpo.AddRange(new List<string>()
                        {
                            string.Format("{0} | {1} | {2}", dy.Args[0].Inicio, dy.Args[0].Inicio, dy.Args[0].Inicio.Year),
                            "<table>",
                            "<tr>",
                            "<td>REQUISICAO</td>",
                            "<td>PERIODO</td>",
                            "<td>HORA INICIAL</td>",
                            "<td>HORA FINAL</td>",
                            "<td>HORAS TRABALHADAS</td>",
                            "</tr>",
                        });
                            corpo.AddRange(colunas.SelectMany(x => x));
                            corpo.AddRange(new List<string>()
                        {
                            "<tr>",
                            "<td>&nbsp;</td>",
                            "<td>&nbsp;</td>",
                            "<td>&nbsp;</td>",
                            "<td>&nbsp;</td>",
                            $"<td>{dy.Total}</td>",
                            "</tr>",
                        });
                            corpo.Add("</table>");
                            corpo.Add("<br>");
                            corpo.Add("<br>");
                        }
                        divs.AddRange(new List<string>()
                    {bs,
                        "<div class=\"box\">",
                        $"<h2>Tempo detalhe: {n}</h2>"
                    });
                        divs.AddRange(corpo);
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
