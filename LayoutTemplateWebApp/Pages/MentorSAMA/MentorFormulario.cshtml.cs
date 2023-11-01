using LayoutTemplateWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LayoutTemplateWebApp.Pages.MentorSAMA
{
        public class MentorFormularioModel : PageModel
        {
        public string role { get; set; }
        public User CurrentUser { get; set; }

        public void OnGet()
        {
            role = HttpContext.Session.GetString("role");
            string ahijadoEmail = HttpContext.Session.GetString("email");
            CurrentUser = UserData.Users.FirstOrDefault(u => u.Email == ahijadoEmail);
        }
    }
}
