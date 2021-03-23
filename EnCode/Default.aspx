<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EnCode._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <h3 class="text-info">Suscripción</h3>
    <h5 class="text-info">Para realizar la suscripción complete los siguientes datos</h5>
    <asp:Panel ID="pnlWarning" runat="server" BackColor="Red" ForeColor="White" Width="100%" Height="50px" Font-Strikeout="False" Font-Overline="False" Font-Size="XX-Large" HorizontalAlign="NotSet" Visible="False">No hay un suscriptor registrado con esos datos</asp:Panel>
    <asp:Panel ID="pnlSuccessfully" runat="server" ForeColor="White" Width="100%" Height="50px" Font-Strikeout="False" Font-Overline="False" Font-Size="XX-Large" HorizontalAlign="NotSet" Visible="False" BackColor="#00CC00">El registro fue exitoso</asp:Panel>
    <hr />
    <div class="border">
        <div class="row g-3">
            <div class="container">
                <h4>Buscar Suscriptor</h4>
                <br />
                <div class="form-group">
                    <div class="col-md-5">
                        <asp:Label ID="lblTipoDoc" runat="server" Text="Tipo de Documento" Font-Bold="true"></asp:Label>
                        <asp:DropDownList ID="cboTipoDocumento" runat="server" CssClass="form-control" >
                            <asp:ListItem>Pasaporte</asp:ListItem>
                            <asp:ListItem>Cedula</asp:ListItem>
                            <asp:ListItem>DNI</asp:ListItem>
                            <asp:ListItem>Otro</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4">
                        <asp:Label ID="lblNumeroDoc" runat="server" Text="Numero de Documento" Font-Bold="true"></asp:Label>
                        <asp:TextBox ID="txtNumeroDoc" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator_app" ControlToValidate="txtNumeroDoc"
                        ErrorMessage="InsertarNumeroDocumento" ForeColor="Red" ValidationGroup="form_ejm"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-1">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" class="btn btn-success" OnClick="btnBuscar_Click1" />
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btnVerificar" runat="server" Text="VerificarSuscripcion" class="btn btn-success" OnClick="btnVerificar_Click" />
                    </div>
                    
                    <div class="col-md-5" id="divMensaje">
                        <br />
                        <asp:Panel ID="PnlMensaje" runat="server" >
                            <asp:Label ID="lblMensaje" runat="server"  Text="Desea Registrar un Nuevo Suscrpitor?"
                            Font-Bold="true" ForeColor="red"></asp:Label>
                         <asp:Button ID="BtnSi" runat="server" Text="SI" class="btn btn-primary" OnClick="BtnSi_Click" />
                         <asp:Button ID="BtnNo" runat="server" Text="NO" class="btn btn-primary" OnClick="BtnNo_Click" />
                        </asp:Panel>
                         <asp:Panel ID="PnlSubscripto" runat="server" >
                            <asp:Label ID="LblSubscripto" runat="server"  Text="esta persona posee una subscripcion vigente"
                            Font-Bold="true" ForeColor="green" ></asp:Label>
                           <asp:Button ID="BtnCerrar" runat="server" Text="Cerrar" class="btn btn-primary" OnClick="BtnCerrar_Click" />
                        </asp:Panel>
                        <asp:Panel ID="pnlSuscribir" runat="server" >
                            <asp:Label ID="LblSuscribir" runat="server"  Text="Esta Persona no tiene una subscripcion Vigente. Desea Suscribirla?"
                            Font-Bold="true" ForeColor="red"></asp:Label>
                         <asp:Button ID="btnSuscribir" runat="server" Text="SI" class="btn btn-primary" OnClick="btnSuscribir_Click" />
                         <asp:Button ID="btnNoSus" runat="server" Text="NO" class="btn btn-primary" OnClick="btnNoSus_Click" />
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <div class="row g-3">
            <div class="container">
                <h4>Datos del Suscriptor</h4>
                <br />
                <div class="form-group">
                    <div class="col-md-5">
                        <asp:Label ID="lblNombre" runat="server" Text="Nombre" Font-Bold="true"></asp:Label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox> 
                          <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtNombre"
                        ErrorMessage="InsertarNombre" ForeColor="Red" ValidationGroup="form_ejm"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-5">
                        <asp:Label ID="lblApellido" runat="server" Text="Apellido" Font-Bold="true"></asp:Label>
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtApellido"
                        ErrorMessage="InsertarApellido" ForeColor="Red" ValidationGroup="form_ejm"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btnModificar" runat="server" Text="Modificar" class="btn btn-primary" OnClick="btnModificar_Click" ValidationGroup="form_ejm"/>
                    </div>              
                    <div class="col-md-5">
                        <asp:Label ID="lblDireccion" runat="server" Text="Direccion" Font-Bold="true"></asp:Label>
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" MaxLength="48"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtDireccion"
                        ErrorMessage="InsertarDireccion" ForeColor="Red" ValidationGroup="form_ejm"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-5">
                        <asp:Label ID="lblEmail" runat="server" Text="Email" Font-Bold="true"></asp:Label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" MaxLength="48" TextMode="Email"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="txtEmail"
                        ErrorMessage="InsertarNombre" ForeColor="Red" ValidationGroup="form_ejm"></asp:RequiredFieldValidator>                      
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" class="btn btn-info" OnClick="btnNuevo_Click" />
                    </div>
                    <div class="col-md-5">
                        <asp:Label ID="lblTelefono" runat="server" Text="Telefono" Font-Bold="true"></asp:Label>
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" MaxLength="11" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="txtTelefono"
                        ErrorMessage="InsertarTelefono" ForeColor="Red" ValidationGroup="form_ejm"></asp:RequiredFieldValidator>                      
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <div class="row g-2">
            <div class="container">
                <div class="form-group">
                    <div class="col-md-5">
                        <asp:Label ID="lblNombreUsuario" runat="server" Text="Nombre de Usuario" Font-Bold="true"></asp:Label>
                        <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control" MaxLength="30"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6" ControlToValidate="txtNombreUsuario"
                        ErrorMessage="InsertarDatos" ForeColor="Red" ValidationGroup="form_ejm"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-7">
                        <asp:Label ID="lblContasena" runat="server" Text="Contraseña" Font-Bold="true"></asp:Label>
                        <asp:TextBox ID="txtContrasena" runat="server"   CssClass="form-control" MaxLength="15" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator7" ControlToValidate="txtcontrasena"
                        ErrorMessage="InsertarDatos" ForeColor="Red" ValidationGroup="form_ejm"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="container">
                <div class="col-md-1">
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" class="btn btn-success" OnClick="btnAceptar_Click" ValidationGroup="form_ejm"/>
                </div>
                <div class="col-md-1">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-success" OnClick="btnCancelar_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
