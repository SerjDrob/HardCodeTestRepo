using HardCodeFront.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace HardCodeFront.Controllers
{
    public class ProductController : ControllerBase
    {
        public ProductController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory) : base(logger, httpClientFactory)
        {
        }
        [HttpGet]
        public IActionResult Index()
        {
            var catResponse = _httpClient.GetAsync("category").Result;
            var categoryDTOs = catResponse.Content.ReadFromJsonAsync<IEnumerable<CategoryDTO>>().Result;

            var model = new ProductCrEditVM
            {
                ProductDTO = new ProductDTO(),
                Categories = categoryDTOs
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult Index(ProductCrEditVM productCrEdit) 
        {
            return View();
        }
    }
}
