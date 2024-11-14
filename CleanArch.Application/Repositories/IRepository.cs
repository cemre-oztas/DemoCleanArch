using CleanArch.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;


namespace CleanArch.Application.Repositories;
public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
}