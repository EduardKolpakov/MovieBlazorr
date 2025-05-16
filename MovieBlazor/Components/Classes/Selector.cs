using MovieBlazor.Components.Interfaces;

namespace MovieBlazor.Components.Classes
{
    using Fluxor;
    public class Selector<T> : ISelector<T>
    {
        private readonly Func<T> _getValue;

        public Selector(Func<T> getValue) => _getValue = getValue;

        public T Value => _getValue();
    }
}
