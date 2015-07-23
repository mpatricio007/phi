<%@ Page Title="" Language="C#" MasterPageFile="~/Styles/Sistema.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Medusa.Home" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="aspCt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMenu" runat="server">
    <div id="menu_limpo">  
</div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
     <ContentTemplate>
     
  
    <div class="loginFields">
       
        <asp:Label ID="Label1" runat="server" Text="Nome de Usuário" Width="125px"></asp:Label>
  
  <br />
  <asp:TextBox ID="txtLogin" runat="server" Width="125px" MaxLength="50"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" 
        ErrorMessage="? " ControlToValidate="txtLogin" 
        SetFocusOnError="True" SkinID="naotem" ForeColor="Red"></asp:RequiredFieldValidator>   
        <br />
        <asp:Label ID="Label2" runat="server" Text="Senha" Width="125px"></asp:Label>
      <br />
  <asp:TextBox ID="txtSenha" runat="server" Width="125px" MaxLength="20" 
           TextMode="Password" SkinID="naotem"></asp:TextBox>

    <asp:RequiredFieldValidator ID="rfvSenha" runat="server" ControlToValidate="txtSenha"
      ErrorMessage="? " SetFocusOnError="True" SkinID="reqfield_sem_msg" 
           ForeColor="Red" ></asp:RequiredFieldValidator>
          
        <br />
          
    <asp:Button ID="btEntrar" runat="server" Text="entrar" BackColor="#404040" BorderStyle="Double" ForeColor="White" OnClick="btEntrar_Click" />
       
        <br />
       
    <asp:HyperLink ID="hlSenha" runat="server" Font-Underline="True" NavigateUrl="EsqueceuSenha.aspx" >esqueceu sua senha?</asp:HyperLink>&nbsp;

    <br />
    <asp:Label ID="lblMsg" runat="server"></asp:Label>

   
   	
</div>

</ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

