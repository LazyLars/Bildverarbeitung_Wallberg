namespace Bildverarbeitung_Wallberg
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.btnGrey = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnHistogram = new System.Windows.Forms.Button();
            this.btnHistoColor = new System.Windows.Forms.Button();
            this.btnHistoArea = new System.Windows.Forms.Button();
            this.btn_greyscales = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMain
            // 
            this.pbMain.Location = new System.Drawing.Point(-1, -2);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(747, 509);
            this.pbMain.TabIndex = 0;
            this.pbMain.TabStop = false;
            // 
            // btnGrey
            // 
            this.btnGrey.Location = new System.Drawing.Point(1070, 34);
            this.btnGrey.Name = "btnGrey";
            this.btnGrey.Size = new System.Drawing.Size(75, 23);
            this.btnGrey.TabIndex = 1;
            this.btnGrey.Text = "Grau";
            this.btnGrey.UseVisualStyleBackColor = true;
            this.btnGrey.Click += new System.EventHandler(this.btnGrey_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(1070, 5);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(75, 23);
            this.btnDefault.TabIndex = 2;
            this.btnDefault.Text = "Default";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // btnHistogram
            // 
            this.btnHistogram.Location = new System.Drawing.Point(1070, 63);
            this.btnHistogram.Name = "btnHistogram";
            this.btnHistogram.Size = new System.Drawing.Size(75, 23);
            this.btnHistogram.TabIndex = 3;
            this.btnHistogram.Text = "Histogram";
            this.btnHistogram.UseVisualStyleBackColor = true;
            this.btnHistogram.Click += new System.EventHandler(this.btnHistogram_Click);
            // 
            // btnHistoColor
            // 
            this.btnHistoColor.Location = new System.Drawing.Point(1070, 92);
            this.btnHistoColor.Name = "btnHistoColor";
            this.btnHistoColor.Size = new System.Drawing.Size(75, 41);
            this.btnHistoColor.TabIndex = 4;
            this.btnHistoColor.Text = "Histogram Bunt";
            this.btnHistoColor.UseVisualStyleBackColor = true;
            this.btnHistoColor.Click += new System.EventHandler(this.btnHistoColor_Click);
            // 
            // btnHistoArea
            // 
            this.btnHistoArea.Location = new System.Drawing.Point(1070, 139);
            this.btnHistoArea.Name = "btnHistoArea";
            this.btnHistoArea.Size = new System.Drawing.Size(75, 41);
            this.btnHistoArea.TabIndex = 5;
            this.btnHistoArea.Text = "Histogram Ortsbestimmung";
            this.btnHistoArea.UseVisualStyleBackColor = true;
            this.btnHistoArea.Click += new System.EventHandler(this.btnHistoArea_Click);
            // 
            // btn_greyscales
            // 
            this.btn_greyscales.Location = new System.Drawing.Point(1070, 187);
            this.btn_greyscales.Name = "btn_greyscales";
            this.btn_greyscales.Size = new System.Drawing.Size(75, 38);
            this.btn_greyscales.TabIndex = 6;
            this.btn_greyscales.Text = "Clean Greyscales";
            this.btn_greyscales.UseVisualStyleBackColor = true;
            this.btn_greyscales.Click += new System.EventHandler(this.btn_greyscales_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 505);
            this.Controls.Add(this.btn_greyscales);
            this.Controls.Add(this.btnHistoArea);
            this.Controls.Add(this.btnHistoColor);
            this.Controls.Add(this.btnHistogram);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.btnGrey);
            this.Controls.Add(this.pbMain);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.Button btnGrey;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Button btnHistogram;
        private System.Windows.Forms.Button btnHistoColor;
        private System.Windows.Forms.Button btnHistoArea;
        private System.Windows.Forms.Button btn_greyscales;
    }
}

