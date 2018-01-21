using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Entidades
{
    public class Lugar
    {
        public int id_obr{ get; set; }
        public string desc_obr { get; set; }
        public int id_elug { get; set; } = 1;
        public string desc_elug { get; set; }
        public string nombre_lug{ get; set; }
        public string descripcion_lug{ get; set; }
        public string responsable_lug{ get; set; }
        public string direccion_lug{ get; set; }
        public string telefono_lug{ get; set; }
        public float latitud_lug{ get; set; }
        public float longitud_lug { get; set; }
        public string coordenada_lug{ get; set; }
        public Boolean estado_lug { get; set; } = true;
    }
}
