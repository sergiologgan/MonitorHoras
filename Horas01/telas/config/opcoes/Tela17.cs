using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horas01.telas.config.opcoes
{
    public partial class Tela17 : UserControl
    {
        public Tela17()
        {
            InitializeComponent();
            carregarcores();
        }

        private void setarcor(ref object sender)
        {
            Label lbl = sender as Label;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                lbl.BackColor = colorDialog1.Color;
            }
            lbl.BackColor = lbl.BackColor;
        }

        private void carregarcores()
        {
            if (Util.ExisteArquivo("colors.json"))
            {
                LimiteHoraArgs c = JsonConvert.DeserializeObject<LimiteHoraArgs>(Util.LerTexto("colors.json"));
                lblcorcartaofalse.BackColor = c.CartaoFalse;
                lblcorpromotorafalse.BackColor = c.PromotoraFalse;
                lblcorstbcartaofalse.BackColor = c.STB_CartaoFalse;
                lblcorpromotorafalse.BackColor = c.STB_PromotoraFalse;
                lblcorcartaotrue.BackColor = c.CartaoTrue;
                lblcorpromotoratrue.BackColor = c.PromotoraTrue;
                lblcorstbcartaotrue.BackColor = c.STB_CartaoTrue;
                lblcorstbpromtoratrue.BackColor = c.STB_PromotoraTrue;
                lblcorp1false.BackColor = c.P1False;
                lblcorp2false.BackColor = c.P2False;
                lblcorp3false.BackColor = c.P3False;
                lblcorp4false.BackColor = c.P4False;
                lblcorp1true.BackColor = c.P1True;
                lblcorp2true.BackColor = c.P2True;
                lblcorp3true.BackColor = c.P3True;
                lblcorp4true.BackColor = c.P4True;
                maskedcartao.Text = c.HoraCartao;
                maskedpromotora.Text = c.HoraPromotora;
                maskedstbcartao.Text = c.HoraSTBCartao;
                maskedstbpromotora.Text = c.HoraSTBPromotora;
                maskedp1.Text = c.HoraP1;
                maskedp2.Text = c.HoraP2;
                maskedp3.Text = c.HoraP3;
                maskedp4.Text = c.HoraP4;
            }
        }

        public void restaurarcor()
        {
            lblcorcartaofalse.BackColor = Color.White;
            lblcorpromotorafalse.BackColor = Color.White;
            lblcorstbcartaofalse.BackColor = Color.White;
            lblcorpromotorafalse.BackColor = Color.White;
            lblcorcartaotrue.BackColor = Color.FromArgb(0, 149,255);
            lblcorpromotoratrue.BackColor = Color.FromArgb(0, 149, 255);
            lblcorstbcartaotrue.BackColor = Color.FromArgb(0, 149, 255);
            lblcorstbpromtoratrue.BackColor = Color.FromArgb(0, 149, 255);
            lblcorp1false.BackColor = Color.White;
            lblcorp2false.BackColor = Color.White;
            lblcorp3false.BackColor = Color.White;
            lblcorp4false.BackColor = Color.White;
            lblcorp1true.BackColor = Color.FromArgb(0, 149,255);
            lblcorp2true.BackColor = Color.FromArgb(0, 149,255);
            lblcorp3true.BackColor = Color.FromArgb(0, 149,255);
            lblcorp4true.BackColor = Color.FromArgb(0, 149, 255);
            maskedcartao.Text = "";
            maskedpromotora.Text = "";
            maskedstbcartao.Text = "";
            maskedstbpromotora.Text = "";
            maskedp1.Text = "";
            maskedp2.Text = "";
            maskedp3.Text = "";
            maskedp4.Text = "";
        }


        public void Salvar()
        {
            TimeSpan t = TimeSpan.Zero;
            LimiteHoraArgs c = new LimiteHoraArgs()
            {
                CartaoFalse = lblcorcartaofalse.BackColor,
                PromotoraFalse = lblcorpromotorafalse.BackColor,
                STB_CartaoFalse = lblcorstbcartaofalse.BackColor,
                STB_PromotoraFalse = lblcorpromotorafalse.BackColor,
                CartaoTrue = lblcorcartaotrue.BackColor,
                PromotoraTrue = lblcorpromotoratrue.BackColor,
                STB_CartaoTrue = lblcorstbcartaotrue.BackColor,
                STB_PromotoraTrue = lblcorstbpromtoratrue.BackColor,
                P1False = lblcorp1false.BackColor,
                P2False = lblcorp2false.BackColor,
                P3False = lblcorp3false.BackColor,
                P4False = lblcorp4false.BackColor,
                P1True = lblcorp1true.BackColor,
                P2True = lblcorp2true.BackColor,
                P3True = lblcorp3true.BackColor,
                P4True = lblcorp4true.BackColor,
                HoraP1 = maskedp1.Text,
                HoraP2 = maskedp2.Text,
                HoraP3 = maskedp3.Text,
                HoraP4 = maskedp4.Text,
                HoraCartao = maskedcartao.Text,
                HoraPromotora = maskedpromotora.Text,
                HoraSTBCartao = maskedstbcartao.Text,
                HoraSTBPromotora = maskedstbpromotora.Text,
            };
            Util.LimiteHoraArgs = c;
        Util.GravarObjetosJson(c, "colors.json");
        }

        #region true
        private void lblcorstbcartaotrue_Click(object sender, EventArgs e)
        {
            setarcor(ref sender);
        }

        private void lblcorstbpromtoratrue_Click(object sender, EventArgs e)
        {
            setarcor(ref sender);
        }

        private void lblcorcartaotrue_Click(object sender, EventArgs e)
        {
            setarcor(ref sender);
        }

        private void lblcorpromotoratrue_Click(object sender, EventArgs e)
        {
            setarcor(ref sender);
        }

        private void lblcorp4true_Click(object sender, EventArgs e)
        {
            setarcor(ref sender);
        }

        private void lblcorp3true_Click(object sender, EventArgs e)
        {
            setarcor(ref sender);
        }

        private void lblcorp2true_Click(object sender, EventArgs e)
        {
            setarcor(ref sender);
        }

        private void lblcorp1true_Click(object sender, EventArgs e)
        {
            setarcor(ref sender);
        }
        #endregion

        #region false
        private void lblcorstbcartaofalse_Click(object sender, EventArgs e)
        {
            setarcor(ref sender);
        }

        private void lblcorstbpromotorafalse_Click(object sender, EventArgs e)
        {
            setarcor(ref sender);
        }

        private void lblcorcartaofalse_Click(object sender, EventArgs e)
        {
            setarcor(ref sender);
        }

        private void lblcorpromotorafalse_Click(object sender, EventArgs e)
        {
            setarcor(ref sender);
        }

        private void lblcorp4false_Click(object sender, EventArgs e)
        {
            setarcor(ref sender);
        }

        private void lblcorp3false_Click(object sender, EventArgs e)
        {
            setarcor(ref sender);
        }

        private void lblcorp2false_Click(object sender, EventArgs e)
        {
            setarcor(ref sender);
        }

        private void lblcorp1false_Click(object sender, EventArgs e)
        {
            setarcor(ref sender);
        }

        #endregion

        private void btnrestore_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja restaurar?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                restaurarcor();
            }
            
        }
    }
}
