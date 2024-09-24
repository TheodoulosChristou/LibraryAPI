using LIbraryAPI.DTOs.Order;
using LIbraryAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LIbraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("CreateOrder")]
        public async Task<ActionResult<IQueryable<OrderDto>>> CreateOrder([FromBody]OrderDto createOrder)
        {
            var request = await _orderRepository.CreateOrder(createOrder);  
            return Ok(request);
        }

        [HttpPost("SearchOrders")]
        public async Task<ActionResult<IQueryable<SearchOrderResultDto>>> CreateOrder([FromBody] SearchOrderCriteriaDto searchCriteria)
        {
            var request = await _unitOfWork.SearchOrders(searchCriteria);
            return Ok(request);
        }

    }
}
