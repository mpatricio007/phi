<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DdlModalidades.ascx.cs" Inherits="Medusa.Controles.DdlModalidades" %>
                
                
                <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

                <asp:DropDownList ID="lista" runat="server" DataTextField="nome" Width="500px"
                    DataValueField="id_modalidade" AppendDataBoundItems="True">
                </asp:DropDownList>


<asp:ListSearchExtender ID="lista_ListSearchExtender" runat="server" 
    Enabled="True" PromptCssClass="ListSearchExtenderPrompt" 
    PromptText="digite para procurar" QueryPattern="Contains" QueryTimeout="2000" 
    TargetControlID="lista">
</asp:ListSearchExtender>


<asp:CompareValidator ID="cv" runat="server" 
    ErrorMessage="selecione uma modalidade..." ForeColor="Red" Operator="NotEqual" 
    ValueToCompare="0" ControlToValidate="lista"></asp:CompareValidator>



