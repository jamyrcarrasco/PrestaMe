#region     CopyRight

#endregion  CopyRight


#region     Uso e Invocación de Librerias de Clase a Ser Utilizadas

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml;
using System.IO;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;

#endregion  Uso e Invocación de Librerias de Clase a Ser Utilizadas


#region     Logica de la Clase, Segun NameSpace especificado

namespace PrestaMe.Layers.Application
{

    #region     Clase Global, Contenedora de los Procedimientos, Funciones, Eventos y Propiedades de la Aplicación

    /// <summary>
    /// Clase Contenedora de los Procedimientos,Funciones, Eventos y Propiedades de la Aplicación
    /// </summary>
    public static class classApplication
    {


        #region     Variables, Constantes, Propiedades y Declaraciones Adicionales con Sus Respectivos Ambitos y Alcances


        //Declaracion de las Propiedades con sus respectivos metodos GET & SET
        public static int? intIdCia { get; set; }
        public static int? intIdSucursal { get; set; }
        public static int? intIdUsuario { get; set; }
        public static string stringIdRegistro { get; set; }
        public static string stringOperacion { get; set; }
        public static string stringCompañia { get; set; }
        public static string stringSucursal { get; set; }
        public static string stringUsuario { get; set; }
        public static string stringNombreLogin { get; set; }
        public static string stringRolUsuario { get; set; }

        // Variables en las que se almacenan las rutas en las que se encuentran los diferentes tipos de archivos
        public static string stringRutaArchivoXML = string.Empty;
        public static string stringRutaArchivosReportes = string.Empty;
        public static string stringRutaArchivosImagenes = string.Empty;
        public static string stringRutaArchivosDocumentos = string.Empty;
        public static string stringRutaArchivosIconos = string.Empty;
        public static string stringRutaArchivosScripts = string.Empty;

        // Variable en la que se almacena el directorio base de la aplicacion
        public static string stringDirectorioBase = directorioBaseAplicacion();

        // Enumeracion en la que se encuentran los tipos de encriptacion usados en la aplicacion
        public enum tipoHash : int 
        {

            MD5,
            SHA1,
            SHA128,
            SHA256,
            SHA384,
            SHA512,
            SHA634
        }

        #endregion Variables, Constantes, Propiedades y Declaraciones Adicionales con Sus Respectivos Ambitos y Alcances


        #region    Determinar y Retornar el Directorio Base de la Aplicacion

