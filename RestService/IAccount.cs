using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace RestService
{
    [ServiceContract]
    public interface IAccount
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "")]
        IEnumerable<Model.Account> Datas();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "{id}")]
        Model.Account Get(string id);

        [OperationContract]
        [WebInvoke(Method = "POST")]
        void Create(Model.Account account);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "{id}")]
        void Modify(string id, Model.Account account);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "{id}")]
        void Delete(string id);
    }
}
