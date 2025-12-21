using abc.Entities;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using abc.MediatR.Movie.Query;

namespace abc.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ScreeningController : ControllerBase
    {
        private static readonly List<string> _formats = new List<string> { "2D", "3D", "IMAX" };
        private static readonly List<string> _languages = new List<string> { "English", "Chinese", "Hindi", "Spanish", "Arabic",
            "French", "Bengali", "Portuguese", "Russian", "Indonesian" };

        private ApplicationDbContext _context;
        private ISender _sender;
        public ScreeningController(ApplicationDbContext context, ISender sender)
        {
            _context = context;
            _sender = sender;
        }

        [HttpGet]
        public List<Screening> GetAll()
        {
            return _context.Screenings.ToList();
        }

        [HttpPost("add-random-data/{screeningCount:int}")]
        public ActionResult AddRandomData([FromRoute] int screeningCount)
        {
            Random rng = new Random();
            List<Movie> allMovies = _context.Movies.ToList();

            List<Screening> randomData = new List<Screening>();
            DateTime now = DateTime.Now;
            for (int i = 0; i < screeningCount; i++)
            {
                int hasSubtitles = rng.Next(0, 1);
                int totalSeats = rng.Next(50, 80);
                now.AddDays(rng.Next(0, 21));
                Screening screening = new Screening
                {
                    HallName = $"Hall {rng.Next(1, 10)}",
                    ScreeningTime = new DateTime(now.Year, now.Month, now.Day, rng.Next(0,23), rng.Next(0,59), 0),
                    TicketPrice = rng.Next(10, 50) + (float)rng.NextDouble(),
                    Format = _formats[rng.Next(0, _formats.Count)],
                    HasSubtitles = hasSubtitles == 1,
                    Language = _languages[rng.Next(0, _languages.Count)],
                    MovieId = allMovies[rng.Next(0, allMovies.Count)].Id,
                    TotalSeats = rng.Next(50, 80),
                    AvailableSeats = rng.Next(0, totalSeats)
                };

                randomData.Add(screening);
            }

            _context.Screenings.AddRange(randomData);
            int entitiesChanged = _context.SaveChanges();
            return entitiesChanged == screeningCount ? Created() : StatusCode(500);
        }

        [HttpGet("/apply-filter")]
        public PaginatedResult GetFilteredBooks([FromQuery]QueryParameters parameters)
        {
            return _sender.Send(new FilterScreeningsQuery(parameters)).Result;
        }
    }
}
