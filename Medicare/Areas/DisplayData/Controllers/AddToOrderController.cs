using Medicare.Data;
using Medicare.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Medicare.Areas.DisplayData
{
        [Route("api/[controller]")]
        [ApiController]
        public class AddToOrderController : ControllerBase
        {

            private readonly ApplicationDbContext _context;
            private readonly ILogger<AddToOrderController> _logger;

            public AddToOrderController(
                ApplicationDbContext context,
                ILogger<AddToOrderController> logger)
            {
                _context = context;
                _logger = logger;
            }

            public class InputDataModel
            {

                public int ProductId { get; set; }

                public int OrderQuantity { get; set; }

            }


            [HttpPost]
            public IActionResult AddToOrder(InputDataModel inputData)
            {
                if (inputData == null)
                {
                    ModelState.AddModelError("AddToOrder", "Invalid Input Data");
                    return new BadRequestObjectResult(ModelState);
                }

                // Create a NEW ORDER row
                Order newOrder
                    = new Order
                    {
                        OrderDateTime = System.DateTime.Now
                    };
                _context.Order.Add(newOrder);
                _context.SaveChanges();      // COMMIT so that we can retrieve the SCOPE_IDENTITY() for OrderNumber.

                // Create a NEW ORDER DETAIL row
                OrderDetail newOrderDetail
                    = new OrderDetail
                    {
                        OrderNumber = newOrder.OrderNumber,
                        ProductId = inputData.ProductId,
                        Quantity = inputData.OrderQuantity
                    };
                _context.OrderDetails.Add(newOrderDetail);
                _context.SaveChanges();         // COMMIT so the details of the newly inserted row are refreshed.


                // Extract the name of the menu item so that a suitable response can be sent.
                var products = _context.Products
                                    .SingleOrDefault(m => m.ProductId == newOrderDetail.ProductId)
                                    .ProductName;

                var responseObj = new { Status = $"Added {newOrderDetail.Quantity} units of {products}!" };
                return Ok(responseObj);
            }
        }
 }