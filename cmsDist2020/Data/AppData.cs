using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsDist2020.Data
{
    public class AppData
    {
		public int Id { get; set; } = 0;
		public string Nombre { get; set; }
		public string Direccion { get; set; }
		public string Email { get; set; }
		public string Telefono { get; set; }
		public DateTime Fecha_caducidad { get; set; }
		public double ProductoId { get; set; }
		public double ContratoId  { get; set; }
		public double TipoAccionPin { get; set; }
	}
}
