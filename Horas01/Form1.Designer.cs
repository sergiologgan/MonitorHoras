
namespace Horas01
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fecharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feriadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumoGeralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lançamentoGeralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lançamentoDetalheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lançamentoDetalheToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lançamentoDetalhePorPessoaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulaçãoComPlantãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simularMêsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ferramentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calcularPeríodosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.réguaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planilhaDeFechamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.resumosToolStripMenuItem,
            this.resumoToolStripMenuItem,
            this.simularToolStripMenuItem,
            this.ferramentasToolStripMenuItem,
            this.gerarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(856, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.fecharToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            // 
            // fecharToolStripMenuItem
            // 
            this.fecharToolStripMenuItem.Name = "fecharToolStripMenuItem";
            this.fecharToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.fecharToolStripMenuItem.Text = "Fechar";
            // 
            // resumosToolStripMenuItem
            // 
            this.resumosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.horasToolStripMenuItem,
            this.feriadoToolStripMenuItem,
            this.opçõesToolStripMenuItem});
            this.resumosToolStripMenuItem.Name = "resumosToolStripMenuItem";
            this.resumosToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.resumosToolStripMenuItem.Text = "Configurar";
            // 
            // horasToolStripMenuItem
            // 
            this.horasToolStripMenuItem.Name = "horasToolStripMenuItem";
            this.horasToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.horasToolStripMenuItem.Text = "Horas";
            this.horasToolStripMenuItem.Click += new System.EventHandler(this.horasToolStripMenuItem_Click);
            // 
            // feriadoToolStripMenuItem
            // 
            this.feriadoToolStripMenuItem.Name = "feriadoToolStripMenuItem";
            this.feriadoToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.feriadoToolStripMenuItem.Text = "Feriado";
            this.feriadoToolStripMenuItem.Click += new System.EventHandler(this.feriadoToolStripMenuItem_Click);
            // 
            // opçõesToolStripMenuItem
            // 
            this.opçõesToolStripMenuItem.Name = "opçõesToolStripMenuItem";
            this.opçõesToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.opçõesToolStripMenuItem.Text = "Opções";
            this.opçõesToolStripMenuItem.Click += new System.EventHandler(this.opçõesToolStripMenuItem_Click);
            // 
            // resumoToolStripMenuItem
            // 
            this.resumoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resumoGeralToolStripMenuItem,
            this.lançamentoGeralToolStripMenuItem,
            this.lançamentoDetalheToolStripMenuItem,
            this.lançamentoDetalheToolStripMenuItem1,
            this.lançamentoDetalhePorPessoaToolStripMenuItem});
            this.resumoToolStripMenuItem.Name = "resumoToolStripMenuItem";
            this.resumoToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.resumoToolStripMenuItem.Text = "Resumo";
            // 
            // resumoGeralToolStripMenuItem
            // 
            this.resumoGeralToolStripMenuItem.Name = "resumoGeralToolStripMenuItem";
            this.resumoGeralToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.resumoGeralToolStripMenuItem.Text = "Resumo geral";
            this.resumoGeralToolStripMenuItem.Click += new System.EventHandler(this.resumoGeralToolStripMenuItem_Click);
            // 
            // lançamentoGeralToolStripMenuItem
            // 
            this.lançamentoGeralToolStripMenuItem.Name = "lançamentoGeralToolStripMenuItem";
            this.lançamentoGeralToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.lançamentoGeralToolStripMenuItem.Text = "Lançamento resumo";
            this.lançamentoGeralToolStripMenuItem.Click += new System.EventHandler(this.lançamentoGeralToolStripMenuItem_Click);
            // 
            // lançamentoDetalheToolStripMenuItem
            // 
            this.lançamentoDetalheToolStripMenuItem.Name = "lançamentoDetalheToolStripMenuItem";
            this.lançamentoDetalheToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.lançamentoDetalheToolStripMenuItem.Text = "Lançamento resumo (Pessoa)";
            this.lançamentoDetalheToolStripMenuItem.Click += new System.EventHandler(this.lançamentoDetalheToolStripMenuItem_Click);
            // 
            // lançamentoDetalheToolStripMenuItem1
            // 
            this.lançamentoDetalheToolStripMenuItem1.Name = "lançamentoDetalheToolStripMenuItem1";
            this.lançamentoDetalheToolStripMenuItem1.Size = new System.Drawing.Size(230, 22);
            this.lançamentoDetalheToolStripMenuItem1.Text = "Lançamento detalhe";
            this.lançamentoDetalheToolStripMenuItem1.Click += new System.EventHandler(this.lançamentoDetalheToolStripMenuItem1_Click);
            // 
            // lançamentoDetalhePorPessoaToolStripMenuItem
            // 
            this.lançamentoDetalhePorPessoaToolStripMenuItem.Name = "lançamentoDetalhePorPessoaToolStripMenuItem";
            this.lançamentoDetalhePorPessoaToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.lançamentoDetalhePorPessoaToolStripMenuItem.Text = "Lançamento detalhe (Pessoa)";
            this.lançamentoDetalhePorPessoaToolStripMenuItem.Click += new System.EventHandler(this.lançamentoDetalhePorPessoaToolStripMenuItem_Click);
            // 
            // simularToolStripMenuItem
            // 
            this.simularToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simulaçãoComPlantãoToolStripMenuItem,
            this.simularMêsToolStripMenuItem});
            this.simularToolStripMenuItem.Name = "simularToolStripMenuItem";
            this.simularToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.simularToolStripMenuItem.Text = "Simular";
            // 
            // simulaçãoComPlantãoToolStripMenuItem
            // 
            this.simulaçãoComPlantãoToolStripMenuItem.Name = "simulaçãoComPlantãoToolStripMenuItem";
            this.simulaçãoComPlantãoToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.simulaçãoComPlantãoToolStripMenuItem.Text = "Simular planilha plantonistas";
            this.simulaçãoComPlantãoToolStripMenuItem.Click += new System.EventHandler(this.simulaçãoComPlantãoToolStripMenuItem_Click);
            // 
            // simularMêsToolStripMenuItem
            // 
            this.simularMêsToolStripMenuItem.Name = "simularMêsToolStripMenuItem";
            this.simularMêsToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.simularMêsToolStripMenuItem.Text = "Simular mês";
            // 
            // ferramentasToolStripMenuItem
            // 
            this.ferramentasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calcularPeríodosToolStripMenuItem});
            this.ferramentasToolStripMenuItem.Name = "ferramentasToolStripMenuItem";
            this.ferramentasToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.ferramentasToolStripMenuItem.Text = "Ferramentas";
            // 
            // calcularPeríodosToolStripMenuItem
            // 
            this.calcularPeríodosToolStripMenuItem.Name = "calcularPeríodosToolStripMenuItem";
            this.calcularPeríodosToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.calcularPeríodosToolStripMenuItem.Text = "Calcular períodos";
            this.calcularPeríodosToolStripMenuItem.Click += new System.EventHandler(this.calcularPeríodosToolStripMenuItem_Click);
            // 
            // gerarToolStripMenuItem
            // 
            this.gerarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.réguaToolStripMenuItem,
            this.planilhaDeFechamentoToolStripMenuItem,
            this.horasToolStripMenuItem1});
            this.gerarToolStripMenuItem.Name = "gerarToolStripMenuItem";
            this.gerarToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.gerarToolStripMenuItem.Text = "Gerar";
            // 
            // réguaToolStripMenuItem
            // 
            this.réguaToolStripMenuItem.Name = "réguaToolStripMenuItem";
            this.réguaToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.réguaToolStripMenuItem.Text = "Planilha geral";
            this.réguaToolStripMenuItem.Click += new System.EventHandler(this.réguaToolStripMenuItem_Click);
            // 
            // planilhaDeFechamentoToolStripMenuItem
            // 
            this.planilhaDeFechamentoToolStripMenuItem.Name = "planilhaDeFechamentoToolStripMenuItem";
            this.planilhaDeFechamentoToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.planilhaDeFechamentoToolStripMenuItem.Text = "Planilha de fechamento";
            // 
            // horasToolStripMenuItem1
            // 
            this.horasToolStripMenuItem1.Name = "horasToolStripMenuItem1";
            this.horasToolStripMenuItem1.Size = new System.Drawing.Size(199, 22);
            this.horasToolStripMenuItem1.Text = "Horas";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(832, 431);
            this.panel1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 470);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Validar horas";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simularToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ferramentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fecharToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lançamentoGeralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lançamentoDetalheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lançamentoDetalheToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem lançamentoDetalhePorPessoaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumoGeralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulaçãoComPlantãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simularMêsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calcularPeríodosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem réguaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planilhaDeFechamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem feriadoToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem horasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem opçõesToolStripMenuItem;
    }
}

