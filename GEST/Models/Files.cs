namespace GEST.Models
{
    public class Files
    {
        public int Id { get; set; }
        public int? ProjectId { get; set; }
        public virtual Projects Project { get; set; }
        public int? NewsId { get; set; }
        public virtual News News { get; set; }
        public int? AchievementsId { get; set; }
        public virtual Achievements? Achievements { get; set; }
        public int? PagesId { get; set; }
        public virtual Pages? Pages { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
    }
}
