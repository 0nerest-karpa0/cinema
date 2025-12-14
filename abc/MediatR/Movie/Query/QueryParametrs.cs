namespace abc.MediatR.Movie.Query
{
    public class QueryParameters
    {
        public string MovieTitle; //!
        public string Genre; //!
        public string MinScreeningTime;
        public string MaxScreeningTime;
        public float MinTicketPrice; //!
        public float MaxTicketPrice; //!
        public string Format; //!
        public string Language; //!
        public bool HasSubtitles; //!
        public int MinMovieRating;//!
        public int MaxAgeRestriction;//!
        public string HallName;//!

        public int PageNumber;
        public int PageSize;
    }
}
