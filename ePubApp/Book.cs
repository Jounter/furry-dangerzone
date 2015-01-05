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

            epub = new Epub(@"D:\\Escola\\1Semestre\\IS\\projeto\\trunk\\ePubBooks\\ebookExample2.ePub");

            string title = epub.Title[0];
            string author = epub.Creator[0];

            lblAuthor.Text = author;
            lblTitle.Text = title;

            loadContents(epub);

        }

        private void loadContents(Epub epub)
        {
            NavPoint navPoints = epub.TOC;

            if (navPoints.Count != 0) //se não existirem navPoints
            {
                tocAvailable = true;
                foreach (NavPoint item in navPoints)
                {
                    listBox.Items.Add(item.Title);
                }
            }
            else
            {
                tocAvailable = false;
                int chIdx = 0;
                foreach (DictionaryEntry item in _epub.Content)
                {
                    chIdx++;
                    listBox.Items.Add("Chapter " + chIdx);
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
            string htmlText = epub.GetContentAsHtml();

            webBrowser1.DocumentText = htmlText;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ContentData contentData = epub.Content[0] as ContentData;
        }
    }
}
