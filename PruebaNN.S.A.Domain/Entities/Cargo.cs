using PruebaNN.S.A.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNN.S.A.Domain.Entities
{
    [Table("Cargo")]
    public class Cargo:EntityBase
    {
        public string nombre { get; set; }
    }
}
