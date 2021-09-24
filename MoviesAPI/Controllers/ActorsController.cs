using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.DTOs;

namespace MoviesAPI.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly MoviesDbContext _context;
        private readonly IMapper _mapper;

        public ActorsController(
            MoviesDbContext context,
            IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
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
        public async Task<ActionResult> Post([FromBody] ActorCreationDto actorCreationDto)
        {
            throw new NotImplementedException();
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
