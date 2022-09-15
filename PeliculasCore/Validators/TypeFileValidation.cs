using Microsoft.AspNetCore.Http;
using PeliculasCore.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.Validators
{
    internal class TypeFileValidation : ValidationAttribute
    {
        private readonly string[] extensions;

        public TypeFileValidation(string[] extensions)
        {
            this.extensions = extensions;
        }

        public TypeFileValidation(TypeFile typeFile)
        {
            if (typeFile == TypeFile.Images)
            {
                extensions = new string[] { "image/jpeg", "image/pgn", "image/gif" };
            }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;

            IFormFile formFile = value as IFormFile;
            if (formFile == null) return ValidationResult.Success;

            if (!extensions.Contains(formFile.ContentType))
            {
                return new ValidationResult($"La extensión del archivo debe ser una de la siguente lista {string.Join(", ", extensions)}");
            }


            return ValidationResult.Success;
        }
    }
}
