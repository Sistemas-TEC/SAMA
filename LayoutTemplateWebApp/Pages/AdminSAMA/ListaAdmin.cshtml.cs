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


namespace LayoutTemplateWebApp.Pages.AdminSAMA
{
    public class ListaAdminModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        public string role { get; set; }

        public List<UserAPIModel> PersonList { get; set; }
        public string RawJsonData { get; set; }

        [BindProperty]
        public string FilterEmail { get; set; }

        public ListaAdminModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task OnGet()
        {
            role = HttpContext.Session.GetString("role");
            PersonList = await LoadPersonsData();

            if (!string.IsNullOrEmpty(FilterEmail))
            {
                PersonList = PersonList.Where(p => p.Email.Contains(FilterEmail, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }

        public void OnPost()
        {
            OnGet().Wait(); // Espera la ejecución de OnGet
        }

        public async Task<List<UserAPIModel>> LoadPersonsData()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("http://sistema-tec.somee.com/api/users");
            List<UserAPIModel> personList = new List<UserAPIModel>();
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var allPersons = JsonSerializer.Deserialize<List<UserAPIModel>>(data);
                    personList = allPersons.Where(p => p.ApplicationRoles.Any(ar =>
                    ar.Id == 9 && ar.ApplicationId == 9 && ar.ApplicationRoleName == "Administrador"
                )
            ).ToList();
                    RawJsonData = JsonSerializer.Serialize(personList);
                }
                catch (JsonException ex)
                {
                    RawJsonData = $"Error deserializing data: {ex.Message}";
                }
            }
            else
            {
                RawJsonData = $"Error: {response.StatusCode}";
            }
            return personList;
        }
    }

}