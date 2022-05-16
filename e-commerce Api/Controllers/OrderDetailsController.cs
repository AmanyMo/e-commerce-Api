using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetails _orderDetailsContext;
        public OrderDetailsController(IOrderDetails orderDetailsContext)
        {
            _orderDetailsContext = orderDetailsContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<OrderDetails>> GetAll()
        {
            IEnumerable<OrderDetails> orderDetails = _orderDetailsContext.GetAll().Result;
            if (orderDetails.Any())
            {
                return Ok(orderDetails);
            }
            else
            {
                return NotFound("no element exists");
            }
        }

        //to get list of order that contains a specific product
        [HttpGet("prodid")]
        //[Route("product/{id)")]
        public ActionResult<IEnumerable<OrderDetails>> GetOrdersOfProduct(int prod_Id)
        {
            IEnumerable<OrderDetails> ordersDetails = _orderDetailsContext.GetAllOrdersDetailsOfaProduct(prod_Id).Result;
            if (ordersDetails.Any())
            {
                return Ok(ordersDetails);

            }
            return NotFound("no orders for this prod");
        }

        //to get list of order that belongs to a specific product
        [HttpGet("userid/{id}")]
        //[Route("user/{id}")]
        public ActionResult<IEnumerable<OrderDetails>> GetOrdersOfUser(int user_Id)
        {
            IEnumerable<OrderDetails> ordersDetails = _orderDetailsContext.GetAllOrdersForaUser(user_Id).Result;
            if (ordersDetails.Any())
            {
                return Ok(ordersDetails);
            }
            return NotFound("no orders for this prod");
        }

        [HttpGet("orderid-prodid")]
        //[Route("orderprod")]
        public ActionResult<IEnumerable<OrderDetails>> GetuserOfaProductandOrder(int order_Id, int prod_Id)
        {
            OrderDetails orderDetails = _orderDetailsContext.GetuserOfaProductandOrder(order_Id, prod_Id).Result;
            if (orderDetails != null)
            {
                return Ok(orderDetails);
            }
            return NotFound("no orders for this prod");
        }


        //it returns the order details of a certain order to a specific user --invoice fatora-
        [HttpGet("orderuser")]
        //[Route("")]
        public ActionResult<IEnumerable<OrderDetails>> GetUserOrderInvoice(int order_Id, int user_Id)
        {
            IEnumerable<OrderDetails> invoice = _orderDetailsContext.GetuserOrderDetails(order_Id, user_Id).Result;
            if (invoice.Any())
            {
                return Ok(invoice);
            }
            return NotFound("no invoice details for this order_id and user_id");

        }
        [HttpPost]
        public ActionResult PostOrderDetails(OrderDetails _orderDetails)
        {
            OrderDetails order = _orderDetailsContext.Add(_orderDetails).Result;
            if (order != null)
            {
                return CreatedAtAction(nameof(GetAll), order);
            }
            else
            {
                return NotFound("can't added");
            }
        }
        [HttpPut]
        public ActionResult PutOrderDetails(int order_id, int product_id, int user_id, OrderDetails order)
        {
            if (order_id != order.OrderID || product_id != order.ProductID || user_id != order.UserID)
            {
                return BadRequest();
            }
            else
            {
                OrderDetails returnorder = _orderDetailsContext.Update(order_id, product_id, user_id, order).Result;
                if (returnorder != null)
                {
                    return Ok("Updated");
                }
                return NotFound("not updated");
            }
        }
        [HttpDelete]
        public ActionResult DeleteAnOrderDetails(int order_id)
        {
            if (order_id <= 0)
            {
                return BadRequest();
            }
            else
            {
                bool retval = _orderDetailsContext.DeleteSpecifcOrder(order_id);
                if (retval)
                {
                    return Ok("deleted Successfullty");
                }
                return NotFound("Can't delete");
            }
        }

        //delete a product from order details --invoice---
        [HttpDelete("product")]    
        public ActionResult DeleteProductFromOrder([FromQuery]int order_id,[FromQuery]int product_id)
        {
            if (order_id<=0||product_id<=0)
            {
                return BadRequest();
            }
            bool retval=_orderDetailsContext.DeleteAProductFromOrder(order_id, product_id);
            if (retval)
                return Ok("Delete product from invoice");
            else
                return NotFound("can't delete this prod from invoice");
        }
    }
}
