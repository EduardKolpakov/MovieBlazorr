namespace MovieBlazor.Store.Auth;

public class AuthState
{
    public bool IsAuthenticated { get; set; }
    public string Jwt { get; set; } = "";

    public AuthState()
    {
    }

    public AuthState(bool isAuthenticated, string jwt)
    {
        IsAuthenticated = isAuthenticated;
        Jwt = jwt;
    }
}