using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LayoutTemplateWebApp.Model
{
    public class GodchildXLiking
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Godchild")]
        public string Email { get; set; }
        public virtual Godchild Godchild { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Liking")]
        public int LikingId { get; set; }
        public virtual Liking Liking { get; set; }
    }
}
