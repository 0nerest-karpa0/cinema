using System.ComponentModel.DataAnnotations.Schema;

namespace abc.Entities
{
    public class Screening
    {
        public int Id { get; set; }
        public required  string HallName { get; set; }
        public required DateTime ScreeningTime { get; set; }
        public required int TotalSeats { get; set; }
        public required int AvailableSeats { get; set; }
        public required float TicketPrice { get; set; }
        public required string Format { get; set; }
        public required bool HasSubtitles { get; set; }
        public required string Language { get; set; }
        public required int MovieId { get; set; }

        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set; }
    }
}
