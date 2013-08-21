﻿using System;
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
                var client = new RestClient("http://127.0.0.1:6001/");
                // client.Authenticator = new HttpBasicAuthenticator(username, password);

                //var request = new RestRequest("Account.svc/{id}", Method.GET);
                var request = new RestRequest("Account.svc/", Method.GET);
                //request.AddParameter("name", "value"); // adds to POST or URL querystring based on Method
                //request.AddUrlSegment("id", "1"); // replaces matching token in request.Resource

                // easily add HTTP Headers
                //request.AddHeader("header", "value");

                // add files to upload (works with compatible verbs)
                //request.AddFile(path);

                // execute the request
                //RestResponse response = client.Execute(request);
                //var response = client.Execute(request);
                //var content = response.Content; // raw content as string
                //Response.Write(content);

                var response = client.Execute<List<Account>>(request);
                string a = "a";
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