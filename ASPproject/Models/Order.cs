using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ASPproject.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }
        [BindNever]
        public ICollection<CartItem> Items { get; set; }
        [Required(ErrorMessage = "Enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter your adress")]
        public string AdressLine1 { get; set; }
        public string AdressLine2 { get; set; }
        public string AdressLine3 { get; set; }
        [Required(ErrorMessage ="Enter your city")]
        public string City { get; set; }
        [Required(ErrorMessage = "Enter your region")]
        public string State { get; set; }
        public string Zip { get; set; }
        [Required(ErrorMessage ="Enter your country")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
    }
}
