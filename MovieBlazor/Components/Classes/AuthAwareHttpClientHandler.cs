using Fluxor;
using Microsoft.Extensions.Logging;
using MovieBlazor.Store.Auth;
using System.Net.Http.Headers;

namespace MovieBlazor.Components.Classes
{
    public class AuthAwareHttpClientHandler : DelegatingHandler
    {
        private readonly IState<AuthState> _authState;
        private readonly ILogger<AuthAwareHttpClientHandler> _logger;

        public AuthAwareHttpClientHandler(
            IState<AuthState> authState,
            ILogger<AuthAwareHttpClientHandler> logger)
        {
            _authState = authState;
            _logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken ct)
        {
            // Получаем текущее значение из состояния
            var token = _authState.Value?.Jwt;

            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                _logger.LogInformation("Токен добавлен в заголовок");
            }
            else
            {
                _logger.LogWarning("Токен отсутствует");
            }

            return await base.SendAsync(request, ct);
        }
    }
}