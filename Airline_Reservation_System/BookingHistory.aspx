<%@ Page Title="" Language="C#" MasterPageFile="~/Airline_Master.Master" AutoEventWireup="true" CodeBehind="BookingHistory.aspx.cs" Inherits="Airline_Reservation_System.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div>
        <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
              <HeaderTemplate>
                  <table>
                      <tr>
                          <td>Booking Id</td>
                          <td>Flight Id</td>
                          <td>Class</td>
                          <td>Date Of Journey</td>
                          <td>Date Of Booking</td>
                          <td>Booking Status</td>
                          <td></td>
                      </tr>
              </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td><%# Eval("ReferenceId") %></td>
                    <td><%# Eval("FlightId") %></td>
                    <td><%# Eval("Class") %></td>
                    <td><%# Eval("DateOfJourney") %></td>
                    <td><%# Eval("DateOfBooking") %></td>
                    <td><%# Eval("BookingStatus") %></td>
                    <td>
                        <asp:LinkButton ID="btnSelect" runat="server"
                            CommandName="SelectBookingId"
                            CommandArgument ='<%# Eval("ReferenceId") %>'
                            >Select</asp:LinkButton></td>
                </tr>

            </ItemTemplate>

            <FooterTemplate>
                
                </table>
            </FooterTemplate>

        </asp:Repeater>

        <table>
            <tr>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="btnView" runat="server" Text="View Ticket" Width="115px" OnClick="btnView_Click" style="margin-left: 41px" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel Ticket" style="margin-left: 34px" OnClick="btnCancel_Click" />
                    </td>
                </tr>
        </table>
    </div>
</asp:Content>
