<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ArticuloLista.aspx.cs" Inherits="articulos_web.ArticuloLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container mt-3 bg-dark text-white h-100 rounded-3">
    <div class="row">
        <div class="col-md-6">
            <div class="mb-3">
                <label class="form-label text-white">Filtrar</label>
                <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
            </div>
        </div>
        <div class="col-md-6 d-flex align-items-end">
            <div class="mb-3">
                <asp:CheckBox Text="Filtro Avanzado" CssClass="text-white" ID="chkAvanzado" runat="server" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" />
            </div>
        </div>
    </div>
     <%if (chkAvanzado.Checked)
     { %>
    <div class="row" id="filtroAvanzado" runat="server" >
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label text-white">Campo</label>
                <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                    <asp:ListItem Text="-- Seleccione una opción --" Value="0" />
                    <asp:ListItem Text="Codigo" />
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Descripcion" />
                    <asp:ListItem Text="Precio" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator ErrorMessage="Debes seleccionar el Campo para filtrar" InitialValue="0" Display="Dynamic" ControlToValidate="ddlCampo" runat="server" />

            </div>
        </div>
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label text-white">Criterio</label>
                <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control">           
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCriterio" ErrorMessage="Debes seleccionar el Criterio para filtrar" InitialValue="-1" Display="Dynamic" ControlToValidate="ddlCriterio" runat="server"/>
            </div>
        </div>
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label text-white">Filtro</label>
                <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />
                <asp:RegularExpressionValidator  ID="rgexBuscar" ErrorMessage="Formato invalido..." Display="Dynamic" ValidationExpression="^[a-zA-Z0-9\s]+$" ControlToValidate="txtFiltroAvanzado" runat="server" />
                <asp:Label ID="lblMensajeFiltroError" Text=""  runat="server" />
            </div>
        </div>
        <div class="col-md-12">
            <asp:Button Text="Buscar" runat="server" CssClass="btn btn-light" ID="btnBuscar" OnClick="btnBuscar_Click" />
            
            
            
        </div>
    </div>
    <%} %>
    <div class="row mt-3">
        <div class="col-md-12">
            <asp:GridView ID="dgvArticulo" runat="server" DataKeyNames="IdArticulo" CssClass="table table-dark table-striped table-bordered" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvArticulo_SelectedIndexChanged" OnPageIndexChanging="dgvArticulo_PageIndexChanging" AllowPaging="true" PageSize="5">
                <HeaderStyle CssClass="thead-dark" />
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" ItemStyle-CssClass="align-middle" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" ItemStyle-CssClass="align-middle" />
                    <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" ItemStyle-CssClass="align-middle" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" ItemStyle-CssClass="align-middle" />
                    <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="✍" ItemStyle-CssClass="align-middle" />
                </Columns>
            </asp:GridView>
            <div class="mb-3">
            <asp:LinkButton Text="Nuevo articulo" ID="btnNuevoArticulo" OnClick="btnNuevoArticulo_Click" CssClass="btn btn-primary mt-3" runat="server" />

            </div>
        </div>
    </div>
</div>
</asp:Content>
