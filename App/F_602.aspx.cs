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
    public partial class Formulario_web118 : System.Web.UI.Page
    {
        #region "Atributos"

        public static string strIp, strCambios;
        static XmlDocument documento = new XmlDocument();
        public static bool cambio = false;

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
                    pnInmuebles.Visible = false;
                    pnUsuarios.Visible = false;
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "MostrarModalJS();", true);
                    break;

                case 2:
                    pnMsjForm.Visible = false;
                    pnBusquedaC.Visible = true;
                    pnAuditoria.Visible = false;
                    pnInmuebles.Visible = false;
                    pnUsuarios.Visible = false;
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "MostrarModalJS();", true);
                    break;

                case 3:
                    pnMsjForm.Visible = false;
                    pnBusquedaC.Visible = false;
                    pnAuditoria.Visible = true;
                    pnInmuebles.Visible = false;
                    pnUsuarios.Visible = false;
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "MostrarModalJS();", true);
                    break;

                case 4:
                    pnMsjForm.Visible = false;
                    pnBusquedaC.Visible = false;
                    pnAuditoria.Visible = false;
                    pnInmuebles.Visible = true;
                    pnUsuarios.Visible = false;
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "MostrarModalJS();", true);
                    break;

                case 5:
                    pnMsjForm.Visible = false;
                    pnBusquedaC.Visible = false;
                    pnAuditoria.Visible = false;
                    pnInmuebles.Visible = false;
                    pnUsuarios.Visible = true;
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "MostrarModalJS();", true);
                    break;

                case 10:
                    string script = "window.open('emg-EdtListas.aspx','','height=500,width=400 ,directories=false,status=0,toolbar=0,center=yes;menubar=0,help=no;scrollbars=no,RESIZABLE=no')";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "openwindow", script, true);
                    break;
            }
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
            objapp.CodProg = 602;

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

            if (ValidarAccion(1654))
            {
                Session["intEditL"] = "1"; // Permite crear y Actualizar
            }
            else
            {
                Session["intEditL"] = "0"; // Permite Actualizar 
                ibtnUTInc.Visible = true;
                ibtnATInc.Visible = false;
                ibtnUTCont.Visible = true;
                ibtnATCont.Visible = false;
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
            if (Session["Origen"] == null)
            {
                cambio = true;
                return;
            }

            DataTable tmp = (DataTable)Session["Origen"];
            strCambios = "se actualizo: ";
            int j = 13;

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
        private DataTable DtActual()
        {
            DataTable tmp = new DataTable();

            tmp.Columns.Add("Referencia", typeof(string));
            tmp.Columns.Add("Tipo Contrato", typeof(string));
            tmp.Columns.Add("Fecha Inicial", typeof(string));
            tmp.Columns.Add("Fecha Final", typeof(string));
            tmp.Columns.Add("Inmueble", typeof(string));
            tmp.Columns.Add("Usuario", typeof(string));
            tmp.Columns.Add("Solicitud", typeof(string));
            tmp.Columns.Add("Canon", typeof(string));
            tmp.Columns.Add("Incremento", typeof(string));
            tmp.Columns.Add("Administracion", typeof(string));
            tmp.Columns.Add("Retencion", typeof(string));
            tmp.Columns.Add("Iva", typeof(string));
            tmp.Columns.Add("Nota", typeof(string));
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
            tmp.Columns.Add("11", typeof(string));
            tmp.Columns.Add("12", typeof(string));
            tmp.Columns.Add("13", typeof(string));
            tmp.Columns.Add("14", typeof(string));

            DataRow drFilaAlt = tmp.NewRow();

            drFilaAlt["Referencia"] = txtRef.Value;
            drFilaAlt["Tipo Contrato"] = ddlTCont.SelectedValue;
            drFilaAlt["Fecha Inicial"] = txtFIni.Value;
            drFilaAlt["Fecha Final"] = txtFFin.Value;
            drFilaAlt["Inmueble"] = lblCodInm.Text;
            drFilaAlt["Usuario"] = lblCodUser.Text;
            drFilaAlt["Solicitud"] = lblCodSlt.Text;
            drFilaAlt["Canon"] = txtCanon.Value;
            drFilaAlt["Incremento"] = ddlTInc.SelectedValue;
            drFilaAlt["Administracion"] = txtAdmin.Value;
            drFilaAlt["Retencion"] = txtRet.Value;
            drFilaAlt["Iva"] = txtIva.Value;
            drFilaAlt["Nota"] = txtNota.Value;
            drFilaAlt["Estado"] = chkEstado.Checked;

            drFilaAlt["1"] = "Referencia";
            drFilaAlt["2"] = "Tipo Contrato";
            drFilaAlt["3"] = "Fecha Inicial";
            drFilaAlt["4"] = "Fecha Final";
            drFilaAlt["5"] = "Inmueble";
            drFilaAlt["6"] = "Usuario";
            drFilaAlt["7"] = "Solicitud";
            drFilaAlt["8"] = "Canon";
            drFilaAlt["9"] = "Incremento";
            drFilaAlt["10"] = "Administracion";
            drFilaAlt["11"] = "Retencion";
            drFilaAlt["12"] = "Iva";
            drFilaAlt["13"] = "Nota";
            drFilaAlt["14"] = "Estado";

            tmp.Rows.Add(drFilaAlt);

            return tmp;
        }
        private void DtOrigen()
        {
            DataTable tmp = new DataTable();

            tmp.Columns.Add("Referencia", typeof(string));
            tmp.Columns.Add("Tipo Contrato", typeof(string));
            tmp.Columns.Add("Fecha Inicial", typeof(string));
            tmp.Columns.Add("Fecha Final", typeof(string));
            tmp.Columns.Add("Inmueble", typeof(string));
            tmp.Columns.Add("Usuario", typeof(string));
            tmp.Columns.Add("Solicitud", typeof(string));
            tmp.Columns.Add("Canon", typeof(string));
            tmp.Columns.Add("Incremento", typeof(string));
            tmp.Columns.Add("Administracion", typeof(string));
            tmp.Columns.Add("Retencion", typeof(string));
            tmp.Columns.Add("Iva", typeof(string));
            tmp.Columns.Add("Nota", typeof(string));
            tmp.Columns.Add("Estado", typeof(string));

            DataRow drFilaAlt = tmp.NewRow();

            drFilaAlt["Referencia"] = txtRef.Value;
            drFilaAlt["Tipo Contrato"] = ddlTCont.SelectedValue;
            drFilaAlt["Fecha Inicial"] = txtFIni.Value;
            drFilaAlt["Fecha Final"] = txtFFin.Value;
            drFilaAlt["Inmueble"] = lblCodInm.Text;
            drFilaAlt["Usuario"] = lblCodUser.Text;
            drFilaAlt["Solicitud"] = lblCodSlt.Text;
            drFilaAlt["Canon"] = txtCanon.Value;
            drFilaAlt["Incremento"] = ddlTInc.SelectedValue;
            drFilaAlt["Administracion"] = txtAdmin.Value;
            drFilaAlt["Retencion"] = txtRet.Value;
            drFilaAlt["Iva"] = txtIva.Value;
            drFilaAlt["Nota"] = txtNota.Value;
            drFilaAlt["Estado"] = chkEstado.Checked;

            tmp.Rows.Add(drFilaAlt);

            Session["Origen"] = tmp;
        }

        private void LimpiarFrmGnr()
        {
            Session["Origen"] = null;
            cambio = false;
            strCambios = string.Empty;

            pnCreoUdp.Visible = false;
            lblCreoUdp.Text = string.Empty;

            lblCod.Text = "0";
            ddlTCont.SelectedValue = "62";
            txtRef.Value = string.Empty;
            chkEstado.Checked = true;
            txtFIni.Value = string.Empty;
            txtFFin.Value = string.Empty;
            lbtInmueble.Visible = true;
            lblInmueble.Text = string.Empty;
            lblCodInm.Text = "0";
            lbtUser.Visible = true;
            lblUser.Text = string.Empty;
            lblCodUser.Text = "0";
            lblTipoUser.Text = "0";
            lblCodSlt.Text = "0";
            txtCanon.Value = string.Empty;
            txtCanon.Disabled = true;
            ddlTInc.SelectedValue = "63";
            ddlTInc.Enabled = true;
            txtAdmin.Value = string.Empty;
            txtAdmin.Disabled = true;
            txtRet.Value = string.Empty;
            txtRet.Disabled = true;
            txtIva.Value = string.Empty;
            txtIva.Disabled = true;
            txtNota.Value = string.Empty;
        }
        private void HabilitarBusqueda()
        {
            if (Session["id"] == null || Session["rol"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }

            if (!ValidarAccion(1652))
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

            if (!ValidarAccion(1650))
            {
                LimpiarMensajes();
                Mensajes(3, "No tiene privilegios para realizar esta acción, contacte al administrador del sistema.");
                return;
            }

            LimpiarFrmGnr();
            btnProcesar.Enabled = true;
            pnDatos.Visible = true;

            txtCanon.Disabled = false;
            txtAdmin.Disabled = false;
            txtIva.Disabled = false;
            txtRet.Disabled = false;
            ddlTInc.Enabled = true;
        }
        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtRef.Value))
            {
                Mensajes(3, "** No ha Ingresado la referencia del Contrato, complete el campo para continuar **");
                txtRef.Focus();
                return false;
            }
            if (ddlTCont.SelectedValue == "62")
            {
                Mensajes(3, "** No ha seleccionado el tipo de Contrato, complete el campo para continuar **");
                ddlTCont.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtFIni.Value) || string.IsNullOrEmpty(txtFFin.Value))
            {
                Mensajes(3, "** No ha Ingresado el lapso de fecha del Contrato, complete el campo para continuar **");
                txtFIni.Focus();
                return false;
            }
            if (Convert.ToDateTime(txtFIni.Value) > Convert.ToDateTime(txtFFin.Value))
            {
                Mensajes(3, "** error en la estructura del lapso de fecha para el contrato, complete el campo para continuar **");
                txtFIni.Focus();
                return false;
            }

            if (lblCodInm.Text == "0")
            {
                Mensajes(3, "** No ha seleccionado un inmueble para el Contrato, complete el campo para continuar **");
                lbtInmueble.Focus();
                return false;
            }
            if (lblCodUser.Text == "0" || lblTipoUser.Text == "0")
            {
                Mensajes(3, "** No ha seleccionado un usuario para el Contrato, complete el campo para continuar **");
                lbtUser.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtCanon.Value))
            {
                Mensajes(3, "** No ha Ingresado el canon para el contrato, complete el campo para continuar **");
                txtCanon.Focus();
                return false;
            }
            if (ddlTInc.SelectedValue == "63")
            {
                Mensajes(3, "** No ha seleccionado el tipo de incremento para el contrato, complete el campo para continuar **");
                ddlTInc.Focus();
                return false;
            }            
            if (string.IsNullOrEmpty(txtAdmin.Value))
            {
                Mensajes(3, "** No ha Ingresado la administración al contrato, complete el campo para continuar **");
                txtAdmin.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtRet.Value))
            {
                Mensajes(3, "** No ha Ingresado la retención al contrato, complete el campo para continuar **");
                txtRet.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtIva.Value))
            {
                Mensajes(3, "** No ha Ingresado el iva al contrato, complete el campo para continuar **");
                txtIva.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNota.Value))
                txtNota.Value = "";

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

            if (!objapp.ObtenerListarContrato())
            {
                LimpiarMensajes();
                Mensajes(4, objapp.Error);
                InsertarXml(DateTime.Now.ToShortDateString(), objapp.Error);
                objapp = null;
                return false;
            }

            if (objapp.TablaContrato.Rows.Count > 0)
            {
                for (int i = 0; i < objapp.TablaContrato.Rows.Count; i++)
                {
                    if (objapp.TablaContrato.Rows[i][1].ToString() != lblCod.Text)
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
        #region "Listas Desplegables"

        private void ComboTipoContrato()
        {
            clsListasGn objapp = new clsListasGn();

            objapp.ComboListas = ddlTCont;
            objapp.CodEmp = (int)Session["emp"];
            objapp.LtRef = 62;
            objapp.EstLt = 1;

            if (objapp.ListarCombos())
            {
                ddlTCont = objapp.ComboListas;
                ddlTCont.SelectedValue = "62";
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
        private void ComboTipoIncremento()
        {
            clsListasGn objapp = new clsListasGn();

            objapp.ComboListas = ddlTInc;
            objapp.CodEmp = (int)Session["emp"];
            objapp.LtRef = 63;
            objapp.EstLt = 1;

            if (objapp.ListarCombos())
            {
                ddlTInc = objapp.ComboListas;
                ddlTInc.SelectedValue = "63";
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
                objapp.EstadoCont = 1;
            else
                objapp.EstadoCont = 2;

            if (!objapp.ObtenerListarContrato())
            {
                LimpiarMensajes();
                Mensajes(4, objapp.Error);
                InsertarXml(DateTime.Now.ToShortDateString(), objapp.Error);
                objapp = null;
                return;
            }

            if (objapp.TablaContrato.Rows.Count < 1)
            {
                grvComunes.DataSource = null;
                grvComunes.DataBind();
                lblMsjComun.Visible = true;
                lblMsjComun.Text = "No se encontro información para esta busqueda, intente nuevamente.";
                return;
            }

            grvComunes.DataSource = objapp.TablaContrato;
            grvComunes.DataBind();
            lblMsjComun.Text = string.Empty;
            lblMsjComun.Visible = false;
            objapp = null;
            return;
        }
        private void ObtenerInfoContrato(int Cod)
        {
            if (Session["id"] == null || Session["rol"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }

            if (!ValidarAccion(1653))
            {
                LimpiarMensajes();
                Mensajes(3, "No tiene privilegios para realizar esta acción, contacte al administrador del sistema.");
                return;
            }

            clsInmuebles objapp = new clsInmuebles();
            objapp.CodCont = Cod;
            objapp.CodEmp = (int)Session["emp"];

            if (!objapp.ObtenerListarContrato())
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
            lblCreoUdp.Text = "Elaboro: " + objapp.TablaContrato.Rows[0][24].ToString() + "<br/> Fecha Elaboro:" + objapp.TablaContrato.Rows[0][22].ToString() +
                              "<br/> Actualizo:" + objapp.TablaContrato.Rows[0][27].ToString() + "<br/> Fecha Actualizo: " + objapp.TablaContrato.Rows[0][25].ToString();

            lblCod.Text = objapp.TablaContrato.Rows[0][1].ToString();
            txtRef.Value = objapp.TablaContrato.Rows[0][2].ToString();
            txtFIni.Value = objapp.TablaContrato.Rows[0][3].ToString();
            txtFFin.Value = objapp.TablaContrato.Rows[0][4].ToString();
            ddlTCont.SelectedValue = objapp.TablaContrato.Rows[0][5].ToString();
            lblCodInm.Text = objapp.TablaContrato.Rows[0][7].ToString();
            lblCodUser.Text = objapp.TablaContrato.Rows[0][8].ToString();
            lblTipoUser.Text = objapp.TablaContrato.Rows[0][9].ToString();
            lblCodSlt.Text = objapp.TablaContrato.Rows[0][10].ToString();
            txtCanon.Value = objapp.TablaContrato.Rows[0][11].ToString();
            ddlTInc.SelectedValue = objapp.TablaContrato.Rows[0][12].ToString();
            txtRet.Value = objapp.TablaContrato.Rows[0][15].ToString();
            txtIva.Value = objapp.TablaContrato.Rows[0][16].ToString();
            txtAdmin.Value = objapp.TablaContrato.Rows[0][17].ToString();
            txtNota.Value = objapp.TablaContrato.Rows[0][19].ToString();
            if (objapp.TablaContrato.Rows[0][20].ToString() == "1")
                chkEstado.Checked = true;
            else
                chkEstado.Checked = false;

            if (!ValidarAccion(1655)) // Tipo de contrato
                ddlTCont.Enabled = false;
            else
                ddlTCont.Enabled = true;

            if (!ValidarAccion(1658)) // Inmueble
                lbtInmueble.Visible = false;
            else
                lbtInmueble.Visible = true;

            if (!ValidarAccion(1657)) // Usuario
                lbtUser.Visible = false;
            else
                lbtUser.Visible = true;

            if (!ValidarAccion(1656)) // Economicos
            {
                txtCanon.Disabled = true;
                txtAdmin.Disabled = true;
                txtIva.Disabled = true;
                txtRet.Disabled = true;
                ddlTInc.Enabled = false;
            }
            else
            {

                txtCanon.Disabled = false;
                txtAdmin.Disabled = false;
                txtIva.Disabled = false;
                txtRet.Disabled = false;
                ddlTInc.Enabled = true;
            }

            ObtenerInfoInmuebles(Convert.ToInt32(lblCodInm.Text));
            ObtenerDtRegistro(Convert.ToInt32(lblCodUser.Text));

            pnDatos.Visible = true;
            btnProcesar.Enabled = true;
            AuditoriaIndiv(131);
            DtOrigen();

            objapp = null;
            return;
        }

        private void ListarObtenerInmuebles()
        {
            if (Session["id"] == null || Session["rol"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }

            clsInmuebles objapp = new clsInmuebles();
            objapp.CodEmp = (int)Session["emp"];
            objapp.VrUnico = txtPDBInm.Value;
            objapp.EstadoInm = 1;

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
                grvInm.DataSource = null;
                grvInm.DataBind();
                lblMsjInm.Visible = true;
                lblMsjInm.Text = "No se encontro información para esta busqueda, intente nuevamente.";
                return;
            }

            VentanaEmg(4);
            grvInm.DataSource = objapp.TablaInmueble;
            grvInm.DataBind();
            lblMsjInm.Text = string.Empty;
            lblMsjInm.Visible = false;
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

            lblCodInm.Text = string.Empty;
            lblInmueble.Text = string.Empty;

            lblCodInm.Text = objapp.TablaInmueble.Rows[0][1].ToString();
            lblInmueble.Text = "<strong>Referencia: </strong>" + objapp.TablaInmueble.Rows[0][2].ToString() + "<br>" +
            "<strong>Matricula: </strong>" + objapp.TablaInmueble.Rows[0][11].ToString() + "<br>" +
            "<strong>Tipo inmueble: </strong>" + objapp.TablaInmueble.Rows[0][4].ToString() + "<br>" +
            "<strong>Dirección: </strong>" + objapp.TablaInmueble.Rows[0][14].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
            "<strong>Telefono: </strong>" + objapp.TablaInmueble.Rows[0][15].ToString() + "<br>" +
            "<strong>Ubicación: </strong>" + objapp.TablaInmueble.Rows[0][10].ToString() + "<br>" +
            "<strong>Grupo Administra: </strong>" + objapp.TablaInmueble.Rows[0][13].ToString();     

            objapp = null;
            return;
        }

        private void ListarObtenerRegistro()
        {
            if (Session["id"] == null || Session["rol"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }

            clsTSocial objapp = new clsTSocial();
            objapp.CodEmp = (int)Session["emp"];
            objapp.VrUnico = txtPDBUser.Value;
            objapp.EstRg = 1;

            if (!objapp.ObtenerListarRegistro())
            {
                lblMsjComun.Text = objapp.Error;
                InsertarXml(DateTime.Now.ToShortDateString(), objapp.ErrorInterno);
                objapp = null;
                return;
            }

            if (objapp.TablaTSocial.Rows.Count < 1)
            {
                grvUser.DataSource = null;
                grvUser.DataBind();
                lblMsjUser.Visible = true;
                lblMsjUser.Text = "NO se encontro Información para esta Busqueda, Intente Nuevamente.";
                return;
            }

            VentanaEmg(5);
            grvUser.DataSource = objapp.TablaTSocial;
            grvUser.DataBind();
            lblMsjUser.Text = string.Empty;
            lblMsjUser.Visible = false;
            objapp = null;
            return;
        }
        private void ObtenerDtRegistro(int cod)
        {
            if (Session["id"] == null || Session["rol"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }

            clsTSocial objapp = new clsTSocial();
            objapp.CodEmp = (int)Session["emp"];
            objapp.CodRg = cod;
            objapp.VrUnico = "%";
            objapp.EstRg = 1;


            if (!objapp.ObtenerListarRegistro())
            {
                Mensajes(3, objapp.Error);
                InsertarXml(DateTime.Now.ToShortDateString(), objapp.ErrorInterno);
                objapp = null;
                return;
            }

            if (objapp.TablaTSocial.Rows.Count < 1)
            {
                LimpiarMensajes();
                Mensajes(4, "Error al obtener la información del Usuario, intente nuevamente.");
                return;
            }

            lblCodUser.Text = string.Empty;
            lblTipoUser.Text = string.Empty;
            lblUser.Text = string.Empty;

            lblCodUser.Text = objapp.TablaTSocial.Rows[0][1].ToString();
            lblTipoUser.Text = "1";
            lblUser.Text = "<strong>Cedula: </strong>" + objapp.TablaTSocial.Rows[0][2].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
            "<strong>Nombre: </strong>" + objapp.TablaTSocial.Rows[0][5].ToString() + " " + objapp.TablaTSocial.Rows[0][6].ToString();
            
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
                objapp.DescAdt = "Busqueda de datos en programa 602 - Control de inmueble. ";
                objapp.IDTrnAdt = 0; //Todos
            }
            if (sw == 131) //Obtener datos
            {
                objapp.IDTpAdt = sw;
                objapp.DescAdt = "Se obtuvo información del Contrato: " + txtRef.Value + " con id: " + lblCod.Text;
                objapp.IDTrnAdt = Convert.ToInt32(lblCod.Text);
            }

            objapp.IDUsrAdt = (Int32)Session["id"];
            objapp.NmUsCreaAdt = Session["nm"].ToString();
            objapp.IDProgAdt = 602;
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
        private void GrabarActualizarContrato()
        {
            if (Session["id"] == null || Session["rol"] == null)
            {
                Session.Clear();
                Response.Redirect("Login.aspx");
            }

            if (lblCod.Text != "0" && !ValidarAccion(1651))
            {
                LimpiarMensajes();
                Mensajes(3, "No tiene privilegios para realizar esta accion, contacte a la mesa de ayuda.");
                return;
            }

            ValidarCambios(DtActual());
            if (cambio == false)
            {
                LimpiarMensajes();
                Mensajes(2, "No se encontraron cambios en la información.");
                return;
            }

            try
            {
                if (!ValidarCampos())
                    return;

                if (!ValidarReferencia())
                    return;

                clsTRNInmuebles objapp = new clsTRNInmuebles();

                objapp.CodEmp = (Int32)Session["emp"];
                objapp.CodCont = Convert.ToInt32(lblCod.Text);
                objapp.RefCont = txtRef.Value;
                objapp.CodLt = Convert.ToInt32(ddlTCont.SelectedValue);
                objapp.Fecha = Convert.ToDateTime(txtFIni.Value);
                objapp.Fecha2 = Convert.ToDateTime(txtFFin.Value);                
                objapp.CodInm = Convert.ToInt32(lblCodInm.Text);
                objapp.CodRg = Convert.ToInt32(lblCodUser.Text);
                objapp.CodSw = Convert.ToInt32(lblTipoUser.Text);
                objapp.CodSlt = Convert.ToInt32(lblCodSlt.Text);
                objapp.Canon = Convert.ToDecimal(txtCanon.Value);
                objapp.CodIncCont = Convert.ToInt32(ddlTInc.SelectedValue);
                objapp.CuotaAdmin = Convert.ToDecimal(txtAdmin.Value);
                objapp.Retencion = Convert.ToDecimal(txtRet.Value);
                objapp.Iva = Convert.ToDecimal(txtIva.Value);
                objapp.NotaCont = txtNota.Value;
                if (chkEstado.Checked == true)
                    objapp.EstadoCont = 1;
                else
                    objapp.EstadoCont = 2;

                objapp.IDEmdC = (int)Session["id"];
                objapp.IDEmdU = (int)Session["id"];

                // Parametros de Auditoria
                objapp.CodEmp = (Int32)Session["emp"];
                if (objapp.CodCont == 0)
                {
                    objapp.IDTpAdt = 133;
                    objapp.DescAdt = "Creación de Nuevo Contrato con referencia: " + txtRef.Value + " Exitosamente." + strCambios;
                    objapp.IDTrnAdt = 0;
                }
                else
                {
                    objapp.IDTpAdt = 134;
                    objapp.DescAdt = "Actualización de contrato conrefernecia: " + txtRef.Value + " e id: " + lblCod.Text + " Exitosamente. " + strCambios;
                    objapp.IDTrnAdt = Convert.ToInt32(lblCod.Text);
                }
                objapp.IDUsrAdt = (Int32)Session["id"];
                objapp.NmUsCreaAdt = Session["nm"].ToString();
                objapp.IDProgAdt = 602;
                objapp.IPAdt = BusquedaIp();
                objapp.NmPCAdt = System.Net.Dns.GetHostEntry(BusquedaIp()).HostName;

                if (!objapp.AgregarModificarTrnContrato())
                {
                    LimpiarMensajes();
                    InsertarXml(DateTime.Now.ToShortDateString(), objapp.Error);
                    Mensajes(4, objapp.Error);
                    return;
                }

                LimpiarMensajes();
                Mensajes(1, "Contrato con referencia: <strong>" + txtRef.Value + "</strong> e id: <strong>" + lblCod.Text + "</strong> procesado exitosamente en la base de Datos.");


                LimpiarFrmGnr();
                btnProcesar.Enabled = false;
                btnBuscar.Enabled = true;
                btnNuevo.Enabled = true;

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
                ComboTipoContrato();
                ComboTipoIncremento();
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
            GrabarActualizarContrato();
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
        #region "Contenido"

        protected void lkbAudit_Click(object sender, EventArgs e)
        {
            VentanaEmg(3);
            lblNmAudit.Text = txtRef.Value;
        }

        protected void ibtnATCont_Click(object sender, ImageClickEventArgs e)
        {
            ibtnUTCont.Visible = true;
            ibtnATCont.Visible = false;
            ValidarCreaEditaLt(Convert.ToInt32(ddlTCont.SelectedValue), 62);
            VentanaEmg(10);
        }
        protected void ibtnUTCont_Click(object sender, ImageClickEventArgs e)
        {
            if (Convert.ToInt32(Session["intEditL"]) == 1)
            {
                ibtnUTCont.Visible = false;
                ibtnATCont.Visible = true;
                ComboTipoContrato();
                return;
            }
            else
            {
                ibtnUTCont.Visible = true;
                ibtnATCont.Visible = false;
                ComboTipoContrato();
                return;
            }
        }

        protected void lbtInmueble_Click(object sender, EventArgs e)
        {            
            ListarObtenerInmuebles();
        }
        protected void ibtnViewInm_Click(object sender, ImageClickEventArgs e)
        {
            ListarObtenerInmuebles();
        }
        protected void grvInm_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Int32 ID = (Int32)grvInm.DataKeys[e.RowIndex].Value;
            ObtenerInfoInmuebles(ID);
        }
        protected void grvInm_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvInm.PageIndex = e.NewPageIndex;
            ListarObtenerInmuebles();
        }

        protected void lbtUser_Click(object sender, EventArgs e)
        {
            ListarObtenerRegistro();
        }
        protected void ibtnViewUser_Click(object sender, ImageClickEventArgs e)
        {
            ListarObtenerRegistro();
        }
        protected void grvUser_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Int32 ID = (Int32)grvUser.DataKeys[e.RowIndex].Value;
            ObtenerDtRegistro(ID);
        }
        protected void grvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvUser.PageIndex = e.NewPageIndex;
            ListarObtenerRegistro();
        }

        protected void ibtnATInc_Click(object sender, ImageClickEventArgs e)
        {
            ibtnUTInc.Visible = true;
            ibtnATInc.Visible = false;
            ValidarCreaEditaLt(Convert.ToInt32(ddlTInc.SelectedValue), 63);
            VentanaEmg(10);
        }
        protected void ibtnUTInc_Click(object sender, ImageClickEventArgs e)
        {
            if (Convert.ToInt32(Session["intEditL"]) == 1)
            {
                ibtnUTInc.Visible = false;
                ibtnATInc.Visible = true;
                ComboTipoIncremento();
                return;
            }
            else
            {
                ibtnUTInc.Visible = true;
                ibtnATInc.Visible = false;
                ComboTipoIncremento();
                return;
            }
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
            ObtenerInfoContrato(ID);
        }
        protected void grvComunes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvComunes.PageIndex = e.NewPageIndex;
            HabilitarBusqueda();
        }

        #endregion

        #endregion
    }
}