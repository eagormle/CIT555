using PackAPI.Models;
using PackAPIAPI.Models;
using System.Net;

public interface IOrderRepository : IGenericRepository<Order>
{
    HttpStatusCode CreateOrder(CreateOrder createOrder);

    List<GetOrder> GetOrder(OrderFilter getOrder);

    void DeleteOrder(int Id);

    GetOrder UpdateOrder(int Id, UpdateOrder updateOrder);
}