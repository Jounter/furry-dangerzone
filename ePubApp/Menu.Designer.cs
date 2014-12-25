namespace ePubApp
{
    partial class Menu
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfigs = new System.Windows.Forms.Button();
            this.btnStats = new System.Windows.Forms.Button();
            this.btnBM = new System.Windows.Forms.Button();
            this.btnFavs = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(41, 61);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(195, 251);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lista Livros";
            // 
            // btnConfigs
            // 
            this.btnConfigs.Location = new System.Drawing.Point(313, 73);
            this.btnConfigs.Name = "btnConfigs";
            this.btnConfigs.Size = new System.Drawing.Size(75, 23);
            this.btnConfigs.TabIndex = 2;
            this.btnConfigs.Text = "Configs";
            this.btnConfigs.UseVisualStyleBackColor = true;
            // 
            // btnStats
            // 
            this.btnStats.Location = new System.Drawing.Point(313, 125);
            this.btnStats.Name = "btnStats";
            this.btnStats.Size = new System.Drawing.Size(75, 23);
            this.btnStats.TabIndex = 3;
            this.btnStats.Text = "Stats";
            this.btnStats.UseVisualStyleBackColor = true;
            // 
            // btnBM
            // 
            this.btnBM.Location = new System.Drawing.Point(313, 174);
            this.btnBM.Name = "btnBM";
            this.btnBM.Size = new System.Drawing.Size(75, 23);
            this.btnBM.TabIndex = 4;
            this.btnBM.Text = "Bookmarks";
            this.btnBM.UseVisualStyleBackColor = true;
            // 
            // btnFavs
            // 
            this.btnFavs.Location = new System.Drawing.Point(313, 223);
            this.btnFavs.Name = "btnFavs";
            this.btnFavs.Size = new System.Drawing.Size(75, 23);
            this.btnFavs.TabIndex = 5;
            this.btnFavs.Text = "Favorites";
            this.btnFavs.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(313, 276);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 373);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnFavs);
            this.Controls.Add(this.btnBM);
            this.Controls.Add(this.btnStats);
            this.Controls.Add(this.btnConfigs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfigs;
        private System.Windows.Forms.Button btnStats;
        private System.Windows.Forms.Button btnBM;
        private System.Windows.Forms.Button btnFavs;
        private System.Windows.Forms.Button btnLogout;


    }
}