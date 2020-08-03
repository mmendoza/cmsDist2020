using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsDist2020.Models
{
    public class ProductosModel
    {
		public int Id { get; set; }
		public string IdClienteDist { get; set; }
		public string Cliente { get; set; }
		public string Direccion { get; set; }
		public string Telefono { get; set; }
		public string Correo01 { get; set; }
		public string Correo02 { get; set; }
		public string Correo03 { get; set; }
		public string Colaborador { get; set; }
		public int IdProducto { get; set; }
		public string Producto { get; set; }
		public string NroContrato { get; set; }
		public string NroCuotas { get; set; }
		public string NroPin { get; set; }
		public string EstadoPin { get; set; }
		public string IdEstadoContrato { get; set; }
		public DateTime FechaRegistro { get; set; }
		public string IdColaborador { get; set; }
		public int IdDistribuidor { get; set; }
	}
}
