using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentasForms.Util;

namespace VentasForms
{
    public partial class UCMarca : UserControl
    {
        //private static readonly MarcaService repositorio = MarcaService.getInstancia();
        public UCMarca()
        {
            InitializeComponent();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            txtCuenta.Focus();
        }
        
        private void UCMarca_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.flowLayoutPanel2.ClientRectangle, Color.Silver, ButtonBorderStyle.Dashed);
        }

        private void UCMarca_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Silver, ButtonBorderStyle.Dashed);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.flowLayoutPanel1.ClientRectangle, Color.Silver, ButtonBorderStyle.Dashed);
        }

        private async void btnSiguiente_Click(object sender, EventArgs e)
        {
            
        }

    

        private void txtContrasenia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtContrasenia.Text))
                {
                    if (string.IsNullOrEmpty(txtCuenta.Text))
                    {
                        txtCuenta.Focus();
                    }
                    else {
                        btnSiguiente.Focus();
                    }
                }
                else {
                    return;

                }
            }
        }

        private void lblPassword_Click(object sender, EventArgs e)
        {
            txtContrasenia.PasswordChar = '\0';
        }
        

        private void txtCuenta_TextChanged(object sender, EventArgs e)
        {
            Utilidades.validarCampo(panelBase, this);
        }

        private void btnSiguiente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                //login();
            }
        }

        private void txtContrasenia_TextChanged(object sender, EventArgs e)
        {
            Utilidades.validarCampo(panelBase, txtContrasenia);
        }

        private void txtCuenta_MouseLeave(object sender, EventArgs e)
        {
            Utilidades.validarCampo(panelBase, txtCuenta);
        }

        private void txtCuenta_Leave(object sender, EventArgs e)
        {
            Utilidades.validarCampo(panelBase, txtCuenta);
        }

        private void txtContrasenia_Leave(object sender, EventArgs e)
        {
            Utilidades.validarCampo(panelBase, txtContrasenia);
        }

        private void txtCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtCuenta.Text))
                {
                    if (string.IsNullOrEmpty(txtContrasenia.Text))
                    {
                        txtContrasenia.Focus();
                    }
                    else
                    {
                        btnSiguiente.Focus();
                    }
                }
                else
                {
                    return;

                }
            }
        }
    }
}
