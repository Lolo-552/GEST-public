using GEST.Data;
using GEST.Areas.Admin.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using GEST.Models;

namespace GEST.Areas.Admin.Data
{
    namespace GEST.Data
    {
        public static class Seeder
        {
            public static void Seed(GESTContext _dbContext)
            {
                if (_dbContext.Database.CanConnect())
                {
                    if (!_dbContext.Admin.Any())
                    {
                        var admin = new Models.Admin();
                        admin.Login = "admin";
                        admin.Password = "admin";
                        admin.Email = "example@example";
                        _dbContext.Admin.Add(admin);
                        _dbContext.SaveChanges();
                    }

                    if (!_dbContext.HomePage.Any())
                    {
                        var homePage = new HomePage();
                        homePage.Language= "pl";
                        homePage.HeroHeader = "Koło naukowe interakcji człowiek komputer - GEST";
                        homePage.HeroP = "Podaj opis";
                        homePage.AboutUsHeader = "Charakterystyka działalności GEST";
                        homePage.AboutUsP = "Podaj opis";
                        homePage.JoinUsHeader = "Jesteś zainteresowany dołączeniem do koła?";
                        homePage.JoinUsP = "Podaj opis";
                        homePage.ProjectHeader = "Projekty";
                        homePage.NewsHeader = "Aktualności";
                        homePage.AchievementsHeader = "Osiągnięcia";
                        homePage.PublicationsHeader = "Publikacje";
                        homePage.ManagementHeader = "Zarząd";
                        homePage.Email = "example@example.com";

                        var homePageEng = new HomePage();
                        homePageEng.Language = "en";
                        homePageEng.HeroHeader = "GEST - human computer interaction science club";
                        homePageEng.HeroP = "Enter description";
                        homePageEng.AboutUsHeader = "Characteristics of the activity";
                        homePageEng.AboutUsP = "Enter description";
                        homePageEng.JoinUsHeader = "Are you interested in joining the academic club?";
                        homePageEng.JoinUsP = "Enter description";
                        homePageEng.ProjectHeader = "Projects";
                        homePageEng.NewsHeader = "News";
                        homePageEng.AchievementsHeader = "Achievements";
                        homePageEng.PublicationsHeader = "Publications";
                        homePageEng.ManagementHeader = "Managements";
                        homePageEng.Email = "example@example.com";

                        _dbContext.HomePage.Add(homePage);
                        _dbContext.HomePage.Add(homePageEng);
                        _dbContext.SaveChanges();
                    }
                }
            }
        }
    }
}
