﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsDist2020.Models
{
    public class LoginModel
    {
		public int Id { get; set; }
		public string Nombre { get; set; }

		public string Direccion { get; set; }

		public string Email { get; set; }

		public string Telefono { get; set; }

		public DateTime Fecha_caducidad { get; set; }
	}
}
