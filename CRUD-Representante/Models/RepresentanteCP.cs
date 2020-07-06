using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_Representante.Models
{
    public class RepresentanteCP
    {
        [Required]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }
        [Required]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }
        [Required]
        [Display(Name = "Parentesco")]
        public string Parentesco { get; set; }
        [Required]
        [Display(Name = "Teléfono")]
        public int Telefono { get; set; }

    }
    

    [MetadataType(typeof(RepresentanteCP))]
    public partial class Representante
    {

    }
}