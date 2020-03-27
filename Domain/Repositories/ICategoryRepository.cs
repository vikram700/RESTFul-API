using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services.Communication;

namespace Supermarket.API.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category > > ListAsync();
        Task PostAsync(Category category);
        Task<Category > FindById(int id);
        void Update(Category category);
        void Delete(Category category);
    }
}