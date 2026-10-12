using Microsoft.EntityFrameworkCore;
using TechNova.Api.Model.Base;
using TechNova.Api.Model.Context;

namespace TechNova.Api.Repositories.Impl;

public class GenericRepository<T> : IRepository<T> where T : Entity
{
    private SqlServerContext _context;
    private DbSet<T> _dataset;
    public GenericRepository(SqlServerContext context)
    {
        _context = context;
        _dataset = context.Set<T>();
    }
    public T Create(T item)
    {
        _dataset.Add(item);
        _context.SaveChanges();
        return item;
    }
    public T FindById(long id)
    {
        return _dataset.Find(id)!;
    }
    public List<T> FindList(int pageNumber = 1)
    {
        return _dataset
        .Skip((pageNumber - 1) * 15) 
        .Take(15)                    
        .ToList();
    }
    public T Update(T item)
    {
        _dataset.Update(item);
        _context.SaveChanges();
        return item;
    }
    public void Delete(long id)
    {
        _dataset.Where(x => x.Id == id).ExecuteDelete();
    }
    public bool Existis(long id)
    {
        return _dataset.Any(x => x.Id == id);
    }
}
