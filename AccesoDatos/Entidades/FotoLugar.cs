using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Entidades
{
    public class FotoLugar
    {
        public int id_lug { get; set; }
        public string desc_lug{ get; set; }
        public string descripcion_flug{ get; set; }
        public string pathfoto_flug { get; set; }
        public Boolean estado_flug { get; set; } = true;
    }
}
