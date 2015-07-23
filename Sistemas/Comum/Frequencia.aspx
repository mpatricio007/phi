<%@ Page Title="" Language="C#" MasterPageFile="~/Styles/Site.Master" AutoEventWireup="true" CodeBehind="Frequencia.aspx.cs" Inherits="Medusa.Sistemas.Comum.Frequencia" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    Cadastro de Entrada
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="conteudo">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
        <asp:ScriptReference Path="~/Scripts/FixFocus.js" />
        </Scripts>
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
       
                <asp:Panel ID="panelCadastro" runat="server">
                    <table class="cadastro">
                        <tr>
                            <th colspan="1">
                                cadastro de entrada</th>
                            <th colspan="1">
                            <div id="dGravacao" runat="server">
                            </div>
                            </th>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                foto:</td>
                            <td class="direito">
                                <asp:Image ID="imgFoto" runat="server" Height="200px" Width="200px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                nome:<asp:Label ID="txtCodigo" runat="server" Text="0" Visible="False"></asp:Label>
                            </td>
                            <td class="direito">
                                <asp:Label ID="lbNome" runat="server" Font-Size="XX-Large"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                ra:
                            </td>
                            <td class="direito">
                                <asp:TextBox ID="txtRa" runat="server" AutoPostBack="True" Font-Size="XX-Large" onkeyup="formataInteiro(this,event);"
                                    Height="48px" ontextchanged="txtRa_TextChanged" Width="342px" 
                                    CausesValidation="True"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvRA" runat="server" ControlToValidate="txtRa" 
                                    ErrorMessage="RequiredFieldValidator" Font-Size="XX-Large" Height="48px"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                     
                           <tr>
                            <td colspan="2">
                               
                               
                                <asp:GridView ID="gridServicos" runat="server" AutoGenerateColumns="False" 
                                    Font-Size="Medium" Width="100%" onrowcreated="grid_RowCreated" EmptyDataText="Não há serviços ativos para o cliente!" Caption="Serviços">
                                    <Columns>
                                        <asp:BoundField DataField="plano" HeaderText="serviço" />
                                        <asp:BoundField DataField="motivo" HeaderText="motivo" />
                                        <asp:TemplateField HeaderText="status">
                                            <ItemTemplate>
                                                <asp:Label ID="lbStatus" runat="server" Text='<%# Bind("status") %>' ForeColor='<%# Bind("color") %>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataRowStyle ForeColor="Red" />
                                </asp:GridView>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2">
                               
                               
                                <asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" 
                                    Font-Size="Medium" Width="100%" onrowcreated="grid_RowCreated" EmptyDataText="Não há planos ativos para o cliente!" Caption="Planos">
                                    <Columns>
                                        <asp:BoundField DataField="plano" HeaderText="plano" />
                                        <asp:BoundField DataField="motivo" HeaderText="motivo" />
                                        <asp:TemplateField HeaderText="status">
                                            
                                            <ItemTemplate>
                                                <asp:Label ID="lbStatus" runat="server" Text='<%# Bind("status") %>' ForeColor='<%# Bind("color") %>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataRowStyle ForeColor="Red" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                observação:
                            </td>
                            <td class="direito">
                                <ctx:cTexto ID="cTextoObs" runat="server" EnableValidator="False" 
                                    Width="500px" Height="50px" TextMode="MultiLine" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                                
                            </td>
                        </tr>
                        <tr>
                            <th colspan="2">
                            <div id="dGravacao1" runat="server">
                                <asp:Button ID="btInserir0" runat="server" onclick="btInserir_Click" 
                                     Text="confirma entrada?" />
                                <asp:Button ID="btCancelar0" runat="server" CausesValidation="False" 
                                    onclick="btCancelar_Click" Text="cancelar" />
                            </div>
                            </th>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
      
</div>
</asp:Content>
