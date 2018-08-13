<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ChihuahuaV1.Contact" %>

<%@ Register Assembly="SlimeeLibrary" Namespace="SlimeeLibrary" TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <%-- #Calendario --%>
    <script src="calendar/moment.min.js"></script>
    <script src="calendar/jquery.min.js"></script>
    <script src="calendar/daterangepicker.min.js"></script>
    <link href="calendar/daterangepicker.css" rel="stylesheet" />
    <%-- #endCalendario --%>
    <script src="canvasjs/canvasjs.min.js"></script>
    <script type='text/javascript' src='canvas/canvasjs.js'></script>
    <script type='text/javascript'>
        var chart1 = new CanvasJS.Chart('chart1',
        {
            animationEnabled: true,
            title: { text: 'ESTACION: ' + fecha + ' ' },
            axisY: {
                nterval: 1, maximum: 80, title: 'Pm (µg/m3)', gridThickness: 0,
                stripLines: [{ value: 75, label: 'PM10: 75µg/m3', labelFontColor: 'black', color: 'red' },
                            { value: 45, label: 'PM2.5: 45µg/m3', labelFontColor: 'black', color: 'red' }]
            },
            axisX: {
                interval: 1, maximun: 24,
                labelAngle: -50,
                stripLines: [{ value: new Date(2018, 07, 1, 6), lineDashType: 'dot', label: '▲ 6 a.m.', color: 're11d', labelFontColor: 'black' }, { value: new Date(" + fch.Year + ", " + fch.Month + ", " + fch.Day + ", 12), lineDashType: 'dot', label: '▲ 12 p.m.', color: 'red', labelFontColor: 'black' }, { value: new Date(" + fch.Year + ", " + fch.Month + ", " + fch.Day + ", 18), lineDashType: 'dot', label: '▲ 6 P.M.', color: 'red', labelFontColor: 'black' }]
            },
            data: [
                { yValueFormatString: '## µg/m3', xValueFormatString: 'hh:mm tt', showInLegend: true, name: 'PM1', type: 'line', dataPoints: [] },
                { yValueFormatString: '## µg/m3', xValueFormatString: 'hh:mm TT', showInLegend: true, name: 'PM2.5', type: 'line', dataPoints: [] },
                { yValueFormatString: '## µg/m3', xValueFormatString: 'hh:mm TT', showInLegend: true, name: 'PM10', type: 'line', dataPoints: [] }, ]
        });
        chart1.render();
    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:TextBox ID="TextBox1" runat="server" Width="140px" OnTextChanged="TextBox1_TextChanged" AutoPostBack="True"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" TargetControlID="TextBox1" />

            &nbsp;<asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged" AutoPostBack="True" Width="140px"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" TargetControlID="TextBox2" />
            &nbsp;<asp:RadioButtonList ID="RadioButtonList1" runat="server" BackColor="#FFFF99" TextAlign="Left" Width="782px" RepeatDirection="Horizontal" TargetControlID="RadioButtonList1">
                <asp:ListItem Value="0">NUEZ</asp:ListItem>
                <asp:ListItem Value="1">RUEZNO</asp:ListItem>
                <asp:ListItem Value="2">MAÍZ</asp:ListItem>
                <asp:ListItem Value="3">DURAZNO</asp:ListItem>
            </asp:RadioButtonList>
           
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
