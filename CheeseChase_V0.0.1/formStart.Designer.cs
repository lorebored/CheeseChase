namespace CheeseChase_V0._0._1
{
    partial class FormStart
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStart));
            this.btnStart = new System.Windows.Forms.Button();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.cbDifficolta = new System.Windows.Forms.ComboBox();
            this.lblDifficolta = new System.Windows.Forms.Label();
            this.lblDiff = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Khaki;
            this.btnStart.Location = new System.Drawing.Point(489, 204);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(475, 88);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "INIZIA PARTITA";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(489, 165);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(197, 32);
            this.txtNome.TabIndex = 1;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.BackColor = System.Drawing.Color.Khaki;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.ForeColor = System.Drawing.Color.Black;
            this.lblNome.Location = new System.Drawing.Point(485, 142);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(201, 20);
            this.lblNome.TabIndex = 2;
            this.lblNome.Text = "INSERISCI IL TUO NOME:";
            // 
            // cbDifficolta
            // 
            this.cbDifficolta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDifficolta.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDifficolta.FormattingEnabled = true;
            this.cbDifficolta.Location = new System.Drawing.Point(746, 165);
            this.cbDifficolta.Name = "cbDifficolta";
            this.cbDifficolta.Size = new System.Drawing.Size(218, 33);
            this.cbDifficolta.TabIndex = 3;
            // 
            // lblDifficolta
            // 
            this.lblDifficolta.AutoSize = true;
            this.lblDifficolta.BackColor = System.Drawing.Color.Transparent;
            this.lblDifficolta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifficolta.ForeColor = System.Drawing.Color.White;
            this.lblDifficolta.Location = new System.Drawing.Point(587, -62);
            this.lblDifficolta.Name = "lblDifficolta";
            this.lblDifficolta.Size = new System.Drawing.Size(222, 20);
            this.lblDifficolta.TabIndex = 4;
            this.lblDifficolta.Text = "SELEZIONA LA DIFFICOLTA";
            // 
            // lblDiff
            // 
            this.lblDiff.AutoSize = true;
            this.lblDiff.BackColor = System.Drawing.Color.Khaki;
            this.lblDiff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiff.ForeColor = System.Drawing.Color.Black;
            this.lblDiff.Location = new System.Drawing.Point(743, 142);
            this.lblDiff.Name = "lblDiff";
            this.lblDiff.Size = new System.Drawing.Size(222, 20);
            this.lblDiff.TabIndex = 5;
            this.lblDiff.Text = "SELEZIONA LA DIFFICOLTA";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CheeseChase_V0._0._1.Properties.Resources.Regole;
            this.pictureBox1.Location = new System.Drawing.Point(259, 299);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(945, 549);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // FormStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1443, 857);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblDiff);
            this.Controls.Add(this.lblDifficolta);
            this.Controls.Add(this.cbDifficolta);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.btnStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1459, 896);
            this.MinimumSize = new System.Drawing.Size(1459, 896);
            this.Name = "FormStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheesChase";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.ComboBox cbDifficolta;
        private System.Windows.Forms.Label lblDifficolta;
        private System.Windows.Forms.Label lblDiff;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

