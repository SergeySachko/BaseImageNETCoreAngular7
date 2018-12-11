using Application.DAL;
using System;

namespace Application.BLLInterfaces
{
    public interface IDbContextFactory
    {
         IApplicationDbContext Create();
    } 
}
