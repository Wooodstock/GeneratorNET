namespace Generator
{
    partial class frm_Generator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Generator));
            this.btn_Parcourir = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lst_Files = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Dechiffrer = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Quitter = new System.Windows.Forms.Button();
            this.btn_Delete_File = new System.Windows.Forms.Button();
            this.lbl_NB_Files = new System.Windows.Forms.Label();
            this.btn_Ouvrir = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Parcourir
            // 
            this.btn_Parcourir.Location = new System.Drawing.Point(693, 239);
            this.btn_Parcourir.Name = "btn_Parcourir";
            this.btn_Parcourir.Size = new System.Drawing.Size(75, 23);
            this.btn_Parcourir.TabIndex = 0;
            this.btn_Parcourir.Text = "&Parcourir";
            this.btn_Parcourir.UseVisualStyleBackColor = true;
            this.btn_Parcourir.Click += new System.EventHandler(this.btn_Parcourir_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Fichiers .txt|*.txt";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Veuillez sélectionner les fichiers à déchiffrer.";
            // 
            // lst_Files
            // 
            this.lst_Files.BackColor = System.Drawing.Color.Black;
            this.lst_Files.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_Files.ForeColor = System.Drawing.Color.White;
            this.lst_Files.FormattingEnabled = true;
            this.lst_Files.Location = new System.Drawing.Point(12, 272);
            this.lst_Files.Name = "lst_Files";
            this.lst_Files.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lst_Files.Size = new System.Drawing.Size(756, 238);
            this.lst_Files.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Veuillez sélectionner les fichiers à déchiffrer :";
            // 
            // btn_Dechiffrer
            // 
            this.btn_Dechiffrer.Location = new System.Drawing.Point(612, 522);
            this.btn_Dechiffrer.Name = "btn_Dechiffrer";
            this.btn_Dechiffrer.Size = new System.Drawing.Size(75, 23);
            this.btn_Dechiffrer.TabIndex = 4;
            this.btn_Dechiffrer.Text = "&Déchiffrer";
            this.btn_Dechiffrer.UseVisualStyleBackColor = true;
            this.btn_Dechiffrer.Click += new System.EventHandler(this.btn_Dechiffrer_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ImageLocation = "C:\\Users\\EMO_Kevin\\Documents\\GeneratorNET\\Generator_Client\\Generator_Name.png";
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(756, 221);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Quitter
            // 
            this.btn_Quitter.Location = new System.Drawing.Point(693, 522);
            this.btn_Quitter.Name = "btn_Quitter";
            this.btn_Quitter.Size = new System.Drawing.Size(75, 23);
            this.btn_Quitter.TabIndex = 6;
            this.btn_Quitter.Text = "&Quitter";
            this.btn_Quitter.UseVisualStyleBackColor = true;
            this.btn_Quitter.Click += new System.EventHandler(this.btn_Quitter_Click);
            // 
            // btn_Delete_File
            // 
            this.btn_Delete_File.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete_File.Location = new System.Drawing.Point(612, 239);
            this.btn_Delete_File.Name = "btn_Delete_File";
            this.btn_Delete_File.Size = new System.Drawing.Size(75, 23);
            this.btn_Delete_File.TabIndex = 7;
            this.btn_Delete_File.Text = "&Supprimer";
            this.btn_Delete_File.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Delete_File.UseVisualStyleBackColor = true;
            this.btn_Delete_File.Click += new System.EventHandler(this.btn_Delete_File_Click);
            // 
            // lbl_NB_Files
            // 
            this.lbl_NB_Files.AutoSize = true;
            this.lbl_NB_Files.Location = new System.Drawing.Point(12, 527);
            this.lbl_NB_Files.Name = "lbl_NB_Files";
            this.lbl_NB_Files.Size = new System.Drawing.Size(101, 13);
            this.lbl_NB_Files.TabIndex = 9;
            this.lbl_NB_Files.Text = "0 fichier sélectionné";
            // 
            // btn_Ouvrir
            // 
            this.btn_Ouvrir.Location = new System.Drawing.Point(531, 239);
            this.btn_Ouvrir.Name = "btn_Ouvrir";
            this.btn_Ouvrir.Size = new System.Drawing.Size(75, 23);
            this.btn_Ouvrir.TabIndex = 10;
            this.btn_Ouvrir.Text = "&Ouvrir";
            this.btn_Ouvrir.UseVisualStyleBackColor = true;
            this.btn_Ouvrir.Click += new System.EventHandler(this.btn_Ouvrir_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(29, 24);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(739, 212);
            this.listBox1.TabIndex = 11;
            // 
            // frm_Generator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(780, 557);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btn_Ouvrir);
            this.Controls.Add(this.lbl_NB_Files);
            this.Controls.Add(this.btn_Delete_File);
            this.Controls.Add(this.btn_Quitter);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_Dechiffrer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lst_Files);
            this.Controls.Add(this.btn_Parcourir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_Generator";
            this.Text = "Generator";
            this.Load += new System.EventHandler(this.frm_Generator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Parcourir;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox lst_Files;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Dechiffrer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Quitter;
        private System.Windows.Forms.Button btn_Delete_File;
        private System.Windows.Forms.Label lbl_NB_Files;
        private System.Windows.Forms.Button btn_Ouvrir;
        private System.Windows.Forms.ListBox listBox1;




    }
}