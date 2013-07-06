using System;
using System.Web;
using Business.Contracts;
using Ninject;

namespace Business.UserAccess
{
    public class AuthModule : IHttpModule
    {
        [Inject]
        public IUserAccessManager UserAccessManager { get; set; }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += Authenticate;

        }

        private void Authenticate(object source, EventArgs e)
        {
            var app = (HttpApplication)source;
            HttpContext context = app.Context;

            if (context.Request.IsAuthenticated)
            {
                return;
            }

            if (context.Request.HttpMethod == "POST")
            {
                var userName = context.Request.Form["userName"];
                var password = context.Request.Form["password"];

                if (UserAccessManager.Authenticate(userName, password))
                {
                    context.Session["IsAuthenticated"] = true;
                    context.User = new Principal { Identity = new Identity { IsAuthenticated = true, Name = userName } };
                }
                else
                {
                    context.Session["IsAuthenticated"] = false;
                    context.User = null;
                }
            }
        }

        public void Dispose()
        { }
    }
}