using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;


namespace UltraEdit2.Pages
{

   
    public class signupModel : PageModel
    {
        private readonly string ConnectionStrings;
        public signupModel(IConfiguration configuration)
        {
            ConnectionStrings = configuration.GetConnectionString("DefaultConnection");


        }

        public User Ur = new();

        public string errorMessage = "";
        public string SuccessMessage = "";

        public void OnPost()
        {
            Ur.firstname= Request.Form["firstname"];
            Ur.lastname = Request.Form["lastname"];
            Ur.email     = Request.Form["email"];
            Ur.password = Request.Form["password"];


            if(Ur.firstname.Length==0 || Ur.lastname.Length==0 || Ur.email.Length==0 || Ur.password.Length==0)
            {
                errorMessage = "All fields are required";
                return;
            }

        }


    }
}