        /// <summary>
        /// Determinar y Retornar el Directorio Base de la Aplicacion
        /// </summary>
        /// <returns>Retorna el Directorio Base de la Aplicacion</returns>
        public static string directorioBaseAplicacion()
        {

            if (AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin") > 0)
            {

                stringDirectorioBase = AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin"));
            }
            else
            {

                stringDirectorioBase = AppDomain.CurrentDomain.BaseDirectory.ToString();
            }
            return stringDirectorioBase;
        }

        #endregion Determinar y Retornar el Directorio Base de la Aplicacion


        #region    Verificacion de los Registros Basicos por Defecto de la Aplicacion

        /// <summary>
        /// Verificacion de los Registros Basicos por defecto de la Aplicacion
        /// </summary>
        public static void verificarDataInicial()
        {
            if (intIdCia == null || intIdCia == 0)
            {
                intIdCia = -1;
            }
            if (intIdSucursal == null || intIdSucursal == 0)
            {
                intIdSucursal = -1;
            }
            if (intIdUsuario == null || intIdUsuario == 0)
            {
                intIdUsuario = -1;
            }
            if (stringIdRegistro.ToString().Trim() == string.Empty)
            {
                stringIdRegistro = string.Empty;
            }
            if (stringOperacion.ToString().Trim() == string.Empty)
            {
                stringOperacion = string.Empty;
            }
            if (stringCompañia.ToString().Trim() == string.Empty)
            {
                stringCompañia = string.Empty;
            }
            if (stringUsuario.ToString().Trim() == string.Empty)
            {
                stringUsuario = string.Empty;
            }
            if (stringNombreLogin.ToString().Trim() == string.Empty)
            {
                stringNombreLogin = string.Empty;
            }
            if (stringRolUsuario.ToString().Trim() == string.Empty)
            {
                stringRolUsuario = string.Empty;
            }
            if (stringRutaArchivoXML.ToString().Trim() == string.Empty)
            {
                stringRutaArchivoXML = buscarNodo("appConfig.xml", "carpeta", "xml");
            }
            if (stringRutaArchivosImagenes.ToString().Trim() == string.Empty)
            {
                stringRutaArchivosImagenes = buscarNodo("appConfig.xml", "carpeta", "imagenes");
            }
            if (stringRutaArchivosDocumentos.ToString().Trim() == string.Empty)
            {
                stringRutaArchivosDocumentos = buscarNodo("appConfig.xml", "carpeta", "documentos");
            }
            if (stringRutaArchivosReportes.ToString().Trim() == string.Empty)
            {
                stringRutaArchivosReportes = buscarNodo("appConfig.xml", "carpeta", "reportes");
            }
            if (stringRutaArchivosIconos.ToString().Trim() == string.Empty)
            {
                stringRutaArchivosIconos = buscarNodo("appConfig.xml", "carpeta", "iconos");
            }
            if (stringRutaArchivosScripts.ToString().Trim() == string.Empty)
            {
                stringRutaArchivosScripts = buscarNodo("appConfig.xml", "carpeta", "scripts");
            }

        }

        #endregion Verificacion de los Registros Basicos por Defecto de la Aplicacion


        #region     Configuracion de los Registros Basicos por Defecto de la Aplicacion

        /// <summary>
        /// Configuracion de los Registros Basicos por Defecto de las Principales Tablas de la Aplicacion
        /// </summary>
        public static void configurarDataInicial()
        {
            intIdCia = -1;
            intIdSucursal = -1;
            intIdUsuario = -1;

            stringIdRegistro = string.Empty;
            stringOperacion = string.Empty;

            stringCompañia = string.Empty;
            stringSucursal = string.Empty;

            stringUsuario = string.Empty;
            stringNombreLogin = string.Empty;
            stringRolUsuario = string.Empty;

            stringRutaArchivoXML = buscarNodo("appConfig.xml", "carpeta", "xml");
            stringRutaArchivosImagenes = buscarNodo("appConfig.xml", "carpeta", "imagenes");
            stringRutaArchivosDocumentos = buscarNodo("appConfig.xml", "carpeta", "documentos");
            stringRutaArchivosReportes = buscarNodo("appConfig.xml", "carpeta", "reportes");
            stringRutaArchivosIconos = buscarNodo("appConfig.xml", "carpeta", "iconos");
            stringRutaArchivosScripts = buscarNodo("appConfig.xml", "carpeta", "scripts");
        }

        #endregion  Configuracion de los Registros Basicos por Defecto de la Aplicacion


        #region     Verificacion de los Archivos XML appConfig y appError Respectivamente

        /// <summary>
        /// Verificacion de los Archivos XML appConfig y appError Respectivamente
        /// </summary>
        /// <param name="stringParametroArchivoXML">Archivo XML que se desea buscar</param>
        public static void verificarArchivosXMLAplicacion(string stringParametroArchivoXML = @"xml\appConfig.xml")
        {
            try
            {
                // Verificar si el archivo XML existe en la carpeta correspondiente
                if (File.Exists(stringDirectorioBase + stringParametroArchivoXML) == false)
                {

                    crearArchivoXMLAplicacion(stringParametroArchivoXML);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Target Site: {ex.TargetSite.ToString()}/n Source: {ex.Source.ToString()}/n Message:{ex.Message.ToString()}");

            }
        }


        #endregion  Verificacion de los Archivos XML appConfig y appError Respectivamente


        #region     Creacion de los Archivos XML appConfig y appError Respectivamente

        /// <summary>
        /// Creacion de los archivos XML appConfig y appError Respectivamente
        /// De crear el appMessage y appIdioms utitizar un Switch o no
        /// </summary>
        /// <param name="stringParametroArchivoXML">Nombre del archivo XML a Crear</param>
        public static void crearArchivoXMLAplicacion(string stringParametroArchivoXML = @"xml\appConfig.xml")
        {
            // Instancia del objeto XMLTextWrite para creacion de los XML
            XmlTextWriter xmlTextWriter = new XmlTextWriter(directorioBaseAplicacion() + stringParametroArchivoXML, Encoding.UTF8);

            try
            {
                //Darle formato a el XML
                xmlTextWriter.Formatting = Formatting.Indented;

                //No especificar la version de XML usada en el archivo appConfig
                xmlTextWriter.WriteStartDocument(false);

                //Crea cualquier xml especificado.
                switch (stringParametroArchivoXML.ToLower())
                {
                    case "xml/appconfig.xml":
                        {
                            //Elemento Raiz del AppConfig
                            xmlTextWriter.WriteStartElement("configuration");

                            //Elemento aplicacion, en donde se guardan los datos de la aplicacion
                            xmlTextWriter.WriteStartElement("aplicacion");

                            xmlTextWriter.WriteStartElement("identificacion");
                            xmlTextWriter.WriteAttributeString("producto", FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductName);
                            xmlTextWriter.WriteAttributeString("alias", "PrestaMe");
                            xmlTextWriter.WriteAttributeString("siglas", "PM$");
                            xmlTextWriter.WriteAttributeString("tipo", ".exe");
                            xmlTextWriter.WriteAttributeString("version", FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion);
                            xmlTextWriter.WriteAttributeString("copyright", FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).LegalCopyright);
                            xmlTextWriter.WriteEndElement();

                            xmlTextWriter.WriteStartElement("entorno");
                            xmlTextWriter.WriteAttributeString("ambiente", checkearAmbienteDesarrollo());
                            xmlTextWriter.WriteAttributeString("multiCompania", "si");
                            xmlTextWriter.WriteAttributeString("multiSucursal", "si");
                            xmlTextWriter.WriteAttributeString("multiUsuario", "si");
                            xmlTextWriter.WriteAttributeString("multiMoneda", "no");
                            xmlTextWriter.WriteAttributeString("interfaz", "windows10");
                            xmlTextWriter.WriteEndElement();

                            xmlTextWriter.WriteStartElement("carpeta");
                            xmlTextWriter.WriteAttributeString("principal", "default");
                            xmlTextWriter.WriteAttributeString("imagenes", "imagenes");
                            xmlTextWriter.WriteAttributeString("iconos", "iconos");
                            xmlTextWriter.WriteAttributeString("reportes", "reportes");
                            xmlTextWriter.WriteAttributeString("documentos", "documentos");
                            xmlTextWriter.WriteAttributeString("xml", "xml");
                            xmlTextWriter.WriteAttributeString("scripts", "scripts");
                            xmlTextWriter.WriteEndElement();

                            xmlTextWriter.WriteStartElement("manejoErrores");
                            xmlTextWriter.WriteAttributeString("tipoEnvio", "XMLCorreo");
                            xmlTextWriter.WriteEndElement();

                            xmlTextWriter.WriteEndElement();

                            //Elemento Soporte, en donde se guardan los datos de contacto via email para el soporte de la aplicacion
                            xmlTextWriter.WriteStartElement("soporte");

                            xmlTextWriter.WriteStartElement("mensajeria");
                            xmlTextWriter.WriteAttributeString("emailTo", "colocarcontenidoaqui");
                            xmlTextWriter.WriteAttributeString("emailFrom", "colocarcontenidoaqui");
                            xmlTextWriter.WriteAttributeString("emailPOP3", "colocarcontenidoaqui");
                            xmlTextWriter.WriteAttributeString("emailSMTP", "colocarcontenidoaqui");
                            xmlTextWriter.WriteAttributeString("hostName", "colocarcontenidoaqui");
                            xmlTextWriter.WriteAttributeString("password", "colocarcontenidoaqui");
                            xmlTextWriter.WriteAttributeString("emailPort", "25");
                            xmlTextWriter.WriteAttributeString("emailFormat", "HTML");
                            xmlTextWriter.WriteAttributeString("emailSubject", "Correo de PrestaMe " + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion);
                            xmlTextWriter.WriteEndElement();

                            xmlTextWriter.WriteStartElement("contacto");
                            xmlTextWriter.WriteAttributeString("entidad", "InsideDev Technology");
                            xmlTextWriter.WriteAttributeString("direccion", "");
                            xmlTextWriter.WriteAttributeString("telefono", "");
                            xmlTextWriter.WriteAttributeString("correo", "insidedev.technology@gmail.com");
                            xmlTextWriter.WriteAttributeString("departamento", "");
                            xmlTextWriter.WriteAttributeString("copyright", FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).LegalCopyright);
                            xmlTextWriter.WriteEndElement();

                            xmlTextWriter.WriteEndElement();

                            //Elemento Connection String, en el que se guarda los diferentes datos de los connectionString 
                            xmlTextWriter.WriteStartElement("connectionStrings");

                            xmlTextWriter.WriteStartElement("sqlServer");
                            xmlTextWriter.WriteAttributeString("connectionString", "");
                            xmlTextWriter.WriteAttributeString("nombreServidor", "");
                            xmlTextWriter.WriteAttributeString("nombreBaseDeDatos", "");
                            xmlTextWriter.WriteAttributeString("nombreInstancia", "");
                            xmlTextWriter.WriteAttributeString("nombreUsuario", "");
                            xmlTextWriter.WriteAttributeString("passwordEncriptado", "");
                            xmlTextWriter.WriteAttributeString("autenticacionWindows", "");
                            xmlTextWriter.WriteEndElement();

                            xmlTextWriter.WriteStartElement("oracle");
                            xmlTextWriter.WriteAttributeString("connectionString", "");
                            xmlTextWriter.WriteAttributeString("nombreServidor", "");
                            xmlTextWriter.WriteAttributeString("nombreBaseDeDatos", "");
                            xmlTextWriter.WriteAttributeString("nombreInstancia", "");
                            xmlTextWriter.WriteAttributeString("nombreUsuario", "");
                            xmlTextWriter.WriteAttributeString("passwordEncriptado", "");
                            xmlTextWriter.WriteAttributeString("autenticacionWindows", "");
                            xmlTextWriter.WriteEndElement();

                            xmlTextWriter.WriteStartElement("postgreSql");
                            xmlTextWriter.WriteAttributeString("connectionString", "");
                            xmlTextWriter.WriteAttributeString("nombreServidor", "");
                            xmlTextWriter.WriteAttributeString("nombreBaseDeDatos", "");
                            xmlTextWriter.WriteAttributeString("nombreInstancia", "");
                            xmlTextWriter.WriteAttributeString("nombreUsuario", "");
                            xmlTextWriter.WriteAttributeString("passwordEncriptado", "");
                            xmlTextWriter.WriteAttributeString("autenticacionWindows", "");
                            xmlTextWriter.WriteEndElement();

                            xmlTextWriter.WriteStartElement("mySql");
                            xmlTextWriter.WriteAttributeString("connectionString", "");
                            xmlTextWriter.WriteAttributeString("nombreServidor", "");
                            xmlTextWriter.WriteAttributeString("nombreBaseDeDatos", "");
                            xmlTextWriter.WriteAttributeString("nombreInstancia", "");
                            xmlTextWriter.WriteAttributeString("nombreUsuario", "");
                            xmlTextWriter.WriteAttributeString("passwordEncriptado", "");
                            xmlTextWriter.WriteAttributeString("autenticacionWindows", "");
                            xmlTextWriter.WriteEndElement();

                            xmlTextWriter.WriteStartElement("defaultBaseDeDatos");
                            xmlTextWriter.WriteAttributeString("default", "sqlServer");
                            xmlTextWriter.WriteEndElement();

                            xmlTextWriter.WriteEndElement();

                            //Ambiente del Splash
                            xmlTextWriter.WriteStartElement("splash");

                            xmlTextWriter.WriteStartElement("formulario");
                            xmlTextWriter.WriteAttributeString("width", "640");
                            xmlTextWriter.WriteAttributeString("heigth", "462");
                            xmlTextWriter.WriteAttributeString("transparencyKey", "control");
                            xmlTextWriter.WriteAttributeString("icon", "system/PrestaMe.ico");
                            xmlTextWriter.WriteAttributeString("backgroundImage", "system/PrestaMe.JPG");
                            xmlTextWriter.WriteAttributeString("layout", "stretch");
                            xmlTextWriter.WriteAttributeString("backColor", "Control");
                            xmlTextWriter.WriteAttributeString("startPosition", "middlecenter");
                            xmlTextWriter.WriteEndElement();

                            //creacion de nodo siglas con sus respectivos atributos
                            xmlTextWriter.WriteStartElement("siglas");
                            xmlTextWriter.WriteAttributeString("autoSize", "true");
                            xmlTextWriter.WriteAttributeString("fontSize", "48");
                            xmlTextWriter.WriteAttributeString("fontBold", "true");
                            xmlTextWriter.WriteAttributeString("fontItalic", "false");
                            xmlTextWriter.WriteAttributeString("fontRegular", "false");
                            xmlTextWriter.WriteAttributeString("fontStrykeout", "false");
                            xmlTextWriter.WriteAttributeString("fontUnderline", "false");
                            xmlTextWriter.WriteAttributeString("locationX", "323");
                            xmlTextWriter.WriteAttributeString("locationY", "111");
                            xmlTextWriter.WriteAttributeString("dock", "none");
                            xmlTextWriter.WriteAttributeString("anchor", "none");
                            xmlTextWriter.WriteAttributeString("visible", "true");
                            xmlTextWriter.WriteAttributeString("foreColor", "Black");
                            xmlTextWriter.WriteAttributeString("backColor", "Transparent");
                            xmlTextWriter.WriteAttributeString("fontName", "Arial");
                            xmlTextWriter.WriteAttributeString("alignment", "middlecenter");
                            xmlTextWriter.WriteEndElement();

                            //creacion de nodo alias con sus respectivos atributos
                            xmlTextWriter.WriteStartElement("alias");
                            xmlTextWriter.WriteAttributeString("autoSize", "true");
                            xmlTextWriter.WriteAttributeString("fontSize", "48");
                            xmlTextWriter.WriteAttributeString("fontBold", "true");
                            xmlTextWriter.WriteAttributeString("fontItalic", "false");
                            xmlTextWriter.WriteAttributeString("fontRegular", "false");
                            xmlTextWriter.WriteAttributeString("fontStrykeout", "false");
                            xmlTextWriter.WriteAttributeString("fontUnderline", "false");
                            xmlTextWriter.WriteAttributeString("locationX", "323");
                            xmlTextWriter.WriteAttributeString("locationY", "111");
                            xmlTextWriter.WriteAttributeString("dock", "none");
                            xmlTextWriter.WriteAttributeString("anchor", "none");
                            xmlTextWriter.WriteAttributeString("visible", "true");
                            xmlTextWriter.WriteAttributeString("foreColor", "Black");
                            xmlTextWriter.WriteAttributeString("backColor", "Transparent");
                            xmlTextWriter.WriteAttributeString("fontName", "Arial");
                            xmlTextWriter.WriteAttributeString("alignment", "middlecenter");
                            xmlTextWriter.WriteEndElement();

                            //creacion de nodo version con sus respectivos atributos
                            xmlTextWriter.WriteStartElement("version");
                            xmlTextWriter.WriteAttributeString("autoSize", "true");
                            xmlTextWriter.WriteAttributeString("fontSize", "10");
                            xmlTextWriter.WriteAttributeString("fontBold", "true");
                            xmlTextWriter.WriteAttributeString("fontItalic", "false");
                            xmlTextWriter.WriteAttributeString("fontRegular", "false");
                            xmlTextWriter.WriteAttributeString("fontStrykeout", "false");
                            xmlTextWriter.WriteAttributeString("fontUnderline", "false");
                            xmlTextWriter.WriteAttributeString("locationX", "560");
                            xmlTextWriter.WriteAttributeString("locationY", "30");
                            xmlTextWriter.WriteAttributeString("dock", "none");
                            xmlTextWriter.WriteAttributeString("anchor", "none");
                            xmlTextWriter.WriteAttributeString("visible", "true");
                            xmlTextWriter.WriteAttributeString("foreColor", "Black");
                            xmlTextWriter.WriteAttributeString("backColor", "Transparent");
                            xmlTextWriter.WriteAttributeString("fontName", "Arial");
                            xmlTextWriter.WriteAttributeString("alignment", "middlecenter");
                            xmlTextWriter.WriteEndElement();

                            //Atributos para el nodo de Producto
                            xmlTextWriter.WriteStartElement("producto");
                            xmlTextWriter.WriteAttributeString("autoSize", "true");
                            xmlTextWriter.WriteAttributeString("fontSize", "16");
                            xmlTextWriter.WriteAttributeString("fontBold", "true");
                            xmlTextWriter.WriteAttributeString("fontItalic", "false");
                            xmlTextWriter.WriteAttributeString("fontRegular", "false");
                            xmlTextWriter.WriteAttributeString("fontStrykeout", "false");
                            xmlTextWriter.WriteAttributeString("fontUnderline", "false");
                            xmlTextWriter.WriteAttributeString("locationX", "219");
                            xmlTextWriter.WriteAttributeString("locationY", "194");
                            xmlTextWriter.WriteAttributeString("dock", "none");
                            xmlTextWriter.WriteAttributeString("anchor", "none");
                            xmlTextWriter.WriteAttributeString("visible", "true");
                            xmlTextWriter.WriteAttributeString("foreColor", "Black");
                            xmlTextWriter.WriteAttributeString("backColor", "Transparent");
                            xmlTextWriter.WriteAttributeString("fontName", "Arial");
                            xmlTextWriter.WriteAttributeString("alignment", "middlecenter");
                            xmlTextWriter.WriteEndElement();

                            //Atributos para el label de copyright 
                            xmlTextWriter.WriteStartElement("copyright");
                            xmlTextWriter.WriteAttributeString("autoSize", "true");
                            xmlTextWriter.WriteAttributeString("fontSize", "8");
                            xmlTextWriter.WriteAttributeString("fontBold", "true");
                            xmlTextWriter.WriteAttributeString("fontItalic", "false");
                            xmlTextWriter.WriteAttributeString("fontRegular", "false");
                            xmlTextWriter.WriteAttributeString("fontStrykeout", "false");
                            xmlTextWriter.WriteAttributeString("fontUnderline", "false");
                            xmlTextWriter.WriteAttributeString("locationX", "12");
                            xmlTextWriter.WriteAttributeString("locationY", "441");
                            xmlTextWriter.WriteAttributeString("dock", "none");
                            xmlTextWriter.WriteAttributeString("anchor", "none");
                            xmlTextWriter.WriteAttributeString("visible", "true");
                            xmlTextWriter.WriteAttributeString("foreColor", "Black");
                            xmlTextWriter.WriteAttributeString("backColor", "Transparent");
                            xmlTextWriter.WriteAttributeString("fontName", "Arial");
                            xmlTextWriter.WriteAttributeString("alignment", "middlecenter");
                            xmlTextWriter.WriteEndElement();

                            //Atributos para la barra de progresos.
                            xmlTextWriter.WriteStartElement("progressBar");
                            xmlTextWriter.WriteAttributeString("autoSize", "true");
                            xmlTextWriter.WriteAttributeString("fontSize", "8");
                            xmlTextWriter.WriteAttributeString("fontBold", "false");
                            xmlTextWriter.WriteAttributeString("fontItalic", "false");
                            xmlTextWriter.WriteAttributeString("fontRegular", "false");
                            xmlTextWriter.WriteAttributeString("fontStrykeout", "false");
                            xmlTextWriter.WriteAttributeString("fontUnderline", "false");
                            xmlTextWriter.WriteAttributeString("locationX", "278");
                            xmlTextWriter.WriteAttributeString("locationY", "222");
                            xmlTextWriter.WriteAttributeString("dock", "none");
                            xmlTextWriter.WriteAttributeString("anchor", "none");
                            xmlTextWriter.WriteAttributeString("visible", "true");
                            xmlTextWriter.WriteAttributeString("foreColor", "Black");
                            xmlTextWriter.WriteAttributeString("backColor", "Transparent");
                            xmlTextWriter.WriteAttributeString("fontName", "Arial");
                            xmlTextWriter.WriteAttributeString("alignment", "middlecenter");
                            xmlTextWriter.WriteEndElement();

                            xmlTextWriter.WriteStartElement("progressMessage");
                            xmlTextWriter.WriteAttributeString("autoSize", "true");
                            xmlTextWriter.WriteAttributeString("fontSize", "8.85");
                            xmlTextWriter.WriteAttributeString("fontBold", "false");
                            xmlTextWriter.WriteAttributeString("fontItalic", "false");
                            xmlTextWriter.WriteAttributeString("fontRegular", "true");
                            xmlTextWriter.WriteAttributeString("fontStrykeout", "false");
                            xmlTextWriter.WriteAttributeString("fontUnderline", "false");
                            xmlTextWriter.WriteAttributeString("locationX", "208");
                            xmlTextWriter.WriteAttributeString("locationY", "241");
                            xmlTextWriter.WriteAttributeString("dock", "none");
                            xmlTextWriter.WriteAttributeString("anchor", "none");
                            xmlTextWriter.WriteAttributeString("visible", "true");
                            xmlTextWriter.WriteAttributeString("foreColor", "Black");
                            xmlTextWriter.WriteAttributeString("backColor", "Transparent");
                            xmlTextWriter.WriteAttributeString("fontName", "Microsoft Sans Serif");
                            xmlTextWriter.WriteAttributeString("alignment", "middlecenter");
                            xmlTextWriter.WriteEndElement();

                            xmlTextWriter.WriteEndElement();

                            xmlTextWriter.WriteEndElement();

                            //Limpiar el buffer usando el Garbage Collector
                            xmlTextWriter.Flush();

                            //Cerrar el XMLTextWriter
                            xmlTextWriter.Close();
                            break;
                        }
                    case "xml/apperror.xml":
                        {
                            //Elemento Raiz configuracion
                            xmlTextWriter.WriteStartElement("configuration");

                            //Elemento errores, en donde se almacenan los errore encontrados y sus datos
                            xmlTextWriter.WriteStartElement("errores");
                            xmlTextWriter.WriteEndElement();

                            xmlTextWriter.WriteEndElement();

                            //Limpiar el buffer usando el Garbage Collector
                            xmlTextWriter.Flush();
                            xmlTextWriter.Close();
                            break;
                        }
                }

                //Limpiar el buffer usando el Garbage Collector
                xmlTextWriter.Flush();
                xmlTextWriter.Close();

            }
            catch (ArgumentException argumentException)
            {

                MessageBox.Show(argumentException.ToString());
                // Colocar codigo para Auditar el Error y/o Enviarlo
            }
            catch (UnauthorizedAccessException unauthorizeAccessException)
            {

                MessageBox.Show(unauthorizeAccessException.ToString());
                // Colocar codigo para Auditar el Error y/o Enviarlo
            }
            catch (DirectoryNotFoundException directoryNotFoundException)
            {

                MessageBox.Show(directoryNotFoundException.ToString());
                // Colocar codigo para Auditar el Error y/o Enviarlo
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.ToString());
                // Colocar codigo para Auditar el Error y/o Enviarlo
            }
        }

