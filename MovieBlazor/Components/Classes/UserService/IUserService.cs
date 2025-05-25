namespace MovieBlazor.Components.Classes
{
    public interface IUserService
    {
        UserContext CurrentUser { get; }

        void UpdateFromJwt(string jwt);
    }
}
