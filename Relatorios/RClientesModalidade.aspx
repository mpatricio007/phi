<%@ Page Title="" Language="C#" MasterPageFile="~/Styles/Site.Master" AutoEventWireup="true" CodeBehind="RClientesModalidade.aspx.cs" Inherits="Medusa.Relatorios.RClientesModalidade" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    Relatório de Clientes
    por Modalidade 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="conteudo">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
       
          <table class="cadastro">
                        <tr>
                            <th colspan="1">
                                relatório de clientes</th>
                            <th colspan="1">
                                &nbsp;</th>
                        </tr>
                        <tr>
                            <td class="esquerdo" style="height: 23px">
                                modalidade:</td>
                            <td class="direito" style="height: 23px">
                                <cddlModalidades:cDdlModalidades ID="cDdlModalidades1" runat="server" 
                                    ValidationGroup="qq" />
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                ativos:</td>
                            <td class="direito">
                                <asp:RadioButtonList ID="rdAtivos" runat="server" RepeatDirection="Horizontal">
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btGerarRelatorios" runat="server" Text="gerar relatório" 
                                    onclick="btGerarRelatorios_Click" CausesValidation="False" />
                                </td>
                        </tr>
                     
                        </table>
        <asp:Panel ID="Panel1" runat="server" Width="100%" Height="600px" BackColor="White">
      
                         <rsweb:ReportViewer ID="rvClientes" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" Height="600px" InteractiveDeviceInfos="(Collection)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
                          <LocalReport ReportPath="Relatorios\RelClientesModalidade.rdlc">
                          </LocalReport>
        </rsweb:ReportViewer>
         </asp:Panel>
         </ContentTemplate>
        </asp:UpdatePanel>
</div>
</asp:Content>
