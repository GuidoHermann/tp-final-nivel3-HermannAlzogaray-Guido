<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="articulos_web.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row row-cols-1 row-cols-md-3 g-4">
        <div class="col-md-12 bg-dark text-white h-100 rounded-3">
            <div>

                <h2>Esta es la pagina de error!</h2>
                <p>Si el error persiste vuelva a intertar luego.</p>
            </div>

            <asp:Label ID="lblError" Text="" runat="server" />
            <div>
                <a href="javascript:history.back()" class="btn btn-secondary">Volver</a>

            </div>
        </div>

    </div>

</asp:Content>
