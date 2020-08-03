using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsDist2020.Models
{
    public class DistModel
    {
        public string IdDist { get; set; }
        public string NombDist { get; set; }
        public string ProvId { get; set; }
        public ProvModel provModel { get; set; }
    }
}
