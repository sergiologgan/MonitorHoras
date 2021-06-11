using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horas01.telas.ferramentas
{
    public partial class Tela17 : UserControl
    {
        public Tela17()
        {
            InitializeComponent();
        }

        private void btncalcularsimples_Click(object sender, EventArgs e)
        {
            try
            {
                this.lblperiodo.Text = Util.ObterPeriodo(DateTime.Parse(this.maskedTextBox1.Text), this.chkferiado.Checked).ToString();
            }
            catch
            {
                MessageBox.Show("Formato incorreto");
            }
            
            
        }

        private void btncalcularmassa_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in this.grid.Rows)
                {
                    bool isferiado = Convert.ToBoolean(row.Cells[1].Value);
                    DateTime dt = DateTime.Parse(row.Cells[0].Value?.ToString());
                    row.Cells[2].Value = Util.ObterPeriodo(dt, isferiado);
                }
            }
            catch
            {
            }
        }
    }
}
