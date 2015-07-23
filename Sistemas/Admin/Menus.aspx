<%@ Page Title="" Language="C#" MasterPageFile="~/Styles/Site.Master" AutoEventWireup="true" CodeBehind="Menus.aspx.cs" Inherits="Medusa.Sistemas.Admin.Menus" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    Cadatro de menus
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
                    &nbsp;<asp:DropDownList ID="ddlOptions" runat="server" CausesValidation="True" 
                        AutoPostBack="True" onselectedindexchanged="ddlOptions_SelectedIndexChanged">
                        <asp:ListItem Value="id_menu">código</asp:ListItem>
                        <asp:ListItem Value="descricao">descrição</asp:ListItem>
                        <asp:ListItem Value="nome">nome</asp:ListItem>
                        <asp:ListItem Value="Sistema.nome">sistema</asp:ListItem>
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
                        onrowediting="grid_RowEditing" onsorting="grid_Sorting" Width="100%" 
                        onselectedindexchanged="grid_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="id_menu" HeaderText="código" 
                                SortExpression="id_menu">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="sistema" SortExpression="Sistema.nome">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Sistema.nome") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Sistema.nome") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="nome" HeaderText="nome" 
                                SortExpression="nome">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descricao" HeaderText="descrição" 
                                SortExpression="descricao" >
                            <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ordem" HeaderText="ordem" SortExpression="ordem" />
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
                            <th>
                                cadastro de menus</th>
                            <th>    
                                <div id="dGravacao" runat="server">     
                                <asp:Button ID="btInserir" runat="server" onclick="btInserir_Click" 
                                    Text="inserir" ValidationGroup="vg_menu" />
                                <asp:Button ID="btAlterar" runat="server" onclick="btAlterar_Click" 
                                    Text="salvar" ValidationGroup="vg_menu" />
                                <asp:Button ID="btExcluir" runat="server" CausesValidation="False" 
                                    onclick="btExcluir_Click" Text="excluir" ValidationGroup="vg_menu" />
                                  
                                <asp:Button ID="btCancelar" runat="server" CausesValidation="False" 
                                    onclick="btCancelar_Click" Text="cancelar" ValidationGroup="vg_menu" />
                                      </div>
                                   
                            </th>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                código:
                                </td>
                            <td class="direito">
                                <asp:TextBox ID="txtCodigo" runat="server" Width="43px" Enabled="False">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                nome:
                                </td>
                            <td class="direito">
                                <ctx:cTexto ID="cTextoNome" runat="server" EnableValidator="True" Width="500" 
                                    MaxLength="50" ValidationGroup="vg_menu" />
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                descrição:</td>
                            <td class="direito">
                                <ctx:cTexto ID="cTextoDescricao" runat="server" Width="500" MaxLength="50" />
                            </td>
                        </tr>
                         <tr>
                            <td class="esquerdo">
                                sistema:</td>
                            <td class="direito">
                                <asp:DropDownList ID="ddlSistema" runat="server" Width="500px" 
                                    ValidationGroup="vg_menu">
                                </asp:DropDownList>
                                <asp:CompareValidator ID="cvSistema" runat="server" 
                                    ControlToValidate="ddlSistema" ErrorMessage="selecione um sistema..." 
                                    ForeColor="Red" Operator="NotEqual" ValueToCompare="0"></asp:CompareValidator>
                            </td>
                        </tr>

                        <tr>
                            <td class="esquerdo">
                                ordem:</td>
                            <td class="direito">
                                <cint:cInteiro ID="cInteiro1" runat="server" EnableValidator="False" 
                                    ValidationGroup="vg_menu" />
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
                                    style="height: 26px" Text="inserir" ValidationGroup="vg_menu" />
                                <asp:Button ID="btAlterar0" runat="server" onclick="btAlterar_Click" 
                                    Text="salvar" ValidationGroup="vg_menu" />
                                <asp:Button ID="btExcluir0" runat="server" CausesValidation="False" 
                                    onclick="btExcluir_Click" Text="excluir" ValidationGroup="vg_menu" />
                                  
                                <asp:Button ID="btCancelar0" runat="server" CausesValidation="False" 
                                    onclick="btCancelar_Click" Text="cancelar" ValidationGroup="vg_menu" />
                                      </div>
                            </th>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="panelPaginas" runat="server" Visible="False">
                    <table class="cadastro">
                        <tr>
                            <td colspan="2" class="esquerdo">
                                <strong>atribuição de páginas ao menu</strong></tr>
                        <tr>
                            <td class="esquerdo">
                                página:
                                <asp:Label ID="txtId_mp" runat="server" Text="0" Visible="False"></asp:Label>
                                </td>
                            <td class="direito">
                                <cddlPagina:cDdlPagina ID="cDdlPagina1" runat="server" 
                                    ValidationGroup="vg_pagmenu" />
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                permissões:
                                </td>
                            <td class="direito">
                                <asp:CheckBox ID="chkLeitura" runat="server" Text="Leitura" 
                                    ValidationGroup="vg_pagmenu" />
                                <asp:CheckBox ID="chkGravacao" runat="server" Text="Gravacao" 
                                    ValidationGroup="vg_pagmenu" />
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                ordem:</td>
                            <td class="direito">
                                <cint:cInteiro ID="cOrdem" runat="server" ValidationGroup="vg_pagmenu" />
                            </td>
                        </tr>
                        <tr>
                            <th colspan="2">
                                <asp:Button ID="btInserePag" runat="server" 
                                    style="height: 26px" Text="nova página" onclick="btInserePag_Click" 
                                    ValidationGroup="vg_pagmenu" />
                                <asp:Button ID="btSalvaPag" runat="server" Text="salvar página" 
                                    onclick="btSalvaPag_Click" ValidationGroup="vg_pagmenu" />
                                <asp:Button ID="btExcluiPag" runat="server" CausesValidation="False" 
                                    Text="excluir página" onclick="btExcluiPag_Click" 
                                    ValidationGroup="vg_pagmenu" />
                            </th>
                        </tr>
                      <tr>                       
                            <td class="direito" colspan="2">
                                <asp:GridView ID="gridPag" runat="server"  AllowSorting="True" CssClass="gridv" 
                                    AutoGenerateColumns="False" Caption="Páginas do Menu" CellPadding="4" 
                                     ForeColor="#333333" GridLines="None" Width="100%" 
                                    onrowediting="gridPag_RowEditing" ondatabinding="gridPag_DataBinding">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="página">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Pagina.url") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Pagina.url") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CheckBoxField DataField="leitura" HeaderText="leitura" />
                                        <asp:CheckBoxField DataField="gravacao" HeaderText="gravação" />
                                        <asp:BoundField DataField="ordem" HeaderText="ordem" />
                                        <asp:CommandField EditText="selecionar" ShowEditButton="True">
                                        <HeaderStyle HorizontalAlign="Right" />
                                        <ItemStyle HorizontalAlign="Right" />
                                        </asp:CommandField>
                                    </Columns>
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
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
                                </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblMsgPag" runat="server"></asp:Label>
                            </td>
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
