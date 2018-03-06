namespace PrestaMe.Windows.Forms
{
    partial class splashForm
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
            this.components = new System.ComponentModel.Container();
            this.labelVersion = new Telerik.WinControls.UI.RadLabel();
            this.labelProgressMessage = new Telerik.WinControls.UI.RadLabel();
            this.labelCopyRight = new Telerik.WinControls.UI.RadLabel();
            this.labelSiglas = new Telerik.WinControls.UI.RadLabel();
            this.labelProducto = new Telerik.WinControls.UI.RadLabel();
            this.labelAlias = new Telerik.WinControls.UI.RadLabel();
            this.timerProgressBar = new System.Windows.Forms.Timer(this.components);
            this.radProgressBar = new Telerik.WinControls.UI.RadProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.labelVersion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelProgressMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelCopyRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelSiglas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelAlias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // labelVersion
            // 
            this.labelVersion.Location = new System.Drawing.Point(456, 16);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(28, 18);
            this.labelVersion.TabIndex = 0;
            this.labelVersion.Text = "V1.0";
            // 
            // labelProgressMessage
            // 
            this.labelProgressMessage.Location = new System.Drawing.Point(224, 214);
            this.labelProgressMessage.Name = "labelProgressMessage";
            this.labelProgressMessage.Size = new System.Drawing.Size(55, 18);
            this.labelProgressMessage.TabIndex = 1;
            this.labelProgressMessage.Text = "Cargando";
            // 
            // labelCopyRight
            // 
            this.labelCopyRight.Location = new System.Drawing.Point(12, 370);
            this.labelCopyRight.Name = "labelCopyRight";
            this.labelCopyRight.Size = new System.Drawing.Size(58, 18);
            this.labelCopyRight.TabIndex = 3;
            this.labelCopyRight.Text = "CopyRight";
            // 
            // labelSiglas
            // 
            this.labelSiglas.Location = new System.Drawing.Point(24, 16);
            this.labelSiglas.Name = "labelSiglas";
            this.labelSiglas.Size = new System.Drawing.Size(90, 18);
            this.labelSiglas.TabIndex = 4;
            this.labelSiglas.Text = "Siglas Aplicacion";
            // 
            // labelProducto
            // 
            this.labelProducto.Location = new System.Drawing.Point(227, 140);
            this.labelProducto.Name = "labelProducto";
            this.labelProducto.Size = new System.Drawing.Size(52, 18);
            this.labelProducto.TabIndex = 5;
            this.labelProducto.Text = "Producto";
            // 
            // labelAlias
            // 
            this.labelAlias.Location = new System.Drawing.Point(24, 64);
            this.labelAlias.Name = "labelAlias";
            this.labelAlias.Size = new System.Drawing.Size(30, 18);
            this.labelAlias.TabIndex = 6;
            this.labelAlias.Text = "Alias";
            // 
            // radProgressBar
            // 
            this.radProgressBar.Location = new System.Drawing.Point(136, 184);
            this.radProgressBar.Name = "radProgressBar";
            this.radProgressBar.Size = new System.Drawing.Size(232, 24);
            this.radProgressBar.TabIndex = 7;
            // 
            // splashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.ControlBox = false;
            this.Controls.Add(this.radProgressBar);
            this.Controls.Add(this.labelAlias);
            this.Controls.Add(this.labelProducto);
            this.Controls.Add(this.labelSiglas);
            this.Controls.Add(this.labelCopyRight);
            this.Controls.Add(this.labelProgressMessage);
            this.Controls.Add(this.labelVersion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "splashForm";
            this.Opacity = 0.83D;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "splashForm";
            this.Load += new System.EventHandler(this.splashFormLoad);
            ((System.ComponentModel.ISupportInitialize)(this.labelVersion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelProgressMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelCopyRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelSiglas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelAlias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel labelVersion;
        private Telerik.WinControls.UI.RadLabel labelProgressMessage;
        private Telerik.WinControls.UI.RadLabel labelCopyRight;
        private Telerik.WinControls.UI.RadLabel labelSiglas;
        private Telerik.WinControls.UI.RadLabel labelProducto;
        private Telerik.WinControls.UI.RadLabel labelAlias;
        private System.Windows.Forms.Timer timerProgressBar;
        private Telerik.WinControls.UI.RadProgressBar radProgressBar;
    }
}