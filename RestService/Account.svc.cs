using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RestService
{
    public class Account : IAccount
    {
        private IEnumerable<Model.Account> accounts { get; set; }

        public Account()
        {
            accounts = new List<Model.Account>() { 
                new Model.Account() { Id = "1", Name = "Hello world" },
                new Model.Account() { Id = "2", Name = "Henry" }
            };
        }

        public IEnumerable<Model.Account> Datas()
        {
            return accounts;
        }

        public Model.Account Data(string id)
        {
            return accounts.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
