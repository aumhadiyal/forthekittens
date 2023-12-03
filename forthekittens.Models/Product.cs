using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forthekittens.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Product_name{ get; set; }
        [Required]
        public string Product_description { get; set; }
        [Required]
        public string Upc {  get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        [Display(Name ="List Price ")]
        [Range(100,8000)]
        public int ListPrice { get; set; }

        [Required]
        [Display(Name = "Price 1-5 ")]
        [Range(100, 8000)]
        public int Price { get; set; }


        [Required]
        [Display(Name = "Price for 5+ ")]
        [Range(100, 8000)]
        public int Price5 { get; set; }



        [Required]
        [Display(Name = "Price for 10+")]
        [Range(500, 8000)]
        public int Price10 { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category{ get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
