using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/* == Referencias y Usos de Librerias == */

using System.IO;
using LibSSVP.Temporales;
using LibSSVP.Administracion;
using LibSSVP.Transacciones;
using LibSSVP.Operativa;
using System.Data;
using System.Xml;

using System.Net.Mail;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Text.RegularExpressions;

namespace appIntranet
{
    public partial class Formulario_web117 : System.Web.UI.Page
    {
        #region "Atributos"

        public static string strIp, strCambios, strCambiosAvaluo;
        static XmlDocument documento = new XmlDocument();
        public static bool cambio = false;
        public static bool cambioAval = false;        

        #endregion
        #region "Metodos"

        #region "XML"

        private static XmlNode CrearNodoXml(string User, string Fecha, string Desc)
        {
            //nodo que deseamos insertar.
            XmlElement Errores = documento.CreateElement("Error");

            XmlElement Nombre = documento.CreateElement("User");
            Nombre.InnerText = User;
            Errores.AppendChild(Nombre);

            XmlElement FechaErr = documento.CreateElement("Fecha");
            FechaErr.InnerText = Fecha;
            Errores.AppendChild(FechaErr);

            XmlElement Valor = documento.CreateElement("Desc");
            Valor.InnerText = Desc;
            Errores.AppendChild(Valor);

            return Errores;
        }
        private void InsertarXml(string dtmFecha, string strDescrip)
        {
            if (Session["id"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }

            //Cargamos el documento XML.
            documento = new XmlDocument();
            documento.Load(AppDomain.CurrentDomain.BaseDirectory + "Textos/XMLDataError.xml");

            //Creamos el nodo que deseamos insertar.
            XmlNode Datos = CrearNodoXml(Session["id"].ToString(), dtmFecha, strDescrip);

            //Obtenemos el nodo raiz del documento.
            XmlNode nodoRaiz = documento.DocumentElement;

            nodoRaiz.InsertAfter(Datos, documento.SelectNodes("Data/Error").Item(2));

            documento.Save(AppDomain.CurrentDomain.BaseDirectory + "Textos/XMLDataError.xml");
            //GridXML();
        }
        private string BusquedaIp()
        {
            if (!string.IsNullOrEmpty(Request.ServerVariables[""]))
                return strIp = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            else
                return strIp = Request.ServerVariables["REMOTE_ADDR"];
        }

        #endregion
        #region "Mensajeria"

        private void LimpiarMensajes()
        {
            for (int i = 1; i <= 4; i++)
            {
                Mensajes(i, string.Empty);
            }
            this.pnB.Visible = false;
            this.pnI.Visible = false;
            this.pnA.Visible = false;
            this.pnE.Visible = false;
        }
        private void Mensajes(int Op, string Msj)
        {
            pnBotones.Visible = false;

            switch (Op)
            {
                case 1:
                    pnB.Visible = true;
                    lblMsjB.Text = Msj;
                    VentanaEmg(1);
                    break;

                case 2:
                    pnI.Visible = true;
                    lblMsjI.Text = Msj;
                    VentanaEmg(1);
                    break;

                case 3:
                    pnA.Visible = true;
                    lblMsjA.Text = Msj;
                    VentanaEmg(1);
                    break;

                case 4:
                    pnE.Visible = true;
                    lblMsjE.Text = Msj;
                    VentanaEmg(1);
                    break;
            }
        }
        private void VentanaEmg(int Opc)
        {
            switch (Opc)
            {
                case 1:
                    pnMsjForm.Visible = true;
                    pnBusquedaC.Visible = false;
                    pnAuditoria.Visible = false;
                    //pnAlertaDup.Visible = false;
                    //pnValidarDoc.Visible = false;
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "MostrarModalJS();", true);
                    break;

                case 2:
                    pnMsjForm.Visible = false;
                    pnBusquedaC.Visible = true;
                    pnAuditoria.Visible = false;
                    //pnAlertaDup.Visible = false;
                    //pnValidarDoc.Visible = false;
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "MostrarModalJS();", true);
                    break;

                case 3:
                    pnMsjForm.Visible = false;
                    pnBusquedaC.Visible = false;
                    pnAuditoria.Visible = true;
                    //pnAlertaDup.Visible = false;
                    //pnValidarDoc.Visible = false;
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "MostrarModalJS();", true);
                    break;

                case 4:
                    pnMsjForm.Visible = false;
                    pnBusquedaC.Visible = false;
                    pnAuditoria.Visible = false;
                    //pnAlertaDup.Visible = true;
                    //pnValidarDoc.Visible = false;
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "MostrarModalJS();", true);
                    break;

