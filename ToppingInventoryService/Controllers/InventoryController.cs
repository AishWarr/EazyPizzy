using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryService.Models;

namespace ToppingInventoryService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly EasyPizzyDB_Context dB_Context; 
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<InventoryController> _logger;

        public InventoryController(ILogger<InventoryController> logger, EasyPizzyDB_Context pizzyDB_Context)
        {
            _logger = logger;
            dB_Context = pizzyDB_Context;
        }

        [HttpGet]
        public IEnumerable<ToppingsInvetoryList> Get()
        {
            try
            {
                var a = dB_Context.ToppingsInvetoryLists.Where(x => x.IsAvailable == true);
                return a;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
