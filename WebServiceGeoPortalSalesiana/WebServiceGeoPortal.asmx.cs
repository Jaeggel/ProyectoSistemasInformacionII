using AccesoDatos;
using AccesoDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServiceGeoPortalSalesiana
{
    /// <summary>
    /// Descripción breve de WebServiceGeoPortal
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceGeoPortal : System.Web.Services.WebService
    {
        private AccDatos db = new AccDatos();
        public WebServiceGeoPortal()
        {
            db.setConnString(ConfigurationManager.AppSettings["ConnectionInfo"]);
            db.connectDB();
        }
        [WebMethod]
        public Boolean ingresoCasaSalesiana(string nombre_cas,string direccion_cas,string telefono_cas,string correo_cas,string director_cas,string nombrecorto_cas)
        {
            CasaSalesiana casa = new CasaSalesiana
            {
                nombre_cas=nombre_cas,
                direccion_cas=direccion_cas,
                telefono_cas=telefono_cas,
                correo_cas=correo_cas,
                director_cas=director_cas,
                nombrecorto_cas=nombrecorto_cas
            };
            return db.insertCasaSalesiana(casa);
        }
        [WebMethod]
        public Boolean ingresoTipoObraSalesiana(string descripcion_tobr,string pathicono_tobr)
        {
            TipoObraSalesiana tipoobra = new TipoObraSalesiana
            {
                Descripcion_tobr=descripcion_tobr,
                PathIcono_tobr=pathicono_tobr
            };
            return db.insertTipoObraSalesiana(tipoobra);
        }
        [WebMethod]
        public Boolean comprobarUsuario(string usuario,string clave)
        {
            db.obtenerListaUsuarios();
            return db.comprobarUsuario(usuario, clave);
        }
        [WebMethod]
        public List<string> lstCasasSalesianas()
        {
            return db.obtenerListaNombreCasaSalesiana();
        }
        [WebMethod]
        public List<string> lstTipoObras()
        {
            return db.obtenerListaTipoCasaSalesiana();
        }
        [WebMethod]
        public List<string> lstObrasSalesianasPorCasa(string casa)
        {
            return db.obtenerListaObrasPorCasa(casa);
        }
        [WebMethod]
        public List<string> lstLugarPorObraSalesiana(string obraSalesiana)
        {
            return db.obtenerListaLugarPorObra(obraSalesiana);
        }
        [WebMethod]
        public List<string> lstTipoColaborador()
        {
            return db.obtenerListaTipoColaborador();
        }
    }
}
