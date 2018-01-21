using AccesoDatos.Entidades;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AccesoDatos
{
    /// <summary>
    /// Clase en donde se realizan las diversas transacciones con la base de datos
    /// </summary>
    public class AccDatos
    {
        #region Conexión Base de Datos - Inicio Componentes Varios      
        private static NpgsqlConnection conn=null;
        static List<Usuario> lstUsuarios = new List<Usuario>();
        string connstring = null;
        
        /// <summary>
        /// Método para inicializar la cadena de conexión con la Base de Datos
        /// </summary>
        /// <param name="ConnectionString"></param>
        /// <returns></returns>
        public void SetConnString(string ConnectionString)
        {
            connstring = ConnectionString;
        }
        /// <summary>
        /// Métoto para realizar la conexiónn con la Base de Datos
        /// </summary>
        /// <returns></returns>
        public Boolean ConnectDB()
        {
            try
            {
                conn = new NpgsqlConnection(connstring);
                conn.Open();
            }
            catch (Exception)
            {
                return false;
            }
        return true;
        }
        #endregion

        #region Inserciones en la Base de Datos   
        /// <summary>
        /// Método para la inserciòn de una Casa Salesiana.
        /// </summary>
        /// <param name="casa"></param>
        /// <returns></returns>
        public Boolean InsertCasaSalesiana(CasaSalesiana casa)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("insert into tb_casasalesiana(nombre_cas,direccion_cas,telefono_cas,correo_cas,director_cas,nombrecorto_cas,estado_cas,pathicono_cas) values('" + casa.nombre_cas+ "','" + casa.direccion_cas + "','" + casa.telefono_cas + "','" + casa.correo_cas + "','" + casa.director_cas + "','" + casa.nombrecorto_cas + "','"+casa.estado_cas+ "','"+casa.pathicono_cas+"')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Método para la inserción de un Tipo de Obra Salesiana
        /// </summary>
        /// <param name="tipoobra"></param>
        /// <returns></returns>
        public Boolean InsertTipoObraSalesiana(TipoObraSalesiana tipoobra)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("insert into tb_tipoobra(descripcion_tobr,pathicono_tobr,estado_tobr) values('" + tipoobra.Descripcion_tobr + "','" + tipoobra.PathIcono_tobr+ "','" + tipoobra.Estado_tobr+"')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Método para la inserción de un Tipo de Colaborador
        /// </summary>
        /// <param name="tipocol"></param>
        /// <returns></returns>
        public Boolean InsertTipoColaborador(TipoColaborador tipocol)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("insert into tb_tipocolaborador(descripcion_tcol,estado_tcol) values('"+tipocol.descripcion_tcol+"','"+tipocol.estado_col+"')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Método para la inserción de una Obra Salesiana
        /// </summary>
        /// <param name="obra"></param>
        /// <returns></returns>
        public Boolean InsertObraSalesiana(ObraSalesiana obra)
        {
            conn.Open();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("insert into tb_obrasalesiana(id_tobr,id_cas,denominacion_obr,camposervicio_obr,productos_obr,horario_obr,informacion_obr,pathicono_obr,nombrecorto_obr,paginaweb_obr,estado_obr) values('" + obra.id_tobr + "','" + obra.id_cas + "','" + obra.denominacion_obr + "','" +obra.camposervicio_obr + "','" +obra.productos_obr + "','"+obra.horario_obr + "','" +obra.informacion_obr + "','"+obra.pathicono_obr + "','"+obra.nombrecorto_obr + "','"+obra.paginaweb_obr + "','"+obra.estado_obr+ "')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Método para la inserción de un Lugar
        /// </summary>
        /// <param name="lugar"></param>
        /// <returns></returns>
        public Boolean InsertLugar(Lugar lugar)
        {
            conn.Open();
            //lugar.coordenada_lug = "GeometryFromText('POINT(" + lugar.latitud_lug + " " + lugar.longitud_lug + ")', 4326)";
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("insert into tb_lugar(id_obr,id_elug,nombre_lug,descripcion_lug,responsable_lug,direccion_lug,telefono_lug,coordenada_lug,estado_lug) values('" + lugar.id_obr + "','" + lugar.id_elug + "','" + lugar.nombre_lug + "','" + lugar.descripcion_lug+ "','" + lugar.responsable_lug+ "','" + lugar.direccion_lug+ "','" + lugar.telefono_lug+ "'," + "GeometryFromText('POINT("+lugar.latitud_lug.ToString().Replace(',','.')+" "+ lugar.longitud_lug.ToString().Replace(',', '.') + ")', 4326)"+ ",'" + lugar.estado_lug+ "')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Método para la inserción de un Colaborador
        /// </summary>
        /// <param name="colaborador"></param>
        /// <returns></returns>
        public Boolean InsertColaborador(Colaborador colaborador)
        {
            conn.Open();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("insert into tb_colaborador(id_lug,id_tcol,numero_col,estado_col) values('" + colaborador.id_lug+ "','" + colaborador.id_tcol+ "','" + colaborador.numero_col+ "','" + colaborador.estado_col+"')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Método para la inserción de un Beneficiario
        /// </summary>
        /// <param name="bene"></param>
        /// <returns></returns>
        public Boolean InsertBeneficiario(Beneficiario bene)
        {
            conn.Open();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("insert into tb_beneficiario(id_eben,id_lug,descripcion_ben,numero_ben,areainfluencia_ben,estado_ben) values('" + bene.id_eben + "','" + bene.id_lug+ "','" + bene.descripcion_ben+ "','" + bene.numero_ben + "','"+bene.areainfluencia_ben + "','"+bene.estado_ben+ "')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Método para la inserción de una Foto Lugar
        /// </summary>
        /// <param name="foto"></param>
        /// <returns></returns>
        public Boolean InsertFotoLugar(FotoLugar foto)
        {
            conn.Open();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("insert into tb_fotolugar(id_lug,descripcion_flug,pathfoto_flug,estado_flug) values('" + foto.id_lug+ "','" + foto.descripcion_flug+ "','" + foto.pathfoto_flug+ "','" + foto.estado_flug+"')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Consultas Listas de la Base de datos
        /// <summary>
        /// Obtención de la lista que contiene los nombres de las Casas Salesianas
        /// </summary>
        /// <returns></returns>
        public List<string> ObtenerListaNombreCasaSalesiana()
        {
            List<string> lstCasasSalesianas = new List<string>();
            try
            {
                NpgsqlCommand command = new NpgsqlCommand("select nombre_cas from tb_casasalesiana", conn);
                NpgsqlDataReader dr = command.ExecuteReader();                
                while (dr.Read())
                    lstCasasSalesianas.Add(dr[0].ToString().Trim());
                conn.Close();
            }
            catch(Exception)
            {
                lstCasasSalesianas = null;
            }
            return lstCasasSalesianas;
        }
        /// <summary>
        /// Obtención de la lista que contiene los Usuarios
        /// </summary>
        /// <returns></returns>
        public List<Usuario> ObtenerListaUsuarios()
        {
            try
            {
                NpgsqlCommand command = new NpgsqlCommand("select usuario_usu,contrasenia_usu from tb_usuario", conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    Usuario user = new Usuario();
                    user.Nombre_Usuario = dr[0].ToString().Trim();
                    user.Contrasenia = dr[01].ToString().Trim();
                    lstUsuarios.Add(user);
                }
                conn.Close();
            }
            catch (Exception)
            {
                lstUsuarios = null;
            }
            return lstUsuarios;
        }
        /// <summary>
        /// Obtención de la lista que contiene los Tipos de Obra Salesianas
        /// </summary>
        /// <returns></returns>
        public List<string> ObtenerListaTipoObraSalesiana()
        {
            List<string> lstTipoObras = new List<string>();
            try
            {
                NpgsqlCommand command = new NpgsqlCommand("select descripcion_tobr from tb_tipoobra", conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                    lstTipoObras.Add(dr[0].ToString().Trim());
                conn.Close();
            }
            catch (Exception)
            {
                lstTipoObras = null;
            }
            return lstTipoObras;
        }
        /// <summary>
        /// Obtención de la lista que contiene las Obras Salesianas. Se busca por el nombre de la Casa Salesiana.
        /// </summary>
        /// <param name="NombreCasa"></param>
        /// <returns></returns>
        public List<string> ObtenerListaObrasPorCasa(string NombreCasa)
        {
            List<string> lstObras = new List<string>();
            try
            {
                NpgsqlCommand command = new NpgsqlCommand("select denominacion_obr from tb_obrasalesiana where id_cas in (Select id_cas from tb_casasalesiana where nombre_cas='"+NombreCasa.Trim()+"')", conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                    lstObras.Add(dr[0].ToString().Trim());
                conn.Close();
            }
            catch (Exception)
            {
                lstObras = null;
            }
            return lstObras;
        }
        /// <summary>
        /// Obtención de la lista que contiene los Lugares. Se busca por la Denominación de la Obra Salesiana.
        /// </summary>
        /// <param name="DenominacionObra"></param>
        /// <returns></returns>
        public List<string> ObtenerListaLugarPorObra(string DenominacionObra)
        {
            List<string> lstLugar = new List<string>();
            try
            {
                NpgsqlCommand command = new NpgsqlCommand("select nombre_lug from tb_lugar where id_obr in (Select id_obr from tb_obrasalesiana where denominacion_obr='"+DenominacionObra+"')", conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                    lstLugar.Add(dr[0].ToString().Trim());
                conn.Close();
            }
            catch (Exception)
            {
                lstLugar = null;
            }
            return lstLugar;
        }
        /// <summary>
        /// Obtención de la lista que contiene los Tipos de Colaboradores.
        /// </summary>
        /// <returns></returns>
        public List<string> ObtenerListaTipoColaborador()
        {
            List<string> lstColaborador = new List<string>();
            try
            {
                NpgsqlCommand command = new NpgsqlCommand("select descripcion_tcol from tb_tipocolaborador", conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                    lstColaborador.Add(dr[0].ToString().Trim());
                conn.Close();
            }
            catch (Exception)
            {
                lstColaborador = null;
            }
            return lstColaborador;
        }
        #endregion

        #region Consultas varias de la Base de Datos
        /// <summary>
        /// Obtención del Id de la Casa Salesiana. Se busca por el Nombre de la Casa Salesiana
        /// </summary>
        /// <param name="nombreCasa"></param>
        /// <returns></returns>
        public int ObtenerIdCasaSalesiana(string nombreCasa)
        {
            conn.Open();
            int idCasa=0;
            try
            {
                NpgsqlCommand command = new NpgsqlCommand("select id_cas from tb_casasalesiana where nombre_cas='"+nombreCasa.Trim()+"'", conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                    idCasa =Convert.ToInt32(dr[0].ToString().Trim());

                conn.Close();
            }
            catch (Exception)
            {
                idCasa = 0;
            }
            return idCasa;
        }
        /// <summary>
        /// Obtención del Id Tipo Obra. Se busca por la Descripción del Tipo de Obra Salesiana.
        /// </summary>
        /// <param name="tipoObra"></param>
        /// <returns></returns>
        public int ObtenerIdTipoObra(string tipoObra)
        {
            int idTipo = 0;
            try
            {
                NpgsqlCommand command = new NpgsqlCommand("select id_tobr from tb_tipoobra where descripcion_tobr='" + tipoObra+ "'", conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                    idTipo = Convert.ToInt32(dr[0].ToString().Trim());

                conn.Close();
            }
            catch (Exception)
            {
                idTipo = 0;
            }
            return idTipo;
        }
        /// <summary>
        /// Obtención del Id de Obra Salesiana. Se busca por la Denominación de la Obra Salesiana.
        /// </summary>
        /// <param name="denominacion"></param>
        /// <returns></returns>
        public int ObtenerIdObra(string denominacion)
        {
            int idObra = 0;
            try
            {
                NpgsqlCommand command = new NpgsqlCommand("select id_obr from tb_obrasalesiana where denominacion_obr='" + denominacion + "'", conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                    idObra= Convert.ToInt32(dr[0].ToString().Trim());

                conn.Close();
            }
            catch (Exception)
            {
                idObra = 0;
            }
            return idObra;
        }
        /// <summary>
        /// Obtención del Id del Tipo de Colaborador. Se busca por la Descripciñon del Tipo de Colaborador.
        /// </summary>
        /// <param name="descripcion_tcol"></param>
        /// <returns></returns>
        public int ObtenerIdTipoColaborador(string descripcion_tcol)
        {
            conn.Open();
            int idTipoColaborador = 0;
            try
            {
                NpgsqlCommand command = new NpgsqlCommand("select id_tcol from tb_tipocolaborador where descripcion_tcol='" + descripcion_tcol+ "'", conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                     idTipoColaborador= Convert.ToInt32(dr[0].ToString().Trim());

                conn.Close();
            }
            catch (Exception)
            {
                idTipoColaborador = 0;
            }
            return idTipoColaborador;
        }
        /// <summary>
        /// Obtención del Id de Lugar. Se Buscar por el Nombre del Lugar.
        /// </summary>
        /// <param name="nombre_lug"></param>
        /// <returns></returns>
        public int ObtenerIdLugar(string nombre_lug)
        {
            int idLugar = 0;
            try
            {
                NpgsqlCommand command = new NpgsqlCommand("select id_lug from tb_lugar where nombre_lug='" + nombre_lug + "'", conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                    idLugar = Convert.ToInt32(dr[0].ToString().Trim());

                conn.Close();
            }
            catch (Exception)
            {
                idLugar = 0;
            }
            return idLugar;
        }
        #endregion

        #region Métodos Varios
        /// <summary>
        /// Método para realizar la Autenticación de Usuario.
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="clave"></param>
        /// <returns></returns>
        public Boolean ComprobarUsuario(string usuario, string clave)
        {
            Boolean sw = false;
            try
            {
                foreach (var item in lstUsuarios)
                {
                    if (usuario.Trim() == item.Nombre_Usuario.Trim() && clave.Trim() == item.Contrasenia.Trim())
                    {
                        sw = true;
                    }
                    else
                    {
                        sw = false;
                    }
                }
            }
            catch (Exception)
            {
                sw = false;
            }
            return sw;
        }
        /// <summary>
        /// Método para obtener el nombre de la foto (Galeria Android) a partir del Path 
        /// </summary>
        /// <param name="pathFoto"></param>
        /// <returns></returns>
        public string ObtenerNombrePathFoto(string pathFoto)
        {
            var aux = pathFoto.Split('/');
            return aux[aux.Length-1];
        }
        #endregion
    }
}