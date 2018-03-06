#region     CopyRighy

#endregion     CopyRighy


#region     Uso e Invocacion de Librerias de Clase a ser Utilizadas

using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using PrestaMe.Layers.Application;

#endregion  Uso e Invocacion de Librerias de Clase a ser Utilizadas


#region     Logica de la Clase, Segun NameSpace Especificado

namespace PrestaMe.Windows.Forms
{

    #region     Estructura de Metodos, Propiedades, Procedimientos y Funciones de la clase indicada

    /// <summary>
    /// Estructura de Metodos, Propiedades, Procedimientos y Funciones de la clase indicada
    /// </summary>
    public partial class splashForm : RadForm
    {


        #region     Constructor Principal Sin Parametros Invocados

        /// <summary>
        /// Constructor Sin Parametros
        /// </summary>
        public splashForm()
        {

            InitializeComponent();

            // Archivos XML que se desea verificar su existencia
            string[] stringXMLVerificar = new string[] { "xml/appConfig.xml", "xml/appError.xml" };

            // Verificar que exista el archivo appConfig.xml
            foreach (string stringElementoXML in stringXMLVerificar)
            {

                classApplication.verificarArchivosXMLAplicacion(stringElementoXML);

            }

            // Configura los datos iniciales de la aplicacion
            classApplication.configurarDataInicial();

            //Invocacion y carga de los Elementos del Nodo a los Objetos del Formulario Splash
            cargarSplashFromArchivoXMLAplicacion();

        }

        #endregion  Constructor Principal Sin Parametros Invocados   


        #region     Aplicar el Ambiente del Splash segun la configuracion del Archivo de la Aplicacion

