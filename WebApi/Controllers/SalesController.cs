using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        readonly private IBLRepo _bl;

        public SalesController(IBLRepo bl)
        {
            _bl = bl;
        }

        // GET api/<SalesController>/getpurchases/peter/7811112222
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Sale> allSales = await _bl.GetSalesAsync();
            if (allSales.Count != 0)
            {
                return Ok(allSales);
            }
            else
            {
                return NoContent();
            }
        }

        // GET: api/<SalesController>/getsales/peter/7811112222
        [HttpGet("getsales/{sellerName}/{phoneNumber}")]
        public async Task<IActionResult> GetSales(string sellerName, long phoneNumber)
        {
            List<Sale> sales = await _bl.GetUserSalesAsync(sellerName, phoneNumber);
            if(sales.Count != 0)
            {
                return Ok(sales);
            }
            else
            {
                return NoContent();
            }
        }

        // GET api/<SalesController>/getpurchases/peter/7811112222
        [HttpGet("getpurchases/{buyerName}/{phoneNumber}")]
        public async Task<IActionResult> GetPurchases(string buyerName, long phoneNumber)
        {
            List<Sale> purchases = await _bl.GetUserPurchasesAsync(buyerName, phoneNumber);
            if (purchases.Count != 0)
            {
                return Ok(purchases);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<SalesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Sale newSale)
        {
            Sale sale = await _bl.AddSaleAsync(newSale);
            return Created("api/[controller]", sale);
        }
    }
}
