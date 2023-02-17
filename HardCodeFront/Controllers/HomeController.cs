using HardCodeFront.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http;

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