using LayoutTemplateWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LayoutTemplateWebApp.Pages.AdminSAMA
{
    public class AsignacionesModel : PageModel
    {
        public string role { get; set; }
        public List<Assignment> Assignments { get; set; }

        [BindProperty]
        public string FilterEmailMentor { get; set; }

        public void OnGet()
        {
            role = HttpContext.Session.GetString("role");
            LoadAssignments();
        }

        public void OnPost()
        {
            role = HttpContext.Session.GetString("role");
            LoadAssignments();
        }

        public void OnPostAssign()
        {
            role = HttpContext.Session.GetString("role");
            MakeAssignments();
            LoadAssignments();
        }

        private void LoadAssignments()
        {
            Assignments = UserData.AssignmentsList;  // Cargar las asignaciones de la lista estática

            if (!string.IsNullOrEmpty(FilterEmailMentor))
            {
                Assignments = Assignments.Where(a => a.Mentor.Email.Contains(FilterEmailMentor, System.StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }


        private void MakeAssignments()
        {
            Assignments = new List<Assignment>();
            var ahijados = UserData.Users.Where(u => u.Role == 2).ToList();
            var mentors = UserData.Users.Where(u => u.Role == 3).ToList();

            // Agrupar a los ahijados por carrera
            var groupedAhijados = ahijados.GroupBy(a => a.DegreeName).ToDictionary(group => group.Key, group => group.ToList());

            int mentorIndex = 0;
            bool ahijadoAsignado = true;

            while (ahijadoAsignado)
            {
                ahijadoAsignado = false; // reset for each loop

                foreach (var mentor in mentors)
                {
                    if (!groupedAhijados.ContainsKey(mentor.DegreeName)) continue;

                    var ahijadosOfSameDegree = groupedAhijados[mentor.DegreeName];
                    User bestMatchAhijado = null;

                    // Prioridad 1: Coincidencia de carrera, provincia y gustos
                    bestMatchAhijado = ahijadosOfSameDegree.FirstOrDefault(a =>
                        a.Province == mentor.Province &&
                        a.Likings.Select(l => l.Name).Intersect(mentor.Likings.Select(l => l.Name)).Any());

                    // Prioridad 2: Coincidencia de carrera y provincia
                    if (bestMatchAhijado == null)
                    {
                        bestMatchAhijado = ahijadosOfSameDegree.FirstOrDefault(a => a.Province == mentor.Province);
                    }

                    // Prioridad 3: Coincidencia de carrera y gustos
                    if (bestMatchAhijado == null)
                    {
                        bestMatchAhijado = ahijadosOfSameDegree.FirstOrDefault(a =>
                            a.Likings.Select(l => l.Name).Intersect(mentor.Likings.Select(l => l.Name)).Any());
                    }

                    // Prioridad 4: Cualquier ahijado de la misma carrera
                    if (bestMatchAhijado == null)
                    {
                        bestMatchAhijado = ahijadosOfSameDegree.FirstOrDefault();
                    }

                    if (bestMatchAhijado != null)
                    {
                        Assignments.Add(new Assignment
                        {
                            Mentor = mentor,
                            Godchild = bestMatchAhijado
                        });

                        ahijadosOfSameDegree.Remove(bestMatchAhijado);
                        if (ahijadosOfSameDegree.Count == 0)
                        {
                            groupedAhijados.Remove(mentor.DegreeName);
                        }
                        ahijadoAsignado = true;
                    }

                    mentorIndex++;
                    if (mentorIndex == mentors.Count) mentorIndex = 0;
                }
            }

            UserData.AssignmentsList.Clear();
            UserData.AssignmentsList.AddRange(Assignments);
        }
    }
}