        #endregion  Creacion de los Archivos XML appConfig y appError Respectivamente


        #region     Envio o Escritura de Errores

        /// <summary>
        /// Envio o Escritura de Errores
        /// </summary>
        /// <param name="intIDUsuario"></param>
        /// <param name="intNumeroError"></param>
        /// <param name="stringMensajeError"></param>
        /// <param name="stringDescripcionError"></param>
        public static void enviarErrores(int intIDUsuario = 0, int intNumeroError = 0, string stringMensajeError = "", string stringDescripcionError = "")
        {

            //Path donde se encuentra el appConfig
            string stringRuta = System.AppDomain.CurrentDomain.BaseDirectory + @"\appConfig.xml";

            //Representacion de un documento XML
            XmlDocument IXMLDocument = new XmlDocument();

            //Cargando el documento XML en el Path especificado anteriormente
            IXMLDocument.Load(stringRuta);

            //Buscar el tipo de envio dentro del appConfig.XML
            XmlNode nodoTipoEnvio = IXMLDocument.SelectSingleNode("configuration/manejoErrores");
            string stringTipoEnvio = string.Format("{0}", nodoTipoEnvio.InnerText);


            if (stringTipoEnvio == "XMLCorreo" || stringTipoEnvio == "XML")
            {

                string stringRutaAppError = stringDirectorioBase + @"xml\appError.xml";

                //Representacion deL XML, de sus nodos y subnodos
                XmlDocument iXMLDocument = new XmlDocument();
                XmlNode iXMLNodo = default(XmlNode);
                XmlNode iXMLSubNodos = default(XmlNode);

                int intIdError;

                try
                {

                    //Cargamos el documento XML en el fullPath
                    IXMLDocument.Load(stringRutaAppError);

                    //Seleccionamos los nodos a partir del cual escribiremos
                    XmlNodeList iXMLNodeList = IXMLDocument.SelectNodes("configuration/errores/error");

                    //Creando el Nodo Error
                    iXMLNodo = iXMLDocument.CreateElement("error");

                    //Valor del ID
                    intIdError = Convert.ToInt32(iXMLNodeList.Count.ToString());

                    //Generando el ID del Error
                    iXMLSubNodos = iXMLDocument.CreateElement("errorID");
                    iXMLSubNodos.InnerText = (intIdError + 1).ToString();
                    iXMLNodo.AppendChild(iXMLSubNodos);

                    //Creando los SubNodos adentro del nodo Error
                    iXMLSubNodos = iXMLDocument.CreateElement("errorDate");
                    iXMLSubNodos.InnerText = "Fecha: " + DateTime.Now.ToShortDateString().ToString() + " Hora: " + DateTime.Now.ToShortTimeString().ToString();
                    iXMLNodo.AppendChild(iXMLSubNodos);

                    //Creando nodo del UserID
                    iXMLSubNodos = iXMLDocument.CreateElement("userID");
                    iXMLSubNodos.InnerText = intIDUsuario.ToString();
                    iXMLNodo.AppendChild(iXMLSubNodos);

                    //Creando nodo del errorNumber
                    iXMLSubNodos = iXMLDocument.CreateElement("errorNumber");
                    iXMLSubNodos.InnerText = intNumeroError.ToString();
                    iXMLNodo.AppendChild(iXMLSubNodos);

                    //Creando nodo del errorMessage
                    iXMLSubNodos = iXMLDocument.CreateElement("errorMessage");
                    iXMLSubNodos.InnerText = stringMensajeError;
                    iXMLNodo.AppendChild(iXMLSubNodos);

                    //Creando nodo del errorDescription
                    iXMLSubNodos = iXMLDocument.CreateElement("errorDescription");
                    iXMLSubNodos.InnerText = stringDescripcionError;
                    iXMLNodo.AppendChild(iXMLSubNodos);

                    iXMLDocument.DocumentElement.SelectSingleNode("errores").AppendChild(iXMLNodo);

                    //Guardar los Cambios en el appError.xml
                    iXMLDocument.Save(stringRutaAppError);

                }
                catch (Exception iException)
                {

                    MessageBox.Show(iException.ToString());
                    //Colocar codigo para auditar el Error y/o Enviarlo
                }

            }
            if (stringTipoEnvio == "XMLCorreo")
            {

                enviarMail("");
            }
        }

