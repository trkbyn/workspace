namespace HastaneRandevu
{
    partial class Anasayfa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Anasayfa));
            this.DısPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.icPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnHatırla = new System.Windows.Forms.Button();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKimlik = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.DısPanel.SuspendLayout();
            this.icPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // DısPanel
            // 
            this.DısPanel.BackColor = System.Drawing.Color.Brown;
            this.DısPanel.Controls.Add(this.label1);
            this.DısPanel.Controls.Add(this.icPanel);
            this.DısPanel.Controls.Add(this.pictureBox1);
            this.DısPanel.Controls.Add(this.pictureBox2);
            this.DısPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DısPanel.Location = new System.Drawing.Point(0, 0);
            this.DısPanel.Name = "DısPanel";
            this.DısPanel.Size = new System.Drawing.Size(777, 505);
            this.DısPanel.TabIndex = 4;
            this.DısPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DısPanel_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(279, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // icPanel
            // 
            this.icPanel.BackColor = System.Drawing.Color.LightGray;
            this.icPanel.Controls.Add(this.button2);
            this.icPanel.Controls.Add(this.button1);
            this.icPanel.Controls.Add(this.btnHatırla);
            this.icPanel.Controls.Add(this.txtSifre);
            this.icPanel.Controls.Add(this.label4);
            this.icPanel.Controls.Add(this.label3);
            this.icPanel.Controls.Add(this.txtKimlik);
            this.icPanel.Location = new System.Drawing.Point(137, 119);
            this.icPanel.Name = "icPanel";
            this.icPanel.Size = new System.Drawing.Size(504, 341);
            this.icPanel.TabIndex = 4;
            this.icPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.icPanel_Paint);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DimGray;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(86, 196);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(316, 35);
            this.button2.TabIndex = 8;
            this.button2.Text = "Üye Ol";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(86, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(316, 35);
            this.button1.TabIndex = 7;
            this.button1.Text = "Giriş";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnHatırla
            // 
            this.btnHatırla.BackColor = System.Drawing.Color.Teal;
            this.btnHatırla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHatırla.Location = new System.Drawing.Point(337, 86);
            this.btnHatırla.Name = "btnHatırla";
            this.btnHatırla.Size = new System.Drawing.Size(111, 27);
            this.btnHatırla.TabIndex = 6;
            this.btnHatırla.Text = "Hatırlamıyorum";
            this.btnHatırla.UseVisualStyleBackColor = false;
            this.btnHatırla.Click += new System.EventHandler(this.btnHatırla_Click);
            // 
            // txtSifre
            // 
            this.txtSifre.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSifre.Location = new System.Drawing.Point(202, 86);
            this.txtSifre.MaxLength = 10;
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(129, 26);
            this.txtSifre.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Şifrenizi giriniz";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "T.C. Kimlik numaranızı giriniz";
            // 
            // txtKimlik
            // 
            this.txtKimlik.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKimlik.Location = new System.Drawing.Point(202, 42);
            this.txtKimlik.MaxLength = 11;
            this.txtKimlik.Name = "txtKimlik";
            this.txtKimlik.Size = new System.Drawing.Size(247, 26);
            this.txtKimlik.TabIndex = 0;
            this.txtKimlik.TextChanged += new System.EventHandler(this.txtKimlik_TextChanged);
            this.txtKimlik.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKimlik_KeyPress);
            this.txtKimlik.Leave += new System.EventHandler(this.txtKimlik_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HastaneRandevu.Properties.Resources._182;
            this.pictureBox1.Location = new System.Drawing.Point(66, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(136, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::HastaneRandevu.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(603, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(136, 80);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // Anasayfa
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 505);
            this.Controls.Add(this.DısPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Anasayfa";
            this.Text = "Hastane Randevu Sistemi";
            this.Load += new System.EventHandler(this.Anasayfa_Load);
            this.DısPanel.ResumeLayout(false);
            this.DısPanel.PerformLayout();
            this.icPanel.ResumeLayout(false);
            this.icPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel DısPanel;
        private System.Windows.Forms.Panel icPanel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnHatırla;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKimlik;
        private System.Windows.Forms.Label label1;
    }
}

