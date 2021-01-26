using System.Drawing;

namespace VentasForms
{
    partial class FrmAcceso
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAcceso));
            this.panelBase = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtContrasenia = new VentasForms.Util.TextBoxElement();
            this.txtCuenta = new VentasForms.Util.TextBoxElement();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.lblContrasenia = new System.Windows.Forms.Label();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.separator2 = new VentasForms.Util.Separator();
            this.label3 = new System.Windows.Forms.Label();
            this.separator1 = new VentasForms.Util.Separator();
            this.panelBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBase
            // 
            this.panelBase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(196)))), ((int)(((byte)(164)))));
            this.panelBase.Controls.Add(this.label2);
            this.panelBase.Controls.Add(this.button2);
            this.panelBase.Controls.Add(this.txtContrasenia);
            this.panelBase.Controls.Add(this.txtCuenta);
            this.panelBase.Controls.Add(this.panel2);
            this.panelBase.Controls.Add(this.btnSiguiente);
            this.panelBase.Controls.Add(this.lblContrasenia);
            this.panelBase.Controls.Add(this.lblCuenta);
            this.panelBase.Controls.Add(this.button4);
            this.panelBase.Controls.Add(this.label1);
            this.panelBase.Controls.Add(this.separator2);
            this.panelBase.Controls.Add(this.label3);
            this.panelBase.Controls.Add(this.separator1);
            this.panelBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBase.Location = new System.Drawing.Point(0, 0);
            this.panelBase.Name = "panelBase";
            this.panelBase.Size = new System.Drawing.Size(351, 495);
            this.panelBase.TabIndex = 0;
            this.panelBase.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBase_MouseDown);
            this.panelBase.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBase_MouseMove);
            this.panelBase.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelBase_MouseUp);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(117, 472);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 15);
            this.label2.TabIndex = 28;
            this.label2.Text = "© 2020 Quokka Soft";
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::VentasForms.Properties.Resources.close;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(326, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(22, 22);
            this.button2.TabIndex = 27;
            this.button2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtContrasenia
            // 
            this.txtContrasenia.AccessibleName = "lblContrasenia";
            this.txtContrasenia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(196)))), ((int)(((byte)(164)))));
            this.txtContrasenia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContrasenia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasenia.ForeColor = System.Drawing.Color.White;
            this.txtContrasenia.ForegroundHint = System.Drawing.Color.White;
            this.txtContrasenia.Hint = "Contraseña";
            this.txtContrasenia.Location = new System.Drawing.Point(66, 345);
            this.txtContrasenia.Name = "txtContrasenia";
            this.txtContrasenia.PasswordChar = '*';
            this.txtContrasenia.Size = new System.Drawing.Size(218, 19);
            this.txtContrasenia.TabIndex = 26;
            this.txtContrasenia.Tag = "*";
            this.txtContrasenia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContrasenia.TextChanged += new System.EventHandler(this.txtContrasenia_TextChanged);
            this.txtContrasenia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContrasenia_KeyPress);
            this.txtContrasenia.Leave += new System.EventHandler(this.txtContrasenia_Leave);
            // 
            // txtCuenta
            // 
            this.txtCuenta.AccessibleName = "lblCuenta";
            this.txtCuenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(196)))), ((int)(((byte)(164)))));
            this.txtCuenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCuenta.ForeColor = System.Drawing.Color.White;
            this.txtCuenta.ForegroundHint = System.Drawing.Color.White;
            this.txtCuenta.Hint = "Usuario";
            this.txtCuenta.Location = new System.Drawing.Point(66, 287);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.Size = new System.Drawing.Size(218, 19);
            this.txtCuenta.TabIndex = 24;
            this.txtCuenta.Tag = "*";
            this.txtCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCuenta.TextChanged += new System.EventHandler(this.textBoxElement1_TextChanged);
            this.txtCuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCuenta_KeyPress);
            this.txtCuenta.Leave += new System.EventHandler(this.txtCuenta_Leave);
            this.txtCuenta.MouseLeave += new System.EventHandler(this.txtCuenta_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackgroundImage = global::VentasForms.Properties.Resources.logoAcceso;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(71, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(210, 210);
            this.panel2.TabIndex = 23;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.Color.White;
            this.btnSiguiente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSiguiente.FlatAppearance.BorderSize = 0;
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Font = new System.Drawing.Font("Copperplate Gothic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiguiente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(196)))), ((int)(((byte)(164)))));
            this.btnSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSiguiente.Location = new System.Drawing.Point(38, 396);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(278, 34);
            this.btnSiguiente.TabIndex = 21;
            this.btnSiguiente.Text = "Ingresar";
            this.btnSiguiente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // lblContrasenia
            // 
            this.lblContrasenia.AutoSize = true;
            this.lblContrasenia.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrasenia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblContrasenia.Location = new System.Drawing.Point(39, 373);
            this.lblContrasenia.Name = "lblContrasenia";
            this.lblContrasenia.Size = new System.Drawing.Size(229, 17);
            this.lblContrasenia.TabIndex = 19;
            this.lblContrasenia.Text = "Campo contraseña es obligatorio";
            this.lblContrasenia.Visible = false;
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCuenta.Location = new System.Drawing.Point(35, 316);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(202, 17);
            this.lblCuenta.TabIndex = 20;
            this.lblCuenta.Text = "Campo cuenta es obligatorio";
            this.lblCuenta.Visible = false;
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Image = global::VentasForms.Properties.Resources.btnVer;
            this.button4.Location = new System.Drawing.Point(290, 345);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(22, 22);
            this.button4.TabIndex = 18;
            this.button4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(39, 341);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 24);
            this.label1.TabIndex = 7;
            // 
            // separator2
            // 
            this.separator2.ForeColor = System.Drawing.Color.White;
            this.separator2.isVertical = false;
            this.separator2.Location = new System.Drawing.Point(38, 357);
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(278, 23);
            this.separator2.TabIndex = 8;
            this.separator2.Text = "separator2";
            this.separator2.Thickness = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label3.Image = global::VentasForms.Properties.Resources.user;
            this.label3.Location = new System.Drawing.Point(39, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 24);
            this.label3.TabIndex = 4;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // separator1
            // 
            this.separator1.ForeColor = System.Drawing.Color.White;
            this.separator1.isVertical = false;
            this.separator1.Location = new System.Drawing.Point(38, 299);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(278, 23);
            this.separator1.TabIndex = 5;
            this.separator1.Text = "separator1";
            this.separator1.Thickness = 1;
            this.separator1.Click += new System.EventHandler(this.separator1_Click);
            // 
            // FrmAcceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 495);
            this.Controls.Add(this.panelBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAcceso";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio de Sesion";
            this.panelBase.ResumeLayout(false);
            this.panelBase.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBase;
        private System.Windows.Forms.Label label3;
        private VentasForms.Util.Separator separator1;
        private System.Windows.Forms.Label label1;
        private VentasForms.Util.Separator separator2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblContrasenia;
        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Panel panel2;
        private Util.TextBoxElement txtCuenta;
        private Util.TextBoxElement txtContrasenia;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
    }
}