using AccesoDatos.Entidades;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class AccDatosObjects
    {
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
        #region Conexión Base de Datos       
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
        public List<Beneficiario> ObtenerListaUsuarios()
        {
            List<Beneficiario> lst = new List<Beneficiario>();
            try
            {
                NpgsqlCommand command = new NpgsqlCommand("select * from tb_beneficiario", conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    Beneficiario obj = new Beneficiario();
                    
                }
                conn.Close();
            }
            catch (Exception)
            {
                lst = null;
            }
            return lst;
        }

    }
}
