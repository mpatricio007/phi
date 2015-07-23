<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Texto.ascx.cs" Inherits="Medusa.Controles.Texto" %>
<asp:TextBox ID="txt" runat="server"     ></asp:TextBox>
<asp:RequiredFieldValidator  ID="rfv" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txt" > </asp:RequiredFieldValidator>