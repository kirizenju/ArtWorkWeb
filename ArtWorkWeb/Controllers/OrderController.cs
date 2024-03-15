﻿using DataTier.Models;
using Eatera.Helpers;
using Eatera.Models;
using Login_Signup.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Login_Signup.Controllers
{
    [ApiController]
    [Route("api/orders")]
    [DisableCors]
    public class OrderController : Controller
    {
        private MainDataContext _mainDataContext;

        public OrderController(MainDataContext dataContext)
        {
            _mainDataContext = dataContext;
        }

        // GET: api/orders
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var orders = await _mainDataContext.Orders.ToListAsync();
                return Ok(new { data = orders });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // POST: api/orders
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequestModel request)
        {
            try
            {
                List<Order> orderList = new List<Order>();

                foreach (var artId in request.ArtIDList)
                {
                    var order = new Order
                    {
                        IdArtwork = artId,
                        CustomerName = request.CustomerName,
                        CustomerNumber = request.CustomerNumber,
                        CustomerEmail = request.CustomerEmail,
                        CustomerAddress = request.CustomerAddress
                    };

                    _mainDataContext.Orders.Add(order);
                    await _mainDataContext.SaveChangesAsync();
                    orderList.Add(order);
                }

                return Ok(new { data = orderList });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // DELETE: api/orders
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder([FromQuery] int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("No id specified");
                }

                Console.WriteLine($"{DateTime.Now} DELETE /api/orders... id={id}");

                var order = await _mainDataContext.Orders.FirstOrDefaultAsync(o => o.IdArtwork == id);

                if (order == null)
                {
                    return NotFound("Order not found");
                }

                _mainDataContext.Orders.Remove(order);
                await _mainDataContext.SaveChangesAsync();

                return Ok(new { data = order });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // PUT: api/orders/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderUpdateModel updateModel)
        {
            try
            {
                var order = await _mainDataContext.Orders.FirstOrDefaultAsync(o => o.ArtworkId == id);

                if (order == null)
                {
                    return NotFound("Order not found");
                }

              
                order.CustomerName = updateModel.CustomerName;
                order.CustomerNumber = updateModel.CustomerNumber;
                order.CustomerEmail = updateModel.CustomerEmail;
                order.CustomerAddress = updateModel.CustomerAddress;

                _mainDataContext.Orders.Update(order);
                await _mainDataContext.SaveChangesAsync();

                return Ok(new { data = order });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
