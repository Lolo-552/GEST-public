using GEST.Models;
using System.Text.RegularExpressions;

namespace GEST.ViewModels
{
    public class HomePageModel
    {
        public IEnumerable<Projects>? Projects { get; set; }
        public Projects? Project { get; set; }
        public IEnumerable<Photos>? ProjectPhotos { get; set; }
        public IEnumerable<News>? News { get; set; }
        public News One_news { get; set; }
        public IEnumerable<Management>? Management { get; set; }
        public IEnumerable<Achievements>? Achievements { get; set; }
        public Achievements? Achievement { get; set; }
        public IEnumerable<Pages>? Pages { get; set; }
        public Pages? Page { get; set; }
        public IEnumerable<Publications>? Publications { get; set; }
        public HomePage? HomePage { get; set; }
    }
}
