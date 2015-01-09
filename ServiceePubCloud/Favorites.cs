using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ServiceePubCloud
{
    [DataContract]
    public class Favorites
    {
        [DataMember]
        public int FavoriteID { get; set; }
        [DataMember]
        public int EBookID { get; set; }
        [DataMember]
        public int ChapterID { get; set; }
        [DataMember]
        public System.DateTime Schedule { get; set; }

        public Favorites()
        {
            this.FavoriteID = 0;
            this.EBookID = 0;
            this.ChapterID = 0;
            this.Schedule = DateTime.MinValue;
        }

        public Favorites(int id, int eBookID, int chapterID, DateTime schedule)
        {
            this.FavoriteID = id;
            this.EBookID = eBookID;
            this.ChapterID = chapterID;
            this.Schedule = schedule;
        }

        public Favorites(Favorites favorites)
        {
            this.FavoriteID = favorites.FavoriteID;
            this.EBookID = favorites.EBookID;
            this.ChapterID = favorites.ChapterID;
            this.Schedule = favorites.Schedule;
        }

    }
}