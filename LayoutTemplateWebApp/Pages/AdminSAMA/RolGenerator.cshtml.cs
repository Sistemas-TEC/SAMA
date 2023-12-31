using LayoutTemplateWebApp.Data;
using LayoutTemplateWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text.Json;

namespace LayoutTemplateWebApp.Pages.AdminSAMA
{
    public class RolGeneratorModel : PageModel
    {


        private readonly IHttpClientFactory _clientFactory;
        public string role { get; set; }

        public RolGeneratorModel(IHttpClientFactory clientFactory)
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
