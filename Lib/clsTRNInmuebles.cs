using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* == Referencias y Usos de Librerias == */

using LibSSVP.Administracion;
using LibSSVP.Operativa;
using System.Transactions;

namespace LibSSVP.Transacciones
{
    public class clsTRNInmuebles : clsSComun
    {
        #region "Atributos"

        private string strError;
        private string strValor;

        #endregion
        #region "Propiedades"

        public string Error { get { return strError; } }

        #endregion
        #region "Metodos Privados"

        private bool InsertarAuditoria()
        {
            clsInmuebles objapp = new clsInmuebles();

            objapp.CodEmp = intCodEmp;
            objapp.IDTpAdt = intIDTpAdt;
            objapp.IDUsrAdt = intIDUsrAdt;
            objapp.NmUsCreaAdt = strNmUsCreaAdt;
            objapp.IDProgAdt = intIDProgAdt;
            objapp.IDTrnAdt = intIDTrnAdt;
            objapp.DescAdt = strValor + strDescAdt;
            objapp.IPAdt = strIPAdt;
            objapp.NmPCAdt = strNmPCAdt;

            if (!objapp.CrearAuditoria())
            {
                strError = objapp.Error;
                objapp = null;
                return false;
            }

            objapp = null;
            return true;
        }

        private bool InsertarEditarInmueble()
        {
            clsInmuebles objapp = new clsInmuebles();

            objapp.CodEmp = intCodEmp;
            objapp.CodInm = intCodInm;
            objapp.RefInm = strRefInm;
            objapp.CodTInm = intCodTInm;
            objapp.CodLt = intCodLt;
            objapp.MatInm = strMatInm;
            objapp.CodCnf = intCodCnf;
            objapp.DirInm = strDirInm;
            objapp.TelInm = strTelInm;
            objapp.EstratoInm = strEstratoInm;
            objapp.CicloInm = strCicloInm;
            objapp.EstadoInm = intEstadoInm;
            objapp.IDEmdC = intIDEmdC;
            objapp.IDEmdU = intIDEmdU;

            if (!objapp.CrearActualizarInmueble())
            {
                strError = objapp.Error;
                objapp = null;
                return false;
            }

            intCodInm = objapp.CodInm;
            intIDTrnAdt = intCodInm;
            objapp = null;
            return true;
        }
        private bool InsertarEditarDtInmueble()
        {
            clsInmuebles objapp = new clsInmuebles();

            objapp.CodDtInm = intCodDtInm;
            objapp.CodInm = intCodInm;
            objapp.CodLt = intCodLt;
            objapp.DescDtInm = strDescDtInm;
            objapp.fechaDtInm = dtmfechaDtInm;
            objapp.MonetInm = dcMonetInm;
            objapp.EstadoDtInm = intEstadoDtInm;
            objapp.IDEmdC = intIDEmdC;
            objapp.IDEmdU = intIDEmdU;

            if (!objapp.CrearActualizarDtInmueble())
            {
                strError = objapp.Error;
                objapp = null;
                return false;
            }

            intCodInm = objapp.CodInm;
            strValor = "Detalle id:" + objapp.CodDtInm.ToString() + " - ";
            intIDTrnAdt = intCodInm;
            objapp = null;
            return true;
        }
        private bool InsertarEditarAvaluo()
        {
            clsInmuebles objapp = new clsInmuebles();

            objapp.CodAval = intCodAval;
            objapp.CodInm = intCodInm;
            objapp.CodLt = intCodLt;
            objapp.Fecha = dtmFecha;
            objapp.Fecha2 = dtmFecha2;
            objapp.MonetAval = dcMonetAval;
            objapp.NotAval = strNotAval;
            objapp.IDEmdC = intIDEmdC;
            objapp.IDEmdU = intIDEmdU;

            if (!objapp.CrearActualizarAvaluo())
            {
                strError = objapp.Error;
                objapp = null;
                return false;
            }

            intCodInm = objapp.CodInm;
            strValor = "Avaluo id:" + objapp.CodAval.ToString() + " - ";
            intIDTrnAdt = intCodInm;

            objapp = null;
            return true;
           
        }

