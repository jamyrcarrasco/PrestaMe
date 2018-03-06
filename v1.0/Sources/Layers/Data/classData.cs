#region    CopyRight 

#endregion CopyRight 


#region    Uso e invocacion de librerias de Clases

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using PrestaMe.Layers.Application;

#endregion Uso e invocacion de librerias de Clases


#region    Logica de la Clase, Segun NameSpace especificado

namespace PrestaMe.Layers.Data
{

    #region    Clase Global, Contenedora de los Procedimientos, Funciones, Eventos y Propiedades de la Aplicación

    public static class classData
    {


        #region     Variable publica de conexion, que recibe el conexion string de la funcion connectionString()

        // Variable publica de conexion, que recibe el conexion string de la funcion connectionString()
        public static SqlConnection sqlConnection = new SqlConnection(connectionString());

        #endregion  Variable publica de conexion, que recibe el conexion string de la funcion connectionString()


        #region     Funcion que devuelve la connectionString de la base de datos por defecto seleccionada en el appConfig.xml

        /// <summary>
        /// Funcion que devuelve la connectionString de la base de datos por defecto seleccionada en el appConfig.xml
        /// </summary>
        /// <param name="stringParametroConexion">atributo en donde se encuentra el connectionString</param>
        /// <returns>connectionString de la base de datos por defecto</returns>
        public static string connectionString(string stringParametroConexion = "connectionString")
        {
            //Conseguir base de datos por defecto que ha sido guardada en el appConfig.xml
            string stringDefaultBaseDeDatos = classApplication.buscarNodo("appConfig.xml", "defaultBaseDeDatos", "default");

            //Retorna el connectionString de la base de datos por defecto
            return classApplication.buscarNodo("appConfig.xml", stringDefaultBaseDeDatos, stringParametroConexion);
        }

        #endregion  Funcion que devuelve la connectionString de la base de datos por defecto seleccionada en el appConfig.xml


        #region     Procedimiento que permite ejecutar consultas tipo insert, delete y update

        /// <summary>
        /// Procedimiento que permite ejecutar consultas tipo insert, delete y update
        /// </summary>
        /// <param name="stringParametroSqlQuery">Query de la consulta</param>
        /// <param name="listSqlParameter">Parametros de la consulta</param>
        /// <param name="enumTipoComando">Opcional. Tipo de comando</param>
        public static void ejecutarSqlCommand(string stringParametroSqlQuery, List<SqlParameter> listSqlParameter = null, CommandType enumTipoComando = CommandType.Text)
        {

            //Si la conexion no esta abierta, abrela
            if (sqlConnection.State != ConnectionState.Open)
            {

                sqlConnection.Open();
            }

            //Comando de sql, con query y conexion seleccionada
            SqlCommand sqlCommand = new SqlCommand(stringParametroSqlQuery, sqlConnection);

            try
            {

                //sqlCommand.CommandText = stringParametroSqlQuery;

                //Selecciona el tipo de comando. Si fue especificado otro que no sea Text, cambialo a StoredProcedure
                sqlCommand.CommandType = enumTipoComando == CommandType.Text ? CommandType.Text : CommandType.StoredProcedure;

                //Solo agrega parametros si el tipo de comando es diferente de texto y la lista de parametros es mayor que 0
                if (enumTipoComando != CommandType.Text && listSqlParameter.Count > 0)
                {
                    foreach (SqlParameter sqlparametro in listSqlParameter)
                    {
                        sqlCommand.Parameters.Add(sqlparametro);
                    }
                }
            }
            catch (Exception excepcion)
            {
                //Manejo de excepciones
                throw new Exception(excepcion.Message);
            }
            finally
            {
                //Cerrar el sqlcommand y la conexion
                sqlConnection.Close();
                sqlCommand.Dispose();
            }
        }

        #endregion  Procedimiento que permite ejecutar consultas tipo insert, delete y update


        #region     Funcion que permite ejecutar consultas con el SqlDataReader

        /// <summary>
        /// Funcion que permite ejecutar consultas con el SqlDataReader
        /// </summary>
        /// <param name="stringParametroSqlQuery">Query de la consulta</param>
        /// <param name="listSqlParameter">Parametros de consulta</param>
        /// <param name="enumTipoComando">Opcional. Tipo de comando</param>
        /// <returns></returns>
        public static SqlDataReader conseguirSqlDataReader(string stringParametroSqlQuery, List<SqlParameter> listSqlParameter = null, CommandType enumTipoComando = CommandType.Text)
        {
            //Si la conexion no esta abierta, abrela
            if (sqlConnection.State != ConnectionState.Open)
            {

                sqlConnection.Open();
            }

            //sqlCommand con el query y la conexion
            SqlCommand sqlCommand = new SqlCommand(stringParametroSqlQuery, sqlConnection);

            //Tipo de comando segun el especificado
            sqlCommand.CommandType = enumTipoComando == CommandType.Text ? CommandType.Text : CommandType.StoredProcedure;

            //DataReader que se usara para retornar la consulta
            SqlDataReader sqlDataReader;

            try
            {
                //Si la lista de parametros no esta nula, añade los parametros al sqlcommand
                if (listSqlParameter != null)
                {
                    foreach (SqlParameter sqlParametro in listSqlParameter)
                    {
                        sqlCommand.Parameters.Add(sqlParametro);
                    }
                }

                //Ejecuta el comando en el sqldataReader
                sqlDataReader = sqlCommand.ExecuteReader();
            }
            catch (Exception exception)
            {
                //Manejo de excepciones y errores
                throw new Exception(exception.Message);
            }
            finally
            {
                //Cierra la conexion y el commando
                sqlConnection.Close();
                sqlCommand.Dispose();
            }

            //Retorna el dataReader con la consulta realizada
            return sqlDataReader;
        }

