using Fluxor;

namespace MovieBlazor.Store.Auth;

public static class AuthReducers
{
    [ReducerMethod]
    public static AuthState ReduceLoginAction(AuthState state, LoginAction action)
        => new AuthState(isAuthenticated: true, action.Jwt);

    [ReducerMethod]
    public static AuthState ReduceLogoutAction(AuthState state, LogoutAction action)
        => new AuthState(isAuthenticated: false);
}