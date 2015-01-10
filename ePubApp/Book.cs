using eBdb.EpubReader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ePubApp
{
    public partial class Book : Form
    {
        Epub book;
        Boolean tocAvailable;

        public Book(Epub book)
        {
            InitializeComponent();

            this.book = book;

            insertSpecs();

            loadContents();

            if (tocAvailable == false)
            {
                ReadChapter.Enabled = false;
            }

        }

        private void insertSpecs()
        {
            try
            {
                string title = book.Title[0];
                lblTitle.Text = title;
            }
            catch (Exception)
            {
                string title = "Anonymous";
                lblTitle.Text = title;
            }

            try
            {
                string author = book.Creator[0];
                lblAuthor.Text = author;
            }
            catch (Exception)
            {
                string author = "Anonymous";
                lblAuthor.Text = author;
            }

            try
            {
                string publisher = book.Publisher[0];
                lblPub.Text = publisher;
            }
            catch (Exception)
            {
                string publisher = "Anonymous";
                lblPub.Text = publisher;
            }

            try
            {
                string subject = book.Subject[0];
                lblPub.Text = subject;
            }
            catch (Exception)
            {
                string subject = "No subject";
                txtSubject.Text = subject;
            }
        }

        private void loadContents()
        {
            var navPoints = new List<NavPoint>();
            navPoints = book.TOC;

            if (navPoints.Count != 0) //se não existirem navPoints
            {
                tocAvailable = true;
                foreach (NavPoint item in navPoints)
                {
                    listBox1.Items.Add(item.Title);
                }
            }
            else
            {
                tocAvailable = false;
                int chIdx = 0;
                foreach (DictionaryEntry item in book.Content)
                {
                    chIdx++;
                    listBox1.Items.Add("Chapter " + chIdx);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {

        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            string htmlText = book.GetContentAsHtml();

            webBrowser1.DocumentText = htmlText;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ReadChapter_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;

            var navPoints = new List<NavPoint>();
            navPoints = book.TOC;

            String contentData = navPoints[selectedIndex].ContentData.Content;

            webBrowser1.DocumentText = contentData;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void btnBookmarkChapter_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;

            var navPoints = new List<NavPoint>();
            navPoints = book.TOC;

            foreach (NavPoint item in navPoints)
            {
                listBox1.Items.Add(item.Title);
            }
        }
    }
}
