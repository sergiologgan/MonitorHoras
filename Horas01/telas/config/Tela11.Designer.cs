
namespace Horas01.telas.config
{
    partial class Tela11
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
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.btnadd = new System.Windows.Forms.Button();
            this.listbox = new System.Windows.Forms.ListBox();
            this.btnremoe = new System.Windows.Forms.Button();
            this.btnok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // calendar
            // 
            this.calendar.Location = new System.Drawing.Point(9, 9);
            this.calendar.Name = "calendar";
            this.calendar.TabIndex = 0;
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(238, 9);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(75, 23);
            this.btnadd.TabIndex = 1;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // listbox
            // 
            this.listbox.FormattingEnabled = true;
            this.listbox.Location = new System.Drawing.Point(316, 9);
            this.listbox.Name = "listbox";
            this.listbox.Size = new System.Drawing.Size(158, 173);
            this.listbox.TabIndex = 2;
            // 
            // btnremoe
            // 
            this.btnremoe.Location = new System.Drawing.Point(238, 38);
            this.btnremoe.Name = "btnremoe";
            this.btnremoe.Size = new System.Drawing.Size(75, 23);
            this.btnremoe.TabIndex = 3;
            this.btnremoe.Text = "Remover";
            this.btnremoe.UseVisualStyleBackColor = true;
            this.btnremoe.Click += new System.EventHandler(this.btnremoe_Click);
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(399, 188);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(75, 23);
            this.btnok.TabIndex = 4;
            this.btnok.Text = "Ok";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // Tela11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.btnremoe);
            this.Controls.Add(this.listbox);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.calendar);
            this.Name = "Tela11";
            this.Size = new System.Drawing.Size(485, 220);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.ListBox listbox;
        private System.Windows.Forms.Button btnremoe;
        private System.Windows.Forms.Button btnok;
    }
}
