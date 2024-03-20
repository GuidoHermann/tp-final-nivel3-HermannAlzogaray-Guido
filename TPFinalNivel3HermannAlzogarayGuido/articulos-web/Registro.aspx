<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="articulos_web.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />

    <div class="row row-cols-1 text-white h-100 rounded-3 bg-dark row-cols-md-3 g-4 d-flex justify-content-between align-items-center gx-4">
        <div class="col-md-5">
            <h2>Creá tu perfil </h2>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtPassword" TextMode="Password" />
            </div>
            <div class="mb-3 d-flex justify-content-between">
                <asp:Button Text="Registrarse" CssClass="btn btn-primary" ID="btnRegistrarse" OnClick="btnRegistrarse_Click" runat="server" />
                <a href="/" class="btn btn-secondary" >Cancelar</a>
            </div>
        </div>
        <div class="col-md-5">
            <div class="mb-3">

                <h4>Bienvenido</h4>
                <p>Por favor, registrate para poder utilizar la pagina.</p>
                <p>Si ya tienes cuenta puedes loguearte aquí.</p>
                <a href="Login.aspx" class="btn btn-success">Login</a>
            </div>
        </div>
    </div>


</asp:Content>
