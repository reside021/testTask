using Microsoft.EntityFrameworkCore;
using testTask.DB;
using testTask.Models;

namespace testTask.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _dbContext;
        public OrderRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            return await _dbContext.SaveChangesAsync() > 0;
        }
        public async Task<List<Order>> GetAllOrders()
        {
            return await _dbContext.Orders.AsNoTracking().ToListAsync();
        }
        public async Task<Order?> GetOrderById(int id)
        {
            return await _dbContext.Orders
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
