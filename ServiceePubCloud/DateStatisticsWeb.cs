using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ServiceePubCloud
{
    [DataContract]
    public class DateStatisticsWeb
    {

        private DateTime date;

        [DataMember]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        private int acess;
        [DataMember]
        public int Acess
        {
            get { return acess; }
            set { acess = value; }
        }

        public DateStatisticsWeb(DateTime date, int acess)
        {
            this.date = date;
            this.acess = acess;
        }
    }
}