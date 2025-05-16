using Fluxor;

namespace MovieBlazor.Store.Auth;

public static class AuthReducers
{
    [ReducerMethod]
    public static AuthState ReduceLoginAction(AuthState state, LoginAction action)
    {
        return new AuthState
        {
            IsAuthenticated = true,
            Jwt = action.Jwt
        };
    }

    [ReducerMethod]
    public static AuthState ReduceLogoutAction(AuthState state, LogoutAction action)
        => new AuthState(isAuthenticated: false, "");
}