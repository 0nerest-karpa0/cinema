namespace abc.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Genre { get; set; }
        public required string Director { get; set; }
        public required int Duration { get; set; }
        public required int Rating { get; set; }
        public required int AgeRestriction { get; set; }
        public required DateOnly ReleaseDate { get; set; }
        public required string? PosterUrl { get; set; }
        public required DateTime CreatedAt { get; set; }
    }
}
