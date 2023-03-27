using PackAPIAPI.Models;

namespace PackAPI.Models
{
    public class CreateOrder
    {
        public OrderType OrderType { get; set; }
        public string CustomerName { get; set; }
        public string CreatedByUserName { get; set; }
    }
}
