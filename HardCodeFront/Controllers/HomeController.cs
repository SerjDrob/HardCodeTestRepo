using HardCodeFront.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;

namespace HardCodeFront.Controllers
{
    public class HomeController : ControllerBase
    {
        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory) : base(logger, httpClientFactory)
        {
        }

        public IActionResult Index()
        {
            var prodResponse = _httpClient.GetAsync("product").Result;
            var productDTOs = prodResponse.Content.ReadFromJsonAsync<IEnumerable<ProductDTO>>().Result;
            
            var homeVM = new HomeVM 
            {
                CategorieNames = productDTOs.Select(c=>c.CategoryName).Distinct(), 
                Products = productDTOs
            };
            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}