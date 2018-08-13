<%@ Page Title="Datos" Language="C#" MasterPageFile="~/rep/Demon.Master" AutoEventWireup="true" CodeBehind="datos.aspx.cs" Inherits="ChihuahuaV1.rep.datos"  MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        
        .auto-style3 {
            width: 202px;
        }
        .auto-style4 {
            width: 289px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="PanelInfo" runat="server">
        <div style="display: inline-grid" class="w3-responsive">
            <table style="width: 100%; display: inline-flexbox;">
                <tr>
                    <td style="padding:15px; text-align: left;" class="auto-style4">
                        <asp:Label ID="Labeltype" runat="server" Text="" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding:15px; text-align: left;" class="auto-style4">
                        <asp:Label ID="nameLabel" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding:15px; text-align: left;" class="auto-style4">
                        <asp:Label ID="LongLabel" runat="server" Text="Label"></asp:Label>
                        <br />
                        <asp:Label ID="LatLabel" runat="server" Text="Label"></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <h3><b>Consulta:</b></h3>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 15px; text-align: left;" class="auto-style4">
                        <asp:Label ID="LabelFch1" runat="server" Text="Fecha Inicio" Font-Bold="True" Font-Size="Medium"></asp:Label></td>
                </tr>
                <tr>
                    <td style="text-align: right;" class="auto-style4">
                        <asp:TextBox ID="TextBoxFch1" runat="server" Height="30px" Width="175px"></asp:TextBox></td>
                    <td>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxFch1" Format="dd/MM/yyyy" PopupButtonID="ImageButtonfch1" />
                        <asp:ImageButton ID="ImageButtonfch1" runat="server" ImageUrl="~/Images/calendario1.png" Height="40px" Width="40px" /></td>
                </tr>
                <tr>
                    <td style="padding: 15px; text-align: left;" class="auto-style4">
                        <asp:Label ID="LabelFch2" runat="server" Text="Fecha de Final" Font-Bold="True" Font-Size="Medium"></asp:Label></td>
                </tr>
                <tr>
                    <td style="text-align: right;" class="auto-style4">
                        <asp:TextBox ID="TextBoxFch2" runat="server" Height="30px" Width="175px"></asp:TextBox>
                    </td>
                    <td>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBoxFch2" Format="dd/MM/yyyy" PopupButtonID="ImageButtonfch2" />
                        <asp:ImageButton ID="ImageButtonfch2" runat="server" ImageUrl="~/Images/calendario1fin.png" Height="40px" Width="40px" /></td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center;" class="auto-style4">
                        <asp:Button ID="Button1" runat="server" Text="Consultar" OnClick="Button1_Click" CssClass="btn-info" Font-Bold="True" Font-Size="Medium" Height="40px" Width="142px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <br />
                    </td>
                </tr>
                <tr style="padding: 15px;">
                    <td class="auto-style4">
                        <h3><b>Resultados:</b></h3>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <br />
                    </td>
                </tr>
            </table>
        </div>
        <%-- Div Calendar --%>
        <div style="display: inline-grid;" class="table-responsive">
            <table>
                <tr>
                    <td></td>
                    <td style="align-content: center;" class="auto-style3">
                        <div id="calendar_basic" style="width: 900px; height: 200px; text-align: center;"></div>
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>
        <%-- Div Chart --%>
        <table style="width: 100%; text-align: center; display: inline-flexbox;">
            <tr>
                <td style="align-content: center; width: auto;" class="auto-style3">
                    <div id="chart1" style='width: 90%; height: 450px; vertical-align: central; display: inline-block;'></div>
                </td>
            </tr>
        </table>
        <%-- Grid --%>
        <table style="width: 100%; text-align: center; display: inline-flexbox;">
            <tr>
                <td style="padding:50px; width: auto;" class="auto-style3">
                    <asp:GridView ID="GridViewInfo" runat="server" AllowPaging="True" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="599px" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" OnDataBinding="Button1_Click">
                        <Columns>
                            <asp:BoundField DataField="Fecha" DataFormatString="{0:d/MM/yyyy}" HeaderText="Fecha" SortExpression="Fecha" />
                            <asp:BoundField DataField="HorasDia" HeaderText="HorasDia" SortExpression="HorasDia" />
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="toGridView" TypeName="ChihuahuaV1.proceso.grafica">
            <SelectParameters>
                <asp:QueryStringParameter Name="numero" QueryStringField="id" Type="Int32" />
                <asp:ControlParameter ControlID="TextBoxFch1" Name="fch1" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="TextBoxFch2" Name="fhc2" PropertyName="Text" Type="String" />
                <asp:SessionParameter Name="tipo" SessionField="typeOf" Type="Int32" />
                <asp:Parameter Direction="Output" Name="chart" Type="String" />
                <asp:Parameter Direction="Output" Name="calenda" Type="String" />
                <asp:Parameter Direction="Output" Name="strpLns" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <%-- Code to Grid & Calendar --%>
        <div style="display: inline-block">
            <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
            <script type="text/javascript">
                google.charts.load("current", { packages: ["calendar"] });
                google.charts.setOnLoadCallback(drawChartMax);
                function drawChartMax() {
                    var dataTable = new google.visualization.DataTable();
                    dataTable.addColumn({ type: 'date', id: 'Fecha' });
                    dataTable.addColumn({ type: 'number', id: 'Temp' });
                    dataTable.addRows([ <% =calenda1 %>]);
                    var calenda = new google.visualization.Calendar(document.getElementById('calendar_basic'));
                    var options = {
                        title: "Calendario Unidades Calor Acumuladas (Horas Día)",
                        height: 300, calendar: { cellSize: 15 },
                        colorAxis: { minValue: 0, colors: ['green', 'yellow', 'orange', 'red'] },
                    };
                    calenda.draw(dataTable, options);
                }
            </script>

            <script src="../canvasjs/canvasjs.min.js"></script>
            <script type='text/javascript'>
                var chart1 = new CanvasJS.Chart('chart1',
                {
                    animationEnabled: true,
                    title: { text: 'UNIDADES CALOR ACUMULADAS (HORAS DÍA)' },
                    axisY: {
                        interval: 300,
                        maximum: 5000,
                        title: 'UC (Tmax - Tmin / 2 - 3.3)',
                        gridThickness: 0
                    },
                    axisX: {
                        interval: 10, maximun: 365,
                        labelAngle: -50,
                        stripLines: [<%=striplines%>]
                    },
                    data: [
                    { yValueFormatString: '##.# UC', xValueFormatString: 'DD MMM', showInLegend: true, name: 'Horas Día', type: 'line', dataPoints: [<% =chart1 %>] }]
                });
                chart1.render();
            </script>

        </div>
    </asp:Panel>

</asp:Content>
