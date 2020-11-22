using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpecPattern.Api.EndPoints.Models;
using SpecPattern.Domain;
using SpecPattern.Domain.Entities;
using SpecPattern.Domain.Spedifications;

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
        public async Task<IActionResult> GetAsync(FilterMovie filterMovie)
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
            var result = await _unitOfWork.Repository<Movie>()
                .FindAsync(spec);
            return result is null ? NotFound() : (IActionResult)Ok(result.ToList());
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
            if (!specification.IsSatisfiedBy(result)) {
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
            var specification = new  AvailabeOnCDSpecification();
            if (!specification.IsSatisfiedBy(result))
            {
                return Conflict("The movie doesn´t have a CD version");
            }
            return Ok(result);
        }
    }
}
