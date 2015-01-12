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
            //string chapterTitle = listBox1.SelectedItem.ToString();
            //serv.lastEbookRead(chapterTitle);
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
            if (listBox1.SelectedIndex >= 0)
            {
                string chapterTitle = listBox1.SelectedItem.ToString();
                int chapterNumber = listBox1.SelectedIndex;
                isFavorite = false;
                sendBookMarkFavXml(chapterTitle, chapterNumber, isFavorite);
            }else{
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

            XmlDocument xmlLocal = new XmlDocument();
            string folderpath = Directory.GetCurrentDirectory();

            Boolean localExists;
            try
            {
                if (!isFavorite)
                {
                    xmlLocal.Load(folderpath + "\\Bookmarks.xml");
                }
                else {
                    xmlLocal.Load(folderpath + "\\Favorites.xml");
                }
                
                localExists = true;
            }
            catch (Exception)
            {
                localExists = false;
            }
            
            

            XmlNode baseNodeLocal;

            XmlDeclaration xmlDeclaration = xml.CreateXmlDeclaration("1.0", "UTF-8", null);
            xml.AppendChild(xmlDeclaration);

            if (!localExists)
            {
                XmlDeclaration xmlDeclarationLocal = xmlLocal.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmlLocal.AppendChild(xmlDeclarationLocal);
            }



            if (isFavorite)
            {
                rootNode = xml.CreateElement("favorite");
                xml.AppendChild(rootNode);

                

                if (!localExists)
                {
                    XmlNode rootNodeLocal = xmlLocal.CreateElement("favorites");
                    xmlLocal.AppendChild(rootNodeLocal);
                    baseNodeLocal = xmlLocal.CreateElement("favorite");
                    rootNodeLocal.AppendChild(baseNodeLocal);
                }
                else
                {
                    baseNodeLocal = xmlLocal.CreateElement("favorite");
                    XmlElement rootNodeChild = xmlLocal.DocumentElement;
                    rootNodeChild.AppendChild(baseNodeLocal);
                }


            }
            else
            {
                rootNode = xml.CreateElement("bookmark");
                xml.AppendChild(rootNode);                
                

                if (!localExists)
                {
                    XmlNode rootNodeLocal = xmlLocal.CreateElement("bookmarks");
                    xmlLocal.AppendChild(rootNodeLocal);
                    baseNodeLocal = xmlLocal.CreateElement("bookmark");
                    rootNodeLocal.AppendChild(baseNodeLocal);
                }
                else
                {
                    baseNodeLocal = xmlLocal.CreateElement("bookmark");
                    XmlElement rootNodeChild = xmlLocal.DocumentElement;
                    rootNodeChild.AppendChild(baseNodeLocal);
                }
            }

            XmlNode eownerNode = xml.CreateElement("owner");
            eownerNode.InnerText = logedUser;
            rootNode.AppendChild(eownerNode);

            XmlNode eownerNodeLocal = xmlLocal.CreateElement("owner");
            eownerNodeLocal.InnerText = logedUser;
            baseNodeLocal.AppendChild(eownerNodeLocal);



            XmlNode bookNode = xml.CreateElement("book");
            rootNode.AppendChild(bookNode);

            XmlNode bookNodeLocal = xmlLocal.CreateElement("book");
            baseNodeLocal.AppendChild(bookNodeLocal);

            XmlNode titleNode = xml.CreateElement("bookname");
            XmlNode titleNodeLocal = xmlLocal.CreateElement("bookname");

            try
            {
                titleNode.InnerText = book.Title[0];
                titleNodeLocal.InnerText = book.Title[0];
            }
            catch (Exception)
            {
                string title = "Anonymous";
                titleNode.InnerText = title;
                titleNodeLocal.InnerText = title;
            }

            bookNode.AppendChild(titleNode);
            bookNodeLocal.AppendChild(titleNodeLocal);

            XmlNode authorNode = xml.CreateElement("author");
            XmlNode authorNodeLocal = xmlLocal.CreateElement("author");

            try
            {
                authorNode.InnerText = book.Creator[0];
                authorNodeLocal.InnerText = book.Creator[0];
            }
            catch (Exception)
            {
                string author = "Anonymous";
                authorNode.InnerText = author;
                authorNodeLocal.InnerText = author;
            }

            bookNode.AppendChild(authorNode);
            bookNodeLocal.AppendChild(authorNodeLocal);

            XmlNode publisherNode = xml.CreateElement("publisher");
            XmlNode publisherNodeLocal = xmlLocal.CreateElement("publisher");

            try
            {
                publisherNode.InnerText = book.Publisher[0];
                publisherNodeLocal.InnerText = book.Publisher[0];
            }
            catch (Exception)
            {
                string publisher = "Anonymous";
                publisherNode.InnerText = publisher;
                publisherNodeLocal.InnerText = publisher;
            }

            bookNode.AppendChild(publisherNode);
            bookNodeLocal.AppendChild(publisherNodeLocal);

            if (chapterTitle != null && chapterNumber >= 0)
            {
                XmlNode chapterNode = xml.CreateElement("chapter");
                bookNode.AppendChild(chapterNode);

                XmlNode nameNode = xml.CreateElement("chaptername");
                nameNode.InnerText = chapterTitle;
                chapterNode.AppendChild(nameNode);

                XmlNode numberNode = xml.CreateElement("chapternumber");
                numberNode.InnerText = chapterNumber + "";
                chapterNode.AppendChild(numberNode);



                XmlNode chapterNodeLocal = xmlLocal.CreateElement("chapter");
                bookNodeLocal.AppendChild(chapterNodeLocal);

                XmlNode nameNodeLocal = xmlLocal.CreateElement("chaptername");
                nameNodeLocal.InnerText = chapterTitle;
                chapterNodeLocal.AppendChild(nameNodeLocal);

                XmlNode numberNodeLocal = xmlLocal.CreateElement("chapternumber");
                numberNodeLocal.InnerText = chapterNumber + "";
                chapterNodeLocal.AppendChild(numberNodeLocal);
            }

            XmlNode dateNode = xml.CreateElement("date");
            dateNode.InnerText = System.DateTime.Now.ToString();
            rootNode.AppendChild(dateNode);

            XmlNode dateNodeLocal = xmlLocal.CreateElement("date");
            dateNodeLocal.InnerText = System.DateTime.Now.ToString();
            baseNodeLocal.AppendChild(dateNodeLocal);


            string xmlOutput = xml.OuterXml;
            string xmlOutputLocal = xmlLocal.OuterXml;


            string path2 = System.IO.Directory.GetCurrentDirectory();

            System.IO.DirectoryInfo directoryInfo =
                System.IO.Directory.GetParent(path2);


            System.IO.DirectoryInfo directoryInfo2 =
                System.IO.Directory.GetParent(directoryInfo.ToString());

            if (isFavorite)
            {
                MyXMLHandler xmlValidated = new MyXMLHandler(xmlOutput, directoryInfo2 + "\\xsd\\FavoriteSchema.xsd");
                bool valid = xmlValidated.ValidateXML();

                MyXMLHandler xmlValidatedLocal = new MyXMLHandler(xmlOutputLocal, directoryInfo2 + "\\xsd\\FavoriteLocalSchema.xsd");
                bool validLocal = xmlValidatedLocal.ValidateXML();

                if (valid && validLocal)
                {
                    string m = serv.CreateFavorite(xmlOutput);

                    xmlLocal.Save(folderpath + "\\Favorites.xml");

                    MessageBox.Show(m);
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

                MyXMLHandler xmlValidatedLocal = new MyXMLHandler(xmlOutputLocal, directoryInfo2 + "\\xsd\\BookmarkLocalSchema.xsd");
                bool validLocal = xmlValidatedLocal.ValidateXML();

                if (valid && validLocal)
                {
                    string m = serv.CreateBookmark(xmlOutput);
                    MessageBox.Show(m);

                    xmlLocal.Save(folderpath + "\\Bookmarks.xml");

                }
                else
                {
                    MessageBox.Show("Nao foi possivel adicionar aos bookmarks!");
                }
            }
            

           

        }

        private void btnFavoriteChapter_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                string chapterTitle = listBox1.SelectedItem.ToString();
                int chapterNumber = listBox1.SelectedIndex;
                isFavorite = true;
                sendBookMarkFavXml(chapterTitle, chapterNumber, isFavorite); 
            }else{
                MessageBox.Show("Selecione um capitulo para adicionar aos favoritos!");
            }

        }
    }
}
