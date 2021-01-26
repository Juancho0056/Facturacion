
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
using VentasModel.Entities.BaseEntities;
using VentasService.Models;
using VentasService.Models.BaseModel;

namespace VentasForms.Util
{
        public static class Utilidades
        {
            public static DataTable ConvertToDataTable<T>(IList<T> data)
            {
                PropertyDescriptorCollection properties =
                   TypeDescriptor.GetProperties(typeof(T));
                DataTable table = new DataTable();
                foreach (PropertyDescriptor prop in properties)
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                foreach (T item in data)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    table.Rows.Add(row);
                }
                return table;

            }
        public static List<Elemento> listarTag(Panel c, string tag)
        {
            List<Elemento> clases = new List<Elemento>();
            var components = c.Controls;
            foreach (Control component in components)
            {
                if (component is Panel)
                {
                    listarTag((Panel)component, tag);
                }

                if (component.Tag == null)
                    continue;
                if (component is TextBoxElement)
                {
                    if (component.Tag.Equals(tag))
                        clases.Add(new Elemento() { Key = component.Text, Value = primerletraM(component.Text) });

                }
            }
            return clases;
        }
        public static string primerletraM(string letra)
        {
            if (string.IsNullOrEmpty(letra))
            {
                return "";
            }
            char[] caracteres = letra.ToCharArray();
            caracteres[0] = char.ToUpper(caracteres[0]);
            return new string(caracteres);
        }
        public static string EncriptarClaveUsuario(string pCadena)
            {
                pCadena = CifrarTextoMD5(pCadena);
                pCadena += "2$V#WX3";
                return pCadena;
            }

            public static string CifrarTextoMD5(string str)
            {
                MD5 md5 = MD5.Create();
                ASCIIEncoding asciiEncoding = new ASCIIEncoding();
                StringBuilder stringBuilder = new StringBuilder();
                foreach (int num in md5.ComputeHash(asciiEncoding.GetBytes(str)))
                    stringBuilder.AppendFormat("{0:x2}", (object)(byte)num);
                return stringBuilder.ToString();
            }


