using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcApplication1.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }


        
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {

                if (DbValidation(model.username, model.password))
                //   if (model.username=="nahida"&&  model.password=="mounthanh")
                {
                    FormsAuthentication.SetAuthCookie(model.username, false);
                    return RedirectToAction("index", "home");
                }
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }

            return View();
        }

        private bool DbValidation(string username, string password)
        {

            Boolean value = false;
            // @"Data Source=NAHIDA\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True;";
            string connectionString = @"Server=tcp:sru8q2iy7b.database.windows.net,1433;Database=MVCLogin;User ID=nahida@sru8q2iy7b;Password=MountHanh90#;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";


            // Provide the query string with a parameter placeholder.
            //"SELECT *from Login_Table "+ " where username='" + username+"'"+" and password ='" + password + "'";
            string queryString = "SELECT *from Login_Table " + " where username='" + username + "'" + " and password ='" + password + "'";

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(queryString, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                value = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return value;
        }

    }
}
