<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="articulos_web.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card-img-top {
            max-width: 100%;
            max-height: 500px;
            width: auto;
            height: auto;
        }

        .required-field {
            color: yellow;
        }

            .required-field:hover::after {
                content: "Campo Requerido";
                background-color: #000;
                color: yellow;
                padding: 2px;
                border-radius: 2px;
                position: absolute;
                z-index: 999;
                margin-top: 1px;
                margin-left: 1px;
                font-size: 15px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <header class="bg-dark text-white text-center rounded-3">
        <h1>¡Bienvenido!</h1>
        <p>Estás en la página de creación de nuevos artículos.</p>
    </header>

    <asp:ScriptManager ID="ScriptManFormArticulo" runat="server" />

    <div class="container-fluid bg-dark-custom py-5 bg-dark text-white h-100 rounded-3">
        <div class="row">
            <div class="col-md-6">



                <asp:TextBox ID="txtId" runat="server" />

                <div class="mb-3">

                    <h4>Código de artículo<span class="required-field ">*</span> </h4>
                    <asp:TextBox ID="txtCodigo" CssClass="form-control mb-3" runat="server" />
                    <asp:RequiredFieldValidator ErrorMessage="&#9757 El código de  artículo es requerido." ControlToValidate="txtCodigo" Display="Dynamic" ForeColor="Yellow" runat="server" />
                    <asp:RegularExpressionValidator ErrorMessage="&#9757 El código debe contener entre 1 y 3 caracteres alfanuméricos." Display="Dynamic" ValidationExpression="^[a-zA-Z0-9]{1,3}$" ControlToValidate="txtCodigo" ForeColor="Yellow" runat="server" />
                </div>

                <div class="mb-3">

                    <h4>Nombre de artículo<span class="required-field ">*</span></h4>
                    <asp:TextBox ID="txtNombre" CssClass="form-control mb-3" runat="server" />
                    <asp:RequiredFieldValidator ErrorMessage="&#9757 El nombre del  artículo es requerido." Display="Dynamic" ControlToValidate="txtNombre" ForeColor="Yellow" runat="server" />

                </div>


                <div class="mb-3">

                    <h4>Descripción</h4>
                    <asp:TextBox ID="txtDescripcion" CssClass="form-control mb-3" runat="server" />


                </div>

                <div class="mb-3">

                    <h4>Marca</h4>
                    <asp:DropDownList ID="ddlMarca" CssClass="form-control mb-3" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ErrorMessage="&#9757 Debes seleccionar la Marca..." InitialValue="0" Display="Dynamic" ControlToValidate="ddlMarca" ForeColor="Yellow" runat="server" />
                </div>


                <div class="mb-3">

                    <h4>Categoría</h4>
                    <asp:DropDownList ID="ddlCategoria" CssClass="form-control mb-3" runat="server"></asp:DropDownList>
                    <asp:RequiredFieldValidator ErrorMessage="&#9757 Debes seleccionar la Categoria..." InitialValue="0" Display="Dynamic" ControlToValidate="ddlCategoria" ForeColor="Yellow" runat="server" />
                </div>



                <div class="mb-3">

                    <h4>Precio<span class=" required-field ">*</span></h4>
                    <asp:TextBox ID="txtPrecio" CssClass="form-control mb-3" runat="server" />
                    <asp:RequiredFieldValidator ErrorMessage="&#9757 El precio del artículo es requerido." Display="Dynamic" ControlToValidate="txtPrecio" ForeColor="Yellow" runat="server" />
                    <asp:RegularExpressionValidator ErrorMessage="&#9757 Solo numeros." Display="Dynamic" ValidationExpression="^\d+(\,\d+)?(\.\d+)?$" ControlToValidate="txtPrecio" ForeColor="Yellow" runat="server" />
                </div>


                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="mb-3 d-flex justify-content-between align-items-center">
                            <asp:Button ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" Text="Aceptar" runat="server" />
                            <a href="/" class="btn btn-secondary">Volver al Home</a>

                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>

                <div class="mb-3">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>

                            <%if (txtId.Text != "")
                                {%>
                            <div class="mb-3">

                                <asp:Button ID="btnEliminar" CausesValidation="false" CssClass="btn btn-warning" OnClick="btnEliminar_Click" Text="Eliminar" runat="server" />
                            </div>

                            <% } %>
                            <% if (Confirmar)
                                {%>


                            <div class="d-flex justify-content-between">

                                <asp:Button CausesValidation="false" ID="btnConfirmoEliminar" CssClass="btn btn-danger" Text="Eliminar" OnClick="btnConfirmoEliminar_Click" runat="server" />
                                <asp:CheckBox  CausesValidation="false" ID="chkConfirmo" CssClass="text-white h-100" Text="Confirmo la eliminación" runat="server" />
                            </div>





                            <% }%>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="col-md-6">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>

                        <div class="mb-3">
                            <h4>Imagen</h4>
                            <asp:TextBox ID="txtImagen" CssClass="form-control mb-3" AutoPostBack="true" OnTextChanged="txtImagen_TextChanged" runat="server" />
                        </div>

                        <asp:Image CssClass="card-img-top img-fluid" ImageUrl="https://placehold.co/600x400/black/white?text=No+Se+Encontro+La+Imagen"
                            ID="imgArticulo" runat="server" onerror="this.src='https://placehold.co/600x400/black/white?text=No+Se+Encontro+La+Imagen';" alt="..." />

                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
        </div>
    </div>

















</asp:Content>
