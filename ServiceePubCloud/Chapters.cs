using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ServiceePubCloud
{
    [DataContract]
    public class Chapters
    {
        [DataMember]
        public int ChapterID { get; set; }
        [DataMember]
        public string ChapterName { get; set; }
        [DataMember]
        public string ChapterNumber { get; set; }
        [DataMember]
        public int EBookID { get; set; }

        public Chapters()
        {
            ChapterID = 0;
            ChapterName = "";
            ChapterNumber = "";
            EBookID = 0;
        }

        public Chapters(int chapterID, string chapterName, string chapterNumber, int ebookID)
        {
            this.ChapterID = chapterID;
            this.ChapterName = chapterName;
            this.ChapterNumber = chapterName;
            this.EBookID = ebookID;
        }

    }
}