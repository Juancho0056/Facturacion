using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VentasForms.Util;
using VentasModel.Entities;
using VentasService;
using VentasService.Services;

namespace VentasForms
{
    public partial class UCPagina: UserControl, BaseUC
    {
        private readonly PaginaService paginaService = PaginaService.getInstancia();
        private readonly string NombreFormulario = "Pagina";
        private PaginaDto dtoPagina;
        private FormMode mode = FormMode.EDITOR;
        
        public UCPagina()
        {
            InitializeComponent();
        }
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (mode == FormMode.READONLY) 
            {
                return;
            }
            PaginaDto result = PaginaDto.create();
            if (dtoPagina != null && dtoPagina.Id > 0)
            {
                var item = PaginaDto.create(Convert.ToInt32(txtCodigo.Text),
                    txtNombre.Text, txtTitulo.Text, txtProyecto.Text, txtUrl.Text, chbEstado.Checked);
                result = await paginaService.Update(item, Global.vg_token);
            }
            else 
            {
                var item = PaginaDto.create(0, txtNombre.Text, txtTitulo.Text, txtProyecto.Text, txtUrl.Text);
                result = await paginaService.GuardarPagina(item, Global.vg_token);
            }

            if (result != null && result.Errors != null && result.Errors.Count > 0) 
            {
                var error = (from dt in result.Errors
                             where dt.Field.ToLower().Equals(NombreFormulario.ToLower())
                             select dt).FirstOrDefault();
                if (error != null && error.Description != null && result.ErrorCode > 200)
                {
                    MessageBox.Show(error.Description, Global.vg_msg_sys, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (error != null && error.Description != null && result.ErrorCode ==  200)
                {
                    MessageBox.Show(error.Description, Global.vg_msg_sys, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Utilidades.validarCampos(this.panelBase, result.Errors);
            }
            if (result.ErrorCode == 200) 
            {
                dtoPagina = result;
                LlenarCampos(result, FormMode.EDITOR);
            }
        }
        private void ReadOnlyText(Panel panelBase, FormMode mode) 
        {
            foreach (Control component in panelBase.Controls)
            {
                
                if (component is TextBox)
                {
                    if(((TextBox)component).AccessibleDescription== null || 
                        !((TextBox)component).AccessibleDescription.ToString().Contains("block"))
                            ((TextBox)component).ReadOnly = mode.Equals(FormMode.EDITOR)? false:true;
                }
                if (component is Button)
                {
                    if(component.Tag != null && component.Tag.ToString().Contains("frm"))
                        ((Button)component).Enabled = mode.Equals(FormMode.EDITOR) ? true : false;
                }
                if (component is CheckBox)
                {
                    ((CheckBox)component).Enabled = mode.Equals(FormMode.EDITOR) ? true : false;
                }
                if (component is ComboBox) 
                {
                    ((ComboBox)component).Enabled = mode.Equals(FormMode.EDITOR) ? true : false;
                }
                if (component is Panel) 
                {
                    ReadOnlyText(((Panel)component), mode);
                }
                if (component is FlowLayoutPanel)
                {
                    ReadOnlyText((Panel)component, mode);
                }
            }
        }
        public async void LlenarCamposExterno(int id, FormMode _mode) 
        {
            mode = _mode;
            dtoPagina = await paginaService.Get(id);
            LlenarCampos(dtoPagina, _mode);
        }
        
        public async Task<dynamic> Get(int id) 
        {
            return await paginaService.Get(id);
        }
        private void LlenarCampos(PaginaDto pagina, FormMode mode) 
        {
            ReadOnlyText(panelBase, mode);
            if (pagina != null && pagina.Id > 0) 
            {
                txtCodigo.Visible = true;
                lblCodigoLabel.Visible = true;
                flpCodigo.Visible = true;
                txtCodigo.Text = pagina.Id.ToString();
                txtTitulo.Text = pagina.Titulo;
                txtNombre.Text = pagina.Nombre;
                txtProyecto.Text = pagina.Proyecto;
                txtUrl.Text = pagina.Url;
                chbEstado.Checked = pagina.EstadoRegistro;
                chbEstado.Visible = true;
                lblFechaCreacion.Visible = true;
                txtFechaCreacion.Visible = true;
                txtFechaCreacion.Text = pagina.FechaCreacion.ToString("yyyy-MM-dd");
                txtCreadoPor.Visible = true;
                lblCreadoPor.Visible = true;
                txtCreadoPor.Text = pagina.CreadoPor;
                if (pagina.FechaModificacion != null) 
                {
                    lblFechaModificacion.Visible = true;
                    txtFechaModificacion.Visible = true;
                    txtFechaModificacion.Text = pagina.FechaModificacion?.ToString("yyyy-MM-dd");
                }
                if (!string.IsNullOrEmpty(pagina.ModificadoPor)) 
                {
                    lblModificadoPor.Visible = true;
                    txtModificadoPor.Visible = true;
                    txtModificadoPor.Text = pagina.ModificadoPor;
                }
            }
        }
        private void label13_Click(object sender, EventArgs e)
        {
            string ruta = string.Empty;
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Seleccione el Archivo DLL";
            fDialog.Filter = "DLL Files (*.dll) |*.dll";
            fDialog.InitialDirectory = @"C:\";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                ruta = fDialog.FileName.ToString();
                if (ruta.ToUpper().IndexOf(".DLL") > 0)
                {
                    txtUrl.Text = ruta.Substring(0, ruta.Length > 20 ? 20 : ruta.Length) + "...";
                    txtProyecto.Text = fDialog.SafeFileName;
                    try
                    {
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            dtoPagina = new PaginaDto();
            mode = FormMode.EDITOR;
            Utilidades.ocultarCamposNuevo(this.panelBase, "oc");
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dtoPagina != null && dtoPagina.Id > 0) 
            {
                var result = await paginaService.Delete(dtoPagina.Id);
                if (result.Errors != null && result.Errors.Count > 0)
                {
                    var error = (from dt in result.Errors
                                 where dt.Field.ToLower().Equals(NombreFormulario.ToLower())
                                 select dt).FirstOrDefault();
                    if (error != null && error.Description != null && result.ErrorCode > 200)
                    {
                        MessageBox.Show(error.Description, Global.vg_msg_sys, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (error != null && error.Description != null && result.ErrorCode == 200)
                    {
                        MessageBox.Show(error.Description, Global.vg_msg_sys, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (result.ErrorCode == 200)
                {
                    dtoPagina = new PaginaDto();
                    Utilidades.ocultarCamposNuevo(this.panelBase, "oc");
                }
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
