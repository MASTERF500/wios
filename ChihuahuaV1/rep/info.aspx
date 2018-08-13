<%@ Page Title="" Language="C#" MasterPageFile="~/rep/Demon.Master" AutoEventWireup="true" CodeBehind="info.aspx.cs" Inherits="ChihuahuaV1.rep.info" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- google-references --%>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <%-- google-referencesEnd --%>
    <asp:Panel ID="PanelInfo" runat="server">
    </asp:Panel>
    <asp:Panel ID="PanelConfig" runat="server" HorizontalAlign="Center">
        <div style="overflow-x: auto;">
            <table style="width: 100%; height: 100px;">
                <tr>
                    <td colspan="7" style="text-align: left;">
                        <h4><b>Seleccione un rango de fechas:</b></h4>
                        <asp:CompareValidator ID="CompareValidatorFechas" runat="server" ControlToCompare="TextBoxFch1" ControlToValidate="TextBoxfch2" Type="Date" ErrorMessage="* Rango de Fechas Inadecuado..." Operator="GreaterThanEqual" Font-Bold="True" ForeColor="#FF3300" ValidationGroup="fechas"></asp:CompareValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorfch1" runat="server" ErrorMessage="* Falta Fecha Inicial..." ControlToValidate="TextBoxFch1" Font-Bold="True" ForeColor="Red" ValidationGroup="fechas"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorfch2" runat="server" ErrorMessage="* Falta Fecha Final..." ControlToValidate="TextBoxfch2" Font-Bold="True" ForeColor="Red" ValidationGroup="fechas"></asp:RequiredFieldValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left;">
                        <table>
                            <tr>
                                <td style="text-align: right;"><b>Desde:</b></td>
                                <td>
                                            <asp:TextBox ID="TextBoxFch1" runat="server" class="w3-border w3-round" Height="25px" ReadOnly="True" Width="140px" ValidationGroup="fechas" AutoPostBack="True" OnTextChanged="TextBoxFch1_TextChanged"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxFch1" Format="dd/MM/yyyy" PopupButtonID="ImageButtonCalenda" />
                                     </td>
                                <td>
                                    <asp:ImageButton ID="ImageButtonCalenda" runat="server" ImageUrl="~/Images/calendario2.png" Height="47px" Width="50px" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td></td>
                    <td>
                        <table>
                            <tr>
                                <td style="text-align: right;"><b>Hasta:</b></td>
                                <td>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBoxFch2" Format="dd/MM/yyyy" PopupButtonID="ImageButtonCalendaFin" />
                                    <asp:TextBox ID="TextBoxfch2" runat="server" class="w3-border w3-round" Height="25px" Width="140px" ReadOnly="True" ValidationGroup="fechas" AutoPostBack="True" OnTextChanged="TextBoxfch2_TextChanged"></asp:TextBox>
                                </td>
                                <td>

                                    <asp:ImageButton ID="ImageButtonCalendaFin" runat="server" ImageUrl="~/Images/calendario3.png" Height="47px" Width="50px" Enabled="False" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <asp:ImageButton ID="ImageButtonAccept" runat="server" Height="42px" ImageUrl="~/Images/accept_buttom.png" OnClick="ImageButtonAccept_Click" ToolTip="Click to Cotinue" Width="47px" ValidationGroup="fechas" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>

            </table>
        </div>
    </asp:Panel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Block">
        <ContentTemplate>

        </ContentTemplate>
    </asp:UpdatePanel>
        
        <div id="chart" style="overflow-x: auto; width: 1000px; height: 350px;"></div>




</asp:Content>
