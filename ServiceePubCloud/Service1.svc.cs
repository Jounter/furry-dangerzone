using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace ServiceePubCloud
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public string CreateUser(string username, string password, string name, string email, DateTime birthdate)
        {
            Model1Container context = new Model1Container();
            User user = context.UserSet.Where(i => i.Username == username).First();
            if(user.Username != username){
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

        public UserWeb GetUser(string username)
        {
            Model1Container context = new Model1Container();

            try
            {
                User user = context.UserSet.Where(i => i.Username == username).First();
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
            }catch(Exception ex){
                throw ex;
            }
            return null;           
        }

        public int UserExists(string username, string password)
        {
            UserWeb user = GetUser(username);
            if (user == null)
            {
                return 0;
            }
            return user.Id;
        }
    }
}
