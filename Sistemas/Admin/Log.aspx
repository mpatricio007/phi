<%@ Page Title="" Language="C#" MasterPageFile="~/Styles/Site.Master" AutoEventWireup="true" CodeBehind="Log.aspx.cs" Inherits="Medusa.Sistemas.Admin.Log" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    Log do Sistema
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="conteudo">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                  <asp:CheckBox ID="ckFilter" runat="server" AutoPostBack="True" 
                        oncheckedchanged="ckFilter_CheckedChanged" 
            Text="habilitar múltiplos filtros" />
        <asp:DataList ID="DataListFiltros" runat="server" RepeatColumns="6"
            ondatabinding="DataListFiltros_DataBinding" RepeatDirection="Horizontal" 
            OnDeleteCommand="DataListFiltros_DeleteCommand">
            <ItemTemplate>

               <div class="FilterName">

                <%# Eval("property_name") %>&nbsp
                <%# Eval("mode_name")%>&nbsp
                <%# Eval("value")%> &nbsp 
                   <asp:ImageButton ID="btExcluiFiltro" runat="server" 
                       ImageUrl="~/Styles/img/bt_delete.jpg" Width="15px" Height="15px" CommandName="delete"
                        />
                </div>
            </ItemTemplate>
        </asp:DataList>
                <div class="pesquisar">
                    <div id="updateProgressDiv" style="display:none; position:absolute;">
                        <div style=" margin-left:780px;  float:left">
                        <img src="../../Styles/img/loading.gif" />
                        <span style="margin:3px">Carregando ...</span></div>
                    </div>
                    <asp:Label ID="Label1" runat="server" Text="procurar"></asp:Label>
                    &nbsp;<asp:DropDownList ID="ddlOptions" runat="server" AutoPostBack="True" 
                        CausesValidation="True" 
                        onselectedindexchanged="ddlOptions_SelectedIndexChanged">
                        <asp:ListItem Selected="True">id_log</asp:ListItem>
                        <asp:ListItem Value="acao">ação</asp:ListItem>
                        <asp:ListItem>entidade</asp:ListItem>
                        <asp:ListItem>ip</asp:ListItem>
                        <asp:ListItem Value="Usuario.nome">usuário</asp:ListItem>
                        <asp:ListItem>data</asp:ListItem>
                        <asp:ListItem>id_entidade</asp:ListItem>
                        <asp:ListItem Value="descricao">descrição</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtProcura" runat="server" Width="137px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlMode" runat="server">
                    </asp:DropDownList>
                    <asp:Label ID="Label2" runat="server" Text="mostrar"></asp:Label>
                    &nbsp;
                    <asp:DropDownList ID="ddlSize" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlSize_SelectedIndexChanged">
                        <asp:ListItem Selected="True">10</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>50</asp:ListItem>
                        <asp:ListItem Value="0">todos</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="btSearch" runat="server" CausesValidation="False" 
                        onclick="btProcurar_Click" Text="procurar" />
                    <asp:Button ID="btCriar" runat="server" CausesValidation="False" 
                        onclick="btCriar_Click"  Text="novo" Width="80px" />
                </div>
                <asp:Panel ID="panelGrid" runat="server">
                          
                            
                    <asp:GridView ID="grid" runat="server" AllowPaging="True" AllowSorting="True" 
                        AutoGenerateColumns="False" CellPadding="4" 
                        CssClass="tableView" ForeColor="#333333" GridLines="None" 
                        onpageindexchanging="grid_PageIndexChanging" onrowcreated="grid_RowCreated" 
                        onrowediting="grid_RowEditing" onsorting="grid_Sorting" Width="100%">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="id_log" HeaderText="id_log" 
                                SortExpression="id_log">
                            </asp:BoundField>
                            <asp:BoundField DataField="acao" HeaderText="ação" SortExpression="acao" >
                            </asp:BoundField>
                            <asp:BoundField DataField="entidade" HeaderText="entidade" 
                                SortExpression="entidade">
                            </asp:BoundField>
                            <asp:BoundField DataField="ip" HeaderText="ip" SortExpression="ip" />
                            <asp:TemplateField HeaderText="usuário" SortExpression="Usuario.nome">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Usuario.nome") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Usuario.nome") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="data" HeaderText="data" SortExpression="data" />
                            <asp:BoundField DataField="id_entidade" HeaderText="id_entidade" 
                                SortExpression="id_entidade" />
                            <asp:CommandField EditText="selecionar" ShowEditButton="True">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                            </asp:CommandField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                            HorizontalAlign="Left" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" 
                            CssClass="SortedAscendingCellStyle" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" 
                            CssClass="SortedAscendingHeaderStyle" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" 
                            CssClass="SortedDescendingCellStyle" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" 
                            CssClass="SortedDescendingHeaderStyle " />
                    </asp:GridView>
                </asp:Panel>
                <asp:Panel ID="panelCadastro" runat="server">
                    <table class="cadastro">
                        <tr>
                            <th colspan="1">
                                consulta de log</th>
                            <th colspan="1">
                                &nbsp;</th>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                id_log:
                                </td>
                            <td class="direito">
                                <asp:Label ID="lbId_log" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                acao:
                                </td>
                            <td class="direito">
                                <asp:Label ID="lbAcao" runat="server"></asp:Label>
                            </td>
                        </tr>
                       
                        <tr>
                            <td class="esquerdo">
                                ip:</td>
                            <td class="direito">
                                <asp:Label ID="lbIp" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                usuário:</td>
                            <td class="direito">
                                <asp:Label ID="lbUsuario" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                data:</td>
                            <td class="direito">
                                <asp:Label ID="lbData" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                id_entidade:</td>
                            <td class="direito">
                                <asp:Label ID="lbId_entidade" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                descrição:</td>
                            <td class="direito">
                                <asp:Label ID="lbDescricao" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th colspan="2">
                               detalhes da entidade  <asp:Label ID="lbEntidade" runat="server"></asp:Label></th>
                            <th colspan="1">
                                &nbsp;</th>
                        </tr>
                        <div id="entidade" runat="server"></div>
                       
                        <tr>
                            <th colspan="2">
                                &nbsp;</th>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanelAnimationExtender ID="upae" BehaviorID="animation" runat="server" TargetControlID="UpdatePanel1" Enabled="True">
        <Animations>
            <OnUpdating>
                <Parallel duration="0">
                    <FadeOut minimumOpacity=".5" />
                    <ScriptAction Script="onUpdating();" />  
                 </Parallel>
            </OnUpdating>
            <OnUpdated>
                <Parallel duration="0">
                   <FadeIn minimumOpacity=".5" />  
                    <ScriptAction Script="onUpdated();" /> 
                </Parallel> 
            </OnUpdated>
        </Animations>
        </asp:UpdatePanelAnimationExtender>
    </div>
</asp:Content>
