using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consolaApi
{
    public  class Report
    {
        public string Flota { get; set; }
        public string Log { get; set; }
        public string Nombre { get; set; }
        public Grupo Grupo { get; set; }
        public string Descripcion { get; set; }

    }
}
