using System;
using System.Windows.Forms;
using VentasService.Services;
using VentasService;
using VentasForms.Util;
using System.Collections.Generic;
using Forms;
using VentasService.Models.BaseModel;
using System.Data;
using VentasModel.Entities;

namespace VentasForms
{
    public partial class UCLista : UserControl
    {
        private UserControl ucCrud;
        private FrmInicio frmInicio;
        private readonly ConsultaService consultaService = ConsultaService.getInstancia();
        private string table;
        private string tipo;
        private Paginador pag;
        private EnumerableResponse<DataTable> consulta;
        private List<Elemento> elementosSelect;
        public UCLista(UserControl _ucCrud, FrmInicio _frmInicio,
            string _table, string _tipo)
        {
            InitializeComponent();
            this.ucCrud = _ucCrud;
            this.table = _table;
            this.tipo = _tipo;
            this.frmInicio = _frmInicio;
            FillComboLimit();
            //FillTable("N");
        }
        private void FillComboLimit() 
        {
            elementosSelect = new List<Elemento>();
            elementosSelect.Add(new Elemento() { Key = "5", Value = "5" });
            elementosSelect.Add(new Elemento() { Key = "10", Value = "10" });
            elementosSelect.Add(new Elemento() { Key = "20", Value = "20" });
            elementosSelect.Add(new Elemento() { Key = "30", Value = "30" });
            cmbLimit.DisplayMember = "Value";
            cmbLimit.ValueMember = "Key";
            cmbLimit.DataSource = elementosSelect;
        }
        public void refreshTable(string busqueda)
        {
            pag.setTotalItem(consulta.Count);
            FillTable(busqueda, pag.getPaginaActual(), pag.getTamPagina());
            txtRegistros.Text = (pag.getPaginaActual().ToString());
            if ((pag.getTamPagina() + pag.getCurrentItem()) > pag.getTotalItem())
            {
                txtRegistros.Text = ("Mostrando " + ((pag.getCurrentItem() == 0 && pag.getTotalItem() > 0) ? 1
                    : pag.getCurrentItem() > 1 ? pag.getCurrentItem() + 1 : pag.getCurrentItem()) + " a "
                        + (pag.getTotalItem()) + " de " + pag.getTotalItem() + " registros");
            }
            else
            {
                txtRegistros.Text = ("Mostrando " + ((pag.getCurrentItem() == 0 && pag.getTotalItem() > 0) ? 1 
                    : pag.getCurrentItem() > 1 ? pag.getCurrentItem() + 1 : pag.getCurrentItem()) + " a "
                        + (pag.getTamPagina() + pag.getCurrentItem()) + " de " + pag.getTotalItem() + " registros");
                
                
            }
            btnPrimero.Enabled = (pag.existeAnteriorPagina());
            btnAnterior.Enabled = (pag.existeAnteriorPagina());
            btnSiguiente.Enabled = (pag.existeSiguientePagina());
            btnUltimo.Enabled = (pag.existeSiguientePagina());
            lblPagina.Text = pag.getPaginaActual().ToString();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private async void FillTable(string busqueda, int page, int limit) 
        {
            consulta = null;
            consulta = await consultaService.GetConsultaDataTable(txtBusqueda.Text, table,
                tipo, page, limit);
            dgDatos.DataSource = null;
            dgDatos.Rows.Clear();
            dgDatos.Columns.Clear();
            if (consulta is null || consulta.Data is null)
                return;
            
            if (consulta.Data.Rows.Count > 0)
            {
                dgDatos.DataSource = consulta.Data;
                DataGridViewButtonColumn btnVer = new DataGridViewButtonColumn();
                dgDatos.Columns.Add(btnVer);
                btnVer.Text = "Ver";
                btnVer.Name = "Ver";
                btnVer.Width = 84;
                btnVer.UseColumnTextForButtonValue = true;
                DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                dgDatos.Columns.Add(btnEditar);
                btnEditar.Text = "Editar";
                btnEditar.Name = "Editar";
                btnEditar.Width = 84;
                btnEditar.UseColumnTextForButtonValue = true;
            }
        }

        private async void dgDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            dynamic data = null;

            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                data = await ((BaseUC)ucCrud).Get(id);
                if (data is null)
                {
                    MessageBox.Show("Verifique el codigo del registro", Global.vg_msg_sys, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if ((this.dgDatos.Columns[e.ColumnIndex].Name.ToString() == "Ver"))
            {
                if (data != null) 
                {
                    int id = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                    ((BaseUC)ucCrud).LlenarCamposExterno(id, FormMode.READONLY);
                    frmInicio.openChildForm(ucCrud, this, true);
                }
            }
            if ((this.dgDatos.Columns[e.ColumnIndex].Name.ToString() == "Editar"))
            {
                if (data != null)
                {
                    int id = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                    ((BaseUC)ucCrud).LlenarCamposExterno(id, FormMode.EDITOR);
                    frmInicio.openChildForm(ucCrud, this, true);
                }
            }
        }

        private async void cmbLimit_SelectedIndexChanged(object sender, EventArgs e)
        {
            string search = txtBusqueda.Text;
            if (cmbLimit.SelectedIndex > -1 || cmbLimit.SelectedItem != null)
            {
                if (cmbLimit.SelectedIndex > -1)
                {
                    consulta = null;
                    consulta = await consultaService.GetConsultaDataTable(txtBusqueda.Text, table,
                        tipo, 1, Convert.ToInt32(cmbLimit.SelectedValue.ToString()));
                    pag = new Paginador(Convert.ToInt32(cmbLimit.SelectedValue.ToString()), consulta.Count);
                    refreshTable(search);
                }   
            }
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            if (cmbLimit.SelectedIndex > -1)
            {
                string search = txtBusqueda.Text;
                pag.primeraPagina();
                refreshTable(search);
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (cmbLimit.SelectedIndex > -1)
            {
                string search = txtBusqueda.Text;
                pag.anteriorPagina();
                refreshTable(search);
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (cmbLimit.SelectedIndex > -1)
            {
                string search = txtBusqueda.Text;
                pag.siguientePagina();
                refreshTable(search);
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            if (cmbLimit.SelectedIndex > -1)
            {
                string search = txtBusqueda.Text;
                pag.ultimaPagina();
                refreshTable(search);
            }
        }

        private async void label1_Click(object sender, EventArgs e)
        {
            string search = txtBusqueda.Text;
            if (cmbLimit.SelectedIndex > -1 || cmbLimit.SelectedItem != null)
            {
                if (cmbLimit.SelectedIndex > -1)
                {
                    var prueba = cmbLimit.SelectedValue;
                    consulta = await consultaService.GetConsultaDataTable(txtBusqueda.Text, table,
                        tipo, 1, Convert.ToInt32(cmbLimit.SelectedValue.ToString()));
                    pag = new Paginador(Convert.ToInt32(cmbLimit.SelectedValue.ToString()), consulta.Count);
                    refreshTable(search);
                }
            }
        }

        private void dgDatos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var dataGridView = (DataGridView)sender;
            if ((this.dgDatos.Columns[e.ColumnIndex].Name.ToString() == "Editar") 
                || (this.dgDatos.Columns[e.ColumnIndex].Name.ToString() == "Ver"))
                dataGridView.Cursor = Cursors.Hand;
            else
                dataGridView.Cursor = Cursors.Default;
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgDatos.DataSource = null;
            dgDatos.Rows.Clear();
            dgDatos.Columns.Clear();
            dgDatos.AutoGenerateColumns = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string search = txtBusqueda.Text;
            refreshTable(search);
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                string search = txtBusqueda.Text;
                refreshTable(search);
            }
        }
    }
}
