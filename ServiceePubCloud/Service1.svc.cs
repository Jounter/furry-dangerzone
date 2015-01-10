﻿using System;
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
                User userExists=null;
                foreach(var us in user){
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

                    return userWeb;
                }
            }
            return null;

        }

        public int UserExists(string username, string password)
        {
            //Apanhar a exception e enviar mensagem
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

        public string CreateEbook(string xmlDoc)
        {
            MyXMLHandler xml = new MyXMLHandler(xmlDoc, folderPath + "\\xsd\\EBookSchema.xsd");
            xml.ValidateXML();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlDoc);
            Model1Container context = new Model1Container();
            XmlNodeList lista = doc.SelectNodes("/ebooks/ebook");
            foreach (XmlNode item in lista)
            {
                // TODO: verificar se  BD está vazia 
                if ((context.EBookSet.Count() == 0))
                {
                    EBook novo = new EBook();
                    novo.EBookName = item["title"].InnerText;
                    novo.Author = item["author"].InnerText;
                    novo.Subject = item["subject"].InnerText;
                    novo.Publisher = item["publisher"].InnerText;
                    context.EBookSet.Add(novo);
                    context.SaveChanges();
                    return "Ebook created sucessfully!";
                }
                else
                {
                    //verificar se o livro já existe
                    if (context.EBookSet.Equals(item["title"].InnerText) && context.EBookSet.Equals(item["author"].InnerText) && context.EBookSet.Equals(item["subject"].InnerText) && context.EBookSet.Equals(item["publisher"].InnerText))
                    {
                        return "Ebook already exists!";
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
            return "Ebook created sucessfully!";
        }

        //TODO METER PUBLISHER no ebooktype do xsd
        public string CreateChapter(string xmlDoc)
        {
            XmlDocument doc = new XmlDocument();
            Model1Container context = new Model1Container();
            doc.LoadXml(xmlDoc);
            //XmlNode root = doc.DocumentElement;
            //root.OuterXml;
            XmlNodeList lista = doc.SelectNodes("/ebooks/ebook");
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
                        novoCapitulo.ChapterNumber = Convert.ToInt32(itemC["number"].InnerText);
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
                                if (!(chapter.ChapterName == itemC["chaptertitle"].InnerText) && !(chapter.ChapterNumber == Convert.ToInt32(itemC["number"].InnerText)))
                                {
                                    novoCapitulo.EBookID = ebook.EbookID;
                                    novoCapitulo.ChapterName = itemC["chaptertitle"].InnerText;
                                    novoCapitulo.ChapterNumber = Convert.ToInt32(itemC["number"].InnerText);
                                    context.ChapterSet.Add(novoCapitulo);
                                    context.SaveChanges();
                                    return "Chapter Created!";
                                }
                            }
                        }
                    }
                }
            }
            return "Chapter Already Exists!";
        }

        public string createBookmark(string xmlDoc)
        {
            XmlDocument doc = new XmlDocument();
            Model1Container context = new Model1Container();
            CreateChapter(xmlDoc);
            doc.LoadXml(xmlDoc);
            //verificar existe user
            XmlNodeList user = doc.SelectNodes("/ePubType/user");
            foreach (XmlNode itemU in user)
            {
                if (context.UserSet.Count() != 0)
                {
                    User userExist = context.UserSet.Where(i => i.Username == itemU["username"].InnerText).First();
                    XmlNodeList capitulos = doc.SelectNodes("/ePubType/book/chapters");
                    foreach (XmlNode itemC in capitulos)
                    {
                        Chapter chapter = context.ChapterSet.Where(i => i.ChapterNumber == Convert.ToInt32(itemC["number"].InnerText)).First();
                        if (context.BookmarkSet.Count() == 0)
                        {
                            Bookmark novoBookmark = new Bookmark();
                            novoBookmark.UserID = userExist.UserID;
                            novoBookmark.ChapterID = chapter.ChapterID;
                            novoBookmark.Date = DateTime.Today;
                            context.BookmarkSet.Add(novoBookmark);
                            context.SaveChanges();
                            return "Bookmark Created";

                        }
                        else
                        {
                            Bookmark bookmark = context.BookmarkSet.Where(i => i.UserID == userExist.UserID).First();
                            if (bookmark.ChapterID != chapter.ChapterID)
                            {

                                Bookmark novoBookmark = new Bookmark();
                                novoBookmark.UserID = userExist.UserID;
                                novoBookmark.ChapterID = chapter.ChapterID;
                                novoBookmark.Date = DateTime.Today;
                                context.BookmarkSet.Add(novoBookmark);
                                context.SaveChanges();
                                return "Bookmark Created";
                            }
                        }
                    }
                }
            }
            return "Bookmark Already Exists";
        }
    }
}
