using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCMusicStore.Models
{
    public class MaxWordsAttribute: ValidationAttribute
    {
        private readonly int _maxWords;
        public MaxWordsAttribute(int maxWords):base("Too many words for {0}") {//This constructor initiate max words permitted and default error
            _maxWords = maxWords;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null) {
                string Name = value.ToString();
                if (Name.Split(' ').Length > _maxWords) {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}