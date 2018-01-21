using AccesoDatos.Entidades;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    /// <summary>
    /// Clase en donde se realizan las diversas transacciones con la base de datos. Obtención de Listas Tipo  Objeto.
    /// </summary>
    public class AccDatosObjects
    {
        #region Conexión Base de Datos - Inicio Componentes Varios      
        string connstring = null;
        private static NpgsqlConnection conn = null;
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

        #region Consultas Listas Tipo Objeto   
        /// <summary>
        /// Método para obtener la Lista Tipo Objeto de Beneficiarios
        /// </summary>
        /// <returns></returns>
        public List<Beneficiario> ObtenerListaBeneficiarios()
        {
            List<Beneficiario> lst = new List<Beneficiario>();
            try
            {
                NpgsqlCommand command = new NpgsqlCommand("select descripcion_eben,nombre_lug,descripcion_ben,numero_ben from tb_beneficiario b,tb_estilobeneficiario e,tb_lugar l where b.id_lug = l.id_lug and b.id_eben = e.id_eben order by b.id_ben desc", conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    Beneficiario obj = new Beneficiario
                    {
                        desc_eben = dr[0].ToString(),
                        desc_lug = dr[1].ToString(),
                        descripcion_ben = dr[2].ToString(),
                        numero_ben = Convert.ToInt32(dr[3].ToString())
                    };
                    lst.Add(obj);
                }
                conn.Close();
            }
            catch (Exception)
            {
                lst = null;
            }
            return lst;
        }
        /// <summary>
        /// Método para obtener la Lista Tipo Objeto de Casa Salesiana
        /// </summary>
        /// <returns></returns>
        public List<CasaSalesiana> ObtenerListaCasaSalesiana()
        {
            List<CasaSalesiana> lst = new List<CasaSalesiana>();
            try
            {
                NpgsqlCommand command = new NpgsqlCommand("select * from tb_casasalesiana order by id_cas desc", conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    CasaSalesiana obj = new CasaSalesiana
                    {
                        nombre_cas = dr[1].ToString(),
                        direccion_cas = dr[2].ToString(),
                        telefono_cas = dr[3].ToString(),
                        correo_cas = dr[4].ToString(),
                        director_cas = dr[5].ToString(),
                        pathicono_cas = dr[6].ToString(),
                        nombrecorto_cas = dr[7].ToString()
                    };
                    lst.Add(obj);
                }
                conn.Close();
            }
            catch (Exception)
            {
                lst = null;
            }
            return lst;
        }
        /// <summary>
        /// Método para obtener la Lista Tipo Objeto de Colaboradores
        /// </summary>
        /// <returns></returns>
        public List<Colaborador> ObtenerListaColaboradores()
        {
            List<Colaborador> lst = new List<Colaborador>();
            try
            {
                NpgsqlCommand command = new NpgsqlCommand("select nombre_lug,descripcion_tcol,numero_col from tb_lugar l,tb_colaborador c, tb_tipocolaborador t where l.id_lug = c.id_lug and t.id_tcol = c.id_tcol order by c.id_col desc", conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    Colaborador obj = new Colaborador
                    {
                        desc_lug = dr[0].ToString(),
                        desc_tcol = dr[1].ToString(),
                        numero_col = Convert.ToInt32(dr[2].ToString())
                    };
                    lst.Add(obj);
                }
                conn.Close();
            }
            catch (Exception)
            {
                lst = null;
            }
            return lst;
        }
        /// <summary>
        /// Método para obtener la Lista Tipo Objeto de Foto Lugar
        /// </summary>
        /// <returns></returns>
        public List<FotoLugar> ObtenerListaFotoLugar()
        {
            List<FotoLugar> lst = new List<FotoLugar>();
            try
            {
                NpgsqlCommand command = new NpgsqlCommand("select nombre_lug,descripcion_flug,pathfoto_flug from tb_lugar l,tb_fotolugar f where f.id_lug=l.id_lug order by f.id_flug desc", conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    FotoLugar obj = new FotoLugar
                    {
                        desc_lug = dr[0].ToString(),
                        descripcion_flug = dr[1].ToString(),
                        pathfoto_flug = dr[2].ToString()
                    };
                    lst.Add(obj);
                }
                conn.Close();
            }
            catch (Exception)
            {
                lst = null;
            }
            return lst;
        }
        /// <summary>
        /// Método para obtener la Lista Tipo Objeto de Lugar
        /// </summary>
        /// <returns></returns>
        public List<Lugar> ObtenerListaLugar()
        {
            List<Lugar> lst = new List<Lugar>();
            try
            {
                NpgsqlCommand command = new NpgsqlCommand("select nombre_lug,denominacion_obr,descripcion_elug,descripcion_lug,responsable_lug,direccion_lug,telefono_lug from tb_lugar l, tb_obrasalesiana o,tb_estilolugar e where l.id_obr=o.id_obr and l.id_elug= e.id_elug order by l.id_lug desc", conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    Lugar obj = new Lugar
                    {
                        nombre_lug = dr[0].ToString(),
                        desc_obr = dr[1].ToString(),
                        desc_elug = dr[2].ToString(),
                        descripcion_lug = dr[3].ToString(),
                        responsable_lug = dr[4].ToString(),
                        direccion_lug = dr[5].ToString(),
                        telefono_lug = dr[6].ToString(),
                    };
                    lst.Add(obj);
                }
                conn.Close();
            }
            catch (Exception)
            {
                lst = null;
            }
            return lst;
        }
        /// <summary>
        /// Método para obtener la Lista Tipo Objeto de Obra Salesiana
        /// </summary>
        /// <returns></returns>
        public List<ObraSalesiana> ObtenerObraSalesiana()
        {
            List<ObraSalesiana> lst = new List<ObraSalesiana>();
            try
            {
                NpgsqlCommand command = new NpgsqlCommand("select descripcion_tobr,nombre_cas,denominacion_obr,camposervicio_obr,productos_obr,horario_obr,informacion_obr,pathicono_obr,nombrecorto_obr,paginaweb_obr from tb_tipoobra t, tb_obrasalesiana o, tb_casasalesiana c where t.id_tobr = o.id_tobr and c.id_cas = o.id_cas order by o.id_obr desc", conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    ObraSalesiana obj = new ObraSalesiana
                    {
                        desc_tobr = dr[0].ToString(),
                        desc_cas = dr[1].ToString(),
                        denominacion_obr = dr[2].ToString(),
                        camposervicio_obr = dr[3].ToString(),
                        productos_obr = dr[4].ToString(),
                        horario_obr = dr[5].ToString(),
                        informacion_obr = dr[6].ToString(),
                        pathicono_obr = dr[7].ToString(),
                        nombrecorto_obr = dr[8].ToString(),
                        paginaweb_obr = dr[9].ToString()
                    };
                    lst.Add(obj);
                }
                conn.Close();
            }
            catch (Exception)
            {
                lst = null;
            }
            return lst;
        }
        /// <summary>
        /// Método para obtener la Lista Tipo Objeto de Tipo Obra Salesiana
        /// </summary>
        /// <returns></returns>
        public List<TipoObraSalesiana> ObtenerTipoObraObj()
        {
            List<TipoObraSalesiana> lst = new List<TipoObraSalesiana>();
            try
            {
                NpgsqlCommand command = new NpgsqlCommand("select * from tb_tipoobra order by id_tobr desc", conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    TipoObraSalesiana obj = new TipoObraSalesiana
                    {
                        Descripcion_tobr = dr[1].ToString(),
                        PathIcono_tobr = dr[2].ToString()
                    };
                    lst.Add(obj);
                }
                conn.Close();
            }
            catch (Exception)
            {
                lst = null;
            }
            return lst;
        }
        #endregion
    }
}

