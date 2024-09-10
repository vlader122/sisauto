using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace DB.Models
{
    public class Ordenes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrdenID { get; set; }
        public int ClienteID { get; set; }
        public DateTime fecha { get; set; }
        public decimal Total { get; set; }
        public virtual Clientes Cliente { get; set; }
        public virtual ICollection<DetalleOrdenes> DetalleOrdenes { get; set; }

    }
}
