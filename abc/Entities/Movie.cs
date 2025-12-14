namespace abc.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public int Rating { get; set; }
        public int AgeRestriction { get; set; }
        public string ReleaseDate { get; set; }
        public string? PosterUrl { get; set; }
        public string CreatedAt { get; set; }
    }
}
