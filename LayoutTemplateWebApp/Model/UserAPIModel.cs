
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LayoutTemplateWebApp.Model
{
    public class UserAPIModel
    {

        [Key]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("personName")]
        public string PersonName { get; set; }

        [JsonPropertyName("firstLastName")]
        public string FirstLastName { get; set; }

        [JsonPropertyName("secondLastName")]
        public string SecondLastName { get; set; }

        [JsonPropertyName("debt")]
        public decimal Debt { get; set; }

        [JsonPropertyName("employee")]
        public Employee Employee { get; set; } // Assuming Employee can be a complex object

        [JsonPropertyName("student")]
        public Student Student { get; set; }
        [NotMapped]
        public List<Object> Departments { get; set; }

        [NotMapped]
        public List<Object> Schools { get; set; }

        [JsonPropertyName("applicationRoles")]
        public List<ApplicationRole> ApplicationRoles { get; set; }

        public string ProvinceName { get; set; }
        public string CantonName { get; set; }
        public string DistrictName { get; set; }
        public List<Liking> Likings { get; set; }
    }
}
