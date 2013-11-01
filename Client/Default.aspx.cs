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

        private readonly string URL = "http://127.0.0.1:6001/";

        private void BindData()
        {
            var client = new RestClient(URL);
            var request = new RestRequest("Account", Method.GET);
            var response = client.Execute<List<Account>>(request);
            rptAccount.DataSource = response.Data;
            rptAccount.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //RequestData account = new RequestData { Account = new Account { Id = txtId.Text.Trim(), Name = txtName.Text.Trim() } };
            var account = new Account { Id = txtId.Text.Trim(), Name = txtName.Text.Trim() };

            var client = new RestClient(URL);

            IRestRequest request = null;

            if ("0" == txtId.Text.Trim())
            {
                request = new RestRequest("Account", Method.POST);
            }
            else
            {
                request = new RestRequest("Account/{id}", Method.PUT);
                request.AddUrlSegment("id", txtId.Text.Trim());
            }

            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new JsonSerializer();
            request.AddBody(account);

            var response = client.Execute(request);
            Response.Write(response.ErrorMessage);
            BindData();
        }

        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            var client = new RestClient(URL);

            var request = new RestRequest("Account/{id}", Method.GET);
            request.AddUrlSegment("id", (sender as LinkButton).CommandArgument);

            var response = client.Execute<Account>(request);

            txtId.Text = response.Data.Id;
            txtName.Text = response.Data.Name;
        }

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            var client = new RestClient(URL);

            var request = new RestRequest("Account/{id}", Method.DELETE);
            request.AddUrlSegment("id", (sender as LinkButton).CommandArgument);

            var response = client.Execute(request);
            BindData();
        }

        public class JsonSerializer : RestSharp.Serializers.ISerializer
        {
            public JsonSerializer()
            {
                ContentType = "application/json";
            }

            public string ContentType { get; set; }

            public string DateFormat { get; set; }

            public string Namespace { get; set; }

            public string RootElement { get; set; }

            public string Serialize(object obj)
            {
                return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(obj);
            }
        }

        private class RequestData
        {
            public Account Account { get; set; }
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