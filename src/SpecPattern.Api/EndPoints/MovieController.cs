using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpecPattern.Api.EndPoints.Models;
using SpecPattern.Domain;
using SpecPattern.Domain.Entities;
using SpecPattern.Domain.Spedifications;
using SpecPattern.Domain.Spedifications.Implementations;
using SpecPattern.Infrastructure.Repositories;

namespace SpecPattern.Api.EndPoints
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovieController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery]FilterMovie filterMovie)
        {
            Specification<Movie> spec = Specification<Movie>.All;
            if (filterMovie.ForKidsOnly)
            {
                spec = spec.And(new MovieForKidsSpecification());
            }
            if (filterMovie.OnCd)
            {
                spec = spec.And(new AvailabeOnCDSpecification());
            }
            if (!string.IsNullOrWhiteSpace(filterMovie.Director))
            {
                spec = spec.And(new MovieDirectedBySpecification(filterMovie.Director));
            }
            var repository = (MovieRepository)_unitOfWork.Repository<Movie>();
            var result = await repository.FindAsync(
                spec,
                filterMovie.MinimunRating,
                filterMovie.Page,
                filterMovie.PageSize);

            var movieDto = result.Select(s => new MovieDto
            {
                Id = s.Id,
                Director = s.Director.Name,
                Genre = s.Genre,
                MpaaRating = s.MpaaRating.ToString(),
                Name = s.Name,
                Rating = s.Rating,
                ReleaseDate = s.ReleaseDate
            });
            return result is null ? NotFound() : (IActionResult)Ok(movieDto.ToList());
        }

        [HttpGet]
        [Route("id:{int}")]
        public async Task<IActionResult> GetIdAsync(int id)
        {
            var result = await _unitOfWork.Repository<Movie>().GetAsync(id);
            return result is null ? NotFound() : (IActionResult)Ok(result);
        }

        [HttpPost]
        [Route("buy-adult-ticket/id:{int}")]
        public async Task<IActionResult> BuyAdultTicket(int movieId)
        {
            var result = await _unitOfWork.Repository<Movie>().GetAsync(movieId);
            return result is null ? NotFound() : (IActionResult)Ok(result);
        }
        [HttpPost]
        [Route("buy-child-ticket/id:{int}")]
        public async Task<IActionResult> BuyChildTicket(int movieId)
        {
            var result = await _unitOfWork.Repository<Movie>().GetAsync(movieId);
            if (result is null)
                return NotFound();
            var specification = new MovieForKidsSpecification();
            if (!specification.IsSatisfiedBy(result))
            {
                return Conflict("The mvie is not sutable for children");
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("buy-cd/id:{int}")]
        public async Task<IActionResult> BuyCd(int movieId)
        {
            var result = await _unitOfWork.Repository<Movie>().GetAsync(movieId);
            if (result is null)
                return NotFound();
            var specification = new AvailabeOnCDSpecification();
            if (!specification.IsSatisfiedBy(result))
            {
                return Conflict("The movie doesn´t have a CD version");
            }
            return Ok(result);
        }
    }
}
