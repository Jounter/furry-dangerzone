namespace ePubApp
{
    partial class Book
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnAll = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnFavorite = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblPub = new System.Windows.Forms.Label();
            this.ReadChapter = new System.Windows.Forms.Button();
            this.btnBookmarkChapter = new System.Windows.Forms.Button();
            this.btnFavoriteChapter = new System.Windows.Forms.Button();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chapters";
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(35, 304);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(168, 23);
            this.btnAll.TabIndex = 2;
            this.btnAll.Text = "Read All Chapters";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 414);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Title:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 438);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Author:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(441, 411);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Subject:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 463);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Publisher:";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(235, 9);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(795, 389);
            this.webBrowser1.TabIndex = 7;
            // 
            // btnFavorite
            // 
            this.btnFavorite.Location = new System.Drawing.Point(37, 414);
            this.btnFavorite.Name = "btnFavorite";
            this.btnFavorite.Size = new System.Drawing.Size(167, 23);
            this.btnFavorite.TabIndex = 9;
            this.btnFavorite.Text = "Mark This Book As Favorite";
            this.btnFavorite.UseVisualStyleBackColor = true;
            this.btnFavorite.Click += new System.EventHandler(this.btnFavorite_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(81, 453);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(276, 414);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(33, 13);
            this.lblTitle.TabIndex = 13;
            this.lblTitle.Text = "Titulo";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(288, 438);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(32, 13);
            this.lblAuthor.TabIndex = 14;
            this.lblAuthor.Text = "Autor";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(35, 25);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(168, 238);
            this.listBox1.TabIndex = 15;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // lblPub
            // 
            this.lblPub.AutoSize = true;
            this.lblPub.Location = new System.Drawing.Point(296, 463);
            this.lblPub.Name = "lblPub";
            this.lblPub.Size = new System.Drawing.Size(50, 13);
            this.lblPub.TabIndex = 16;
            this.lblPub.Text = "Publisher";
            // 
            // ReadChapter
            // 
            this.ReadChapter.Location = new System.Drawing.Point(35, 275);
            this.ReadChapter.Name = "ReadChapter";
            this.ReadChapter.Size = new System.Drawing.Size(168, 23);
            this.ReadChapter.TabIndex = 18;
            this.ReadChapter.Text = "Read Chapter";
            this.ReadChapter.UseVisualStyleBackColor = true;
            this.ReadChapter.Click += new System.EventHandler(this.ReadChapter_Click);
            // 
            // btnBookmarkChapter
            // 
            this.btnBookmarkChapter.Location = new System.Drawing.Point(36, 346);
            this.btnBookmarkChapter.Name = "btnBookmarkChapter";
            this.btnBookmarkChapter.Size = new System.Drawing.Size(168, 23);
            this.btnBookmarkChapter.TabIndex = 19;
            this.btnBookmarkChapter.Text = "Bookmark Selected Chapter";
            this.btnBookmarkChapter.UseVisualStyleBackColor = true;
            this.btnBookmarkChapter.Click += new System.EventHandler(this.btnBookmarkChapter_Click);
            // 
            // btnFavoriteChapter
            // 
            this.btnFavoriteChapter.Location = new System.Drawing.Point(36, 375);
            this.btnFavoriteChapter.Name = "btnFavoriteChapter";
            this.btnFavoriteChapter.Size = new System.Drawing.Size(167, 23);
            this.btnFavoriteChapter.TabIndex = 20;
            this.btnFavoriteChapter.Text = "Favorite Selected Chapter";
            this.btnFavoriteChapter.UseVisualStyleBackColor = true;
            this.btnFavoriteChapter.Click += new System.EventHandler(this.btnFavoriteChapter_Click);
            // 
            // txtSubject
            // 
            this.txtSubject.Enabled = false;
            this.txtSubject.Location = new System.Drawing.Point(493, 411);
            this.txtSubject.Multiline = true;
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(518, 62);
            this.txtSubject.TabIndex = 21;
            // 
            // Book
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 485);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.btnFavoriteChapter);
            this.Controls.Add(this.btnBookmarkChapter);
            this.Controls.Add(this.ReadChapter);
            this.Controls.Add(this.lblPub);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnFavorite);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.label1);
            this.Name = "Book";
            this.Text = "Book";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btnFavorite;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lblPub;
        private System.Windows.Forms.Button ReadChapter;
        private System.Windows.Forms.Button btnBookmarkChapter;
        private System.Windows.Forms.Button btnFavoriteChapter;
        private System.Windows.Forms.TextBox txtSubject;
    }
}