        #endregion  Envio o Escritura de Errores


        #region     Envio de Errores y Excepciones por Mail

        /// <summary>
        /// Envio de Errores y Excepciones por Mail
        /// </summary>
        /// <param name="Error">Error y Excepcion a Enviar</param>
        public static void enviarMail(string Error)
        {
            //Instanciando el objeto XMLDocument como una interfaz
            XmlDocument iXMLDocument = new XmlDocument();

            //Path donde se encuentra el archivo XML
            string stringRuta = stringDirectorioBase + @"xml\appConfig.xml";
            iXMLDocument.Load(stringRuta);

            #region     Nodos De Configuracion del Correo

            #region     Buscar los nodos, subnodos y propiedades correspondientes existentes en el appConfig

            //Buscando cada uno de los elementos del nodo de Soporte
            XmlNode to = iXMLDocument.SelectSingleNode("configuration/support/emailTo"),
                from = iXMLDocument.SelectSingleNode("configuration/support/emailFrom"),
                POP3 = iXMLDocument.SelectSingleNode("configuration/support/emailPOP3"),
                SMTP = iXMLDocument.SelectSingleNode("configuration/support/emailSMTP"),
                host = iXMLDocument.SelectSingleNode("configuration/support/host"),
                password = iXMLDocument.SelectSingleNode("configuration/support/password"),
                port = iXMLDocument.SelectSingleNode("configuration/support/emailPort"),
                format = iXMLDocument.SelectSingleNode("configuration/support/emailFormat"),
                subject = iXMLDocument.SelectSingleNode("configuration/support/emailSubject");

            //Convirtiendo a String cada uno de los elementos del nodo de Soporte
            string stringTo = string.Format("{0}", to.InnerText),
                stringFrom = string.Format("{0}", from.InnerText),
                stringPOP3 = string.Format("{0}", POP3.InnerText),
                stringSMTP = string.Format("{0}", SMTP.InnerText),
                stringHost = string.Format("{0}", host.InnerText),
                stringPassword = string.Format("{0}", password.InnerText),
                stringPort = string.Format("{0}", port.InnerText),
                stringFormat = string.Format("{0}", format.InnerText),
                stringSubject = string.Format("{0}", subject.InnerText);

            #endregion  Buscar los nodos, subnodos y propiedades correspondientes existentes en el appConfig

            //Mensaje a enviar 
            MailMessage iMailMessage = new MailMessage(stringTo, stringFrom, stringSubject, Error);

            //Servidor SMTP
            SmtpClient iSMTPClient = new SmtpClient(stringSMTP);

            //Credenciales servidor SMTP
            iSMTPClient.Credentials = new System.Net.NetworkCredential(stringTo, stringPassword);
            //iSMTPClient.EnableSsl = true;
            try
            {
                //Enviar Mensaje
                iSMTPClient.Send(iMailMessage);
            }
            catch (Exception iException)
            {

                MessageBox.Show(iException.ToString());
                //Colocar Codigo para Auditar el Error y/o Enviarlo
            }
            #endregion  Nodos De Configuracion del Correo
        }

