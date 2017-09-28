using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Data;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Web.Script.Serialization;

namespace Aciident_Geo_Watch
{
    public partial class contactus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                //label افتتاحي
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            string x = Request.Form["TextArea1"];
            if (TextBox1.Text == "" || TextBox2.Text == "" || x == "")
            {
                Label1.Text = "Some Fields Required..!";
            }
            else
            {
                Label1.Text = "Your Message Was Sent Successfully";
                SqlConnection sqlConnection1 = new SqlConnection("Server=.\\SQLEXPRESS;Database=gp;Trusted_Connection=True;MultipleActiveResultSets=true");
                sqlConnection1.Open();
                SqlCommand cmd = new SqlCommand("insert into feedback " + " (name,email,message)values(@name,@email,@message)", sqlConnection1);

                cmd.Parameters.AddWithValue("@name", TextBox1.Text.ToString());
                cmd.Parameters.AddWithValue("@email", TextBox2.Text.ToString());
                cmd.Parameters.AddWithValue("@message", x);
                cmd.ExecuteScalar();
                sqlConnection1.Close();
                TextBox1.Text = "";
                TextBox2.Text = "";
            }

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