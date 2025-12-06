namespace abc.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Duration { get; set; }
        public int Rating { get; set; }
        public int AgeRestriction { get; set; }
        public int ReleaseDate { get; set; }
        public string? PosterUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
