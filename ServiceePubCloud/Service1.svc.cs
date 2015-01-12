using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.IO;


namespace ServiceePubCloud
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        string folderPath = Directory.GetCurrentDirectory();

        public string CreateUser(string username, string password, string name, string email, DateTime birthdate)
        {
            Model1Container context = new Model1Container();
            //TODO verificar se a bd está vazia

            var user1 = context.UserSet.Where(i => i.Username == username);
            if (user1.Count() != 0)
            {
                return "Username already exists.";
            }

            User novo = new User();
            novo.Username = username;
            novo.Password = password;
            novo.Name = name;
            novo.Email = email;
            novo.Birthdate = birthdate;

            context.UserSet.Add(novo);
            context.SaveChanges();
            return "User Created!";
        }

        public UserWeb GetUser(string username, string password)
        {
            Model1Container context = new Model1Container();
            var user = context.UserSet.Where(i => i.Username == username && i.Password == password);
            if (user.Count() != 0)
            {
                User userExists = null;
                foreach (var us in user)
                {
                    userExists = user.First();
                }

                UserWeb userWeb = new UserWeb();
                if (user != null)
                {
                    userWeb.Id = userExists.UserID;
                    userWeb.Username = userExists.Username;
                    userWeb.Name = userExists.Name;
                    userWeb.Password = userExists.Password;
                    userWeb.Email = userExists.Email;
                    userWeb.Birthdate = userExists.Birthdate;
                    userWeb.LastEBookRead = userExists.LastEBookRead;
                    userWeb.LastChapterRead = userExists.LastChapterRead;
                    userExists.LastLogin = DateTime.Now;
                    userWeb.LastLogin = userExists.LastLogin;
                    context.SaveChanges();
                    return userWeb;
                }
            }
            return null;

        }

        public void LastLogin(int IdUser, DateTime lastLogin)
        {
            Model1Container context = new Model1Container();
            DateStatistics dateS = new DateStatistics();
            dateS.UserID = IdUser;
            dateS.Date = lastLogin;
            context.DateStatisticsSet.Add(dateS);
            context.SaveChanges();
        }

        public bool UserExists(string username, string password)
        {
            //Apanhar a exception e enviar mensagem
            UserWeb user = GetUser(username, password);
            if (user != null)
            {
                LastLogin(user.Id, (DateTime)user.LastLogin);
                return true;
            }
            return false;
        }


        public void CreateEbook(string xmlDoc)
        {
            MyXMLHandler xml = new MyXMLHandler(xmlDoc, folderPath + "\\xsd\\EBookSchema.xsd");
            xml.ValidateXML();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlDoc);
            Model1Container context = new Model1Container();
            XmlNodeList lista = doc.SelectNodes("/ebooks/ebook");
            foreach (XmlNode item in lista)
            {
                //verificar se o livro já existe
                if (!(EbookExists(item["title"].InnerText, item["author"].InnerText, item["publisher"].InnerText)))
                {
                    EBook novo = new EBook();
                    novo.EBookName = item["title"].InnerText;
                    novo.Author = item["author"].InnerText;
                    novo.Subject = item["subject"].InnerText;
                    novo.Publisher = item["publisher"].InnerText;
                    context.EBookSet.Add(novo);
                    context.SaveChanges();
                    CreateChapter(doc, novo);
                }
            }
            // context.SaveChanges();
        }

        public bool EbookExists(string title, string author, string publisher)
        {
            Model1Container context = new Model1Container();
            var ebook = context.EBookSet.Where(i => i.EBookName.Equals(title) && i.Author.Equals(author) && i.Publisher.Equals(publisher));

            if (ebook.Count() != 0)
            {
                return true;
            }
            return false;
        }

        public void CreateChapter(XmlDocument xmlDoc, EBook eBook)
        {
            Model1Container context = new Model1Container();

            XmlNodeList nodes = xmlDoc.SelectNodes("/ebooks/ebook[contains(title,'" + eBook.EBookName + "')]/chapter");

            Chapter novoCapitulo = new Chapter();
            foreach (XmlNode itemC in nodes)
            {
                novoCapitulo.EBookID = eBook.EbookID;
                novoCapitulo.ChapterName = itemC["name"].InnerText;
                novoCapitulo.ChapterNumber = Convert.ToInt32(itemC["number"].InnerText);
                context.ChapterSet.Add(novoCapitulo);
                context.SaveChanges();
            }
        }

        public bool ChapterExists(string chapterName, int chapterNumber, int EbookID)
        {
            Model1Container context = new Model1Container();
            if (context.ChapterSet.Equals(chapterName) && context.ChapterSet.Equals(chapterNumber) && context.ChapterSet.Equals(EbookID))
            {
                return true;
            }
            return false;
        }


        public string CreateBookmark(string xmlDoc)
        {
            MyXMLHandler xml = new MyXMLHandler(xmlDoc, folderPath + "\\xsd\\BookmarkSchema.xsd");
            xml.ValidateXML();
            XmlDocument doc = new XmlDocument();
            Model1Container context = new Model1Container();
            doc.LoadXml(xmlDoc);
            //verificar existe user
            XmlNodeList user = doc.SelectNodes("/bookmark");
            foreach (XmlNode itemU in user)
            {
                string username = itemU["owner"].InnerText;
                var userSearch = context.UserSet.Where(i => i.Username.Equals(username));
                if (userSearch.Count() != 0)
                {
                    User userExists = null;
                    foreach (var us in user)
                    {
                        userExists = userSearch.First();
                    }
                    //book
                    XmlNodeList books = doc.SelectNodes("/bookmark/book");
                    foreach (XmlNode itemB in books)
                    {
                        string title = itemB["bookname"].InnerText;
                        string author = itemB["author"].InnerText;
                        string publisher = itemB["publisher"].InnerText;
                        var bookSearch = context.EBookSet.Where(i => i.EBookName.Equals(title) && i.Author.Equals(author) && i.Publisher.Equals(publisher));
                        if (bookSearch.Count() != 0)
                        {
                            EBook bookExists = null;
                            foreach (var us in user)
                            {
                                bookExists = bookSearch.First();
                            }
                            //chapter
                            XmlNodeList chapters = doc.SelectNodes("/bookmark/chapter");
                            foreach (XmlNode itemC in chapters)
                            {
                                string name = itemC["chaptername"].InnerText;
                                int number = Convert.ToInt32(itemC["chapternumber"].InnerText);
                                var chapterSearch = context.ChapterSet.Where(i => i.ChapterName.Equals(name) && i.EBookID == bookExists.EbookID && i.ChapterNumber == number);
                                Chapter chapterExists = null;
                                if (chapterSearch.Count() != 0)
                                {
                                    chapterExists = chapterSearch.First();
                                }
                                if (!(context.BookmarkSet.Equals(chapterExists.ChapterID)) && !(context.BookmarkSet.Equals(userExists.UserID)))
                                {
                                    Bookmark novoBookmark = new Bookmark();
                                    novoBookmark.UserID = userExists.UserID;
                                    novoBookmark.ChapterID = chapterExists.ChapterID;
                                    novoBookmark.Date = DateTime.Today;
                                    context.BookmarkSet.Add(novoBookmark);
                                    context.SaveChanges();
                                    return "Bookmark Created";
                                }
                                return "Bookmark already exists.";
                            }
                        }
                        return "Book doesn´t exists.";
                    }
                }
            }
            return "Bookmark Already Exists";
        }

        public bool BookmarkExists(DateTime date, int chapterID, int userID)
        {
            Model1Container context = new Model1Container();
            if (context.BookmarkSet.Equals(date) && context.BookmarkSet.Equals(chapterID) && context.BookmarkSet.Equals(userID))
            {
                return true;
            }
            return false;
        }

        public string CreateFavorite(string xmlDoc)
        {
            MyXMLHandler xml = new MyXMLHandler(xmlDoc, folderPath + "\\xsd\\FavoriteSchema.xsd");
            xml.ValidateXML();
            XmlDocument doc = new XmlDocument();
            Model1Container context = new Model1Container();
            doc.LoadXml(xmlDoc);
            //verificar existe user
            XmlNodeList user = doc.SelectNodes("/favorite");
            foreach (XmlNode itemU in user)
            {

                string username = itemU["owner"].InnerText;
                var userSearch = context.UserSet.Where(i => i.Username.Equals(username));
                if (userSearch.Count() != 0)
                {
                    User userExists = null;
                    foreach (var us in user)
                    {
                        userExists = userSearch.First();
                    }
                    //book
                    XmlNodeList books = doc.SelectNodes("/favorite/book");
                    foreach (XmlNode itemB in books)
                    {

                        string title = itemB["bookname"].InnerText;
                        string author = itemB["author"].InnerText;
                        string publisher = itemB["publisher"].InnerText;
                        var bookSearch = context.EBookSet.Where(i => i.EBookName.Equals(title) && i.Author.Equals(author) && i.Publisher.Equals(publisher));
                        if (bookSearch.Count() != 0)
                        {
                            EBook bookExists = null;
                            foreach (var us in books)
                            {
                                bookExists = bookSearch.First();
                            }
                            //chapter
                            XmlNodeList chapters = doc.SelectNodes("/favorite/chapter");
                            if (chapters != null)
                            {
                                foreach (XmlNode itemC in chapters)
                                {
                                    string name = itemC["chaptername"].InnerText;
                                    int number = Convert.ToInt32(itemC["chapternumber"].InnerText);
                                    var chapterSearch = context.ChapterSet.Where(i => i.ChapterName.Equals(name) && i.EBookID == bookExists.EbookID && i.ChapterNumber == number);
                                    if (chapterSearch.Count() != 0)
                                    {
                                        Chapter chapterExists = null;
                                        foreach (var us in books)
                                        {
                                            chapterExists = chapterSearch.First();
                                        }

                                        if (!(context.FavoriteSet.Equals(chapterExists.ChapterID)) && !(context.FavoriteSet.Equals(userExists.UserID)) && !(context.FavoriteSet.Equals(bookExists.EbookID)))
                                        {
                                            Favorite novoFavorite = new Favorite();
                                            novoFavorite.UserID = userExists.UserID;
                                            novoFavorite.ChapterID = chapterExists.ChapterID;
                                            novoFavorite.EBookID = bookExists.EbookID;
                                            novoFavorite.Date = DateTime.Today;
                                            context.FavoriteSet.Add(novoFavorite);
                                            context.SaveChanges();
                                            return "Favorite Created.";
                                        }
                                        return "Favorite already exists.";
                                    }
                                }
                            }

                            else
                            {
                                if (!(context.FavoriteSet.Equals(bookExists.EbookID)) && !(context.FavoriteSet.Equals(userExists.UserID)))
                                {
                                    Favorite novoFavorite = new Favorite();
                                    novoFavorite.UserID = userExists.UserID;
                                    novoFavorite.EBookID = bookExists.EbookID;
                                    novoFavorite.ChapterID = 0;
                                    novoFavorite.Date = DateTime.Today;
                                    context.FavoriteSet.Add(novoFavorite);
                                    context.SaveChanges();
                                    return "Favorite Created";
                                }
                            }
                        }
                    }
                    return "Book doesn´t exists.";
                }
            }
            return "Bookmark Already Exists";
        }


        public List<DateStatisticsWeb> getMostAccess()
        {
            Model1Container context = new Model1Container();
            List<DateTime> dataAcess = context.DateStatisticsSet.Select(i => i.Date).ToList();
            List<DateStatisticsWeb> final = new List<DateStatisticsWeb>();
            List<DateTime> dataLida = new List<DateTime>();
            int count;
            foreach (DateTime data in dataAcess)
            {
                if (!dataLida.Contains(data))
                {
                    count = 0;

                    foreach (DateTime dataF in dataAcess)
                    {
                        if (((data.Day.Equals(dataF.Day)) && (data.Month.Equals(dataF.Month)) && (data.Year.Equals(dataF.Year))))
                        {
                            count++;
                            dataLida.Add(dataF);
                        }
                    }
                    final.Add(new DateStatisticsWeb(data, count));
                }
            }
            return final;
        }
    }
}
