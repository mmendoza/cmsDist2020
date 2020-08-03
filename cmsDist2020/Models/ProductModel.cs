using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsDist2020.Models
{
    public class ProductModel
    {
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public int Registrado { get; set; }
        public int C_Pin { get; set; }
        public int C_Pin_Anulado { get; set; }
        public int Cod { get; set; }
    }
}
