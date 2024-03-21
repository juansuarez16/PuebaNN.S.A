using PruebaNN.S.A.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNN.S.A.Domain.Entities
{
    public class Usuarios:EntityBase
    {
        public string usuario { get; set; }
        public string contrasena { get; set; }
    }
}
