using Fluxor;

namespace MovieBlazor.Store.Auth;

[FeatureState]
public class AuthState
{
    public bool IsAuthenticated { get; }
    public string Jwt { get; init; }

    public AuthState(bool isAuthenticated, string jwt)
    {
        IsAuthenticated = isAuthenticated;
        Jwt = jwt;
    }
    public AuthState()
    {
        IsAuthenticated = false;
        Jwt = null;
    }
}