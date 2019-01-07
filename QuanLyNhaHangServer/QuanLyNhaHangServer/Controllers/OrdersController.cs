﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyNhaHangServer;
using QuanLyNhaHangServer.Helpers;
using QuanLyNhaHangServer.Models;

namespace QuanLyNhaHangServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppContext _context;

        public OrdersController(AppContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public IActionResult GetOrders()
        {
            var jObject = Utils.getJObjectResponseFromArray(true, _context.Orders.ToList());
            return Ok(jObject);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }
            var jObject = Utils.getJObjectResponseFromObject(true, order);
            return Ok(jObject);
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder([FromRoute] long id, [FromForm] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.Id)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<IActionResult> PostOrder([FromForm] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            var jObject = Utils.getJObjectResponseFromObject(true, order);
            return CreatedAtAction("GetOrder", new { id = order.Id }, jObject);
        }

        // POST: api/Orders
        [HttpPost("new")]
        public async Task<IActionResult> AddOrder([FromForm] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return Ok(Utils.getJObjectResponseFromObject(true, order));
        }

        private bool OrderExists(long id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}