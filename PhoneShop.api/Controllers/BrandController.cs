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
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly ICaching _caching;

        public BrandController(IBrandService brandService, ICaching caching)
        {
            _brandService = brandService;
            _caching = caching;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("getall")]
        public ActionResult<Brand> GetAll()
        {
            var brands = _caching.GetOrCreate("Brands", () => _brandService.Get().ToList()).Result;
            if (!brands.Any())
            {
                return NotFound($"No brands found");
            }
            return Ok(brands);
        }

        [HttpGet]
        [Route("getall/{query}")]
        public ActionResult<Brand> GetAll(string query)
        {
            var brand = _brandService.GetByName(query);
            if (brand == null)
            {
                return NotFound($"No brand found");
            }
            return Ok(brand);
        }

        [HttpGet]
        [Route("{id:int}")]

        public ActionResult<Brand> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"{id} has to be > 0");
            }
            var brand = _brandService.Get(id);
            if (brand == null)
            {
                return NotFound($"A brand with id: {id} does not exist");
            }
            return Ok(brand);
        }

        [HttpPost]
        public ActionResult Create(Brand brand)
        {
            try
            {
                _brandService.Create(brand);
                return Created(HttpStatusCode.Created.ToString(), brand);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("Delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                _brandService.Delete(id);
                return Ok($"Brand with {id} removed");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
