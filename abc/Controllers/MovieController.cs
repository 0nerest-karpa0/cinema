using abc.Entities;
using Microsoft.AspNetCore.Mvc;

namespace abc.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private List<int> _ageRestrictions = new List<int> { 0, 16, 18 };
        private List<string?> _postersUrl = new List<string?> { null, 
            "https://upload.wikimedia.org/wikipedia/commons/thumb/0/07/Dromaius_peroni.jpg/960px-Dromaius_peroni.jpg?20110925025356", 
            "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6d/Penis_park_korea.jpg/500px-Penis_park_korea.jpg?20120917122133", 
            "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1e/Wozzeck_poster_1925_%281%29.jpg/960px-Wozzeck_poster_1925_%281%29.jpg?20251130093045" };

        private List<string> _genres = new List<string> { "Drama", "Horror", "Action", "Fantasy", "Thriller", "Western", "Romance", "Comedy", "Animation" };
        private List<string> _descriptions = new List<string> { "Aenean non arcu venenatis, fringilla odio eget, faucibus dolor.", 
            "Curabitur sed sem mollis dolor tincidunt efficitur.","Sed at ligula malesuada, pharetra neque eget, porttitor neque.",
            "Quisque vehicula quam at nibh volutpat, et bibendum nulla mollis.", "Suspendisse imperdiet libero nec volutpat molestie."};
        private List<string> _titlesWords = new List<string> { "etiam", "eget", "elit", "elit", "nulla", "semper", "orci", "quis", "libero", "ullamcorper" };

        private ApplicationDbContext _context;
        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Movie> GetAll()
        {
            return _context.Movies.ToList(); 
        }


        [HttpPost("add-random-data/{movieCount:int}")]
        public ActionResult AddRandomData([FromRoute] int movieCount)
        {
            Random rng = new Random();
            List<Movie> randomMovies = new List<Movie>();
            for (int i = 0; i < movieCount; i++)
            {
                DateTime now = DateTime.Now;
                Movie movie = new Movie
                {
                    Title = $"{_titlesWords[rng.Next(0, _titlesWords.Count)]} {_titlesWords[rng.Next(0, _titlesWords.Count)]}",
                    Description = _descriptions[rng.Next(0,_descriptions.Count)],
                    Genre = _genres[rng.Next(0, _genres.Count)],
                    Duration = rng.Next(30, 150),
                    Rating = rng.Next(1, 5),
                    AgeRestriction = _ageRestrictions[rng.Next(0, _ageRestrictions.Count)],
                    ReleaseDate = $"{rng.Next(1,29)}.{rng.Next(1,12)}.{rng.Next(1990, 2025)}",
                    PosterUrl = _postersUrl[rng.Next(0, _postersUrl.Count)],
                    CreatedAt = $"{now.Day}.{now.Month}.{now.Year} {now.Hour}:{now.Minute}:{now.Second}"
                };
                randomMovies.Add(movie);
            }

            _context.AddRange(randomMovies);

            int entitiesChanged = _context.SaveChanges();
            return entitiesChanged == movieCount ? Created() : StatusCode(500);
        }
    }
}
