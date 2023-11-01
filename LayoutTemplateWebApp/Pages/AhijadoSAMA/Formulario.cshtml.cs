using LayoutTemplateWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;  // Agregar para usar la sesión
using System.Linq;  // Agregar para usar el método FirstOrDefault

namespace LayoutTemplateWebApp.Pages.AhijadoSAMA
{
    public class FormularioModel : PageModel
    {
        public User CurrentUser { get; set; }
        public string Message { get; set; }

        public void OnGet()
        {
            // Obtener el correo del ahijado
            string userEmail = HttpContext.Session.GetString("email");

            // Buscar al usuario por el email
            CurrentUser = UserData.Users.FirstOrDefault(u => u.Email == userEmail);
        }
    }
}
