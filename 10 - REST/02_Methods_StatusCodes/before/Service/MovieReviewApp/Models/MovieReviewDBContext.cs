using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MovieReviewApp.Models;
using System.IO;
using System.Xml.Linq;
using System.Data.Entity.Infrastructure;
using MovieReviewApp.Service;

[assembly: PreApplicationStartMethod(typeof(MovieWebAppDBContext), "AppStart")]

namespace MovieReviewApp.Models
{
    public class MovieWebAppDBContext : DbContext
    {
        static MovieWebAppDBContext()
        {
            //Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0", "|DataDirectory|", "");
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ReviewerGenre> ReviewerGenres { get; set; }

        public static void AppStart()
        {
            //Database.SetInitializer<MovieWebAppDBContext>(new DbInitStrat());
        }

        class DbInitStrat : DropCreateDatabaseIfModelChanges<MovieWebAppDBContext>
        {
            protected override void Seed(MovieWebAppDBContext ctx)
            {
                //var xmlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data\\MovieDB.xml");
                var xmlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\data\Movies.xml");
                if (File.Exists(xmlFile))
                {
                    var xml = XElement.Load(xmlFile);

                    PopulateDirectors(ctx, xml);
                    PopulateCountries(ctx, xml);
                    PopulateGenres(ctx, xml);
                    PopulateMovies(ctx, xml);
                    PopulateUsers(ctx, xml);
                    PopulateReviews(ctx, xml);
                    PopulateReviewers(ctx);
                }
            }

            private void PopulateReviewers(MovieWebAppDBContext ctx)
            {
                var genres = ctx.Genres.ToArray();
                foreach (var genre in genres)
                {
                    if (genre.ID % 2 == 0)
                    {
                        var rg = new ReviewerGenre {GenreID = genre.ID, UserID="reviewer1" };
                        ctx.ReviewerGenres.Add(rg);
                    }
                    if (genre.ID % 3 == 0)
                    {
                        var rg = new ReviewerGenre { GenreID = genre.ID, UserID = "reviewer2" };
                        ctx.ReviewerGenres.Add(rg);
                    }
                    if (genre.ID % 4 == 0)
                    {
                        var rg = new ReviewerGenre { GenreID = genre.ID, UserID = "reviewer3" };
                        ctx.ReviewerGenres.Add(rg);
                    }
                }
                ctx.SaveChanges();
            }

            private void PopulateReviews(MovieWebAppDBContext ctx, XElement xml)
            {
                var rnd = new Random();

                var movieQ =
                    from x in xml.Descendants("movie")
                    select x;
                foreach (var item in movieQ)
                {
                    var title = (string)item.Element("title");
                    int? stars = null;
                    if (null != item.Element("stars") && !String.IsNullOrEmpty(item.Element("stars").Value))
                    {
                        stars = Convert.ToInt32(Math.Round((double)item.Element("stars")));
                    }
                    var review = (string)item.Element("review");

                    var movie = ctx.Movies.Where(x => x.Title == title).First();
                    var usr = "reviewer3";
                    if (movie.ID % 2 == 0)
                    {
                        usr = "reviewer1";
                    }
                    else if (movie.ID % 3 == 0)
                    {
                        usr = "reviewer2";
                    }

                    var dt = new DateTime(movie.Year, 1, 1);
                    if (movie.Year < 1960) dt = new DateTime(1960, 1, 1);
                    var diff = DateTime.Now.Subtract(dt);
                    dt = dt.AddDays(rnd.Next(30, diff.Days));
                    
                    var r = new Review
                    {
                        Comment = review, Stars = stars, ReviewDate = dt, MovieID = movie.ID, UserID = usr
                    };
                    ctx.Reviews.Add(r);
                }

                ctx.SaveChanges();
            }

            private void PopulateUsers(MovieWebAppDBContext ctx, XElement xml)
            {
                var userRep = new UserRepository() { context = ctx };
                AuthenticationService svc = new AuthenticationService(userRep);
                svc.Register("admin", "admin", "admin@admin.com");
                var q =
                    from x in userRep.All
                    where x.ID == "admin"
                    select x;
                foreach (var item in q)
                {
                    item.IsRoleAdmin = true;
                }
                userRep.Save();

                svc.Register("reviewer1", "reviewer1", "reviewer1@review.com");
                svc.Register("reviewer2", "reviewer2", "reviewer2@review.com");
                svc.Register("reviewer3", "reviewer3", "reviewer3@review.com");
                q =
                    from x in userRep.All
                    where x.ID.StartsWith("reviewer")
                    select x;
                var list = q.ToArray();
                string[] names = { "One", "Two", "Three" };
                for (int i = 0; i < list.Length; i++)
                {
                    var item = list[i];
                    item.FirstName = "Reviewer";
                    item.LastName = names[i];
                    item.IsRoleReviewer = true;
                }

                svc.Register("user1", "user1", "user1@user.com");
                svc.Register("user2", "user2", "user2@user.com");
                svc.Register("user3", "user3", "user3@user.com");
                q =
                    from x in userRep.All
                    where x.ID.StartsWith("user")
                    select x;
                list = q.ToArray();
                //names = { "One", "Two", "Three" };
                for (int i = 0; i < list.Length; i++)
                {
                    var item = list[i];
                    item.FirstName = "User";
                    item.LastName = names[i];
                    item.IsRoleRegisteredUser = true;
                }
                userRep.Save();
            }

            private static void PopulateMovies(MovieWebAppDBContext ctx, XElement xml)
            {
                var movieQ =
                    from x in xml.Descendants("movie")
                    select x;
                foreach (var item in movieQ)
                {
                    var movie = new Movie();
                    movie.Title = (string)item.Element("title");
                    movie.Description = (string)item.Element("description");
                    movie.Rating = (string)item.Element("rating");
                    var year = (string)item.Element("year");
                    if (year != null) movie.Year = Int32.Parse(year);
                    var director = (string)item.Element("director");
                    if (!String.IsNullOrEmpty(director))
                    {
                        movie.DirectorID = ctx.Directors.Where(x => x.Name == director).Single().ID;
                    }
                    var country = (string)item.Element("country");
                    if (!String.IsNullOrEmpty(country))
                    {
                        country = country.Split(',')[0];
                        movie.CountryID = ctx.Countries.Where(x => x.Name == country).Single().ID;
                    }
                    var genreNames =
                        from x in item.Element("genres").Elements("genre")
                        select x.Value;
                    var genres =
                        from x in ctx.Genres
                        where genreNames.Contains(x.Name)
                        select x;
                    movie.Genres.AddRange(genres);
                    
                    var poster = item.Element("base64Image").Value;
                    if (!String.IsNullOrEmpty(poster))
                    {
                        var posterDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content\\Posters");
                        Directory.CreateDirectory(posterDir);
                        movie.PosterName = movie.Title.Replace(" ", "")+".jpg";
                        var posterFile = Path.Combine(posterDir, movie.PosterName);
                        if (!File.Exists(posterFile))
                        {
                            try
                            {
                                File.WriteAllBytes(posterFile, Convert.FromBase64String(poster));
                            }
                            catch 
                            {
                                movie.PosterName = null;
                            }
                        }
                    }
                    ctx.Movies.Add(movie);
                    try
                    {
                        ctx.SaveChanges();
                    }
                    catch
                    {
                        foreach (var err in ctx.GetValidationErrors())
                        {
                            var msg = err.ValidationErrors.First().ErrorMessage;
                        }
                    }
                }
            }

            private static void PopulateGenres(MovieWebAppDBContext ctx, XElement xml)
            {
                var genreQ =
                    from x in xml.Descendants("genre")
                    where x != null && x.Value != null
                    select x.Value;
                foreach (var item in genreQ.Distinct())
                {
                    ctx.Genres.Add(new Genre { Name = item });
                }
                ctx.SaveChanges();
            }

            private static void PopulateCountries(MovieWebAppDBContext ctx, XElement xml)
            {
                var countryQ =
                    from x in xml.Descendants("country")
                    where x != null && x.Value != null
                    let names = x.Value.Split(',')
                    from y in names
                    select y.Trim(); 
                foreach (var item in countryQ.Distinct())
                {
                    ctx.Countries.Add(new Country { Name = item });
                }
                ctx.SaveChanges();
            }

            private static void PopulateDirectors(MovieWebAppDBContext ctx, XElement xml)
            {
                var directorQ =
                    from x in xml.Descendants("director")
                    where x != null && x.Value != null && x.Value != ""
                    select x.Value;
                foreach (var item in directorQ.Distinct())
                {
                    ctx.Directors.Add(new Director { Name = item });
                }
                ctx.SaveChanges();
            }
        }
    }
}
