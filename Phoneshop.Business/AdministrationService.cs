using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Phoneshop.Domain.Interfaces;

namespace Phoneshop.Business
{
    public class AdministrationService : IAdministrationService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdministrationService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task CreateRole(string roleName)
        {
            IdentityRole identityRole = new IdentityRole()
            {
                Name = roleName,
            };
            
            await _roleManager.CreateAsync(identityRole);
        }

        public async Task DeleteRole(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            await _roleManager.DeleteAsync(role);
        }
    }
}