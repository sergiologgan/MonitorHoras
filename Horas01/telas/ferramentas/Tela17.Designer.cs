
namespace Horas01.telas.ferramentas
{
    partial class Tela17
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
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btncalcularsimples = new System.Windows.Forms.Button();
            this.chkferiado = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.inicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feriado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.resultado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btncalcularmassa = new System.Windows.Forms.Button();
            this.btnok = new System.Windows.Forms.Button();
            this.lblperiodo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(6, 54);
            this.maskedTextBox1.Mask = "00/00/0000 90:00";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(140, 20);
            this.maskedTextBox1.TabIndex = 0;
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblperiodo);
            this.groupBox1.Controls.Add(this.btncalcularsimples);
            this.groupBox1.Controls.Add(this.chkferiado);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.maskedTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 108);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calcula período";
            // 
            // btncalcularsimples
            // 
            this.btncalcularsimples.Location = new System.Drawing.Point(219, 76);
            this.btncalcularsimples.Name = "btncalcularsimples";
            this.btncalcularsimples.Size = new System.Drawing.Size(75, 23);
            this.btncalcularsimples.TabIndex = 4;
            this.btncalcularsimples.Text = "Calcular";
            this.btncalcularsimples.UseVisualStyleBackColor = true;
            this.btncalcularsimples.Click += new System.EventHandler(this.btncalcularsimples_Click);
            // 
            // chkferiado
            // 
            this.chkferiado.AutoSize = true;
            this.chkferiado.Location = new System.Drawing.Point(6, 80);
            this.chkferiado.Name = "chkferiado";
            this.chkferiado.Size = new System.Drawing.Size(77, 17);
            this.chkferiado.TabIndex = 2;
            this.chkferiado.Text = "É Feriado?";
            this.chkferiado.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Insira a data";
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.inicio,
            this.feriado,
            this.resultado});
            this.grid.Location = new System.Drawing.Point(0, 29);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(387, 306);
            this.grid.TabIndex = 2;
            // 
            // inicio
            // 
            this.inicio.HeaderText = "Inicio";
            this.inicio.Name = "inicio";
            // 
            // feriado
            // 
            this.feriado.HeaderText = "E_Feriado";
            this.feriado.Name = "feriado";
            // 
            // resultado
            // 
            this.resultado.HeaderText = "Resultado";
            this.resultado.Name = "resultado";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btncalcularmassa);
            this.groupBox2.Controls.Add(this.grid);
            this.groupBox2.Location = new System.Drawing.Point(3, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(394, 365);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Calcular períodos das datas em massa";
            // 
            // btncalcularmassa
            // 
            this.btncalcularmassa.Location = new System.Drawing.Point(0, 336);
            this.btncalcularmassa.Name = "btncalcularmassa";
            this.btncalcularmassa.Size = new System.Drawing.Size(75, 23);
            this.btncalcularmassa.TabIndex = 3;
            this.btncalcularmassa.Text = "Calcular";
            this.btncalcularmassa.UseVisualStyleBackColor = true;
            this.btncalcularmassa.Click += new System.EventHandler(this.btncalcularmassa_Click);
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(322, 488);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(75, 23);
            this.btnok.TabIndex = 4;
            this.btnok.Text = "Ok";
            this.btnok.UseVisualStyleBackColor = true;
            // 
            // lblperiodo
            // 
            this.lblperiodo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblperiodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblperiodo.Location = new System.Drawing.Point(219, 27);
            this.lblperiodo.Name = "lblperiodo";
            this.lblperiodo.Size = new System.Drawing.Size(75, 47);
            this.lblperiodo.TabIndex = 5;
            this.lblperiodo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Tela17
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Tela17";
            this.Size = new System.Drawing.Size(408, 515);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkferiado;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn inicio;
        private System.Windows.Forms.DataGridViewCheckBoxColumn feriado;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultado;
        private System.Windows.Forms.Button btncalcularsimples;
        private System.Windows.Forms.Button btncalcularmassa;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.Label lblperiodo;
    }
}
