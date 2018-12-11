
using System;

namespace Application.DAL
{
    public interface IApplicationDbContext:  IDisposable
    {
        int SaveChanges();
    }
}