
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VentasForms;
using VentasForms.Util;
using VentasModel.Entities;
using VentasService;
using VentasService.Services;

namespace Forms
{
    public partial class FrmInicio : Form
    {
        private UserControl activeForm = null;
        private UserControl activeParent = null;
        private static FrmInicio _obj;
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        public FrmInicio()
        {
            InitializeComponent();
            //hideSubMenu(panelMenuBoton);
        }
        public static FrmInicio Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new FrmInicio();
                }
                return _obj;
            }
        }
        public Panel PnlContainer
        {
            get { return panelChildForm; }
            set { panelChildForm = value; }
        }

        public Button BackButton
        {
            get { return btnBack; }
            set { btnBack = value;}
        }
        public async void cargarMenu(IList<VentasModel.Entities.Menu> menus, Panel panelbase)
        {

            foreach (var menu in menus)
            {
                var boton = Utilidades.botonMenu(menu);

                var submenus = await MenuService.getInstancia().GetMenuUsuario(menu.Id, Global.vg_token);
                if (submenus.Data.Count > 0)
                {
                    boton.Click += new System.EventHandler(this.btn_Click);
                    var panelsubmenu = Utilidades.panelSubMenu(submenus.Data.Count() * boton.Height, "panel" + menu.Id);
                    panelsubmenu.Visible = false;
                    panelbase.Controls.Add(panelsubmenu);
                    cargarMenu(submenus.Data, panelsubmenu);
                }
                else
                {
                    boton.Click += new System.EventHandler(this.btnAction_Click);
                }
                panelbase.Controls.Add(boton);

            }
        }
        private UserControl usrControl(PaginaDto control)
        {
            UserControl extForm = null;
            try
            {
                System.Reflection.Assembly extAssembly = System.Reflection.Assembly.LoadFrom(control.Url);
                extForm = ((UserControl)extAssembly.CreateInstance(control.Proyecto + "." + control.Nombre, true));
                extForm.Name = "UCLista";
            }
            catch (Exception e)
            {
                return null;
            }

            return extForm;
        }
        
        private void closeChildForm(UserControl data)
        {
            if (FrmInicio.Instance.PnlContainer.Controls.ContainsKey(data.Tag.ToString()))
            {
                //FrmInicio.Instance.PnlContainer.Controls.Remove(data);
                FrmInicio.Instance.PnlContainer.Controls.RemoveByKey("UCLista");
            }
        }
        public void openChildForm(UserControl childForm, UserControl parentForm, bool muestraRegreso = false)
        {
            if (childForm != null)
            {

                if (!FrmInicio.Instance.PnlContainer.Controls.ContainsKey(childForm.Tag.ToString()))
                {
                    childForm.Dock = DockStyle.Fill;
                    FrmInicio.Instance.PnlContainer.Controls.Add(childForm);
                }
                if(FrmInicio.Instance.PnlContainer.Controls.Contains(childForm))
                    childForm.BringToFront();
                //FrmInicio.Instance.PnlContainer.Controls[childForm.Tag.ToString()].BringToFront();
                FrmInicio.Instance.BackButton.Visible = muestraRegreso;
                if (muestraRegreso && parentForm != null)
                {
                    activeParent = parentForm;
                }
                activeForm = childForm;
            }

        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.flowLayoutPanel1.ClientRectangle, Color.Silver, ButtonBorderStyle.Dashed);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            btnBack.Visible = false;
            lblNombre.Visible = false;
            _obj = this;
            //UCMarca uc = new UCMarca();
            //openChildForm(uc, null);
        }


        private void hideSubMenu(Panel c)
        {
            var components = c.Controls;
            foreach (Control component in components)
            {
                if (component is Panel)
                {
                    if (component.Tag==null) 
                        continue;

                    if (component.Tag.Equals("submenu"))
                    ((Panel)component).Visible = false;
                }
            }
        }

        private void showSubMenu(string subMenu)
        {
            var components = panelMenuBoton.Controls;
            foreach (Control component in components)
            {
                if (component is Panel)
                {
                    if (((Panel)component).Name.Equals(subMenu))
                    {
                        if (((Panel)component).Visible == false)
                        {
                            hideSubMenu(panelMenuBoton);
                            ((Panel)component).Visible = true;
                        }
                        else
                            ((Panel)component).Visible = false;
                    }
                }

            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                if (activeParent != null)
                {
                    openChildForm(activeParent, null);
                }
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            var boton = (Button)sender;
            showSubMenu(boton.Tag.ToString());

        }
        private async void btnAction_Click(object sender, EventArgs e)
        {
            var boton = (Button)sender;
            var pagina = await PaginaService.getInstancia().GetPagina(Convert.ToInt32(boton.AccessibleName), Global.vg_token);
            if (pagina != null && pagina.ErrorCode == 200)
            {
                var vistaBusqueda = new UCLista(usrControl(pagina), this, pagina.Nombre, "Table");
                closeChildForm(vistaBusqueda);
                openChildForm(vistaBusqueda, null);
                this.lblFormulario.Text = pagina.Titulo;
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

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void panel7_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void panel7_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void FrmInicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