        #endregion  Envio de Errores y Excepciones por Mail


        //No creo que sean necesarios
        #region    Determinar Conexion segun XML

        /// <summary>
        /// Determinar conexion segun parametros del connectionString
        /// </summary>
        /// <returns></returns>
        public static string determinarConexionDesdeArchivoXML()
        {
            //Declaracion de la variable utilizada para el connection String
            string stringBaseDeDatos = string.Empty;

            //Instanciacion del XMLDocument y carga del XML appConfig
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(stringDirectorioBase + stringRutaArchivoXML + @"\appConfig.xml");

            //Nodo del appConfig donde se encuentran los connectionString 
            XmlNode xmlNode = xmlDocument.SelectSingleNode("configuration/connectionsStrings");

            //Eligiendo la base de datos que se ha especificado en el appConfig
            if (xmlNode.InnerXml.ToUpper().IndexOf("SQLSERVER") > 0)
            {
                stringBaseDeDatos = "SQLServer";
            }
            else
            {
                if (xmlNode.InnerXml.ToUpper().IndexOf("ORACLE") > 0)
                {
                    stringBaseDeDatos = "Oracle";
                }
                else
                {
                    if (xmlNode.InnerXml.ToUpper().IndexOf("MYSQL") > 0)
                    {
                        stringBaseDeDatos = "MySQL";
                    }
                    else
                    {
                        if (xmlNode.InnerXml.ToUpper().IndexOf("SQLLITE") > 0)
                        {
                            stringBaseDeDatos = "SQLLite";
                        }
                        else
                        {
                            if (xmlNode.InnerXml.ToUpper().IndexOf
                            ("POSTGRESQL") > 0)
                            {
                                stringBaseDeDatos = "PostgreSQL";
                            }
                            else
                            {
                            }
                        }
                    }
                }
            }

            return string.Format("{0}", stringBaseDeDatos);
        }

