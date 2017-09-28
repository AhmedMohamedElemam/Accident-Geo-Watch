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

namespace Aciident_Geo_Watch
{
    public partial class Login : System.Web.UI.Page
    {

        public static string RemoveDigits(string key)
        {
            return Regex.Replace(key, @"\d", "");
        }

     

        protected void Page_Load(object sender, EventArgs e)
        {
            var web = new HtmlWeb();
            var document = web.Load("http://www.youm7.com/Section/%D8%AD%D9%88%D8%A7%D8%AF%D8%AB/203/1");

            foreach (HtmlNode selectNode in document.DocumentNode.SelectNodes("//div[@class='col-xs-12 bigOneSec']"))
            {
                string divContents = selectNode.InnerHtml;

                //-----------------------------------------------------------------------

                Regex reg_link = new Regex(@"href="".*?""");
                Match mat_link = reg_link.Match(divContents);
                String link = mat_link.Value;
                link = link.Replace("href=", "");
                link = link.Replace(@"""", "");
                link = "http://www.youm7.com" + link;

                Regex reg_date = new Regex(@"\d+/\d+/\d+");
                Match mat_date = reg_date.Match(divContents);
                String date = mat_date.Value;


                Regex reg_title = new Regex(@"alt="".*?""");
                Match mat_title = reg_title.Match(divContents);
                String title = mat_title.Value;
                title = title.Replace("alt=", "");
                title = title.Replace(@"""", "");
                title = title.Replace("&quot;", "");




                String title_stopwords = StopWords.remove_stop_words(RemoveDigits(title));

                String location = Locations.get_location(title_stopwords);
                if (location == "none")
                {
                    continue;
                }
                else
                {
                    String label = Bayesian.bayesian(title_stopwords);
                    if (label == "others")
                    {
                        continue;
                    }
                    else
                    {
                        int count;
                        SqlConnection connection = new SqlConnection(" Server=.\\SQLEXPRESS;Database=gp;Trusted_Connection=True;MultipleActiveResultSets=true");
                        connection.Open();
                        using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from [gp].[dbo].[map_details] where link = @link ", connection))
                        {
                            sqlCommand.Parameters.AddWithValue("@link", link);
                            count = (int)sqlCommand.ExecuteScalar();
                        }
                        if (count > 0)
                        {
                            continue;
                        }
                        else
                        {
                            SqlCommand cmd = new SqlCommand("insert into [gp].[dbo].[map_details] ([title],[link],[location],[date],[label]) values(@title,@link,@location,@date,@label) ", connection);
                            cmd.Parameters.AddWithValue("@title", title);
                            cmd.Parameters.AddWithValue("@link", link);
                            cmd.Parameters.AddWithValue("@location", location);
                            cmd.Parameters.AddWithValue("@date", date);
                            cmd.Parameters.AddWithValue("@label", label);
                            cmd.ExecuteNonQuery();

                        }
                    }
                }
            }

            //************************************************************
            /*StringBuilder builder = new StringBuilder();
            Boolean check = false;
            var web_ = new HtmlWeb();
            var document_ = web_.Load(link);
            try
            {

                foreach (HtmlNode selectNode_ in document_.DocumentNode.SelectNodes("//p[@dir='RTL']//text()"))
                {
                    string Contents = selectNode_.InnerHtml;

                    Contents = Contents.Replace("&quot;", "");
                    Contents = Contents.Replace("&nbsp;", "");
                    Contents = Contents.Replace("\r\n\t\t", "");
                    Contents = Contents.Replace("\r\n\t", "");
                    Contents = Contents.Replace("&ndash", "");
                    builder.Append(Contents).Append(' ');
                }
                check = true;
            }

            catch { }

            if (check != false)
            {
                string new_content = builder.ToString().Trim();
                        
                String new_content_stopwords = StopWords.remove_stop_words(new_content);


                c.WriteLine(new_content_stopwords);

                check = false;

            }*/
            //**********************************************************************

          

        }

       
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (email1.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage2", "alert('ERROR..Enter Your Email !')", true);
            }
            else if (password1.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage2", "alert('ERROR..Enter Your Password !')", true);
            }
            else
            {
                SqlConnection connection = new SqlConnection(" Server=.\\SQLEXPRESS;Database=gp;Trusted_Connection=True;MultipleActiveResultSets=true");
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(@"select * from register where email='" + email1.Text + "' and password= '" + password1.Text + "'", connection);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count.ToString() == "1")
                {
                    Session["email"] = email1.Text;
                    String mmmm = RadioButtonList1.SelectedValue;
                    if (mmmm == "    Visualize Markers")
                    {
                        Response.Redirect("GP.aspx");
                    }
                    else if (mmmm == "    Create Statistics")
                    {
                        Response.Redirect("summ.aspx");
                    }
                }
                else {
                    Label4.Text = "Email Or Password Isn't Correct";
                }
               
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
           

           
            if (email2.Text == "" || password2.Text == "" || name.Text == "" || city.Text == "")
            {
                Label2.Text = "Some Fields Required..!";
            }
            else
            {
                
                    string email = email2.Text;
                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match match = regex.Match(email);
                    if (match.Success)
                    {
                        var input = password2.Text;
                        var hasNumber = new Regex(@"[0-9]+");
                        var hasUpperChar = new Regex(@"[A-Z]+");
                        var hasMinimum8Chars = new Regex(@".{8,}");
                         if(hasNumber.IsMatch(input) && hasUpperChar.IsMatch(input) && hasMinimum8Chars.IsMatch(input))
                         {
                            ////////////////////////////////////////////////////////////
                             if (password2.Text == repassword.Text)
                             {
                                 SqlConnection connection = new SqlConnection(" Server=.\\SQLEXPRESS;Database=gp;Trusted_Connection=True;MultipleActiveResultSets=true");
                                 connection.Open();
                                 SqlCommand cmd = new SqlCommand("insert into register " + " (email,password,name,city)values(@email,@password,@name,@city)", connection);
                                 cmd.Parameters.AddWithValue("@email", email2.Text.ToString());
                                 cmd.Parameters.AddWithValue("@password", password2.Text.ToString());
                                 cmd.Parameters.AddWithValue("@name", name.Text.ToString());
                                 cmd.Parameters.AddWithValue("@city", city.Text.ToString());
                                 cmd.ExecuteNonQuery();
                                 Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('CONGRATULATIONS..Successful Registration :)');</script>");
                                 // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage2", "alert('ERROR..Repassword Doesnt Match !')", true);
                             }
                             else
                             {
                                 Label2.Text = "Password Doesn't Match..!";
                             }
                        }
                        else {
                            Label2.Text = "Password Must Be Strong..!";
                        }
                    }
                    else
                    {
                        Label2.Text = "Email Isn't Correct..!";
                    }



                   
                
            }
        }

      
        

        

        
        
       

       
       
       

      

      

       

       
    }
}