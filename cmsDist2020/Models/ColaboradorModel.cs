using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cmsDist2020.Models
{
    public class ColaboradorModel
    {
		public int Id { get; set; }

		[Required(ErrorMessage = "No te olvides del nombre del COLABORADOR(A)")]
		[DataType(DataType.Text)]
		public string Nombre { get; set; }

		[Required(ErrorMessage = "No te olvides de la DIRECCION")]
		[DataType(DataType.Text)]
		public string Direccion { get; set; }

		[Required(ErrorMessage = "No te olvides de un correo electronico")]
		[DataType(DataType.EmailAddress)]
		[EmailAddress]
		public string Correo { get; set; }

		[Required(ErrorMessage = "No te olvides del TELEFONO")]
		[DataType(DataType.Text)]
		public string Telefono { get; set; }
		public int IdDistribuidor { get; set; }
	}
}
