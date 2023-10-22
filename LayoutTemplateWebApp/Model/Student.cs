using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace LayoutTemplateWebApp.Model
{
    public class Student
    {
        [Key]
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("isExemptFromPrintingCosts")]
        public bool IsExemptFromPrintingCosts { get; set; }
        [JsonPropertyName("degreeId")]
        public int DegreeId { get; set; }
        [JsonPropertyName("degreeName")]
        public string DegreeName { get; set; }
    }
}