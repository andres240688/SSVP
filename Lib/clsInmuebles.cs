using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* == Referencias y Usos de Librerias == */

using LibConexionBD;
using LibLlenarCombos;
using LibLlenarGrids;

using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace LibSSVP.Operativa
{
    public class clsInmuebles : clsSComun
    {
        #region "Atributos"

        /* == Atributos Locales no Heredables == */

        private clsConexionBD ObjCnx;
        private SqlDataReader Reader_Local;

        private string strError;

        #endregion
        #region "Propiedades"

        /* == Propiedades Locales no Heredables == */

        public string Error { get { return strError; } }

        #endregion
        #region "Metodos Privados"

        #region "Parametros de Entrada"

        private bool prmInmueble()
        {
            if (!ObjCnx.parametros(ParameterDirection.Input, "@id_emp", SqlDbType.Int, intCodEmp))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@cod", SqlDbType.Int, intCodInm))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@cod_inmueble", SqlDbType.NVarChar, strRefInm))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@id_tipo", SqlDbType.Int, intCodTInm))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@id_ubic", SqlDbType.Int, intCodLt))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@matricula", SqlDbType.NVarChar, strMatInm))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@id_asociado", SqlDbType.Int, intCodCnf))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@dir", SqlDbType.NVarChar, strDirInm))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@tel", SqlDbType.NVarChar, strTelInm))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@estrato", SqlDbType.NVarChar, strEstratoInm))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@ciclo", SqlDbType.NVarChar, strCicloInm))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@estado", SqlDbType.Int, intEstadoInm))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@id_emdc", SqlDbType.Int, intIDEmdC))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@id_emdu", SqlDbType.Int, intIDEmdU))
            {
                strError = ObjCnx.Error;
                return false;
            }

            return true;
        }
        private bool prmDetalleInmueble()
        {
            if (!ObjCnx.parametros(ParameterDirection.Input, "@cod", SqlDbType.Int, intCodDtInm))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@id_inmueble", SqlDbType.Int, intCodInm))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@id_Tipo", SqlDbType.Int, intCodLt))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@descripcion", SqlDbType.NVarChar, strDescDtInm))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (string.IsNullOrEmpty(dtmfechaDtInm.ToString()))
            {
                if (!ObjCnx.parametros(ParameterDirection.Input, "@fecha", SqlDbType.DateTime, DBNull.Value))
                {
                    strError = ObjCnx.Error;
                    return false;
                }
            }
            else
                if (!ObjCnx.parametros(ParameterDirection.Input, "@fecha", SqlDbType.DateTime, dtmfechaDtInm))
                {
                    strError = ObjCnx.Error;
                    return false;
                }

            if (!ObjCnx.parametros(ParameterDirection.Input, "@concepto", SqlDbType.Money, dcMonetInm))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@estado", SqlDbType.Int, intEstadoDtInm))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@id_emdc", SqlDbType.Int, intIDEmdC))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@id_emdu", SqlDbType.Int, intIDEmdU))
            {
                strError = ObjCnx.Error;
                return false;
            }

            return true;
        }
        private bool prmAvaluoInmueble()
        {
            if (!ObjCnx.parametros(ParameterDirection.Input, "@cod", SqlDbType.Int, intCodAval))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@id_inmueble", SqlDbType.Int, intCodInm))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@id_tipo", SqlDbType.Int, intCodLt))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@fecha", SqlDbType.DateTime, dtmFecha))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@fecha_vence", SqlDbType.DateTime, dtmFecha2))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@concepto", SqlDbType.Money, dcMonetAval))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@nota", SqlDbType.NVarChar, strNotAval))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@id_emdc", SqlDbType.Int, intIDEmdC))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@id_emdu", SqlDbType.Int, intIDEmdU))
            {
                strError = ObjCnx.Error;
                return false;
            }

            return true;
        }

        #region "Contratos"

        private bool prmContrato()
        {
            if (!ObjCnx.parametros(ParameterDirection.Input, "@id_emp", SqlDbType.Int, intCodEmp))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@cod", SqlDbType.Int, intCodCont))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@cod_referencia", SqlDbType.NVarChar, strRefCont))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@fecha", SqlDbType.DateTime, dtmFecha))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@fecha_vence", SqlDbType.DateTime, dtmFecha2))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@id_tipo", SqlDbType.Int, intCodLt))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@id_inmueble", SqlDbType.Int, intCodInm))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@id_registro", SqlDbType.Int, intCodRg))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@tipo_registro", SqlDbType.Int, intCodSw))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@id_solicitud", SqlDbType.Int, intCodSlt))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@canon", SqlDbType.Money, dcCanon))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@id_incremento", SqlDbType.Int, intCodIncCont))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@retencion", SqlDbType.Money, dcRetencion))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@iva", SqlDbType.Money, dcIva))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@cuota_admin", SqlDbType.Money, dcCuotaAdmin))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@nota", SqlDbType.NVarChar, strNotaCont))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@estado", SqlDbType.Int, intEstadoCont))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@id_emdc", SqlDbType.Int, intIDEmdC))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@id_emdu", SqlDbType.Int, intIDEmdU))
            {
                strError = ObjCnx.Error;
                return false;
            }

            return true;
        }

        #endregion

        private bool prmAuditoria()
        {
            if (!ObjCnx.parametros(ParameterDirection.Input, "@IDEmp", SqlDbType.Int, intCodEmp))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@IDTpAudit", SqlDbType.Int, intIDTpAdt))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@IDUsr", SqlDbType.Int, intIDUsrAdt))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@NmUsCrea", SqlDbType.VarChar, strNmUsCreaAdt))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@IDProg", SqlDbType.Int, intIDProgAdt))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@IDTrnAudit", SqlDbType.Int, intIDTrnAdt))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@DescAudit", SqlDbType.VarChar, strDescAdt))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@IPAudit", SqlDbType.VarChar, strIPAdt))
            {
                strError = ObjCnx.Error;
                return false;
            }
            if (!ObjCnx.parametros(ParameterDirection.Input, "@NmPCAudit", SqlDbType.VarChar, strNmPCAdt))
            {
                strError = ObjCnx.Error;
                return false;
            }

            return true;
        }

        #endregion
        #region "Codigos Nuevos"

        public int CodigoNuevoInmueble()
        {
            strSQL = "USP_Obtener_CodigoInmueble;";
            ObjCnx = new clsConexionBD();
            ObjCnx.SQL = strSQL;

            if (!ObjCnx.Consultar(false))
            {
                strError = ObjCnx.Error;
                ObjCnx.CerrarCnx();
                return 0;
            }

            Reader_Local = ObjCnx.Reader;

            if (!Reader_Local.HasRows)
            {
                strError = "No fue posible obtener los datos del inmueble"; // Campo en Blanco
                ObjCnx.CerrarCnx();
                return 0;
            }

            Reader_Local.Read();

            try
            {
                intCodInm = Reader_Local.GetInt32(0);

                Reader_Local.Close();
                ObjCnx.CerrarCnx();
                ObjCnx = null;
                return intCodInm;
            }
            catch (Exception e)
            {
                strError = e.Message;
                Reader_Local.Close();
                ObjCnx = null;
                return 0;
            }
        }
        public int CodigoNuevoDetalleInmueble()
        {
            strSQL = "USP_Obtener_CodigoDetalleInmueble;";
            ObjCnx = new clsConexionBD();
            ObjCnx.SQL = strSQL;

            if (!ObjCnx.Consultar(false))
            {
                strError = ObjCnx.Error;
                ObjCnx.CerrarCnx();
                return 0;
            }

            Reader_Local = ObjCnx.Reader;

            if (!Reader_Local.HasRows)
            {
                strError = "No fue posible obtener los datos de detalle del inmueble"; // Campo en Blanco
                ObjCnx.CerrarCnx();
                return 0;
            }

            Reader_Local.Read();

            try
            {
                intCodDtInm = Reader_Local.GetInt32(0);

                Reader_Local.Close();
                ObjCnx.CerrarCnx();
                ObjCnx = null;
                return intCodDtInm;
            }
            catch (Exception e)
            {
                strError = e.Message;
                Reader_Local.Close();
                ObjCnx = null;
                return 0;
            }
        }
        public int CodigoNuevoAvaluo()
        {
            strSQL = "USP_Obtener_CodigoAvaluo;";
            ObjCnx = new clsConexionBD();
            ObjCnx.SQL = strSQL;

            if (!ObjCnx.Consultar(false))
            {
                strError = ObjCnx.Error;
                ObjCnx.CerrarCnx();
                return 0;
            }

            Reader_Local = ObjCnx.Reader;

            if (!Reader_Local.HasRows)
            {
                strError = "No fue posible obtener los datos del avaluo"; // Campo en Blanco
                ObjCnx.CerrarCnx();
                return 0;
            }

            Reader_Local.Read();

            try
            {
                intCodAval = Reader_Local.GetInt32(0);

                Reader_Local.Close();
                ObjCnx.CerrarCnx();
                ObjCnx = null;
                return intCodAval;
            }
            catch (Exception e)
            {
                strError = e.Message;
                Reader_Local.Close();
                ObjCnx = null;
                return 0;
            }
        }

        #region "Contratos"

        public int CodigoNuevoContrato()
        {
            strSQL = "USP_Obtener_CodigoContratoInmuebles;";
            ObjCnx = new clsConexionBD();
            ObjCnx.SQL = strSQL;

            if (!ObjCnx.Consultar(false))
            {
                strError = ObjCnx.Error;
                ObjCnx.CerrarCnx();
                return 0;
            }

            Reader_Local = ObjCnx.Reader;

            if (!Reader_Local.HasRows)
            {
                strError = "No fue posible obtener los datos del Contrato"; // Campo en Blanco
                ObjCnx.CerrarCnx();
                return 0;
            }

            Reader_Local.Read();

            try
            {
                intCodCont = Reader_Local.GetInt32(0);

                Reader_Local.Close();
                ObjCnx.CerrarCnx();
                ObjCnx = null;
                return intCodCont;
            }
            catch (Exception e)
            {
                strError = e.Message;
                Reader_Local.Close();
                ObjCnx = null;
                return 0;
            }
        }

        #endregion

        #endregion

        private bool Grabar(bool cod)
        {
            try
            {
                ObjCnx.SQL = strSQL;

                if (!ObjCnx.ConsultarVrUnico(cod))
                {
                    strError = ObjCnx.Error;
                    ObjCnx.CerrarCnx();
                    return false;
                }

                ObjCnx.CerrarCnx();
                return true;
            }
            catch (Exception e)
            {
                strError = e.Message;
                ObjCnx.CerrarCnx();
                return false;
            }
        }

        #endregion
        #region "Metodos Publicos"

        #region "Listas Desplegables"

        public bool ListarComboAñosAvaluo()
        {
            try
            {
                clsLlenarCombos ObjLlenar = new clsLlenarCombos();
                ObjLlenar.SQL = "EXEC USP_ListarAños_Avaluo " + intCodInm + ";";
                ObjLlenar.NombreDT = "Años";
                ObjLlenar.CampoID = "Codigo";
                ObjLlenar.CampoTexto = "Codigo";

                if (!ObjLlenar.LlenarCombo_Web())
                {
                    strError = ObjLlenar.Error;
                    ObjLlenar = null;
                    return false;
                }

                ddlListas.DataSource = ObjLlenar.TablaCombo;
                ddlListas.DataTextField = "Codigo";
                ddlListas.DataValueField = "Codigo";
                ddlListas.DataBind();
                ObjLlenar = null;
                return true;
            }
            catch (Exception Er)
            {
                strError = Er.Message;
                return false;
            }
        }

        #endregion
        #region "Obtener Listar"

        public bool ObtenerListarInmueble()
        {
            try
            {
                strSQL = "EXEC USP_ObtenerListar_Inmuebles " + intCodEmp + "," + intCodInm + ",'" + strVrUnico + "'," + intCodCnf + "," + intEstadoInm + ";";
                clsLlenarGrids ObjLlenar = new clsLlenarGrids();
                ObjLlenar.SQL = strSQL;
                ObjLlenar.NombreTabla = "Inmuebles";

                if (!ObjLlenar.LlenarGrids_Web(false))
                {
                    strError = ObjLlenar.Error;
                    ObjLlenar = null;
                    return false;
                }

                dt_tblInmuebles = ObjLlenar.Tabla;
                ObjLlenar = null;
                return true;
            }
            catch (Exception Er)
            {
                strError = Er.Message;
                return false;
            }
        }
        public bool ObtenerListarDtInmueble()
        {
            try
            {
                strSQL = "EXEC USP_ObtenerListar_DetalleInmuebles " + intCodDtInm + "," + intCodInm + "," + intCodLt + "," + intEstadoDtInm + ";";
                clsLlenarGrids ObjLlenar = new clsLlenarGrids();
                ObjLlenar.SQL = strSQL;
                ObjLlenar.NombreTabla = "DtInmuebles";

                if (!ObjLlenar.LlenarGrids_Web(false))
                {
                    strError = ObjLlenar.Error;
                    ObjLlenar = null;
                    return false;
                }

                dt_tblDtInmuebles = ObjLlenar.Tabla;
                ObjLlenar = null;
                return true;
            }
            catch (Exception Er)
            {
                strError = Er.Message;
                return false;
            }
        }
        public bool ObtenerListarAvaluo()
        {
            try
            {
                strSQL = "EXEC USP_ObtenerListar_Avaluo " + intCodAval + "," + intCodLt + "," + intCodInm + "," + intEstadoInm + ";";
                clsLlenarGrids ObjLlenar = new clsLlenarGrids();
                ObjLlenar.SQL = strSQL;
                ObjLlenar.NombreTabla = "Avaluo";

                if (!ObjLlenar.LlenarGrids_Web(false))
                {
                    strError = ObjLlenar.Error;
                    ObjLlenar = null;
                    return false;
                }

                dt_tblAvaluos = ObjLlenar.Tabla;
                ObjLlenar = null;
                return true;
            }
            catch (Exception Er)
            {
                strError = Er.Message;
                return false;
            }
        }

        public bool ObtenerListarContrato()
        {
            try
            {
                strSQL = "EXEC USP_ObtenerListar_ContratoInmuebles " + intCodEmp + "," + intCodCont + ",'" + strVrUnico + "'," + intEstadoCont + ";";
                clsLlenarGrids ObjLlenar = new clsLlenarGrids();
                ObjLlenar.SQL = strSQL;
                ObjLlenar.NombreTabla = "Contrato";

                if (!ObjLlenar.LlenarGrids_Web(false))
                {
                    strError = ObjLlenar.Error;
                    ObjLlenar = null;
                    return false;
                }

                dt_tblContrato = ObjLlenar.Tabla;
                ObjLlenar = null;
                return true;
            }
            catch (Exception Er)
            {
                strError = Er.Message;
                return false;
            }
        }

        #endregion
        #region "Crear Actualizar"

        public bool CrearActualizarInmueble()
        {
            try
            {
                if (intCodInm == 0)
                {
                    intCodInm = CodigoNuevoInmueble();
                    if (intCodInm == 0)
                        return false;
                }

                ObjCnx = new clsConexionBD();

                if (!prmInmueble())
                {
                    ObjCnx.gCommand.Parameters.Clear();
                    ObjCnx = null;
                    return false;
                }

                strSQL = "USP_GrabarActualizar_Inmuebles";
                if (!Grabar(true))
                    return false;
                return true;
            }
            catch (Exception e)
            {
                strError = e.Message;
                return false;
            }
        }
        public bool CrearActualizarDtInmueble()
        {
            try
            {
                if (intCodDtInm == 0)
                {
                    intCodDtInm = CodigoNuevoDetalleInmueble();
                    if (intCodDtInm == 0)
                        return false;
                }

                if (intCodInm == 0)
                {
                    strError = "No asigno inmueble a detallar, informe al administrador del sistema";
                    return false;
                }

                ObjCnx = new clsConexionBD();

                if (!prmDetalleInmueble())
                {
                    ObjCnx.gCommand.Parameters.Clear();
                    ObjCnx = null;
                    return false;
                }

                strSQL = "USP_GrabarActualizar_DetalleInmuebles";
                if (!Grabar(true))
                    return false;
                return true;
            }
            catch (Exception e)
            {
                strError = e.Message;
                return false;
            }
        }
        public bool CrearActualizarAvaluo()
        {
            try
            {
                if (intCodAval == 0)
                {
                    intCodAval = CodigoNuevoAvaluo();
                    if (intCodAval == 0)
                        return false;
                }

                if (intCodInm == 0)
                {
                    strError = "No asigno inmueble para avaluar, informe al administrador del sistema";
                    return false;
                }

                ObjCnx = new clsConexionBD();

                if (!prmAvaluoInmueble())
                {
                    ObjCnx.gCommand.Parameters.Clear();
                    ObjCnx = null;
                    return false;
                }

                strSQL = "USP_GrabarActualizar_Avaluo";
                if (!Grabar(true))
                    return false;
                return true;
            }
            catch (Exception e)
            {
                strError = e.Message;
                return false;
            }
        }

        public bool CrearActualizarContrato()
        {
            try
            {
                if (intCodCont == 0)
                {
                    intCodCont = CodigoNuevoContrato();
                    if (intCodCont == 0)
                        return false;
                }

                ObjCnx = new clsConexionBD();

                if (!prmContrato())
                {
                    ObjCnx.gCommand.Parameters.Clear();
                    ObjCnx = null;
                    return false;
                }

                strSQL = "USP_GrabarActualizar_ContratoInmuebles";
                if (!Grabar(true))
                    return false;
                return true;
            }
            catch (Exception e)
            {
                strError = e.Message;
                return false;
            }
        }

        public bool CrearAuditoria()
        {
            try
            {
                ObjCnx = new clsConexionBD();

                if (!prmAuditoria())
                {
                    ObjCnx.gCommand.Parameters.Clear();
                    ObjCnx = null;
                    return false;
                }

                strSQL = "USP_Crear_Auditorias";
                if (!Grabar(true))
                    return false;
                return true;
            }
            catch (Exception e)
            {
                strError = e.Message;
                return false;
            }
        }

        #endregion

        #endregion
    }
}
