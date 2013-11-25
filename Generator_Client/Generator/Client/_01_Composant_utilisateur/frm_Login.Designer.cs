namespace Generator
{
    partial class frm_Login
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Login));
            this.btn_Connection = new System.Windows.Forms.Button();
            this.grp_Login = new System.Windows.Forms.GroupBox();
            this.txt_PWD = new System.Windows.Forms.TextBox();
            this.lbl_PWD = new System.Windows.Forms.Label();
            this.lbl_Login = new System.Windows.Forms.Label();
            this.txt_Login = new System.Windows.Forms.TextBox();
            this.img_Logo = new System.Windows.Forms.PictureBox();
            this.btn_Quitter = new System.Windows.Forms.Button();
            this.grp_Login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Connection
            // 
            this.btn_Connection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Connection.Location = new System.Drawing.Point(348, 65);
            this.btn_Connection.Name = "btn_Connection";
            this.btn_Connection.Size = new System.Drawing.Size(75, 23);
            this.btn_Connection.TabIndex = 0;
            this.btn_Connection.Text = "&Connexion";
            this.btn_Connection.UseVisualStyleBackColor = true;
            this.btn_Connection.Click += new System.EventHandler(this.btn_Connection_Click);
            // 
            // grp_Login
            // 
            this.grp_Login.Controls.Add(this.txt_PWD);
            this.grp_Login.Controls.Add(this.lbl_PWD);
            this.grp_Login.Controls.Add(this.lbl_Login);
            this.grp_Login.Controls.Add(this.txt_Login);
            this.grp_Login.Controls.Add(this.btn_Connection);
            this.grp_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_Login.Location = new System.Drawing.Point(172, 450);
            this.grp_Login.Name = "grp_Login";
            this.grp_Login.Size = new System.Drawing.Size(429, 95);
            this.grp_Login.TabIndex = 1;
            this.grp_Login.TabStop = false;
            this.grp_Login.Text = "Authentification";
            // 
            // txt_PWD
            // 
            this.txt_PWD.BackColor = System.Drawing.Color.Black;
            this.txt_PWD.ForeColor = System.Drawing.Color.White;
            this.txt_PWD.Location = new System.Drawing.Point(123, 39);
            this.txt_PWD.Name = "txt_PWD";
            this.txt_PWD.PasswordChar = '*';
            this.txt_PWD.Size = new System.Drawing.Size(300, 20);
            this.txt_PWD.TabIndex = 4;
            // 
            // lbl_PWD
            // 
            this.lbl_PWD.AutoSize = true;
            this.lbl_PWD.Location = new System.Drawing.Point(6, 42);
            this.lbl_PWD.Name = "lbl_PWD";
            this.lbl_PWD.Size = new System.Drawing.Size(91, 13);
            this.lbl_PWD.TabIndex = 3;
            this.lbl_PWD.Text = "Mot de passe :";
            // 
            // lbl_Login
            // 
            this.lbl_Login.AutoSize = true;
            this.lbl_Login.Location = new System.Drawing.Point(6, 16);
            this.lbl_Login.Name = "lbl_Login";
            this.lbl_Login.Size = new System.Drawing.Size(46, 13);
            this.lbl_Login.TabIndex = 2;
            this.lbl_Login.Text = "Login :";
            // 
            // txt_Login
            // 
            this.txt_Login.BackColor = System.Drawing.Color.Black;
            this.txt_Login.ForeColor = System.Drawing.Color.White;
            this.txt_Login.Location = new System.Drawing.Point(123, 13);
            this.txt_Login.Name = "txt_Login";
            this.txt_Login.Size = new System.Drawing.Size(300, 20);
            this.txt_Login.TabIndex = 1;
            // 
            // img_Logo
            // 
            this.img_Logo.ImageLocation = "C:\\Users\\EMO_Kevin\\Documents\\GeneratorNET\\Generator_Client\\Generator_Logo.png";
            this.img_Logo.Location = new System.Drawing.Point(172, 12);
            this.img_Logo.Name = "img_Logo";
            this.img_Logo.Size = new System.Drawing.Size(429, 429);
            this.img_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_Logo.TabIndex = 2;
            this.img_Logo.TabStop = false;
            // 
            // btn_Quitter
            // 
            this.btn_Quitter.Location = new System.Drawing.Point(693, 515);
            this.btn_Quitter.Name = "btn_Quitter";
            this.btn_Quitter.Size = new System.Drawing.Size(75, 23);
            this.btn_Quitter.TabIndex = 3;
            this.btn_Quitter.Text = "&Quitter";
            this.btn_Quitter.UseVisualStyleBackColor = true;
            this.btn_Quitter.Click += new System.EventHandler(this.btn_Quitter_Click);
            // 
            // frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(780, 557);
            this.Controls.Add(this.btn_Quitter);
            this.Controls.Add(this.img_Logo);
            this.Controls.Add(this.grp_Login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_Login";
            this.Text = "Generator";
            this.Load += new System.EventHandler(this.frm_Login_Load);
            this.grp_Login.ResumeLayout(false);
            this.grp_Login.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Connection;
        private System.Windows.Forms.GroupBox grp_Login;
        private System.Windows.Forms.PictureBox img_Logo;
        private System.Windows.Forms.TextBox txt_PWD;
        private System.Windows.Forms.Label lbl_PWD;
        private System.Windows.Forms.Label lbl_Login;
        private System.Windows.Forms.TextBox txt_Login;
        private System.Windows.Forms.Button btn_Quitter;
    }
}

