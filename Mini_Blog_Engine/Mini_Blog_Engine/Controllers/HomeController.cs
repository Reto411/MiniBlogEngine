using System;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;

namespace Mini_Blog_Engine.Controllers
{
    public class HomeController : ControllerWithDB
    {

        /*
         * Antwort 
         * 
         * 1: 
         * 
         * 2:
         * 
         * 3:
         * 
         */


        public ActionResult Index()
        {


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Login()
        {
            var username = Request["username"];
            var password = Request["password"];

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Eigene Dateien\\Schule\\M183_Projekt\\MiniBlogEngine\\mini_blog_engine.mdf\";Integrated Security=True;Connect Timeout=30";

            con.Open();

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;


            cmd.CommandText = "SELECT * FROM [dbo].[User]";
            cmd.Connection = con;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    // In order to make this code work -> replace all UPPERCASE-Placeholders with the corresponding data!

                    var dbUsername = reader.GetString(4);
                    var dbPassword = reader.GetString(5);

                    if (username == dbUsername && password == dbPassword)
                    {
                        var user_roles = "";
                        var current_user_role = "";

                        if (current_user_role == "User")
                        {
                            // RedirectToAction();
                        }
                        else if (current_user_role == "Admin")
                        {

                        }

                        var request = (HttpWebRequest)WebRequest.Create("https://rest.nexmo.com/sms/json");

                        var secret = "TEST";

                        var postData = "api_key=API_KEY";
                        postData += "&api_secret=API_SECRET";
                        postData += "&to=MY_PHONENUMBER";
                        postData += "&from=\"\"NEXMO\"\"";
                        postData += "&text=\"" + secret + "\"";
                        var data = Encoding.ASCII.GetBytes(postData);

                        request.Method = "POST";
                        request.ContentType = "application/x-www-form-urlencoded";
                        request.ContentLength = data.Length;

                        using (var stream = request.GetRequestStream())
                        {
                            stream.Write(data, 0, data.Length);
                        }

                        var response = (HttpWebResponse)request.GetResponse();

                        var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                        ViewBag.Message = responseString;
                        return View();
                    }
                }

                ViewBag.Message = "Wrong Credentials";
                
            }
            else
            {
                Console.WriteLine("NO ROWS FOUND");
            }

            return View();
        }

        [HttpPost]
        public void TokenLogin()
        {
            var token = Request["token"];

            if (token == "TEST")
            {
                // -> "Token is correct";
            }
            else
            {
                // -> "Wrong Token";
            }

        }

        public ActionResult Dashboard()
        {

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}