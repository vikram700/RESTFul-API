using System.Threading.Tasks;

namespace Supermarket.API.Persistence.Repositories
{
    public interface IUnitofWork
    {
        Task CompleteAsync();
    }
}