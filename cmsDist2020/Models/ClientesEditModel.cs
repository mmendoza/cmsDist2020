using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cmsDist2020.Models
{
    public class ClientesEditModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "No te olvides del RUC o DNI")]
        [StringLength(11, MinimumLength = 8, ErrorMessage = "RUC 11 characters Y PARA dni 8 characteres")]
        public string RucDni { get; set; }

        [Required(ErrorMessage = "No te olvides del Nombre")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
        [DataType(DataType.Text)]
        public string ApePat { get; set; }
        [DataType(DataType.Text)]
        public string Apemat { get; set; }
        [Required(ErrorMessage = "No te olvides de la DIRECCION")]
        [DataType(DataType.Text)]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "No te olvides de seleccionar el DEPARTAMENTO")]
        public string IdDep { get; set; } = "00";


        [Required(ErrorMessage = "No te olvides de seleccionar la PROVINCIA")]
        public string IdProv { get; set; } = "0000";
        public DptoModel dptoModel { get; set; }


        [Required(ErrorMessage = "No te olvides de seleccionar el DISTRITO")]
        public string IdDist { get; set; } = "000000";
        public ProvModel provModel { get; set; }


        [Required(ErrorMessage = "No te olvides de ingresar el Numero de TELEFONO")]
        [DataType(DataType.Text)]
        public string Telefonos { get; set; }
        [Required(ErrorMessage = "No te olvides de un correo electronico")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email01 { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email02 { get; set; }
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email03 { get; set; }

        [Required(ErrorMessage = "No te olvides el ESTADO del CLIENTE")]
        public string IdEstado { get; set; } = "1";
        public int IdDistribuidor { get; set; }
    }
}
