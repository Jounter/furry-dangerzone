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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
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
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Book List";
            // 
            // btnConfigs
            // 
            this.btnConfigs.Location = new System.Drawing.Point(282, 60);
            this.btnConfigs.Name = "btnConfigs";
            this.btnConfigs.Size = new System.Drawing.Size(75, 23);
            this.btnConfigs.TabIndex = 2;
            this.btnConfigs.Text = "Configs";
            this.btnConfigs.UseVisualStyleBackColor = true;
            this.btnConfigs.Click += new System.EventHandler(this.btnConfigs_Click);
            // 
            // btnStats
            // 
            this.btnStats.Location = new System.Drawing.Point(282, 107);
            this.btnStats.Name = "btnStats";
            this.btnStats.Size = new System.Drawing.Size(75, 23);
            this.btnStats.TabIndex = 3;
            this.btnStats.Text = "Stats";
            this.btnStats.UseVisualStyleBackColor = true;
            this.btnStats.Click += new System.EventHandler(this.btnStats_Click);
            // 
            // btnBM
            // 
            this.btnBM.Location = new System.Drawing.Point(282, 150);
            this.btnBM.Name = "btnBM";
            this.btnBM.Size = new System.Drawing.Size(75, 23);
            this.btnBM.TabIndex = 4;
            this.btnBM.Text = "Bookmarks";
            this.btnBM.UseVisualStyleBackColor = true;
            this.btnBM.Click += new System.EventHandler(this.btnBM_Click);
            // 
            // btnFavs
            // 
            this.btnFavs.Location = new System.Drawing.Point(282, 197);
            this.btnFavs.Name = "btnFavs";
            this.btnFavs.Size = new System.Drawing.Size(75, 23);
            this.btnFavs.TabIndex = 5;
            this.btnFavs.Text = "Favorites";
            this.btnFavs.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(282, 289);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(70, 318);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Read Selected Book";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(282, 242);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Synchronize";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 373);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnFavs);
            this.Controls.Add(this.btnBM);
            this.Controls.Add(this.btnStats);
            this.Controls.Add(this.btnConfigs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;


    }
}