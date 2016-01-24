using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCMusicStore.Models
{
    public class MaxWordsAttribute: ValidationAttribute,IClientValidatable
    {
        private readonly int _maxWords;
        public MaxWordsAttribute(int maxWords):base("Too many words for {0}") {//This constructor initiate max words permitted and default error
            _maxWords = maxWords;
        }

        //implement the method of IClientValidatable interface to make the attribute client validatable
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.DisplayName);
            rule.ValidationParameters.Add("wordcount",_maxWords);
            rule.ValidationType = "maxwords";
            yield return rule;
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