namespace LayoutTemplateWebApp.Model
{
    public class Assignment
    {
        public User Mentor { get; set; }
        public User Godchild { get; set; }
        public List<string> CommonAttributes { get; set; } = new List<string>();  // Nueva propiedad
    }
}
