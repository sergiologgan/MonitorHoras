using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horas01.telas.config
{
    public partial class Tela10 : UserControl
    {
        private Dictionary<Tipo, List<HorasArgs>> dichoras;
        public Tela10()
        {
            InitializeComponent();
            carregargrids();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (!isOkWithMsg()) return;
            MesFechamento m = new MesFechamento();
            m.ShowDialog();


            foreach (Tipo t in dichoras.Keys)
            {
                List<HorasArgs> hs = dichoras[t];
                switch (t)
                {
                    case Tipo.PROMOTORA:
                        for (int i = 0; i < hs.Count; i++)
                        {
                            HorasArgs h = hs[i];
                            h.Requisicao = txtpromotora.Text.Trim();
                            h.Tipo = t;
                        }
                        break;
                    case Tipo.CARTAO:
                        for (int i = 0; i < hs.Count; i++)
                        {
                            HorasArgs h = hs[i];
                            h.Requisicao = txtcartao.Text.Trim();
                            h.Tipo = t;
                        }
                        break;
                    case Tipo.STB_PROMOTORA:
                        for (int i = 0; i < hs.Count; i++)
                        {
                            HorasArgs h = hs[i];
                            h.Requisicao = txtpromotorastb.Text.Trim();
                            h.Tipo = t;
                        }
                        break;
                    case Tipo.STB_CARTAO:
                        for (int i = 0; i < hs.Count; i++)
                        {
                            HorasArgs h = hs[i];
                            h.Requisicao = txtcartaostb.Text.Trim();
                            h.Tipo = t;
                        }
                        break;
                    default:
                        break;
                }
                
            }

            Util.SetHoras(dichoras);
            salvar();
            this.Hide();
        }

        private void dgvpromotora_KeyDown(object sender, KeyEventArgs e)
        {
            populargrid(ref dgvpromotora, Tipo.PROMOTORA, e);
        }

        private void dgvcartao_KeyDown(object sender, KeyEventArgs e)
        {
            populargrid(ref dgvcartao, Tipo.CARTAO, e);
        }

        private void dgvpromotorastb_KeyDown(object sender, KeyEventArgs e)
        {
            populargrid(ref dgvpromotorastb, Tipo.STB_PROMOTORA, e);
        }

        private void dgvcartaostb_KeyDown(object sender, KeyEventArgs e)
        {
            populargrid(ref dgvcartaostb, Tipo.STB_CARTAO, e);
        }

        private void btnlimparpromotora_Click(object sender, EventArgs e)
        {
            dgvpromotora.Rows.Clear();
            dichoras[Tipo.PROMOTORA].Clear();
        }

        private void btnlimparcartao_Click(object sender, EventArgs e)
        {
            dgvcartao.Rows.Clear();
            dichoras[Tipo.CARTAO].Clear();
        }

        private void btnlimparpromotorastb_Click(object sender, EventArgs e)
        {
            dgvpromotorastb.Rows.Clear();
            dichoras[Tipo.STB_PROMOTORA].Clear();
        }

        private void btnlimparcartaostb_Click(object sender, EventArgs e)
        {
            dgvcartaostb.Rows.Clear();
            dichoras[Tipo.STB_CARTAO].Clear();
        }

        private bool isOkWithMsg()
        {
            if (dgvpromotora.RowCount > 0 && string.IsNullOrEmpty(txtpromotora.Text))
            {
                MessageBox.Show("Coloque um número de RS para promotora");
                return false;
            }
            else if (dgvpromotora.RowCount <= 0 && !string.IsNullOrEmpty(txtpromotora.Text))
            {
                MessageBox.Show("Cole os lançamentos de promotora");
                return false;
            }

            if (dgvcartao.RowCount > 0 && string.IsNullOrEmpty(txtcartao.Text))
            {
                MessageBox.Show("Coloque um número de RS para cartão");
                return false;
            }
            else if (dgvcartao.RowCount <= 0 && !string.IsNullOrEmpty(txtcartao.Text))
            {
                MessageBox.Show("Cole os lançamentos de cartão");
                return false;
            }

            if (dgvpromotorastb.RowCount > 0 && string.IsNullOrEmpty(txtpromotorastb.Text))
            {
                MessageBox.Show("Coloque um número de RS para stb promotora");
                return false;
            }
            else if (dgvpromotorastb.RowCount <= 0 && !string.IsNullOrEmpty(txtpromotorastb.Text))
            {
                MessageBox.Show("Cole os lançamentos de stb promotora");
                return false;
            }

            if (dgvcartaostb.RowCount > 0 && string.IsNullOrEmpty(txtcartaostb.Text))
            {
                MessageBox.Show("Coloque um número de RS para stb cartão");
                return false;
            }
            else if (dgvcartaostb.RowCount <= 0 && !string.IsNullOrEmpty(txtcartaostb.Text))
            {
                MessageBox.Show("Cole os lançamentos de stb cartão");
                return false;
            }
            return true;
        }

        private bool isOkNoMsg()
        {
            return !(dgvpromotora.RowCount > 0 && string.IsNullOrEmpty(txtpromotora.Text)) ||
                    ((dgvpromotora.RowCount <= 0 && !string.IsNullOrEmpty(txtpromotora.Text)) ||
                    (dgvcartao.RowCount > 0 && string.IsNullOrEmpty(txtcartao.Text)) ||
                    (dgvcartao.RowCount <= 0 && !string.IsNullOrEmpty(txtcartao.Text)) ||
                    (dgvpromotorastb.RowCount > 0 && string.IsNullOrEmpty(txtpromotorastb.Text)) ||
                    (dgvpromotorastb.RowCount <= 0 && !string.IsNullOrEmpty(txtpromotorastb.Text)) ||
                    (dgvcartaostb.RowCount > 0 && string.IsNullOrEmpty(txtcartaostb.Text)) ||
                    (dgvcartaostb.RowCount <= 0 && !string.IsNullOrEmpty(txtcartaostb.Text)));


        }

        private void populargrid(ref DataGridView grid, Tipo tipo, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyCode == Keys.V && !string.IsNullOrEmpty(Clipboard.GetText()))
                {
                    string text = Clipboard.GetText().Replace("\t", "%").Replace("\r\n", "%");
                    string[] cols = text.Split('%').Where(x => !string.IsNullOrEmpty(x)).ToArray();

                    for (int i = 0; i < cols.Length; i += 4)
                    {
                        DateTime d = DateTime.Parse(cols[i + 1]);
                        Periodo p = Util.ObterPeriodo(d);
                        string semana = Util.ObterNomeSemana(d);
                        if (grid.ColumnCount <= 0)
                        {
                            adicionarcolunas(ref grid);
                        }
                        dichoras[tipo].Add(new HorasArgs()
                        {
                            Inicio = d,
                            Fim = DateTime.Parse(cols[i + 2]),
                            Total = TimeSpan.Parse(cols[i + 3]),
                            Nome = cols[i],
                            Tipo = tipo,
                            Periodo = p,
                            Semana = semana,
                            P1 = (p == Periodo.P1) ? TimeSpan.Parse(cols[i + 3]) : TimeSpan.Zero,
                            P2 = (p == Periodo.P2) ? TimeSpan.Parse(cols[i + 3]) : TimeSpan.Zero,
                            P3 = (p == Periodo.P3) ? TimeSpan.Parse(cols[i + 3]) : TimeSpan.Zero,
                            P4 = (p == Periodo.P4) ? TimeSpan.Parse(cols[i + 3]) : TimeSpan.Zero,
                        });
                        grid.Rows.Add(cols[i], cols[i + 1], cols[i + 2], cols[i + 3], semana, p);
                    }
                }
            }
            catch (Exception er)
            {
                Log_Erro.GravarErro(er.Message);
            }
        }

        private void adicionarcolunas(ref DataGridView dgv)
        {
            dgv.Columns.AddRange(new DataGridViewTextBoxColumn[6]
            {
                new DataGridViewTextBoxColumn(){ HeaderText = "Nome" },
                new DataGridViewTextBoxColumn(){ HeaderText = "Inicio" },
                new DataGridViewTextBoxColumn(){ HeaderText = "Fim" },
                new DataGridViewTextBoxColumn(){ HeaderText = "Total" },
                new DataGridViewTextBoxColumn(){ HeaderText = "Semana" },
                new DataGridViewTextBoxColumn(){ HeaderText = "Periodo" },
            });
        }

        private void carregargrids()
        {
            try
            {
                var horas = Util.ObterHoras();
                if (horas != null)
                {
                    dichoras = horas;
                    this.txtpromotora.Text = dichoras[Tipo.PROMOTORA].Count > 0 ? dichoras[Tipo.PROMOTORA].FirstOrDefault().Requisicao : "";
                    this.txtpromotorastb.Text = dichoras[Tipo.STB_PROMOTORA].Count > 0 ? dichoras[Tipo.STB_PROMOTORA].FirstOrDefault().Requisicao : "";
                    this.txtcartao.Text = dichoras[Tipo.CARTAO].Count > 0 ? dichoras[Tipo.CARTAO].FirstOrDefault().Requisicao : "";
                    this.txtcartaostb.Text = dichoras[Tipo.STB_CARTAO].Count > 0 ? dichoras[Tipo.STB_CARTAO].FirstOrDefault().Requisicao : ""; 

                    List<HorasArgs> hs = new List<HorasArgs>();

                    foreach (Tipo t in dichoras.Keys)
                    {
                        hs = dichoras[t];
                        for (int i = 0; i < hs.Count; i++)
                        {
                            HorasArgs h = hs[i];
                            switch (t)
                            {
                                case Tipo.PROMOTORA:
                                    if (dgvpromotora.ColumnCount <= 0) adicionarcolunas(ref dgvpromotora);
                                    dgvpromotora.Rows.Add(h.Nome, h.Inicio, h.Fim, h.Total, h.Semana, h.Periodo);
                                    break;
                                case Tipo.CARTAO:
                                    if (dgvcartao.ColumnCount <= 0) adicionarcolunas(ref dgvcartao);
                                    dgvcartao.Rows.Add(h.Nome, h.Inicio, h.Fim, h.Total, h.Semana, h.Periodo);
                                    break;
                                case Tipo.STB_PROMOTORA:
                                    if (dgvpromotorastb.ColumnCount <= 0) adicionarcolunas(ref dgvpromotorastb);
                                    dgvpromotorastb.Rows.Add(h.Nome, h.Inicio, h.Fim, h.Total, h.Semana, h.Periodo);
                                    break;
                                case Tipo.STB_CARTAO:
                                    if (dgvcartaostb.ColumnCount <= 0) adicionarcolunas(ref dgvcartaostb);
                                    dgvcartaostb.Rows.Add(h.Nome, h.Inicio, h.Fim, h.Total, h.Semana, h.Periodo);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    this.dichoras = new Dictionary<Tipo, List<HorasArgs>>()
                    {
                        { Tipo.PROMOTORA, new List<HorasArgs>() },
                        { Tipo.CARTAO, new List<HorasArgs>() },
                        { Tipo.STB_CARTAO, new List<HorasArgs>() },
                        { Tipo.STB_PROMOTORA, new List<HorasArgs>() },
                    };
                }
                
            }
            catch (Exception er)
            {
                Log_Erro.GravarErro(er.Message);
            }
           
        }

        private void salvar()
        {
            if (isOkNoMsg())
            {
                File.WriteAllText("horas.txt", JsonConvert.SerializeObject(dichoras), Encoding.UTF8);
            }
        }

    }
}
