using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.DTOs
{
    /// <summary>
    /// Este DTO posee contiene la información completa de la entidad Actor.
    /// Usos: Para servicios de consulta
    /// </summary>
    public class ActorDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Photo { get; set; }
    }
}
