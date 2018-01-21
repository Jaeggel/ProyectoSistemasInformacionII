using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Entidades
{
    public class Beneficiario
    {
        public int id_eben { get; set; } = 1;
        public string desc_eben { get; set; }
        public int id_lug { get; set; }
        public string desc_lug{ get; set; }
        public string descripcion_ben { get; set; }
        public int numero_ben { get; set; }
        public string areainfluencia_ben{ get; set; }
        public Boolean estado_ben { get; set; } = true;
    }
}
