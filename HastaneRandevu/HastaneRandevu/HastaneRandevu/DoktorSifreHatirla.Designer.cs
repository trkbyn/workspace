namespace HastaneRandevu
{
    partial class DoktorSifreHatirla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoktorSifreHatirla));
            this.pnlHatırla = new System.Windows.Forms.Panel();
            this.gbHatirla = new System.Windows.Forms.GroupBox();
            this.btnGonder = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtKimlik = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlHatırla.SuspendLayout();
            this.gbHatirla.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHatırla
            // 
            this.pnlHatırla.Controls.Add(this.gbHatirla);
            this.pnlHatırla.Location = new System.Drawing.Point(172, 84);
            this.pnlHatırla.Name = "pnlHatırla";
            this.pnlHatırla.Size = new System.Drawing.Size(456, 282);
            this.pnlHatırla.TabIndex = 1;
            // 
            // gbHatirla
            // 
            this.gbHatirla.BackColor = System.Drawing.Color.LightCoral;
            this.gbHatirla.Controls.Add(this.btnGonder);
            this.gbHatirla.Controls.Add(this.txtEmail);
            this.gbHatirla.Controls.Add(this.txtKimlik);
            this.gbHatirla.Controls.Add(this.label2);
            this.gbHatirla.Controls.Add(this.label1);
            this.gbHatirla.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbHatirla.Location = new System.Drawing.Point(60, 43);
            this.gbHatirla.Name = "gbHatirla";
            this.gbHatirla.Size = new System.Drawing.Size(352, 204);
            this.gbHatirla.TabIndex = 0;
            this.gbHatirla.TabStop = false;
            this.gbHatirla.Text = "Parola Yenileme";
            // 
            // btnGonder
            // 
            this.btnGonder.BackColor = System.Drawing.Color.LightCyan;
            this.btnGonder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGonder.Location = new System.Drawing.Point(135, 144);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(90, 31);
            this.btnGonder.TabIndex = 12;
            this.btnGonder.Text = "Gönder";
            this.btnGonder.UseVisualStyleBackColor = false;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.LightCyan;
            this.txtEmail.Location = new System.Drawing.Point(135, 100);
            this.txtEmail.MaxLength = 60;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 33);
            this.txtEmail.TabIndex = 11;
            // 
            // txtKimlik
            // 
            this.txtKimlik.BackColor = System.Drawing.Color.LightCyan;
            this.txtKimlik.Location = new System.Drawing.Point(135, 54);
            this.txtKimlik.MaxLength = 11;
            this.txtKimlik.Name = "txtKimlik";
            this.txtKimlik.Size = new System.Drawing.Size(200, 33);
            this.txtKimlik.TabIndex = 10;
            this.txtKimlik.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKimlik_KeyPress);
            this.txtKimlik.Leave += new System.EventHandler(this.txtKimlik_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(25, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "E Posta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(25, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "T.C. Kimlik No";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::HastaneRandevu.Properties.Resources.turquise;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(1, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 25);
            this.button1.TabIndex = 36;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DoktorSifreHatirla
            // 
            this.AcceptButton = this.btnGonder;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pnlHatırla);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DoktorSifreHatirla";
            this.Text = "Şifremi Unuttum";
            this.Load += new System.EventHandler(this.DoktorSifreHatirla_Load);
            this.pnlHatırla.ResumeLayout(false);
            this.gbHatirla.ResumeLayout(false);
            this.gbHatirla.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHatırla;
        private System.Windows.Forms.GroupBox gbHatirla;
        private System.Windows.Forms.Button btnGonder;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtKimlik;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}