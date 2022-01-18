﻿using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models
{
    public class Product
    { 
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Range(1, 100000)]
        public double ListPrice { get; set; }
        [Required]
        [Range(1, 100000)]
        public double Price { get; set; }
        [Required]
        [Range(1, 100000)]
        public double Price50 { get; set; }
        [Required]
        [Range(1, 100000)]
        public double Price100 { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public int CoverTypeId { get; set; }
        public CoverType CoverType { get; set; }

    }
}
