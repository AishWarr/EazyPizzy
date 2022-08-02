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
    [Route("[InventoryController]")]
    public class InventoryController : ControllerBase
    {
        private static readonly EasyPizzyDB_Context dB_Context; 
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<InventoryController> _logger;

        public InventoryController(ILogger<InventoryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return dB_Context.ToppingsInvetoryLists.Where(x => x.IsAvailable == true);
        }
    }
}
