using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace LayoutTemplateWebApp.Pages.MentorSAMA
{
    public class PerfilMentorModel : PageModel
    {
        private static readonly String connApi = "http://sistema-tec.somee.com/api/degree";
        public async Task OnGetApi()
        {
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage response = await httpClient.GetAsync(connApi))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(apiResponse);
                    }
                }
            }
        }
        public void OnGet()
        {
            OnGetApi();
        }
        
    }
}
