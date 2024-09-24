using LIbraryAPI.DTOs.Order;

namespace LIbraryAPI.Repository
{
    public interface IOrderRepository
    {
        public Task<List<OrderDto>> GetAllOrders();
        public Task<OrderDto> CreateOrder(OrderDto createOrder);
    }
}
