using Fluxor;

namespace MovieBlazor.Store.Auth;

public class AuthFeature : Feature<AuthState>
{
    public override string GetName() => "Auth";

    protected override AuthState GetInitialState()
        => new AuthState();

    [ReducerMethod]
    public static AuthState ReduceLoginAction(AuthState state, LoginAction action)
        => new AuthState
        {
            IsAuthenticated = true,
            Jwt = action.Jwt
        };
}