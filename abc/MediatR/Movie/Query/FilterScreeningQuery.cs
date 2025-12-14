using abc.Entities;
using MediatR;

namespace abc.MediatR.Movie.Query
{
    public class FilterScreeningQuery(QueryParameters parameters) : IRequest<PaginatedResult>
    {
        public readonly QueryParameters parameters = parameters;
    }

    public class FilterBooksQueryHandler : IRequestHandler<FilterScreeningQuery, PaginatedResult>
    {
        private readonly ApplicationDbContext _dbContext;
        public FilterBooksQueryHandler(ApplicationDbContext dBContext)
        {
            _dbContext = dBContext;
        }

        public Task<PaginatedResult> Handle(FilterScreeningQuery request, CancellationToken cancellationToken)
        {
            QueryParameters parameters = request.parameters;
            List<Screening> screenings = _dbContext.Screenings.Where(x =>
            x.HasSubtitles == parameters.HasSubtitles && x.TicketPrice <= parameters.MaxTicketPrice && x.TicketPrice >= parameters.MinTicketPrice &&
                x.HallName == parameters.HallName && x.Movie.Title == parameters.MovieTitle && x.Movie.Genre == parameters.Genre &&
                x.Movie.Rating >= parameters.MinMovieRating && x.Movie.AgeRestriction <= parameters.MaxAgeRestriction &&
                x.Format == parameters.Format && x.Language == parameters.Language).ToList().
            GetRange(parameters.PageNumber * parameters.PageSize, parameters.PageNumber * (parameters.PageSize + 1));

            List<ScreeningDto> screeningDtos = new List<ScreeningDto>();
            foreach(Screening s in screenings)
            {
                screeningDtos.Add(ScreeningDto.FromScreening(s));
            }


            PaginatedResult result = new PaginatedResult
            {
                Screenings = screeningDtos,
                HasNextPage = parameters.PageNumber != Math.Ceiling((float)screenings.Count / parameters.PageNumber),
                HasPreviousPage = parameters.PageNumber != 0
            };

            return result;
        }
    }
}
