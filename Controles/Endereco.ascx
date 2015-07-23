<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Endereco.ascx.cs" Inherits="Medusa.Controles.Endereco" %>
                <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
              

    <tr>
        <td class="esquerdo">
            logradouro:
        </td>
        <td class="direito">
           
            <asp:TextBox  ID="cTextoLogradouro" runat="server" EnableValidator="True" 
                MaxLength="50" Width="400px" />
            <asp:RequiredFieldValidator  ID="rfvLogradouro" runat="server" 
                ErrorMessage="RequiredFieldValidator" ControlToValidate="cTextoLogradouro" ></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="esquerdo">
            número:
        </td>
        <td class="direito">
            <asp:TextBox  ID="cTextoNumero" runat="server" MaxLength="10" />
            <asp:RequiredFieldValidator  ID="rfvNumero" runat="server" 
                ErrorMessage="RequiredFieldValidator" ControlToValidate="cTextoNumero" ></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="esquerdo">
            complemento:</td>
        <td class="direito">
            <asp:TextBox  ID="cTextoComplemento" runat="server" MaxLength="50" 
                Width="400px" />
        </td>
    </tr>
    <tr>
        <td class="esquerdo">
            bairro:</td>
        <td class="direito">
            <asp:TextBox  ID="cTextoBairro" runat="server" MaxLength="30" Width="400px" />
            <asp:RequiredFieldValidator  ID="rfvBairro" runat="server" 
                ErrorMessage="RequiredFieldValidator" ControlToValidate="cTextoBairro" ></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="esquerdo">
            cidade:</td>
        <td class="direito">
       
                 <asp:TextBox ID="cTextoCidade" runat="server" EnableValidator="True" 
                     MaxLength="100" Width="400px" />
                 <asp:RequiredFieldValidator ID="rfvCidade" runat="server" 
                     ControlToValidate="cTextoCidade" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
            
        </td>
    </tr>
    <tr>
        <td class="esquerdo">
            uf:</td>
        <td class="direito">
       
        
             <asp:TextBox ID="cTextoUF" runat="server" EnableValidator="True" MaxLength="2" 
                 Width="20px" />
             <asp:RequiredFieldValidator ID="rfvUF" runat="server" 
                 ControlToValidate="cTextoUF" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
      
        </td>
    </tr>
    
    <tr>
        <td class="esquerdo">
            cep:</td>
        <td class="direito">
            <asp:TextBox  ID="cTextoCep" runat="server" MaxLength="9" onkeyup="formataCEP(this,event);"/>
            <asp:RequiredFieldValidator  ID="rfvCep" runat="server" 
                ErrorMessage="RequiredFieldValidator" ControlToValidate="cTextoCep" ></asp:RequiredFieldValidator>
        </td>
    </tr>

              

