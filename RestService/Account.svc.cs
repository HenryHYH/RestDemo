using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;

namespace RestService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Account : IAccount
    {
        private static IList<Model.Account> accounts = new List<Model.Account>() { new Model.Account() { Id = "1", Name = "Hello world" }, new Model.Account() { Id = "2", Name = "Henry" }, new Model.Account() { Id = "3", Name = "Test" } };

        public IEnumerable<Model.Account> Datas()
        {
            return accounts;
        }

        public Model.Account Get(string id)
        {
            return accounts.Where(x => x.Id == id).FirstOrDefault();
        }

        public Model.ResponseMessage Create(Model.Account account)
        {
            accounts.Add(new Model.Account() { Id = (int.Parse(accounts.LastOrDefault().Id) + 1).ToString(), Name = account.Name });
            return new Model.ResponseMessage() { Success = true, Message = "Created" };
        }

        public Model.ResponseMessage Modify(string id, Model.Account account)
        {
            var data = Get(id);
            if (null != data)
            {
                data.Name = account.Name;
            }
            return new Model.ResponseMessage() { Success = true, Message = "Modify success" };
        }

        public Model.ResponseMessage Delete(string id)
        {
            var data = Get(id);
            if (null != data)
            {
                accounts.Remove(data);
            }
            return new Model.ResponseMessage() { Success = true, Message = "Deleted" };
        }
    }
}
