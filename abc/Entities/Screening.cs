using System.ComponentModel.DataAnnotations.Schema;

namespace abc.Entities
{
    public class Screening
    {
        public int Id { get; set; }
        public string HallName { get; set; }
        public string ScreeningTime { get; set; }
        public float TicketPrice { get; set; }
        public string Format { get; set; }
        public bool HasSubtitles { get; set; }
        public string Language { get; set; }
        public int MovieId { get; set; }

        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set; }
    }
}
