<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DdlSexo.ascx.cs" Inherits="Medusa.Controles.DdlSexo" %>
<asp:DropDownList ID="listaSexos" runat="server" AppendDataBoundItems="True">
    <asp:ListItem Selected="True">M</asp:ListItem>
    <asp:ListItem>F</asp:ListItem>
</asp:DropDownList>


<asp:CompareValidator ID="cvSexo" runat="server" 
    ErrorMessage="selecione um sexo..." ForeColor="Red" Operator="NotEqual" 
    ValueToCompare="0" ControlToValidate="listaSexos"></asp:CompareValidator>