        #endregion Determinar Conexion segun XML


        //No creo que sean necesarios
        #region     Abrir Conexion Segun XML

        public static string abrirConexionDesdeArchivoXML(string parametrosConexion = "")
        {
            //Instaciacion del XMLDocument y cargando el path donde se encuentra el XML appConfig
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(stringDirectorioBase + stringRutaArchivoXML + @"\appConfig.xml");
            XmlNode xmlNode;

            //Obteniendo los connection string segun el servidor especificado en el appConfig
            switch (parametrosConexion.ToUpper())
            {
                case "SQLSERVER":
                    {
                        xmlNode = xmlDocument.SelectSingleNode("configuration/connectionStrings/SQLServer");
                        break;
                    }
                case "ORACLE":
                    {
                        xmlNode = xmlDocument.SelectSingleNode("configuration/connectionStrings/oracle");
                        break;
                    }
                case "MYSQL":
                    {
                        xmlNode = xmlDocument.SelectSingleNode("configuration/connectionStrings/MySQL");
                        break;
                    }
                case "SQLLITE":
                    {
                        xmlNode = xmlDocument.SelectSingleNode("configuration/connectionStrings/SQLLite");
                        break;
                    }
                case "POSTGRESQL":
                    {
                        xmlNode = xmlDocument.SelectSingleNode("configuration/connectionStrings/PostgreSQL");
                        break;
                    }
                default:
                    {
                        xmlNode = xmlDocument.SelectSingleNode("configuration/connectionStrings/SQLServer");
                        break;
                    }
            }

            return string.Format("{0}", xmlNode.InnerText);
        }
        #endregion  Abrir Conexion Segun XML


        #region     Determinar el contenido de un nodo especificado

