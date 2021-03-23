
namespace OtoparkOtomasyonu
{
    partial class frmSeri
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
            this.lblSeri = new System.Windows.Forms.Label();
            this.txtSeri = new System.Windows.Forms.TextBox();
            this.btnSeriEkle = new System.Windows.Forms.Button();
            this.cbxMarka = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSeri
            // 
            this.lblSeri.AutoSize = true;
            this.lblSeri.Location = new System.Drawing.Point(18, 53);
            this.lblSeri.Name = "lblSeri";
            this.lblSeri.Size = new System.Drawing.Size(50, 15);
            this.lblSeri.TabIndex = 0;
            this.lblSeri.Text = "Seri Ekle";
            // 
            // txtSeri
            // 
            this.txtSeri.Location = new System.Drawing.Point(74, 50);
            this.txtSeri.Name = "txtSeri";
            this.txtSeri.Size = new System.Drawing.Size(120, 23);
            this.txtSeri.TabIndex = 1;
            // 
            // btnSeriEkle
            // 
            this.btnSeriEkle.Location = new System.Drawing.Point(119, 79);
            this.btnSeriEkle.Name = "btnSeriEkle";
            this.btnSeriEkle.Size = new System.Drawing.Size(75, 23);
            this.btnSeriEkle.TabIndex = 2;
            this.btnSeriEkle.Text = "Seri Ekle";
            this.btnSeriEkle.UseVisualStyleBackColor = true;
            this.btnSeriEkle.Click += new System.EventHandler(this.btnSeriEkle_Click);
            // 
            // cbxMarka
            // 
            this.cbxMarka.FormattingEnabled = true;
            this.cbxMarka.Location = new System.Drawing.Point(73, 12);
            this.cbxMarka.Name = "cbxMarka";
            this.cbxMarka.Size = new System.Drawing.Size(121, 23);
            this.cbxMarka.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Marka";
            // 
            // frmSeri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 142);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxMarka);
            this.Controls.Add(this.btnSeriEkle);
            this.Controls.Add(this.txtSeri);
            this.Controls.Add(this.lblSeri);
            this.Name = "frmSeri";
            this.Text = "SeriEkle";
            this.Load += new System.EventHandler(this.frmSeri_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSeri;
        private System.Windows.Forms.TextBox txtSeri;
        private System.Windows.Forms.Button btnSeriEkle;
        private System.Windows.Forms.ComboBox cbxMarka;
        private System.Windows.Forms.Label label1;
    }
}