﻿using HardCodeData.Models;
using System.ComponentModel.DataAnnotations;

namespace HardCodeTest.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public IFormFile? Image { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        /// <summary>
        /// MiscFieldId,MiscFildValue
        /// </summary>
        public IDictionary<int,string>? AdditionalFields { get; set; }
    }
}
