using PruebaNN.S.A.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNN.S.A.Domain.Entities
{
    public class SolicitudServicio:EntityBase
    {
        public int empleadoId { get; set; }
        public DateTime fechaSolicitud { get; set; }
        public int estadoSolicitudId { get; set; }
        public int servicioSolicitadoId { get; set; }
    }
}
