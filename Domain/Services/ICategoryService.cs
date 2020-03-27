using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services.Communication;

namespace Supermarket.API.Domain.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category > > ListAsync();
        Task<SaveCategoryResponse > PostAsync(Category category);
        Task<SaveCategoryResponse > PutAsync(int id, Category category); 
        Task<SaveCategoryResponse > DeleteAsync(int id);
    }
}