        private void cargarSplashFromArchivoXMLAplicacion()
        {

            #region    Declaracion de Variables Locales


            string stringRutaArchivosImagenes = classApplication.stringRutaArchivosImagenes;
            string stringRutaArchivosIconos = classApplication.stringRutaArchivosIconos;
            string stringArchivoIcono = classApplication.buscarNodo("appconfig.xml", "formulario", "icon");
            string stringArchivoImagen = classApplication.buscarNodo("appConfig.xml", "formulario", "backgroundImage");
            string stringTransparentColor = classApplication.buscarNodo("appConfig.xml", "formulario", "transparencyKey");
            string stringBackColor = classApplication.buscarNodo("appConfig.xml", "formulario", "backColor");

            #endregion  Declaracion de Variables Locales


            //Ocultar Formulario hasta realizar cambios
            this.Visible = false;


            #region     Estilo y Ubicacion del Formulario

            //Aplicar Width y Height especificados en el appConfig.XML
            this.Width = int.Parse(classApplication.buscarNodo("appConfig.xml", "formulario", "width"));
            this.Height = int.Parse(classApplication.buscarNodo("appConfig.xml", "formulario", "heigth"));

            //Color y transparencia por defecto, si no existe configuracion dentro del XML
            stringBackColor = string.IsNullOrEmpty(stringBackColor) ? "control" : stringBackColor;
            stringTransparentColor = string.IsNullOrEmpty(stringTransparentColor) ? "control" : stringTransparentColor;

            //Aplicar Propiedades del Color y Transparencia
            this.BackColor = Color.FromName(stringBackColor);
            this.TransparencyKey = Color.FromName(stringTransparentColor);

            //Ruta de la imagen de fondo del formulario
            stringRutaArchivosImagenes = stringRutaArchivosImagenes.Substring(stringRutaArchivosImagenes.Length - 1, 1) == @"\" ? stringRutaArchivosImagenes : stringRutaArchivosImagenes + @"\";

            try
            {

                //Aplicar la imagen de fondo al formulario
                this.BackgroundImage = Image.FromFile(System.IO.File.Exists(stringRutaArchivosImagenes + stringArchivoImagen) ? stringArchivoImagen + stringArchivoImagen : classApplication.stringDirectorioBase + stringRutaArchivosImagenes + stringArchivoImagen);
            }
            catch (Exception exception)
            {

                //Si no encuentra la imagen especificada, asignele estos valores por defecto
                MessageBox.Show(exception.Message);
                this.BackgroundImage = null;
                this.BackColor = Color.White;

            }

            //Posicion inical del formulario segun appConfig.XML
            this.StartPosition = classApplication.posicionInicialFormulario(classApplication.buscarNodo("appConfig.xml", "formulario", "startPosition"));

            //Ruta del icono del formulario
            stringRutaArchivosIconos = stringRutaArchivosIconos.Substring(stringRutaArchivosIconos.Length - 1, 1) == @"\" ? stringRutaArchivosIconos : stringRutaArchivosIconos + @"\";

            try
            {

                //Aplicar el icono al formulario
                this.Icon = new Icon(System.IO.File.Exists(stringRutaArchivosIconos + stringArchivoIcono) ? stringRutaArchivosIconos + stringArchivoIcono : classApplication.stringDirectorioBase + stringRutaArchivosIconos + stringArchivoIcono);
            }
            catch (Exception exception)
            {

                //Si no encuentra el icono especificado, asignele estos valores por defecto
                MessageBox.Show(exception.Message);
                this.Icon = new Icon(SystemIcons.Application, 40, 40);

            }

            #endregion  Estilo y Ubicacion del Formulario


            #region    Estilo y Ubicacion de la Version de la Aplicacion

            //Texto
            labelVersion.Text = classApplication.buscarNodo("appConfig.xml", "identificacion", "version");

            //Localizacion
            labelVersion.Location = new Point(int.Parse(classApplication.buscarNodo("appConfig.xml", "version", "locationX")), int.Parse(classApplication.buscarNodo("appConfig.xml", "version", "locationY")));

            //Color de Fondo
            labelVersion.BackColor = Color.FromName(classApplication.buscarNodo("appConfig.xml", "version", "backColor"));

            //Color de la Letra
            labelVersion.ForeColor = Color.FromName(classApplication.buscarNodo("appConfig.xml", "version", "foreColor"));

            //Fonts y Estilos
            labelVersion.Font = new Font(classApplication.buscarNodo("appConfig.xml", "version", "fontName"), float.Parse(classApplication.buscarNodo("appConfig.xml", "version", "fontSize")));
            labelVersion.Font = new Font(labelVersion.Font, classApplication.buscarNodo("appConfig.xml", "version", "fontBold").ToLower() == "true" ? FontStyle.Bold : labelVersion.Font.Style);
            labelVersion.Font = new Font(labelVersion.Font, classApplication.buscarNodo("appConfig.xml", "version", "fontItalic").ToLower() == "true" ? FontStyle.Italic : labelVersion.Font.Style);
            labelVersion.Font = new Font(labelVersion.Font, classApplication.buscarNodo("appConfig.xml", "version", "fontRegular").ToLower() == "true" ? FontStyle.Regular : labelVersion.Font.Style);
            labelVersion.Font = new Font(labelVersion.Font, classApplication.buscarNodo("appConfig.xml", "version", "fontStrykeout").ToLower() == "true" ? FontStyle.Strikeout : labelVersion.Font.Style);
            labelVersion.Font = new Font(labelVersion.Font, classApplication.buscarNodo("appConfig.xml", "version", "fontUnderline").ToLower() == "true" ? FontStyle.Underline : labelVersion.Font.Style);

            //Propiedad AutoSize
            labelVersion.AutoSize = classApplication.buscarNodo("appConfig.xml", "version", "autoSize").ToLower() == "true" ? true : false;

            //Aliniacion del Label
            labelVersion.TextAlignment = classApplication.alineamientoContenido(classApplication.buscarNodo("appConfig.xml", "version", "alignment"));

            //Visibilidad
            labelVersion.Visible = classApplication.buscarNodo("appConfig.xml", "version", "visible").ToLower() == "true" ? true : false;

            //Dock
            labelVersion.Dock = classApplication.estiloDock(classApplication.buscarNodo("appConfig.xml", "version", "dock"));

            //Anchor
            labelVersion.Anchor = classApplication.estiloAncho(classApplication.buscarNodo("appConfig.xml", "version", "anchor"));

            #endregion Estilo y Ubicacion de la Version de la Aplicacion


            #region     Estilo y Ubicacion del Progress Message 

            //Localizacion
            labelProgressMessage.Location = new Point(int.Parse(classApplication.buscarNodo("appConfig.xml", "progressMessage", "locationX")), int.Parse(classApplication.buscarNodo("appConfig.xml", "progressMessage", "locationY")));

            //Color de Fondo
            labelProgressMessage.BackColor = Color.FromName(classApplication.buscarNodo("appConfig.xml", "progressMessage", "backColor"));

            //Color de la Letra
            labelProgressMessage.ForeColor = Color.FromName(classApplication.buscarNodo("appConfig.xml", "progressMessage", "foreColor"));

            //Fonts y Estilos
            labelProgressMessage.Font = new Font(classApplication.buscarNodo("appConfig.xml", "progressMessage", "fontName"), float.Parse(classApplication.buscarNodo("appConfig.xml", "progressMessage", "fontSize")));
            labelProgressMessage.Font = new Font(labelProgressMessage.Font, classApplication.buscarNodo("appConfig.xml", "progressMessage", "fontBold").ToLower() == "true" ? FontStyle.Bold : labelProgressMessage.Font.Style);
            labelProgressMessage.Font = new Font(labelProgressMessage.Font, classApplication.buscarNodo("appConfig.xml", "progressMessage", "fontItalic").ToLower() == "true" ? FontStyle.Italic : labelProgressMessage.Font.Style);
            labelProgressMessage.Font = new Font(labelProgressMessage.Font, classApplication.buscarNodo("appConfig.xml", "progressMessage", "fontRegular").ToLower() == "true" ? FontStyle.Regular : labelProgressMessage.Font.Style);
            labelProgressMessage.Font = new Font(labelProgressMessage.Font, classApplication.buscarNodo("appConfig.xml", "progressMessage", "fontStrykeout").ToLower() == "true" ? FontStyle.Strikeout : labelProgressMessage.Font.Style);
            labelProgressMessage.Font = new Font(labelProgressMessage.Font, classApplication.buscarNodo("appConfig.xml", "progressMessage", "fontUnderline").ToLower() == "true" ? FontStyle.Underline : labelProgressMessage.Font.Style);

            //Propiedad AutoSize
            labelProgressMessage.AutoSize = classApplication.buscarNodo("appConfig.xml", "progressMessage", "autoSize").ToLower() == "true" ? true : false;

            //Aliniacion del Label
            labelProgressMessage.TextAlignment = classApplication.alineamientoContenido(classApplication.buscarNodo("appConfig.xml", "progressMessage", "alignment"));

            //Visibilidad
            labelProgressMessage.Visible = classApplication.buscarNodo("appConfig.xml", "version", "visible").ToLower() == "true" ? true : false;

            //Dock
            labelProgressMessage.Dock = classApplication.estiloDock(classApplication.buscarNodo("appConfig.xml", "version", "dock"));

            //Anchor
            labelProgressMessage.Anchor = classApplication.estiloAncho(classApplication.buscarNodo("appConfig.xml", "version", "anchor"));
            #endregion  Estilo y Ubicacion del Progress Message


            #region     Estilo y Ubicacion del Progress Bar

            //Location
            radProgressBar.Location = new Point(int.Parse(classApplication.buscarNodo("appConfig.xml", "progressBar", "locationX")), int.Parse(classApplication.buscarNodo("appConfig.xml", "progressBar", "locationY")));

            //BackColor
            radProgressBar.BackColor = Color.FromName(classApplication.buscarNodo("appConfig.xml", "progressBar", "backColor"));

            //ForeColor
            radProgressBar.ForeColor = Color.FromName(classApplication.buscarNodo("appConfig.xml", "progressBar", "foreColor"));

            //Fonts y Estilos
            labelProgressMessage.Font = new Font(classApplication.buscarNodo("appConfig.xml", "progressBar", "fontName"), float.Parse(classApplication.buscarNodo("appConfig.xml", "progressBar", "fontSize")));
            labelProgressMessage.Font = new Font(labelProgressMessage.Font, classApplication.buscarNodo("appConfig.xml", "progressBar", "fontBold").ToLower() == "true" ? FontStyle.Bold : labelProgressMessage.Font.Style);
            labelProgressMessage.Font = new Font(labelProgressMessage.Font, classApplication.buscarNodo("appConfig.xml", "progressBar", "fontItalic").ToLower() == "true" ? FontStyle.Italic : labelProgressMessage.Font.Style);
            labelProgressMessage.Font = new Font(labelProgressMessage.Font, classApplication.buscarNodo("appConfig.xml", "progressBar", "fontRegular").ToLower() == "true" ? FontStyle.Regular : labelProgressMessage.Font.Style);
            labelProgressMessage.Font = new Font(labelProgressMessage.Font, classApplication.buscarNodo("appConfig.xml", "progressBar", "fontStrykeout").ToLower() == "true" ? FontStyle.Strikeout : labelProgressMessage.Font.Style);
            labelProgressMessage.Font = new Font(labelProgressMessage.Font, classApplication.buscarNodo("appConfig.xml", "progressBar", "fontUnderline").ToLower() == "true" ? FontStyle.Underline : labelProgressMessage.Font.Style);

            //AutoScroll
            radProgressBar.AutoScroll = classApplication.buscarNodo("appConfig.xml", "progressBar", "autoSize").ToLower() == "true" ? true : false;

            //TextAligment
            radProgressBar.TextAlignment = classApplication.alineamientoContenido(classApplication.buscarNodo("appConfig.xml", "progressBar", "autoSize"));

            //Visible
            radProgressBar.Visible = classApplication.buscarNodo("appConfig.xml", "progressBar", "visible").ToLower() == "true" ? true : false;

            //Dock
            radProgressBar.Dock = classApplication.estiloDock(classApplication.buscarNodo("appConfig.xml", "progressBar", "dock"));

            //Anchor
            radProgressBar.Anchor = classApplication.estiloAncho(classApplication.buscarNodo("appConfig.xml", "progressBar", "anchor"));


            #endregion  Estilo y Ubicacion del Progress Bar


            #region     Estilo y Ubicacion del CopyRight

            //Texto
            labelCopyRight.Text = classApplication.buscarNodo("appConfig.xml", "identificacion", "copyright");

            //Localizacion
            labelCopyRight.Location = new Point(int.Parse(classApplication.buscarNodo("appConfig.xml", "copyright", "locationX")), int.Parse(classApplication.buscarNodo("appConfig.xml", "copyright", "locationY")));

            //Color de Fondo
            labelCopyRight.BackColor = Color.FromName(classApplication.buscarNodo("appConfig.xml", "copyright", "backColor"));

            //Color de la Letra
            labelCopyRight.ForeColor = Color.FromName(classApplication.buscarNodo("appConfig.xml", "copyright", "foreColor"));

            //Fonts y Estilos
            labelCopyRight.Font = new Font(classApplication.buscarNodo("appConfig.xml", "copyright", "fontName"), float.Parse(classApplication.buscarNodo("appConfig.xml", "copyright", "fontSize")));
            labelCopyRight.Font = new Font(labelCopyRight.Font, classApplication.buscarNodo("appConfig.xml", "copyright", "fontBold").ToLower() == "true" ? FontStyle.Bold : labelCopyRight.Font.Style);
            labelCopyRight.Font = new Font(labelCopyRight.Font, classApplication.buscarNodo("appConfig.xml", "copyright", "fontItalic").ToLower() == "true" ? FontStyle.Italic : labelCopyRight.Font.Style);
            labelCopyRight.Font = new Font(labelCopyRight.Font, classApplication.buscarNodo("appConfig.xml", "copyright", "fontRegular").ToLower() == "true" ? FontStyle.Regular : labelCopyRight.Font.Style);
            labelCopyRight.Font = new Font(labelCopyRight.Font, classApplication.buscarNodo("appConfig.xml", "copyright", "fontStrykeout").ToLower() == "true" ? FontStyle.Strikeout : labelCopyRight.Font.Style);
            labelCopyRight.Font = new Font(labelCopyRight.Font, classApplication.buscarNodo("appConfig.xml", "copyright", "fontUnderline").ToLower() == "true" ? FontStyle.Underline : labelCopyRight.Font.Style);

            //Propiedad AutoSize
            labelCopyRight.AutoSize = classApplication.buscarNodo("appConfig.xml", "copyright", "autoSize").ToLower() == "true" ? true : false;

            //Aliniacion del Label
            labelCopyRight.TextAlignment = classApplication.alineamientoContenido(classApplication.buscarNodo("appConfig.xml", "copyright", "alignment"));

            //Visibilidad
            labelCopyRight.Visible = classApplication.buscarNodo("appConfig.xml", "copyright", "visible").ToLower() == "true" ? true : false;

            //Dock
            labelCopyRight.Dock = classApplication.estiloDock(classApplication.buscarNodo("appConfig.xml", "copyright", "dock"));

            //Anchor
            labelCopyRight.Anchor = classApplication.estiloAncho(classApplication.buscarNodo("appConfig.xml", "copyright", "anchor"));


            #endregion  Estilo y Ubicacion del CopyRight


            #region     Estilo y Ubicacion de las Siglas de la Aplicacion

            //Texto
            labelSiglas.Text = classApplication.buscarNodo("appConfig.xml", "identificacion", "siglas");

            //Localizacion
            labelSiglas.Location = new Point(int.Parse(classApplication.buscarNodo("appConfig.xml", "siglas", "locationX")), int.Parse(classApplication.buscarNodo("appConfig.xml", "siglas", "locationY")));

            //Color de Fondo
            labelSiglas.BackColor = Color.FromName(classApplication.buscarNodo("appConfig.xml", "siglas", "backColor"));

            //Color de la Letra
            labelSiglas.ForeColor = Color.FromName(classApplication.buscarNodo("appConfig.xml", "siglas", "foreColor"));

            //Fonts y Estilos
            labelSiglas.Font = new Font(classApplication.buscarNodo("appConfig.xml", "siglas", "fontName"), float.Parse(classApplication.buscarNodo("appConfig.xml", "siglas", "fontSize")));
            labelSiglas.Font = new Font(labelSiglas.Font, classApplication.buscarNodo("appConfig.xml", "siglas", "fontBold").ToLower() == "true" ? FontStyle.Bold : labelSiglas.Font.Style);
            labelSiglas.Font = new Font(labelSiglas.Font, classApplication.buscarNodo("appConfig.xml", "siglas", "fontItalic").ToLower() == "true" ? FontStyle.Italic : labelSiglas.Font.Style);
            labelSiglas.Font = new Font(labelSiglas.Font, classApplication.buscarNodo("appConfig.xml", "siglas", "fontRegular").ToLower() == "true" ? FontStyle.Regular : labelSiglas.Font.Style);
            labelSiglas.Font = new Font(labelSiglas.Font, classApplication.buscarNodo("appConfig.xml", "siglas", "fontStrykeout").ToLower() == "true" ? FontStyle.Strikeout : labelSiglas.Font.Style);
            labelSiglas.Font = new Font(labelSiglas.Font, classApplication.buscarNodo("appConfig.xml", "siglas", "fontUnderline").ToLower() == "true" ? FontStyle.Underline : labelSiglas.Font.Style);

            //Propiedad AutoSize
            labelSiglas.AutoSize = classApplication.buscarNodo("appConfig.xml", "siglas", "autoSize").ToLower() == "true" ? true : false;

            //Aliniacion del Label
            labelSiglas.TextAlignment = classApplication.alineamientoContenido(classApplication.buscarNodo("appConfig.xml", "siglas", "alignment"));

            //Visibilidad
            labelSiglas.Visible = classApplication.buscarNodo("appConfig.xml", "siglas", "visible").ToLower() == "true" ? true : false;

            //Dock
            labelSiglas.Dock = classApplication.estiloDock(classApplication.buscarNodo("appConfig.xml", "siglas", "dock"));

            //Anchor
            labelSiglas.Anchor = classApplication.estiloAncho(classApplication.buscarNodo("appConfig.xml", "siglas", "anchor"));

            #endregion  Estilo y ubicacion de las Siglas de la Aplicacion


            #region     Estilo y Ubicacion del Label del producto

            //Texto
            labelProducto.Text = classApplication.buscarNodo("appConfig.xml", "identificacion", "producto");

            //Localizacion
            labelProducto.Location = new Point(int.Parse(classApplication.buscarNodo("appConfig.xml", "producto", "locationX")), int.Parse(classApplication.buscarNodo("appConfig.xml", "producto", "locationY")));

            //Color de Fondo
            labelProducto.BackColor = Color.FromName(classApplication.buscarNodo("appConfig.xml", "producto", "backColor"));

            //Color de la Letra
            labelProducto.ForeColor = Color.FromName(classApplication.buscarNodo("appConfig.xml", "producto", "foreColor"));

            //Fonts y Estilos
            labelProducto.Font = new Font(classApplication.buscarNodo("appConfig.xml", "producto", "fontName"), float.Parse(classApplication.buscarNodo("appConfig.xml", "producto", "fontSize")));
            labelProducto.Font = new Font(labelProducto.Font, classApplication.buscarNodo("appConfig.xml", "producto", "fontBold").ToLower() == "true" ? FontStyle.Bold : labelProducto.Font.Style);
            labelProducto.Font = new Font(labelProducto.Font, classApplication.buscarNodo("appConfig.xml", "producto", "fontItalic").ToLower() == "true" ? FontStyle.Italic : labelProducto.Font.Style);
            labelProducto.Font = new Font(labelProducto.Font, classApplication.buscarNodo("appConfig.xml", "producto", "fontRegular").ToLower() == "true" ? FontStyle.Regular : labelProducto.Font.Style);
            labelProducto.Font = new Font(labelProducto.Font, classApplication.buscarNodo("appConfig.xml", "producto", "fontStrykeout").ToLower() == "true" ? FontStyle.Strikeout : labelProducto.Font.Style);
            labelProducto.Font = new Font(labelProducto.Font, classApplication.buscarNodo("appConfig.xml", "producto", "fontUnderline").ToLower() == "true" ? FontStyle.Underline : labelProducto.Font.Style);

            //Propiedad AutoSize
            labelProducto.AutoSize = classApplication.buscarNodo("appConfig.xml", "producto", "autoSize").ToLower() == "true" ? true : false;

            //Aliniacion del Label
            labelProducto.TextAlignment = classApplication.alineamientoContenido(classApplication.buscarNodo("appConfig.xml", "producto", "alignment"));

            //Visibilidad
            labelProducto.Visible = classApplication.buscarNodo("appConfig.xml", "producto", "visible").ToLower() == "true" ? true : false;

            //Dock
            labelProducto.Dock = classApplication.estiloDock(classApplication.buscarNodo("appConfig.xml", "producto", "dock"));

            //Anchor
            labelProducto.Anchor = classApplication.estiloAncho(classApplication.buscarNodo("appConfig.xml", "producto", "anchor"));

            #endregion  Estilo y Ubicacion del Label del producto


            #region     Estilo y Ubicacion del label del Alias

            //Texto
            labelAlias.Text = classApplication.buscarNodo("appConfig.xml", "identificacion", "alias");

            //Localizacion
            labelAlias.Location = new Point(int.Parse(classApplication.buscarNodo("appConfig.xml", "alias", "locationX")), int.Parse(classApplication.buscarNodo("appConfig.xml", "alias", "locationY")));

            //Color de Fondo
            labelAlias.BackColor = Color.FromName(classApplication.buscarNodo("appConfig.xml", "producto", "backColor"));

            //Color de la Letra
            labelAlias.ForeColor = Color.FromName(classApplication.buscarNodo("appConfig.xml", "producto", "foreColor"));

            //Fonts y Estilos
            labelAlias.Font = new Font(classApplication.buscarNodo("appConfig.xml", "alias", "fontName"), int.Parse(classApplication.buscarNodo("appConfig.xml", "alias", "fontSize")));
            labelAlias.Font = new Font(labelAlias.Font, classApplication.buscarNodo("appConfig.xml", "alias", "fontBold").ToLower() == "true" ? FontStyle.Bold : labelAlias.Font.Style);
            labelAlias.Font = new Font(labelAlias.Font, classApplication.buscarNodo("appConfig.xml", "alias", "fontItalic").ToLower() == "true" ? FontStyle.Italic : labelAlias.Font.Style);
            labelAlias.Font = new Font(labelAlias.Font, classApplication.buscarNodo("appConfig.xml", "alias", "fontRegular").ToLower() == "true" ? FontStyle.Regular : labelAlias.Font.Style);
            labelAlias.Font = new Font(labelAlias.Font, classApplication.buscarNodo("appConfig.xml", "alias", "fontStrykeout").ToLower() == "true" ? FontStyle.Strikeout : labelAlias.Font.Style);
            labelAlias.Font = new Font(labelAlias.Font, classApplication.buscarNodo("appConfig.xml", "alias", "fontUnderline").ToLower() == "true" ? FontStyle.Underline : labelAlias.Font.Style);

            //Propiedad AutoSize
            labelAlias.AutoSize = classApplication.buscarNodo("appConfig.xml", "alias", "autoSize").ToLower() == "true" ? true : false;

            //Aliniacion del Label
            labelAlias.TextAlignment = classApplication.alineamientoContenido(classApplication.buscarNodo("appConfig.xml", "alias", "alignment"));

            //Visibilidad
            labelAlias.Visible = classApplication.buscarNodo("appConfig.xml", "alias", "visible").ToLower() == "true" ? true : false;

            //Dock
            labelAlias.Dock = classApplication.estiloDock(classApplication.buscarNodo("appConfig.xml", "alias", "dock"));

            //Anchor
            labelAlias.Anchor = classApplication.estiloAncho(classApplication.buscarNodo("appConfig.xml", "alias", "anchor"));

            #endregion  Estilo y ubicacion del label del Alias


            this.Visible = true;
        }

