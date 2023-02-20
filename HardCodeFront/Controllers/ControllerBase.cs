using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace HardCodeFront.Controllers
{
    public class ControllerBase : Controller
    {
        protected readonly ILogger<HomeController> _logger;
        protected readonly HttpClient _httpClient;
        public ControllerBase(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient("HardCodeTestAPI");
        }
    }
}