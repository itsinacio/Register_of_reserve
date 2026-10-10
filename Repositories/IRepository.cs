using TechNova.Api.Model.Base;

namespace TechNova.Api.Repositories;

public interface IRepository<T> where T : Entity
{
    T Create(T item);
    T FindById(long id);
    List<T> FindList(int pageNumber = 1);
    T Update(T item);
    void Delete(long id);
    bool Existis(long id);
}