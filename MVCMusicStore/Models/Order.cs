using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMusicStore.Models
{
    public class Order : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            if (FirstName != null && FirstName.Split(' ').Length > 4) {
                yield return new ValidationResult("This field can't be more  than 4 words",new[] { FirstName });
            }
        }


        public int OrderId { get; set; }
        [Display(Name ="Orer Date",Order =5)]
        public DateTime OrderDate { get; set; }
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        [Required]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Minimum length for your first name is 3")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [MaxWords(3, ErrorMessage ="There are too many words in {0}")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",ErrorMessage ="Ho! It seems your email is invalid. Please check it")]
        public string Email { get; set; }
        [Range(0,10000)]
        public decimal Total { get; set; }
    }
}