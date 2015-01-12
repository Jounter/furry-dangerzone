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
        public int ChapterNumber { get; set; }
        [DataMember]
        public int EBookID { get; set; }
        [DataMember]
        public int Count { get; set; }

        public Chapters()
        {
            ChapterID = 0;
            ChapterName = "";
            ChapterNumber = 0;
            EBookID = 0;
        }

        public Chapters(int chapterID, string chapterName, int chapterNumber, int ebookID)
        {
            this.ChapterID = chapterID;
            this.ChapterName = chapterName;
            this.ChapterNumber = chapterNumber;
            this.EBookID = ebookID;
        }

        public Chapters(int chapterID, string chapterName, int chapterNumber, int ebookID, int count)
        {
            this.ChapterID = chapterID;
            this.ChapterName = chapterName;
            this.ChapterNumber = ChapterNumber;
            this.EBookID = ebookID;
            this.Count = count;
        }

    }
}