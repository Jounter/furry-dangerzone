using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServiceePubCloud
{
    [DataContract]
    public class EBooks
    {
        [DataMember]
        public int EbookID { get; set; }
        [DataMember]
        public string EBookName { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public string Publisher { get; set; }
        [DataMember]
        public string Subject { get; set; }

        public EBooks()
        {
            EbookID = 0;
            EBookName = "";
            Author = "";
            Publisher = "";
            Subject = "";
        }

        public EBooks(int EbookID, string EBookName, string Author, string Publisher, string Subject)
        {
            this.EbookID = EbookID;
            this.EBookName = EBookName;
            this.Author = Author;
            this.Publisher = Publisher;
            this.Subject = Subject;
        }
    }
}