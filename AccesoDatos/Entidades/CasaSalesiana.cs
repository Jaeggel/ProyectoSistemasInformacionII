using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Entidades
{
    public class CasaSalesiana
    {
        public string nombre_cas { get; set; }
        public string direccion_cas { get; set; }
        public string telefono_cas { get; set; }
        public string correo_cas { get; set; }
        public string director_cas{ get; set; }
        public string nombrecorto_cas{ get; set; }
        public string pathicono_cas { get; set; } = ConfigurationManager.AppSettings["pathicono_cas"];
        public Boolean estado_cas { get; set; } = true;

    }
}
