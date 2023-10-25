using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LayoutTemplateWebApp.Model
{
    public class MentorXLiking
    {
        [ForeignKey("Mentor")]
        public string MentorEmail { get; set; }
        public virtual Mentor Mentor { get; set; }

        [ForeignKey("Liking")]
        public int LikingId { get; set; }
        public virtual Liking Liking { get; set; }

    }


}
