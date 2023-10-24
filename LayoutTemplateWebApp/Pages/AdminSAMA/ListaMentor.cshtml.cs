using LayoutTemplateWebApp.Data;
using LayoutTemplateWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;

namespace LayoutTemplateWebApp.Pages.AdminSAMA
{
    public class ListaMentorModel : PageModel
    {
        public readonly IHttpClientFactory _clientFactory;
        public readonly ApplicationDBContext _dbContext;

        public string RawJsonData { get; set; }

        public List<UserAPIModel> PersonList { get; set; }
        public IEnumerable<Campus> campusDB { get; set; }

        public string role { get; set; }

        public ListaMentorModel(IHttpClientFactory clientFactory, ApplicationDBContext db)
        {
            _clientFactory = clientFactory;
            _dbContext = db;
        }
        public void OnGet()
        {
            role = HttpContext.Session.GetString("role");
            //campusDB = _dbContext.Campus.ToList();
            Page();
        }
    }
}
