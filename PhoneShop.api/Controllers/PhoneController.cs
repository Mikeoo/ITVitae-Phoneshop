using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Phoneshop.Domain.Entities;
using Phoneshop.Domain.Interfaces;
using System;
using System.Linq;
using System.Net;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace PhoneShop.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneService _phoneService;

        public PhoneController(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        [HttpGet]
        [Route("getall")]
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        [ProducesResponseType(Status401Unauthorized)]
        public ActionResult<Phone> GetAll()
        {
            var phones = _phoneService.GetAll();
            if (!phones.Any())
            {
                return NotFound($"No phones found");
            }
            return Ok(phones);
        }

        [HttpGet]
        [Route("getall/{query}")]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        public ActionResult<Phone> GetAll(string query)
        {
            if (string.IsNullOrEmpty(query))
                return BadRequest($"query cannot be null or empty");

            var phones = _phoneService.Search(query);

            if (!phones.Any())
            {
                return NotFound($"No phones found");
            }
            return Ok(phones);
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        [ProducesResponseType(Status400BadRequest)]
        [Route("{id:int}")]
        public ActionResult<Phone> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"{id} has to be > 0");
            }
            var phone = _phoneService.Get(id);
            if (phone == null)
            {
                return NotFound($"A phone with id: {id} does not exist");
            }

            return Ok(phone);
        }

        [HttpPost]
        [ProducesResponseType(Status201Created)]
        [ProducesResponseType(Status400BadRequest)]
        public ActionResult Create(Phone phone)
        {
            try
            {
                _phoneService.Create(phone);
                return Created(HttpStatusCode.Created.ToString(), phone);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        [HttpPost]
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status400BadRequest)]
        [Route("Delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                _phoneService.Delete(id);
                return Ok($"Phone with {id} removed");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
