using MoviesAPI.Services;

namespace MoviesAPI.Controllers
{
    public class GenresController
    {
        private readonly IRepository _repository;

        public GenresController(IRepository repository)
            => this._repository = repository;
    }
}