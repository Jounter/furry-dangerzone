using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace ePubApp
{
    public partial class Configs : Form
    {
        string folderPath;
        //string[] files;

        public Configs()
        {
            folderPath = Directory.GetCurrentDirectory();
            //files = Directory.GetFiles(@"" + path + "\\", "*.xml", SearchOption.AllDirectories);

            //if (files.Length == 0)
            if (!File.Exists(folderPath + "\\epubConfigurations.xml"))
            {
                //usefull link: http://csharp.net-tutorials.com/xml/writing-xml-with-the-xmldocument-class/

                XmlDocument xml = new XmlDocument();

                XmlNode rootNode = xml.CreateElement("configs");
                xml.AppendChild(rootNode);

                XmlNode pathNode = xml.CreateElement("path");
                pathNode.InnerText = txtPath.Text;
                rootNode.AppendChild(pathNode);

                XmlNode webServiceNode = xml.CreateElement("webservice");
                webServiceNode.InnerText = txtWSPath.Text;
                rootNode.AppendChild(webServiceNode);

                xml.Save(folderPath + "\\epubConfigurations.xml");
            }
            else if (File.Exists(folderPath + "\\epubConfigurations.xml"))
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(folderPath + "\\epubConfigurations.xml");

                //XmlNode node = xml.SelectSingleNode();

                string path = "";
                string webservice = "";
            }

            InitializeComponent();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowDialog();

            txtPath.Text = folder.SelectedPath;
        }

        private void btnWSPath_Click(object sender, EventArgs e)
        {

        }
    }
}
