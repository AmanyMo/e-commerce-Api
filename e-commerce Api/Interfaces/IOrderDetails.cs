namespace e_commerce_Api.Interfaces
{
    public interface IOrderDetails
    {
        Task<IEnumerable<OrderDetails>> GetAll();
        //Task<OrderDetails> GetuserOfOrder(int productId);
        Task<OrderDetails> GetuserOfaProduct(int orderId, int productId);
        Task<IEnumerable<OrderDetails>> GetUsersOfaProduct(int productId);
        Task<IEnumerable<OrderDetails>> GetAllOrdersForaUser(int userId);
        Task<IEnumerable<OrderDetails>> GetAllOrdersOfaProduct(int productId);

        Task<OrderDetails> Add(OrderDetails orderDetail);
        Task<OrderDetails> Update(int orderId, OrderDetails orderDetail);
        bool DeleteAProductFromOrder(int order_Id, int product_Id);
        bool DeleteSpecifcOrder(int order_Id);
        Task<IEnumerable<OrderDetails>> GetuserOrder(int orderId, int userId);



    }
}
