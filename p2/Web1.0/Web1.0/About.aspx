<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Web1._0.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
    <!--Formulario locochon-->

     <asp:TextBox ID="txtDocumento" runat="server"></asp:TextBox>
     <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
     <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
     <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
     <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" OnClick="BtnGuardar_Click"></asp:Button>
     

</asp:Content>
