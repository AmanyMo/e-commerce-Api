namespace e_commerce_Api.Interfaces
{
    public interface IOrderDetails
    {
        Task<IEnumerable<OrderDetails>> GetAll();
        Task<IEnumerable<OrderDetails>> GetAllOrdersDetailsOfaProduct(int productId);
        Task<IEnumerable<OrderDetails>> GetAllOrdersForaUser(int userId);
        Task<OrderDetails> GetuserOfaProductandOrder(int orderId, int productId);
        Task<IEnumerable<OrderDetails>> GetuserOrderDetails(int orderId, int userId);
        Task<OrderDetails> Add(OrderDetails orderDetail);
        Task<OrderDetails> Update(int orderId,int produstId,int userId, OrderDetails orderDetail);
        bool DeleteAProductFromOrder(int order_Id, int product_Id);
        bool DeleteSpecifcOrder(int order_Id);
      


        
   



    }
}
