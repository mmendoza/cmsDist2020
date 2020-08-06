using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cmsDist2020.Models
{
    public class ContratoModel
    {
        public double Id { get; set; }
        public double IdProducto { get; set; }
        public double IdDistribuidor { get; set; }
        [Required]
        public string IdCliente { get; set; }
        [Required]
        public string IdColaborador { get; set; }

        [Required(ErrorMessage = "No te olvides del N° de Contrato")]
        public string NroContrato { get; set; }
        [Required]
        [Range(1, 12, ErrorMessage = "El rango permitido es  (1-12)")]
        public double NroCuotas { get; set; }
        public string EstadoPin { get; set; }
    }
}
