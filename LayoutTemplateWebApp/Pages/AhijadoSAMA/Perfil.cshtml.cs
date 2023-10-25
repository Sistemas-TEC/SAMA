using LayoutTemplateWebApp.Data;
using LayoutTemplateWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace LayoutTemplateWebApp.Pages.AhijadoSAMA
{

    public class PerfilModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        public string role { get; set; }
        public User MentorData { get; set; } // Datos del mentor del ahijado
        public string RawJsonData { get; set; }

        public PerfilModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public void OnGet()
        {
            role = HttpContext.Session.GetString("role");

            // Obtener el correo del ahijado
            string ahijadoEmail = HttpContext.Session.GetString("email");

            // Buscar la asignación que corresponde al ahijado
            var assignment = UserData.AssignmentsList.FirstOrDefault(a => a.Godchild.Email == ahijadoEmail);

            // Si encontramos una asignación, cargamos los datos del mentor
            if (assignment != null)
            {
                MentorData = assignment.Mentor;
            }
        }
    }
}
