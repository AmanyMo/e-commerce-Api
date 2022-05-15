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
        public async Task<OrderDetails> Update(int orderId, OrderDetails orderDetail)
        {
            OrderDetails order = await _context.OrderDetails.FindAsync(orderId);
 
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
                .FirstOrDefaultAsync(o=>o.OrderID== order_Id&&o.ProductID==product_Id).Result;
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

       

        public Task<IEnumerable<IOrderDetails>> GetAllOrdersOfaProduct(int productId)
        {
            
        }

        public Task<IEnumerable<IOrderDetails>> GetAllProductsForaUser(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetails> GetuserOfaProduct(int orderId, int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDetails>> GetuserOrder(int orderId, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDetails>> GetUsersOfaProduct(int productId)
        {
            throw new NotImplementedException();
        }

     
    }
}
