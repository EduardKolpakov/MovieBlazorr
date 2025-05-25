namespace MovieBlazor.Components.Classes
{
    public interface IMovieApiService
    {
        Task<List<MovieDto>> GetAllMovies(string Token);
        Task<MovieDto> GetMovie(int id);
        Task<bool> DeleteMovie(int id);
        Task<MovieDto> CreateMovie(MovieDto movie);
        Task<MovieDto> UpdateMovie(int id, MovieDto movie);
        Task<AuthResponse> LoginAsync(LoginModel model);
        Task<List<UserContext>> GetAllUsers();
        Task<bool> GetChatWithUser(int SenderId, int ReceiverId);
    }
}
