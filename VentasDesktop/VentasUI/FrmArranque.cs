
using System;
using System.Windows.Forms;
using VentasForms;

namespace VentasUI
{
    public partial class FrmArranque : Form
    {
        public FrmArranque()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 3;
            if (panel2.Width >= panel1.Width) 
            {
                timer1.Stop();
                FrmAcceso ui = new FrmAcceso();
                ui.Show();
                this.Hide();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmArranque_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
