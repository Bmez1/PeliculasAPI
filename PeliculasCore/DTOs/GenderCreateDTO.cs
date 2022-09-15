using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.DTOs
{
    public class GenderCreateDTO
    {
        [Required(ErrorMessage = "El ccampo {0} es requerido")]
        [StringLength(20, ErrorMessage = "Error: El campo {0} no debe tener una longotid mayor a {1}")]
        public string Name { get; set; }
    }
}
