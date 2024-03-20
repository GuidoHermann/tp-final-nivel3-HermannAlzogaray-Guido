<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="articulos_web.DetalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card-img-top {
            max-width: 100%;
            max-height: 500px;
            width: auto;
            height: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scripManDetalle" runat="server" />

    <header class="bg-dark text-white text-center rounded-3">
        <h1>Hola!</h1>
        <p>Llegaste a la página de detalle del artículo.</p>

    </header>

    <div class="container-fluid bg-dark-custom py-5 bg-dark text-white h-100 rounded-3">
        <div class="row">
            <div class="col-md-6">
                <h4>Código de artículo</h4>
                <asp:Label ID="lblCodigoArticulo" CssClass="form-control mb-3 " Text="" runat="server" />

                <h4>Nombre de artículo</h4>
                <asp:Label ID="lblNombreArticulo" CssClass="form-control mb-3" Text="" runat="server" />

                <h4>Descripción</h4>
                <asp:Label ID="lblDescripcion" BorderColor="#000000" CssClass="form-control mb-3" Text="" runat="server" />

                <h4>Marca</h4>
                <asp:Label ID="lblMarca" CssClass="form-control mb-3" Text="" runat="server" />

                <h4>Categoría</h4>
                <asp:Label ID="lblCategoria" CssClass="form-control mb-3" Text="" runat="server" />

                <h4>Precio</h4>
                <asp:Label ID="lblPrecio" CssClass="form-control mb-3" Text="" runat="server" />
            </div>
            <div class="col-md-6">
                <asp:Image ID="imgDetalle" CssClass="card-img-top img-fluid" runat="server" onerror="this.src='https://placehold.co/600x400/black/white?text=No+Se+Encontro+La+Imagen';" alt="..." />
            </div>
            <div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div>
                            <asp:Button ID="btnAgregarFavorito" runat="server" CssClass="btn btn-outline-warning" Text="Agregar a Favoritos" OnClick="btnAgregarFavorito_Click" />
                            <a href="Favoritos.aspx" class="btn btn-outline-warning">Ver Favoritos</a>
                            <asp:Label ID="lblFavorito" Text="" runat="server" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>






</asp:Content>
