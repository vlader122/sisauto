using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DB.Models
{
    public class Clientes : IValidatableObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion {  get; set; }
        public string Telefono { get; set; }
        [ForeignKey("PaisID")]
        public int PaisID { get; set; }
        [JsonIgnore]
        public virtual Paises ?Pais { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Nombre.Length < 2 || Nombre.Length > 10)
            {
                yield return new ValidationResult("La longitud del nombre tiene que estar entre 2 y 10", new[] { "Nombre" });
            }
        }
    }
}
