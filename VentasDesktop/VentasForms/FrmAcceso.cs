using Forms;
using VentasForms.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentasService.Services;
using VentasService;
using VentasModel.Entities;

namespace VentasForms
{
    public partial class FrmAcceso : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private static readonly UsuarioService repositorio = UsuarioService.getInstancia();
        public FrmAcceso()
        {
            InitializeComponent();
        }

        private void textBoxElement1_TextChanged(object sender, EventArgs e)
        {
            //Utilidades.validarCampo(panelBase, this);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            txtCuenta.Focus();
        }

        private void separator1_Click(object sender, EventArgs e)
        {
            txtCuenta.Focus();
        }

        private async void btnSiguiente_Click(object sender, EventArgs e)
        {
            btnSiguiente.Enabled = false;
            var access = await login();
            if (access && !string.IsNullOrEmpty(Global.vg_usuario))
            {
                var menus = await MenuService.getInstancia().GetMenuUsuario(null, Global.vg_token);
                
                FrmInicio.Instance.cargarMenu(menus.Data, FrmInicio.Instance.panelMenuBoton);
                FrmInicio.Instance.panelMenuBoton.Visible = true;
                FrmInicio.Instance.Show();
                

                this.Hide();
                //FrmInicio.Instance.panelChildForm.Controls.Remove(this);
            }
            btnSiguiente.Enabled = true;
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtContrasenia.PasswordChar.ToString().Equals("*"))
            {
                txtContrasenia.PasswordChar = '\0';
            }
            else 
            {
                txtContrasenia.PasswordChar = '*';   
            }
        }

        private async Task<bool> login()
        {

            if (Utilidades.validarCampo(panelBase, txtCuenta) && Utilidades.validarCampo(panelBase, txtContrasenia))
            {
                var usuario = await getUsuario(txtCuenta.Text, txtContrasenia.Text);
                if (usuario.ErrorCode == 200) 
                {
                    if (usuario == null || usuario.Username is null)
                    {
                        MessageBox.Show("*#* Cuenta o contraseña incorrecta!", Global.vg_msg_sys, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else
                    {
                        Global.vg_usuario = usuario.Username;
                        Global.vg_token = usuario.Token;
                        Global.vg_nombre_usuario = usuario.FirstName + " " + usuario.LastName;
                        return true;
                    }
                }
                if (usuario.ErrorCode > 200)
                {
                    var errors = usuario.Errors;
                    var sb = new StringBuilder();
                    foreach (var error in errors) 
                    {
                        sb.Append(error.Description +"\n");
                    }
                    MessageBox.Show("*#* "+sb.ToString(), Global.vg_msg_sys, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            return false;
        }
        private async Task<UsuarioDto> getUsuario(string login, string password)
        {
            //password = Utilidades.EncriptarClaveUsuario(password);
            return await repositorio.Login(username: login, password: password);

        }

        private void txtContrasenia_TextChanged(object sender, EventArgs e)
        {
            Utilidades.validarCampo(panelBase, txtContrasenia);
           
        }

        private void txtCuenta_MouseLeave(object sender, EventArgs e)
        {
            //Utilidades.validarCampo(panelBase, txtCuenta);
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

        private void panelBase_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void panelBase_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void panelBase_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
