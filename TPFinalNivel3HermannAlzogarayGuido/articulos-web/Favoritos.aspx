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
    <h1>Hola!</h1>
    <p>Llegaste a la página de tus articulos favoritos.</p>

</header>

    <main>
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
    </main>
</asp:Content>
