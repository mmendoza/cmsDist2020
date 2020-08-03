using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsDist2020.Models
{
    public class ContratoModel
    {
        public double Id { get; set; }
        public double IdProducto { get; set; }
        public double IdDistribuidor { get; set; }
        public string IdCliente { get; set; }
        public string IdColaborador { get; set; }
        public string NroContrato { get; set; }
        public double NroCuotas { get; set; }
    }
}
