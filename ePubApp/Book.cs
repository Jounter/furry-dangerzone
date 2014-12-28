using eBdb.EpubReader;
using System;
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
        Epub epub;

        public Book()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            epub = new Epub(@"D:\\Escola\\1Semestre\\IS\\projeto\\trunk\\ePubBooks");

            string title = epub.Title[0];
            string author = epub.Creator[0];

            lblAuthor.Text = author;
            lblTitle.Text = title;

            List<NavPoint> navPoints = epub.TOC;

            listBox1.DataSource = navPoints;

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {

        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            string htmlText = epub.GetContentAsHtml();

            webBrowser1.DocumentText = htmlText;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContentData contentData = epub.Content[0] as ContentData;
        }
    }
}
