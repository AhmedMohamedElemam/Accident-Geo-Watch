using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;


namespace Aciident_Geo_Watch
{
    public partial class aboutus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session["email"] = null;
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("Login.aspx");
            //HttpContext.Current.Session.Clear();
            //HttpContext.Current.Session.Abandon();
            //HttpContext.Current.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
        }
    }
}