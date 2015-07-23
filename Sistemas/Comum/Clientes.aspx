<%@ Page Title="" Language="C#" MasterPageFile="~/Styles/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="Medusa.Sistemas.Comum.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    Cadastro de Clientes
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="conteudo">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>                
            <ajaxToolkit:TabContainer ID="tabs" runat="server" ActiveTabIndex="5" 
                    AutoPostBack="True" onactivetabchanged="tabs_ActiveTabChanged" 
                    Width="100%" >
                    <ajaxToolkit:TabPanel ID="tpProcurar" runat="server" HeaderText="Procurar" style="min-height:600px">
                        <HeaderTemplate>
                            Procurar
                        </HeaderTemplate>
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
                        <img src="../../Styles/img/loading.gif" alt="carregando" />
                        <span style="margin:3px">Carregando ...</span></div>
                    </div>
                    <asp:Label ID="Label1" runat="server" Text="procurar"></asp:Label>
                    &nbsp;<asp:DropDownList ID="ddlOptions" runat="server" CausesValidation="True" 
                        AutoPostBack="True" onselectedindexchanged="ddlOptions_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="ra">ra</asp:ListItem>
                        <asp:ListItem Value="nome">nome</asp:ListItem>
                        <asp:ListItem>rg</asp:ListItem>
                        <asp:ListItem Value="cpf">cpf</asp:ListItem>
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
                          
                    <asp:GridView ID="grid" runat="server" AllowPaging="True" AllowSorting="True" 
                        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" 
                        onpageindexchanging="grid_PageIndexChanging" onrowcreated="grid_RowCreated" 
                        onrowediting="grid_RowEditing" onsorting="grid_Sorting" Width="100%">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="ra" HeaderText="ra" 
                                SortExpression="ra" />
                            <asp:BoundField DataField="nome" HeaderText="nome" 
                                SortExpression="nome">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="cpf" HeaderText="cpf" SortExpression="cpf" >
                            </asp:BoundField>
                            <asp:BoundField DataField="rg" HeaderText="rg" SortExpression="rg" />
                            <asp:TemplateField HeaderText="telefone" SortExpression="telefone.value">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("telefone.value") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("telefone.value") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="celular" SortExpression="celular.value">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("celular.value") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("celular.value") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="email" SortExpression="email.value">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("email.value") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("email.value") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
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
                </ContentTemplate>
                </ajaxToolkit:TabPanel>
               
                    <ajaxToolkit:TabPanel ID="tpCadastro" runat="server" HeaderText="Cadastro" style="min-height:600px">
                        <HeaderTemplate>
                            Cadastro
                        </HeaderTemplate>
                    <ContentTemplate>
                       
                    <table class="cadastro">
                        <tr>
                            <th colspan="1">
                                cadastro de clientes</th>
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
                        <th colspan="2">dados pessoais</th>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                registro do aluno:<asp:TextBox ID="txtCodigo" runat="server" Enabled="False" 
                                    Visible="False" Width="43px">0</asp:TextBox>
                            </td>
                            <td class="direito">
                                <asp:Label ID="txtRA" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                foto:</td>
                           <td class="direito">
                              
                                <asp:Image ID="imgFoto" runat="server" Height="200px" Width="200px" />

                                &nbsp;&nbsp;<br /> <asp:LinkButton ID="lkAddFile" runat="server" onclick="lkAddFile_Click" 
                                    CausesValidation="False">adicionar foto</asp:LinkButton>
                                <ajaxToolkit:AsyncFileUpload ID="AsyncFileUpload1" runat="server" UploadingBackColor="Yellow"
            OnUploadedComplete="ProcessUpload" ThrobberID="spanUploading" UploaderStyle="Modern" 
                                    Width="300px" Visible="False" FailedValidation="False"  />
        <span id="spanUploading" runat="server" visible="False">
                                <img class="style1" 
                                    src="../../Styles/img/loading2.gif" alt="carregando" /></span>
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
                                sexo:</td>
                            <td class="direito">
                                <cddlSexo:cDdlSexo ID="cDdlSexo1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                responsável:</td>
                            <td class="direito">
                                <asp:TextBox ID="txtResponsavel" runat="server" MaxLength="50" Width="500px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                rg:</td>
                            <td class="direito">
                                <asp:TextBox ID="txtRG" runat="server" MaxLength="15"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                cpf:</td>
                            <td class="direito">
                                <cCpf:cCPF ID="cCPF1" runat="server" EnableValidator="False" />
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                data de nascimento:</td>
                            <td class="direito">
                                <cdt:cData ID="cDataNascto" runat="server" />
                            </td>
                        </tr>
                  
                        <tr>
                        <th colspan="2">endereço</th>
                        </tr>
                        
                                <cender:cEnder ID="cEnder1" runat="server" />
                        
                        <tr>
                        <th colspan="2">contato</th>
                        </tr>
                              <tr>
                            <td class="esquerdo">
                                email:</td>
                            <td class="direito">
                                <cem:cEmail ID="cEmail1" runat="server" EnableValidator="False"  />
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                telefone:</td>
                            <td class="direito">
                                <ctel:cTelefone ID="cTelefoneTel" runat="server" />
                            </td>
                        </tr>
  
                        <tr>
                            <td class="esquerdo">
                                telefone comercial:</td>
                            <td class="direito">
                                <ctel:cTelefone ID="cTelefoneComercial" runat="server" 
                                    EnableValidator="False" />
                            </td>
                        </tr>
  
                        <tr>
                            <td class="esquerdo">
                                celular:</td>
                            <td class="direito">
                                <ctel:cTelefone ID="cTelefoneCelular" runat="server" EnableValidator="False" />
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                telefone emergência:</td>
                            <td class="direito">
                                <ctel:cTelefone ID="cTelefoneEmer" runat="server" EnableValidator="False" />
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                contato emergência:</td>
                            <td class="direito">
                                <ctx:cTexto ID="cTextoContatoEmer" runat="server" MaxLength="50" 
                                    Width="500px" EnableValidator="False" />
                            </td>
                        </tr>
                          <tr>
                        <th colspan="2">outras informações</th>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                vip:</td>
                            <td class="direito">
                                <asp:CheckBox ID="ckVip" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                observação:</td>
                            <td class="direito">
                                <ctx:cTexto ID="cTextoObs" runat="server" EnableValidator="False" Height="50px" 
                                    TextMode="MultiLine" Width="500px" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblMsg" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th colspan="2">
                            <div id="dGravacao1" runat="server">
                                <asp:Button ID="btInserir0" runat="server" onclick="btInserir_Click" 
                                    style="height: 26px" Text="inserir" />
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
              
                    </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                    <ajaxToolkit:TabPanel ID="tpContratos" runat="server" HeaderText="Contratos" style="min-height:600px">
                        <HeaderTemplate>
                            Contratos
                        </HeaderTemplate>
                    <ContentTemplate>
                       <table class="cadastro">
                       
                          <tr>
                         <th colspan="1">cliente</th>
                          <th colspan="1"></th>
                        </tr>
                        <tr style="display:none">
                            <td class="esquerdo">
                                registro do aluno:
                                </td>
                            <td class="direito">
                                <asp:Label ID="lbId_cliente" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                nome:
                            </td>
                            <td class="direito">
                                <asp:Label ID="lbNome" runat="server"></asp:Label>
                            </td>
                        </tr>
                  
                  
                       
                        <tr>
                        <th colspan="1">contratos</th>
                        <th colspan="1">
                            </th>
                        </tr>
                      
                               
                           
                           <tr><td colspan="2">
                                  <asp:GridView ID="gridContratos" runat="server" AutoGenerateColumns="False" 
        onrowediting="gridContratos_RowEditing" Width="100%" 
                                      >
         <Columns>
             <asp:BoundField DataField="id_contrato" HeaderText="nº contrato" />
             <asp:TemplateField HeaderText="plano">
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Plano.nome") %>'></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label1" runat="server" Text='<%# Bind("Plano.nome") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:BoundField DataField="inicio" DataFormatString="{0:d}" 
                 HeaderText="inicio" />
             <asp:BoundField DataField="termino" DataFormatString="{0:d}" 
                 HeaderText="término" />
             <asp:BoundField DataField="desconto_per" DataFormatString="{0:N2}" 
                 HeaderText="desconto(%)" />
             <asp:BoundField DataField="desconto_valor" DataFormatString="{0:N2}" 
                 HeaderText="desconto valor" />
             <asp:BoundField DataField="Total" DataFormatString="{0:n2}" 
                 HeaderText="total" />
             <asp:CheckBoxField DataField="status" HeaderText="status" Text="ativo" />
             <asp:TemplateField HeaderText="lançado por">
                 <EditItemTemplate>
                     <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Usuario.nome") %>'></asp:TextBox>
                 </EditItemTemplate>
                 <ItemTemplate>
                     <asp:Label ID="Label2" runat="server" Text='<%# Bind("Usuario.nome") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:CommandField EditText="selecionar" ShowEditButton="True" />
         </Columns>
         <HeaderStyle HorizontalAlign="Left" />
                           </asp:GridView>
                           </td>
                           </tr>
                           
                         
                               <tr>
                            <td class="esquerdo">
                                nº contrato:</td>
                            <td class="direito">
                                <asp:Label ID="txtId_contrato" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                plano:</td>
                            <td class="direito">

                            
                <asp:DropDownList ID="lista" runat="server" DataTextField="nome" Width="400px"
                    DataValueField="id_plano" AppendDataBoundItems="True">
                </asp:DropDownList>


