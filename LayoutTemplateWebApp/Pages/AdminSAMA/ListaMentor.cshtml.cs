using LayoutTemplateWebApp.Model;
using LayoutTemplateWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace LayoutTemplateWebApp.Pages.AdminSAMA
{
    public class ListaMentorModel : PageModel
    {
        private readonly ApplicationDBContext _context;
        private readonly IHttpClientFactory _clientFactory;
        public string role { get; set; }

        [BindProperty]
        public string FilterEmail { get; set; }
        public List<User> MentorList { get; set; }
        public string RawJsonData { get; set; }

        public ListaMentorModel(ApplicationDBContext context, IHttpClientFactory clientFactory)
        {
            _context = context;
            _clientFactory = clientFactory;
        }

        public List<StudentIntegratec> StudentsIntegratec { get; set; }
        public void OnGet()
        {
            role = HttpContext.Session.GetString("role");

            LoadDefaultList();

            if (!string.IsNullOrEmpty(FilterEmail))
            {
                MentorList = MentorList.Where(a => a.Email.Contains(FilterEmail, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }
        public void OnPost()
        {
            OnGet();
        }
        private void LoadDefaultList()
        {
            MentorList = UserData.Users.Where(u => u.Role == 3).ToList();
        }

    }
}
