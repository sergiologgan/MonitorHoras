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
    public partial class MesFechamento : Form
    {
        public MesFechamento()
        {
            InitializeComponent();
            this.comboBox1.Text = this.comboBox1.Items[DateTime.Now.Month - 1].ToString();
            this.numericUpDown1.Value = DateTime.Now.Year;
        }

        private void btninfomes_Click(object sender, EventArgs e)
        {
            Util.MesFechamento = new KeyValuePair<int, int>(this.comboBox1.SelectedIndex + 1, (int)this.numericUpDown1.Value);
        }
    }
}
