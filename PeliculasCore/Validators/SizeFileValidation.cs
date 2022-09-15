using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.Validators
{
    /// <summary>
    /// Clase que contiene el método para validar que un archivo no supere un peso máximo pasado por parámetro.
    /// </summary>
    public class SizeFileValidation : ValidationAttribute
    {
        private readonly int sizeMaxMB;

        public SizeFileValidation(int sizeMaxMB)
        {
            this.sizeMaxMB = sizeMaxMB;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;

            IFormFile formFile = value as IFormFile;
            if (formFile == null) return ValidationResult.Success;

            if (formFile.Length > sizeMaxMB * 1024 * 1024)
            {
                return new ValidationResult(ErrorMessage = $"El archivo supera el peso máximo de {sizeMaxMB} MB");
            }

            return ValidationResult.Success;    

        }
    }
}
