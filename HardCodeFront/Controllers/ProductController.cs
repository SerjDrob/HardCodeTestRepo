using HardCodeFront.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;

namespace HardCodeFront.Controllers
{
    public class ProductController : ControllerBase
    {
        public ProductController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory) : base(logger, httpClientFactory)
        {
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var catResponse = await _httpClient.GetAsync("category");
            var categoryDTOs = await catResponse.Content.ReadFromJsonAsync<IEnumerable<CategoryDTO>>();

            var model = new ProductCrEditVM
            {
                ProductDTO = new ProductDTO(),
                Categories = categoryDTOs
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(ProductCrEditVM productCrEdit) 
        {
            var prodDto = productCrEdit.ProductDTO;

            var catResponse = await _httpClient.GetAsync("category");
            var categoryDTOs = await catResponse.Content
                .ReadFromJsonAsync<IEnumerable<CategoryDTO>>();

            //var categoryDTO = categoryDTOs.Where(c=>c.)

            //prodDto.AdditionalFields=productCrEdit.AdFields
            //    .Select(f=>new PropertyField
            //    {
            //        Value = f,
            //        Name = 
            //    })
            return View();
        }
    }
}
