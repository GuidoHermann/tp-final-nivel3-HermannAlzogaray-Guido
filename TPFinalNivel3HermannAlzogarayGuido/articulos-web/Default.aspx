<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="articulos_web.Default" %>

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
    <asp:ScriptManager ID="scriptManDefault" runat="server" />
    <div class="container">

        <header class="bg-dark text-white text-center rounded-3">
            <div class="welcome-message">
                <h1>¡Bienvenido al home!</h1>
                <p>Aca encontraras una colección de artículos.</p>
                <p>¡Puedes agregarlos a favoritos o verlos en detalle!</p>
                <p>Solo si estas logueado &#x1F61C; </p>
            </div>
        </header>

        <main>

            <%if (repCartas.Items.Count > 0)
                {

            %>
            <div class="row row-cols-1 row-cols-md-3 g-4">
                <asp:Repeater ID="repCartas" runat="server">
                    <ItemTemplate>
                        <div class="col">
                            <div class="card bg-dark text-white h-100 rounded-3">
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

                                <% if (negocio.Seguridad.sesionActiva(Session["usuario"]))
                                    { %>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="card-footer d-flex justify-content-between">
                                            <asp:LinkButton ID="btnAgregarFavorito" runat="server" Text="Agregar a Favoritos" CommandName="AgregarFavorito" CommandArgument='<%#Eval("IdArticulo") %>' OnClick="btnAgregarFavorito_Click" CssClass="btn btn-warning"></asp:LinkButton>
                                            <asp:LinkButton ID="btnVerDetalle" runat="server" OnClick="btnVerDetalle_Click" CommandName="VerDetalle" CommandArgument='<%#Eval("IdArticulo") %>' CssClass="btn btn-primary ">Ver Detalle</asp:LinkButton>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <%
                                    }%>
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
                    <h3>No hay ningún artículo en home!!!!</h3>                  
                    <p>Si quieres agregar un artículo, ve al formulario.</p>
                </div>
                <div>
                    <a href="FormularioArticulo.aspx" class="mb-3 btn btn-secondary">Formulario</a>
                </div>
            </div>
            <%} %>
        </main>
    </div>

</asp:Content>
