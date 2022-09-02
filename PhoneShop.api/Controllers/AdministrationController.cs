using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Phoneshop.Domain.Entities;
using Phoneshop.Domain.Interfaces;
using static Microsoft.AspNetCore.Http.StatusCodes;


namespace PhoneShop.api.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly IAdministrationService _administrationService;

        public AdministrationController(IAdministrationService administrationService)
        {
            _administrationService = administrationService;
        }
        
        [HttpPost]
        [Route("CreateRole")]
        public async Task<ActionResult> CreateRole(string roleName)
        {
            await _administrationService.CreateRole(roleName);
            return Ok(roleName);
        }

        [HttpPost]
        [Route("DeleteRole")]
        public async Task<ActionResult> DeleteRole(string roleName)
        {
            await _administrationService.DeleteRole(roleName);
            return Ok(roleName);
        }
    }
}