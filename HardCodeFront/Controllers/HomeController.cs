using HardCodeFront.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HardCodeFront.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory, IWebHostEnvironment webHostEnvironment) : base(logger, httpClientFactory)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var prodResponse = await _httpClient.GetAsync("product");
            var productDTOs = await prodResponse.Content.ReadFromJsonAsync<IEnumerable<ProductDTO>>();
            foreach (var product in productDTOs)
            {
                await SaveImgFile(product.ImageBytes, product.ImageName);
            }

            var homeVM = new HomeVM
            {
                CategorieNames = productDTOs.Select(c => c.CategoryName).Distinct(),
                Products = productDTOs
            };
            return View(homeVM);
        }

        private async Task SaveImgFile(string file, string fileName)
        {
            var path = Path.Combine(_webHostEnvironment.WebRootPath + WC.ImagesPath, fileName);
            if (!Path.Exists(path))
            {
                var bytes = Convert.FromBase64String(file);
                await System.IO.File.WriteAllBytesAsync(path, bytes);
            }
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