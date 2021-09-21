﻿using System;
using AutoMapper;
using MoviesAPI.DTOs;
using MoviesAPI.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Helpers;

namespace MoviesAPI.Controllers
{
    [Route("api/genres")]
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

        [HttpGet("{id:int}", Name = "getGenre")]
        public ActionResult<Genre> Get(int id)
        {
            throw new NotImplementedException();
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