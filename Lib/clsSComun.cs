using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* == Referencias y Usos de Librerias == */

using System.Data;
using System.Web.UI.WebControls;

namespace LibSSVP
{
    public class clsSComun
    {
        #region "Atributos"

            #region "Globales"

                protected string strCod;
                protected string strSQL;/* -------------------------> Variable de tipo String para almacenar los parametros de Bases de Datos SQL.   */
                protected int intCodSw;/* --------------------------> Variable de tipo Entero para diferentes propositos de switches.   */
                protected string strNmDtSet;/* ----------------------> Variable de tipo String para almacenar Nombres de Dataset Llenados para Impresion por Crystal Report   */
                protected string strVrUnico;
                protected DateTime dtmFecha;
                protected DateTime dtmFecha2;
                protected int intIDEmdC;
                protected int intIDEmdU;

            #endregion
            #region "Empresas"

                protected int intCodEmp;
                protected int intIDTpIdentEmp;
                protected string strIdEmp;
                protected string strRSocialEmp;
                protected string strNmComEmp;
                protected int intVerNmEmp;
                protected string strDirEmp;
                protected string strTelEmp;
                protected string strCorreoEmp;
                protected int intEstEmp;

                protected DropDownList ddlEmpresas;
                protected DataTable dt_tblEmpresas;

            #endregion
            #region "Seguridad"

                protected int intCodMod;
                protected string strDescMod;
                protected int intEstMod;

                protected int intCodProg;
                protected string strDescProg;
                protected int intEstProg;

                protected DataTable dt_tblSeguridad;
                protected DropDownList ddlSeguridad;

                protected int intCodAO; //Codigo Accesos Otorgados
                protected int intCodEjO; //Codigo Ejecuciones Otorgadas
                protected int intCodEO; //Codigo Ejecuciones en Programas Otorgadas     

            #endregion
            #region "Empleados"

                protected int intCodUs;
                protected int intIDTipIdentUs;
                protected string strIdentUs;
                protected string strNmUs;
                protected string strApUs;
                protected string strDirUs;
                protected string strTelUs;
                protected string strCorreoUs;
                protected int intIDCargo;
                protected int intIDRol;
                protected int intEstEmd;

                protected DropDownList ddlEmpleados;
                protected DataTable dt_tblEmpleados;

                protected string strUsuario;
                protected string strPassUs;
                protected int intEstUs;

                protected DataTable dt_tblUsuarios;

            #endregion
            #region "Auditorias"

                protected int intIDTpAdt;
                protected int intIDUsrAdt;
                protected string strNmUsCreaAdt;
                protected int intIDProgAdt;
                protected int intIDTrnAdt;
                protected string strDescAdt;
                protected string strIPAdt;
                protected string strNmPCAdt;

            #endregion
            #region "Conferencia"

                protected int intCodCnf;
                protected int intEstCnf;
                protected string strDescConf;
	            protected int intIDZConf;
	            protected DateTime dtmFFunConf;
                protected DateTime dtmFAgrConf;
                protected string strBarrioConf;
                protected string strDirConf;
                protected string strTelConf;
                protected string strCelConf;
                protected string strCorreoConf;
	            protected int intIDReuConf;
                protected string strLugConf;
                protected string strDiaConf;
                protected string strHConf;
                protected string strActivConf;
                protected string strObservConf;

                protected DropDownList ddlConferencia;
                protected DataTable dt_tblConferencias;

                #region "Socios"
        
                    protected int intCodSC;
                    protected int intIDTIdentSC;
                    protected string strIdentSC;
                    protected string strNmSC;
                    protected string strApSC;
                    protected int intIDEstCvSc;
                    protected DateTime dtmFNaceSC;
                    protected string strLNace;
                    protected DateTime? dtmFIngSC;
                    protected DateTime? dtmFAspiraSC;
                    protected DateTime? dtmFConsagSC;
                    protected DateTime? dtmFSaleSC;
                    protected string strDirSC;
                    protected string strTelSC;
                    protected int intIDLabSC;
                    protected string strCorreoSC;
                    protected string strZonaSC;
                    protected int intIDNEducSC;
                    protected string strNtEduSC;
                    protected string strReligionSC;
                    protected string strObservSC;
                    protected int intIDUbicSC;
                    protected int intIDTipoSc;
                    protected int intEstSC;

                    protected DataTable dt_tblSocios;

                #endregion
                #region "Cruce"

                    protected int intCodCru;
                    protected int intCodCgSC;

                    protected DataTable dt_tblCruces;

                #endregion

            #endregion
            #region "Trabajo Social"

                protected int intCodRg;
                protected string stridRg;
                protected int intIDTIdRg;
                protected string strNmRg;
                protected string strApRg;
                protected int intEstRg;

                protected DataTable dt_tblTSocial;

                #region "DetRegistro"

                    protected int intCodDtRg;
                    protected DateTime dtmFNaceRg;
                    protected int intEdadRg;
                    protected int intIDGnRg;
                    protected int intECivRg;
                    protected int intNHijRg;
                    protected string strDirRg;
                    protected string strBarRg;
                    protected string strTelRg;
                    protected int intIDUbicRg;
                    protected int intAntRg;
                    protected string strProcRg;
                    protected string strMTvTRg;
                    protected int intEstratoRg;
                    protected int intHConvRg;
                    protected decimal dcCapAhRg;
                    protected int intRCR;
                    protected string strDescRCR;
                    protected int intDP;
                    protected string strDescDP;
                    protected int intPGS;
                    protected string strDescPGS;
                    protected int intMasc;
                    protected string strDescM;
                    protected int intVC;
                    protected string strDescVC;
                    protected int intIDTFmRg;

                    protected int intNBenefRg;
                    protected int intCondRg;

                    protected DataTable dt_tblDtRegistros;

                #endregion
                #region "DtLaborales"

                    protected int intCodLab;
                    protected int intIDTORg;
                    protected string strODesempRg;
                    protected string strEmpLabRg;
                    protected string strDirLabRg;
                    protected string strBarrLabRg;
                    protected int intAntLabRg;
                    protected string strHLabRg;
                    protected int intIDTCtRg;
                    protected decimal dcSLabRg;
                    protected string strTelLabRg;

                    protected DataTable dt_tblDtLaboral;

                #endregion
                #region "DtEducativo"

                    protected int intCodEdu;
                    protected int intIDNEduRg;
                    protected string strGrdIncRg;
                    protected string strObservEducRg;

                    protected DataTable dt_tblDtEducativo;

                #endregion
                #region "DtConyugue"

                    protected int intCodCny;
                    protected int intIDTIdentCny;
                    protected string strIdCny;
                    protected string strNmCny;                    
                    protected int intEdadCny;
                    protected DateTime dtmFNaceCny;
                    protected string strOcupCny;
                    protected int intIDNEduCny;
                    protected string strGrdIncCny;
                    protected string strNEmpCny;
                    protected string strDirEmpCny;
                    protected string strBarrEmpCny;
                    protected int intAntEmpCny;
                    protected string strHTEmpCny;                    
                    protected int intIDTContCny;
                    protected decimal dcCapAhCny;
                    protected decimal dcSlrCny;                    
                    protected string strObservCny;

                    protected int intCondCny;

                    protected DataTable dt_tblDtConyugue;

