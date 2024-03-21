using PruebaNN.S.A.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNN.S.A.Domain.Entities
{
    [Table("Empleado")]
    public class Empleado:EntityBase
    {
        public int cedula { get; set; }
        public string nombre { get; set; }
        public string rutaFoto { get; set; } 
        public DateTime fechaIngreso { get; set; }
        public int cargoId { get; set; }
        public int usuarioId { get; set; }
        public int rolId { get; set; }
    }
}
