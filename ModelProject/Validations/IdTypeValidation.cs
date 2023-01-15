using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModelProject.Models;

namespace System.ComponentModel.DataAnnotations
{
    sealed public class IdTypeNotDefaultAttribute : ValidationAttribute
    {
        private Type _enumType;
        public int RejectedValue { get; set; }

        public IdTypeNotDefaultAttribute(Type enumType, int rejectedValue)
        {
            _enumType = enumType;
            RejectedValue = rejectedValue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((int)value == RejectedValue)
            {
                var displayName = validationContext.DisplayName;
                var errorMessage = $"The value '{value}' is not valid for {displayName}.Please choose some option";
                return new ValidationResult(errorMessage);
            }
            return ValidationResult.Success;
        }

    }
}