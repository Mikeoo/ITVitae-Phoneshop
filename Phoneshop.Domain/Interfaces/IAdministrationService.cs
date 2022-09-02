using System.Threading.Tasks;

namespace Phoneshop.Domain.Interfaces
{
    public interface IAdministrationService
    {
        Task CreateRole(string roleName);
        Task DeleteRole(string roleName);
    }
}