                #endregion
                #region "Familiares"

                    protected int intCodFm;
                    protected int intIDTIdentFm;
                    protected string strDescTIdentFm;
                    protected string strNmFm;
                    protected string strIdFm;
                    protected int intEdadFm;
                    protected int intIDECivFm;
                    protected string strDescECivFm;
                    protected DateTime dtmFNaceFm;
                    protected int intIDNEduFm;
                    protected string strDescNEduFm;
                    protected string strGrdIncFm;
                    protected int intIDParentFm;
                    protected string strDescParentFm;
                    protected string strOcupFm;
                    protected string strEntFm;
                    protected string strObservFm;
                    protected int intEstFm;

                    protected int intCondfm;

                    protected DataTable dt_tblFamiliares;

                    #region"Intereses Familiar"

                        protected int intIDTIntFm;
                        protected string strDescIntFm;
                        protected int intEstIntFm;

                        protected DataTable dt_tblIntFm;

                    #endregion
                    #region"Habilidades Familiar"

                        protected int intIDTHabFm;
                        protected string strDescHabFm;
                        protected int intEstHabFm;

                        protected DataTable dt_tblHabFm;

                    #endregion

                #endregion
                #region"Intereses"

                    protected int intIDTIntRg;
                    protected string strDescIntRg;
                    protected int intEstIntRg;

                    protected DataTable dt_tblDtIntereses;

                #endregion
                #region"Habilidades"

                    protected int intIDTHabRg;
                    protected string strDescHabRg;
                    protected int intEstHabRg;

                    protected DataTable dt_tblDtHabilidades;

                #endregion
                #region"Economicos"

                    protected int intIDTIngRg;
                    protected decimal dcVlrIngRg;
                    protected int intEstIngRg;
                    protected string strObservIngRg;

                    protected DataTable dt_tblDtIngresos;

                    protected int intIDTGastRg;
                    protected decimal dcVlrGastRg;
                    protected int intEstGastRg;
                    protected string strObservGastRg;

                    protected DataTable dt_tblDtGastos;

                #endregion
                #region"Seguridad Social"

                    protected int intIDTSSocRg;
                    protected string strDescTSSocRg;
                    protected int intIDSSocRg;
                    protected string strDescSSocRg;
                    protected int intEstSSocRg;

                    protected DataTable dt_tblDtSSocial;

                #endregion
                #region"Vivienda"

                    protected int intIDTVVRg;
                    protected string strDescTVVRg;
                    protected int intIDVVRg;
                    protected string strDescVVRg;
                    protected int intEstVVRg;

                    protected DataTable dt_tblDtVivienda;

                #endregion
                #region"Observaciones"

                    protected int intCodObsRg;
                    protected string strDescObservRg;
                    protected int intEstObservRg;

                    protected DataTable dt_tblDtObservaciones;

                #endregion
                #region"Desarrollos"

                    protected int intCodDs;
                    protected int intTDtDs;
                    protected int intMultDs;
                    protected string strNmMultDs;
                    protected int intTipoDs;
                    protected decimal dcVrFnDs;
                    protected string strObservDs;
                    protected int intEstDs;

                #endregion
                #region"Validacion"

                    protected int intCodVal;
                    protected int intIDTVal;
                    protected string strDescVal;
                    protected int intEstVal;

                    protected DataTable dt_tblDtValidacion;

                #endregion

                #region"Solicitudes"

                    protected int intCodSlt;
                    protected int intIDTSlt;
                    protected string strConcSlt;
                    protected int intCitarSlt;
                    protected int intEstSlt;

                    #region "Detalle Solicitud"

                        protected int intCodOSlt;
                        protected string strObservSlt;

                        protected DataTable dt_tblDtSolicitudes;

                    #endregion

                #endregion                
                #region"Autorizados"

                protected int intCodAut;
                protected int intCodLAut;
                protected string strDescLAut;
                protected int intCodTAut;

                protected DropDownList ddlAutorizado;
                protected DataTable dt_tblDtAutorizado;

                #endregion

            #endregion
            #region "Notas"

                protected int intCodNt;
                protected int intUsrPropNt;
                protected int intIDVistaNt;
                protected int intIDTPNota;
                protected string strDescNota;
                protected DateTime dtmFFNt;
                protected int intIDEstNt;

                protected int intCodIntGrp;
                protected int intUsrVt;

                protected int intCodIntDt;
                protected int intIDTPDtNt;
                protected string strDescDtNt;
                protected string strDescDtNt2;
                protected string strDescDtNt3;
                protected int intEstDtNt;

                protected DataTable tbl_dtNotas;
                protected DataTable tbl_dtGrupoNt;
                protected DataTable tbl_dtDetNotas;

            #endregion
            #region "Equipos"

                protected int intCodIntEq;
                protected int intIDUsResp;
                protected string strSerialEq;
                protected string strPlacaEq;
                protected int intIDMcEq;
                protected string strModEq;
                protected int intIDTPEq;
                protected DateTime dtmFComp;
                protected int intTMGarantia;
                protected string strObservEq;
                protected int intEstEq;

                protected DropDownList ddlEquipos;
                protected DataTable dt_tblEquipos;

            #region "Detalle Equipos"

            protected int intCodIntDtEq;
            protected int intIDTDtEq;
            protected string strDetalle1Eq;
            protected string strDetalle2Eq;
            protected string strDetalle3Eq;
            protected int intEstDtEq;

            #endregion

            #endregion
            #region "Incidentes"

                protected int intNroInc;
                protected int intUsrInc;
                protected int intIDIntEq;
                protected string strSerialEqInc;
                protected string strPlacaEqInc;
                protected int intIDEstInc;
                protected int intIDTPInc;
                protected string strAsuntoTPPinc;
                protected string strDescInc;

                protected DataTable dt_tblIncidentes;

                #region "Detalle Incidente"

                    protected int intCodIntDtInc;
                    protected int intTPDtInc;
                    protected DateTime dtmFCrea;
                    protected string strDescDtInc;

                #endregion

            #endregion
            #region "Informes"

                protected DropDownList ddlInformes;
                protected DataTable dt_tblInformes;
                protected DataSet dts_tblInformes;

            #endregion
            #region "Listas Genericas"

                protected int intCodLt;
                protected int intLtRef;
                protected int intLtCod;
                protected string strCodGnc;
                protected string strDescLt;
                protected int intCodVistaLt;
                protected int intCodDtLt;
                protected int intEstLt;

                protected DataTable dt_tblListas;
                protected DropDownList ddlListas;

            #endregion
            #region "Anexos"

                protected int intCodAnx;
                protected int intIDRefTrnAnx;
                protected int intIDTAnx;
                protected string strDescArchivo;
                protected byte[] btAnx;
                protected decimal dcTamaño;
                protected string strExtArch;
                protected int intIDVtProg;

                protected DataTable dt_tblAnexos;

            #endregion
            #region "Imagenes"

            protected int intCodImg;
            protected int intIDTpImg;
            protected int intTRefImg;
            protected int intRefImg;
            protected byte[] btImg;
            protected string strNmImg;
            protected decimal dcTamImg;
            protected string strFmtImg;
            protected int intEstImg;

            protected DataTable dt_tblImagen;

            #endregion
            #region "Citas"

                protected int intCodCt;
                protected int intCodTipoCt;
                protected DateTime dtmHoraCt;

