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
    public interface IAccount : IResource<Model.Account>
    {
    }
}
