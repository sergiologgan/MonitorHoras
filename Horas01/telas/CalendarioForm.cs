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
    public partial class CalendarioForm : Form
    {
        public CalendarioForm()
        {
            InitializeComponent();
        }

        public CalendarioForm(List<string> feriados)
        {
            InitializeComponent();
            for (int i = 0; i < feriados.Count; i++)
            {
                lbferiados.Items.Add(feriados[i]);
            }
        }

        public List<string> Datas { get; private set; }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            Datas = lbferiados.Items.Cast<string>().ToList();
            this.Close();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                string v = calendario.SelectionRange.Start.ToString("dd/MM/yyyy");
                if (!lbferiados.Items.Contains(v))
                {
                    lbferiados.Items.Add(v);
                }
            }
            catch
            {
            }
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            try
            {
                string v = lbferiados.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(v))
                {
                    lbferiados.Items.Remove(v);
                }
            }
            catch
            {
            }
        }
    }
}