                protected DataTable dt_tblCitas;

                #region "Asignacion"
		
                protected int intCodAsig;

                protected DataTable dt_tblAsignacion;

	            #endregion
                #region "Fecha Cita"

                protected int intCodFCt;
                protected string strlmtHora;
                protected decimal dclaptHora;
                protected string strlmtRanHora;

                protected DataTable dt_tblFechaCitas;
		 
	            #endregion

            #endregion
            #region "GMercados"

            protected int intCodGM;
            protected int intCodModGM;               

            #endregion
            #region "Grupos"

            protected int intCodGrupo;
            protected string strDescGrupo;
            protected int intBenMax;
            protected int intBenMin;
            protected string strSedeGrupo;
            protected string strNotasGrupo;
            protected int intEstGrupo;

            protected int intCodDtGrupo;
            protected int intCodTipoBenefic;
            protected string strRemiteDtGrupo;
            protected string strNotasDtGrupo;
            protected int intEstDtGrupo;
            protected int intCodEstDtGrupo;

            protected DropDownList ddlGrupo;
            protected DataTable dt_tblGrupo;
            protected DataTable dt_tblDtGrupo;

            #endregion

            //--------------- Variables de Inmuebles ------------------//
            #region "Inmuebles"

            protected int intCodInm;
            protected string strRefInm;
            protected int intCodTInm;
            protected string strMatInm;
            protected string strDirInm;
            protected string strTelInm;
            protected string strEstratoInm;
            protected string strCicloInm;
            protected int intEstadoInm;
            protected DataTable dt_tblInmuebles;
            
            #region "Detalle"

            protected int intCodDtInm;
            protected string strDescDtInm;
            protected DateTime? dtmfechaDtInm;
            protected decimal dcMonetInm;
            protected int intEstadoDtInm;
            protected DataTable dt_tblDtInmuebles;

            #endregion
            #region "Avaluos"

            protected int intCodAval;
            protected decimal dcMonetAval;
            protected string strNotAval;
            protected int intEstadoAval;
            protected DataTable dt_tblAvaluos;

            #endregion

            #endregion
            //------------- fin Variables de inmuebles ----------------//

            //--------------- Variables de Contrato ------------------//
            #region "Contratos"

            protected int intCodCont;
            protected string strRefCont;
            protected decimal dcCanon;
            protected int intCodIncCont;
            protected decimal dcIncremento;
            protected decimal dcRetencion;
            protected decimal dcIva;
            protected decimal dcCuotaAdmin;
            protected string strNotaCont;
            protected int intEstadoCont;
            protected DataTable dt_tblContrato;
            protected DataTable dt_tblDtContrato;   

            #endregion
            //------------- fin Variables de Contrato ----------------//
            
        #endregion
        #region "Propiedades"

            #region "Globales"

            public string Codigo { get { return strCod; } set { strCod = value; } }
                public string SQL { get { return strSQL; } set { strSQL = value; } }
                public int CodSw { get { return intCodSw; } set { intCodSw = value; } }
                public string NmDtSet { get { return strNmDtSet; } set { strNmDtSet = value; } }
                public string VrUnico { get { return strVrUnico; } set { strVrUnico = value; } }
                public DateTime Fecha { get { return dtmFecha; } set { dtmFecha = value; } }
                public DateTime Fecha2 { get { return dtmFecha2; } set { dtmFecha2 = value; } }
                public int IDEmdC { get { return intIDEmdC; } set { intIDEmdC = value; } }
                public int IDEmdU { get { return intIDEmdU; } set { intIDEmdU = value; } }

            #endregion
            #region "Empresas"

                public int CodEmp { get { return intCodEmp; } set { intCodEmp = value; } }
                public int IDTpIdentEmp { get { return intIDTpIdentEmp; } set { intIDTpIdentEmp = value; } }
                public string IdEmp { get { return strIdEmp; } set { strIdEmp = value; } }
                public string RSocialEmp { get { return strRSocialEmp; } set { strRSocialEmp = value; } }
                public string NmComEmp { get { return strNmComEmp; } set { strNmComEmp = value; } }
                public int VerNmEmp { get { return intVerNmEmp; } set { intVerNmEmp = value; } }
                public string DirEmp { get { return strDirEmp; } set { strDirEmp = value; } }
                public string TelEmp { get { return strTelEmp; } set { strTelEmp = value; } }
                public string CorreoEmp { get { return strCorreoEmp; } set { strCorreoEmp = value; } }
                public int EstEmp { get { return intEstEmp; } set { intEstEmp = value; } }

                public DropDownList ComboEmpresas { get { return ddlEmpresas; } set { ddlEmpresas = value; } }
                public DataTable TablaEmpresas { get { return dt_tblEmpresas; } set { dt_tblEmpresas = value; } }

            #endregion
            #region "Seguridad"

                public int CodMod { get { return intCodMod; } set { intCodMod = value; } }
                public string DescMod { get { return strDescMod; } set { strDescMod = value; } }
                public int EstMod { get { return intEstMod; } set { intEstMod = value; } }

                public int CodProg { get { return intCodProg; } set { intCodProg = value; } }
                public string DescProg { get { return strDescProg; } set { strDescProg = value; } }
                public int EstProg { get { return intEstProg; } set { intEstProg = value; } }

                public DataTable TablaSeguridad { get { return dt_tblSeguridad; } set { dt_tblSeguridad = value; } }
                public DropDownList ComboSeguridad { get { return ddlSeguridad; } set { ddlSeguridad = value; } }

                public int CodAO { get { return intCodAO; } set { intCodAO = value; } }
                public int CodEjO { get { return intCodEjO; } set { intCodEjO = value; } }
                public int CodEO { get { return intCodEO; } set { intCodEO = value; } }

            #endregion
            #region "Empleados"

                public int CodUs { get { return intCodUs; } set { intCodUs = value; } }
                public int IDTipIdentUs { get { return intIDTipIdentUs; } set { intIDTipIdentUs = value; } }
                public string IdentUs { get { return strIdentUs; } set { strIdentUs = value; } }
                public string NmUs { get { return strNmUs; } set { strNmUs = value; } }
                public string ApUs { get { return strApUs; } set { strApUs = value; } }
                public string DirUs { get { return strDirUs; } set { strDirUs = value; } }
                public string TelUs { get { return strTelUs; } set { strTelUs = value; } }
                public string CorreoUs { get { return strCorreoUs; } set { strCorreoUs = value; } }
                public int IDCargo { get { return intIDCargo; } set { intIDCargo = value; } }
                public int IDRol { get { return intIDRol; } set { intIDRol = value; } }
                public int EstEmd { get { return intEstEmd; } set { intEstEmd = value; } }

                public DropDownList ComboEmpleados { get { return ddlEmpleados; } set { ddlEmpleados = value; } }
                public DataTable TablaEmpleados { get { return dt_tblEmpleados; } set { dt_tblEmpleados = value; } }

                public string Usuario { get { return strUsuario; } set { strUsuario = value; } }
                public string PassUs { get { return strPassUs; } set { strPassUs = value; } }
                public int EstUs { get { return intEstUs; } set { intEstUs = value; } }

                public DataTable TablaUsuarios { get { return dt_tblUsuarios; } set { dt_tblUsuarios = value; } }

