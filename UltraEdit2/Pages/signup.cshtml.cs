using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using BCrypt.Net;



namespace UltraEdit2.Pages
{


    public class SignupModel : PageModel
    {
        private readonly string ConnectionString;
        public SignupModel(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");

        }


        public User Ur = new();

        public string errorMessage = "";
        public string SuccessMessage = "";

        public void OnPost()
        {
            Ur.firstname = Request.Form["firstname"];
            Ur.lastname = Request.Form["lastname"];
            Ur.email =   Request.Form["email"];
            Ur.password = Request.Form["password"];


            if (Ur.firstname.Length == 0 || Ur.lastname.Length == 0 || Ur.email.Length == 0 || Ur.password.Length == 0)
            {
                errorMessage = "All fields are required ";
                return;
            }
            try
            {

            string hashedpassword = BCrypt.Net.BCrypt.HashPassword(Ur.password);


                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    Connection.Open();

                    string sql = "INSERT  INTO Users" +
                        "(firstname,lastname,email,password) Values" +
                        "(@firstname,@lastname,@email,@password)";

                    using (SqlCommand command = new SqlCommand(sql, Connection))
                    {

                        command.Parameters.AddWithValue("@firstname", Ur.firstname);
                        command.Parameters.AddWithValue("@lastname", Ur.lastname);
                        command.Parameters.AddWithValue("@email", Ur.email);
                        command.Parameters.AddWithValue("@password", hashedpassword);

                        command.ExecuteNonQuery();

                        SuccessMessage = "Registration Successfull";

                    }



                }


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                errorMessage= "Something went wrong";
            }




            Ur.firstname = "";
            Ur.lastname = "";
            Ur.email = "";
            Ur.password = "";
            Thread.Sleep(3000);
            Response.Redirect("/login");


        }


    }
}
