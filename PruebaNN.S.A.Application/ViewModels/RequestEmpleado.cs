using PruebaNN.S.A.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaNN.S.A.Application.ViewModels
{
    public class RequestEmpleado
    {
        public Empleado empleado { get; set; }  
        public Usuarios usuario { get; set; }
        public int rol { get; set; }        
    }
}
