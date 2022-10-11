using System;

namespace Code.Factory
{
    public interface IFactory<T> : IDisposable
        where T : class
    {
        T Prototype { get; }
        T Create();
    }
}
