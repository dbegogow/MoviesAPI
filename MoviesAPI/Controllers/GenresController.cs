using System;
using MoviesAPI.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace MoviesAPI.Controllers
{
    [Route("api/genres")]
    public class GenresController : ControllerBase
    {
        private readonly ILogger<GenresController> _logger;

        public GenresController(ILogger<GenresController> logger)
            => this._logger = logger;

        [HttpGet]
        public async Task<ActionResult<List<Genre>>> Get()
        {
            this._logger.LogInformation("Getting all the genres");

            return new List<Genre>() { new Genre { Id = 1, Name = "Comedy" } };
        }

        [HttpGet("{id:int}", Name = "getGenre")]
        public ActionResult<Genre> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Post([FromBody] Genre genre)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Genre genre)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            throw new NotImplementedException();
        }
    }
}