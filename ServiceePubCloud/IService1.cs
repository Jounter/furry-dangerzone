using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace ServiceePubCloud
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //[OperationContract]
        //User GetDataUsingDataContract(string username, string password);

       
        [OperationContract]
        string CreateUser(string username, string password, string name, string email, DateTime birthdate);

        [OperationContract]
        bool UserExists(string username, string password);

        [OperationContract]
        UserWeb GetUser(string username, string password);

        [OperationContract]
        void CreateEbook(string xmlDoc);
        
        [OperationContract]
        string CreateBookmark(string xmlDoc);

        [OperationContract]
        string CreateFavorite(string xmlDoc);

        [OperationContract]
        List<DateStatisticsWeb> getMostAccess();

    }
}
