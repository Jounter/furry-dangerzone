using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServiceePubCloud
{
    [DataContract]
    public class Bookmarks
    {
        [DataMember]
        public int BookmarkID { get; set; }
        [DataMember]
        public int ChapterID { get; set; }

        public Bookmarks()
        {
            BookmarkID = 0;
            ChapterID = 0;
        }
    }

}