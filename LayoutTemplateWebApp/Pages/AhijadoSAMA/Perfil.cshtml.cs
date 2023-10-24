using LayoutTemplateWebApp.Data;
using LayoutTemplateWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LayoutTemplateWebApp.Pages.AhijadoSAMA
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        public string role { get; set; }
        public List<UserAPIModel> PersonList { get; set; }
        public string RawJsonData { get; set; }

        public IndexModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public void OnGet()
        {

            role = HttpContext.Session.GetString("role");

        }
    }
}
