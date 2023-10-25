

namespace LayoutTemplateWebApp.Model
{
    public static class UserData
    {
        public static List<User> Users { get; } = new List<User>
        {
            new User
                {
                    Email = "ldfozamis@estudiantec.cr",
                    Role = 2,
                    PersonName = "Leonardo David",
                    FirstLastName = "Fariña",
                    SecondLastName = "Ozamis",
                    NumContact = 85631892,
                    DegreeName = "Ingeniería en Computación",
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
                    DegreeName = "Ingeniería en Computación",
                    Province = "San Jose",
                    District = "Piedades",
                    Canton = "Santa Ana",
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
                    DegreeName = "Ingeniería Mecatrónica",
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
                    DegreeName = "Ingeniería en Computación",
                    Province = "San Jose",
                    District = "San Rafael",
                    Canton = "Escazú",
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
                    DegreeName = "Ingeniería Mecatrónica",
                    Province = "San Jose",
                    District = "Guadalupe",
                    Canton = "Goicoechea",
                    Likings = new List<LikingUser>
                    {
                        new LikingUser { Name = "Anime" },
                        new LikingUser { Name = "Cine" }
                    },
                    Comment = "Duermo con el ventilador prendido"
                },


        new User
        {
            Email = "mariolara.21@estudiantec.cr",
            Role = 3,
            PersonName = "Mario Alberto",
            FirstLastName = "Lara",
            SecondLastName = "Molina",
            NumContact = 85631892,
            DegreeName = "Ingeniería en Computación",
            Province = "San Jose",
            Canton = "San Jose",
            District = "Merced",
            Likings = new List<LikingUser>
                    {
                        new LikingUser { Name = "Videojuegos" },
                        new LikingUser { Name = "Cine" }
                    },
                    Comment = "Me gusta One Piece"
        },

        new User
        {
            Email = "jmorales@estudiantec.cr",
            Role = 3,
            PersonName = "Juan",
            FirstLastName = "Morales",
            SecondLastName = "Vargas",
            NumContact = 85631892,
            DegreeName = "Ingeniería en Computación",
            Province = "Cartago",
            Canton = "Turrialba",
            District = "La Suiza",
            Likings = new List<LikingUser>
                    {
                        new LikingUser { Name = "Videojuegos" },
                        new LikingUser { Name = "Cine" }
                    },
                    Comment = "Me gusta One Piece"
        },
        new User
        {
            Email = "fermurillo04@estudiantec.cr",
            Role = 3,
            PersonName = "María Fernanda",
            FirstLastName = "Murillo",
            SecondLastName = "Mena",
            NumContact = 85633321,
            DegreeName = "Ingenieria Mecatrónica",
            Province = "San Jose",
            Canton = "Moravia",
            District = "San Vicente",
            Likings = new List<LikingUser>
                    {
                        new LikingUser { Name = "Moda" },
                        new LikingUser { Name = "Gimnasio" }
                    },
            Comment = "No me gusta gritar"
        }
    };

    }
}

