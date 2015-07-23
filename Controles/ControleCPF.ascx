<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControleCPF.ascx.cs" Inherits="Medusa.Controles.ControleCPF" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


 <asp:TextBox ID="txtCpf" runat="server" onkeyup="formataCPF(this,event);" MaxLength="14"></asp:TextBox>
    <asp:CustomValidator ID="cvCpf" runat="server" 
        ClientValidationFunction="valida_cpf" ControlToValidate="txtCpf" 
        Display="Dynamic" ValidateEmptyText="false"
        EnableTheming="False" ErrorMessage="cpf inválido" ForeColor="Red" 
    onservervalidate="cvCpf_ServerValidate"></asp:CustomValidator>

    <asp:RequiredFieldValidator ID="rfv" runat="server" 
    ControlToValidate="txtCpf" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>


