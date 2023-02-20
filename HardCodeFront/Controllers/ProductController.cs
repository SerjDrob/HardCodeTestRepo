using HardCodeFront.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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

            var fields = categoryDTOs.Where(c => c.Id == prodDto.CategoryId)
                .SelectMany(c => c.MiscFields)
                .Select(m => m.Id)
                .Zip(productCrEdit.AdFields)
                .Select(r => new PropertyField(r.First,null, r.Second))
                .ToList();

            prodDto.AdditionalFields = fields;

            using var stream = new MemoryStream();
            prodDto.Image.CopyTo(stream);
            var bytes = stream.ToArray();
            var fileString = Convert.ToBase64String(bytes);

            prodDto.ImageName = prodDto.Image.FileName;
            prodDto.ImageBytes = fileString;

            var response = await _httpClient.PostAsJsonAsync("product", prodDto);
            if (!response.IsSuccessStatusCode) return BadRequest(response);
            return RedirectToAction("index","home");
        }
        public class ProdTemp
        {
            public int Id { get; set; }
            //public IFormFile? Image { get; set; }
            public string Name { get; set; }
            public string? Description { get; set; }
            public decimal Price { get; set; }
            public int CategoryId { get; set; }
            public string? CategoryName { get; set; }
            /// <summary>
            /// MiscFieldId, MiscFieldName,MiscFildValue
            /// </summary>
            public IList<PropertyField>? AdditionalFields { get; set; }
        }
    }
}
