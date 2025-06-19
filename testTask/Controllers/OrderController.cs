using Mapster;
using Microsoft.AspNetCore.Mvc;
using testTask.Contracts;
using testTask.Models;
using testTask.Repositories;

namespace testTask.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await _orderRepository.GetAllOrders();
            return View(orders);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateOrderRequest());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateOrderRequest orderRequest)
        {
            if (!ModelState.IsValid)
            {             
                return View(orderRequest);
            }

            var order = orderRequest.Adapt<Order>();

            await _orderRepository.AddOrder(order);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var order = await _orderRepository.GetOrderById(id); 
            if (order is null)
                return NotFound();

            return View(order);
        }
    }
}
