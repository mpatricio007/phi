<%@ Page Title="" Language="C#" MasterPageFile="~/Styles/Site.Master" AutoEventWireup="true" CodeBehind="Planos.aspx.cs" Inherits="Medusa.Sistemas.Comum.Planos" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    Cadastro de Planos
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
                        <asp:ListItem Value="id_plano">código</asp:ListItem>
                        <asp:ListItem Value="nome">nome</asp:ListItem>
                        <asp:ListItem Value="descricao">descrição</asp:ListItem>
                        <asp:ListItem Value="meses">quantidade de meses</asp:ListItem>
                        <asp:ListItem Value="Modalidade.nome">modalidade</asp:ListItem>
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
                        AutoGenerateColumns="False" 
                        onpageindexchanging="grid_PageIndexChanging" onrowcreated="grid_RowCreated" 
                        onrowediting="grid_RowEditing" onsorting="grid_Sorting" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="id_plano" HeaderText="código" 
                                SortExpression="id_plano" >
                            <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="nome" HeaderText="nome" 
                                SortExpression="nome">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descricao" HeaderText="descrição" 
                                SortExpression="descricao" />
                            <asp:TemplateField HeaderText="modalidade" SortExpression="Modalidade.nome">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Modalidade.nome") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Modalidade.nome") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="valor" HeaderText="valor mensal" 
                                SortExpression="valor" />
                            <asp:BoundField DataField="total" HeaderText="total" />
                            <asp:BoundField DataField="inicio" HeaderText="inicio" 
                                SortExpression="inicio" />
                            <asp:BoundField DataField="termino" HeaderText="término" 
                                SortExpression="termino" />
                            <asp:CheckBoxField DataField="status" HeaderText="status" 
                                SortExpression="status" />
                            <asp:CommandField EditText="selecionar" ShowEditButton="True">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                            </asp:CommandField>
                        </Columns>
                        <HeaderStyle HorizontalAlign="Left" />
                        <SortedAscendingCellStyle 
                            CssClass="SortedAscendingCellStyle" />
                        <SortedAscendingHeaderStyle 
                            CssClass="SortedAscendingHeaderStyle" />
                        <SortedDescendingCellStyle 
                            CssClass="SortedDescendingCellStyle" />
                        <SortedDescendingHeaderStyle 
                            CssClass="SortedDescendingHeaderStyle " />
                    </asp:GridView>
                </asp:Panel>
                <asp:Panel ID="panelCadastro" runat="server">
                    <table class="cadastro">
                        <tr>
                            <th colspan="1">
                                cadastro de planos</th>
                            <th colspan="1">
                            <div id="dGravacao" runat="server">
                                <asp:Button ID="btInserir" runat="server" onclick="btInserir_Click"  
                                    Text="inserir" />
                                <asp:Button ID="btAlterar" runat="server" onclick="btAlterar_Click" 
                                    Text="salvar" />
                                <asp:Button ID="btExcluir" runat="server" CausesValidation="False" 
                                    onclick="btExcluir_Click" Text="excluir" />
                                <asp:Button ID="btCancelar" runat="server" CausesValidation="False" 
                                    onclick="btCancelar_Click" Text="cancelar" />
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
                                <ctx:cTexto ID="cTextoNome" runat="server" EnableValidator="True" 
                                    MaxLength="100" Width="500px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                descrição:
                            </td>
                            <td class="direito">
                                <ctx:cTexto ID="cTextoDescricao" runat="server" EnableValidator="True" MaxLength="100" 
                                    Width="500px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                modalidade:</td>
                            <td class="direito">
                                <cddlModalidades:cDdlModalidades ID="cDdlModalidades1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                valor:</td>
                            <td class="direito">
                                <cvl:cValor ID="cValor1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                quantidade de meses:</td>
                            <td class="direito">
                                <cint:cInteiro ID="cInteiroMeses" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                quantidade de acessos no mês:<br />
                                <br />
                                (se for diferente de zero será validado a quiantidade de acessos no mês)</td>
                            <td class="direito">
                                <cint:cInteiro ID="cInteiroAcessos" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                dias de tolerancia:</td>
                            <td class="direito">
                                <cint:cInteiro ID="cInteiroTolerancia" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                horário de acesso:</td>
                            <td class="direito">
                                das
                                <asp:TextBox ID="txtInicio" runat="server" Width="50px"
                                    ></asp:TextBox>
                                <ajaxToolkit:MaskedEditExtender ID="meeInicio" runat="server" 
                                    AcceptAMPM="True" ErrorTooltipEnabled="True" Mask="99:99:99" MaskType="Time" 
                                    MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" 
                                    OnInvalidCssClass="MaskedEditError" TargetControlID="txtInicio" />
                                <ajaxToolkit:MaskedEditValidator ID="mevInicio" runat="server" 
                                    ControlExtender="meeInicio" ControlToValidate="txtInicio" 
                                    Display="Dynamic" EmptyValueBlurredText="*" 
                                    EmptyValueMessage="obrigatório" InvalidValueBlurredMessage="*" 
                                    InvalidValueMessage="inválido" IsValidEmpty="False" ForeColor="Red" 
                                     />
                                &nbsp;até
                                <asp:TextBox ID="txtTermino" runat="server" Width="50px"
                                    ></asp:TextBox>
                                <ajaxToolkit:MaskedEditExtender ID="meeTermino" runat="server" 
                                    AcceptAMPM="True" ErrorTooltipEnabled="True" Mask="99:99:99" MaskType="Time" 
                                    MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" 
                                    OnInvalidCssClass="MaskedEditError" TargetControlID="txtTermino" />
                                <ajaxToolkit:MaskedEditValidator ID="mevTermino" runat="server" 
                                    ControlExtender="meeTermino" ControlToValidate="txtTermino" 
                                    Display="Dynamic" EmptyValueBlurredText="*" 
                                    EmptyValueMessage="obrigatório" InvalidValueBlurredMessage="*" 
                                    InvalidValueMessage="inválido" IsValidEmpty="False" ForeColor="Red" 
                                     />
                                </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                status:</td>
                            <td class="direito">
                                <asp:CheckBox ID="ckStatus" runat="server" Text="ativo" />
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
                                     Text="inserir" />
                                <asp:Button ID="btAlterar0" runat="server" onclick="btAlterar_Click" 
                                    Text="salvar" />
                                <asp:Button ID="btExcluir0" runat="server" CausesValidation="False" 
                                    onclick="btExcluir_Click" Text="excluir" />
                                <asp:Button ID="btCancelar0" runat="server" CausesValidation="False" 
                                    onclick="btCancelar_Click" Text="cancelar" />
                            </div>
                            </th>
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