            #endregion
            #region "Auditorias"

                public int IDTpAdt { get { return intIDTpAdt; } set { intIDTpAdt = value; } }
                public int IDUsrAdt { get { return intIDUsrAdt; } set { intIDUsrAdt = value; } }
                public string NmUsCreaAdt { get { return strNmUsCreaAdt; } set { strNmUsCreaAdt = value; } }
                public int IDProgAdt { get { return intIDProgAdt; } set { intIDProgAdt = value; } }
                public int IDTrnAdt { get { return intIDTrnAdt; } set { intIDTrnAdt = value; } }
                public string DescAdt { get { return strDescAdt; } set { strDescAdt = value; } }
                public string IPAdt { get { return strIPAdt; } set { strIPAdt = value; } }
                public string NmPCAdt { get { return strNmPCAdt; } set { strNmPCAdt = value; } }

            #endregion
            #region "Conferencia"

                public int CodCnf { get { return intCodCnf; } set { intCodCnf = value; } }
                public int EstCnf { get { return intEstCnf; } set { intEstCnf = value; } }
                public string DescConf { get { return strDescConf; } set { strDescConf = value; } }
                public int IDZConf { get { return intIDZConf; } set { intIDZConf = value; } }
                public DateTime FFunConf { get { return dtmFFunConf; } set { dtmFFunConf = value; } }
                public DateTime FAgrConf { get { return dtmFAgrConf; } set { dtmFAgrConf = value; } }
                public string BarrioConf { get { return strBarrioConf; } set { strBarrioConf = value; } }
                public string DirConf { get { return strDirConf; } set { strDirConf = value; } }
                public string TelConf { get { return strTelConf; } set { strTelConf = value; } }
                public string CelConf { get { return strCelConf; } set { strCelConf = value; } }
                public string CorreoConf { get { return strCorreoConf; } set { strCorreoConf = value; } }
                public int IDReuConf { get { return intIDReuConf; } set { intIDReuConf = value; } }
                public string LugConf { get { return strLugConf; } set { strLugConf = value; } }
                public string DiaConf { get { return strDiaConf; } set { strDiaConf = value; } }
                public string HConf { get { return strHConf; } set { strHConf = value; } }
                public string ActivConf { get { return strActivConf; } set { strActivConf = value; } }
                public string ObservConf { get { return strObservConf; } set { strObservConf = value; } }

                public DropDownList ComboConferencia { get { return ddlConferencia; } set { ddlConferencia = value; } }
                public DataTable TablaConferencias { get { return dt_tblConferencias; } set { dt_tblConferencias = value; } }

                #region "Socios"

                    public int CodSC { get { return intCodSC; } set { intCodSC = value; } }
                    public int IDTIdentSC { get { return intIDTIdentSC; } set { intIDTIdentSC = value; } }
                    public string IdentSC { get { return strIdentSC; } set { strIdentSC = value; } }
                    public string NmSC { get { return strNmSC; } set { strNmSC = value; } }
                    public string ApSC { get { return strApSC; } set { strApSC = value; } }
                    public int IDEstCvSc { get { return intIDEstCvSc; } set { intIDEstCvSc = value; } }
                    public DateTime FNaceSC { get { return dtmFNaceSC; } set { dtmFNaceSC = value; } }
                    public string LNaceSC { get { return strLNace; } set { strLNace = value; } }
                    public DateTime? FIngSC { get { return dtmFIngSC; } set { dtmFIngSC = value; } }
                    public DateTime? FAspiraSC { get { return dtmFAspiraSC; } set { dtmFAspiraSC = value; } }
                    public DateTime? FConsagSC { get { return dtmFConsagSC; } set { dtmFConsagSC = value; } }
                    public DateTime? FSaleSC { get { return dtmFSaleSC; } set { dtmFSaleSC = value; } }
                    public string DirSC { get { return strDirSC; } set { strDirSC = value; } }
                    public string TelSC { get { return strTelSC; } set { strTelSC = value; } }
                    public int LabSC { get { return intIDLabSC; } set { intIDLabSC = value; } }
                    public string CorreoSC { get { return strCorreoSC; } set { strCorreoSC = value; } }
                    public string ZonaSC { get { return strZonaSC; } set { strZonaSC = value; } }
                    public int IDNEducSC { get { return intIDNEducSC; } set { intIDNEducSC = value; } }
                    public string NotaEduSC { get { return strNtEduSC; } set { strNtEduSC = value; } }
                    public string ReligionSC { get { return strReligionSC; } set { strReligionSC = value; } }
                    public string ObservSC { get { return strObservSC; } set { strObservSC = value; } }
                    public int IDUbicSC { get { return intIDUbicSC; } set { intIDUbicSC = value; } }
                    public int TipoSC { get { return intIDTipoSc; } set { intIDTipoSc = value; } }
                    public int EstSC { get { return intEstSC; } set { intEstSC = value; } }

                    public DataTable TablaSocios { get { return dt_tblSocios; } set { dt_tblSocios = value; } }

                #endregion
                #region "Cruce"

                    public int CodCru { get { return intCodCru; } set { intCodCru = value; } }
                    public int CodCgSC { get { return intCodCgSC; } set { intCodCgSC = value; } }

                    public DataTable TablaCruces { get { return dt_tblCruces; } set { dt_tblCruces = value; } }

                #endregion

            #endregion
            #region "Trabajo Social"

                public int CodRg { get { return intCodRg; } set { intCodRg = value; } }
                public string idRg { get { return stridRg; } set { stridRg = value; } }
                public int IDTIdRg { get { return intIDTIdRg; } set { intIDTIdRg = value; } }
                public string NmRg { get { return strNmRg; } set { strNmRg = value; } }
                public string ApRg { get { return strApRg; } set { strApRg = value; } }
                public int EstRg { get { return intEstRg; } set { intEstRg = value; } }

                public DataTable TablaTSocial { get { return dt_tblTSocial; } set { dt_tblTSocial = value; } }

                #region "DetRegistro"

                    public int CodDtRg { get { return intCodDtRg; } set { intCodDtRg = value; } }
                    public DateTime FNaceRg { get { return dtmFNaceRg; } set { dtmFNaceRg = value; } }
                    public int EdadRg { get { return intEdadRg; } set { intEdadRg = value; } }
                    public int IDGnRg { get { return intIDGnRg; } set { intIDGnRg = value; } }
                    public int ECivRg { get { return intECivRg; } set { intECivRg = value; } }
                    public int NHijRg { get { return intNHijRg; } set { intNHijRg = value; } }
                    public string DirRg { get { return strDirRg; } set { strDirRg = value; } }
                    public string BarRg { get { return strBarRg; } set { strBarRg = value; } }
                    public string TelRg { get { return strTelRg; } set { strTelRg = value; } }
                    public int IDUbicRg { get { return intIDUbicRg; } set { intIDUbicRg = value; } }
                    public int AntRg { get { return intAntRg; } set { intAntRg = value; } }
                    public string ProcRg { get { return strProcRg; } set { strProcRg = value; } }
                    public string MTvTRg { get { return strMTvTRg; } set { strMTvTRg = value; } }
                    public int EstratoRg { get { return intEstratoRg; } set { intEstratoRg = value; } }
                    public int HConvRg { get { return intHConvRg; } set { intHConvRg = value; } }
                    public decimal CapAhRg { get { return dcCapAhRg; } set { dcCapAhRg = value; } }
                    public int RCR { get { return intRCR; } set { intRCR = value; } }
                    public string DescRCR { get { return strDescRCR; } set { strDescRCR = value; } }
                    public int DP { get { return intDP; } set { intDP = value; } }
                    public string DescDP { get { return strDescDP; } set { strDescDP = value; } }
                    public int PGS { get { return intPGS; } set { intPGS = value; } }
                    public string DescPGS { get { return strDescPGS; } set { strDescPGS = value; } }
                    public int Masc { get { return intMasc; } set { intMasc = value; } }
                    public string DescM { get { return strDescM; } set { strDescM = value; } }
                    public int VC { get { return intVC; } set { intVC = value; } }
                    public string DescVC { get { return strDescVC; } set { strDescVC = value; } }
                    public int IDTFmRg { get { return intIDTFmRg; } set { intIDTFmRg = value; } }

