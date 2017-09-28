using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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

using System.Web.Security;
namespace Aciident_Geo_Watch
{
    public partial class summ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection1 = new SqlConnection("Server=.\\SQLEXPRESS;Database=gp;Trusted_Connection=True;MultipleActiveResultSets=true");
            sqlConnection1.Open();

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandText = "SELECT * FROM locations";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                String place = reader["location"].ToString();
                ListBox1.Items.Add(place);

            }
            sqlConnection1.Close();
        }



        protected void Button2_Click(object sender, EventArgs e)
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



       
        

        protected void Button1_Click(object sender, EventArgs e)
        {
            String place = TextBox1.Text;
            SqlConnection connection = new SqlConnection(" Server=.\\SQLEXPRESS;Database=gp;Trusted_Connection=True;MultipleActiveResultSets=true");
            connection.Open();
            int f, a, m, t, tot;

            using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from [gp].[dbo].[map_details] where location = @place and label = @label ", connection))
            {
                sqlCommand.Parameters.AddWithValue("@place", place);
                sqlCommand.Parameters.AddWithValue("@label", "fires");
                f = (int)sqlCommand.ExecuteScalar();
            }
            using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from [gp].[dbo].[map_details] where location = @place and label = @label ", connection))
            {
                sqlCommand.Parameters.AddWithValue("@place", place);
                sqlCommand.Parameters.AddWithValue("@label", "accident");
                a = (int)sqlCommand.ExecuteScalar();
            }

            using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from [gp].[dbo].[map_details] where location = @place and label = @label ", connection))
            {
                sqlCommand.Parameters.AddWithValue("@place", place);
                sqlCommand.Parameters.AddWithValue("@label", "murder");
                m = (int)sqlCommand.ExecuteScalar();
            }

            using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from [gp].[dbo].[map_details] where location = @place and label = @label ", connection))
            {
                sqlCommand.Parameters.AddWithValue("@place", place);
                sqlCommand.Parameters.AddWithValue("@label", "theft");
                t = (int)sqlCommand.ExecuteScalar();
            }

            tot = f + a + m + t;
            fire.Text = f.ToString();
            accident.Text = a.ToString();
            murder.Text = m.ToString();
            theft.Text = t.ToString();
            total.Text = tot.ToString();

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox1.Text = ListBox1.SelectedItem.ToString();
        }
    }
}