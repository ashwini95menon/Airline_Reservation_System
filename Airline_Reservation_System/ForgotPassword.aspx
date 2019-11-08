<%@ Page Title="" Language="C#" MasterPageFile="~/Airline_Master.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Airline_Reservation_System.WebForm15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style5 {
            width: 28%;
            margin-left: 457px;
        }
        .auto-style6 {
            text-align: center;
        }
        .auto-style7 {
            text-align: center;
            height: 58px;
        }
        .auto-style8 {
            text-align: center;
            width: 193px;
        }
        .auto-style9 {
            width: 193px;
        }
        .auto-style10 {
            text-align: center;
            height: 58px;
            width: 193px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <table class="auto-style5" style="border-style: double; border-color: inherit; border-width: medium; background-color:aliceblue; height: 252px;">
        <tr>
            <td class="auto-style6">
    <asp:Label ID="lblEmail" runat="server" Text="EmailId"></asp:Label>                                                      
            </td>
            <td class="auto-style8">
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            &nbsp;
            </td>
        </tr>
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td style="text-align: center" class="auto-style9">
    <asp:Button ID="btnEmail" runat="server" OnClick="btnEmail_Click" Text="Submit" />
            </td>
        </tr>
        <tr>
            <td class="auto-style7">
    <asp:Label ID="lblShowResult" runat="server"></asp:Label>
            </td>
            <td class="auto-style10">
    <asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" Text="Go To Next" />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;<br />
    <br />
    <br />
&nbsp;
</asp:Content>
