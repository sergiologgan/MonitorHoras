using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horas01.telas.config
{
    public partial class Tela11 : UserControl
    {
        private List<string> feriados;
        public Tela11()
        {
            InitializeComponent();
            feriados = Util.ObterFeriados().ToList();
            this.listbox.Items.AddRange(feriados.ToArray());
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            string v = calendar.SelectionRange.Start.ToString("dd/MM/yyyy");
            if (!listbox.Items.Contains(v))
            {
                this.listbox.Items.Add(v);
                feriados.Add(v);
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            Util.SetarFeriado(feriados);
            this.Hide();
        }

        private void btnremoe_Click(object sender, EventArgs e)
        {
            string v = this.listbox.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(v))
            {
                feriados.Remove(v);
                this.listbox.Items.Remove(v);
            }
        }
    }
}
