using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace LayoutTemplateWebApp.Model
{
    public class ApplicationRole
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("applicationId")]
        public int ApplicationId { get; set; }

        [JsonPropertyName("applicationRoleName")]
        public string ApplicationRoleName { get; set; }

        [JsonPropertyName("applicationName")]
        public string ApplicationName { get; set; }

        [JsonPropertyName("parentId")]
        public int? ParentId { get; set; }

        [JsonPropertyName("inverseparent")]
        [NotMapped]
        public List<object> InverseParent { get; set; }

        [JsonPropertyName("application")]
        [NotMapped]
        public object Application { get; set; }

        [JsonPropertyName("parent")]
        [NotMapped]
        public object Parent { get; set; }

        [JsonPropertyName("emails")]
        [NotMapped]
        public List<string> Emails { get; set; }
    }
}