                    public int NBenefRg { get { return intNBenefRg; } set { intNBenefRg = value; } }
                    public int CondRg { get { return intCondRg; } set { intCondRg = value; } }

                    public DataTable TablaDtRegistros { get { return dt_tblDtRegistros; } set { dt_tblDtRegistros = value; } }

                #endregion
                #region "DtLaborales"

                    public int CodLab { get { return intCodLab; } set { intCodLab = value; } }
                    public int IDTORg { get { return intIDTORg; } set { intIDTORg = value; } }
                    public string ODesempRg { get { return strODesempRg; } set { strODesempRg = value; } }
                    public string EmpLabRg { get { return strEmpLabRg; } set { strEmpLabRg = value; } }
                    public string DirLabRg { get { return strDirLabRg; } set { strDirLabRg = value; } }
                    public string BarrLabRg { get { return strBarrLabRg; } set { strBarrLabRg = value; } }
                    public int AntLabRg { get { return intAntLabRg; } set { intAntLabRg = value; } }
                    public string HLabRg { get { return strHLabRg; } set { strHLabRg = value; } }
                    public int IDTCtRg { get { return intIDTCtRg; } set { intIDTCtRg = value; } }
                    public decimal SLabRg { get { return dcSLabRg; } set { dcSLabRg = value; } }
                    public string TelLabRg { get { return strTelLabRg; } set { strTelLabRg = value; } }

                    public DataTable TablaLaboral { get { return dt_tblDtLaboral; } set { dt_tblDtLaboral = value; } }

                #endregion
                #region "DtEducativo"

                    public int CodEdu { get { return intCodEdu; } set { intCodEdu = value; } }
                    public int IDNEduRg { get { return intIDNEduRg; } set { intIDNEduRg = value; } }
                    public string GrdIncRg { get { return strGrdIncRg; } set { strGrdIncRg = value; } }
                    public string ObservEducRg { get { return strObservEducRg; } set { strObservEducRg = value; } }

                    public DataTable TablaEducativo { get { return dt_tblDtEducativo; } set { dt_tblDtEducativo = value; } }

                #endregion
                #region "Conyugue"

                    public int CodCny { get { return intCodCny; } set { intCodCny = value; } }
                    public int IDTIdentCny { get { return intIDTIdentCny; } set { intIDTIdentCny = value; } }
                    public string IdCny { get { return strIdCny; } set { strIdCny = value; } }
                    public string NmCny { get { return strNmCny; } set { strNmCny = value; } }
                    public int EdadCny { get { return intEdadCny; } set { intEdadCny = value; } }
                    public DateTime FNaceCny { get { return dtmFNaceCny; } set { dtmFNaceCny = value; } }
                    public string OcupCny { get { return strOcupCny; } set { strOcupCny = value; } }
                    public int IDNEduCny { get { return intIDNEduCny; } set { intIDNEduCny = value; } }
                    public string GrdIncCny { get { return strGrdIncCny; } set { strGrdIncCny = value; } }
                    public string NEmpCny { get { return strNEmpCny; } set { strNEmpCny = value; } }
                    public string DirEmpCny { get { return strDirEmpCny; } set { strDirEmpCny = value; } }
                    public string BarrEmpCny { get { return strBarrEmpCny; } set { strBarrEmpCny = value; } }
                    public int AntEmpCny { get { return intAntEmpCny; } set { intAntEmpCny = value; } }
                    public string HTEmpCny { get { return strHTEmpCny; } set { strHTEmpCny = value; } }
                    public int IDTContCny { get { return intIDTContCny; } set { intIDTContCny = value; } }
                    public decimal CapAhCny { get { return dcCapAhCny; } set { dcCapAhCny = value; } }
                    public decimal SlrCny { get { return dcSlrCny; } set { dcSlrCny = value; } }
                    public string ObservCny { get { return strObservCny; } set { strObservCny = value; } }

                    public int CondCny { get { return intCondCny; } set { intCondCny = value; } }

                    public DataTable TablaDtConyugue { get { return dt_tblDtConyugue; } set { dt_tblDtConyugue = value; } }

                #endregion
                #region "Familiares"

                    public int CodFm { get { return intCodFm; } set { intCodFm = value; } }
                    public int IDTIdentFm { get { return intIDTIdentFm; } set { intIDTIdentFm = value; } }
                    public string DescTIdentFm { get { return strDescTIdentFm; } set { strDescTIdentFm = value; } }
                    public string NmFm { get { return strNmFm; } set { strNmFm = value; } }
                    public string IdFm { get { return strIdFm; } set { strIdFm = value; } }
                    public int EdadFm { get { return intEdadFm; } set { intEdadFm = value; } }
                    public int IDECivFm { get { return intIDECivFm; } set { intIDECivFm = value; } }
                    public string DescECivFm { get { return strDescECivFm; } set { strDescECivFm = value; } }
                    public DateTime FNaceFm { get { return dtmFNaceFm; } set { dtmFNaceFm = value; } }
                    public int IDNEduFm { get { return intIDNEduFm; } set { intIDNEduFm = value; } }
                    public string DescNEduFm { get { return strDescNEduFm; } set { strDescNEduFm = value; } }
                    public string GrdIncFm { get { return strGrdIncFm; } set { strGrdIncFm = value; } }
                    public int IDParentFm { get { return intIDParentFm; } set { intIDParentFm = value; } }
                    public string DescParentFm { get { return strDescParentFm; } set { strDescParentFm = value; } }
                    public string OcupFm { get { return strOcupFm; } set { strOcupFm = value; } }
                    public string EntFm { get { return strEntFm; } set { strEntFm = value; } }
                    public string ObservFm { get { return strObservFm; } set { strObservFm = value; } }
                    public int EstFm { get { return intEstFm; } set { intEstFm = value; } }

                    public int CondFm { get { return intCondfm; } set { intCondfm = value; } }

                    public DataTable TablaFamiliares { get { return dt_tblFamiliares; } set { dt_tblFamiliares = value; } }

                    #region"Intereses Familiar"

                        public int IDTIntFm { get { return intIDTIntFm; } set { intIDTIntFm = value; } }
                        public string DescIntFm { get { return strDescIntFm; } set { strDescIntFm = value; } }
                        public int EstIntFm { get { return intEstIntFm; } set { intEstIntFm = value; } }

