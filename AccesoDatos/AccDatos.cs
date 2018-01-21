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

        #region Inserciones en la Base de Datos   
        /// <summary>
        /// Método para la inserciòn de una Casa Salesiana.
        /// </summary>
        /// <param name="casa"></param>
        /// <returns></returns>
        public Boolean InsertCasaSalesiana(CasaSalesiana casa)
        {
            conn.Open();
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
            conn.Open();
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
            conn.Open();
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
            lugar.coordenada_lug = "0104000020E610000001000000010100000074905603948753C025116D09F10FD63F";
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("insert into tb_lugar(id_obr,id_elug,nombre_lug,descripcion_lug,responsable_lug,direccion_lug,telefono_lug,coordenada_lug,estado_lug) values('" + lugar.id_obr + "','" + lugar.id_elug + "','" + lugar.nombre_lug + "','" + lugar.descripcion_lug+ "','" + lugar.responsable_lug+ "','" + lugar.direccion_lug+ "','" + lugar.telefono_lug+ "','" + lugar.coordenada_lug+ "','" + lugar.estado_lug+ "')", conn);
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
            bene.areainfluencia_ben = "0103000020E61000000100000082000000E6577380607553C04A7CEE04FBAFA33FCFD90242EB7553C06FBA6587F8879D3F0B60CAC0017653C09A7B48F8DEDF903F4301DBC1887653C022FAB5F5D37F763FCB85CABF967753C0D3F544D7851F7CBF774EB340BB7853C09A7B48F8DEDF90BF9A232BBF0C7A53C0973C9E961FB89ABF0A664CC11A7B53C07C9C69C2F693A1BFF699B33EE57B53C02BFBAE08FEB7AABF1EC3633F8B7B53C08F8CD5E6FF55B3BF46EC1340317B53C0FFCBB56801DAB6BFBA13ECBFCE7B53C0A12B11A8FE41B8BF8E058541997C53C0E63BF88903E8B7BFDA03ADC0907D53C0700B96EA025EBABFEA7B0DC1717E53C03EEB1A2D077ABCBFF9F36DC1527F53C0F9DA334B02D4BCBFE527D53E1D8053C0B4CA4C69FD2DBDBF7D93A641D18053C028452BF702B3C0BFCD76853E588153C0F9F4D8960167C1BF65E256410C8253C0D76CE525FF93C1BFB1E07EC0038353C09B5434D6FECEC2BF25085740A18353C031EC3026FDBDC4BF982F2FC03E8453C00C9414580053C6BF0C570740DC8453C0BABBCE86FC33C7BFE048A0C1A68553C0C4B304190115C8BF2C47C8409E8653C0BABBCE86FC33C7BF187B2FBE688753C00C9414580053C6BF28F38FBE498853C0185C7347FFCBC5BFC05E61C1FD8853C03BE466B8019FC5BF0B5D8940F58953C0E90B21E7FD7FC6BFDF4E22C2BF8A53C0C7832D76FBACC6BF7F8461C0928A53C0DD43C2F7FE06C7BF6BF46A80D28A53C0FFCBB56801DAC6BF1AA20A7F868B53C066136058FE7CC9BF16BD5301F78B53C06FBA6587F887CDBFB6F292FFC98B53C01B12F758FAD0CFBFF2785A7EE08B53C0B64C86E3F90CD1BF2F6EA301BC8A53C0C710001C7BF6D0BF0F7EE200FA8853C0F0FCA204FD85D0BF9F3BC1FEEB8753C0B64C86E3F90CD1BF7B6649809A8653C0DE3829CC7B9CD0BFF8C610001C8553C0DE3829CC7B9CD0BF48197101688453C079B29B19FD68CEBF9C508880438353C00725CCB4FD2BD0BF2C0E677E358253C0E998F38C7DC9D0BF6803B001118153C0D270CADC7C23D1BF5D70067FBF7F53C0D270CADC7C23D1BF4DF8A57EDE7E53C0A320787C7BD7D1BF4913EF004F7F53C039B874CC79C6D3BFC1525DC0CB7E53C02CF015DD7A4DD4BF52103CBEBD7D53C050E09D7C7A6CD3BF8E058541997C53C044183F8D7BF3D3BF56647440127C53C0D5B32094F771D5BF328FFCC1C07A53C082734694F606D7BFAEEFC341427953C05987A3AB7477D7BFF3AE7AC03C7753C06A4B1DE4F560D7BF9738F240647553C035971B0C7558D8BFD712F241CF7353C00DAB7823F3C8D8BF5858703FE07153C0FBE6FEEA71DFD8BF9C1727BEDA6F53C0F5824F73F222D9BF7842AF3F896E53C0CC96AC8A7093D9BF2C4487C0916D53C0B306EFAB72A1DABFA9A44E40136C53C07A56D28A6F28DBBFC53A55BE676A53C07A56D28A6F28DBBF91ED7C3F356853C06D8E739B70AFDBBFFAF02C41466653C01CB62DCA6C90DCBF12A27C410B6553C00FEECEDA6D17DDBF060FD3BEB96353C0CFD90242EBE1DDBF6F1283C0CA6153C084656CE8667FDEBFB3D1393FC55F53C07E01BD70E7C2DEBF575BB1BFEC5D53C071395E81E849DFBFD4BB783F6E5C53C04FB16A10E676DFBF501C40BFEF5A53C0C97553CA6B25DEBFA453573ECB5953C044A2D0B2EE1FDCBFBC04A73E905853C097E2AAB2EF8ADABFF8F9EFC16B5753C0A8A624EB7074DABF29ED0DBE305653C0BA6A9E23F25DDABF4D310741475653C035971B0C7558D8BFB5C5353E935553C048C32973F38DD7BF2D414640855453C09337C0CC77F0D6BF0D51853FC35253C0A663CE33F625D6BF9544F641965253C03354C554FA09D4BF61889CBE9E5153C06808C72C7B12D3BFD5AF743E3C5253C0B64C86E3F90CD1BF5DA3E5400F5253C0C092AB58FCA6CCBFA9A10DC0065353C02BFBAE08FEB7CABFB9196EC0E75353C08B6B7C26FBE7C7BF69C70DBF9B5453C0F6D37FD6FCF8C5BFF59F353FFE5353C0B4E4F1B4FCC0C1BFA9A10DC0065353C0B4CA4C69FD2DBDBF594FADBEBA5353C0D49CBCC804FCB2BF419E5DBEF55453C0D34B8C65FA25B6BFB5C5353E935553C0448B6CE7FBA9B9BFED66463F1A5653C09B3A8F8AFF3BBEBF85D21742CE5653C006BD378600E0C0BFD0D03FC1C55753C0B4E4F1B4FCC0C1BF68CD8FBFB45953C0E3344415FE0CC1BF9C1A683EE75B53C0F0FCA204FD85C0BFAB92C83EC85C53C0F88903E8F7FDBFBF8369183E225D53C075ABE7A4F78DB7BF6F0C01C0B15C53C0BB0CFFE9060AB4BFAB92C83EC85C53C0B51B7DCC0704AABF7F8461C0925D53C090DD054A0A2CA0BFCB82893F8A5E53C05B79C9FFE4EF8EBF8BA8893E1F6053C05B79C9FFE4EF9EBFFBEAAA402D6153C05C1B2AC6F99BA8BF43041C42956253C04BCD1E680586B0BFA25F5B3FFD6353C04A7CEE04FBAFB3BF7651F4C0C76453C0FFCBB56801DAB6BF12A27C410B6553C0A12B11A8FE41B8BFAEF204C24E6553C0448B6CE7FBA9B9BF221ADD41EC6553C0448B6CE7FBA9B9BFD2C77C40A06653C044DC9C4A0680B6BFF59CF4BEF16753C04A7CEE04FBAFB3BF793C2D3F706953C08F8CD5E6FF55B3BF71033E3F8C6B53C0ECDB4944F817B5BFB91CAF40F46C53C08F8CD5E6FF55B3BF40A19E3E026E53C051DB8651103CAEBFD80C7041B66E53C0B51B7DCC0704AABFB0E3BF40106F53C0DA3C0E83F92BB0BF60915F3FC46F53C0A81C93C5FD47B2BF983270404B7053C031EC3026FDBDB4BF44FB58C16F7153C076FC17080264B4BF302FC03E3A7253C02BFBAE08FEB7AABF0806103E947253C022FAB5F5D37F86BFB82231410D7253C022FAB5F5D37F763FCC7F48BF7D7253C09A7B48F8DEDF903F9F71E140487353C0FA7C94111780963F4B3ACAC16C7453C006BD378600E0A03FE6577380607553C04A7CEE04FBAFA33E";
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
                    lstCasasSalesianas.Add(dr[0].ToString());
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
                    user.Nombre_Usuario = dr[0].ToString();
                    user.Contrasenia = dr[01].ToString();
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
                    lstTipoObras.Add(dr[0].ToString());
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
                    lstObras.Add(dr[0].ToString());
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
                    lstLugar.Add(dr[0].ToString());
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
                    lstColaborador.Add(dr[0].ToString());
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
                    idCasa =Convert.ToInt32(dr[0].ToString());

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
                    idTipo = Convert.ToInt32(dr[0].ToString());

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
            conn.Open();
            int idObra = 0;
            try
            {
                NpgsqlCommand command = new NpgsqlCommand("select id_obr from tb_obrasalesiana where denominacion_obr='" + denominacion + "'", conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                    idObra= Convert.ToInt32(dr[0].ToString());

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
                     idTipoColaborador= Convert.ToInt32(dr[0].ToString());

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
                    idLugar = Convert.ToInt32(dr[0].ToString());

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