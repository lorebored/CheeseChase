namespace CheeseChase_V0._0._1
{
    partial class formEnd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formEnd));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblSecondi = new System.Windows.Forms.Label();
            this.lblSoldi = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::CheeseChase_V0._0._1.Properties.Resources.ClienteBracaFurioso;
            this.pictureBox2.Location = new System.Drawing.Point(977, 220);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(454, 653);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // lblSecondi
            // 
            this.lblSecondi.AutoSize = true;
            this.lblSecondi.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblSecondi.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecondi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSecondi.Location = new System.Drawing.Point(724, 528);
            this.lblSecondi.Name = "lblSecondi";
            this.lblSecondi.Size = new System.Drawing.Size(42, 46);
            this.lblSecondi.TabIndex = 5;
            this.lblSecondi.Text = "0";
            // 
            // lblSoldi
            // 
            this.lblSoldi.AutoSize = true;
            this.lblSoldi.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblSoldi.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoldi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSoldi.Location = new System.Drawing.Point(724, 599);
            this.lblSoldi.Name = "lblSoldi";
            this.lblSoldi.Size = new System.Drawing.Size(42, 46);
            this.lblSoldi.TabIndex = 6;
            this.lblSoldi.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CheeseChase_V0._0._1.Properties.Resources.GameOver;
            this.pictureBox1.Location = new System.Drawing.Point(343, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(524, 821);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.s);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(676, 599);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 46);
            this.label1.TabIndex = 8;
            this.label1.Text = "€";
            // 
            // formEnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CheeseChase_V0._0._1.Properties.Resources.start_sfondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1443, 857);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSoldi);
            this.Controls.Add(this.lblSecondi);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formEnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheesChase";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblSecondi;
        private System.Windows.Forms.Label lblSoldi;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}