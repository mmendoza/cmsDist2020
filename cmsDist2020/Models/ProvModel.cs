using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsDist2020.Models
{
    public class ProvModel
    {
        public string IdProv { get; set; }
        public string NombProv { get; set; }
        public string DptoId { get; set; }
        public DptoModel dptoModel { get; set; }
    }
}
