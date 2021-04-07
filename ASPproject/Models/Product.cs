using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ASPproject.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage ="Enter product name")]
        [Display(Name="Name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Enter product description")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Range(0.01,double.MaxValue,ErrorMessage ="Enter product price")]
        [Display(Name="Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage ="Enter product category")]
        [Display(Name="Category")]
        public string Category { get; set; }


    }
}
