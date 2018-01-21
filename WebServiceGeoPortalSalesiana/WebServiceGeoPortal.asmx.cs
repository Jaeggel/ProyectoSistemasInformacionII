using AccesoDatos;
using AccesoDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;

namespace WebServiceGeoPortalSalesiana
{
    /// <summary>
    /// Web Service para la comunicación con la Base de Datos del GeoPortalSalesiano 
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WebServiceGeoPortal : System.Web.Services.WebService
    {
        #region Inicio Conexión Base de Datos
        private AccDatos db = new AccDatos();
        private static string nombreFoto=string.Empty;
        /// <summary>
        /// Constructor para el inicio de la conexión con la Base de Datos
        /// </summary>
        public WebServiceGeoPortal()
        {
            db.SetConnString(ConfigurationManager.AppSettings["ConnectionInfo"]);
            db.ConnectDB();
        }
        #endregion

        #region Ingresos a la Base de Datos
        /// <summary>
        /// Método del WebService para el Ingreso de una nueva Casa Salesiana
        /// </summary>
        /// <param name="nombre_cas"></param>
        /// <param name="direccion_cas"></param>
        /// <param name="telefono_cas"></param>
        /// <param name="correo_cas"></param>
        /// <param name="director_cas"></param>
        /// <param name="nombrecorto_cas"></param>
        /// <returns></returns>
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
            return db.InsertCasaSalesiana(casa);
        }
        /// <summary>
        /// Método del WebService para el Ingreso de un nuevo Tipo de Obra Salesiana.
        /// </summary>
        /// <param name="descripcion_tobr"></param>
        /// <param name="pathicono_tobr"></param>
        /// <returns></returns>
        [WebMethod]
        public Boolean ingresoTipoObraSalesiana(string descripcion_tobr,string pathicono_tobr)
        {
            TipoObraSalesiana tipoobra = new TipoObraSalesiana
            {
                Descripcion_tobr=descripcion_tobr,
                PathIcono_tobr=pathicono_tobr
            };
            return db.InsertTipoObraSalesiana(tipoobra);
        }
        /// <summary>
        /// Método del WebService para el Ingreso de un nuevo Tipo de Colaborador.
        /// </summary>
        /// <param name="descripcion_tcol"></param>
        /// <returns></returns>
        [WebMethod]
        public Boolean ingresoTipoColaborador(string descripcion_tcol)
        {
            TipoColaborador tipocol = new TipoColaborador
            {
                descripcion_tcol=descripcion_tcol
            };
            return db.InsertTipoColaborador(tipocol);
        }
        /// <summary>
        /// Método del WebService para el Ingreso de una nueva Obra Salesiana.
        /// </summary>
        /// <param name="casa_obr"></param>
        /// <param name="tipoobra_obr"></param>
        /// <param name="denominacion_obr"></param>
        /// <param name="camposervicio_obr"></param>
        /// <param name="productos_obr"></param>
        /// <param name="horario_obr"></param>
        /// <param name="informacion_obr"></param>
        /// <param name="paginaweb_obr"></param>
        /// <param name="nombrecorto_obr"></param>
        /// <returns></returns>
        [WebMethod]
        public Boolean ingresoObraSalesiana(string casa_obr,string tipoobra_obr, string denominacion_obr,string camposervicio_obr,string productos_obr,string horario_obr,string informacion_obr, string paginaweb_obr,string nombrecorto_obr)
        {
            ObraSalesiana obraSal=new ObraSalesiana
            {
                id_tobr=db.ObtenerIdTipoObra(tipoobra_obr),
                id_cas= db.ObtenerIdCasaSalesiana(casa_obr),
                denominacion_obr=denominacion_obr,
                camposervicio_obr=camposervicio_obr,
                productos_obr=productos_obr,
                horario_obr=horario_obr,
                informacion_obr=informacion_obr,
                paginaweb_obr=paginaweb_obr,
                nombrecorto_obr=nombrecorto_obr
            };
            return db.InsertObraSalesiana(obraSal);
        }
        /// <summary>
        /// Método del WebService para el Ingreso de un nuevo Lugar.
        /// </summary>
        /// <param name="denominacion_obr"></param>
        /// <param name="nombre_lug"></param>
        /// <param name="descripcion_lug"></param>
        /// <param name="responsable_lug"></param>
        /// <param name="direccion_lug"></param>
        /// <param name="telefono_lug"></param>
        /// <param name="latitud_lug"></param>
        /// <param name="longitud_lug"></param>
        /// <returns></returns>
        [WebMethod]
        public Boolean ingresoLugar(string denominacion_obr,string nombre_lug,string descripcion_lug,string responsable_lug,string direccion_lug,string telefono_lug,string latitud_lug,string longitud_lug)
        {
            Lugar lugar = new Lugar
            {
                id_obr = db.ObtenerIdObra(denominacion_obr),
                nombre_lug = nombre_lug,
                descripcion_lug = descripcion_lug,
                responsable_lug = responsable_lug,
                direccion_lug = direccion_lug,
                telefono_lug = telefono_lug,
                latitud_lug=Convert.ToDouble(latitud_lug),
                longitud_lug= Convert.ToDouble(longitud_lug)
            };
            return db.InsertLugar(lugar);
        }
        /// <summary>
        /// Método del WebService para el Ingreso de una nuevo Colaborador.
        /// </summary>
        /// <param name="nombre_lug"></param>
        /// <param name="descripcion_tcol"></param>
        /// <param name="numero_col"></param>
        /// <returns></returns>
        [WebMethod]
        public Boolean ingresoColaborador(string nombre_lug,string descripcion_tcol,int numero_col)
        {
            Colaborador colab=new Colaborador
            {
                id_lug=db.ObtenerIdLugar(nombre_lug),
                id_tcol=db.ObtenerIdTipoColaborador(descripcion_tcol),
                numero_col=numero_col
            };
            return db.InsertColaborador(colab);
        }
        /// <summary>
        /// Método del WebService para el Ingreso de una nuevo Beneficiario.
        /// </summary>
        /// <param name="nombre_lug"></param>
        /// <param name="descripcion_ben"></param>
        /// <param name="numero_ben"></param>
        /// <returns></returns>
        [WebMethod]
        public Boolean ingresoBeneficiario(string nombre_lug,string descripcion_ben,int numero_ben)
        {
            Beneficiario bene=new Beneficiario
            {
                id_lug = db.ObtenerIdLugar(nombre_lug),
                numero_ben=numero_ben,
                descripcion_ben=descripcion_ben
            };
            return db.InsertBeneficiario(bene);
        }
        /// <summary>
        /// Método del WebService para el Ingreso de una nueva Foto.
        /// </summary>
        /// <param name="nombre_lug"></param>
        /// <param name="descripcion_flug"></param>
        /// <param name="pathfoto_flug"></param>
        /// <returns></returns>
        [WebMethod]
        public Boolean ingresoFotoLugar(string nombre_lug,string descripcion_flug,string pathfoto_flug)
        {
            nombreFoto = db.ObtenerNombrePathFoto(pathfoto_flug);
            FotoLugar foto = new FotoLugar
            {
                id_lug = db.ObtenerIdLugar(nombre_lug),
                descripcion_flug = descripcion_flug,
                pathfoto_flug = ConfigurationManager.AppSettings["prepathfoto_flug"]+ nombreFoto 
            };
            return db.InsertFotoLugar(foto);
        }
        #endregion