                        public DataTable TablaIntFm { get { return dt_tblIntFm; } set { dt_tblIntFm = value; } }
        
                    #endregion
                    #region"Habilidades Familiar"

                        public int IDTHabFm { get { return intIDTHabFm; } set { intIDTHabFm = value; } }
                        public string DescHabFm { get { return strDescHabFm; } set { strDescHabFm = value; } }
                        public int EstHabFm { get { return intEstHabFm; } set { intEstHabFm = value; } }

                        public DataTable TablaHabFm { get { return dt_tblHabFm; } set { dt_tblHabFm = value; } }

                    #endregion

                #endregion
                #region"Intereses"

                    public int IDTIntRg { get { return intIDTIntRg; } set { intIDTIntRg = value; } }
                    public string DescIntRg { get { return strDescIntRg; } set { strDescIntRg = value; } }
                    public int EstIntRg { get { return intEstIntRg; } set { intEstIntRg = value; } }

                    public DataTable TablaDtIntereses { get { return dt_tblDtIntereses; } set { dt_tblDtIntereses = value; } }

                #endregion
                #region"Habilidades"

                    public int IDTHabRg { get { return intIDTHabRg; } set { intIDTHabRg = value; } }
                    public string DescHabRg { get { return strDescHabRg; } set { strDescHabRg = value; } }
                    public int EstHabRg { get { return intEstHabRg; } set { intEstHabRg = value; } }

                    public DataTable TablaDtHabilidades { get { return dt_tblDtHabilidades; } set { dt_tblDtHabilidades = value; } }

                #endregion
                #region"Economicos"

                    public int IDTIngRg { get { return intIDTIngRg; } set { intIDTIngRg = value; } }
                    public decimal VlrIngRg { get { return dcVlrIngRg; } set { dcVlrIngRg = value; } }
                    public int EstIngRg { get { return intEstIngRg; } set { intEstIngRg = value; } }
                    public string ObservIngRg { get { return strObservIngRg; } set { strObservIngRg = value; } }

                    public DataTable TablaDtIngresos { get { return dt_tblDtIngresos; } set { dt_tblDtIngresos = value; } }

                    public int IDTGastRg { get { return intIDTGastRg; } set { intIDTGastRg = value; } }
                    public decimal VlrGastRg { get { return dcVlrGastRg; } set { dcVlrGastRg = value; } }
                    public int EstGastRg { get { return intEstGastRg; } set { intEstGastRg = value; } }
                    public string ObservGastRg { get { return strObservGastRg; } set { strObservGastRg = value; } }

                    public DataTable TablaDtGastos { get { return dt_tblDtGastos; } set { dt_tblDtGastos = value; } }

                #endregion
                #region"Seguridad Social"

                    public int IDTSSocRg { get { return intIDTSSocRg; } set { intIDTSSocRg = value; } }
                    public string DescTSSocRg { get { return strDescTSSocRg; } set { strDescTSSocRg = value; } }
                    public int IDSSocRg { get { return intIDSSocRg; } set { intIDSSocRg = value; } }
                    public string DescSSocRg { get { return strDescSSocRg; } set { strDescSSocRg = value; } }
                    public int EstSSocRg { get { return intEstSSocRg; } set { intEstSSocRg = value; } }

                    public DataTable TablaDtSSocial { get { return dt_tblDtSSocial; } set { dt_tblDtSSocial = value; } }

                #endregion
                #region"Vivienda"

                    public int IDTVVRg { get { return intIDTVVRg; } set { intIDTVVRg = value; } }
                    public string DescTVVRg { get { return strDescTVVRg; } set { strDescTVVRg = value; } }
                    public int IDVVRg { get { return intIDVVRg; } set { intIDVVRg = value; } }
                    public string DescVVRg { get { return strDescVVRg; } set { strDescVVRg = value; } }
                    public int EstVVRg { get { return intEstVVRg; } set { intEstVVRg = value; } }

                    public DataTable TablaDtVV { get { return dt_tblDtVivienda; } set { dt_tblDtVivienda = value; } }

                #endregion
                #region"Observaciones"

                    public int CodObsRg { get { return intCodObsRg; } set { intCodObsRg = value; } }
                    public string DescObservRg { get { return strDescObservRg; } set { strDescObservRg = value; } }
                    public int EstObservRg { get { return intEstObservRg; } set { intEstObservRg = value; } }

                    public DataTable TablaDtObservacion { get { return dt_tblDtObservaciones; } set { dt_tblDtObservaciones = value; } }

                #endregion
                #region"Desarrollos"

                    public int CodDs { get { return intCodDs; } set { intCodDs = value; } }
                    public int TDtDs { get { return intTDtDs; } set { intTDtDs = value; } }
                    public int MultDs { get { return intMultDs; } set { intMultDs = value; } }
                    public string NmMultDs { get { return strNmMultDs; } set { strNmMultDs = value; } }
                    public int TipoDs { get { return intTipoDs; } set { intTipoDs = value; } }
                    public decimal VrFnDs { get { return dcVrFnDs; } set { dcVrFnDs = value; } }
                    public string ObservDs { get { return strObservDs; } set { strObservDs = value; } }
                    public int EstDs { get { return intEstDs; } set { intEstDs = value; } }

                #endregion
                #region"Validacion"

                    public int CodVal { get { return intCodVal; } set { intCodVal = value; } }
                    public int IDTVal { get { return intIDTVal; } set { intIDTVal = value; } }
                    public string DescVal { get { return strDescVal; } set { strDescVal = value; } }
                    public int EstVal { get { return intEstVal; } set { intEstVal = value; } }

                    public DataTable TablaDtValidacion { get { return dt_tblDtValidacion; } set { dt_tblDtValidacion = value; } }

                #endregion

                #region"Solicitudes"

                    public int CodSlt { get { return intCodSlt; } set { intCodSlt = value; } }
                    public int IDTSlt { get { return intIDTSlt; } set { intIDTSlt = value; } }
                    public string ConcSlt { get { return strConcSlt; } set { strConcSlt = value; } }
                    public int CitarSlt { get { return intCitarSlt; } set { intCitarSlt = value; } }
                    public int EstSlt { get { return intEstSlt; } set { intEstSlt = value; } }

                    public int CodOSlt { get { return intCodOSlt; } set { intCodOSlt = value; } }
                    public string ObservSlt { get { return strObservSlt; } set { strObservSlt = value; } }

                    public DataTable TablaDtSolicitudes { get { return dt_tblDtSolicitudes; } set { dt_tblDtSolicitudes = value; } }

                #endregion
                #region"Autorizados"

                    public int CodAut { get { return intCodAut; } set { intCodAut = value; } }
                    public int CodLAut { get { return intCodLAut; } set { intCodLAut = value; } }
                    public string DescLAut { get { return strDescLAut; } set { strDescLAut = value; } }
                    public int CodTAut { get { return intCodTAut; } set { intCodTAut = value; } }

                    public DropDownList ComboAutorizado { get { return ddlAutorizado; } set { ddlAutorizado = value; } }
                    public DataTable TablaAutorizado { get { return dt_tblDtAutorizado; } set { dt_tblDtAutorizado = value; } }

                #endregion


            #endregion
            #region "Notas"

