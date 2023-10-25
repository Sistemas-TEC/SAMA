namespace LayoutTemplateWebApp.Model
{
    public class User
    {
        public string Email { get; set; }
        public int Role { get; set; }
        public string PersonName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public int NumContact { get; set; }
        public string DegreeName { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Canton { get; set; }

        public string Comment { get; set; }
        public List<LikingUser> Likings { get; set; } = new List<LikingUser>();
    }

    public class LikingUser
    {
        public string Name { get; set; }
        
    }
}
