using LayoutTemplateWebApp.Data;
using LayoutTemplateWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

namespace LayoutTemplateWebApp.Pages.AdminSAMA
{
    public class ListaMentorModel : PageModel
    {
        public readonly IHttpClientFactory _clientFactory;
        public readonly ApplicationDBContext _dbContext;

        public List<Campus> campusDB { get; set; }

        public string role { get; set; }

        public ListaMentorModel(IHttpClientFactory clientFactory, ApplicationDBContext db)
        {
            _clientFactory = clientFactory;
            _dbContext = db;
        }

        public async Task<IActionResult> GetListCampus(){
            campusDB = await _dbContext.Campus.ToListAsync();
            return Page();
        }
        
        public void OnGet()
        {
            role = HttpContext.Session.GetString("role");

            Page(); 
        }
    }
}