                public int CodNt { get { return intCodNt; } set { intCodNt = value; } }
                public int UsrPropNt { get { return intUsrPropNt; } set { intUsrPropNt = value; } }
                public int IDVistaNt { get { return intIDVistaNt; } set { intIDVistaNt = value; } }
                public int IDTPNota { get { return intIDTPNota; } set { intIDTPNota = value; } }
                public string DescNota { get { return strDescNota; } set { strDescNota = value; } }
                public DateTime FFNt { get { return dtmFFNt; } set { dtmFFNt = value; } }
                public int IDEstNt { get { return intIDEstNt; } set { intIDEstNt = value; } }

                public int CodIntGrp { get { return intCodIntGrp; } set { intCodIntGrp = value; } }
                public int UsrVt { get { return intUsrVt; } set { intUsrVt = value; } }

                public int CodIntDt { get { return intCodIntDt; } set { intCodIntDt = value; } }
                public int IDTPDtNt { get { return intIDTPDtNt; } set { intIDTPDtNt = value; } }
                public string DescDtNt { get { return strDescDtNt; } set { strDescDtNt = value; } }
                public string DescDtNt2 { get { return strDescDtNt2; } set { strDescDtNt2 = value; } }
                public string DescDtNt3 { get { return strDescDtNt3; } set { strDescDtNt3 = value; } }
                public int EstDtNt { get { return intEstDtNt; } set { intEstDtNt = value; } }

                public DataTable TablaNotas { get { return tbl_dtNotas; } set { tbl_dtNotas = value; } }
                public DataTable TablaGrupoNt { get { return tbl_dtGrupoNt; } set { tbl_dtGrupoNt = value; } }
                public DataTable TablaDetNotas { get { return tbl_dtDetNotas; } set { tbl_dtDetNotas = value; } }

            #endregion
            #region "Equipos"

                public int CodIntEq { get { return intCodIntEq; } set { intCodIntEq = value; } }
                public int IDUsResp { get { return intIDUsResp; } set { intIDUsResp = value; } }
                public string SerialEq { get { return strSerialEq; } set { strSerialEq = value; } }
                public string PlacaEq { get { return strPlacaEq; } set { strPlacaEq = value; } }
                public int IDMcEq { get { return intIDMcEq; } set { intIDMcEq = value; } }
                public string ModEq { get { return strModEq; } set { strModEq = value; } }
                public int IDTPEq { get { return intIDTPEq; } set { intIDTPEq = value; } }
                public DateTime FComp { get { return dtmFComp; } set { dtmFComp = value; } }
                public int TMGarantia { get { return intTMGarantia; } set { intTMGarantia = value; } }
                public string ObservEq { get { return strObservEq; } set { strObservEq = value; } }
                public int EstEq { get { return intEstEq; } set { intEstEq = value; } }

                public DropDownList ComboEquipos { get { return ddlEquipos; } set { ddlEquipos = value; } }
                public DataTable TablaEquipos { get { return dt_tblEquipos; } set { dt_tblEquipos = value; } }

                #region "Detalle Equipos"

                    public int CodIntDtEq { get { return intCodIntDtEq; } set { intCodIntDtEq = value; } }
                    public int IDTDtEq { get { return intIDTDtEq; } set { intIDTDtEq = value; } }
                    public DateTime FCrea { get { return dtmFCrea; } set { dtmFCrea = value; } }            
                    public string Detalle1Eq { get { return strDetalle1Eq; } set { strDetalle1Eq = value; } }
                    public string Detalle2Eq { get { return strDetalle2Eq; } set { strDetalle2Eq = value; } }
                    public string Detalle3Eq { get { return strDetalle3Eq; } set { strDetalle3Eq = value; } }
                    public int EstDetEq { get { return intEstDtEq; } set { intEstDtEq = value; } }

                #endregion

            #endregion
            #region "Incidentes"

                public int NroInc { get { return intNroInc; } set { intNroInc = value; } }
                public int UsrInc { get { return intUsrInc; } set { intUsrInc = value; } }
                public int IDIntEqInc { get { return intIDIntEq; } set { intIDIntEq = value; } }
                public string SerialEqInc { get { return strSerialEqInc; } set { strSerialEqInc = value; } }
                public string PlacaEqInc { get { return strPlacaEqInc; } set { strPlacaEqInc = value; } }
                public int IDEstInc { get { return intIDEstInc; } set { intIDEstInc = value; } }
                public int IDTPInc { get { return intIDTPInc; } set { intIDTPInc = value; } }
                public string AsuntoTPPinc { get { return strAsuntoTPPinc; } set { strAsuntoTPPinc = value; } }
                public string DescInc { get { return strDescInc; } set { strDescInc = value; } }

                public DataTable TablaIncidentes { get { return dt_tblIncidentes; } set { dt_tblIncidentes = value; } }

                #region "Detalle Incidente"

                    public int CodIntDtInc { get { return intCodIntDtInc; } set { intCodIntDtInc = value; } }
                    public int TPDtInc { get { return intTPDtInc; } set { intTPDtInc = value; } }
                    public string DescDtInc { get { return strDescDtInc; } set { strDescDtInc = value; } }

                #endregion

            #endregion
            #region "Informes"

                public DropDownList ComboInformes { get { return ddlInformes; } set { ddlInformes = value; } }
                public DataTable TablaInformes { get { return dt_tblInformes; } set { dt_tblInformes = value; } }
                public DataSet DatasetInformes { get { return dts_tblInformes; } set { dts_tblInformes = value; } }

            #endregion
            #region "Listas Genericas"

                public int CodLt { get { return intCodLt; } set { intCodLt = value; } }
                public int LtRef { get { return intLtRef; } set { intLtRef = value; } }
                public int LtCod { get { return intLtCod; } set { intLtCod = value; } }
                public string CodGnc { get { return strCodGnc; } set { strCodGnc = value; } }
                public string DescLt { get { return strDescLt; } set { strDescLt = value; } }
                public int CodVistaLt { get { return intCodVistaLt; } set { intCodVistaLt = value; } }
                public int CodDtLt { get { return intCodDtLt; } set { intCodDtLt = value; } }
                public int EstLt { get { return intEstLt; } set { intEstLt = value; } }

                public DataTable TablaListas { get { return dt_tblListas; } set { dt_tblListas = value; } }
                public DropDownList ComboListas { get { return ddlListas; } set { ddlListas = value; } }

            #endregion
            #region "Anexos"

                public int CodAnx { get { return intCodAnx; } set { intCodAnx = value; } }
                public int IDRefTrnAnx { get { return intIDRefTrnAnx; } set { intIDRefTrnAnx = value; } }
                public int IDTAnx { get { return intIDTAnx; } set { intIDTAnx = value; } }
                public string DescArchivo { get { return strDescArchivo; } set { strDescArchivo = value; } }
                public byte[] Anx { get { return btAnx; } set { btAnx = value; } }
                public decimal Tamaño { get { return dcTamaño; } set { dcTamaño = value; } }
                public string ExtArch { get { return strExtArch; } set { strExtArch = value; } }
                public int IDVtProg { get { return intIDVtProg; } set { intIDVtProg = value; } }

                public DataTable TablaAnexos { get { return dt_tblAnexos; } set { dt_tblAnexos = value; } }

            #endregion
            #region "Imagenes"

