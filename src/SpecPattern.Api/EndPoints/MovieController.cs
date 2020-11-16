using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpecPattern.Domain;
using SpecPattern.Domain.Entities;

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
        public async Task<IActionResult> GetAsync() {
            var result = await _unitOfWork.Repository<Movie>().AllAsync();
            return result is null ? NotFound() : (IActionResult)Ok(result.ToList());
        }

        [HttpGet]
        [Route("id:{int}")]
        public async Task<IActionResult> GetIdAsync(int id)
        {
            var result = await _unitOfWork.Repository<Movie>().GetAsync(id);
            return result is null ? NotFound() : (IActionResult)Ok(result);
        }
    }
}
