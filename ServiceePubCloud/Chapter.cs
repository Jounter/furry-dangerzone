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
    
    public partial class Chapter
    {
        public Chapter()
        {
            this.Bookmark = new HashSet<Bookmark>();
            this.EBookStatistics = new HashSet<ConsultedEbooks>();
            this.User = new HashSet<User>();
            this.Favorite = new HashSet<Favorite>();
        }
    
        public int ChapterID { get; set; }
        public string ChapterName { get; set; }
        public int ChapterNumber { get; set; }
        public int EBookID { get; set; }
    
        public virtual EBook EBook { get; set; }
        public virtual ICollection<Bookmark> Bookmark { get; set; }
        public virtual ICollection<ConsultedEbooks> EBookStatistics { get; set; }
        public virtual ICollection<User> User { get; set; }
        public virtual ICollection<Favorite> Favorite { get; set; }
    }
}
