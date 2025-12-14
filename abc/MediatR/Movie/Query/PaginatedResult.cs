using abc.Entities;

namespace abc.MediatR.Movie.Query
{
    public class PaginatedResult
    {
        public List<ScreeningDto> Screenings { get; set; }
        public bool HasPreviousPage;
        public bool HasNextPage;
        public int TotalPages;
    }
}
