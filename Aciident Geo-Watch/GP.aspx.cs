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
    public partial class GP : System.Web.UI.Page
    {
        public List<string> l = new List<string>();
        public JavaScriptSerializer javaSerial = new JavaScriptSerializer();
        public List<string> ll = new List<string>();


        public List<string> lng = new List<string>();
        public List<string> lat = new List<string>();

        public List<string> lng_ = new List<string>();
        public List<string> lat_ = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {

            SqlConnection sqlConnection1 = new SqlConnection("Server=.\\SQLEXPRESS;Database=gp;Trusted_Connection=True;MultipleActiveResultSets=true");
            sqlConnection1.Open();

            SqlCommand cmd = new SqlCommand();
            SqlCommand command;

            SqlDataReader reader;
            object reader1;

            cmd.CommandText = "SELECT * FROM map_details";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                String place = reader["location"].ToString();
                //------------------------------------------------------------------------

                String longitude = "", latitude = "";
                String query = "SELECT longitude FROM locations where location = @loc1 ";
                command = new SqlCommand(query, sqlConnection1);
                command.Parameters.AddWithValue("@loc1", place);
                reader1 = command.ExecuteScalar();
                longitude = System.Convert.ToString(reader1);

                if (lng.Contains(longitude))
                {
                    if (longitude != "")
                    {
                        Double D = Convert.ToDouble(longitude);
                        D += .01;
                        longitude = Convert.ToString(D);
                        lng.Add(longitude);
                    }
                }
                else
                {
                    lng.Add(longitude);
                }

                String query1 = "SELECT latitude FROM locations where location = @loc2 ";
                command = new SqlCommand(query1, sqlConnection1);
                command.Parameters.AddWithValue("@loc2", place);
                reader1 = command.ExecuteScalar();
                latitude = System.Convert.ToString(reader1);

                if (lat.Contains(latitude))
                {
                    if (latitude != "")
                    {
                        Double D = Convert.ToDouble(latitude);
                        D += .01;
                        latitude = Convert.ToString(D);
                        lat.Add(latitude);
                    }
                }
                else
                {
                    lat.Add(latitude);
                }
                //------------------------------------------------------------------------
                string news = (reader["title"].ToString()) + "@" + (reader["link"].ToString()) + "@" + (reader["location"].ToString()) + "@" + (reader["label"].ToString()) + "@" + longitude + "@" + latitude + "@" + (reader["date"].ToString());
                l.Add(news);
            }
            sqlConnection1.Close();


            if (Session["email"] != null)
            {
                //label افتتاحي
            }
            else
            {
                Response.Redirect("Login.aspx");
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

        protected void labelsearch_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection1 = new SqlConnection("Server=.\\SQLEXPRESS;Database=gp;Trusted_Connection=True;MultipleActiveResultSets=true");
            sqlConnection1.Open();



            //*********************************************************************************************************************          
            if (CheckBox1.Checked)
            {
                SqlCommand cmd = new SqlCommand();
                SqlCommand command;

                SqlDataReader reader;
                object reader1;

                cmd.CommandText = "SELECT * FROM map_details where label = @label";
                cmd.Parameters.AddWithValue("@label", "theft");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    String place = reader["location"].ToString();
                    //------------------------------------------------------------------------

                    String longitude = "", latitude = "";
                    String query = "SELECT longitude FROM locations where location = @loc1 ";
                    command = new SqlCommand(query, sqlConnection1);
                    command.Parameters.AddWithValue("@loc1", place);
                    reader1 = command.ExecuteScalar();
                    longitude = System.Convert.ToString(reader1);

                    if (lng_.Contains(longitude))
                    {
                        if (longitude != "")
                        {
                            Double D = Convert.ToDouble(longitude);
                            D += .01;
                            longitude = Convert.ToString(D);
                            lng_.Add(longitude);
                        }
                    }

                    else
                    {
                        lng_.Add(longitude);
                    }

                    String query1 = "SELECT latitude FROM locations where location = @loc2 ";
                    command = new SqlCommand(query1, sqlConnection1);
                    command.Parameters.AddWithValue("@loc2", place);
                    reader1 = command.ExecuteScalar();
                    latitude = System.Convert.ToString(reader1);

                    if (lat_.Contains(latitude))
                    {
                        if (latitude != "")
                        {
                            Double D = Convert.ToDouble(latitude);
                            D += .01;
                            latitude = Convert.ToString(D);
                            lat_.Add(latitude);
                        }
                    }
                    else
                    {
                        lat_.Add(latitude);
                    }
                    //------------------------------------------------------------------------
                    string news = (reader["title"].ToString()) + "@" + (reader["link"].ToString()) + "@" + (reader["location"].ToString()) + "@" + (reader["label"].ToString()) + "@" + longitude + "@" + latitude + "@" + (reader["date"].ToString());
                    ll.Add(news);

                }

            }
            //*********************************************************************************************************************
            if (CheckBox2.Checked)
            {
                SqlCommand cmd = new SqlCommand();
                SqlCommand command;

                SqlDataReader reader;
                object reader1;

                cmd.CommandText = "SELECT * FROM map_details where label = @label";
                cmd.Parameters.AddWithValue("@label", "murder");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    String place = reader["location"].ToString();
                    //------------------------------------------------------------------------

                    String longitude = "", latitude = "";
                    String query = "SELECT longitude FROM locations where location = @loc1 ";
                    command = new SqlCommand(query, sqlConnection1);
                    command.Parameters.AddWithValue("@loc1", place);
                    reader1 = command.ExecuteScalar();
                    longitude = System.Convert.ToString(reader1);
                    if (lng_.Contains(longitude))
                    {
                        if (longitude != "")
                        {
                            Double D = Convert.ToDouble(longitude);
                            D += .01;
                            longitude = Convert.ToString(D);
                            lng_.Add(longitude);
                        }
                    }
                    else
                    {
                        lng_.Add(longitude);
                    }

                    String query1 = "SELECT latitude FROM locations where location = @loc2 ";
                    command = new SqlCommand(query1, sqlConnection1);
                    command.Parameters.AddWithValue("@loc2", place);
                    reader1 = command.ExecuteScalar();
                    latitude = System.Convert.ToString(reader1);

                    if (lat_.Contains(latitude))
                    {
                        if (latitude != "")
                        {
                            Double D = Convert.ToDouble(latitude);
                            D += .01;
                            latitude = Convert.ToString(D);
                            lat_.Add(latitude);
                        }
                    }
                    else
                    {
                        lat_.Add(latitude);
                    }
                    //------------------------------------------------------------------------
                    string news = (reader["title"].ToString()) + "@" + (reader["link"].ToString()) + "@" + (reader["location"].ToString()) + "@" + (reader["label"].ToString()) + "@" + longitude + "@" + latitude + "@" + (reader["date"].ToString());
                    ll.Add(news);

                }


            }
            //*********************************************************************************************************************
            if (CheckBox3.Checked)
            {
                SqlCommand cmd = new SqlCommand();
                SqlCommand command;

                SqlDataReader reader;
                object reader1;

                cmd.CommandText = "SELECT * FROM map_details where label = @label";
                cmd.Parameters.AddWithValue("@label", "fires");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    String place = reader["location"].ToString();
                    //------------------------------------------------------------------------

                    String longitude = "", latitude = "";
                    String query = "SELECT longitude FROM locations where location = @loc1 ";
                    command = new SqlCommand(query, sqlConnection1);
                    command.Parameters.AddWithValue("@loc1", place);
                    reader1 = command.ExecuteScalar();
                    longitude = System.Convert.ToString(reader1);
                    if (lng_.Contains(longitude))
                    {
                        if (longitude != "")
                        {
                            Double D = Convert.ToDouble(longitude);
                            D += .01;
                            longitude = Convert.ToString(D);
                            lng_.Add(longitude);
                        }
                    }
                    else
                    {
                        lng_.Add(longitude);
                    }

                    String query1 = "SELECT latitude FROM locations where location = @loc2 ";
                    command = new SqlCommand(query1, sqlConnection1);
                    command.Parameters.AddWithValue("@loc2", place);
                    reader1 = command.ExecuteScalar();
                    latitude = System.Convert.ToString(reader1);
                    if (lat_.Contains(latitude))
                    {
                        if (latitude != "")
                        {
                            Double D = Convert.ToDouble(latitude);
                            D += .01;
                            latitude = Convert.ToString(D);
                            lat_.Add(latitude);
                        }
                    }
                    else
                    {
                        lat_.Add(latitude);
                    }
                    //------------------------------------------------------------------------
                    string news = (reader["title"].ToString()) + "@" + (reader["link"].ToString()) + "@" + (reader["location"].ToString()) + "@" + (reader["label"].ToString()) + "@" + longitude + "@" + latitude + "@" + (reader["date"].ToString());
                    ll.Add(news);

                }


            }
            //*********************************************************************************************************************
            if (CheckBox4.Checked)
            {
                SqlCommand cmd = new SqlCommand();
                SqlCommand command;

                SqlDataReader reader;
                object reader1;

                cmd.CommandText = "SELECT * FROM map_details where label = @label";
                cmd.Parameters.AddWithValue("@label", "accident");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    String place = reader["location"].ToString();
                    //------------------------------------------------------------------------

                    String longitude = "", latitude = "";
                    String query = "SELECT longitude FROM locations where location = @loc1 ";
                    command = new SqlCommand(query, sqlConnection1);
                    command.Parameters.AddWithValue("@loc1", place);
                    reader1 = command.ExecuteScalar();
                    longitude = System.Convert.ToString(reader1);
                    if (lng_.Contains(longitude))
                    {
                        if (longitude != "")
                        {
                            Double D = Convert.ToDouble(longitude);
                            D += .01;
                            longitude = Convert.ToString(D);
                            lng_.Add(longitude);
                        }
                    }
                    else
                    {
                        lng_.Add(longitude);
                    }

                    String query1 = "SELECT latitude FROM locations where location = @loc2 ";
                    command = new SqlCommand(query1, sqlConnection1);
                    command.Parameters.AddWithValue("@loc2", place);
                    reader1 = command.ExecuteScalar();
                    latitude = System.Convert.ToString(reader1);
                    if (lat_.Contains(latitude))
                    {
                        if (latitude != "")
                        {
                            Double D = Convert.ToDouble(latitude);
                            D += .01;
                            latitude = Convert.ToString(D);
                            lat_.Add(latitude);
                        }
                    }
                    else
                    {
                        lat_.Add(latitude);
                    }
                    //------------------------------------------------------------------------
                    string news = (reader["title"].ToString()) + "@" + (reader["link"].ToString()) + "@" + (reader["location"].ToString()) + "@" + (reader["label"].ToString()) + "@" + longitude + "@" + latitude + "@" + (reader["date"].ToString());
                    ll.Add(news);

                }
            }
            //*********************************************************************************************************************

        }
    }
}