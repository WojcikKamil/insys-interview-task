using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Model;
using MovieLibrary.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace MovieLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IRepository _repository;
        public MovieController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies([FromQuery] Paging paging, [FromQuery] FilteringProperties filter)
        {
            IPagedList result = await _repository.GetPagedListAsync(paging, filter);
            return Ok(result);
        }
    }
}
