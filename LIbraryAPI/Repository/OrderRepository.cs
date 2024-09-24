using AutoMapper;
using LIbraryAPI.DataContext;
using LIbraryAPI.DTOs.Order;
using LIbraryAPI.Entity;
using LIbraryAPI.Validator;

namespace LIbraryAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ProjectDbContext dbContext;

        private readonly IMapper _mapper;

        public OrderRepository(ProjectDbContext _dbContext, IMapper mapper)
        {
            dbContext = _dbContext;
            _mapper = mapper;
        }
        public async Task<OrderDto> CreateOrder(OrderDto createOrder)
        {
            try
            {
                var validator = new OrderValidatorDto();
                var valid = await validator.ValidateAsync(createOrder);

                if (valid.IsValid == false)
                {
                    throw new Exception("Failed to create Order. Validation Failed");
                }
                else
                {
                    var orderRequest = _mapper.Map<Order>(createOrder);
                    dbContext.Order.Add(orderRequest);
                    dbContext.SaveChanges();

                    OrderDto res = _mapper.Map<OrderDto>(orderRequest);
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<OrderDto>> GetAllOrders()
        {
            try
            {
                var orders = dbContext.Order.ToList();
                List<OrderDto> result = _mapper.Map<List<OrderDto>>(orders);
                return result;
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
