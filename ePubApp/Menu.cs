using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eBdb.EpubReader;
using System.IO;
using System.Xml;
using System.Collections;
using ePubApp.ServiceReference1;

namespace ePubApp
{
    public partial class Menu : Form
    {
        private string[] epubFiles;
        List<string> list = new List<string>();
        private string epubPath;
        private string configPath;
        Epub livro;
        Service1Client serv;

        string logedUser;

        public Menu(string username)
        {
            InitializeComponent();

            serv = new Service1Client();

            this.logedUser = username;

            loadEBooks();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnConfigs_Click(object sender, EventArgs e)
        {
            Form config = new Configs(logedUser);
            config.ShowDialog();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;

            string book = epubFiles.ElementAt(selectedIndex);

            string path = epubPath + "\\" + book;

            Epub epub = null;
            Boolean error;
            try
            {
                epub = new Epub(@path);
                error = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Error opening eBook!");
                error = true;
            }

            if (error == false)
            {
                Book li = new Book(epub, logedUser);                
                li.Show();
            }

        }

        private void openBook(string book)
        {
            string path = epubPath + "\\" + book;

            Epub epub = null;
            Boolean error;
            try
            {
                epub = new Epub(@path);
                error = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Error opening eBook!");
                error = true;
            }

            if (error == false)
            {
                Book li = new Book(epub, logedUser);                
                li.Show();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to log out?", "Log Out", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                this.Hide();

                Form login = new LoginForm();
                login.ShowDialog();

                this.Close();
            }
            else if (dialog == DialogResult.No)
            {

            }
        }

        private void btnBM_Click(object sender, EventArgs e)
        {

            Form bookmacks = new Bookmarks(logedUser);
            bookmacks.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //UI
                this.Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                sendEBookXml();
            }
            finally
            {
                //UI
                this.Cursor = Cursors.Default;
            }
        }

        private void sendEBookXml()
        {
            XmlDocument xml = new XmlDocument();

            XmlDeclaration xmlDeclaration = xml.CreateXmlDeclaration("1.0", "UTF-8", null);
            xml.AppendChild(xmlDeclaration);
            XmlNode rootNode = xml.CreateElement("ebooks");
            XmlAttribute attribute = xml.CreateAttribute("xmlns");
            //attribute.Value = "http://tempuri.org/XMLSchema.xsd";
            //rootNode.Attributes.Append(attribute);
            xml.AppendChild(rootNode);

            for (int i = 0; i < epubFiles.Count(); i++)
            {
                string book = epubFiles.ElementAt(i);

                string path = epubPath + "\\" + book;


                try
                {
                    livro = new Epub(@path);
                }
                catch (Exception)
                {
                    livro = null;
                }

                if (livro != null)
                {

                    XmlNode ebookNode = xml.CreateElement("ebook");
                    rootNode.AppendChild(ebookNode);

                    XmlNode titleNode = xml.CreateElement("title");

                    try
                    {
                        titleNode.InnerText = livro.Title[0];
                    }
                    catch (Exception)
                    {
                        string title = "Anonymous";
                        titleNode.InnerText = title;
                    }

                    ebookNode.AppendChild(titleNode);

                    XmlNode authorNode = xml.CreateElement("author");

                    try
                    {
                        authorNode.InnerText = livro.Creator[0];
                    }
                    catch (Exception)
                    {
                        string author = "Anonymous";
                        authorNode.InnerText = author;
                    }

                    ebookNode.AppendChild(authorNode);

                    XmlNode publisherNode = xml.CreateElement("publisher");

                    try
                    {
                        publisherNode.InnerText = livro.Publisher[0];
                    }
                    catch (Exception)
                    {
                        string publisher = "Anonymous";
                        publisherNode.InnerText = publisher;
                    }

                    ebookNode.AppendChild(publisherNode);

                    XmlNode subjectNode = xml.CreateElement("subject");

                    try
                    {
                        subjectNode.InnerText = livro.Subject[0];
                    }
                    catch (Exception)
                    {
                        string subject = "No subject";
                        subjectNode.InnerText = subject;
                    }

                    ebookNode.AppendChild(subjectNode);

                    var navPoints = new List<NavPoint>();
                    navPoints = livro.TOC;

                    int num;

                    if (navPoints.Count != 0)
                    {
                        num = 0;
                        foreach (NavPoint item in navPoints)
                        {
                            num++;

                            XmlNode chapterNode = xml.CreateElement("chapter");
                            ebookNode.AppendChild(chapterNode);

                            XmlNode nameNode = xml.CreateElement("name");
                            nameNode.InnerText = item.Title;
                            chapterNode.AppendChild(nameNode);

                            XmlNode numberNode = xml.CreateElement("number");
                            numberNode.InnerText = num + "";
                            chapterNode.AppendChild(numberNode);
                        }
                    }
                    else
                    {
                        num = 0;
                        foreach (DictionaryEntry item in livro.Content)
                        {
                            num++;
                            XmlNode chapterNode = xml.CreateElement("chapter");
                            ebookNode.AppendChild(chapterNode);

                            XmlNode nameNode = xml.CreateElement("name");
                            nameNode.InnerText = "Chapter " + num;
                            chapterNode.AppendChild(nameNode);

                            XmlNode numberNode = xml.CreateElement("number");
                            numberNode.InnerText = num + "";
                            chapterNode.AppendChild(numberNode);
                        }
                    }
                }
            }

            string xmlOutput = xml.OuterXml;


            string path2 = System.IO.Directory.GetCurrentDirectory();

            System.IO.DirectoryInfo directoryInfo =
                System.IO.Directory.GetParent(path2);


            System.IO.DirectoryInfo directoryInfo2 =
                System.IO.Directory.GetParent(directoryInfo.ToString());


            MyXMLHandler xmlValidated = new MyXMLHandler(xmlOutput, directoryInfo2 + "\\xsd\\EBookSchema.xsd");

            bool valid = xmlValidated.ValidateXML();

            if (valid)
            {
                serv.CreateEbook(xmlOutput);
                MessageBox.Show("Sincronismo efectuado com sucesso!");
            }
            else
            {
                MessageBox.Show("Nao foi possivel sincronizar!");
            }
            
        }

