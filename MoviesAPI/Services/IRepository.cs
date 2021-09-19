using MoviesAPI.Entities;
using System.Collections.Generic;

namespace MoviesAPI.Services
{
    public interface IRepository
    {
        List<Genre> GetAllGenres();
    }
}
