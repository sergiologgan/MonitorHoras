using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horas01.telas.simular
{
    public partial class Tela14 : UserControl
    {
        private List<string> datas;
        private List<InsereHorasArgs> inHorasArgs;

        public Tela14()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.grid.DoubleBuffered(true);
            this.numericUpDown1.Value = DateTime.Now.Year;
            this.comboBox1.Text = this.comboBox1.Items[DateTime.Now.Month - 1].ToString();
            datas = new List<string>();
        }

        #region gerar
        private InsereHorasArgs comparardata(DateTime date)
        {
            if (inHorasArgs != null)
            {
                for (int i = 0; i < inHorasArgs.Count; i++)
                {
                    DateTime d = inHorasArgs[i].Inicio;
                    if (d.Day == date.Day && d.Month == date.Month && d.Year == date.Year)
                    {
                        return inHorasArgs[i];
                    }
                }
            }
            return null;
        }

        private TimeSpan obtertempostand(TimeSpan horaativa, Periodo periodo, DayOfWeek week)
        {
            switch (periodo)
            {
                case Periodo.P1:
                    return new TimeSpan((TimeSpan.Parse("08:00:00") - horaativa).Ticks / 3);
                case Periodo.P2:
                    return new TimeSpan((TimeSpan.Parse("07:00:00") - horaativa).Ticks / 3);
                case Periodo.P3:
                    return new TimeSpan((TimeSpan.Parse("08:00:00") - horaativa).Ticks / 3);
                case Periodo.P4:
                    if (week == DayOfWeek.Monday)
                    {
                        return new TimeSpan((TimeSpan.Parse("08:00:00") - horaativa).Ticks / 3);
                    }
                    else if (week == DayOfWeek.Saturday)
                    {
                        return new TimeSpan((TimeSpan.Parse("16:00:00") - horaativa).Ticks / 3);
                    }
                    else if (week == DayOfWeek.Sunday)
                    {
                        return new TimeSpan((TimeSpan.Parse("24:00:00") - horaativa).Ticks / 3);
                    }
                    break;
                default:
                    return TimeSpan.Zero;
            }
            return TimeSpan.Zero;
        }

        private void calculartotal(DataGridViewRow row)
        {
            TimeSpan p1 = TimeSpan.Zero;
            TimeSpan p2 = TimeSpan.Zero;
            TimeSpan p3 = TimeSpan.Zero;
            TimeSpan p4 = TimeSpan.Zero;
            try { p1 = TimeSpan.Parse(row.Cells[3].Value?.ToString()); } catch { }
            try { p2 = TimeSpan.Parse(row.Cells[4].Value?.ToString()); } catch { }
            try { p3 = TimeSpan.Parse(row.Cells[5].Value?.ToString()); } catch { }
            try { p4 = TimeSpan.Parse(row.Cells[6].Value?.ToString()); } catch { }
            row.Cells[7].Value = Util.FormatarHoras(p1 + p2 + p3 + p4);
        }

        private void btngerarp1ativa_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow r in this.grid.Rows)
                {
                    r.Cells[3].Value = null;
                    DateTime d = DateTime.Parse(r.Cells[2].Value?.ToString());
                    r.Cells[0].Value = this.textBox1.Text;
                    if (d.DayOfWeek != DayOfWeek.Sunday && d.DayOfWeek != DayOfWeek.Saturday && !this.lbferiados.Items.Contains(d.ToString("dd/MM/yyyy")))
                    {
                        r.Cells[3].Value = "08:00:00";
                        calculartotal(r);
                    }
                }
            }
            catch { }
        }

        private void btngerarp2_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow r in this.grid.Rows)
                {
                    r.Cells[4].Value = null;
                    DateTime d = DateTime.Parse(r.Cells[2].Value?.ToString());
                    InsereHorasArgs h = comparardata(d);
                    bool isP2 = false;
                    if (h != null)
                        isP2 = Util.ObterPeriodo(h.Inicio) == Periodo.P2;
                    r.Cells[0].Value = this.textBox1.Text;
                    if (d.DayOfWeek != DayOfWeek.Sunday && d.DayOfWeek != DayOfWeek.Saturday && !this.lbferiados.Items.Contains(d.ToString("dd/MM/yyyy")))
                    {
                        if (h != null && isP2)
                        {
                            TimeSpan stand = obtertempostand(h.Total, Util.ObterPeriodo(h.Inicio), d.DayOfWeek);
                            r.Cells[4].Value = Util.FormatarHoras(stand + h.Total);
                        }
                        else
                            r.Cells[4].Value = "02:20:00";
                        calculartotal(r);
                    }
                }
            }
            catch { }
        }

        private void btngerarp3_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow r in this.grid.Rows)
                {
                    r.Cells[5].Value = null;
                    DateTime d = DateTime.Parse(r.Cells[2].Value?.ToString());
                    InsereHorasArgs h = comparardata(d);
                    bool isP3 = false;
                    if (h != null)
                        isP3 = Util.ObterPeriodo(h.Inicio) == Periodo.P3;
                    r.Cells[0].Value = this.textBox1.Text;
                    if (d.DayOfWeek != DayOfWeek.Sunday && d.DayOfWeek != DayOfWeek.Monday && !this.lbferiados.Items.Contains(d.ToString("dd/MM/yyyy")))
                    {
                        if (h != null && isP3)
                        {
                            TimeSpan stand = obtertempostand(h.Total, Util.ObterPeriodo(h.Inicio), d.DayOfWeek);
                            r.Cells[5].Value = Util.FormatarHoras(stand + h.Total);
                        }
                        else
                            r.Cells[5].Value = "02:40:00";
                        calculartotal(r);
                    }
                }
            }
            catch { }
        }

        private void btngerarp4_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow r in this.grid.Rows)
                {
                    r.Cells[6].Value = null;
                    DateTime d = DateTime.Parse(r.Cells[2].Value?.ToString());
                    InsereHorasArgs h = comparardata(d);
                    bool isP4 = false;
                    if (h != null)
                        isP4 = Util.ObterPeriodo(h.Inicio) == Periodo.P4;

                    r.Cells[0].Value = this.textBox1.Text;
                    if (d.DayOfWeek == DayOfWeek.Sunday || this.lbferiados.Items.Contains(d.ToString("dd/MM/yyyy")))
                    {
                        if (h != null && isP4)
                        {
                            TimeSpan stand = obtertempostand(h.Total, Util.ObterPeriodo(h.Inicio), d.DayOfWeek);
                            r.Cells[6].Value = Util.FormatarHoras(stand + h.Total);
                        }
                        else
                            r.Cells[6].Value = "08:00:00";
                        calculartotal(r);
                    }
                    else if (d.DayOfWeek == DayOfWeek.Saturday)
                    {
                        if (h != null && isP4)
                        {
                            TimeSpan stand = obtertempostand(h.Total, Util.ObterPeriodo(h.Inicio), d.DayOfWeek);
                            r.Cells[6].Value = Util.FormatarHoras(stand + h.Total);
                        }
                        else
                            r.Cells[6].Value = "05:20:00";
                        calculartotal(r);
                    }
                    else if (d.DayOfWeek == DayOfWeek.Monday)
                    {
                        if (h != null && isP4)
                        {
                            TimeSpan stand = obtertempostand(h.Total, Util.ObterPeriodo(h.Inicio), d.DayOfWeek);
                            r.Cells[6].Value = Util.FormatarHoras(stand + h.Total);
                        }
                        else
                            r.Cells[6].Value = "02:40:00";
                        calculartotal(r);
                    }
                }
            }
            catch { }
        }

        private void btngerarp1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow r in this.grid.Rows)
                {
                    r.Cells[3].Value = null;
                    DateTime d = DateTime.Parse(r.Cells[2].Value?.ToString());
                    InsereHorasArgs h = comparardata(d);
                    bool isP1 = false;
                    if (h != null)
                        isP1 = Util.ObterPeriodo(h.Inicio) == Periodo.P1;
                    r.Cells[0].Value = this.textBox1.Text;
                    if (d.DayOfWeek != DayOfWeek.Sunday && d.DayOfWeek != DayOfWeek.Saturday && !this.lbferiados.Items.Contains(d.ToString("dd/MM/yyyy")))
                    {
                       
                        if (h != null && isP1)
                        {
                            TimeSpan stand = obtertempostand(h.Total, Util.ObterPeriodo(h.Inicio), d.DayOfWeek);
                            r.Cells[6].Value = Util.FormatarHoras(stand + h.Total);
                        }
                        else
                            r.Cells[3].Value = "02:40:00";
                        calculartotal(r);
                    }
                }
            }
            catch { }
        }
        #endregion

        #region limpar

        private void btnlimpartudo_Click(object sender, EventArgs e)
        {
            limpargrid(3,4,5,6,7);
        }

        private void limpargrid(params int[] columns)
        {
            for (int i = 0; i < columns.Length; i++)
            {
                foreach (DataGridViewRow r in grid.Rows)
                {
                    r.Cells[columns[i]].Value = null;
                }
            }
        }
        #endregion

        #region alteracao
        private void atualizar()
        {
            List<int> draw = new List<int>();
            try
            {
                foreach (DataGridViewRow r in this.grid.Rows)
                {
                    DateTime d = DateTime.Parse(r.Cells[2].Value?.ToString());
                    r.Cells[0].Value = this.textBox1.Text;
                    bool f = this.lbferiados.Items.Contains(d.ToString("dd/MM/yyyy"));
                    if (d.DayOfWeek != DayOfWeek.Sunday && f)
                    {
                        draw.Add(r.Index);
                        r.Cells[1].Value = $"Feriado - {Util.ObterNomeSemanaResumido(d)}";
                        r.Cells[3].Value = "";
                        r.Cells[4].Value = "";
                        r.Cells[5].Value = "";
                        r.Cells[6].Value = "08:00:00";
                    }
                    else
                    {
                        r.Cells[1].Value = Util.ObterNomeSemanaResumido(d);
                    }
                }
            }
            catch { }
            finally
            {
                pintargrid(draw, Color.LightGreen, Color.Black);
                pintargriddiasespeciais();
            }
        }
        #endregion

        private void pintargrid(List<int> row, Color backcolor, Color forecolor)
        {
            for (int i = 0; i < row.Count; i++)
            {
                int n = row[i];
                for (int l = 0; l < this.grid.ColumnCount; l++)
                {
                    this.grid[l, n].Style.BackColor = backcolor;
                    this.grid[l, n].Style.ForeColor = forecolor;
                }
            }
        }

        private void pintargriddiasespeciais()
        {
            for (int i = 0; i < this.grid.RowCount; i++)
            {
                for (int l = 0; l < this.grid.ColumnCount; l++)
                {
                    var f = this.grid[1, i].Value?.ToString();
                    if (f is null) continue;
                    if (f.Contains("Feriado"))
                    {
                        this.grid[l, i].Style.BackColor = Color.LightGreen;
                        this.grid[l, i].Style.ForeColor = Color.Black;
                    }
                    else if (f.Contains("Domingo") || f.Contains("Sábado"))
                    {
                        this.grid[l, i].Style.BackColor = Color.LightPink;
                        this.grid[l, i].Style.ForeColor = Color.Black;
                    }
                    else
                    {
                        this.grid[l, i].Style.BackColor = Color.White;
                        this.grid[l, i].Style.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void btnatualizar_Click(object sender, EventArgs e)
        {
            atualizar();
        }

        private void btnaddferiado_Click(object sender, EventArgs e)
        {
            CalendarioForm c = null;
            if (datas.Count > 0) c = new CalendarioForm(datas);
            else c = new CalendarioForm();
            c.ShowDialog();
            if (c.Datas != null)
            {
                this.datas = c.Datas;
                this.lbferiados.Items.Clear();
                for (int i = 0; i < this.datas.Count; i++)
                {
                    this.lbferiados.Items.Add(this.datas[i]);
                }
            }
            atualizar();
        }

        private void btnremoveferiado_Click(object sender, EventArgs e)
        {
            try
            {
                object v = this.lbferiados.SelectedItem;
                if (this.lbferiados.Items.Contains(v))
                {
                    this.lbferiados.Items.Remove(v);
                    this.datas = this.lbferiados.Items.Cast<string>().ToList();
                }
            }
            catch { }
            finally
            {
                atualizar();
            }
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (DataGridViewTextBoxCell r in grid.SelectedCells)
                {
                    if (r.ColumnIndex != 0 && r.ColumnIndex != 1 && r.ColumnIndex != 2)
                    {
                        r.Value = "";
                    }
                }
            }
        }

        private void btninfomes_Click(object sender, EventArgs e)
        {
            try
            {
                this.grid.Rows.Clear();
                int mes = this.comboBox1.SelectedIndex + 1;
                int ano = (int)this.numericUpDown1.Value;

                for (int i = 1; i <= DateTime.DaysInMonth(ano, mes); i++)
                {
                    DateTime d = new DateTime(ano, mes, i, 0, 0, 0);
                    if (contemferiado(d))
                        this.grid.Rows.Add(this.textBox1.Text, $"Feriado - {Util.ObterNomeSemanaResumido(d)}", string.Format("{0:D2}/{1:D2}/{2:D2}", i, mes, ano));
                    else
                        this.grid.Rows.Add(this.textBox1.Text, Util.ObterNomeSemanaResumido(d), string.Format("{0:D2}/{1:D2}/{2:D2}", i, mes, ano));
                }
                pintargriddiasespeciais();
            }
            catch { }            
        }

        private bool contemferiado(DateTime d)
        {
            return lbferiados.Items.Contains(d.ToString("dd/MM/yyyy"));
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                for (int i = 0; i < this.grid.RowCount; i++)
                {
                    this.grid.Rows[i].Cells[0].Value = this.textBox1.Text;
                }
            }
        }

        private void btninsereplantao_Click(object sender, EventArgs e)
        {
            InserirPlantao i = new InserirPlantao();
            i.ShowDialog();
            inHorasArgs = i.Horas;
        }

        private void btngeratudo_Click(object sender, EventArgs e)
        {
            btngerarp2.PerformClick();
            btngerarp3.PerformClick();
            btngerarp4.PerformClick();
        }

        
    }
}
