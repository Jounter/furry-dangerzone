namespace ePubApp
{
    partial class Configs
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
            this.btnPath = new System.Windows.Forms.Button();
            this.Path = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtWSPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnWSPath = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(257, 63);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(75, 23);
            this.btnPath.TabIndex = 0;
            this.btnPath.Text = "...";
            this.btnPath.UseVisualStyleBackColor = true;
            // 
            // Path
            // 
            this.Path.AutoSize = true;
            this.Path.Location = new System.Drawing.Point(37, 36);
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(29, 13);
            this.Path.TabIndex = 1;
            this.Path.Text = "Path";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(40, 63);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(202, 20);
            this.txtPath.TabIndex = 2;
            // 
            // txtWSPath
            // 
            this.txtWSPath.Location = new System.Drawing.Point(40, 134);
            this.txtWSPath.Name = "txtWSPath";
            this.txtWSPath.Size = new System.Drawing.Size(202, 20);
            this.txtWSPath.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Web Service";
            // 
            // btnWSPath
            // 
            this.btnWSPath.Location = new System.Drawing.Point(257, 134);
            this.btnWSPath.Name = "btnWSPath";
            this.btnWSPath.Size = new System.Drawing.Size(75, 23);
            this.btnWSPath.TabIndex = 5;
            this.btnWSPath.Text = "...";
            this.btnWSPath.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(153, 197);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // Configs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 255);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnWSPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtWSPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.Path);
            this.Controls.Add(this.btnPath);
            this.Name = "Configs";
            this.Text = "Configs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.Label Path;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.TextBox txtWSPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnWSPath;
        private System.Windows.Forms.Button btnExit;
    }
}