
namespace Horas01.telas.gerar
{
    partial class Tela12
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

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.grid = new System.Windows.Forms.DataGridView();
            this.empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jornada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ae = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.si = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totald = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnok = new System.Windows.Forms.Button();
            this.pindividual = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.empresa,
            this.nome,
            this.data,
            this.jornada,
            this.ae,
            this.aa,
            this.si,
            this.sa,
            this.p3,
            this.p1,
            this.p2,
            this.p4,
            this.ro,
            this.obs,
            this.total,
            this.totald});
            this.grid.Location = new System.Drawing.Point(3, 32);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(874, 440);
            this.grid.TabIndex = 0;
            // 
            // empresa
            // 
            this.empresa.HeaderText = "Empresa";
            this.empresa.Name = "empresa";
            // 
            // nome
            // 
            this.nome.HeaderText = "Nome";
            this.nome.Name = "nome";
            // 
            // data
            // 
            this.data.HeaderText = "Data";
            this.data.Name = "data";
            // 
            // jornada
            // 
            this.jornada.HeaderText = "Jornada";
            this.jornada.Name = "jornada";
            // 
            // ae
            // 
            this.ae.HeaderText = "Atraso_Entrada";
            this.ae.Name = "ae";
            // 
            // aa
            // 
            this.aa.HeaderText = "Atraso_Almoço";
            this.aa.Name = "aa";
            // 
            // si
            // 
            this.si.HeaderText = "SaidaIntermediaria";
            this.si.Name = "si";
            // 
            // sa
            // 
            this.sa.HeaderText = "SaidaAntecipada";
            this.sa.Name = "sa";
            // 
            // p3
            // 
            this.p3.HeaderText = "P3";
            this.p3.Name = "p3";
            // 
            // p1
            // 
            this.p1.HeaderText = "P1";
            this.p1.Name = "p1";
            // 
            // p2
            // 
            this.p2.HeaderText = "P2";
            this.p2.Name = "p2";
            // 
            // p4
            // 
            this.p4.HeaderText = "P4";
            this.p4.Name = "p4";
            // 
            // ro
            // 
            this.ro.HeaderText = "RO";
            this.ro.Name = "ro";
            // 
            // obs
            // 
            this.obs.HeaderText = "Observacao";
            this.obs.Name = "obs";
            // 
            // total
            // 
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            // 
            // totald
            // 
            this.totald.HeaderText = "TotalDebitos";
            this.totald.Name = "totald";
            // 
            // btnok
            // 
            this.btnok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnok.Location = new System.Drawing.Point(3, 478);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(75, 23);
            this.btnok.TabIndex = 1;
            this.btnok.Text = "Ok";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // pindividual
            // 
            this.pindividual.Location = new System.Drawing.Point(3, 3);
            this.pindividual.Name = "pindividual";
            this.pindividual.Size = new System.Drawing.Size(129, 23);
            this.pindividual.TabIndex = 2;
            this.pindividual.Text = "Ver planilha individual";
            this.pindividual.UseVisualStyleBackColor = true;
            this.pindividual.Click += new System.EventHandler(this.pindividual_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(138, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Ver planilha geral";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Tela12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pindividual);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.grid);
            this.Name = "Tela12";
            this.Size = new System.Drawing.Size(880, 515);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn data;
        private System.Windows.Forms.DataGridViewTextBoxColumn jornada;
        private System.Windows.Forms.DataGridViewTextBoxColumn ae;
        private System.Windows.Forms.DataGridViewTextBoxColumn aa;
        private System.Windows.Forms.DataGridViewTextBoxColumn si;
        private System.Windows.Forms.DataGridViewTextBoxColumn sa;
        private System.Windows.Forms.DataGridViewTextBoxColumn p3;
        private System.Windows.Forms.DataGridViewTextBoxColumn p1;
        private System.Windows.Forms.DataGridViewTextBoxColumn p2;
        private System.Windows.Forms.DataGridViewTextBoxColumn p4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ro;
        private System.Windows.Forms.DataGridViewTextBoxColumn obs;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn totald;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.Button pindividual;
        private System.Windows.Forms.Button button1;
    }
}
