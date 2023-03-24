using System.ComponentModel.DataAnnotations.Schema;

namespace GEST.Models
{
    public class Photos
    {
        public int Id { get; set; }
        [ForeignKey("Project")]
        public int? ProjectId { get; set; }
        public virtual Projects? Project { get; set; }
        [ForeignKey("News")]
        public int? NewsId { get; set; }
        public virtual News? News { get; set; }
        public int? AchievementsId { get; set; }
        public virtual Achievements? Achievements { get; set; }
        public int? PagesId { get; set; }
        public virtual Pages? Pages { get; set; }
        public string PhotoPath { get; set; }
    }
}
