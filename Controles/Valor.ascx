<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Valor.ascx.cs" Inherits="Medusa.Controles.Valor" %>
<asp:PlaceHolder ID="StyleSheet" runat="server" Visible="False">
</asp:PlaceHolder>
<asp:TextBox ID="txtValor" runat="server" onkeyup="formataValor(this,event);" ></asp:TextBox>

<asp:RequiredFieldValidator ID="rfvValor" runat="server" 
    ControlToValidate="txtValor" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>


