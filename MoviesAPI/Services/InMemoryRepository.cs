using MoviesAPI.Entities;
using System.Collections.Generic;

namespace MoviesAPI.Services
{
    public class InMemoryRepository : IRepository
    {
        private readonly List<Genre> _genres;

        public InMemoryRepository()
        {
            this._genres = new List<Genre>
            {
                new Genre{Id = 1, Name = "Comedy"},
                new Genre{Id = 2, Name = "Action"}
            };
        }

        public List<Genre> GetAllGenres()
            => this._genres;
    }
}
