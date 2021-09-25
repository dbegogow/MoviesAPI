using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.DTOs;
using MoviesAPI.Entities;
using MoviesAPI.Helpers;

namespace MoviesAPI.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private const string ContainerName = "actors";

        private readonly MoviesDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileStorageService _fileStorageService;

        public ActorsController(
            MoviesDbContext context,
            IMapper mapper,
            IFileStorageService fileStorageService)
        {
            this._context = context;
            this._mapper = mapper;
            this._fileStorageService = fileStorageService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActorDto>>> Get()
        {
            var actors = await this._context
                .Actors
                .ToListAsync();

            return this._mapper.Map<List<ActorDto>>(actors);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ActorDto>> Get(int id)
        {
            var actor = await this._context
                .Actors
                .FirstOrDefaultAsync(a => a.Id == id);

            if (actor == null)
            {
                return NotFound();
            }

            return this._mapper.Map<ActorDto>(actor);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ActorCreationDto actorCreationDto)
        {
            var actor = this._mapper.Map<Actor>(actorCreationDto);

            if (actorCreationDto.Picture != null)
            {
                actor.Picture = await this._fileStorageService.SaveFile(ContainerName, actorCreationDto.Picture);
            }

            this._context.Add(actor);
            await this._context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ActorCreationDto actorCreationDto)
        {
            throw new NotImplementedException();
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var actor = await this._context
                .Actors
                .FirstOrDefaultAsync(a => a.Id == id);

            if (actor == null)
            {
                return NotFound();
            }

            this._context.Remove(actor);
            await this._context.SaveChangesAsync();

            return NoContent();
        }
    }
}
