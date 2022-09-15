using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.Entities
{
    public class Actor : BaseEntity
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [MaxLength(40, ErrorMessage = "El campo {0} debe tener una longitud máxima de {1} caracteres")]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Photo { get; set; }
    }
}
