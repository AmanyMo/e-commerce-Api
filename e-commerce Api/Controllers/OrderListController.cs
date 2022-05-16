using Microsoft.AspNetCore.Mvc;

namespace e_commerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderListController : ControllerBase
    {
        private readonly IOrderList _orderListContext;
        public OrderListController(IOrderList orderListContext)
        {
            _orderListContext= orderListContext;
        }
       
        [HttpGet]
        public ActionResult<IEnumerable<OrderList>> GetAllOrders()
        {
          IEnumerable<OrderList> orders= _orderListContext.GetAll().Result;
            if (orders.Any())
            {
                return Ok(orders);
            }
            return NotFound("their is no orders list here");
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<OrderList> GetById(int id)
        {
            OrderList order= _orderListContext.GetById(id).Result;
            if (order!=null)
            {
                return Ok(order);
            }
            return NotFound("Order does not exist");
        }
        [HttpPost]
        public ActionResult<OrderList> PostNewOrder(OrderList order)
        {
            OrderList orderlist = _orderListContext.Add(order).Result;
            if (orderlist == null)
            {
                return NotFound("no category added");
            }
            else
                return CreatedAtAction(nameof(GetAllOrders),orderlist );

        }

        [HttpPut]
        public ActionResult<OrderList> PutOrderList(int id,OrderList order)
        {
            if (id != order.OrderID)
            {
                return BadRequest();
            }
            else
            {
             OrderList orderList=  _orderListContext.Update(id,order).Result;
                if (orderList != null)
                    return Ok(orderList);       
            }
            return NotFound("can't update ");
        }
        [HttpDelete]
        public ActionResult DeleteOderList(int id)
        {
            if (id<=0)
            {
                return BadRequest("send a valid id");
            }
            else
            {
                OrderList order = _orderListContext.GetById(id).Result;
                if (order != null)
                {
                    bool retval = _orderListContext.Delete(id);
                    if (retval)
                        return Ok("Deleted Successfully");
                    else
                        return NotFound("error at delete operation");
                } 
                return NotFound("item does not exist");
            }
           

        } 
        [HttpDelete]
        [Route("{id}")]
        public  ActionResult DeleteAllOderListForUser(int userid)
        {  
            if (userid <= 0)
            {
                return BadRequest("send a valid id");
            }
            else
            {
               IEnumerable<OrderList> orderList =(IEnumerable<OrderList>) GetAllOrders().Result;
                if (orderList != null)
                {
                    foreach (var order in orderList)
                    {
                        _orderListContext.Delete(order.OrderID);
                    }
                    return Ok("Deleted successfullt");
                }
                return NotFound("item does not exist");
            }
        }



    }
}
