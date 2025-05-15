using System.Net.Http.Json;

namespace MovieBlazor.Components.Classes
{
    public class MovieApiService : IMovieApiService
    {
        private readonly HttpClient _http;

        public MovieApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<MovieDto>> GetAllMovies()
        {
            var response = await _http.GetAsync("api/movie/getallmovies");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<MovieDto>>() ?? new List<MovieDto>();
            }

            throw new Exception("Ошибка при загрузке фильмов");
        }

        public async Task<MovieDto> GetMovie(int id)
        {
            var response = await _http.GetAsync($"api/movie/getmovieinfo/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<MovieDto>();
            }

            throw new Exception("Фильм не найден");
        }

        public async Task<bool> DeleteMovie(int id)
        {
            var response = await _http.DeleteAsync($"api/movie/deletemovie/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<MovieDto> CreateMovie(MovieDto movie)
        {
            var response = await _http.PostAsJsonAsync("api/movie/createnewmovie", movie);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<MovieDto>();
            }

            throw new Exception("Ошибка при создании фильма");
        }

        public async Task<MovieDto> UpdateMovie(int id, MovieDto movie)
        {
            var response = await _http.PutAsJsonAsync($"api/movie/updatemovie/{id}", movie);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<MovieDto>();
            }

            throw new Exception("Ошибка при обновлении фильма");
        }
    }
}
