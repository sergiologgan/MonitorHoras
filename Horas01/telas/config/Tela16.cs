using Horas01.telas.config.opcoes;
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
    public partial class Tela16 : Form
    {
        private List<Color> ctipos;
        private List<Color> cperiodos;
        private dynamic currentForm;

        public Tela16()
        {
            InitializeComponent();
            ctipos = new List<Color>();
            cperiodos = new List<Color>();
        }

        private void adiconarcontroles(Control control)
        {
            this.currentForm = control;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(control);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = this.listBox1.SelectedIndex;
            switch (idx)
            {
                case 0:
                    Tela17 t = new Tela17();
                    adiconarcontroles(t);
                    break;
                default:
                    this.panel1.Controls.Clear();
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentForm != null)
                {
                    currentForm.Salvar();
                    this.Close();
                }
            }
            catch (Exception er)
            {
                Log_Erro.GravarErro(er.Message);
            }
            finally
            {
                this.Close();
            }
        }
    }
}
