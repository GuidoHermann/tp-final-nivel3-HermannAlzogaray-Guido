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
        <div>
            <h1>¡Bienvenido a la página de detalles del artículo!</h1>
            <p>Aquí encontrarás información detallada y completa sobre el artículo.</p>
        </div>

    </header>

    <div class="container-fluid bg-dark-custom py-5 bg-dark text-white h-100 rounded-3">
        <div class="row">
            <div class="col-md-6">
                <div>
                    <h4>Código de artículo</h4>
                    <asp:Label ID="lblCodigoArticulo" CssClass="form-control mb-3 " Text="" runat="server" />
                </div>
                <div>
                    <h4>Nombre de artículo</h4>
                    <asp:Label ID="lblNombreArticulo" CssClass="form-control mb-3" Text="" runat="server" />
                </div>
                <div>
                    <h4>Descripción</h4>
                    <asp:Label ID="lblDescripcion" BorderColor="#000000" CssClass="form-control mb-3" Text="" runat="server" />
                </div>
                <div>
                    <h4>Marca</h4>
                    <asp:Label ID="lblMarca" CssClass="form-control mb-3" Text="" runat="server" />
                </div>
                <div>
                    <h4>Categoría</h4>
                    <asp:Label ID="lblCategoria" CssClass="form-control mb-3" Text="" runat="server" />
                </div>
                <div>
                    <h4>Precio</h4>
                    <asp:Label ID="lblPrecio" CssClass="form-control mb-3" Text="" runat="server" />
                </div>
            </div>
            <div class="col-md-6">
                <asp:Image ID="imgDetalle" CssClass="card-img-top img-fluid" runat="server" onerror="this.src='https://placehold.co/600x400/black/white?text=No+Se+Encontro+La+Imagen';" alt="..." />
            </div>
            <div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="mb-3 ">
                            <div class="mb-3">
                                <asp:Label ID="lblFavorito" Text="&#9757 Tu artículo ha sido añadido a favoritos." ForeColor="Yellow" runat="server" Visible="false" />
                            </div>
                            <div class="button-group">
                                <asp:Button ID="btnAgregarFavorito" runat="server" CssClass="btn btn-warning" Text="Agregar a Favoritos" OnClick="btnAgregarFavorito_Click" />
                                <a href="Favoritos.aspx" class="btn btn-warning">Ver Favoritos</a>
                                <a href="javascript:history.back()" class="btn btn-secondary">Volver</a>
                            </div>

                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>






</asp:Content>
