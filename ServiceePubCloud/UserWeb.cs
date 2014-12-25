using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ServiceePubCloud
{
    [DataContract]
    public class UserWeb
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Password { get; set; }
        //[DataMember]
        //public string Salt { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public System.DateTime Birthdate { get; set; }
        [DataMember]
        public Nullable<int> LastEBookRead { get; set; }
        [DataMember]
        public Nullable<int> LastChapterRead { get; set; }
        [DataMember]
        public Nullable<System.DateTime> LastLogin { get; set; }

        public UserWeb()
        {
            this.Id = 0;
            this.Username = "";
            this.Name = "";
            this.Password = "";
            this.Email = "";
            this.Birthdate = DateTime.MinValue;
            this.LastEBookRead = 0;
            this.LastChapterRead = 0;
            this.LastLogin = DateTime.MinValue;
        }

        public UserWeb(int id, string username, string name, string password, string email, DateTime birthdate, int lastEBookRead, int lastChapterRead, DateTime lastLogin)
        {
            this.Id = id;
            this.Username = username;
            this.Name = name;
            this.Password = password;
            this.Email = email;
            this.Birthdate = birthdate;
            this.LastEBookRead = lastEBookRead;
            this.LastChapterRead = lastChapterRead;
            this.LastLogin = lastLogin;
        }
        public UserWeb(UserWeb userWeb)
        {
            this.Id = userWeb.Id;
            this.Username = userWeb.Username;
            this.Name = userWeb.Name;
            this.Password = userWeb.Password;
            this.Email = userWeb.Email;
            this.Birthdate = userWeb.Birthdate;
            this.LastEBookRead = userWeb.LastEBookRead;
            this.LastChapterRead = userWeb.LastChapterRead;
            this.LastLogin = userWeb.LastLogin;

        }


    }
}
