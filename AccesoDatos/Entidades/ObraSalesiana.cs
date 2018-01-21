using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Entidades
{
    public class ObraSalesiana
    {
        public int id_tobr{ get; set; }
        public string desc_tobr { get; set; }
        public int id_cas { get; set; }
        public string desc_cas { get; set; }
        public string denominacion_obr{ get; set; }
        public string camposervicio_obr { get; set; }
        public string productos_obr{ get; set; }
        public string horario_obr{ get; set; }
        public string informacion_obr{ get; set; }
        public string pathicono_obr { get; set; } = ConfigurationManager.AppSettings["pathicono_obr"];
        public string nombrecorto_obr{ get; set; }
        public string paginaweb_obr{ get; set; }
        public Boolean estado_obr { get; set; } = true;
    }
}
