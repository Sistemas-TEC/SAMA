using LayoutTemplateWebApp.Model;
using LayoutTemplateWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LayoutTemplateWebApp.Pages.MentorSAMA
{
    public class FormularioMentorModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        public string role { get; set; }
        public List<UserAPIModel> PersonList { get; set; }
        public string RawJsonData { get; set; }
        public List<User> MentorList { get; set; }

        public FormularioMentorModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public void OnGet()
        {
            role = HttpContext.Session.GetString("role");
            LoadDefaultList();
            
            
        }
        public void OnPost()
        {
            OnGet();
        }
        private void LoadDefaultList()
        {
            MentorList = UserData.Users.Where(u => u.Role == 3 && u.Email == HttpContext.Session.GetString("email")).ToList();
        }
    }
}