        private string checkPathNotEmpty()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(configPath);

            string path = "";

            foreach (XmlNode node in xml.SelectNodes("/configs"))
            {
                path = node.SelectSingleNode("path").InnerText;
            }

            if (path.Equals(""))
            {
                return "empty";
            }
            else
            {
                return path;
            }
        }

        private void loadEBooks(){

            configPath = Directory.GetCurrentDirectory() + "\\epubConfigurations.xml";

            if (!File.Exists(configPath) || checkPathNotEmpty().Equals("empty"))
            {
                epubPath = Directory.GetCurrentDirectory();
            }
            else
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(configPath);

                foreach (XmlNode node in xml.SelectNodes("/configs"))
                {
                    epubPath = node.SelectSingleNode("path").InnerText;
                }
            }

            byte[] bytes = Encoding.Default.GetBytes(epubPath);
            epubPath = Encoding.UTF8.GetString(bytes);
            epubFiles = Directory.GetFiles(epubPath, "*.epub").
                Select(path => Path.GetFileName(path)).ToArray();

            for (int i = 0; i < epubFiles.Count(); i++)
            {
                string book = epubFiles.ElementAt(i);

                string path = epubPath + "\\" + book;

                livro = null;
                try
                {
                    livro = new Epub(@path);
                    list.Add(livro.Title[0]);
                }
                catch (Exception)
                {
                    list.Add(book + "- Corrupted!");
                }
            }

            if (list.Count > 0)
            {
                listBox1.DataSource = list;
            }
            else
            {
                MessageBox.Show("Please choose a directory containing books!");
                list.Add("No books were found!");
                listBox1.DataSource = list;
            }
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            Form stats = new Statistics();
            stats.Show();
        }

        private void btnFavs_Click(object sender, EventArgs e)
        {
            Form fav = new Favorites(logedUser);
            fav.Show();
        }

    }
}

