using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Entidades
{
    public class Colaborador
    {
        public int id_lug { get; set; }
        public int id_tcol{ get; set; }
        public int numero_col{ get; set; }
        public Boolean estado_col { get; set; } = true;
    }
}
