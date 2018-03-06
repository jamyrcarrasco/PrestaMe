#region    CopyRight

#endregion  CopyRight


#region     Uso e Invocacion de Librerias de clase a ser utilizadas

using PrestaMe.Layers.Application;
using PrestaMe.Layers.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

#endregion  Uso e Invocacion de Librerias de clase a ser utilizadas


#region     Logica de la Clase, Segun NameSpace Especificado

namespace PrestaMe.Windows.Forms
{


    #region     Estructura de Metodos, Propiedades, Procedimientos y Funciones de la clase indicada

    public partial class loginForm : RadForm
    {

        #region     Constructor sin Parametros

        public loginForm()
        {
            InitializeComponent();

            // Llenado de los Items del DropDown de Compañias Utilizando la classData con Esteroides
            radDropDownListCompañia.DisplayMember = "razonComercial";
            radDropDownListCompañia.ValueMember = "idCompañia";

            List<SqlParameter> listSqlParameter = new List<SqlParameter>()
            {
                new SqlParameter("@strTipoEjecucion", "SELECT"),
                new SqlParameter("@strCampos", "idCompañia, razonComercial"),
                new SqlParameter("@strTabla","compañias")
            };



            radDropDownListCompañia.DataSource = classData.conseguirDataTable("USP_General", listSqlParameter, CommandType.StoredProcedure);


            //listSqlParameter = null;

            ////Invocacion y llenado de dropdownList

            //radListControlSucursal.DisplayMember = "descripcion";
            //radListControlSucursal.ValueMember = "idSucursal";

            //listSqlParameter = new List<SqlParameter>()
            //{
            //    new SqlParameter("@strTipoEjecucion", "SELECT"),
            //    new SqlParameter("@strCampos", "idCompañia, idSucursal, descripcion"),
            //    new SqlParameter("@strTabla","sucursales"),
            //    new SqlParameter("@strCondicion", "sucursales.idCompañia = '" + radDropDownListCompañia.SelectedItem.Value + "'")
                 
            //};


            //radListControlSucursal.DataSource = classData.conseguirDataTable("USP_General", listSqlParameter, CommandType.StoredProcedure );


        }


        #endregion  Constructor sin Parametros

        private void radDropDownListCompañia_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
           
        }


        #endregion  Estructura de Metodos, Propiedades, Procedimientos y Funciones de la clase indicada

    

        private void radTextBoxUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == Convert.ToChar(Keys.Enter))
            //{
            //    List<SqlParameter> ListSqlparameter = new List<SqlParameter>()
            //    {
            //        new SqlParameter("@strTipoEjecucion", "SELECT"),
            //        new SqlParameter("@strCampos", "imagenUrl"),
            //        new SqlParameter("@strTabla", "usuarios")
            //    };

            //    pictureBoxCompañia = classData.conseguirSqlDataReader("USP_General", ListSqlparameter, CommandType.StoredProcedure);

                //MessageBox.Show("Enter pressed");
            }
        }
    }
}

#endregion  Logica de la Clase, Segun NameSpace Especificado
