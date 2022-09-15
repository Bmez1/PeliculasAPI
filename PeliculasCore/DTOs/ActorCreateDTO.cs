using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PeliculasCore.Validators;
using PeliculasCore.Enums;

namespace PeliculasCore.DTOs
{
    /// <summary>
    /// Este DTO posee contiene la información del Actor para registrarlo en la DB o actualizarlo
    /// Usos: Para servicios de consulta
    /// </summary>
    public class ActorCreateDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(40, ErrorMessage = "El campo {0} debe tener una longitud máxima de {1} caracteres")]
        public string Name { get; set; }
        public DateTime Date { get; set; }

        [SizeFileValidation(sizeMaxMB:4)]
        [TypeFileValidation(TypeFile.Images)]
        public IFormFile Photo { get; set; }
    }
}
