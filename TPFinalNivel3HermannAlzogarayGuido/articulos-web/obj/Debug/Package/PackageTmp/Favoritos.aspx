<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="articulos_web.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card-img-top {
            max-width: 100%;
            max-height: 200px;
            width: auto;
            height: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scripManFavoritos" runat="server" />

    <header class="bg-dark text-white text-center rounded-3">
        <h1>Bienvenido a tus Artículos Favoritos</h1>
        <p>Descubre y gestiona aquí todos los artículos que has marcado como favoritos. ¡Disfruta de una selección personalizada de tus artículos preferidos!</p>

    </header>

    <main>

        <%if (repFavoritos.Items.Count > 0)
            {

        %>
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater ID="repFavoritos" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <div class="card bg-dark text-white mb-3 h-100 rounded-3">
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                <hr />
                                <img src="<%#Eval("Imagen") %>" class="card-img-top img-fluid " onerror="this.src='https://placehold.co/600x400/black/white?text=No+Se+Encontro+La+Imagen';" alt="...">
                                <hr />
                                <ul class="list-group list-group-flush bg-secondary text-white">
                                    <li class="list-group-item bg-secondary text-white fw-bold">Marca: <%#Eval("Marca.Descripcion") %></li>
                                    <li class="list-group-item bg-secondary text-white fw-bold">Categoría: <%#Eval("Categoria.Descripcion") %></li>
                                </ul>

                            </div>
                            <div class="card-footer d-flex justify-content-between">
                                <asp:Button ID="btnEliminarFavorito" runat="server" Text="Eliminar de Favoritos" CommandName="EliminarFavorito" CommandArgument='<%#Eval("IdArticulo") %>' OnClick="btnEliminarFavorito_Click" CssClass="btn btn-warning" />
                                <asp:LinkButton ID="btnVerDetalle" runat="server" OnClick="btnVerDetalle_Click" CommandName="VerDetalle" CommandArgument='<%#Eval("IdArticulo") %>' CssClass="btn btn-primary ">Ver Detalle</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <%}
            else
            {  %>
        <div class="bg-dark text-white text-center rounded-3">
            <div>
                <h3>No hay ningún artículo en favoritos</h3>
                <p>Si quieres agregar un artículo favorito, ve al inicio.</p>
            </div>
            <div>
                <a href="Default.aspx" class="mb-3 btn btn-secondary">Inicio</a>
            </div>
        </div>
        <%} %>
    </main>
</asp:Content>
