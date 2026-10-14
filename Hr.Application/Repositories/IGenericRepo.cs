using Hr.Application.Interfaces;
using Hr.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Application.Repositories
{
    public interface IGenericRepo<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync();


        Task<T?> GetByIdAsync(object id);

        Task<T?> GetByIdWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetAllAsyncWithSpec(ISpecification<T> spec);
        Task<int> CountAsyncSpec(ISpecification<T> spec);

        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);


    }
}
