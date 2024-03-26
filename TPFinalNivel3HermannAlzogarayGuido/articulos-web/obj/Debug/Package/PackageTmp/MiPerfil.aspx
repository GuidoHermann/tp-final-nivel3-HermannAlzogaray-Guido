<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="articulos_web.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card-img-top {
            max-width: 100%;
            max-height: 300px;
            width: auto;
            height: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />

    <hr />

    <div class="row row-cols-1 text-white h-100 rounded-3 bg-dark row-cols-md-3 g-4 d-flex justify-content-between gx-4 ">
        <div class="col-md-5">
            <h4>Mi Perfil</h4>
            <div class="mb-3">

                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="txtNombre" />

            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" ClientIDMode="Static" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:Label ID="lblMsjInfo" ForeColor="Yellow" Visible="false" runat="server" />
            </div>
            <div class="mb-3 d-flex justify-content-between">
                <asp:Button Text="Guardar" CssClass="btn btn-primary" AutoPostBack="true" OnClick="btnGuardar_Click" ID="btnGuardar" runat="server" />
                <a href="/" class="btn btn-secondary">Regresar</a>
            </div>
        </div>
        <div class="col-md-5">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label class="form-label">Imagen Perfil</label>
                        <input type="file" id="txtImagen" runat="server" class="form-control" />
                    </div>
                    <div class="mb-3">
                        <asp:Image ID="imgNuevoPerfil" ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg"
                            runat="server" CssClass="card-img-top img-fluid " />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </div>

</asp:Content>
