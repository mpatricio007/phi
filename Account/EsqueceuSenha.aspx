<%@ Page Title="" Language="C#" MasterPageFile="~/Styles/SiteBase.Master" AutoEventWireup="true" CodeBehind="EsqueceuSenha.aspx.cs" Inherits="Medusa.Account.EsqueceuSenha" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentBaseMaster" runat="server">
    <h2>ESQUECEU SUA SENHA</h2>
    <p>
        Entre com o seu login e email e clique em enviar. Uma nova senha será gerada e enviada 
        para o email cadastrado.</p>
            <div>
            <fieldset>
                <legend>Recuperar Senha</legend>
                
                <div class="editor-label">
                 <asp:Label ID="lbLogin" runat="server" Text="Login"></asp:Label>
                    </div>
                <div class="editor-field">
                    <asp:TextBox ID="txtLogin" runat="server" Width="150px" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvLogin" runat="server" 
                    ControlToValidate="txtLogin" ErrorMessage="obrigatório"></asp:RequiredFieldValidator>
                </div>
                 <div class="editor-field">
                     Email</div>
                
                <div class="editor-label">
                    <asp:TextBox ID="txtEmail" runat="server" Width="500px" 
                        MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfEmail" runat="server" 
                    ControlToValidate="txtEmail" ErrorMessage="obrigatório"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="rfvEmail" runat="server" 
                        ControlToValidate="txtEmail" ErrorMessage="inválido" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </div>
                <br/>
               
                <div class="editor-label">
                    <asp:Button ID="btSendSenha" runat="server" Text="enviar" 
                        onclick="btSendSenha_Click" />
                    <asp:Label ID="lbLog" runat="server" ForeColor="Red"></asp:Label>
                </div>
            </fieldset>
</asp:Content>



