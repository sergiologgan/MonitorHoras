using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Horas01.telas.config;
using Horas01.telas.ferramentas;
using Horas01.telas.gerar;
using Horas01.telas.resumo;
using Horas01.telas.simular;

namespace Horas01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Util.CarregarDados();

            var numeros = new[] { 1, 2, 3, 4 };
            var soma = numeros.Aggregate((a, b) => a + b);
            Console.WriteLine(soma); // resultado: 10 (1+2+3+4)
        }

        private void adiconarcontroles(Control control)
        {
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(control);
        }

        #region inserir
        private void horasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tela10 t = new Tela10();
            adiconarcontroles(t);
        }

        private void feriadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tela11 t = new Tela11();
            adiconarcontroles(t);
        }

        private void opçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tela16 t = new Tela16();
            t.ShowDialog();
        }
        #endregion


        #region config
        private void resumoGeralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tela01 t = new Tela01();
            adiconarcontroles(t);
        }

        private void promotoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tela02 t = new Tela02();
            adiconarcontroles(t);
        }

        private void cartãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tela03 t = new Tela03();
            adiconarcontroles(t);
        }

        private void cartãoSTBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tela04 t = new Tela04();
            adiconarcontroles(t);
        }

        private void promotoraSTBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tela05 t = new Tela05();
            adiconarcontroles(t);
        }

        private void lançamentoGeralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tela06 t = new Tela06();
            adiconarcontroles(t);
        }

        private void lançamentoDetalheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tela07 t = new Tela07();
            adiconarcontroles(t);
        }

        private void lançamentoDetalheToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Tela08 t = new Tela08();
            adiconarcontroles(t);
        }

        private void lançamentoDetalhePorPessoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tela09 t = new Tela09();
            adiconarcontroles(t);
        }




        #endregion

        #region simular
        private void simulaçãoComPlantãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tela14 t = new Tela14();
            adiconarcontroles(t);
        }

        #endregion

        private void calcularPeríodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tela17 t = new Tela17();
            adiconarcontroles(t);
        }

        private void réguaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tela12 t = new Tela12();
            adiconarcontroles(t);
        }
    }
}
