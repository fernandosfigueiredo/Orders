﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OrderApp.API.Filters;
using OrderApp.API.Mappers;
using OrderApp.API.Models;
using OrderApp.Application.Services.Abstractions;

namespace OrderApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public IOrderService OrderService { get; set; }

        public OrderController(IOrderService orderService)
        {
            OrderService = orderService;
        }

        [HttpPost]
        [ValidateModelStateFilter]
        public IActionResult Post([FromBody] OrderModel order)
        {
            var accountNumber = GetAccountNumberFromHeader();
            var orderDto = order.Map(accountNumber);
            var success = OrderService.PlaceOrder(orderDto);

            if (!success)
                return BadRequest();

            return Ok();
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: Order/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private string GetAccountNumberFromHeader()
        {
            return "550556";
        }
    }
}
