using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CrudPersonaSp.Models
{
    public class Personas
    {
        [Required]
        public int idPersona { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string direccion { get; set; }
        
        public byte[] imagen { get; set; }
        public DateTime nacimiento { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }

    }
}