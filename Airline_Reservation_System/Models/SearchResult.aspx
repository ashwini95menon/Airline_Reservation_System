<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchResult.aspx.cs" Inherits="Airline_Reservation_System.Models.SearchResult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 348px;
        }
        .auto-style3 {
            width: 348px;
            height: 112px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    


        <br />
        <br />
        &nbsp;<br />
        <br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style3">AirLine :<br />
                    <asp:DropDownList ID="FilterDropdown" runat="server">
                        <asp:ListItem Selected="True">Air Indigo</asp:ListItem>
                        <asp:ListItem>Jet Airaways</asp:ListItem>
                        <asp:ListItem>Air India</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <br />
                    Price :
                        <br />
                    Enter Between 1000 and 50000<br />
                    <asp:TextBox ID="txtPriceFilter" runat="server"></asp:TextBox>
                    <br />
                    <asp:RangeValidator ID="priceRangeValidator" runat="server" ControlToValidate="txtPriceFilter" ErrorMessage="Value should be in between 1000 and 50000 " MaximumValue="50000" MinimumValue="1000"></asp:RangeValidator>
                    <br />
                    <br />
                    <br />
                    Flight Time :<br />
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" Height="50px" Width="244px">
                        <asp:ListItem>Between 12 A.M. AND 8 A.M.</asp:ListItem>
                        <asp:ListItem>Between 8 A.M. AND 4 P.M.</asp:ListItem>
                        <asp:ListItem>Between 4 P.M. AND 12 A.M.</asp:ListItem>
                    </asp:RadioButtonList>
                    <br />
                        <br />
                </td>
                <td> 
                    &nbsp;Flights Found......&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblsrc" runat="server" Text="Source"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp; -------&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbldestination" runat="server" Text="Destination"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblDateOfJourney" runat="server" Text="DateOfJourney"></asp:Label>
                    <br />
                    <br />
                    <br />
                    <br />
                    <asp:Repeater ID="RepeaterSecondPage" runat="server" DataSourceID="SqlDataSource1">
                         <HeaderTemplate>
              <table>
              <tr>
                 <th>Name</th>
                 <th>Description</th>
                  <th>Address</th>
              </tr>
          </HeaderTemplate>

          <ItemTemplate>
          <tr>
              <td bgcolor="#CCFFCC">
                <asp:Label runat="server" ID="Label1" 
                    text='<%# Eval("Cid") %>' />
              </td>
              <td bgcolor="#CCFFCC">
                  <asp:Label runat="server" ID="Label2" 
                      text='<%# Eval("CustName") %>' />
              </td>
               <td bgcolor="#CCFFCC">
                  <asp:Label runat="server" ID="Label5" 
                      text='<%# Eval("Address") %>' />
              </td>
          </tr>
          </ItemTemplate>

         

          <FooterTemplate>
              </table>
          </FooterTemplate>
                    </asp:Repeater>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DemoDBConnectionString %>" SelectCommand="SELECT * FROM [Customers]"></asp:SqlDataSource>
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
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
            </tr>
        </table>
    


    </div>
    </form>
</body>
</html>
