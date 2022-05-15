namespace e_commerce_Api.Interfaces
{
    public interface IOrderList
    {
        Task<IEnumerable<OrderList>> GetAll();
        Task<OrderList> GetById(int id);
        Task<OrderList> Add(OrderList order);
        Task<OrderList> Update(int OrderId,OrderList order);
        bool Delete(int order_Id);
        bool DeleteAllOrdersForAUser(int user_Id);
    }
}