        #region Login - Comprobación Usuario
        /// <summary>
        /// Método del WebService para la comprobación del usuario (Autenticación de Usuario).
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="clave"></param>
        /// <returns></returns>
        [WebMethod]
        public Boolean comprobarUsuario(string usuario,string clave)
        {
            db.ObtenerListaUsuarios();
            return db.ComprobarUsuario(usuario, clave);
        }
        #endregion

        #region Consultas - Listas
        /// <summary>
        /// Método del WebService para la obtención de una lista con las Casas Salesianas.
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public List<string> lstCasasSalesianas()
        {
            return db.ObtenerListaNombreCasaSalesiana();
        }
        /// <summary>
        /// Método del WebService para la obtención de una lista con los Tipos de Obras de Salesianas.
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public List<string> lstTipoObrasSalesianas()
        {
            return db.ObtenerListaTipoObraSalesiana();
        }
        /// <summary>
        /// Método del WebService para la obtención de una lista con las Obras Salesianas. Se busca por Casa Salesiana.
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public List<string> lstObrasSalesianasPorCasa(string casa)
        {
            return db.ObtenerListaObrasPorCasa(casa);
        }
        /// <summary>
        /// Método del WebService para la obtención de una lista con los Lugares. Se busca por Obra Salesiana.
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public List<string> lstLugarPorObraSalesiana(string obraSalesiana)
        {
            return db.ObtenerListaLugarPorObra(obraSalesiana);
        }
        [WebMethod]
        public List<Usuario> testUsuarios()
        {
            return db.ObtenerListaUsuarios();
        }

        /// <summary>
        /// Método del WebService para la obtención de una lista con los Tipos de Colaboradores.
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public List<string> lstTipoColaborador()
        {
            return db.ObtenerListaTipoColaborador();
        }
        /// <summary>
        /// Método para almacenar mediante FTP la foto proveniente de la App.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [WebMethod]
        public Boolean ingresoFotoFTP(Byte[] data)
        {
            try
            {
                File.WriteAllBytes(@"E:\FotosAndroid\" + nombreFoto, data);
                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential("carlos", "carlos");
                    client.UploadFile(ConfigurationManager.AppSettings["url_ftpFotos"] + nombreFoto, "STOR", @"E:\FotosAndroid\" + nombreFoto);
                }
                nombreFoto = string.Empty;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        #endregion        
    }
}
