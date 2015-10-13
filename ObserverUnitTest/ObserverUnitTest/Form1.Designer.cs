namespace ObserverUnitTest
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statuskok = new System.Windows.Forms.Label();
            this.bestelwachtlijst = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.bestellinggeplaatst = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(397, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(186, 191);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(394, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ik ben bezig met";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // statuskok
            // 
            this.statuskok.AutoSize = true;
            this.statuskok.Location = new System.Drawing.Point(485, 222);
            this.statuskok.Name = "statuskok";
            this.statuskok.Size = new System.Drawing.Size(55, 13);
            this.statuskok.TabIndex = 2;
            this.statuskok.Text = "nadenken";
            // 
            // bestelwachtlijst
            // 
            this.bestelwachtlijst.FormattingEnabled = true;
            this.bestelwachtlijst.Location = new System.Drawing.Point(12, 62);
            this.bestelwachtlijst.Name = "bestelwachtlijst";
            this.bestelwachtlijst.Size = new System.Drawing.Size(356, 173);
            this.bestelwachtlijst.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "appelmoes met frietjes",
            "steak met curry saus",
            "dame blanche"});
            this.comboBox1.Location = new System.Drawing.Point(13, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(253, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // bestellinggeplaatst
            // 
            this.bestellinggeplaatst.Location = new System.Drawing.Point(272, 19);
            this.bestellinggeplaatst.Name = "bestellinggeplaatst";
            this.bestellinggeplaatst.Size = new System.Drawing.Size(96, 23);
            this.bestellinggeplaatst.TabIndex = 5;
            this.bestellinggeplaatst.Text = "Voeg recept toe";
            this.bestellinggeplaatst.UseVisualStyleBackColor = true;
            this.bestellinggeplaatst.Click += new System.EventHandler(this.bestellinggeplaatst_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 262);
            this.Controls.Add(this.bestellinggeplaatst);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.bestelwachtlijst);
            this.Controls.Add(this.statuskok);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Kok met recepten";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label statuskok;
        private System.Windows.Forms.ListBox bestelwachtlijst;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button bestellinggeplaatst;
    }
}

