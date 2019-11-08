<%@ Page Title="" Language="C#" MasterPageFile="~/Airline_Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Airline_Reservation_System.WebForm2" %>
<asp:Content ID="HomeContent" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    
      
    .auto-style2 {
        height: 22px;
    }
      
        .auto-style5 {
            width: 50%;
        }
        .auto-style6 {
            width: 242px;
        }
        .auto-style7 {
            width: 50%;
            height: 26px;
        }
        .auto-style8 {
            width: 242px;
            height: 26px;
        }
      
  </style>
    
    <link href="Styles/Airline_style.css" rel="stylesheet" />

    <script> function validateDateOfReturn() {

        var doj = document.getElementById('<%=txtDateOfJourney.ClientID %>').value;
        var year = doj.substr(0, 4);
        var month = doj.substr(5, 2);
        var day = doj.substr(8, 2);
        var d = parseInt(day);
        var y = parseInt(year);
        var m = parseInt(month);
        m = m - 1;

        var dor = document.getElementById('<%=txtDateOfReturn.ClientID %>').value;
        var year1 = dor.substr(0, 4);
        var month1 = dor.substr(5, 2);
        var day1 = dor.substr(8, 2);
        var d1 = parseInt(day1);
        var y1 = parseInt(year1);
        var m1 = parseInt(month1);
        m1 = m1 - 1;

        var doj1 = new Date(y, m, d);
        var dor1 = new Date(y1,m1,d1);
        var diff = doj1-dor1;
             
        if ((diff > 0))
            alert("Enter a valid date of return");
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="searchForm" style="border: medium solid #FFFFFF; display:block; margin-left: 250px; margin-right: 250px; visibility: visible; float: inherit; clear: both; cursor: auto; overflow: auto; clip: rect(auto, auto, auto, auto); position: inherit; padding-right: 100px; padding-left: 75px;">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:RadioButtonList ID="btnTripType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="btnTripType_SelectedIndexChanged">
                    <asp:ListItem Selected="True">One Way</asp:ListItem>
                    <asp:ListItem>Round Trip</asp:ListItem>
                </asp:RadioButtonList>
        <br />
                <table style="table-layout: auto; position: absolute; padding-left: 100px;">
                    <tr>
                        <td class="auto-style5">
                            <asp:Label ID="lblSource" runat="server" Text="Source"></asp:Label>
                            &nbsp;</td>
                        <td class="auto-style6">
                            <asp:DropDownList ID="listSource" runat="server" AutoPostBack="True" DataTextField="Source" DataValueField="Source" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">
                            <asp:Label ID="lblDestination" runat="server" Text="Destination"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:DropDownList ID="listDestination" runat="server" AutoPostBack="True" DataTextField="Destination" DataValueField="Destination" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">
                            <asp:Label ID="lblDateOfJourney" runat="server" Text="DateOfJourney"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:TextBox ID="txtDateOfJourney" runat="server" AutoPostBack="True" OnTextChanged="txtDateOfJourney_TextChanged" required="" TextMode="Date"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">
                            <asp:Label ID="lblDateOfReturn" runat="server" Text="DateOfReturn" Visible="False"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:TextBox ID="txtDateOfReturn" runat="server" AutoPostBack="True" onchange="validateDateOfReturn()"  OnTextChanged="TextBox2_TextChanged" required="" TextMode="Date" Visible="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">
                            <asp:Label ID="lblClass" runat="server" Text="Class"></asp:Label>
                        </td>
                        <td class="auto-style6">
                            <asp:DropDownList ID="listClass" runat="server" AutoPostBack="True" DataTextField="Class" DataValueField="Class">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7">
                            <asp:Label ID="lblAdult" runat="server" Text="Adult"></asp:Label>
                            &nbsp;</td>
                        <td class="auto-style8">
                            <asp:DropDownList ID="txtAdult" runat="server" AutoPostBack="True" OnSelectedIndexChanged="txtAdult_SelectedIndexChanged">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="color: #FF0000">
                            <asp:Label ID="lblChild" runat="server" ForeColor="Black" Text="Child"></asp:Label>
                            &nbsp;<br /> (Age between 2 and 12 years)</td>
                        <td class="auto-style6">
                            <asp:DropDownList ID="txtChild" runat="server" AutoPostBack="True">
                                <asp:ListItem>0</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2" style="text-align: left; color: #FF0000;">
                            <asp:Label ID="lblInfant" runat="server" ForeColor="Black" Text="Infant"></asp:Label>
                            <br />
                            (2 years and below)</td>
                        <td class="auto-style2" style="text-align: left">
                            <asp:DropDownList ID="txtInfant" runat="server" AutoPostBack="True">
                                <asp:ListItem>0</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2" colspan="2" style="text-align: center">
                            <asp:Label ID="lblCheckPassengers" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2" colspan="2" style="text-align: center">
                            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click1" Text="Search" />
                        </td>
                    </tr>
                </table>
<br />
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />
     <br />
    <br />
    
        <br />
        <br />
        <br />
    <br />
    <br />
    <br />
    <br />
<br />
<br />
    
<br />

    

   
    </div>
</asp:Content>
