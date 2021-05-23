using FVI.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FVI.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggreateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
