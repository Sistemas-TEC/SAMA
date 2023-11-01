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

        public IActionResult OnPost(string provincia, string canton, string distrito,
                            string[] gustos, string consideraciones)
        {
            // Obtener el correo del usuario actual
            string userEmail = HttpContext.Session.GetString("email");

            // Obtener el usuario actual
            CurrentUser = UserData.Users.FirstOrDefault(u => u.Email == userEmail);

            if (CurrentUser != null)
            {
                // Actualizar los datos del usuario
                CurrentUser.Province = provincia;
                CurrentUser.Canton = canton;
                CurrentUser.District = distrito;
                CurrentUser.Likings = gustos.Select(g => new LikingUser { Name = g }).ToList();
                CurrentUser.Comment = consideraciones;

                // Guardar los cambios
                UserData.UpdateUser(CurrentUser);
            }

            return RedirectToPage(); // Redireccionar a la misma página para ver los cambios
        }
    }
}
