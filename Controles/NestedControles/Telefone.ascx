<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Telefone.ascx.cs" Inherits="Medusa.Controles.Telefone" %>


<asp:TextBox ID="txt" runat="server" MaxLength="20" Width="150px" ></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="txt" 
    ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>


