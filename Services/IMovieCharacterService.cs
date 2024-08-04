using SwipeCardViewDemo.Models;

namespace SwipeCardViewDemo.Services
{
    public interface IMovieCharacterService
    {
        Task<List<MovieCharacter>> GetMovieCharacterDataAsync();
    }
}
