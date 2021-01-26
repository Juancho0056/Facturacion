
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace VentasForms.Util
    {
        public class TextBoxElement : TextBox
        {
            public TextBoxElement()
            {

            }
            string hint;
            Color foregroundHint = Color.White;
            public Color ForegroundHint
            {
                get { return foregroundHint; }
                set { foregroundHint = value; this.Invalidate(); }
            }
            public string Hint
            {
                get { return hint; }
                set { hint = value; this.Invalidate(); }
            }
            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);
                if (m.Msg == 0xf)
                {
                    if (!this.Focused && string.IsNullOrEmpty(this.Text)
                        && !string.IsNullOrEmpty(this.Hint))
                    {
                        using (var g = this.CreateGraphics())
                        {

                            TextRenderer.DrawText(g, this.Hint, this.Font,
                                this.ClientRectangle, this.ForegroundHint, this.BackColor,
                                TextFormatFlags.Top | TextFormatFlags.HorizontalCenter);


                        }
                    }
                }
            }
        }
    }
