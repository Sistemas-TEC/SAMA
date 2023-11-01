using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LayoutTemplateWebApp.Model;
using LayoutTemplateWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Data;

namespace LayoutTemplateWebApp.Pages.AdminSAMA
{
    public class ListaAhijadoModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        public string role { get; set; }

        public List<User> AhijadoList { get; set; }

        [BindProperty]
        public string FilterEmail { get; set; }
        public string RawJsonData { get; set; }

        public ListaAhijadoModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public void OnGet()
        {
            role = HttpContext.Session.GetString("role");
            LoadDefaultList(); // M�todo para cargar la lista por defecto

            if (!string.IsNullOrEmpty(FilterEmail))
            {
                AhijadoList = AhijadoList.Where(a => a.Email.Contains(FilterEmail, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }
        public void OnPost()
        {
            OnGet();
        }

        private void LoadDefaultList()
        {
            // Aqu� simplemente extraemos la lista de usuarios con Role = 2 de UserData.
            AhijadoList = UserData.Users.Where(u => u.Role == 2).ToList();

        }
    }
}
