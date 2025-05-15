namespace MovieBlazor.Components.Classes
{
    public interface IMovieApiService
    {
        Task<List<MovieDto>> GetAllMovies();
        Task<MovieDto> GetMovie(int id);
        Task<bool> DeleteMovie(int id);
        Task<MovieDto> CreateMovie(MovieDto movie);
        Task<MovieDto> UpdateMovie(int id, MovieDto movie);
    }
}