<ajaxToolkit:ListSearchExtender ID="lista_ListSearchExtender" runat="server" 
    Enabled="True" PromptCssClass="ListSearchExtenderPrompt" 
    PromptText="digite para procurar" QueryPattern="Contains" QueryTimeout="2000" 
    TargetControlID="lista">
</ajaxToolkit:ListSearchExtender>


<asp:CompareValidator ID="cv" runat="server" 
    ErrorMessage="selecione um plano..." ForeColor="Red" Operator="NotEqual" ValidationGroup="contrato"
    ValueToCompare="0" ControlToValidate="lista"></asp:CompareValidator>
                                
                            </td>
                        </tr>
  
                        <tr>
                            <td class="esquerdo">
                                inicio:</td>
                            <td class="direito">
                                <cdt:cData ID="cDataInicio" runat="server" ValidationGroup="contrato" />
                            </td>
                        </tr>
  
                                <tr>
                                    <td class="esquerdo">
                                        término:</td>
                                    <td class="direito">
                                        <cdt:cData ID="cDataTermino" runat="server" ValidationGroup="contrato" />
                                    </td>
                           </tr>
  
                                <tr>
                                    <td class="esquerdo">
                                        desconto(%):</td>
                                    <td class="direito">
                                        <cvl:cValor ID="cValorDescPer" runat="server" ValidationGroup="contrato" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="esquerdo">
                                        desconto(R$):</td>
                                    <td class="direito">
                                        <cvl:cValor ID="cValorDescValor" runat="server" ValidationGroup="contrato" />
                                    </td>
                                </tr>
  
                           <tr>
                               <td class="esquerdo">
                                   status:</td>
                               <td class="direito">
                                   <asp:CheckBox ID="ckStatus" runat="server" Text="ativo" />
                                   <br />
                                   <asp:Label ID="lbStatus" runat="server"></asp:Label>
                               </td>
                           </tr>
                        <tr>
                            <td class="esquerdo">
                                observação:</td>
                            <td class="direito">
                                <ctx:cTexto ID="cTextoObs0" runat="server" EnableValidator="False" 
                                    Height="50px" TextMode="MultiLine" Width="500px" />
                            </td>
                        </tr>
                         
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lbMsgContrato" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th colspan="2">
                              <div id="dGravacao2" runat="server">
                              <asp:Button ID="btNewContrato" runat="server" 
                                CausesValidation="False" onclick="btNewContrato_Click" Text="novo contrato" />
                                <asp:Button ID="btInserirContrato" runat="server" 
                                    Text="inserir" ValidationGroup="contrato" onclick="btInserirContrato_Click"/>
                                <asp:Button ID="btAlterarContrato" runat="server" ValidationGroup="contrato"
                                    Text="salvar" onclick="btAlterarContrato_Click" />
                                <asp:Button ID="btExcluirContrato" runat="server" CausesValidation="False" 
                                    Text="excluir" onclick="btExcluirContrato_Click" />
                                 
                                <asp:Button ID="btCancelarContrato" runat="server" CausesValidation="False" 
                                     Text="cancelar" onclick="btCancelarContrato_Click" />
                            </div>
                            </th>
                        </tr>
                        </table>
                        <asp:Panel ID="pGerarPagamentos" runat="server" Visible="False">
                       
                           <table class="cadastro">
                        <tr>
                        <td class="esquerdo">
                            nº de parcelas:</td>
                        <td class="direito">
                            <cint:cInteiro ID="cInteiroParcelas" runat="server" 
                                ValidationGroup="gerarPagtos" />
                        </td>
                        <tr>
                            <td class="esquerdo">
                                data do primeiro vencimento:</td>
                            <td class="direito">
                                <cdt:cData ID="cDataGerarPagtos" runat="server" ValidationGroup="gerarPagtos" />
                            </td>
                              <tr>
                            <td colspan="2">
                                <asp:Label ID="lbMsgGerarPagamentos" runat="server"></asp:Label>
                            </td>
                        </tr>
                            <tr>
                                <th colspan="2">
                                    <asp:Button ID="btGerarPagtos" runat="server" onclick="btGerarPagtos_Click" 
                                        Text="gerar pagamentos" ValidationGroup="gerarPagtos" />
                                </th>
                            </tr>
                        </tr>
                        </tr>
                           
                    </table>
                     </asp:Panel>
                    </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                      <ajaxToolkit:TabPanel ID="tpServicos" runat="server" HeaderText="Serviços" style="min-height:600px">
                    <HeaderTemplate>
                    Serviços</HeaderTemplate>
                    <ContentTemplate>

                       <table class="cadastro">
                       
                          <tr>
                        <th colspan="1">cliente</th>
                        <th colspan="1"></th>
                        </tr>
                        <tr style:>
                            <td class="esquerdo">
                                registro do aluno:</td>
                            <td class="direito">
                                <asp:Label ID="lbId_aluno_servico" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                nome:
                            </td>
                            <td class="direito">
                                <asp:Label ID="lbNomeServico" runat="server"></asp:Label>
                            </td>
                        </tr>
                  
                       
                        <tr>
                        <th colspan="1">serviços</th>
                        <th colspan="1">
                            </th>
                        </tr>
                      
                               
                           
                           <tr>
                           <td colspan="2">
                                  <asp:GridView ID="gridServicos" runat="server" AutoGenerateColumns="False" 
        onrowediting="gridServicos_RowEditing" Width="100%" 
                                      >
         <Columns>
             <asp:BoundField DataField="id_servico_cliente" HeaderText="nº serviço" />
             <asp:TemplateField HeaderText="plano">
                 
                 <ItemTemplate>
                     <asp:Label ID="Label1" runat="server" Text='<%# Bind("Servico.descricao") %>'></asp:Label>
                 </ItemTemplate>
             </asp:TemplateField>
             <asp:BoundField DataField="data" DataFormatString="{0:d}" 
                 HeaderText="data" />
            <asp:BoundField DataField="data_termino" DataFormatString="{0:d}" 
                 HeaderText="data_termino" />
             <asp:BoundField DataField="desconto_per" DataFormatString="{0:N2}" 
                 HeaderText="desconto(%)" />
             <asp:BoundField DataField="desconto_valor" DataFormatString="{0:N2}" 
                 HeaderText="desconto valor" />
             <asp:BoundField DataField="Total" DataFormatString="{0:n2}" 
                 HeaderText="total" />            
             <asp:CommandField EditText="selecionar" ShowEditButton="True" />
         </Columns>
         <HeaderStyle HorizontalAlign="Left" />
                           </asp:GridView>
                           </td>
                           </tr>
                           
                            
                               <tr>
                            <td class="esquerdo">
                                nº serviço:</td>
                            <td class="direito">
                                <asp:Label ID="txtId_servico" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                serviço:</td>
                            <td class="direito">

                            
             
                                
                                <cddlServico:cDdlServico ID="cDdlServico1" runat="server" ValidationGroup="servico"/>

                            
             
                                
                            </td>
                        </tr>
  
                        <tr>
                            <td class="esquerdo">
                                data:</td>
                            <td class="direito">
                                <cdt:cData ID="cDataServico" runat="server" ValidationGroup="servico" />
                            </td>
                        </tr>
    <tr>
                            <td class="esquerdo">
                                data término:</td>
                            <td class="direito">
                                <cdt:cData ID="cDataServicoTermino" runat="server" ValidationGroup="servico" />
                            </td>
                        </tr>
                                <tr>
                                    <td class="esquerdo">
                                        desconto(%):</td>
                                    <td class="direito">
                                        <cvl:cValor ID="cValorDescontoPerServico" runat="server" ValidationGroup="servico" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="esquerdo">
                                        desconto(R$):</td>
                                    <td class="direito">
                                        <cvl:cValor ID="cValorDescServico" runat="server" ValidationGroup="servico" />
                                    </td>
                                </tr>
  
                      
                        <tr>
                            <td class="esquerdo">
                                observação:</td>
                            <td class="direito">
                                <ctx:cTexto ID="cTextoObsServico" runat="server" EnableValidator="False" 
                                    Height="50px" TextMode="MultiLine" Width="500px" />
                            </td>
                        </tr>
                         
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lbMsgServico" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th colspan="2">
                              <div id="dGravacao5" runat="server">
                              <asp:Button ID="btCriarServico" runat="server" 
                                CausesValidation="False" onclick="btNewServico_Click" Text="novo serviço" />
                                <asp:Button ID="btInserirServico" runat="server" 
                                    Text="inserir" ValidationGroup="servico" onclick="btInserirServico_Click"/>
                                <asp:Button ID="btAlterarServico" runat="server" ValidationGroup="servico"
                                    Text="salvar" onclick="btAlterarServico_Click" />
                                <asp:Button ID="btExcluirServico" runat="server" CausesValidation="False" 
                                    Text="excluir" onclick="btExcluirServico_Click" />
                                <asp:Button ID="btCancelarServico" runat="server" CausesValidation="False" 
                                     Text="cancelar" onclick="btCancelarServico_Click" />
                            </div>
                            </th>
                        </tr>
                           
                        
                           
                    </table>
                                        
                    </ContentTemplate>
                    </ajaxToolkit:TabPanel>

                    <ajaxToolkit:TabPanel ID="tpPagamentos" runat="server" HeaderText="Pagamentos" style="min-height:600px">
                    <HeaderTemplate>
                    Pagamentos</HeaderTemplate>
                    <ContentTemplate>
                      <table class="cadastro">
                       <tr>
                        <th colspan="1">cliente</th>
                        <th colspan="1"></th>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                registro do aluno:</td>
                            <td class="direito">
                                <asp:Label ID="lbId_clientePagto" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                nome:
                            </td>
                            <td class="direito">
                                <asp:Label ID="lbNomePagto" runat="server"></asp:Label>
                            </td>
                        </tr>

                    <tr>
                    <th colspan="1">Pagamentos</th>
                    <th colspan="1"></th>
                    </tr>
                  
                    <tr>
                    <td colspan="2">

                                     
                    <asp:GridView ID="gridPagamentos" runat="server" 
                        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" 
                        
                         Width="100%" OnRowEditing="gridPagamentos_RowEditing">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                         
                            <asp:TemplateField HeaderText="plano">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" 
                                        Text='<%# Bind("Contrato.Plano.nome") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Contrato.Plano.nome") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="data_vencto" DataFormatString="{0:d}" 
                                HeaderText="data de vencto" />
                            <asp:BoundField DataField="valor" DataFormatString="{0:N2}" 
                                HeaderText="valor" />
                            <asp:TemplateField HeaderText="lançado por">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" 
                                        Text='<%# Bind("UsuarioLancto.nome") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("UsuarioLancto.nome") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="baixa feita por">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" 
                                        Text='<%# Bind("UsuarioBaixa.nome") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("UsuarioBaixa.nome") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="data_pagto" DataFormatString="{0:d}" 
                                HeaderText="data de pagto" />
                            <asp:TemplateField HeaderText="forma de pagto">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("FormaPagto.nome") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("FormaPagto.nome") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="num" HeaderText="nº" />
                            <asp:CommandField EditText="selecionar" ShowEditButton="True" />
                
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
                    </td>
                    </tr>
                    <tr>

                    <td class="esquerdo">data de vencimento:
                        <asp:Label ID="txtId_pagamento" runat="server"></asp:Label>
                        </td>
                    <td class="direito">
                        <asp:Label ID="lbDataVencto" runat="server"></asp:Label>
                        </td>
                    </tr>
                          <tr>
                              <td class="esquerdo">
                                  valor:
                                  <asp:Label ID="txtId_contratoPagto" runat="server"></asp:Label>
                              </td>
                              <td class="direito">
                                  <asp:Label ID="lbValorPagto" runat="server"></asp:Label>
                              </td>
                          </tr>
                          <tr>
                              <td class="esquerdo">
                                  lançado por:</td>
                              <td class="direito">
                                  <asp:Label ID="lbUsuarioLancto" runat="server"></asp:Label>
                              </td>
                          </tr>
                          <tr>
                              <td class="esquerdo">
                                  data de pagamento:</td>
                              <td class="direito">
                                  <cdt:cData ID="lbDataPagto" runat="server" ValidationGroup="pagamento" />
                              </td>
                          </tr>
                          <tr>
                              <td class="esquerdo">
                                  baixa de pagamento feita por:</td>
                              <td class="direito">
                                  <asp:Label ID="lbUsuarioBaixa" runat="server"></asp:Label>
                              </td>
                          </tr>
                          <tr>
                              <td class="esquerdo">
                                  forma de pagamento:</td>
                              <td class="direito">
                                  <cddlForma:cDdlForma ID="cDdlForma1" runat="server" 
                                      ValidationGroup="pagamento" />
                              </td>
                          </tr>
                          <tr>
                              <td class="esquerdo">
                                  nº:</td>
                              <td class="direito">
                                  <ctx:cTexto ID="cTextoNUmPagto" runat="server" MaxLength="50" 
                                      ValidationGroup="pagamento" EnableValidator="False" />
                              </td>
                          </tr>
                          <tr>
                              <td colspan="2">
                                  <asp:Label ID="lbMsgPagamento" runat="server"></asp:Label>
                              </td>
                          </tr>
                               <tr>
                            <th colspan="2">
                              <div id="Div1" runat="server">
                                <asp:Button ID="btBaixaPagto" runat="server" ValidationGroup="pagamento"
                                    Text="baixar pagamento" onclick="btBaixaPagto_Click" />
                                  <asp:Button ID="btCancelarBaixa" runat="server" OnClick="btCancelarBaixa_Click" 
                                      Text="cancelar baixa" ValidationGroup="pagamento" />
                                <asp:Button ID="btExcluirPagamento" runat="server" CausesValidation="False" 
                                    Text="excluir" onclick="btExcluirPagamento_Click" />
                                <asp:Button ID="btCancelarPagamento" runat="server" CausesValidation="False" 
                                     Text="cancelar" onclick="btCancelarPagamento_Click" />
                            </div>
                            </th>
                        </tr>
                    </table>
                                        
                    </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                     <ajaxToolkit:TabPanel ID="tpFrequencia" runat="server" HeaderText="Frequencia" style="min-height:600px">
                    <HeaderTemplate>
                    Frequencia</HeaderTemplate>
                    <ContentTemplate>
                    <table class="cadastro">
                       <tr>
                        <th colspan="1">cliente</th>
                        <th colspan="1"></th>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                registro do aluno:</td>
                            <td class="direito">
                                <asp:Label ID="lbId_clienteFreq" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="esquerdo">
                                nome:
                            </td>
                            <td class="direito">
                                <asp:Label ID="lbNomeFreq" runat="server"></asp:Label>
                            </td>
                        </tr>

                    <tr>
                    <th colspan="1">Frequencia</th>
                    <th colspan="1"></th>
                    </tr>
                    <tr>
                        <td class="esquerdo">filtrar:</td>
                        <td class="direito"> de: <cdt:cData ID="cDataDeFrequencia" runat="server" ValidationGroup="frequencia" />
                        até: <cdt:cData ID="cDataAteFrequencia" runat="server" ValidationGroup="frequencia" />
                             <asp:Button ID="btFiltrar" runat="server" ValidationGroup="frequencia"
                                     Text="filtrar" onclick="btFiltrar_Click" />
                        </td>
                    </tr>
                    <tr>
                    <td colspan="2">

                                     
                    <asp:GridView ID="gridFrequncia" runat="server" 
                        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" 
                       
                        Width="100%">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                         
                            <asp:BoundField DataField="data" HeaderText="data" 
                                SortExpression="data" />
                            <asp:TemplateField HeaderText="liberado por" SortExpression="Usuario.nome">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Usuario.nome") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Usuario.nome") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="obs" HeaderText="observação" >
                            </asp:BoundField>
                
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
                    </td>
                    </tr>
                    </table>
                                        
                    </ContentTemplate>
                    </ajaxToolkit:TabPanel>
                </ajaxToolkit:TabContainer>
        </ContentTemplate>
        </asp:UpdatePanel>
       
</div>

</asp:Content>
