<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="F_601.aspx.cs" Inherits="appIntranet.Formulario_web117" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div>
        <h2 class="text-center"><strong><em>Registro y Control Inmobiliario</em></strong></h2>
    </div>
    <div class="mnu btn-group" role="group" aria-label="...">
        <asp:Button runat="server" ID="btnBuscar" CssClass="btn btn-default" Text="Buscar" OnClick="btnBuscar_Click" />
        <asp:Button runat="server" ID="btnNuevo" CssClass="btn btn-default" Text="Nuevo" OnClick="btnNuevo_Click" />
        <asp:Button runat="server" ID="btnProcesar" CssClass="btn btn-default" Text="Procesar" Enabled="false" OnClick="btnProcesar_Click" />
        <asp:Button runat="server" ID="btnLimpiar" CssClass="btn btn-default" Text="Limpiar" OnClick="btnLimpiar_Click" />
        <asp:Button runat="server" ID="btnInicio" CssClass="btn btn-default" Text="Atras" OnClick="btnInicio_Click" />
    </div>
    <div style="height: 10px; background-color: #CC0000; position: relative; top: -44px; border-radius: 5px 5px 5px 5px;"></div>
    <asp:Panel ID="pnDatos" runat="server" Visible="false">
        <div style="padding-top: 30px; padding-bottom: 15px; border-style: solid; border-color: blue; border-radius: 10px; position: relative;">
            <div style="position: absolute; background: blue; top: 0px; height: 25px; width: 150px; border-radius: 5px 0px 20px 0px;"><strong style="color: white; margin-left: 15px;">Codigo:&nbsp;&nbsp;</strong><asp:Label ID="lblCod" runat="server" Text="0" ForeColor="White"></asp:Label></div>
            <asp:Panel ID="pnCreoUdp" runat="server" Visible="false" CssClass="posCU">
                <div class="alert alert-success" role="alert" style="width: 256px; padding-top: 4px; height: 80px;">
                    <p style="margin: -2.5% 0;">
                        <asp:Label ID="lblCreoUdp" runat="server" Font-Size="9px" Text="."></asp:Label>
                    </p>
                </div>
                <div style="position: absolute; top: 70px; right: 80px; z-index: -1; background-color: #c9e5be; height: 30px; border-radius: 10px; width: 90px; padding-top: 8px; text-align: center">
                    <asp:LinkButton ID="lkbAudit" runat="server" OnClick="lkbAudit_Click">Auditar</asp:LinkButton>
                </div>
            </asp:Panel>
            <div class="form-horizontal" role="form" style="margin-left: 10px; margin-top: 10px">
                <div class="form-group esptxt" style="position: relative">
                    <label for="textRef" class="col-lg-2 control-label">Codigo Ref:</label>
                    <div class="col-lg-5">
                        <input type="text" class="form-control" runat="server" id="txtRef" style="width: 170px;" maxlength="30" />
                        <div class="checkbox" style="position: absolute; top: -7px; left: 250px;">
                            <label>
                                <input runat="server" id="chkEstado" type="checkbox"  checked="checked" data-toggle="toggle" data-on="Activo" data-off="Inactivo" />
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group esptxt" style="position: relative">
                    <label for="textMat" class="col-lg-2 control-label">Matricula:</label>
                    <div class="col-lg-6">
                        <input type="text" class="form-control" runat="server" id="txtMatricula" style="width: 217px;" maxlength="180" />
                    </div>
                </div>
                <div class="form-group esptxt" style="position: relative">
                    <label for="textTipo" class="col-lg-2 control-label">Tipo:</label>
                    <div class="col-lg-5">
                        <asp:DropDownList ID="ddlTInm" runat="server" CssClass="form-control" Width="217px"></asp:DropDownList>
                        <div style="position: absolute; top: -9px; left: 212px;">
                            <asp:ImageButton ID="ibtnATInm" runat="server" Visible="true" ImageUrl="~/Estilos/Iconos/mas.png" Width="20px" OnClick="ibtnATInm_Click" />
                        </div>
                        <div style="position: absolute; top: -9px; left: 212px;">
                            <asp:ImageButton ID="ibtnUTInm" runat="server" Visible="False" ImageUrl="~/Estilos/Iconos/actualizar.png" Width="20px" OnClick="ibtnUTInm_Click" />
                        </div>
                    </div>
                </div>
                <asp:UpdatePanel ID="UPUbic" runat="server" UpdateMode="Always">
                    <ContentTemplate>
                        <div class="form-group">
                            <label for="textUbic" class="col-lg-2 control-label">Ubicación:</label>
                            <div class="col-lg-3">
                                <asp:DropDownList ID="ddlDep" runat="server" CssClass="form-control" Width="177px" AutoPostBack="true" OnSelectedIndexChanged="ddlDep_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div style="position: relative; top: 0px">
                                <div class="col-lg-3">
                                    <asp:DropDownList ID="ddlMun" runat="server" CssClass="form-control" Width="177px" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="ddlMun_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            <div style="position: relative; top: 0px">
                                <div class="col-lg-3">
                                    <asp:DropDownList ID="ddlBarrio" runat="server" CssClass="form-control" Width="225px" Enabled="false"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="form-group esptxt" style="position: relative">
                    <label for="textTDoc" class="col-lg-2 control-label">Conferencia:</label>
                    <div class="col-lg-5">
                        <asp:DropDownList ID="ddlConf" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <label for="textDir" class="col-lg-2 control-label">Dirección:</label>
                    <div class="col-lg-5">
                        <input type="text" class="form-control" runat="server" id="txtDir" maxlength="180" />
                    </div>
                    <div style="position: relative;">
                        <label for="textTel" class="col-lg-1 control-label">Tel:</label>
                        <div class="col-lg-3">
                            <input type="text" class="form-control" runat="server" name="txtTel" id="txtTel" maxlength="80" style="width: 206px" placeholder="Telefonos" />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="textEstrato" class="col-lg-2 control-label">Estrato:</label>
                    <div class="col-lg-2">
                        <input type="text" class="form-control" runat="server" id="txtEstrato" maxlength="5" onkeypress="javascript:return validarNro(event)" />
                    </div>
                    <div style="position: relative;">
                        <label for="textCiclo" class="col-lg-1 control-label">Ciclo:</label>
                        <div class="col-lg-2">
                            <input type="text" class="form-control" runat="server" name="txtCiclo" id="txtCiclo" maxlength="5" onkeypress="javascript:return validarNro(event)" />
                        </div>
                    </div>
                </div>
            </div>
            <asp:Panel ID="pnAvaluos" runat="server" Visible="false">
                <div style="position: relative; border-style: solid; border-color: grey; width: 98%; left: 7px; border-radius: 10px; margin-top: 19px;">
                    <div style="background-color: grey; border-radius: 10px 0px 10px 0px; position: relative; top: -3px; width: 300px; height: 24px; margin-bottom: 10px;">
                        <p style="color: white; padding-left: 20px;"><strong>Avaluos</strong></p>
                    </div>
                    <div style="position: absolute; top: 34px; left: 482px; z-index: 10;">
                        <asp:Panel ID="pnCreaUdpAval" runat="server" Visible="false">
                            <div class="alert alert-success" role="alert" style="width: 256px; padding-top: 4px; height: 80px;">
                                <p style="margin: -2.5% 0;">
                                    <asp:Label ID="lblCreaUdpAval" runat="server" Font-Size="9px" Text="."></asp:Label>
                                </p>
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="form-horizontal" role="form" style="margin-left: 10px; margin-top: 10px">
                        <div class="form-group esptxt" style="position: relative">
                            <label for="textRef" class="col-lg-2 control-label">Codigo:</label>
                            <div class="col-lg-5">
                                <input type="text" class="form-control" runat="server" id="txtCodAvaluo" style="width: 100px;" value="0" disabled="disabled" />
                            </div>
                        </div>
                        <div class="form-group esptxt" style="position: relative">
                            <label for="textTAval" class="col-lg-2 control-label">Tipo:</label>
                            <div class="col-lg-5">
                                <asp:DropDownList ID="ddlTAval" runat="server" CssClass="form-control" Width="217px"></asp:DropDownList>
                                <div style="position: absolute; top: -9px; left: 212px;">
                                    <asp:ImageButton ID="ibtnATAval" runat="server" Visible="true" ImageUrl="~/Estilos/Iconos/mas.png" Width="20px" OnClick="ibtnATAval_Click" />
                                </div>
                                <div style="position: absolute; top: -9px; left: 212px;">
                                    <asp:ImageButton ID="ibtnUTAval" runat="server" Visible="False" ImageUrl="~/Estilos/Iconos/actualizar.png" Width="20px" OnClick="ibtnUTAval_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="textFechaIni" class="col-lg-2 control-label">Lapso Fecha:</label>
                            <div class="col-lg-3">
                                <input type="date" class="form-control" runat="server" id="txtFIniAval" />
                            </div>
                            <div style="position: relative; top: 0px">
                                <div class="col-lg-3">
                                    <input type="date" class="form-control" runat="server" id="txtFFinAval" />
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="textMonet" class="col-lg-2 control-label">C. Monetario:</label>
                            <div class="col-lg-3">
                                <input type="text" class="form-control" runat="server" id="txtAvaluo" maxlength="200" onkeypress="javascript:return validarNro(event)" onkeyup="puntitos(this,this.value.charAt(this.value.length-1))" />
                            </div>
                            <div style="position: relative">
                                <label for="textDesc" class="col-lg-1 control-label">Nota:</label>
                                <div class="col-lg-4">
                                    <textarea type="text" class="form-control" runat="server" id="txtNotaAval" maxlength="150" rows="2" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div style="position: absolute; right: 34px; top: 124px">
                        <asp:Button ID="btnAddAval" runat="server" Text="Agregar" CssClass="btn btn-info" Height="104px" OnClick="btnAddAval_Click" />
                    </div>
                    <div style="margin: 5px; background-color: aliceblue; border-radius: 10px">
                        <asp:Panel ID="pnFiltroGridAvaluo" runat="server" Visible="true">
                            <div style="padding-bottom: 20px; padding-top: 20px">
                                <div class="form-horizontal" role="form" style="margin-left: 10px; margin-top: 10px">
                                    <div class="form-group" style="position: relative">
                                        <label for="textFiltro" class="col-lg-2 control-label">Filtro:</label>
                                        <div class="col-lg-3">
                                            <asp:DropDownList ID="ddlFTAvaluo" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                        <div style="position: relative; top: 0px">
                                            <div class="col-lg-3">
                                                <asp:DropDownList ID="ddlFAñoInm" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div>
                                            <asp:Button ID="btnFiltroAval" runat="server" Text="Filtrar" CssClass="btn btn-success" OnClick="btnFiltroAval_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <div style="position: relative; padding-bottom: 5px">
                            <asp:GridView ID="grvAvaluos" runat="server" DataKeyNames="cod" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" PageSize="6" AllowPaging="True" OnRowUpdating="grvAvaluos_RowUpdating" OnPageIndexChanging="grvAvaluos_PageIndexChanging">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgDescargar" runat="server" CommandName="Update" ImageUrl="Estilos/Iconos/Ico000.png" Width="24px" Height="24px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="3" HeaderText="Tipo" />
                                    <asp:BoundField DataField="4" HeaderText="Lapso" />
                                    <asp:BoundField DataField="5" HeaderText="" />
                                    <asp:BoundField DataField="6" HeaderText="Avaluo" DataFormatString="{0:C0}" />
                                    <asp:BoundField DataField="8" HeaderText="Estado" />
                                    <asp:BoundField DataField="12" HeaderText="Ult Actualizacion" />
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                            <div style="text-align: center">
                                <asp:Label ID="lblMsjGridAvaluo" runat="server" Text="Sin registros" ForeColor="Red"></asp:Label>
                            </div>

                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnDetalle" runat="server" Visible="false">
                <div style="position: relative; border-style: solid; border-color: grey; width: 98%; left: 7px; border-radius: 10px; margin-top: 19px;">
                    <div style="background-color: grey; border-radius: 10px 0px 10px 0px; position: relative; top: -3px; width: 300px; height: 24px; margin-bottom: 10px;">
                        <p style="color: white; padding-left: 20px;"><strong>Detalle</strong></p>
                    </div>
                    <div style="position: absolute; top: 34px; left: 482px; z-index: 10;">
                        <asp:Panel ID="pnCreaUdpDet" runat="server" Visible="false">
                            <div class="alert alert-success" role="alert" style="width: 256px; padding-top: 4px; height: 80px;">
                                <p style="margin: -2.5% 0;">
                                    <asp:Label ID="lblCreaUdpDet" runat="server" Font-Size="9px" Text="."></asp:Label>
                                </p>
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="form-horizontal" role="form" style="margin-left: 10px; margin-top: 10px">
                        <div class="form-group esptxt" style="position: relative">
                            <label for="textRef" class="col-lg-2 control-label">Codigo:</label>
                            <div class="col-lg-5">
                                <input type="text" class="form-control" runat="server" id="txtCodDet" value="0" style="width: 100px;" disabled="disabled" />
                                <div class="checkbox" style="position: absolute; top: -7px; left: 135px;">
                                    <label>
                                        <input runat="server" id="chkEstDt" type="checkbox" data-toggle="toggle" data-on="Activo" checked="checked" data-off="Inactivo" />
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group esptxt" style="position: relative">
                            <label for="textTDet" class="col-lg-2 control-label">Tipo:</label>
                            <div class="col-lg-5">
                                <asp:DropDownList ID="ddlTDetInm" runat="server" CssClass="form-control" Width="217px" AutoPostBack="true" OnSelectedIndexChanged="ddlTDetInm_SelectedIndexChanged"></asp:DropDownList>
                                <div style="position: absolute; top: -9px; left: 212px;">
                                    <asp:ImageButton ID="ibtnATDet" runat="server" Visible="true" ImageUrl="~/Estilos/Iconos/mas.png" Width="20px" OnClick="ibtnATDet_Click" />
                                </div>
                                <div style="position: absolute; top: -9px; left: 212px;">
                                    <asp:ImageButton ID="ibtnUTDet" runat="server" Visible="False" ImageUrl="~/Estilos/Iconos/actualizar.png" Width="20px" OnClick="ibtnUTDet_Click" />
                                </div>
                            </div>
                        </div>
                        <asp:Panel ID="pnContDetalle" runat="server" Visible="false">
                            <div class="form-group esptxt" style="position: relative">
                                <label for="textDesc" class="col-lg-2 control-label">Descripción:</label>
                                <div class="col-lg-8">
                                    <textarea type="text" class="form-control" runat="server" id="txtDesc" maxlength="200" rows="2" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="textFecha" class="col-lg-2 control-label">Fecha:</label>
                                <div class="col-lg-3">
                                    <input type="date" class="form-control" runat="server" id="txtFecha" />
                                </div>
                                <div style="position: relative; top: 0px">
                                    <label for="textFNace" class="col-lg-2 control-label">C. Monetario:</label>
                                    <div class="col-lg-3">
                                        <input type="text" class="form-control" runat="server" id="txtConcep" maxlength="200" onkeypress="javascript:return validarNro(event)" onkeyup="puntitos(this,this.value.charAt(this.value.length-1))" />
                                    </div>
                                </div>
                            </div>
                            <div style="position: absolute; right: 34px; top: 124px">
                                <asp:Button ID="btnAddDet" runat="server" Text="Agregar" CssClass="btn btn-info" Height="98px" OnClick="btnAddDet_Click" />
                            </div>
                        </asp:Panel>
                    </div>
                    <div style="margin: 5px; background-color: aliceblue; border-radius: 10px">
                        <asp:Panel ID="pnFiltroDetalle" runat="server" Visible="true">
                            <div style="padding-bottom: 20px; padding-top: 20px">
                                <div class="form-horizontal" role="form" style="margin-left: 10px; margin-top: 10px">
                                    <div class="form-group" style="position: relative">
                                        <label for="textFiltro" class="col-lg-2 control-label">Filtro:</label>
                                        <div class="col-lg-3">
                                            <asp:DropDownList ID="ddlFTipoDet" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                        <div style="position: relative; top: 0px">
                                            <div class="col-lg-3">
                                                <asp:DropDownList ID="ddlFEstDet" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div>
                                            <asp:Button ID="btnFiltroDet" runat="server" Text="Filtrar" CssClass="btn btn-success" OnClick="btnFiltroDet_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <div style="position: relative; padding-bottom: 5px">
                            <asp:GridView ID="grvDetalle" runat="server" DataKeyNames="cod" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" PageSize="6" AllowPaging="True" OnRowUpdating="grvDetalle_RowUpdating" OnPageIndexChanging="grvDetalle_PageIndexChanging">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgDescargar" runat="server" CommandName="Update" ImageUrl="Estilos/Iconos/Ico000.png" Width="24px" Height="24px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="3" HeaderText="Tipo" />
                                    <asp:BoundField DataField="4" HeaderText="OP Nota" />
                                    <asp:BoundField DataField="5" HeaderText="OP Fecha" />
                                    <asp:BoundField DataField="6" HeaderText="OP Concepto" DataFormatString="{0:C0}" />
                                    <asp:BoundField DataField="8" HeaderText="Estado" />
                                    <asp:BoundField DataField="12" HeaderText="Ult Actualizacion" />
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                            <div style="text-align: center">
                                <asp:Label ID="lblMsjGridDet" runat="server" Text="Sin registros" ForeColor="Red"></asp:Label>
                            </div>

                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </asp:Panel>
    <div id="modalHtml" class="modalDialog">
        <div style="position: relative">
            <asp:Panel ID="pnMsjForm" runat="server" Visible="false">
                <asp:Panel ID="pnB" runat="server" Visible="false">
                    <div class="alert alert-success" role="alert">
                        <asp:Image ID="imgB" runat="server" ImageUrl="Estilos/Iconos/Bueno.gif" Width="40px" Height="40px" />
                        &nbsp;
                        <asp:Label ID="lblMsjB" runat="server" Text=""></asp:Label>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnI" runat="server" Visible="false">
                    <div class="alert alert-info" role="alert">
                        <asp:Image ID="Image3" runat="server" ImageUrl="Estilos/Iconos/Información.png" Width="40px" Height="40px" />
                        &nbsp;
                    <asp:Label ID="lblMsjI" runat="server" Text=""></asp:Label>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnA" runat="server" Visible="false">
                    <div class="alert alert-warning" role="alert">
                        <asp:Image ID="Image4" runat="server" ImageUrl="Estilos/Iconos/Advertencia.png" Width="40px" Height="40px" />
                        &nbsp;
                    <asp:Label ID="lblMsjA" runat="server" Text=""></asp:Label>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnE" runat="server" Visible="false">
                    <div class="alert alert-danger" role="alert">
                        <asp:Image ID="Image5" runat="server" ImageUrl="Estilos/Iconos/Error.png" Width="40px" Height="40px" />
                        &nbsp;
                    <asp:Label ID="lblMsjE" runat="server" Text=""></asp:Label>
                    </div>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel ID="pnBusquedaC" runat="server" Visible="false">
                <div style="text-align: center;">
                    <div style="background-color: white; border-radius: 10px 10px 0px 0px; position: relative; top: -40px; width: 300px; height: 20px; left: 130px;">
                        <p style="color: white; padding-left: 15px;"><strong style="color: black">Buqueda Avanzada</strong></p>
                    </div>
                    <div class="form-horizontal" role="form" style="margin-left: 10px; margin-top: 10px">
                        <div class="form-group esptxt" style="position: relative">
                            <label for="textIdent" class="col-lg-2 control-label">(PDB):</label>
                            <div class="col-lg-6">
                                <input type="text" class="form-control" runat="server" id="txtPDB" maxlength="80" />
                                <div class="checkbox" style="position: absolute; top: -7px; left: 410px">
                                    <label>
                                        <input runat="server" id="chkEstView" type="checkbox" data-toggle="toggle" checked="checked" data-on="Activo" data-off="Inactivo" />
                                    </label>
                                </div>
                            </div>
                        </div>
                        <p style="margin-top: 10px;">
                            <asp:ImageButton ID="ibtnBuscarComun" runat="server" CssClass="tamview" ImageUrl="Estilos/Iconos/icoView.png" OnClick="ibtnBuscarComun_Click" />
                        </p>
                    </div>
                    <asp:Panel ID="pnGridComun" runat="server">
                        <asp:GridView ID="grvComunes" runat="server" DataKeyNames="cod" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" PageSize="6" AllowPaging="True" OnRowUpdating="grvComunes_RowUpdating" OnPageIndexChanging="grvComunes_PageIndexChanging">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgDescargar" runat="server" CommandName="Update" ImageUrl="Estilos/Iconos/Ico000.png" Width="24px" Height="24px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="2" HeaderText="Referencia" />
                                <asp:BoundField DataField="11" HeaderText="Matricula" />
                                <asp:BoundField DataField="4" HeaderText="Tipo" />
                                <asp:BoundField DataField="14" HeaderText="Dirección" />
                                <asp:BoundField DataField="10" HeaderText="Barrio" />
                                <asp:BoundField DataField="20" HeaderText="Creado" />
                                <asp:BoundField DataField="23" HeaderText="Ult Actualizacion" />
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                        <asp:Label ID="lblMsjComun" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </asp:Panel>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnAuditoria" runat="server" Visible="false">
                <div style="text-align: center;">
                    <div style="background-color: white; border-radius: 10px 10px 0px 0px; position: relative; top: -40px; width: 300px; height: 20px; left: 130px;">
                        <p style="color: white; padding-left: 15px;">
                            <strong style="color: black">Auditoria de
                        <asp:Label ID="lblNmAudit" runat="server" Text=""></asp:Label></strong>
                        </p>
                    </div>
                    <div class="form-horizontal" role="form" style="margin-left: 10px; margin-top: 10px">
                        <div class="form-group" style="position: relative">
                            <label for="textTAudit" class="col-lg-2 control-label">T. Auditoria:</label>
                            <div class="col-lg-5">
                                <asp:DropDownList ID="ddlTAudit" runat="server" CssClass="form-control" Width="309px"></asp:DropDownList>
                            </div>
                            <p>
                                <asp:ImageButton ID="ibtnAuditView" runat="server" CssClass="tamview" ImageUrl="Estilos/Iconos/icoView.png" />
                            </p>
                        </div>
                    </div>
                    <asp:GridView ID="grvAuditorias" runat="server" DataKeyNames="cod" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" PageSize="6" AllowPaging="True">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="4" HeaderText="Cedula" />
                            <asp:BoundField DataField="5" HeaderText="Nombres" />
                            <asp:BoundField DataField="6" HeaderText="Apellidos" />
                            <asp:BoundField DataField="7" HeaderText="F Nace" />
                            <asp:BoundField DataField="16" HeaderText="Telefono" />
                            <asp:BoundField DataField="37" HeaderText="Creado" />
                            <asp:BoundField DataField="40" HeaderText="Ult Actualizacion" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                    <asp:Label ID="lblMsjAudit" runat="server" Text="" ForeColor="Red"></asp:Label>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnBotones" runat="server" Visible="false">
                <div style="text-align: center;">
                    <div class="btn-group" role="group" aria-label="...">
                        <asp:Button runat="server" ID="btnAceptar" CssClass="btn btn-default" Text="Aceptar" OnClick="btnAceptar_Click" />
                    </div>
                </div>
            </asp:Panel>
            <p><a href="#c" class="btn btn-danger" style="position: absolute; top: 8px; right: 8px; border-radius: 17px;">X</a></p>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .mnu
        {
            top: -2px;
            left: 227px;
        }

        .posCU
        {
            position: absolute;
            top: 40px;
            left: 524px;
            z-index: 10;
        }

        .Foto
        {
            position: absolute;
            top: 204px;
            left: 0px;
            width: 170px;
        }

        .tmnimg
        {
            border-style: solid;
            border-color: black;
            border-width: 2px;
            border-radius: 10px;
            width: 170px;
            height: 200px;
        }

        .esptxt
        {
            margin-bottom: 11px;
        }

        .modalDialog
        {
            position: fixed;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            background: rgba(172,185,224,0.8);
            z-index: 99999;
            opacity: 0;
            -webkit-transition: opacity 100ms ease-in;
            -moz-transition: opacity 100ms ease-in;
            transition: opacity 100ms ease-in;
            pointer-events: none;
        }

            .modalDialog:target
            {
                opacity: 3;
                pointer-events: auto;
            }

            .modalDialog > div
            {
                width: 800px;
                background-color: white;
                border-radius: 8px;
                position: relative;
                margin: 10% auto;
                padding: 20px 20px 20px 20px;
                z-index: 3;
            }

        .close
        {
            background: #606061;
            color: #FFFFFF;
            line-height: 25px;
            position: absolute;
            right: -12px;
            text-align: center;
            top: -10px;
            width: 24px;
            text-decoration: none;
            font-weight: bold;
            -webkit-border-radius: 12px;
            -moz-border-radius: 12px;
            border-radius: 12px;
            -moz-box-shadow: 1px 1px 3px #000;
            -webkit-box-shadow: 1px 1px 3px #000;
            box-shadow: 1px 1px 3px #000;
        }

            .close:hover
            {
                background: #00d9ff;
            }

        .UMsj
        {
            position: relative;
            width: 700px;
            left: 48px;
            bottom: 28px;
        }

        .tamview
        {
            width: 40px;
        }
    </style>
    <script type="text/javascript">
        function validarNro(e) {
            var key;
            if (window.event) // IE
            { key = e.keyCode; } else if (e.which) // Netscape/Firefox/Opera
            { key = e.which; }
            if (key < 48 || key > 57) {
                if (key == 8) // Detectar . (punto) y backspace (retroceso)
                { return true; } else { return false; }
            } return true;
        }
        function puntitos(donde, caracter) {
            pat = /[\*,\+,\(,\),\?,\,$,\[,\],\^]/
            valor = donde.value
            largo = valor.length
            crtr = true
            if (isNaN(caracter) || pat.test(caracter) == true) {
                if (pat.test(caracter) == true) {
                    caracter = "/" + caracter
                }
                carcter = new RegExp(caracter, "g")
                valor = valor.replace(carcter, "")
                donde.value = valor
                crtr = false
            }
            else {
                var nums = new Array()
                cont = 0
                for (m = 0; m < largo; m++) {
                    if (valor.charAt(m) == "." || valor.charAt(m) == " ")
                    { continue; }
                    else {
                        nums[cont] = valor.charAt(m)
                        cont++
                    }
                }
            }
            var cad1 = "", cad2 = "", tres = 0
            if (largo > 3 && crtr == true) {
                for (k = nums.length - 1; k >= 0; k--) {
                    cad1 = nums[k]
                    cad2 = cad1 + cad2
                    tres++
                    if ((tres % 3) == 0) {
                        if (k != 0) {
                            cad2 = "." + cad2
                        }
                    }
                }
                donde.value = cad2
            }
        }
        function MostrarModalJS() {
            window.location.href = '#modalHtml';
        }
    </script>
</asp:Content>