        #endregion  Aplicar el Ambiente del Splash segun la configuracion del Archivo de la Aplicacion


        #region    Tick de Control de Avance del ProgressBar

        /// <summary>
        /// Tick del Timer del Progres Bar
        /// </summary>
        /// <param name="sender"> Objeto que activa el evento</param>
        /// <param name="e"> Argumento del Evento</param>
        private void timerProgressBarTick(object sender, EventArgs e)
        {
            if (radProgressBar.Value1 < radProgressBar.Maximum)
            {

                radProgressBar.Value1 = radProgressBar.Value1 + 1;
            }
            else
            {

                //this.Dispose();
                //this.Close();

            }
        }



        #endregion  Tick de Control de Avance del ProgressBar


        #region     Metodo Load del Splash Form

        /// <summary>
        /// Metodo Load del Splash Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splashFormLoad(object sender, EventArgs e)
        {

            timerProgressBar.Start();
            Thread threadSplashCharge = new Thread(loadThreadProcess);
            threadSplashCharge.Start();

        }

        #endregion  Metodo Load del Splash Form


        #region     Invocacion de Procesos Segundo Plano ProgressBar

        /// <summary>
        /// Procedimiento para invocacion de Procesos en Segundo Plano Progress Bar
        /// </summary>
        private void loadThreadProcess()
        {

            timerProgressBar.Start();
            this.Invoke((MethodInvoker)(() => setMessage("Verificando Archivos XML Configuracion...")));
            classApplication.verificarArchivosXMLAplicacion();
            radProgressBar.Value1 = 25;
            Thread.Sleep(2000);


            this.Invoke((MethodInvoker)(() => setMessage("Verificando Datos Iniciales de la Aplicacion...")));
            classApplication.verificarDataInicial();
            radProgressBar.Value1 = 50;
            Thread.Sleep(1500);

            this.Invoke((MethodInvoker)(() => setMessage("Aplicando Interfaz de Usuario Seleccionada...")));
            //Aplicar la interfaz a los controles Telerik
            ThemeResolutionService.ApplicationThemeName = classApplication.buscarNodo("appConfig.xml", "entorno", "interfaz");
            radProgressBar.Value1 = 75;
            Thread.Sleep(1500);

            this.Invoke((MethodInvoker)(() => setMessage("Invocando Control de Acceso de la Aplicacion...")));

            //Asignar Valor al Progress Bar de 100%
            radProgressBar.Value1 = 100;
            timerProgressBar.Stop();
            Thread.Sleep(1000);

            this.Invoke((MethodInvoker)delegate
            {

                loginForm loginForm = new loginForm();
                loginForm.Show();
                this.Close();

            });

        }

        #endregion     Invocacion de Procesos Segundo Plano ProgressBar


        #region     Despliegue de Mensajes Procesos de Segundo Plano

        /// <summary>
        /// Procedimiento de Despliegue de Mensajes Procesos de Segundo Plano
        /// </summary>
        /// <param name="stringParameterMessage">Mensaje Deseado</param>
        public void setMessage(string stringParameterMessage)
        {
            labelProgressMessage.Text = stringParameterMessage;
        }

        #endregion  Despliegue de Mensajes Procesos de Segundo Plano


    }
}


#endregion  Logica de la Clase, Segun NameSpace Especificado


#endregion  Estructura de Metodos, Propiedades, Procedimientos y Funciones de la clase indicada
