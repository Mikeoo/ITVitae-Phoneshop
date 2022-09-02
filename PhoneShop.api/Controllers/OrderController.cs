using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Phoneshop.Business.Builders;
using Phoneshop.Business.Extensions;
using Phoneshop.Domain.Entities;
using Phoneshop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace PhoneShop.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IRepository<Phone> _repository;
        private readonly UserManager<IdentityUser> _userManager;

        public OrderController(IOrderService orderService, IRepository<Phone> repository, UserManager<IdentityUser> userManager)
        {
            _orderService = orderService;
            _repository = repository;
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet("GetAllOrdersFor/{userId}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders(string userId)
        {
            var orders =  _orderService.GetAllLoggedInUser(userId);
            if (!orders.Any())
            {
                return NotFound($"No orders found");
            }
            return Ok(orders);
        }

        [Authorize]
        [HttpGet("GetOrder/{id}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var requestedOrder = _orderService.Get(id, userId);

            return Ok(requestedOrder);
        }

        [Authorize]
        [HttpPost("Create/{orderId}")]
        public async Task<IActionResult> Create(List<int> phoneIds)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            var products = phoneIds.SelectMany(x => _repository.GetAll().Where(y => y.Id == x));

            var builder = new OrderBuilder();
            builder.SetCustomerId(userId)
                .SetTotalPrice(products.Sum(x => x.Price))
                .SetVatPercentage(products.Sum(x => x.PriceWithoutVat()))
                .AddPhones(products);

            var order = builder.Build();
            _orderService.Create(order);
            //return Accepted(order);
            return Ok(order);
        }
    }
}