            public static Button botonMenu(VentasModel.Entities.Menu menu)
            {
                Button boton = new Button();
                boton.Height = 40;
                boton.Width = 209;
                boton.Name = menu.Nombre;
                boton.Text = menu.Titulo;
                boton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(163)))), ((int)(((byte)(171)))));
                boton.Cursor = System.Windows.Forms.Cursors.Hand;
                boton.Dock = System.Windows.Forms.DockStyle.Top;
                boton.FlatAppearance.BorderSize = 0;
                boton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(163)))), ((int)(((byte)(171)))));
                boton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(193)))), ((int)(((byte)(199)))));
                boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                boton.ForeColor = System.Drawing.Color.White;
                boton.AccessibleDescription = menu.Pagina.Nombre;
                boton.AccessibleName = menu.Pagina.Id.ToString();
                boton.Tag = "panel" + menu.Id;
                if (menu.Padre != null)
                {
                    boton.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
                }
                else
                {
                    boton.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
                }


                boton.Size = new System.Drawing.Size(209, 40);
                boton.TabIndex = 1;
                boton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                boton.UseVisualStyleBackColor = false;
                //boton.Click += new EventHandler();
                return boton;
            }
            private delegate void SafeCallDelegateComponent(Control component, bool flag);
            public static void enableControl(Control component, bool flag)
            {
                if (component.InvokeRequired)
                {
                    var d = new SafeCallDelegateComponent(enableControl);
                    component.Invoke(d, new object[] { component, flag });
                }
                else
                {
                    (component).Enabled = flag;
                }
            }
            public static void visibleControl(Control component, bool flag)
            {
                if (component.InvokeRequired)
                {
                    var d = new SafeCallDelegateComponent(enableControl);
                    component.Invoke(d, new object[] { component, flag });
                }
                else
                {
                    (component).Visible = flag;
                }
            }
        public static bool validarCampo(Panel panelBase, Control component)
        {
            if (component is TextBox)
            {
                if (component.Tag != null && component.Tag.ToString().Contains("*"))
                {
                    if (panelBase.Controls.ContainsKey(component.AccessibleName.ToString()))
                    {
                        if (!component.Text.Equals(""))
                        {
                            mostrarLabel(panelBase, component.AccessibleName.ToString());
                            return true;
                        }
                        else
                        {
                            mostrarLabel(panelBase, component.AccessibleName.ToString(),  true);
                            return false;
                        }

                    }
                }
            }
            return true;
        }
        public static bool validarCampo(Panel panelBase, Control component, string mensaje)
            {
                if (component is TextBox)
                {
                    if (component.Tag != null && component.Tag.ToString().Contains("*"))
                    {
                        if (panelBase.Controls.ContainsKey(component.AccessibleName.ToString()))
                        {
                            if (!component.Text.Equals(""))
                            {
                                mostrarLabel(panelBase, component.AccessibleName.ToString(),mensaje = "");
                                return true;
                            }
                            else
                            {
                                mostrarLabel(panelBase, component.AccessibleName.ToString(), mensaje, true);
                                return false;
                            }

                        }
                    }
                }
                return true;
            }
        public static void validarCampos(Panel panelBase, List<BaseErrorDto> errors)
        {
            foreach (Control component in panelBase.Controls)
            {
                if (component is Label)
                {
                    var name = component.Name.ToLower().Substring(3, component.Name.Length - 3);
                    var exist = (from dt in errors where dt.Field.ToLower().Equals(name.ToLower()) select dt).FirstOrDefault();
                    //(Panel panelBase, string nombre, string mensaje, bool flag = false)
                    if (exist != null && exist.Field != null)
                    {
                        Utilidades.mostrarLabel(panelBase, component.Name, exist.Description, true);
                    }

                }
            }
        }
        public static void ocultarCamposNuevo(Control panelBase, string tag)
        {
            foreach (Control component in panelBase.Controls)
            {
                if (component is CheckBox) 
                {
                    if (component.Tag != null && component.Tag.ToString().Equals(tag))
                    {
                        component.Enabled = true;
                        component.Visible = false;
                    }
                }
                if (component is Label)
                {
                    if (component.Tag!= null && component.Tag.ToString().Equals(tag))
                    {
                        component.Visible = false;
                    }
                }
                if (component is TextBox)
                {
                    component.Text = "";
                    ((TextBox)component).ReadOnly = false;
                    if (component.Tag != null && component.Tag.ToString().Equals(tag))
                    {
                        component.Visible = false;
                    }
                }

                if (component is FlowLayoutPanel)
                {
                    if (component.Tag != null && component.Tag.ToString().Equals(tag))
                    {
                        component.Visible = false;
                    }
                    ocultarCamposNuevo(component, tag);
                }
                if (component is Panel)
                {
                    if (component.Tag != null && component.Tag.ToString().Equals(tag))
                    {
                        component.Visible = false;
                    }
                    ocultarCamposNuevo(component, tag);
                }
            }
        }
        private static void mostrarLabel(Panel panelBase, string nombre, string mensaje, bool flag = false)
        {
            foreach (Control component in panelBase.Controls)
            {
                if (component is Label)
                {
                    if (component.Name.Equals(nombre))
                    {
                        component.Visible = flag;
                        component.Text = mensaje;
                    }
                }
            }
        }
        private static void mostrarLabel(Panel panelBase, string nombre,  bool flag = false)
        {
            foreach (Control component in panelBase.Controls)
            {
                if (component is Label)
                {
                    if (component.Name.Equals(nombre))
                    {
                        component.Visible = flag;
                    }
                }
            }
        }
        public static String ArchivoValidacion()
            {
                return Path.GetFullPath(ConfigurationManager.AppSettings["validationfile"]);
            }


            public static string ActualizarValorColumnaDt(string colVlaue, char findChar, char insertChar)
            {
                int startIndex = 0;
                int colIndex = colVlaue.IndexOf(findChar, startIndex);
                while (colIndex != -1)
                {
                    colVlaue = colVlaue.Insert(colIndex, insertChar.ToString());
                    startIndex = colIndex + 2;
                    colIndex = colVlaue.IndexOf(findChar, startIndex);
                }
                return colVlaue;
            }

            public static string NombreCsvValidado(string csvFilePath)
            {
                string path = Path.GetDirectoryName(csvFilePath);
                string filename = Path.GetFileNameWithoutExtension(csvFilePath) + "_" + "validated.csv";
                return Path.Combine(path, filename);

            }
            public static Panel panelSubMenu(int width, string nombre)
            {
                Panel panel = new Panel();
                panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(209)))));
                panel.Dock = System.Windows.Forms.DockStyle.Top;
                panel.Location = new System.Drawing.Point(0, 0);
                panel.Name = nombre;
                panel.Tag = "submenu";
                panel.Size = new System.Drawing.Size(209, width);
                return panel;
            }
            public static ToolStripMenuItem crearMenuItem(VentasModel.Entities.Menu menu)
            {
                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                try
                {
                    toolStripMenuItem.Name = menu.Nombre;
                    toolStripMenuItem.Text = menu.Titulo;
                    toolStripMenuItem.AccessibleDescription = menu.Pagina.Nombre;
                    toolStripMenuItem.AccessibleName = menu.Pagina.Id.ToString();
                }
                catch (Exception e)
                {

                }
                return toolStripMenuItem;
            }


        }
    }
