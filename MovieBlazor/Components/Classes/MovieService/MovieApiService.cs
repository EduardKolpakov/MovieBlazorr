using System.Net.Http.Headers;
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


        public async Task<List<MovieDto>> GetAllMovies(string token)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, "api/movie/getallmovies");

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            var response = await _http.SendAsync(request, CancellationToken.None);

            if (response.IsSuccessStatusCode)
            {
                // Сначала десериализуем весь ответ
                var apiResponse = await response.Content.ReadFromJsonAsync<MovieApiResponse>();

                return apiResponse?.Data.movies ?? new List<MovieDto>();
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
        public async Task<AuthResponse> LoginAsync(LoginModel model)
        {
            var response = await _http.PostAsJsonAsync("api/movie/authorization", model);

            if (response.IsSuccessStatusCode)
            {
                var authResponse = await response.Content.ReadFromJsonAsync<AuthResponse>();
                return authResponse;
            }

            throw new Exception("Ошибка при входе");
        }

        public async Task<List<UserContext>> GetAllUsers()
        {
            var response = await _http.GetAsync("api/movie/GetAllUsers");
            if (response.IsSuccessStatusCode)
            {
                var usersResponse = await response.Content.ReadFromJsonAsync<UserApiResponse>();
                return usersResponse.Users;
            }
            throw new Exception("АШИПКА");
        }

        public async Task<bool> GetChatWithUser(int SenderId, int ReceiverId)
        {
            var response = await _http.GetAsync($"api/movie/GetChatWithUser/{SenderId}/{ReceiverId}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<GetChatResponse>();
                return result.result;
            }
            throw new Exception("АШИПКА");
        }

        public class MovieApiResponse
        {
            public MovieApiData Data { get; set; }
            public bool Status { get; set; }
        }

        public class MovieApiData
        {
            public List<MovieDto> movies { get; set; } = new();
        }

        public class UserApiResponse
        { 
            public List<UserContext> Users { get; set; }
            public bool Status { get; set; }
        }
        public class GetChatResponse
        { 
            public bool result { get; set; }
            public bool Status { get; set; }
        }
    }
}
