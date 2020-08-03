using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsDist2020.Models
{
    public class ClientesModel
    {
        public int Id { get; set; }
        public string RucDni { get; set; }
        public string Nombre { get; set; }
        public string ApePat { get; set; }
        public string Apemat { get; set; }
        public string Direccion { get; set; }
        public string Id_Distrito { get; set; }
        public string Dist { get; set; }
        public string Prov { get; set; }
        public string Dep { get; set; }
        public string Telefonos { get; set; }
        public string Email01 { get; set; }
        public string Email02 { get; set; }
        public string Email03 { get; set; }
        public string IdEstado { get; set; }
        public string Estado { get; set; }
        public int IdDistribuidor { get; set; }
    }
}
