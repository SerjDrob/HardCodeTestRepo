using HardCodeFront.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json.Serialization;

namespace HardCodeFront.Controllers
{
    public class CategoryController : ControllerBase
    {
        public CategoryController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory) : base(logger, httpClientFactory)
        {
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categoryResponse = await _httpClient.GetAsync("category");
            var categoryDTOs = await categoryResponse.Content.ReadFromJsonAsync<IEnumerable<CategoryDTO>>();

            return View(categoryDTOs);
        }
        [HttpGet]
        public IActionResult Create([FromQuery] IEnumerable<string> existingFields)
        {
            var categoryDTO = new CategoryDTO
            {
                ExistingFields = existingFields,
                Name = string.Empty
            };
            return View(categoryDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDTO categoryDTO)
        {
            var fields = categoryDTO.ExistingFields.Where(f => f is not null)
                .Select(f => f.Trim())
                .Where(f => f != string.Empty)
                .Select(f => string.Concat(f[0].ToString().ToUpper(), f.AsSpan(1).ToString().ToLower()))
                .ToList();
            
            categoryDTO.MiscFields = fields.Select(f=>new PropertyField(0,f,null!));
            var response = await _httpClient.PostAsJsonAsync("category", categoryDTO);
            if (!response.IsSuccessStatusCode) return BadRequest(response);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id) 
        {
            var response = await _httpClient.DeleteAsync($"category?id={id}");
            if (!response.IsSuccessStatusCode) return BadRequest(response);
            return RedirectToAction(nameof(Index));
        }
    }
}
