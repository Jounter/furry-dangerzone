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


namespace ServiceePubCloud
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public string CreateUser(string username, string password, string name, string email, DateTime birthdate)
        {
            Model1Container context = new Model1Container();
            //TODO verificar se a bd está vazia
            if ((context.UserSet.Count() == 0))
            {
                User novo = new User();
                novo.Username = username;
                novo.Password = password;
                novo.Name = name;
                novo.Email = email;
                novo.Birthdate = birthdate;

                context.UserSet.Add(novo);
                context.SaveChanges();
            }
            else
            {
                User user = context.UserSet.Where(i => i.Username == username).First();
                if (user.Username != username)
                {
                    User novo = new User();
                    novo.Username = username;
                    novo.Password = password;
                    novo.Name = name;
                    novo.Email = email;
                    novo.Birthdate = birthdate;

                    context.UserSet.Add(novo);
                    context.SaveChanges();
                }
                return "Username existente";
            }
            return "User Criado";
        }

        public UserWeb GetUser(string username, string password)
        {
            Model1Container context = new Model1Container();

            try
            {
                User user = context.UserSet.Where(i => i.Username == username && i.Password == password).First();
                UserWeb userWeb = new UserWeb();
                if (user != null)
                {
                    userWeb.Id = user.UserID;
                    userWeb.Username = user.Username;
                    userWeb.Name = user.Name;
                    userWeb.Password = user.Password;
                    userWeb.Email = user.Email;
                    userWeb.Birthdate = user.Birthdate;
                    userWeb.LastEBookRead = user.LastEBookRead;
                    userWeb.LastChapterRead = user.LastChapterRead;
                    user.LastLogin = DateTime.Now;
                    userWeb.LastLogin = user.LastLogin;

                    //user.Username = reader.GetString(reader.GetOrdinal("Username"));
                    //user.Password = reader.GetString(reader.GetOrdinal("Password"));
                    //user.Name = reader.GetString(reader.GetOrdinal("Name"));
                    //user.Email = reader.GetString(reader.GetOrdinal("Email"));
                    //user.Birthdate = reader.GetDateTime(reader.GetOrdinal("Birthdate"));
                    //user.LastEBookRead = reader.GetSqlInt32(reader.GetOrdinal("LastEBookRead")).Value;
                    //user.LastChapterRead = reader.GetSqlInt32(reader.GetOrdinal("LastChapterRead")).Value;
                    //user.LastLogin = reader.GetDateTime(reader.GetOrdinal("LastLogin"));

                    return userWeb;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public int UserExists(string username, string password)
        {
            UserWeb user = GetUser(username, password);
            if (user != null)
            {
                return user.Id;
            }
            return 0;
        }

        // TODO FAZER cREATEFAVORITOS
        //public void Favorites(XmlDocument doc)
        //{
        //    Model1Container context = new Model1Container();
        //    doc.Load();
        //    XmlNodeList lista = doc.SelectNodes("/ePubType/favorites");
        //    Favorites favorites = new Favorites();
        //    for (int i = 0; i < lista.Count; i++)
        //    {
        //         favorites.
        //    }
        //    foreach (XmlNode item in lista)
        //    {
        //       ;
        //       //context.
        //    }
        //}

        public string CreateEbook(XmlDocument doc)
        {
            Model1Container context = new Model1Container();
            doc.LoadXml(doc.ToString());
            XmlNodeList lista = doc.SelectNodes("/ePubType/book");
            foreach (XmlNode item in lista)
            {
                // TODO: verificar se  BD está vazia 
                if ((context.EBookSet.Count() == 0))
                {
                    EBook novo = new EBook();
                    novo.EBookName = item["title"].InnerText;
                    novo.Author = item["author"].InnerText;
                    novo.Subject = item["subject"].InnerText;
                    context.EBookSet.Add(novo);
                    context.SaveChanges();
                    return "Ebook criado com sucesso!";
                }
                else
                {
                    //verificar se o livro já existe
                    if (context.EBookSet.Equals(item["title"].InnerText) && context.EBookSet.Equals(item["author"].InnerText) && context.EBookSet.Equals(item["subject"].InnerText) && context.EBookSet.Equals(item["publisher"].InnerText))
                    {
                        return "Ebook já existente!";
                    }
                    else
                    {
                        EBook novo = new EBook();
                        novo.EBookName = item["title"].InnerText;
                        novo.Author = item["author"].InnerText;
                        novo.Subject = item["subject"].InnerText;
                        novo.Publisher = item["publisher"].InnerText;
                        context.EBookSet.Add(novo);
                        context.SaveChanges();
                    }
                }
            }
            return "Ebook criado com sucesso!";
        }

        //TODO METER PUBLISHER no ebooktype do xsd
        public string CreateChapter(XmlDocument doc)
        {
            Model1Container context = new Model1Container();
            doc.LoadXml(doc.ToString());
            XmlNodeList lista = doc.SelectNodes("/ePubType/book");
            foreach (XmlNode item in lista)
            {
                // TODO: verificar se BD está vazia
                if ((context.ChapterSet.Count() == 0))
                {

                    //verificar se o livro já está guardado
                    if (context.EBookSet.Count() == 0)
                    {
                        return "Crie um Ebook primeiro!";
                    }
                    if (!context.EBookSet.Equals(item["title"].InnerText) && !context.EBookSet.Equals(item["author"].InnerText) && !context.EBookSet.Equals(item["subject"].InnerText) && !context.EBookSet.Equals(item["publisher"].InnerText))
                    {
                        return "Crie um Ebook com o titulo: " + item["title"].InnerText + ", com o nome de autor: " + item["author"].InnerText + ", com o seguinte tema: " + item["subject"].InnerText + ", e com a seguinte editora: " + item["publisher"].InnerText + "antes de tentar guardar o capítulo!";
                    }

                    EBook ebook = context.EBookSet.Where(i => i.EBookName == item["title"].InnerText).First();
                    XmlNodeList capitulos = doc.SelectNodes("/ePubType/book/chapters");
                    Chapter novoCapitulo = new Chapter();
                    foreach (XmlNode itemC in capitulos)
                    {
                        novoCapitulo.EBookID = ebook.EbookID;
                        novoCapitulo.ChapterName = itemC["chaptertitle"].InnerText;
                        novoCapitulo.ChapterNumber = itemC["number"].InnerText;
                        context.ChapterSet.Add(novoCapitulo);
                        context.SaveChanges();
                        return "Capitulo Criado !";
                    }
                }
                else
                {
                    //verificar se o livro já está guardado
                    if (context.EBookSet.Count() == 0)
                    {
                        return "Crie um Ebook primeiro!";
                    }
                    if (!context.EBookSet.Equals(item["title"].InnerText) && !context.EBookSet.Equals(item["author"].InnerText) && !context.EBookSet.Equals(item["subject"].InnerText) && !context.EBookSet.Equals(item["publisher"].InnerText))
                    {
                        return "Crie um Ebook com o titulo: " + item["title"].InnerText + ", com o nome de autor: " + item["author"].InnerText + ", com o seguinte tema: " + item["subject"].InnerText + ", e com a seguinte editora: " + item["publisher"].InnerText + "antes de tentar guardar o capítulo!";
                    }
                    //verificar se o capitulo já existe
                    else
                    {
                        EBook ebook = context.EBookSet.Where(i => i.EBookName == item["title"].InnerText).First();
                        Chapter chapter = context.ChapterSet.Where(i => i.EBookID == ebook.EbookID).First();
                        //comparar os ids
                        if (ebook.EbookID == chapter.EBookID)
                        {
                            XmlNodeList capitulos = doc.SelectNodes("/ePubType/book/chapters");
                            Chapter novoCapitulo = new Chapter();
                            foreach (XmlNode itemC in capitulos)
                            {
                                //guardar capitulo
                                if (!(chapter.ChapterName == itemC["chaptertitle"].InnerText) && !(chapter.ChapterNumber == itemC["number"].InnerText))
                                {
                                    novoCapitulo.EBookID = ebook.EbookID;
                                    novoCapitulo.ChapterName = itemC["chaptertitle"].InnerText;
                                    novoCapitulo.ChapterNumber = itemC["number"].InnerText;
                                    context.ChapterSet.Add(novoCapitulo);
                                    context.SaveChanges();
                                    return "Capitulo Criado!";
                                }
                            }
                            return "Capítulo já Existe!";
                        }
                    }
                }
            }
            return "Capitulo Criado!";
        }

        public string createBookmark(XmlDocument doc)
        {
            Model1Container context = new Model1Container();
            CreateChapter(doc);
            doc.LoadXml(doc.ToString());
            XmlNodeList capitulos = doc.SelectNodes("/ePubType/book/chapters");
            foreach (XmlNode itemC in capitulos)
            {
                Chapter chapter = context.ChapterSet.Where(i => i.ChapterNumber == itemC["number"].InnerText).First();
                if (context.BookmarkSet.Count() == 0)
                {
                    Bookmark novoBookmark = new Bookmark();
                    novoBookmark.ChapterID = chapter.ChapterID;
                    novoBookmark.Date = DateTime.Today;
                    context.BookmarkSet.Add(novoBookmark);
                    context.SaveChanges();

                }
                else
                {
                }
                return "";
            }
            return "";
        }
    }
}
