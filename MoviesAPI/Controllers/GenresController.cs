using System;
using AutoMapper;
using System.Linq;
using MoviesAPI.DTOs;
using MoviesAPI.Helpers;
using MoviesAPI.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ILogger<GenresController> _logger;
        private readonly MoviesDbContext _context;
        private readonly IMapper _mapper;

        public GenresController(
            ILogger<GenresController> logger,
            MoviesDbContext context,
            IMapper mapper)
        {
            this._logger = logger;
            this._context = context;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GenreDto>>> Get([FromQuery] PaginationDto paginationDto)
        {
            var queryable = this._context
                .Genres
                .AsQueryable();

            await HttpContext.InsertParametersPaginationInHeader(queryable);

            var genres = await queryable
                .OrderBy(x => x.Name)
                .Paginate(paginationDto)
                .ToListAsync();

            return this._mapper.Map<List<GenreDto>>(genres);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GenreDto>> Get(int id)
        {
            var genre = await this._context
                .Genres
                .FirstOrDefaultAsync(g => g.Id == id);

            if (genre == null)
            {
                return NotFound();
            }

            return this._mapper.Map<GenreDto>(genre);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GenreCreationDto genreCreationDto)
        {
            var genre = this._mapper.Map<Genre>(genreCreationDto);

            this._context
                .Add(genre);

            await this._context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] GenreCreationDto genreCreationDto)
        {
            var genre = await this._context
                .Genres
                .FirstOrDefaultAsync(g => g.Id == id);

            if (genre == null)
            {
                return NotFound();
            }

            genre = this._mapper.Map(genreCreationDto, genre);
            await this._context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            throw new NotImplementedException();
        }
    }
}