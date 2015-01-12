//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceePubCloud
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.EBookStatistics = new HashSet<ConsultedEbooks>();
            this.DateStatistics = new HashSet<DateStatistics>();
            this.Bookmark = new HashSet<Bookmark>();
            this.Favorite = new HashSet<Favorite>();
        }
    
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public System.DateTime Birthdate { get; set; }
        public Nullable<System.DateTime> LastLogin { get; set; }
        public Nullable<int> LastEBookRead { get; set; }
        public Nullable<int> LastChapterRead { get; set; }
    
        public virtual ICollection<ConsultedEbooks> EBookStatistics { get; set; }
        public virtual ICollection<DateStatistics> DateStatistics { get; set; }
        public virtual EBook EBook { get; set; }
        public virtual Chapter Chapter { get; set; }
        public virtual ICollection<Bookmark> Bookmark { get; set; }
        public virtual ICollection<Favorite> Favorite { get; set; }
    }
}
