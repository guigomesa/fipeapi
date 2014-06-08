using System;

namespace Fipe.Domain
{
    public interface IUnityOfWork : IDisposable
    {
        void Commit();
    }

    public interface IUnitOfWorkFactory
    {
        IUnityOfWork Build();
    }
}
