using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horas01.telas
{
    public partial class InserirPlantao : Form
    {
        public List<InsereHorasArgs> Horas { get; private set; }

        public InserirPlantao()
        {
            InitializeComponent();
            Horas = new List<InsereHorasArgs>();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.V && !string.IsNullOrEmpty(Clipboard.GetText()))
                {
                    string text = Clipboard.GetText().Replace("\t", "%").Replace("\r\n", "%");
                    string[] cols = text.Split('%').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    dataGridView1.Rows.Clear();
                    Horas = new List<InsereHorasArgs>();
                    for (int i = 0; i < cols.Length; i += 4)
                    {
                        Horas.Add(new InsereHorasArgs()
                        {
                            Inicio = DateTime.Parse(cols[i]),
                            Fim = DateTime.Parse(cols[i+1]),
                            Total = TimeSpan.Parse(cols[i+2]),
                            Observacao = cols[i+3]
                        });
                        this.dataGridView1.Rows.Add(cols[i], cols[i+1], cols[i+2], cols[i+3]);
                    }
                }
            }
            catch (Exception er)
            {
                Log_Erro.GravarErro(er.Message);
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnlimpar_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
        }
    }
}