            public int CodImg { get { return intCodImg; } set { intCodImg = value; } }
            public int IDTpImg { get { return intIDTpImg; } set { intIDTpImg = value; } }
            public int TRefImg { get { return intTRefImg; } set { intTRefImg = value; } }
            public int RefImg { get { return intRefImg; } set { intRefImg = value; } }
            public byte[] Img { get { return btImg; } set { btImg = value; } }
            public string NmImg { get { return strNmImg; } set { strNmImg = value; } }
            public decimal TamImg { get { return dcTamImg; } set { dcTamImg = value; } }
            public string FmtImg { get { return strFmtImg; } set { strFmtImg = value; } }
            public int EstImg { get { return intEstImg; } set { intEstImg = value; } }

            public DataTable TablaImagen { get { return dt_tblImagen; } set { dt_tblImagen = value; } }

            #endregion
            #region "Citas"

                public int CodCt { get { return intCodCt; } set { intCodCt = value; } }
                public int CodTipoCt { get { return intCodTipoCt; } set { intCodTipoCt = value; } }
                public DateTime HoraCt { get { return dtmHoraCt; } set { dtmHoraCt = value; } }
                public DataTable TablaCitas { get { return dt_tblCitas; } set { dt_tblCitas = value; } }

                #region "Asignacion"

                public int CodAsig { get { return intCodAsig; } set { intCodAsig = value; } }

                public DataTable TablaAsignacion { get { return dt_tblAsignacion; } set { dt_tblAsignacion = value; } }

                #endregion
                #region "Fecha Cita"

                public int CodFCt { get { return intCodFCt; } set { intCodFCt = value; } }
                public string lmtHora { get { return strlmtHora; } set { strlmtHora = value; } }
                public decimal laptHora { get { return dclaptHora; } set { dclaptHora = value; } }
                public string lmtRanHora { get { return strlmtRanHora; } set { strlmtRanHora = value; } }

                public DataTable TablaFechaCitas { get { return dt_tblFechaCitas; } set { dt_tblFechaCitas = value; } }

                #endregion

            #endregion
            #region "GMercados"

            public int CodGM { get { return intCodGM; } set { intCodGM = value; } }
            public int CodModGM { get { return intCodModGM; } set { intCodModGM = value; } }

            #endregion
            #region "Grupos"

            public int CodGrupo { get { return intCodGrupo; } set { intCodGrupo = value; } }
            public string DescGrupo { get { return strDescGrupo; } set { strDescGrupo = value; } }
            public int BenMax { get { return intBenMax; } set { intBenMax = value; } }
            public int BenMin { get { return intBenMin; } set { intBenMin = value; } }
            public string SedeGrupo { get { return strSedeGrupo; } set { strSedeGrupo = value; } }
            public string NotasGrupo { get { return strNotasGrupo; } set { strNotasGrupo = value; } }
            public int EstGrupo { get { return intEstGrupo; } set { intEstGrupo = value; } }

            public int CodDtGrupo { get { return intCodDtGrupo; } set { intCodDtGrupo = value; } }
            public int CodTipoBenefic { get { return intCodTipoBenefic; } set { intCodTipoBenefic = value; } }
            public string RemiteDtGrupo { get { return strRemiteDtGrupo; } set { strRemiteDtGrupo = value; } }
            public string NotasDtGrupo { get { return strNotasDtGrupo; } set { strNotasDtGrupo = value; } }
            public int EstDtGrupo { get { return intEstDtGrupo; } set { intEstDtGrupo = value; } }
            public int CodEstDtGrupo { get { return intCodEstDtGrupo; } set { intCodEstDtGrupo = value; } }

            public DropDownList comboGrupo { get { return ddlGrupo; } set { ddlGrupo = value; } }
            public DataTable TablaGrupo { get { return dt_tblGrupo; } set { dt_tblGrupo = value; } }
            public DataTable TablaDtGrupo { get { return dt_tblDtGrupo; } set { dt_tblDtGrupo = value; } }

            #endregion

            //--------------- Propiedades de Inmuebles ------------------//
            #region "Inmuebles"

            public int CodInm { get { return intCodInm; } set { intCodInm = value; } }
            public string RefInm { get { return strRefInm; } set { strRefInm = value; } }
            public int CodTInm { get { return intCodTInm; } set { intCodTInm = value; } }
            public string MatInm { get { return strMatInm; } set { strMatInm = value; } }
            public string DirInm { get { return strDirInm; } set { strDirInm = value; } }
            public string TelInm { get { return strTelInm; } set { strTelInm = value; } }
            public string EstratoInm { get { return strEstratoInm; } set { strEstratoInm = value; } }
            public string CicloInm { get { return strCicloInm; } set { strCicloInm = value; } }
            public int EstadoInm { get { return intEstadoInm; } set { intEstadoInm = value; } }
            public DataTable TablaInmueble { get { return dt_tblInmuebles; } set { dt_tblInmuebles = value; } }

            #region "Detalle"

            public int CodDtInm { get { return intCodDtInm; } set { intCodDtInm = value; } }
            public string DescDtInm { get { return strDescDtInm; } set { strDescDtInm = value; } }
            public DateTime? fechaDtInm { get { return dtmfechaDtInm; } set { dtmfechaDtInm = value; } }
            public decimal MonetInm { get { return dcMonetInm; } set { dcMonetInm = value; } }
            public int EstadoDtInm { get { return intEstadoDtInm; } set { intEstadoDtInm = value; } }
            public DataTable TablaDtInmueble { get { return dt_tblDtInmuebles; } set { dt_tblDtInmuebles = value; } }

            #endregion
            #region "Avaluos"

            public int CodAval { get { return intCodAval; } set { intCodAval = value; } }
            public decimal MonetAval { get { return dcMonetAval; } set { dcMonetAval = value; } }
            public string NotAval { get { return strNotAval; } set { strNotAval = value; } }
            public int EstadoAval { get { return intEstadoAval; } set { intEstadoAval = value; } }
            public DataTable TablaAvaluo { get { return dt_tblAvaluos; } set { dt_tblAvaluos = value; } }

            #endregion

            #endregion
            //------------- fin propiedades de inmuebles ----------------//

            //--------------- Propiedades de Contrato ------------------//
            #region "Contrato"

            public int CodCont { get { return intCodCont; } set { intCodCont = value; } }
            public string RefCont { get { return strRefCont; } set { strRefCont = value; } }
            public decimal Canon { get { return dcCanon; } set { dcCanon = value; } }
            public int CodIncCont { get { return intCodIncCont; } set { intCodIncCont = value; } }
            public decimal Incremento { get { return dcIncremento; } set { dcIncremento = value; } }
            public decimal Retencion { get { return dcRetencion; } set { dcRetencion = value; } }
            public decimal CuotaAdmin { get { return dcCuotaAdmin; } set { dcCuotaAdmin = value; } }
            public decimal Iva { get { return dcIva; } set { dcIva = value; } }
            public string NotaCont { get { return strNotaCont; } set { strNotaCont = value; } }
            public int EstadoCont { get { return intEstadoCont; } set { intEstadoCont = value; } }
            public DataTable TablaContrato { get { return dt_tblContrato; } set { dt_tblContrato = value; } }
            public DataTable TablaDtContrato { get { return dt_tblDtContrato; } set { dt_tblDtContrato = value; } } 

            #endregion
        //------------- fin propiedades de Contrato ----------------//

        #endregion
    }
}
