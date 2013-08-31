using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RestSharp;

namespace Client
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            var client = new RestClient("http://127.0.0.1:6001/");
            var request = new RestRequest("Account", Method.GET);
            var response = client.Execute<List<Account>>(request);
            rptAccount.DataSource = response.Data;
            rptAccount.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Account account = new Account() { Id = txtId.Text.Trim(), Name = txtName.Text.Trim() };

            var client = new RestClient("http://127.0.0.1:6001/");

            IRestRequest request = null;

            if ("0" == account.Id)
            {
                request = new RestRequest("Account", Method.POST);
            }
            else
            {
                request = new RestRequest("Account/{id}", Method.PUT);
                request.AddUrlSegment("id", account.Id);
            }

            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new CustomConverter { ContentType = "application/json" };
            request.AddBody(account);

            var response = client.Execute(request);
            BindData();
        }

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            var client = new RestClient("http://127.0.0.1:6001/");

            var request = new RestRequest("Account/{id}", Method.DELETE);
            request.AddUrlSegment("id", (sender as LinkButton).CommandArgument);

            var response = client.Execute(request);
            BindData();
        }

        public class CustomConverter : RestSharp.Serializers.ISerializer
        {
            public string ContentType { get; set; }

            public string DateFormat { get; set; }

            public string Namespace { get; set; }

            public string RootElement { get; set; }

            public string Serialize(object obj)
            {
                return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(obj);
            }
        }

        private class Accounts : List<Account>
        { }

        private class Account
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
    }
}

/*
           var client = new System.Net.WebClient();
           //var update = client.UploadString("http://127.0.0.1:6001/Account/1", "PUT", string.Empty);
           var update = client.UploadString("http://127.0.0.1:6001/Account", "POST", string.Empty);
           Response.Write("Result = " + update);
            */