        #endregion  Funcion que permite ejecutar consultas con el SqlDataReader


        #region     Funcion que permite ejecutar una consulta dentro de un datatable

        /// <summary>
        /// Funcion que permite ejecutar una consulta dentro de un datatable
        /// </summary>
        /// <param name="stringParametroSqlQuery">Query de la consulta</param>
        /// <param name="listSqlParameter">parametros de consulta</param>
        /// <param name="enumTipoComando">Opcional. Tipo de comando</param>
        /// <returns></returns>
        public static DataTable conseguirDataTable(string stringParametroSqlQuery, List<SqlParameter> listSqlParameter = null, CommandType enumTipoComando = CommandType.Text)
        {

            //Si la conexion no esta abierta, abrela
            if (sqlConnection.State != ConnectionState.Open)
            {

                sqlConnection.Open();
            }

            //DataAdapter y DataTable que se usaran para la consulta
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataTable dataTableConsulta = new DataTable();

            try
            {

                //Crear el comando del dataAdapter
                sqlDataAdapter.SelectCommand = new SqlCommand(stringParametroSqlQuery, sqlConnection);

                //Seleccionar el tipo de comando del dataAdapter
                sqlDataAdapter.SelectCommand.CommandType = enumTipoComando == CommandType.Text ? CommandType.Text : CommandType.StoredProcedure;

                //Añadir parametros si la lista no esta nula
                if (listSqlParameter != null)
                {
                    foreach (SqlParameter sqlParametro in listSqlParameter)
                    {
                        sqlDataAdapter.SelectCommand.Parameters.Add(sqlParametro);
                    }
                }

                //Llenar el DataTable con el dataAdapter
                sqlDataAdapter.Fill(dataTableConsulta);
            }
            catch (Exception exception)
            {
                //Manejo de errores y excepciones
                throw new Exception(exception.Message);
            }
            finally
            {
                //Cerrar el dataAdapter y la conexion
                sqlDataAdapter.Dispose();
                sqlConnection.Close();
            }

            //Retornar el DataTable con la consulta
            return dataTableConsulta;

        }

        #endregion  Funcion que permite ejecutar una consulta dentro de un datatable


        #region     Funcion que permite ejecutar una consulta usando un DataSet

        /// <summary>
        /// Funcion que permite ejecutar una consulta usando un DataSet
        /// </summary>
        /// <param name="stringParametroSqlQuery">Query de la consulta</param>
        /// <param name="listSqlParameter">Parametros de la consulta</param>
        /// <param name="enumTipoComando">Opcional. Tipo de parametro</param>
        /// <returns></returns>
        public static DataSet conseguirDataSet(string stringParametroSqlQuery, List<SqlParameter> listSqlParameter = null, CommandType enumTipoComando = CommandType.Text)
        {

            //Abrir conexion si esta no esta abierta
            if (sqlConnection.State != ConnectionState.Open)
            {

                sqlConnection.Open();
            }

            //DataSet y DataAdapter de la consulta
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataSet dataSet = new DataSet();

            try
            {

                //Crear comando del dataAdapter con la conexion y el query
                sqlDataAdapter.SelectCommand = new SqlCommand(stringParametroSqlQuery, sqlConnection);

                //Seleccionar el tipo de comando
                sqlDataAdapter.SelectCommand.CommandType = enumTipoComando == CommandType.Text ? CommandType.Text : CommandType.StoredProcedure;

                //Llenar el comando con la lista de parametros si la lista no esta null
                if (listSqlParameter != null)
                {
                    foreach (SqlParameter sqlParametro in listSqlParameter)
                    {
                        sqlDataAdapter.SelectCommand.Parameters.Add(sqlParametro);
                    }
                }

                //Llenar el dataSet con el dataAdapter
                sqlDataAdapter.Fill(dataSet);
            }
            catch (Exception exception)
            {

                //Manejo de errores y excepciones
                throw new Exception(exception.Message);
            }
            finally
            {

                //Cerrar dataAdapter y conexion
                sqlDataAdapter.Dispose();
                sqlConnection.Close();
            }

            //Retorna dataset con la consulta realizada
            return dataSet;
        }

        #endregion  Funcion que permite ejecutar una consulta usando un DataSet


    }

    #endregion Clase Global, Contenedora de los Procedimientos, Funciones, Eventos y Propiedades de la Aplicación
}

#endregion    Logica de la Clase, Segun NameSpace especificado
