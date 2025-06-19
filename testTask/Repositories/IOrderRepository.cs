using testTask.Models;

namespace testTask.Repositories
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(Order order);
        Task<List<Order>> GetAllOrders();
        Task<Order?> GetOrderById(int id);
    }
}
