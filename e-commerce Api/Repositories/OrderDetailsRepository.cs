using System.Linq;

namespace e_commerce_Api.Repositories
{
    public class OrderDetailsRepository : IOrderDetails
    {
        private readonly ModelContext _context;
        public OrderDetailsRepository(ModelContext context)
        {
            _context =context;
        } 
        public async Task<IEnumerable<OrderDetails>> GetAll()
        {
            return await _context.OrderDetails.ToListAsync();
        }

        public async Task<IEnumerable<OrderDetails>> GetAllOrdersDetailsOfaProduct(int productId)
        {
            return await _context.OrderDetails.Where(o => o.ProductID == productId).ToListAsync();

        }

        public async Task<IEnumerable<OrderDetails>> GetAllOrdersForaUser(int userId)
        {
            return await _context.OrderDetails.Where(o => o.UserID == userId).ToListAsync();
        }

        public async Task<OrderDetails> GetuserOfaProductandOrder(int orderId, int productId)
        {
            return await _context.OrderDetails
                .FirstOrDefaultAsync(o => o.OrderID == orderId && o.ProductID == productId);

        }

        //it returns the order details of a certain order to a specific user --fatora-
        public async Task<IEnumerable<OrderDetails>> GetuserOrderDetails(int orderId, int userId)
        {
            return await _context.OrderDetails.Where(o => o.OrderID == orderId && o.UserID == userId).ToListAsync();
        }


        public async Task<OrderDetails> Add(OrderDetails orderDetail)
        {
            var result = _context.OrderDetails.AddAsync(orderDetail).Result;
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
        public async Task<OrderDetails> Update(int orderId, int productId, int userId, OrderDetails orderDetail)
        {
            //OrderDetails order = await _context.OrderDetails.FindAsync(orderId);
            OrderDetails order = await _context.OrderDetails
                .SingleOrDefaultAsync(o=>o.OrderID==orderId&&o.UserID==userId &&o.ProductID==productId);

            if (order != null)
            {
                _context.Entry(orderDetail).State = EntityState.Modified;
                try
                {
                    int successRet = _context.SaveChangesAsync().Result;
                    if (successRet == 1)
                    {
                        return orderDetail;
                    }
                }
                catch (Exception e)
                {
                    throw e.InnerException;
                }
            }
            return order;
        }

        public bool DeleteAProductFromOrder(int order_Id, int product_Id)
        {
            OrderDetails order =  _context.OrderDetails
                .SingleOrDefaultAsync(o=>o.OrderID== order_Id&&o.ProductID==product_Id).Result;
            if (order!=null)
            {
                _context.OrderDetails.Remove(order);
                try
                {
                    int retval = _context.SaveChangesAsync().Result;
                    if (Convert.ToBoolean(retval))
                    {
                       return true;
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            return false;
        }

        public bool DeleteSpecifcOrder(int order_Id)
        {
            IEnumerable<OrderDetails> order =  _context.OrderDetails.Where(o => o.OrderID == order_Id).ToArray();

            if (order.Any())
            {
                _context.OrderDetails.RemoveRange(order);
                try
                {
                    int retval = _context.SaveChangesAsync().Result;
                    if (Convert.ToBoolean(retval))
                    {
                        return true;
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                } 
            }    
            return false;
        }

    }
}
