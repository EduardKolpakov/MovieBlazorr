namespace MovieBlazor.Components.Interfaces
{
    public interface ISelector<out T>
    {
        T Value { get; }
    }
}
