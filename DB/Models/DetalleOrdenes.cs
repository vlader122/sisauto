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
    public class DetalleOrdenes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DetalleOrdenID { get; set; }
        public int OrdenID { get; set; }
        public int ServicioID { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public virtual Ordenes ?Orden { get; set; }
        public virtual Servicios ?Servicio { get; set; }

    }
}
