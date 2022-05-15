using System.Linq;

namespace e_commerce_Api.Repositories
{
    public class OrderListRepository : IOrderList
    {
        private readonly ModelContext _context;
        public OrderListRepository(ModelContext context)
        {
            _context=context;
        }
        public async Task<IEnumerable<OrderList>> GetAll()
        {
            return await _context.OrderList.ToListAsync();
        }
        public async Task<OrderList> GetById(int id)
        {
            var order = await _context.OrderList.FindAsync(id);
            return order;
        }
        public async Task<OrderList> Add(OrderList order)
        {
            var result = _context.OrderList.AddAsync(order).Result;
            try
            {
                var num = await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (DbUpdateConcurrencyException db)
            {

                throw db;
            }
           
        }
        public async Task<OrderList> Update(int OrderId, OrderList _order)
        {
            OrderList order = await _context.OrderList.AsNoTracking().SingleOrDefaultAsync(p => p.OrderID == _order.OrderID);
            if (order != null)
            {
                _context.Entry(_order).State = EntityState.Modified;
                try
                {
                    int successRet = _context.SaveChangesAsync().Result;
                    if (successRet == 1)
                    {
                        return _order;
                    }
                }
                catch (Exception e)
                {
                    throw e.InnerException;
                }
            }
             return order;
        }

        public bool Delete(int order_Id)
        {
            var order = _context.OrderList.FindAsync(order_Id).Result;
            if (order != null)
            {
                _context.OrderList.Remove(order);
                var ret = _context.SaveChangesAsync().Result;
                if (Convert.ToBoolean(ret))
                    return true;
            }
            return false;
        }

        public bool DeleteAllOrdersForAUser(int user_Id)
        {
            var order = _context.OrderList.Where(o=>o.User_Id==user_Id);
            if (order.Count() > 0)
            {
                foreach (var item in order)
                {
                    _context.OrderList.Remove(item);
                    try
                    {
                        var ret = _context.SaveChangesAsync().Result;
                        if (Convert.ToBoolean(ret))
                            return true;
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        throw;
                    }
                }
            }
            return false;
        }
    }
}