        /// <summary>
        /// Determinar el contenido de un Nodo Especificado
        /// </summary>
        /// <param name="stringParametroArchivoXML">Nombre del Archivo XML</param>
        /// <param name="stringParametroNodo">Nombre del Nodo</param>
        /// <param name="stringParametroAtributo">Nombre del Atributo</param>
        /// <returns></returns>
        public static string buscarNodo(string stringParametroArchivoXML, string stringParametroNodo, string stringParametroAtributo = "")
        {

            //Si estan vacios los parametros del Path del XML y del XML que se desea buscar, asignarle valores por defecto.
            stringRutaArchivoXML = string.IsNullOrEmpty(stringRutaArchivoXML) ? "xml" : stringRutaArchivoXML.ToString();
            stringParametroArchivoXML = string.IsNullOrEmpty(stringParametroArchivoXML) ? "appConfig.xml" : stringParametroArchivoXML.ToString();

            //Instanciar una lista de Nodos de un documento XML 
            XmlNodeList xmlNodeList = default(XmlNodeList);
            XmlDocument xmlDocument = new XmlDocument();

            //Cargar el documento XML y sus nodos 
            xmlDocument.Load(stringDirectorioBase + stringRutaArchivoXML + @"\" + stringParametroArchivoXML);

            try
            {

                xmlNodeList = xmlDocument.GetElementsByTagName(stringParametroNodo);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

            //Retornar el contenido del nodo que se deseaba buscar
            return string.IsNullOrEmpty(stringParametroAtributo) ? xmlNodeList[0].InnerText : xmlNodeList[0].Attributes[stringParametroAtributo].InnerText;

        }

        #endregion  Determinar el contenido de un nodo especificado


        #region     Modificacion de un atributo de un nodo de un archivo XML

        /// <summary>
        /// Modifica de un atributo de un nodo de un archivo XML
        /// </summary>
        /// <param name="stringParametroArchivoXML">Archivo XML en el cual se va a buscar</param>
        /// <param name="stringParametroNodo">Nombre del Nodo a buscar</param>
        /// <param name="stringParametroAtributo">Nombre del Atributo a buscar</param>
        /// <param name="stringParameterValor">valor que se le quiere asignar al atributo</param>
        public static void modificarNodo(string stringParametroArchivoXML, string stringParametroNodo, string stringParametroAtributo, string stringParameterValor="")
        {
            //Si estan vacios los parametros del Path del XML y del XML que se desea buscar, asignarle valores por defecto.
            stringRutaArchivoXML = string.IsNullOrEmpty(stringRutaArchivoXML) ? "xml" : stringRutaArchivoXML.ToString();
            stringParametroArchivoXML = string.IsNullOrEmpty(stringParametroArchivoXML) ? "appConfig.xml" : stringParametroArchivoXML.ToString();

            //Instanciar una lista de Nodos de un documento XML 
            XmlNodeList xmlNodeList = default(XmlNodeList);
            XmlDocument xmlDocument = new XmlDocument();

            string stringRutaCompleta = stringDirectorioBase + stringRutaArchivoXML + @"\" + stringParametroArchivoXML;

            //Cargar el documento XML y sus nodos 
            xmlDocument.Load(stringRutaCompleta);

            try
            {

                xmlNodeList = xmlDocument.GetElementsByTagName(stringParametroNodo);

                xmlNodeList[0].Attributes[stringParametroAtributo].Value = string.IsNullOrWhiteSpace(stringParameterValor) ? string.Empty : stringParameterValor;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

            xmlDocument.Save(stringRutaCompleta);            

        }

        #endregion  Modificacion de un atributo de un nodo de un archivo XML


        #region     Determinar un nodo especifico

        /// <summary>
        /// Determinar un Nodo Especifico
        /// </summary>
        /// <param name="parametroArchivoXML">Nombre del archIvo XML</param>
        /// <param name="parametroNodo">Nombre del nodo</param>
        /// <returns></returns>
        public static XmlNode determinarNodoXML(string parametroArchivoXML, string parametroNodo)
        {
            //Cargar el XML
            XmlDocument oXmlDocument = new XmlDocument();
            oXmlDocument.Load(directorioBaseAplicacion() + stringRutaArchivoXML + @"\" + parametroArchivoXML);

            //Seleccionar el nodo
            XmlNode oXMLNode = oXmlDocument.SelectSingleNode(parametroNodo);

            //Retornar el nodo especificado
            return oXMLNode;
        }

        #endregion  Determinar un nodo especifico


        #region     Anclaje de Objetos

        /// <summary>
        /// Anclaje de Objetos
        /// </summary>
        /// <param name="stringParametroEstiloDock">Parametro del Anclaje de Objetos</param>
        /// <returns></returns>
        public static DockStyle estiloDock(string stringParametroEstiloDock)
        {
            //Posicion del Dock de la aplicacion
            DockStyle estiloDock = new DockStyle();

            //Posicion del Dock dependiendo del parametro enviado
            switch (stringParametroEstiloDock.ToLower())
            {
                case "bottom":
                    {

                        estiloDock = DockStyle.Bottom;
                        break;
                    }
                case "top":
                    {

                        estiloDock = DockStyle.Top;
                        break;
                    }
                case "left":
                    {

                        estiloDock = DockStyle.Left;
                        break;
                    }
                case "right":
                    {

                        estiloDock = DockStyle.Right;
                        break;
                    }
                case "fill":
                    {

                        estiloDock = DockStyle.Fill;
                        break;
                    }
                case "none":
                    {

                        estiloDock = DockStyle.None;
                        break;
                    }
            }

            return estiloDock;
        }

        #endregion  Anclaje de Objetos


        #region     Ancho de los Objetos

        /// <summary>
        /// Ancho de los Objetos
        /// </summary>
        /// <param name="stringParametroEstiloAncho">Estilo del ancho</param>
        /// <returns>Estilo especificado</returns>
        public static AnchorStyles estiloAncho(string stringParametroEstiloAncho)
        {
            // Declaración de Variables a Ser Utilizadas
            AnchorStyles estiloAncho = new AnchorStyles();

            // Lógica Principal
            switch (stringParametroEstiloAncho.ToLower())
            {
                case "bottom":
                    {
                        estiloAncho = AnchorStyles.Bottom;
                        break;
                    }
                case "top":
                    {
                        estiloAncho = AnchorStyles.Top;
                        break;
                    }
                case "left":
                    {
                        estiloAncho = AnchorStyles.Left;
                        break;
                    }
                case "right":
                    {
                        estiloAncho = AnchorStyles.Right;
                        break;
                    }
                case "none":
                    {
                        estiloAncho = AnchorStyles.None;
                        break;
                    }
            }
            return estiloAncho;
        }

        #endregion  Ancho de los Objetos


        #region     Alineamiento de cualquier texto 

        /// <summary>
        /// Alineamiento de cualquier texto 
        /// </summary>
        /// <param name="stringParameterTipoalignment">Tipo de alignment deseada</param>
        /// <returns>alignment del Texto deseada</returns>
        public static ContentAlignment alineamientoContenido(string stringParametroTipoAlineamiento)
        {

            ContentAlignment alineamientoContenido = new ContentAlignment();

            switch (stringParametroTipoAlineamiento.ToLower())
            {
                case "bottomcenter":
                    {
                        alineamientoContenido = ContentAlignment.BottomCenter;
                        break;
                    }
                case "bottomleft":
                    {
                        alineamientoContenido = ContentAlignment.BottomLeft;
                        break;
                    }
                case "bottomright":
                    {
                        alineamientoContenido = ContentAlignment.BottomRight;
                        break;
                    }
                case "middlecenter":
                    {
                        alineamientoContenido = ContentAlignment.MiddleCenter;
                        break;
                    }
                case "middleleft":
                    {
                        alineamientoContenido = ContentAlignment.MiddleLeft;
                        break;
                    }
                case "middleright":
                    {
                        alineamientoContenido = ContentAlignment.MiddleRight;
                        break;
                    }
                case "topcenter":
                    {
                        alineamientoContenido = ContentAlignment.TopCenter;
                        break;
                    }
                case "topleft":
                    {
                        alineamientoContenido = ContentAlignment.TopLeft;
                        break;
                    }
                case "topright":
                    {
                        alineamientoContenido = ContentAlignment.TopRight;
                        break;
                    }
                default:
                    {
                        alineamientoContenido = ContentAlignment.TopLeft;
                        break;
                    }
            }

            return alineamientoContenido;
        }

        #endregion  Alineamiento de cualquier texto 


        #region     Alineamiento de cualquier formulario

        /// <summary>
        /// Alineamiento de cualquier formulario
        /// </summary>
        /// <param name="stringParameterTipoPosicionInicial">posicion inicial deseada</param>
        /// <returns>posicion inicial deseada</returns>
        public static FormStartPosition posicionInicialFormulario(string stringParameterTipoPosicionInicial = "")
        {

            FormStartPosition posicionInicialFormulario = new FormStartPosition();

            switch (stringParameterTipoPosicionInicial.ToLower())
            {
                case "centerparent":
                    {
                        posicionInicialFormulario = FormStartPosition.CenterParent;
                        break;
                    }
                case "centerscreen":
                    {
                        posicionInicialFormulario = FormStartPosition.CenterScreen;
                        break;
                    }
                case "windowsdefaultlocation":
                    {
                        posicionInicialFormulario = FormStartPosition.WindowsDefaultLocation;
                        break;
                    }
                case "windowsdefaultbounds":
                    {
                        posicionInicialFormulario = FormStartPosition.WindowsDefaultBounds;
                        break;
                    }
                case "manual":
                    {
                        posicionInicialFormulario = FormStartPosition.Manual;
                        break;
                    }
                default:
                    {
                        posicionInicialFormulario = FormStartPosition.CenterScreen;
                        break;
                    }
            }

            return posicionInicialFormulario;
        }

        #endregion  Alineamiento de cualquier formulario


        #region     Obtener y devolver el hash de un texto especificado

        /// <summary>
        /// Obtener y devolver el hash de un texto especificado
        /// </summary>
        /// <param name="stringParametroTexto">Texto al que se va a obtener y devolver el hash</param>
        /// <param name="hashTipoParametro">Tipo de hash en el que se va a devolver el texto</param>
        /// <returns>Hash Especificado</returns>
        public static string conseguirHash(string stringParametroTexto, tipoHash hashTipoParametro = tipoHash.MD5)
        {
            //Declaracion del string para almacenar el hash 
            string stringHash = string.Empty;

            //Codificacion
            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();

            //Array de Bytes
            byte[] byteHashValue;
            byte[] byteText = unicodeEncoding.GetBytes(stringParametroTexto);

            //Segun el tipo especificado de Hash, realiza la encriptacion correspondiente
            switch (hashTipoParametro)
            {
                case tipoHash.MD5:
                    {

                        MD5 md5hashString = new MD5CryptoServiceProvider();

                        byteHashValue = md5hashString.ComputeHash(byteText);
                        foreach (byte byteValue in byteHashValue)
                        {

                            stringHash += string.Format("{0:x2}", byteValue);
                        }
                        break;
                    }
                case tipoHash.SHA1:
                    {

                        SHA1Managed sha1HashString = new SHA1Managed();

                        byteHashValue = sha1HashString.ComputeHash(byteText);
                        foreach (byte byteValue in byteHashValue)
                        {

                            stringHash += string.Format("{0:x2}", byteValue);
                        }
                        break;
                    }
                case tipoHash.SHA128:
                    {

                        SHA1Managed sha128HashString = new SHA1Managed();

                        byteHashValue = sha128HashString.ComputeHash(byteText);
                        foreach (byte byteValue in byteHashValue)
                        {

                            stringHash += string.Format("{0:x2}", byteValue);
                        }
                        break;
                    }
                case tipoHash.SHA256:
                    {

                        SHA256Managed sha256HashString = new SHA256Managed();

                        byteHashValue = sha256HashString.ComputeHash(byteText);
                        foreach (byte byteValue in byteHashValue)
                        {

                            stringHash += string.Format("{0:x2}", byteValue);
                        }
                        break;
                    }
                case tipoHash.SHA384:
                    {

                        SHA384Managed sha384HashString = new SHA384Managed();

                        byteHashValue = sha384HashString.ComputeHash(byteText);
                        foreach (byte byteValue in byteHashValue)
                        {

                            stringHash += string.Format("{0:x2}", byteValue);
                        }
                        break;
                    }
                case tipoHash.SHA512:
                    {

                        SHA512Managed sha512HashString = new SHA512Managed();

                        byteHashValue = sha512HashString.ComputeHash(byteText);
                        foreach (byte byteValue in byteHashValue)
                        {

                            stringHash += string.Format("{0:x2}", byteValue);
                        }
                        break;
                    }
                case tipoHash.SHA634:
                    {

                        break;
                    }
                default:
                    {
                        stringHash = "Tipo de Hash Invalido";
                        break;
                    }

            }

            return stringHash;
        }

        #endregion  Obtener y devolver el hash de un texto especificado


        #region     Verificar String vs String Hash

        /// <summary>
        /// Verificar el String vs el String Hash
        /// </summary>
        /// <param name="stringParametroTexto">String a verificar</param>
        /// <param name="stringParametroHash">String hash a verificar</param>
        /// <param name="hashParametroTipo">Tipo de Hash</param>
        /// <returns></returns>
        public static bool boolChequearHash(string stringParametroTexto, string stringParametroHash, tipoHash hashParametroTipo = tipoHash.MD5)
        {

            return (conseguirHash(stringParametroTexto, hashParametroTipo) == stringParametroHash);
        }

        #endregion  Verificar String vs String Hash


        #region     Conseguir el ambiente de desarrollo en el que se encuentra la Aplicacion

        /// <summary>
        /// Conseguir el ambiente de desarrollo en el que se encuentra la Aplicacion
        /// </summary>
        /// <returns>nombre del ambiente de la aplicacion</returns>
        public static string checkearAmbienteDesarrollo()
        {
            string[] tipoAplicacion = new string[] { "windows", "web", "wpf", "console" };
            int indiceTipoAplicacion = 0;

            if (Assembly.GetEntryAssembly() != null)
            {

                //Es una aplicacion Windows
                indiceTipoAplicacion = 0;
            }
            else if (HttpContext.Current != null)
            {

                //Es una aplicacion Web
                indiceTipoAplicacion = 1;
            }
            else if (System.Windows.Application.Current != null)
            {

                //Es una aplicacion WPF
                indiceTipoAplicacion = 2;
            }
            else
            {

                //Es una aplicacion de Consola
                indiceTipoAplicacion = 3;
            }

            //Retorna el tipo de ambiente de la aplicacion
            return tipoAplicacion[indiceTipoAplicacion];

        }

        #endregion  Conseguir el ambiente de desarrollo en el que se encuentra la Aplicacion


    }
    #endregion  Clase Global, contenendora de los procedimientos, funciones, eventos y propiedades de la aplicacion

}

#endregion  Logica de la Clase, Segun NameSpace especificado