        private bool InsertarEditarContrato()
        {
            clsInmuebles objapp = new clsInmuebles();

            objapp.CodEmp = intCodEmp;
            objapp.CodCont = intCodCont;
            objapp.RefCont = strRefCont;
            objapp.Fecha = dtmFecha;
            objapp.Fecha2 = dtmFecha2;
            objapp.CodLt = intCodLt;
            objapp.CodInm = intCodInm;            
            objapp.CodRg = intCodRg;
            objapp.CodSw = intCodSw;
            objapp.CodSlt = intCodSlt;
            objapp.Canon = dcCanon;
            objapp.CodIncCont = intCodIncCont;
            objapp.Retencion = dcRetencion;
            objapp.Iva = dcIva;
            objapp.CuotaAdmin = dcCuotaAdmin;
            objapp.NotaCont = strNotaCont;
            objapp.EstadoCont = intEstadoCont;
            objapp.IDEmdC = intIDEmdC;
            objapp.IDEmdU = intIDEmdU;

            if (!objapp.CrearActualizarContrato())
            {
                strError = objapp.Error;
                objapp = null;
                return false;
            }

            intCodCont = objapp.CodCont;
            intIDTrnAdt = intCodCont;
            objapp = null;
            return true;
        }

        #endregion
        #region "Metodos Publicos"

        public bool AgregarModificarTrnInmueble()
        {
            try
            {
                using (TransactionScope objTrnScp = new TransactionScope())
                {
                    if (InsertarEditarInmueble())
                    {
                        if (InsertarAuditoria())
                        {
                            objTrnScp.Complete(); //COMMIT
                            return true;
                        }
                        else
                        {
                            objTrnScp.Dispose(); //ROLLBACK
                            return false;
                        }
                    }
                    else
                    {
                        objTrnScp.Dispose(); //ROLLBACK
                        return false;
                    }
                }
            }
            catch (TransactionException tex)
            {
                strError = tex.Message;
                return false;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }
        public bool AgregarModificarTrnDtInmueble()
        {
            try
            {
                using (TransactionScope objTrnScp = new TransactionScope())
                {
                    if (InsertarEditarDtInmueble())
                    {
                        if (InsertarAuditoria())
                        {
                            objTrnScp.Complete(); //COMMIT
                            return true;
                        }
                        else
                        {
                            objTrnScp.Dispose(); //ROLLBACK
                            return false;
                        }
                    }
                    else
                    {
                        objTrnScp.Dispose(); //ROLLBACK
                        return false;
                    }
                }
            }
            catch (TransactionException tex)
            {
                strError = tex.Message;
                return false;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }
        public bool AgregarModificarTrnAvaluo()
        {
            try
            {
                using (TransactionScope objTrnScp = new TransactionScope())
                {
                    if (InsertarEditarAvaluo())
                    {
                        if (InsertarAuditoria())
                        {
                            objTrnScp.Complete(); //COMMIT
                            return true;
                        }
                        else
                        {
                            objTrnScp.Dispose(); //ROLLBACK
                            return false;
                        }
                    }
                    else
                    {
                        objTrnScp.Dispose(); //ROLLBACK
                        return false;
                    }
                }
            }
            catch (TransactionException tex)
            {
                strError = tex.Message;
                return false;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        public bool AgregarModificarTrnContrato()
        {
            try
            {
                using (TransactionScope objTrnScp = new TransactionScope())
                {
                    if (InsertarEditarContrato())
                    {
                        if (InsertarAuditoria())
                        {
                            objTrnScp.Complete(); //COMMIT
                            return true;
                        }
                        else
                        {
                            objTrnScp.Dispose(); //ROLLBACK
                            return false;
                        }
                    }
                    else
                    {
                        objTrnScp.Dispose(); //ROLLBACK
                        return false;
                    }
                }
            }
            catch (TransactionException tex)
            {
                strError = tex.Message;
                return false;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        #endregion
    }
}
