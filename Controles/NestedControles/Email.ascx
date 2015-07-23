<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Email.ascx.cs" Inherits="Medusa.Controles.Email" %>


<asp:TextBox ID="txt" runat="server" MaxLength="100" Width="400px"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="txt"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="rex" runat="server" ControlToValidate="txt" 
    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

