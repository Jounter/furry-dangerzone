using eBdb.EpubReader;
using ePubApp.ServiceReference1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ePubApp
{
    public partial class Book : Form
    {
        Epub book;
        Boolean tocAvailable;
        string logedUser;
        Service1Client serv;
        Boolean isFavorite;

        public Book(Epub book, string Username)
        {
            InitializeComponent();

            this.book = book;
            this.logedUser = Username;
            serv = new Service1Client();

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
            try
            {
                string chapterTitle = listBox1.SelectedItem.ToString();
                int chapterNumber = listBox1.SelectedIndex;
                isFavorite = false;
                sendBookMarkFavXml(chapterTitle, chapterNumber, isFavorite);
            }
            catch (Exception)
            {
                MessageBox.Show("Selecione um capitulo para adicionar aos favoritos!");
            }

        }

        private void btnFavorite_Click(object sender, EventArgs e)
        {
            isFavorite = true;
            sendBookMarkFavXml(null, -1, isFavorite);
        }

        private void sendBookMarkFavXml(String chapterTitle, int chapterNumber, Boolean isFavorite)
        {
            XmlDocument xml = new XmlDocument();
            XmlNode rootNode;

            XmlDeclaration xmlDeclaration = xml.CreateXmlDeclaration("1.0", "UTF-8", null);
            xml.AppendChild(xmlDeclaration);
            if (isFavorite)
            {
                rootNode = xml.CreateElement("favorite");
                //XmlAttribute attribute = xml.CreateAttribute("xmlns");
                //attribute.Value = "http://tempuri.org/XMLSchema.xsd";
                //rootNode.Attributes.Append(attribute);
                xml.AppendChild(rootNode);
            }
            else
            {
                rootNode = xml.CreateElement("bookmark");
                xml.AppendChild(rootNode);
            }

            XmlNode eownerNode = xml.CreateElement("owner");
            eownerNode.InnerText = logedUser;
            rootNode.AppendChild(eownerNode);

            XmlNode bookNode = xml.CreateElement("book");
            rootNode.AppendChild(bookNode);

            XmlNode titleNode = xml.CreateElement("title");

            try
            {
                titleNode.InnerText = book.Title[0];
            }
            catch (Exception)
            {
                string title = "Anonymous";
                titleNode.InnerText = title;
            }

            bookNode.AppendChild(titleNode);

            XmlNode authorNode = xml.CreateElement("author");

            try
            {
                authorNode.InnerText = book.Creator[0];
            }
            catch (Exception)
            {
                string author = "Anonymous";
                authorNode.InnerText = author;
            }

            bookNode.AppendChild(authorNode);

            XmlNode publisherNode = xml.CreateElement("publisher");

            try
            {
                publisherNode.InnerText = book.Publisher[0];
            }
            catch (Exception)
            {
                string publisher = "Anonymous";
                publisherNode.InnerText = publisher;
            }

            bookNode.AppendChild(publisherNode);

            XmlNode dateNode = xml.CreateElement("date");
            dateNode.InnerText = System.DateTime.Now.ToString();
            rootNode.AppendChild(dateNode);

            if (chapterTitle != null && chapterNumber >= 0)
            {
                XmlNode chapterNode = xml.CreateElement("chapter");
                rootNode.AppendChild(chapterNode);

                XmlNode nameNode = xml.CreateElement("chaptername");
                nameNode.InnerText = chapterTitle;
                chapterNode.AppendChild(nameNode);

                XmlNode numberNode = xml.CreateElement("chapternumber");
                numberNode.InnerText = chapterNumber + "";
                chapterNode.AppendChild(numberNode);
            }


            string xmlOutput = xml.OuterXml;


            string path2 = System.IO.Directory.GetCurrentDirectory();

            System.IO.DirectoryInfo directoryInfo =
                System.IO.Directory.GetParent(path2);


            System.IO.DirectoryInfo directoryInfo2 =
                System.IO.Directory.GetParent(directoryInfo.ToString());

            if (isFavorite)
            {
                MyXMLHandler xmlValidated = new MyXMLHandler(xmlOutput, directoryInfo2 + "\\xsd\\FavoriteSchema.xsd");
                bool valid = xmlValidated.ValidateXML();

                if (valid)
                {
                    serv.CreateFavorite(xmlOutput);
                    MessageBox.Show("Adicionado aos favoritos!");
                }
                else
                {
                    MessageBox.Show("Nao foi possivel adicionar aos favoritos!");
                }
            }
            else
            {
                MyXMLHandler xmlValidated = new MyXMLHandler(xmlOutput, directoryInfo2 + "\\xsd\\BookmarkSchema.xsd");
                bool valid = xmlValidated.ValidateXML();

                if (valid)
                {
                    //serv.CreateBookmark(xmlOutput);
                    MessageBox.Show("Adicionado aos bookmarks!");
                    string folderpath = Directory.GetCurrentDirectory();
                    xml.Save(folderpath + "\\Bookmarks.xml");
                }
                else
                {
                    MessageBox.Show("Nao foi possivel adicionar aos favoritos!");
                }
            }
            

           

        }

        private void btnFavoriteChapter_Click(object sender, EventArgs e)
        {
            try
            {
                string chapterTitle = listBox1.SelectedItem.ToString();
                int chapterNumber = listBox1.SelectedIndex;
                isFavorite = true;
                sendBookMarkFavXml(chapterTitle, chapterNumber, isFavorite); 
            }
            catch (Exception)
            {
                MessageBox.Show("Selecione um capitulo para adicionar aos favoritos!");
            }

        }
    }
}
