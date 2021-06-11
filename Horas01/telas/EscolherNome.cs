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
    public partial class EscolherNome : Form
    {
        public string Valor { get; set; }
        public EscolherNome(List<string> nomes)
        {
            InitializeComponent();
            this.listBox1.Items.AddRange(nomes.ToArray());
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Valor = this.listBox1.Items[this.listBox1.SelectedIndex].ToString();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (!(this.listBox1.SelectedIndex >= 0))
            {
                MessageBox.Show("Selecione um nome");
                return;
            }
            this.Close();
        }
    }
}
