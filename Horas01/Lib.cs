using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horas01
{
    public class Lib
    {
        private List<List<object>> objs;
        private List<object> header;
        public Lib()
        {
            objs = new List<List<object>>();
            header = new List<object>() { "<table>", "<tr>", };
            
        }

        public void SetHeader(params object[] value)
        {
            header = new List<object>() { "<tr>" };
            for (int i = 0; i < value.Length; i++)
            {
                header.Add($"<td>{value[i]}</td>");
            }
            header.Add("</tr>");
        }

        public void Add(params object[] value)
        {
            objs.Add(new List<object>());
            for (int i = 0; i < value.Length; i++)
            {
                object v = value[i];
                objs[objs.Count - 1].Add(v);
            }
        }

        public string GetHtml(string titulo)
        {
            string bs = File.ReadAllText("base.txt");
            List<object> divs = new List<object>();
            List<object> corpo = new List<object>();
            List<object> row = new List<object>();
            for (int i = 0; i < objs.Count; i++)
            {
                List<object> os = objs[i];
                row.Add("<tr>");
                for (int l = 0; l < os.Count; l++)
                {
                    object o = os[l];
                    row.Add($"<td>{o}</td>");
                }
                row.Add("</tr>");
            }
            corpo.Add("<table>");
            corpo.Add("<tr>");
            int max = objs.Select(x => x.Count).Max();
            for (int i = 0; i < max; i++)
            {
                if (i >= header.Count)
                    corpo.Add("<td></td>");
                else
                    corpo.Add(header[i]);
            }
            corpo.Add("</tr>");
            corpo.AddRange(row.Select(x => x).ToArray());
            corpo.Add("</table>");
            divs.AddRange(new List<string>()
            {bs,
                "<div class=\"box\">",
                $"<h2>{titulo}</h2>"
            });
            divs.AddRange(corpo);
            divs.Add("</div>");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < divs.Count; i++)
            {
                sb.Append(divs[i]);
            }
            return sb.ToString();
        }

        public List<List<object>> Rows { get => objs; set => objs = value; }
    }
}
