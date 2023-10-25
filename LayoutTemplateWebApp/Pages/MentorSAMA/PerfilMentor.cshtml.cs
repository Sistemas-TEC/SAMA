using LayoutTemplateWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LayoutTemplateWebApp.Pages.MentorSAMA
{
    public class PerfilMentorModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        public string role { get; set; }

        // Add a list to store godchildren for the logged-in mentor
        public List<User> Godchildren { get; set; } = new List<User>();

        public PerfilMentorModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public void OnGet()
        {
            role = HttpContext.Session.GetString("role");

            // Get email of logged-in mentor
            string mentorEmail = HttpContext.Session.GetString("email");

            // Fetch the assignments for the logged-in mentor
            var assignments = UserData.AssignmentsList.Where(a => a.Mentor.Email == mentorEmail).ToList();

            foreach (var assignment in assignments)
            {
                Godchildren.Add(assignment.Godchild);
            }
        }
    }
}
