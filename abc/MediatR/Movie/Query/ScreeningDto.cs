using abc.Entities;

namespace abc.MediatR.Movie.Query
{
    public class ScreeningDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public int Rating { get; set; }
        public int AgeRestriction { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string? PosterUrl { get; set; }
        public string HallName { get; set; }
        public DateTime ScreeningTime { get; set; }
        public float TicketPrice { get; set; }
        public string Format { get; set; }
        public bool HasSubtitles { get; set; }
        public string Language { get; set; }


        public static ScreeningDto FromScreening(Screening screening)
        {
            return new ScreeningDto
            {
                Title = screening.Movie.Title,
                Description = screening.Movie.Description,
                Genre = screening.Movie.Genre,
                Duration = screening.Movie.Duration,
                Rating = screening.Movie.Rating,
                AgeRestriction = screening.Movie.AgeRestriction,
                ReleaseDate = screening.Movie.ReleaseDate,
                PosterUrl = screening.Movie.PosterUrl,
                HallName = screening.HallName,
                ScreeningTime = screening.ScreeningTime,
                TicketPrice = screening.TicketPrice,
                Format = screening.Format,
                HasSubtitles = screening.HasSubtitles,
                Language = screening.Language,
            };
        }
    }
}