                case 5:
                    pnMsjForm.Visible = false;
                    pnBusquedaC.Visible = false;
                    pnAuditoria.Visible = false;
                    //pnAlertaDup.Visible = false;
                    //pnValidarDoc.Visible = true;
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "MostrarModalJS();", true);
                    break;

                case 10:
                    string script = "window.open('emg-EdtListas.aspx','','height=500,width=400 ,directories=false,status=0,toolbar=0,center=yes;menubar=0,help=no;scrollbars=no,RESIZABLE=no')";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "openwindow", script, true);
                    break;
            }
        }

        #endregion
        #region "Listas Desplegables"

        private void ComboTipoInmueble()
        {
            clsListasGn objapp = new clsListasGn();

            objapp.ComboListas = ddlTInm;
            objapp.CodEmp = (int)Session["emp"];
            objapp.LtRef = 60;
            objapp.EstLt = 1;

            if (objapp.ListarCombos())
            {
                ddlTInm = objapp.ComboListas;
                ddlTInm.SelectedValue = "60";
                objapp = null;
                return;
            }
            else
            {
                InsertarXml(DateTime.Now.ToString(), objapp.ErrorInterno);
                objapp = null;
                return;
            }
        }
        private void ComboConferencias()
        {
            clsConferencia objapp = new clsConferencia();

            objapp.ComboConferencia = ddlConf;
            objapp.CodEmp = (int)Session["emp"];

            if (objapp.ListarComboConferencias())
            {
                ddlConf = objapp.ComboConferencia;
                ListItem oItem = new ListItem("Sin Especificar", "0");
                ddlConf.Items.Add(oItem);
                ddlConf.SelectedValue = "0";
                objapp = null;
                return;
            }
            else
            {
                InsertarXml(DateTime.Now.ToString(), objapp.ErrorInterno);
                objapp = null;
                return;
            }
        }
        private void ComboDepartamento(int pais)
        {
            clsListasGn objapp = new clsListasGn();

            objapp.ComboListas = ddlDep;
            objapp.CodEmp = (int)Session["emp"];
            objapp.LtRef = 18;
            objapp.LtCod = pais;
            objapp.EstLt = 1;

            if (objapp.ListarCombos())
            {
                ddlDep = objapp.ComboListas;
                ListItem oItem = new ListItem("Departamento", "0");
                ddlDep.Items.Add(oItem);
                ddlDep.SelectedValue = "0";
                objapp = null;
                return;
            }
            else
            {
                InsertarXml(DateTime.Now.ToString(), objapp.ErrorInterno);
                objapp = null;
                return;
            }
        }
        private void ComboMunicipio(int Dep)
        {
            clsListasGn objapp = new clsListasGn();

            objapp.ComboListas = ddlMun;
            objapp.CodEmp = (int)Session["emp"];
            objapp.LtRef = 19;
            objapp.LtCod = Dep;
            objapp.EstLt = 1;

            if (objapp.ListarCombos())
            {
                ddlMun = objapp.ComboListas;
                ListItem oItem = new ListItem("Municipio", "0");
                ddlMun.Items.Add(oItem);
                ddlMun.SelectedValue = "0";
                ddlMun.Enabled = true;
                objapp = null;
                return;
            }
            else
            {
                InsertarXml(DateTime.Now.ToString(), objapp.ErrorInterno);
                objapp = null;
                return;
            }
        }
        private void ComboBarrio(int Mun)
        {
            clsListasGn objapp = new clsListasGn();

            objapp.ComboListas = ddlBarrio;
            objapp.CodEmp = (int)Session["emp"];
            objapp.LtRef = 61;
            objapp.LtCod = Mun;
            objapp.EstLt = 1;

            if (objapp.ListarCombos())
            {
                ddlBarrio = objapp.ComboListas;
                ListItem oItem = new ListItem("Barrio", "0");
                ddlBarrio.Items.Add(oItem);
                ddlBarrio.SelectedValue = "0";
                ddlBarrio.Enabled = true;
                objapp = null;
                return;
            }
            else
            {
                InsertarXml(DateTime.Now.ToString(), objapp.ErrorInterno);
                objapp = null;
                return;
            }
        }

        private void ComboTipoAvaluo()
        {
            clsListasGn objapp = new clsListasGn();

            objapp.ComboListas = ddlTAval;
            objapp.CodEmp = (int)Session["emp"];
            objapp.LtRef = 64;
            objapp.EstLt = 1;

            if (objapp.ListarCombos())
            {
                ddlTAval = objapp.ComboListas;
                ddlTAval.SelectedValue = "64";
                objapp = null;
                return;
            }
            else
            {
                InsertarXml(DateTime.Now.ToString(), objapp.ErrorInterno);
                objapp = null;
                return;
            }
        }
        private void ComboFiltroAños()
        {
            clsInmuebles objapp = new clsInmuebles();

            objapp.ComboListas = ddlFAñoInm;
            objapp.CodInm = Convert.ToInt32(lblCod.Text);

            if (objapp.ListarComboAñosAvaluo())
            {
                ddlFAñoInm = objapp.ComboListas;
                ListItem oItem = new ListItem("Año", "0");
                ddlFAñoInm.Items.Add(oItem);
                ddlFAñoInm.SelectedValue = "0";
                objapp = null;
                return;
            }
            else
            {
                InsertarXml(DateTime.Now.ToString(), objapp.Error);
                objapp = null;
                return;
            }
        }
        private void ComboFiltroTAvaluo()
        {
            clsListasGn objapp = new clsListasGn();

            objapp.ComboListas = ddlFTAvaluo;
            objapp.CodEmp = (int)Session["emp"];
            objapp.LtRef = 64;
            objapp.EstLt = 1;

            if (objapp.ListarCombos())
            {
                ddlFTAvaluo = objapp.ComboListas;
                ddlFTAvaluo.SelectedValue = "64";
                objapp = null;
                return;
            }
            else
            {
                InsertarXml(DateTime.Now.ToString(), objapp.ErrorInterno);
                objapp = null;
                return;
            }
        }

        private void ComboTipoDetalle()
        {
            clsListasGn objapp = new clsListasGn();

            objapp.ComboListas = ddlTDetInm;
            objapp.CodEmp = (int)Session["emp"];
            objapp.LtRef = 65;
            objapp.EstLt = 1;

            if (objapp.ListarCombos())
            {
                ddlTDetInm = objapp.ComboListas;
                ddlTDetInm.SelectedValue = "65";
                objapp = null;
                return;
            }
            else
            {
                InsertarXml(DateTime.Now.ToString(), objapp.ErrorInterno);
                objapp = null;
                return;
            }
        }
        private void ComboFiltroTDetalle()
        {
            clsListasGn objapp = new clsListasGn();

            objapp.ComboListas = ddlFTipoDet;
            objapp.CodEmp = (int)Session["emp"];
            objapp.LtRef = 65;
            objapp.EstLt = 1;

            if (objapp.ListarCombos())
            {
                ddlFTipoDet = objapp.ComboListas;
                ddlFTipoDet.SelectedValue = "65";
                objapp = null;
                return;
            }
            else
            {
                InsertarXml(DateTime.Now.ToString(), objapp.ErrorInterno);
                objapp = null;
                return;
            }
        }
        private void ComboFiltroEstadoDt()
        {
            ListItem oItem = new ListItem("Todos", "0");
            ListItem oItem1 = new ListItem("Activo", "1");
            ListItem oItem2 = new ListItem("Inactivo", "2");
            ddlFEstDet.Items.Add(oItem);
            ddlFEstDet.Items.Add(oItem1);
            ddlFEstDet.Items.Add(oItem2);
            ddlFEstDet.SelectedValue = "0";
        }

        #endregion
        #region "Validaciones"

        public bool ValidarAccion(int e)
        {
            if (Session["id"] == null || Session["rol"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }

            if (!AccionesOtorgadas())
                return false;

            DataTable dtTmp = new DataTable();
            dtTmp = (DataTable)Session["LtEj"];

            for (int i = 0; i < dtTmp.Rows.Count; i++)
            {
                if ((int)dtTmp.Rows[i][5] == e)
                    return true;
            }

            dtTmp = null;
            return false;
        }
        private bool AccionesOtorgadas()
        {
            if (Session["id"] == null || Session["rol"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }

            clsSeguridad objapp = new clsSeguridad();

            objapp.CodEmp = (Int32)Session["emp"];
            objapp.IDRol = (Int32)Session["rol"];
            objapp.CodProg = 601;

            if (objapp.AccionesOtorgados())
            {
                Session["LtEj"] = objapp.TablaSeguridad;
                objapp = null;
                return true;
            }
            else
            {
                InsertarXml(DateTime.Now.ToString(), objapp.ErrorInterno);
                objapp = null;
                return false;
            }
        }
        private void ValidarEdicionListas()
        {
            if (Session["id"] == null || Session["rol"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }

            if (ValidarAccion(1605))
            {
                Session["intEditL"] = "1"; // Permite crear y Actualizar
            }
            else
            {
                Session["intEditL"] = "0"; // Permite Actualizar 
                ibtnUTInm.Visible = true;
                ibtnATInm.Visible = false;
                ibtnUTAval.Visible = true;
                ibtnATAval.Visible = false;
                ibtnUTDet.Visible = true;
                ibtnATDet.Visible = false;
            }
        }
        private void ValidarCreaEditaLt(int e, int a) //e lista desplegable, a titulo
        {
            string[] vec = new string[2];
            if (e == a)
            {
                vec[0] = "0"; // Si nuevo item el codigo es 0, sino el codigo es el item que se actualiza
                vec[1] = a.ToString(); // Tituto al que se le creara el contenido
                Session["dt"] = vec;
            }
            else
            {
                vec[0] = e.ToString(); // Si nuevo item el codigo es 0, sino el codigo es el item que se actualiza
                vec[1] = a.ToString(); // Tituto al que se le creara el contenido
                Session["dt"] = vec;
            }
        }

        private void ValidarCambios(DataTable act)
        {
            if (Session["CabOrigen"] == null)
            {
                cambio = true;
                return;
            }

            DataTable tmp = (DataTable)Session["CabOrigen"];
            strCambios = "se actualizo: ";
            int j = 9;

            for (int i = 0; i < tmp.Columns.Count; i++)
            {
                j = j + 1;
                if (tmp.Rows[0][i].ToString() != act.Rows[0][i].ToString())
                {
                    strCambios += "'" + act.Rows[0][j].ToString() + "': (" + tmp.Rows[0][i].ToString() + ") por (" + act.Rows[0][i].ToString() + "), ";
                    cambio = true;
                }
            }

            LimpiarMensajes();
            Mensajes(2, strCambios);
            return;

        }
        private DataTable DtCabActual()
        {
            DataTable tmp = new DataTable();

            tmp.Columns.Add("Referencia", typeof(string));
            tmp.Columns.Add("Matricula", typeof(string));
            tmp.Columns.Add("Tipo Inmueble", typeof(string));
            tmp.Columns.Add("Ubicación", typeof(string));
            tmp.Columns.Add("Conferencia", typeof(string));
            tmp.Columns.Add("Dirección", typeof(string));
            tmp.Columns.Add("Telefono", typeof(string));
            tmp.Columns.Add("Estrato", typeof(string));
            tmp.Columns.Add("Ciclo", typeof(string));
            tmp.Columns.Add("Estado", typeof(string)); 

            tmp.Columns.Add("1", typeof(string));
            tmp.Columns.Add("2", typeof(string));
            tmp.Columns.Add("3", typeof(string));
            tmp.Columns.Add("4", typeof(string));
            tmp.Columns.Add("5", typeof(string));
            tmp.Columns.Add("6", typeof(string));
            tmp.Columns.Add("7", typeof(string));
            tmp.Columns.Add("8", typeof(string));
            tmp.Columns.Add("9", typeof(string));
            tmp.Columns.Add("10", typeof(string)); 

            DataRow drFilaAlt = tmp.NewRow();

            drFilaAlt["Referencia"] = txtRef.Value;
            drFilaAlt["Matricula"] = txtMatricula.Value;
            drFilaAlt["Tipo Inmueble"] = ddlTInm.SelectedValue;
            drFilaAlt["Ubicación"] = ddlBarrio.SelectedValue;
            drFilaAlt["Conferencia"] = ddlConf.SelectedValue;
            drFilaAlt["Dirección"] = txtDir.Value;
            drFilaAlt["Telefono"] = txtTel.Value;
            drFilaAlt["Estrato"] = txtEstrato.Value;
            drFilaAlt["Ciclo"] = txtCiclo.Value;            
            drFilaAlt["Estado"] = chkEstado.Checked;

            drFilaAlt["1"] = "Referencia";
            drFilaAlt["2"] = "Matricula";
            drFilaAlt["3"] = "Tipo Inmueble";
            drFilaAlt["4"] = "Ubicación";
            drFilaAlt["5"] = "Conferencia";
            drFilaAlt["6"] = "Dirección";
            drFilaAlt["7"] = "Telefono";
            drFilaAlt["8"] = "Estrato";
            drFilaAlt["9"] = "Ciclo";
            drFilaAlt["10"] = "Estado";           

            tmp.Rows.Add(drFilaAlt);

            return tmp;
        }
        private void DtCabOrigen()
        {
            DataTable tmp = new DataTable();

            tmp.Columns.Add("Referencia", typeof(string));
            tmp.Columns.Add("Matricula", typeof(string));
            tmp.Columns.Add("Tipo Inmueble", typeof(string));
            tmp.Columns.Add("Ubicación", typeof(string));
            tmp.Columns.Add("Conferencia", typeof(string));
            tmp.Columns.Add("Dirección", typeof(string));
            tmp.Columns.Add("Telefono", typeof(string));
            tmp.Columns.Add("Estrato", typeof(string));
            tmp.Columns.Add("Ciclo", typeof(string));
            tmp.Columns.Add("Estado", typeof(string));

            DataRow drFilaAlt = tmp.NewRow();

            drFilaAlt["Referencia"] = txtRef.Value;
            drFilaAlt["Matricula"] = txtMatricula.Value;
            drFilaAlt["Tipo Inmueble"] = ddlTInm.SelectedValue;
            drFilaAlt["Ubicación"] = ddlBarrio.SelectedValue;
            drFilaAlt["Conferencia"] = ddlConf.SelectedValue;
            drFilaAlt["Dirección"] = txtDir.Value;
            drFilaAlt["Telefono"] = txtTel.Value;
            drFilaAlt["Estrato"] = txtEstrato.Value;
            drFilaAlt["Ciclo"] = txtCiclo.Value;
            drFilaAlt["Estado"] = chkEstado.Checked;

            tmp.Rows.Add(drFilaAlt);

            Session["CabOrigen"] = tmp;
        }

        private void LimpiarFrmGnr()
        {
            Session["CabOrigen"] = null;
            cambio = false;
            strCambios = string.Empty;

            Session["AvalOrigen"] = null;
            cambioAval = false;
            strCambiosAvaluo = string.Empty;

            pnCreoUdp.Visible = false;
            lblCreoUdp.Text = string.Empty;

            lblCod.Text = "0";
            ddlTInm.SelectedValue = "60";
            txtRef.Value = string.Empty;
            chkEstado.Checked = true;
            txtMatricula.Value = string.Empty;
            pnAvaluos.Visible = false;
            pnDetalle.Visible = false;
            ddlDep.SelectedValue = "0";
            ddlDep_SelectedIndexChanged(null, null);
            txtDir.Value = string.Empty;
            txtTel.Value = string.Empty;
            txtEstrato.Value = string.Empty;
            txtCiclo.Value = string.Empty;
            ddlConf.SelectedValue = "0";

            LimpiarAvaluo();
            grvAvaluos.DataSource = null;
            grvAvaluos.DataBind();
            lblMsjGridAvaluo.Text = "sin registros";

            LimpiarDetalle();
            grvDetalle.DataSource = null;
            grvDetalle.DataBind();
            lblMsjGridDet.Text = "sin registros";

        }
        private void HabilitarBusqueda()
        {
            if (Session["id"] == null || Session["rol"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }

            if (!ValidarAccion(1602))
            {
                LimpiarMensajes();
                Mensajes(3, "No tiene privilegios para realizar esta acción, contacte al administrador del sistema.");
                return;
            }

            ObtenerListarBComun();
            VentanaEmg(2);
            return;
        }

        private void Nuevo()
        {
            if (Session["id"] == null || Session["rol"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }

            if (!ValidarAccion(1600))
            {
                LimpiarMensajes();
                Mensajes(3, "No tiene privilegios para realizar esta acción, contacte al administrador del sistema.");
                return;
            }

            LimpiarFrmGnr();
            btnProcesar.Enabled = true;
            pnDatos.Visible = true;
        }
        private bool ValidarCamposBase()
        {
            if (string.IsNullOrEmpty(txtRef.Value))
            {
                Mensajes(3, "** No ha Ingresado la referencia del inmueble, complete el campo para continuar **");
                txtRef.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMatricula.Value))
            {
                Mensajes(3, "** No ha Ingresado la matricula del inmueble, complete el campo para continuar **");
                txtMatricula.Focus();
                return false;
            }
            if (ddlTInm.SelectedValue == "60")
            {
                Mensajes(3, "** No ha seleccionado el tipo de inmueble, complete el campo para continuar **");
                ddlTInm.Focus();
                return false;
            }
            if (ddlDep.SelectedValue == "0" || ddlMun.SelectedValue == "0" || ddlBarrio.SelectedValue == "0")
            {
                Mensajes(3, "** No ha seleccionado la ubicación del inmueble, complete el campo para continuar **");
                return false;
            }
            if (ddlConf.SelectedValue == "0")
            {
                Mensajes(3, "** No ha seleccionado la conferencia del inmueble, complete el campo para continuar **");
                ddlConf.Focus();
                return false;
            }           
            if (string.IsNullOrEmpty(txtDir.Value))
            {
                Mensajes(3, "** No ha Ingresado la dirección del inmueble, complete el campo para continuar **");
                txtDir.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTel.Value))
            {
                Mensajes(3, "** No ha Ingresado el telefono del inmueble, complete el campo para continuar **");
                txtTel.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtEstrato.Value))
            {
                Mensajes(3, "** No ha Ingresado el estrato del inmueble, complete el campo para continuar **");
                txtEstrato.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtCiclo.Value))
            {
                Mensajes(3, "** No ha Ingresado el ciclo del inmueble, complete el campo para continuar **");
                txtCiclo.Focus();
                return false;
            }

            return true;
        }
        private bool ValidarReferencia()
        {
            if (Session["id"] == null || Session["rol"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }

            clsInmuebles objapp = new clsInmuebles();
            objapp.CodEmp = (int)Session["emp"];
            objapp.VrUnico = txtRef.Value;            

            if (!objapp.ObtenerListarInmueble())
            {
                LimpiarMensajes();
                Mensajes(4, objapp.Error);
                InsertarXml(DateTime.Now.ToShortDateString(), objapp.Error);
                objapp = null;
                return false;
            }

            if (objapp.TablaInmueble.Rows.Count > 0)
            {
                for (int i = 0; i < objapp.TablaInmueble.Rows.Count; i++)
                {
                    if (objapp.TablaInmueble.Rows[i][1].ToString() != txtRef.Value)
                    {
                        LimpiarMensajes();
                        Mensajes(3, "Esta referencia ya fue registrada en el sistema.");
                        return false;
                    }
                }
            }

            objapp = null;
            return true;
        }

        #endregion
        #region "Avaluos"

        private bool ValidarLapso()
        {
            if (Session["id"] == null || Session["rol"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }

            clsInmuebles objapp = new clsInmuebles();

            objapp.CodInm = Convert.ToInt32(lblCod.Text);
            objapp.EstadoInm = Convert.ToDateTime(txtFIniAval.Value).Year;
            objapp.CodLt = Convert.ToInt32(ddlTAval.SelectedValue);

            if (!objapp.ObtenerListarAvaluo())
            {
                LimpiarMensajes();
                Mensajes(4, objapp.Error);
                return false;
            }

            if (objapp.TablaAvaluo.Rows.Count > 0)
            {
                for (int i = 0; i < objapp.TablaAvaluo.Rows.Count; i++)
                {
                    if (objapp.TablaAvaluo.Rows[0][0].ToString() != txtCodAvaluo.Value)
                    {
                        LimpiarMensajes();
                        Mensajes(3, "el año al que hace referencia el lapso de fecha ingresado, ya presenta un: <strong>" + ddlTAval.SelectedItem.ToString() + "<strong>");
                        return false;
                    }
                } 
            }

            return true;
        }
        private bool ValidarCampoAvaluo()
        {
            if (ddlTAval.SelectedValue == "64")
            {
                Mensajes(3, "** No ha seleccionado el tipo de avaluo para el inmueble, complete el campo para continuar **");
                ddlTAval.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtFIniAval.Value) || string.IsNullOrEmpty(txtFFinAval.Value))
            {
                Mensajes(3, "** No ha ingresado el lapso de fecha para avaluo del inmueble, complete el campo para continuar **");
                txtFIniAval.Focus();
                return false;
            }
            if (Convert.ToDateTime(txtFIniAval.Value) > Convert.ToDateTime(txtFFinAval.Value))
            {
                Mensajes(3, "** Lapso de fecha errado, valide el campo para continuar **");
                txtFIniAval.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtAvaluo.Value))
            {
                Mensajes(3, "** No ha ingresado el avaluo para el inmueble, complete el campo para continuar **");
                txtAvaluo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNotaAval.Value))
                txtNotaAval.Value = "";

            return true;
        }
        private void ValidarCambiosAvaluo(DataTable act)
        {
            if (Session["AvalOrigen"] == null)
            {
                cambioAval = true;
                return;
            }

            DataTable tmp = (DataTable)Session["AvalOrigen"];
            strCambiosAvaluo = "se actualizo: ";
            int j = 4;

            for (int i = 0; i < tmp.Columns.Count; i++)
            {
                j = j + 1;
                if (tmp.Rows[0][i].ToString() != act.Rows[0][i].ToString())
                {
                    strCambiosAvaluo += "'" + act.Rows[0][j].ToString() + "': (" + tmp.Rows[0][i].ToString() + ") por (" + act.Rows[0][i].ToString() + "), ";
                    cambioAval = true;
                }
            }

            LimpiarMensajes();
            Mensajes(2, strCambiosAvaluo);
            return;

        }
        private DataTable DtAvaluoActual()
        {
            DataTable tmp = new DataTable();

            tmp.Columns.Add("Tipo Avaluo", typeof(string));
            tmp.Columns.Add("Fecha Inicial", typeof(string));
            tmp.Columns.Add("Fecha Final", typeof(string));
            tmp.Columns.Add("Avaluo", typeof(string));
            tmp.Columns.Add("Nota", typeof(string));

            tmp.Columns.Add("1", typeof(string));
            tmp.Columns.Add("2", typeof(string));
            tmp.Columns.Add("3", typeof(string));
            tmp.Columns.Add("4", typeof(string));
            tmp.Columns.Add("5", typeof(string));

            DataRow drFilaAlt = tmp.NewRow();

            drFilaAlt["Tipo Avaluo"] = txtRef.Value;
            drFilaAlt["Fecha Inicial"] = txtMatricula.Value;
            drFilaAlt["Fecha Final"] = ddlTInm.SelectedValue;
            drFilaAlt["Avaluo"] = ddlBarrio.SelectedValue;
            drFilaAlt["Nota"] = ddlConf.SelectedValue;

            drFilaAlt["1"] = "Tipo Avaluo";
            drFilaAlt["2"] = "Fecha Inicial";
            drFilaAlt["3"] = "Fecha Final";
            drFilaAlt["4"] = "Avaluo";
            drFilaAlt["5"] = "Nota";

            tmp.Rows.Add(drFilaAlt);

            return tmp;
        }
        private void DtAvaluoOrigen()
        {
            DataTable tmp = new DataTable();

            tmp.Columns.Add("Tipo Avaluo", typeof(string));
            tmp.Columns.Add("Fecha Inicial", typeof(string));
            tmp.Columns.Add("Fecha Final", typeof(string));
            tmp.Columns.Add("Avaluo", typeof(string));
            tmp.Columns.Add("Nota", typeof(string));            

            DataRow drFilaAlt = tmp.NewRow();

            drFilaAlt["Tipo Avaluo"] = ddlTDetInm.SelectedValue;
            drFilaAlt["Fecha Inicial"] = txtFIniAval.Value;
            drFilaAlt["Fecha Final"] = txtFFinAval.Value;
            drFilaAlt["Avaluo"] = txtAvaluo.Value;
            drFilaAlt["Nota"] = txtNotaAval.Value;

            tmp.Rows.Add(drFilaAlt);

            Session["AvalOrigen"] = tmp;
        }
        private void ListarAvaluos()
        {
            if (Session["id"] == null || Session["rol"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }

            clsInmuebles objapp = new clsInmuebles();

            objapp.CodInm = Convert.ToInt32(lblCod.Text);
            if (ddlFTAvaluo.SelectedValue == "64")
                objapp.CodLt = 0;
            else
                objapp.CodLt = Convert.ToInt32(ddlFTAvaluo.SelectedValue);
            objapp.EstadoInm = Convert.ToInt32(ddlFAñoInm.SelectedValue);

            if (objapp.ObtenerListarAvaluo())
            {
                grvAvaluos.DataSource = objapp.TablaAvaluo;
                grvAvaluos.DataBind();

                if (objapp.TablaAvaluo.Rows.Count < 1)
                {
                    grvAvaluos.DataSource = null;
                    grvAvaluos.DataBind();
                    lblMsjGridAvaluo.Text = "Sin registros";
                }
                else
                    lblMsjGridAvaluo.Text = string.Empty;

                objapp = null;
                return;
            }
            else
            {
                grvAvaluos.DataSource = null;
                grvAvaluos.DataBind();
                lblMsjGridAvaluo.Text = "Sin registros";
                objapp = null;
                return;
            }
        }
        private void LimpiarAvaluo()
        {
            txtCodAvaluo.Value = "0";
            ddlTAval.SelectedValue = "64";
            txtFIniAval.Value = string.Empty;
            txtFFinAval.Value = string.Empty;
            txtAvaluo.Value = string.Empty;
            txtNotaAval.Value = string.Empty;
            Session["AvalOrigen"] = null;
            cambioAval = false;
            strCambiosAvaluo = string.Empty;
        }
        private void ObtenerInfoAvaluos(int Cod)
        {
            if (Session["id"] == null || Session["rol"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }

            clsInmuebles objapp = new clsInmuebles();
            objapp.CodAval = Cod;

            if (!objapp.ObtenerListarAvaluo())
            {
                LimpiarMensajes();
                Mensajes(4, objapp.Error);
                InsertarXml(DateTime.Now.ToShortDateString(), objapp.Error);
                objapp = null;
                return;
            }

            LimpiarAvaluo();
            pnCreaUdpAval.Visible = true;
            lblCreaUdpAval.Text = string.Empty;
            lblCreaUdpAval.Text = "Elaboro: " + objapp.TablaAvaluo.Rows[0][11].ToString() + "<br/> Fecha Elaboro:" + objapp.TablaAvaluo.Rows[0][9].ToString() +
                              "<br/> Actualizo:" + objapp.TablaAvaluo.Rows[0][14].ToString() + "<br/> Fecha Actualizo: " + objapp.TablaAvaluo.Rows[0][12].ToString();

            txtCodAvaluo.Value = objapp.TablaAvaluo.Rows[0][0].ToString();
            ddlTAval.SelectedValue = objapp.TablaAvaluo.Rows[0][2].ToString();
            txtFIniAval.Value = objapp.TablaAvaluo.Rows[0][4].ToString();
            txtFFinAval.Value = objapp.TablaAvaluo.Rows[0][5].ToString();
            txtAvaluo.Value = objapp.TablaAvaluo.Rows[0][6].ToString();
            txtNotaAval.Value = objapp.TablaAvaluo.Rows[0][7].ToString();

            AuditoriaIndivAvaluo(131);
            DtAvaluoOrigen();

            grvAvaluos.Focus();
            objapp = null;
            return;
        }
        private void GrabarActualizarAvaluoInmueble()
        {
            if (Session["id"] == null || Session["rol"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }

            if (!ValidarAccion(1606))
            {
                LimpiarMensajes();
                Mensajes(3, "No tiene privilegios para realizar esta accion, contacte a la mesa de ayuda.");
                return;
            }

            ValidarCambiosAvaluo(DtAvaluoActual());
            if (cambioAval == false)
            {
                LimpiarMensajes();
                Mensajes(2, "No se encontraron cambios en la información de avaluos.");
                return;
            }

            try
            {
                if (!ValidarCampoAvaluo())
                    return;

                if (!ValidarLapso())
                    return;

                clsTRNInmuebles objapp = new clsTRNInmuebles();

                objapp.CodEmp = (Int32)Session["emp"];
                objapp.CodAval = Convert.ToInt32(txtCodAvaluo.Value);
                objapp.CodInm = Convert.ToInt32(lblCod.Text);
                objapp.Fecha = Convert.ToDateTime(txtFIniAval.Value);
                objapp.Fecha2 = Convert.ToDateTime(txtFFinAval.Value);
                objapp.MonetAval = Convert.ToDecimal(txtAvaluo.Value);
                objapp.CodLt = Convert.ToInt32(ddlTAval.SelectedValue);
                objapp.NotAval = txtNotaAval.Value;                

                objapp.IDEmdC = (int)Session["id"];
                objapp.IDEmdU = (int)Session["id"];

                // Parametros de Auditoria
                objapp.CodEmp = (Int32)Session["emp"];
                if (objapp.CodAval == 0)
                {
                    objapp.IDTpAdt = 133;
                    objapp.DescAdt = "Creación de Nuevo: " + ddlTAval.SelectedItem.ToString() + " Exitosamente." + strCambios;
                    objapp.IDTrnAdt = 0;
                }
                else
                {
                    objapp.IDTpAdt = 134;
                    objapp.DescAdt = "Actualización de: " + ddlTAval.SelectedItem.ToString() + " Exitosamente. " + strCambios;
                    objapp.IDTrnAdt = Convert.ToInt32(lblCod.Text);
                }
                objapp.IDUsrAdt = (Int32)Session["id"];
                objapp.NmUsCreaAdt = Session["nm"].ToString();
                objapp.IDProgAdt = 601;
                objapp.IPAdt = BusquedaIp();
                objapp.NmPCAdt = System.Net.Dns.GetHostEntry(BusquedaIp()).HostName;

                if (!objapp.AgregarModificarTrnAvaluo())
                {
                    LimpiarMensajes();
                    InsertarXml(DateTime.Now.ToShortDateString(), objapp.Error);
                    Mensajes(4, objapp.Error);
                    return;
                }

                LimpiarMensajes();
                Mensajes(1, "<strong>" + ddlTAval.SelectedItem.ToString() + "</strong> procesado exitosamente en la base de Datos.");

                ComboFiltroAños();
                ListarAvaluos();
                LimpiarAvaluo();
                grvAvaluos.Focus();
                objapp = null;
                return;
            }
            catch (Exception e)
            {
                LimpiarMensajes();
                Mensajes(3, e.Message);
                return;
            }
        }
        private void AuditoriaIndivAvaluo(int sw)
        {
            clsInmuebles objapp = new clsInmuebles();

            // Parametros de Auditoria
            objapp.CodEmp = (Int32)Session["emp"];
            if (sw == 130) //Busca datos
            {
                objapp.IDTpAdt = sw;
                objapp.DescAdt = "Busqueda de avaluo en programa 601 - Control de inmueble. ";
                objapp.IDTrnAdt = 0; //Todos
            }
            if (sw == 131) //Obtener datos
            {
                objapp.IDTpAdt = sw;
                objapp.DescAdt = "Se obtuvo información del: " + ddlTAval.SelectedValue + " con id: " + txtCodAvaluo.Value;
                objapp.IDTrnAdt = Convert.ToInt32(lblCod.Text);
            }

            objapp.IDUsrAdt = (Int32)Session["id"];
            objapp.NmUsCreaAdt = Session["nm"].ToString();
            objapp.IDProgAdt = 601;
            objapp.IPAdt = BusquedaIp();
            objapp.NmPCAdt = System.Net.Dns.GetHostEntry(BusquedaIp()).HostName;

            if (!objapp.CrearAuditoria())
            {
                LimpiarMensajes();
                InsertarXml(DateTime.Now.ToShortDateString(), objapp.Error);
                Mensajes(4, objapp.Error);
                return;
            }
        }

        #endregion
        #region "Detalle"

        private bool ValidarCampoDetalle()
        {
            if (ddlTDetInm.SelectedValue == "65")
            {
                Mensajes(3, "** No ha seleccionado el tipo de detalle para el inmueble, complete el campo para continuar **");
                ddlTDetInm.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtConcep.Value))
                txtConcep.Value = "0";

            return true;
        }
        private void ListarDetalle()
        {
            if (Session["id"] == null || Session["rol"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }

            clsInmuebles objapp = new clsInmuebles();

            objapp.CodInm = Convert.ToInt32(lblCod.Text);
            if (ddlFTipoDet.SelectedValue == "65")
                objapp.CodLt = 0;
            else
                objapp.CodLt = Convert.ToInt32(ddlFTipoDet.SelectedValue);
            objapp.EstadoDtInm = Convert.ToInt32(ddlFEstDet.SelectedValue);

            if (objapp.ObtenerListarDtInmueble())
            {
                grvDetalle.DataSource = objapp.TablaDtInmueble;
                grvDetalle.DataBind();

                if (objapp.TablaDtInmueble.Rows.Count < 1)
                {
                    grvDetalle.DataSource = null;
                    grvDetalle.DataBind();
                    lblMsjGridDet.Text = "Sin registros";
                }
                else
                    lblMsjGridDet.Text = string.Empty;

                objapp = null;
                return;
            }
            else
            {
                grvDetalle.DataSource = null;
                grvDetalle.DataBind();
                lblMsjGridDet.Text = "Sin registros";
                objapp = null;
                return;
            }
        }
        private void LimpiarDetalle()
        {
            txtCodDet.Value = "0";
            ddlTDetInm.SelectedValue = "65";
            txtFecha.Value = string.Empty;
            txtDesc.Value = string.Empty;
            txtConcep.Value = string.Empty;            
        }
        private void ObtenerInfoDetalle(int Cod)
        {
            if (Session["id"] == null || Session["rol"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }

            clsInmuebles objapp = new clsInmuebles();
            objapp.CodDtInm = Cod;

            if (!objapp.ObtenerListarDtInmueble())
            {
                LimpiarMensajes();
                Mensajes(4, objapp.Error);
                InsertarXml(DateTime.Now.ToShortDateString(), objapp.Error);
                objapp = null;
                return;
            }

            LimpiarDetalle();
            pnCreaUdpDet.Visible = true;
            lblCreaUdpDet.Text = string.Empty;
            lblCreaUdpDet.Text = "Elaboro: " + objapp.TablaDtInmueble.Rows[0][11].ToString() + "<br/> Fecha Elaboro:" + objapp.TablaDtInmueble.Rows[0][9].ToString() +
                              "<br/> Actualizo:" + objapp.TablaAvaluo.Rows[0][14].ToString() + "<br/> Fecha Actualizo: " + objapp.TablaDtInmueble.Rows[0][12].ToString();

            txtCodDet.Value = objapp.TablaDtInmueble.Rows[0][0].ToString();
            ddlTDetInm.SelectedValue = objapp.TablaDtInmueble.Rows[0][2].ToString();
            txtDesc.Value = objapp.TablaDtInmueble.Rows[0][4].ToString();
            txtFecha.Value = objapp.TablaDtInmueble.Rows[0][5].ToString();
            txtConcep.Value = objapp.TablaDtInmueble.Rows[0][6].ToString();
            if (objapp.TablaDtInmueble.Rows[0][7].ToString() == "1")
                chkEstDt.Checked = true;
            else
                chkEstDt.Checked = false;

            AuditoriaIndivDetalle(131);

            btnFiltroDet.Focus();
            objapp = null;
            return;
        }
        private void GrabarActualizarDtInmueble()
        {
            if (Session["id"] == null || Session["rol"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }

            if (!ValidarAccion(1609))
            {
                LimpiarMensajes();
                Mensajes(3, "No tiene privilegios para realizar esta accion, contacte a la mesa de ayuda.");
                return;
            }

            try
            {
                if (!ValidarCampoDetalle())
                    return;

                clsTRNInmuebles objapp = new clsTRNInmuebles();

                objapp.CodEmp = (Int32)Session["emp"];
                objapp.CodDtInm = Convert.ToInt32(txtCodDet.Value);
                objapp.CodInm = Convert.ToInt32(lblCod.Text);
                objapp.CodLt = Convert.ToInt32(ddlTDetInm.SelectedValue);
                if (string.IsNullOrEmpty(txtFecha.Value))
                    objapp.fechaDtInm = null;
                else
                    objapp.fechaDtInm = Convert.ToDateTime(txtFecha.Value);
                objapp.MonetInm = Convert.ToDecimal(txtConcep.Value);
                objapp.DescDtInm = txtDesc.Value;
                if (chkEstDt.Checked == true)
                    objapp.EstadoDtInm = 1;
                else
                    objapp.EstadoDtInm = 2;

                objapp.IDEmdC = (int)Session["id"];
                objapp.IDEmdU = (int)Session["id"];

                // Parametros de Auditoria
                objapp.CodEmp = (Int32)Session["emp"];
                if (objapp.CodDtInm == 0)
                {
                    objapp.IDTpAdt = 133;
                    objapp.DescAdt = "Creación de detalle: " + ddlTDetInm.SelectedItem.ToString() + " Exitosamente." + strCambios;
                    objapp.IDTrnAdt = 0;
                }
                else
                {
                    objapp.IDTpAdt = 134;
                    objapp.DescAdt = "Actualización de detalle: " + ddlTDetInm.SelectedItem.ToString() + " Exitosamente. " + strCambios;
                    objapp.IDTrnAdt = Convert.ToInt32(lblCod.Text);
                }
                objapp.IDUsrAdt = (Int32)Session["id"];
                objapp.NmUsCreaAdt = Session["nm"].ToString();
                objapp.IDProgAdt = 601;
                objapp.IPAdt = BusquedaIp();
                objapp.NmPCAdt = System.Net.Dns.GetHostEntry(BusquedaIp()).HostName;

                if (!objapp.AgregarModificarTrnDtInmueble())
                {
                    LimpiarMensajes();
                    InsertarXml(DateTime.Now.ToShortDateString(), objapp.Error);
                    Mensajes(4, objapp.Error);
                    return;
                }

                LimpiarMensajes();
                Mensajes(1, "<strong>" + ddlTDetInm.SelectedItem.ToString() + "</strong> procesado exitosamente en la base de Datos.");

                ListarDetalle();
                LimpiarDetalle();
                btnFiltroDet.Focus();
                objapp = null;
                return;
            }
            catch (Exception e)
            {
                LimpiarMensajes();
                Mensajes(3, e.Message);
                return;
            }
        }
        private void AuditoriaIndivDetalle(int sw)
        {
            clsInmuebles objapp = new clsInmuebles();

            // Parametros de Auditoria
            objapp.CodEmp = (Int32)Session["emp"];
            if (sw == 130) //Busca datos
            {
                objapp.IDTpAdt = sw;
                objapp.DescAdt = "Busqueda de detalle en programa 601 - Control de inmueble. ";
                objapp.IDTrnAdt = 0; //Todos
            }
            if (sw == 131) //Obtener datos
            {
                objapp.IDTpAdt = sw;
                objapp.DescAdt = "Se obtuvo información del detalle: " + ddlTDetInm.SelectedValue + " con id: " + txtCodDet.Value;
                objapp.IDTrnAdt = Convert.ToInt32(lblCod.Text);
            }

            objapp.IDUsrAdt = (Int32)Session["id"];
            objapp.NmUsCreaAdt = Session["nm"].ToString();
            objapp.IDProgAdt = 601;
            objapp.IPAdt = BusquedaIp();
            objapp.NmPCAdt = System.Net.Dns.GetHostEntry(BusquedaIp()).HostName;

            if (!objapp.CrearAuditoria())
            {
                LimpiarMensajes();
                InsertarXml(DateTime.Now.ToShortDateString(), objapp.Error);
                Mensajes(4, objapp.Error);
                return;
            }
        }

        #endregion
        #region "Listar Obtener"

        private void ObtenerListarBComun()
        {
            if (Session["id"] == null || Session["rol"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }

            clsInmuebles objapp = new clsInmuebles();
            objapp.CodEmp = (int)Session["emp"];
            objapp.VrUnico = txtPDB.Value;
            if (chkEstView.Checked == true)
                objapp.EstadoInm = 1;
            else
                objapp.EstadoInm = 2;

            if (!objapp.ObtenerListarInmueble())
            {
                LimpiarMensajes();
                Mensajes(4, objapp.Error);
                InsertarXml(DateTime.Now.ToShortDateString(), objapp.Error);
                objapp = null;
                return;
            }

            if (objapp.TablaInmueble.Rows.Count < 1)
            {
                grvComunes.DataSource = null;
                grvComunes.DataBind();
                lblMsjComun.Visible = true;
                lblMsjComun.Text = "No se encontro información para esta busqueda, intente nuevamente.";
                return;
            }

            grvComunes.DataSource = objapp.TablaInmueble;
            grvComunes.DataBind();
            lblMsjComun.Text = string.Empty;
            lblMsjComun.Visible = false;
            objapp = null;
            return;
        }
        private void ObtenerInfoInmuebles(int Cod)
        {
            if (Session["id"] == null || Session["rol"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }

            if (!ValidarAccion(1603))
            {
                LimpiarMensajes();
                Mensajes(3, "No tiene privilegios para realizar esta acción, contacte al administrador del sistema.");
                return;
            }

            clsInmuebles objapp = new clsInmuebles();
            objapp.CodInm = Cod;
            objapp.CodEmp = (int)Session["emp"];

            if (!objapp.ObtenerListarInmueble())
            {
                LimpiarMensajes();
                Mensajes(4, objapp.Error);
                InsertarXml(DateTime.Now.ToShortDateString(), objapp.Error);
                objapp = null;
                return;
            }

            LimpiarFrmGnr();
            pnCreoUdp.Visible = true;
            lblCreoUdp.Text = string.Empty;
            lblCreoUdp.Text = "Elaboro: " + objapp.TablaInmueble.Rows[0][22].ToString() + "<br/> Fecha Elaboro:" + objapp.TablaInmueble.Rows[0][20].ToString() +
                              "<br/> Actualizo:" + objapp.TablaInmueble.Rows[0][25].ToString() + "<br/> Fecha Actualizo: " + objapp.TablaInmueble.Rows[0][23].ToString();

            lblCod.Text = objapp.TablaInmueble.Rows[0][1].ToString();
            txtRef.Value = objapp.TablaInmueble.Rows[0][2].ToString();
            ddlTInm.SelectedValue = objapp.TablaInmueble.Rows[0][3].ToString();
            txtMatricula.Value = objapp.TablaInmueble.Rows[0][11].ToString();
            ddlDep.SelectedValue = objapp.TablaInmueble.Rows[0][5].ToString();
            ddlDep_SelectedIndexChanged(null,null);
            ddlMun.SelectedValue = objapp.TablaInmueble.Rows[0][7].ToString();
            ddlMun_SelectedIndexChanged(null, null);
            ddlBarrio.SelectedValue = objapp.TablaInmueble.Rows[0][9].ToString();
            ddlConf.SelectedValue = objapp.TablaInmueble.Rows[0][12].ToString();
            txtDir.Value = objapp.TablaInmueble.Rows[0][14].ToString();
            txtTel.Value = objapp.TablaInmueble.Rows[0][15].ToString();
            txtEstrato.Value = objapp.TablaInmueble.Rows[0][16].ToString();
            txtCiclo.Value = objapp.TablaInmueble.Rows[0][17].ToString();
            if (objapp.TablaInmueble.Rows[0][18].ToString() == "1")
                chkEstado.Checked = true;
            else
                chkEstado.Checked = false;

            if (!ValidarAccion(1607))            
                pnAvaluos.Visible = false;            
            else
            {
                ComboFiltroTAvaluo();
                ComboFiltroAños();
                ListarAvaluos();
                pnAvaluos.Visible = true;
            }

            if (!ValidarAccion(1608))
                pnDetalle.Visible = false;
            else
            {
                ComboFiltroTDetalle();
                ComboFiltroEstadoDt();
                ListarDetalle();
                pnDetalle.Visible = true;
            }
            
            pnDatos.Visible = true;
            btnProcesar.Enabled = true;
            AuditoriaIndiv(131);
            DtCabOrigen();

            objapp = null;
            return;
        }

        #endregion
        #region "Grabar Actualizar"

        private void AuditoriaIndiv(int sw)
        {
            clsInmuebles objapp = new clsInmuebles();

            // Parametros de Auditoria
            objapp.CodEmp = (Int32)Session["emp"];
            if (sw == 130) //Busca datos
            {
                objapp.IDTpAdt = sw;
                objapp.DescAdt = "Busqueda de datos en programa 601 - Control de inmueble. ";
                objapp.IDTrnAdt = 0; //Todos
            }
            if (sw == 131) //Obtener datos
            {
                objapp.IDTpAdt = sw;
                objapp.DescAdt = "Se obtuvo información del inmueble: " + txtRef.Value + " con dirección: " + txtDir.Value;
                objapp.IDTrnAdt = Convert.ToInt32(lblCod.Text);
            }

            objapp.IDUsrAdt = (Int32)Session["id"];
            objapp.NmUsCreaAdt = Session["nm"].ToString();
            objapp.IDProgAdt = 601;
            objapp.IPAdt = BusquedaIp();
            objapp.NmPCAdt = System.Net.Dns.GetHostEntry(BusquedaIp()).HostName;

            if (!objapp.CrearAuditoria())
            {
                LimpiarMensajes();
                InsertarXml(DateTime.Now.ToShortDateString(), objapp.Error);
                Mensajes(4, objapp.Error);
                return;
            }
        }
        private void GrabarActualizarInmueble()
        {
            if (Session["id"] == null || Session["rol"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }

            if (lblCod.Text != "0" && !ValidarAccion(1601))
            {
                LimpiarMensajes();
                Mensajes(3, "No tiene privilegios para realizar esta accion, contacte a la mesa de ayuda.");
                return;
            }

            ValidarCambios(DtCabActual());
            if (cambio == false)
            {
                LimpiarMensajes();
                Mensajes(2, "No se encontraron cambios en la información.");
                return;
            }

            try
            {
                if (!ValidarCamposBase())
                    return;

                if (!ValidarReferencia())
                    return;

                clsTRNInmuebles objapp = new clsTRNInmuebles();

                objapp.CodEmp = (Int32)Session["emp"];
                objapp.CodInm = Convert.ToInt32(lblCod.Text);
                objapp.CodTInm = Convert.ToInt32(ddlTInm.SelectedValue);
                objapp.CodCnf = Convert.ToInt32(ddlConf.SelectedValue);
                objapp.RefInm = txtRef.Value;
                objapp.MatInm = txtMatricula.Value;
                objapp.CodLt = Convert.ToInt32(ddlBarrio.SelectedValue);                
                objapp.DirInm = txtDir.Value;
                objapp.TelInm = txtTel.Value;
                objapp.EstratoInm = txtEstrato.Value;
                objapp.CicloInm = txtCiclo.Value;
                if (chkEstado.Checked == true)
                    objapp.EstadoInm = 1;
                else
                    objapp.EstadoInm = 2;

                objapp.IDEmdC = (int)Session["id"];
                objapp.IDEmdU = (int)Session["id"];

                // Parametros de Auditoria
                objapp.CodEmp = (Int32)Session["emp"];
                if (objapp.CodInm == 0)
                {
                    objapp.IDTpAdt = 133;
                    objapp.DescAdt = "Creación de Nuevo Inmueble: " + txtRef.Value + " con dirección: " + txtDir.Value + " Exitosamente." + strCambios;
                    objapp.IDTrnAdt = 0;
                }
                else
                {
                    objapp.IDTpAdt = 134;
                    objapp.DescAdt = "Actualización de inmueble: " + txtRef.Value + " con dirección: " + txtDir.Value + " Exitosamente. " + strCambios;
                    objapp.IDTrnAdt = Convert.ToInt32(lblCod.Text);
                }
                objapp.IDUsrAdt = (Int32)Session["id"];
                objapp.NmUsCreaAdt = Session["nm"].ToString();
                objapp.IDProgAdt = 601;
                objapp.IPAdt = BusquedaIp();
                objapp.NmPCAdt = System.Net.Dns.GetHostEntry(BusquedaIp()).HostName;

                if (!objapp.AgregarModificarTrnInmueble())
                {
                    LimpiarMensajes();
                    InsertarXml(DateTime.Now.ToShortDateString(), objapp.Error);
                    Mensajes(4, objapp.Error);
                    return;
                }

                LimpiarMensajes();
                Mensajes(1, "inmueble con referencia: <strong>" + txtRef.Value + "</strong> y dirección: <strong>" + txtDir.Value + "</strong> procesado exitosamente en la base de Datos.");

                if (lblCod.Text == "0")
                {
                    Mensajes(2,"desea continuar con la inclusión de avaluos o detalles, siempre y cuando tenga los permisos para hacerlos ?");
                    pnBotones.Visible = true;                    
                }

                LimpiarFrmGnr();
                btnProcesar.Enabled = false;
                btnBuscar.Enabled = true;
                btnNuevo.Enabled = true;

                lblCod.Text = objapp.CodInm.ToString();

                objapp = null;
                return;
            }
            catch (Exception e)
            {
                LimpiarMensajes();
                Mensajes(3, e.Message);
                return;
            }
        }

        #endregion

        #endregion
        #region "Eventos"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["id"] == null || Session["rol"] == null)
                {
                    Session.Clear();
                    Response.Redirect("Login.aspx");
                }

                ValidarEdicionListas();
                btnNuevo.Enabled = true;
                btnBuscar.Enabled = true;
                ComboTipoInmueble();
                ComboConferencias();
                ComboDepartamento(209);
                ComboTipoAvaluo();
                ComboTipoDetalle();
            }
        }

        #region "Menu"

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            AuditoriaIndiv(130);
            HabilitarBusqueda();
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }
        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            GrabarActualizarInmueble();
        }
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFrmGnr();
        }
        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ini_06.aspx");
        }

        #endregion
        #region "Basica"

        protected void lkbAudit_Click(object sender, EventArgs e)
        {
            VentanaEmg(3);
            lblNmAudit.Text = txtRef.Value;
        }

        protected void ibtnATInm_Click(object sender, ImageClickEventArgs e)
        {
            ibtnUTInm.Visible = true;
            ibtnATInm.Visible = false;
            ValidarCreaEditaLt(Convert.ToInt32(ddlTInm.SelectedValue), 60);
            VentanaEmg(10);
        }
        protected void ibtnUTInm_Click(object sender, ImageClickEventArgs e)
        {
            if (Convert.ToInt32(Session["intEditL"]) == 1)
            {
                ibtnUTInm.Visible = false;
                ibtnATInm.Visible = true;
                ComboTipoInmueble();
                return;
            }
            else
            {
                ibtnUTInm.Visible = true;
                ibtnATInm.Visible = false;
                ComboTipoInmueble();
                return;
            }
        }

        protected void ddlDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDep.SelectedValue == "0")
            {
                ddlBarrio.Items.Clear();
                ddlBarrio.Enabled = false;
                ddlMun.Items.Clear();
                ddlMun.Enabled = false;
            }
            else            
                ComboMunicipio(Convert.ToInt32(ddlDep.SelectedValue));
            
        }
        protected void ddlMun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMun.SelectedValue == "0")
            {
                ddlBarrio.Items.Clear();
                ddlBarrio.Enabled = false;
            }
            else
                ComboBarrio(Convert.ToInt32(ddlMun.SelectedValue));
        }

        #endregion
        #region "Avaluos"

        protected void ibtnATAval_Click(object sender, ImageClickEventArgs e)
        {
            ibtnUTAval.Visible = true;
            ibtnATAval.Visible = false;
            ValidarCreaEditaLt(Convert.ToInt32(ddlTAval.SelectedValue), 64);
            VentanaEmg(10);
        }
        protected void ibtnUTAval_Click(object sender, ImageClickEventArgs e)
        {
            if (Convert.ToInt32(Session["intEditL"]) == 1)
            {
                ibtnUTAval.Visible = false;
                ibtnATAval.Visible = true;
                ComboTipoAvaluo();
                return;
            }
            else
            {
                ibtnUTAval.Visible = true;
                ibtnATAval.Visible = false;
                ComboTipoAvaluo();
                return;
            }
        }

        protected void btnAddAval_Click(object sender, EventArgs e)
        {
            GrabarActualizarAvaluoInmueble();
        }

        protected void btnFiltroAval_Click(object sender, EventArgs e)
        {
            ListarAvaluos();
            btnFiltroAval.Focus();
        }
        protected void grvAvaluos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Int32 ID = (Int32)grvAvaluos.DataKeys[e.RowIndex].Value;
            ObtenerInfoAvaluos(ID);
        }
        protected void grvAvaluos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvAvaluos.PageIndex = e.NewPageIndex;
        }

        #endregion
        #region "Detalle"

        protected void ddlTDetInm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTDetInm.SelectedValue == "65")           
                pnContDetalle.Visible = false;          
            else            
                pnContDetalle.Visible = true;

            btnFiltroDet.Focus();
            
        }
        protected void ibtnATDet_Click(object sender, ImageClickEventArgs e)
        {
            ibtnUTDet.Visible = true;
            ibtnATDet.Visible = false;
            ValidarCreaEditaLt(Convert.ToInt32(ddlTDetInm.SelectedValue), 65);
            VentanaEmg(10);
        }
        protected void ibtnUTDet_Click(object sender, ImageClickEventArgs e)
        {
            if (Convert.ToInt32(Session["intEditL"]) == 1)
            {
                ibtnUTDet.Visible = false;
                ibtnATDet.Visible = true;
                ComboTipoDetalle();
                return;
            }
            else
            {
                ibtnUTDet.Visible = true;
                ibtnATDet.Visible = false;
                ComboTipoDetalle();
                return;
            }
        }

        protected void btnAddDet_Click(object sender, EventArgs e)
        {
            GrabarActualizarDtInmueble();
        }

        protected void btnFiltroDet_Click(object sender, EventArgs e)
        {
            ListarDetalle();
            btnFiltroDet.Focus();
        }
        protected void grvDetalle_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Int32 ID = (Int32)grvDetalle.DataKeys[e.RowIndex].Value;
            ObtenerInfoDetalle(ID);
        }
        protected void grvDetalle_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvDetalle.PageIndex = e.NewPageIndex;
        }

        #endregion
        #region "Busqueda Avanzada"

        protected void ibtnBuscarComun_Click(object sender, ImageClickEventArgs e)
        {
            HabilitarBusqueda();
        }
        protected void grvComunes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Int32 ID = (Int32)grvComunes.DataKeys[e.RowIndex].Value;
            ObtenerInfoInmuebles(ID);
        }
        protected void grvComunes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvComunes.PageIndex = e.NewPageIndex;
            HabilitarBusqueda();
        }

        #endregion

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            ObtenerInfoInmuebles(Convert.ToInt32(lblCod.Text));
        }
        

        #endregion
    }
}
