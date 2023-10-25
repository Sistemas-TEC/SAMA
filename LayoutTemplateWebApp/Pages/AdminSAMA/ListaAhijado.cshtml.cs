using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LayoutTemplateWebApp.Model;
using LayoutTemplateWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Data;


namespace LayoutTemplateWebApp.Pages.AdminSAMA
{
    public class ListaAhijadoModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        public string role { get; set; }

        public List<User> AhijadoList { get; set; }
        public string RawJsonData { get; set; }

        public ListaAhijadoModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public void OnGet()
        {
            role = HttpContext.Session.GetString("role");
            AhijadoList = new List<User>
            {
                new User
                {
                    Email = "mario.lara21@estudiantec.cr",
                    Role = 2,
                    PersonName = "Mario",
                    FirstLastName = "Lara",
                    SecondLastName = "Molina",
                    NumContact = 85631892,
                    DegreeName = "Ingenieria en Computacion",
                    Province = "San Jose",
                    Canton = "San Jose",
                    District = "Hospital",
                    Likings = new List<LikingUser>
                    {
                        new LikingUser { Name = "Anime" },
                        new LikingUser { Name = "Idiomas" }
                    }, 
                    Comment = "Me gusta One Piece"
                }, 

                 new User
                {
                    Email = "andres2028@estudiantec.cr",
                    Role = 2,
                    PersonName = "Andres",
                    FirstLastName = "Sanchez",
                    SecondLastName = "Rojas",
                    NumContact = 65734522,
                    DegreeName = "Ingenier�a en Computaci�n",
                    Province = "San Jose",
                    District = "Pavas",
                    Canton = "San Jose",
                    Likings = new List<LikingUser>
                    {
                        new LikingUser { Name = "Viajar" },
                        new LikingUser { Name = "Gimnasio" }, 
                        new LikingUser { Name = "Politica" }
                    },
                    Comment = "Soy alergico al sol"
                },
                new User
                {
                    Email = "avenegas@estudiantec.cr",
                    Role = 2,
                    PersonName = "Ana",
                    FirstLastName = "Venegas",
                    SecondLastName = "Vargas",
                    NumContact = 88653423,
                    DegreeName = "Ingenier�a Mecatr�nica",
                    Province = "Cartago",
                    District = "Oriental",
                    Canton = "Cartago",
                    Likings = new List<LikingUser>
                    {
                        new LikingUser { Name = "Dibujo" },
                        new LikingUser { Name = "Lectura" }
                    }, 
                    Comment = "Odio el marxismo"
                },
                new User
                {
                    Email = "chacalerks@estudiantec.cr",
                    Role = 2,
                    PersonName = "Maynor Erks",
                    FirstLastName = "Martinez",
                    SecondLastName = "Hernandez",
                    NumContact = 88215271,
                    DegreeName = "Ingenier�a en Computaci�n",
                    Province = "San Jose",
                    District = "Escaz�",
                    Canton = "Escaz�",
                   Likings = new List<LikingUser>
                    {
                        new LikingUser { Name = "Musica" },
                        new LikingUser { Name = "Deportes" }, 
                        new LikingUser { Name = "Videojuegos" }
                    },
                   Comment = "Corro todos los dias"
                },
                new User
                {
                    Email = "machobg08@estudiantec.cr",
                    Role = 2,
                    PersonName = "Alex",
                    FirstLastName = "Brenes",
                    SecondLastName = "Garita",
                    NumContact = 88213452,
                    DegreeName = "Ingenier�a Mecatr�nica",
                    Province = "San Jose",
                    District = "Zapote",
                    Canton = "San Jose",
                    Likings = new List<LikingUser>
                    {
                        new LikingUser { Name = "Anime" },
                        new LikingUser { Name = "Cine" }
                    },
                    Comment = "Duermo con el ventilador prendido"
                }
            };
        }
    }
  
}
