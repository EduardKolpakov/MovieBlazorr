namespace MovieBlazor.Store.Auth;

public class AuthState
{
    public bool IsAuthenticated { get; }
    public string Jwt { get; }

    public AuthState(bool isAuthenticated, string jwt)
    {
        IsAuthenticated = isAuthenticated;
        Jwt = jwt;
    }
}