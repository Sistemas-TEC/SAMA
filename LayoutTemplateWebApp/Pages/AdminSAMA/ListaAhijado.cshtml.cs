using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LayoutTemplateWebApp.Model;
using LayoutTemplateWebApp.Data;
using Microsoft.AspNetCore.Mvc; 
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Azure.Core;
using Microsoft.EntityFrameworkCore;


namespace LayoutTemplateWebApp.Pages.AdminSAMA
{
    public class ListaAhijadoModel : PageModel
    {
            private readonly IHttpClientFactory _clientFactory;
            public string role { get; set; }

        public List<UserAPIModel> PersonList { get; set; }
        public string RawJsonData { get; set; }

        public ListaAhijadoModel(IHttpClientFactory clientFactory)
            {
                _clientFactory = clientFactory;
            }


        public async Task OnGet()
        {
            role = HttpContext.Session.GetString("role");
            PersonList = await LoadPersonsData();
        
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
                    personList = JsonSerializer.Deserialize<List<UserAPIModel>>(data);
                    RawJsonData = data;
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

