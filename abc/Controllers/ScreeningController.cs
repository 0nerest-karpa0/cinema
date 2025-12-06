using abc.Entities;
using Microsoft.AspNetCore.Mvc;

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
        public ScreeningController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Screening> GetAll()
        {
            return _context.screenings.ToList();
        }

        [HttpPost("add-random-data/{screeningCount:int}")]
        public ActionResult AddRandomData([FromRoute] int screeningCount)
        {
            Random rng = new Random();

            List<Screening> randomData = new List<Screening>();
            for (int i = 0; i < screeningCount; i++)
            {
                int hasSubtitles = rng.Next(0, 1);

                Screening screening = new Screening
                {

                    HallName = $"Hall {rng.Next(1, 10)}",
                    ScreeningTime = DateTime.Now,
                    TicketPrice = rng.Next(10, 50) + (float)rng.NextDouble(),
                    Format = _formats[rng.Next(0, _formats.Count)],
                    HasSubtitles = hasSubtitles == 1,
                    Language = _languages[rng.Next(0, _languages.Count)],
                    MovieId = 1,
                };

                randomData.Add(screening);
            }

            _context.screenings.AddRange(randomData);
            int entitiesChanged = _context.SaveChanges();
            return entitiesChanged == screeningCount ? Created() : StatusCode(500);
        }
    }
}
