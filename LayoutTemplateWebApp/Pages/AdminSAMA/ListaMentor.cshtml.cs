using LayoutTemplateWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LayoutTemplateWebApp.Pages.AdminSAMA
{
    public class ListaMentorModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        public string role { get; set; }

        public ListaMentorModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public List<UserAPIModel> PersonList { get; set; }
        public string RawJsonData { get; set; }

        public void OnGet()
        {

            role = HttpContext.Session.GetString("role");

        }
    }
}
