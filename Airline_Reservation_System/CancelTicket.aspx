<%@ Page Title="" Language="C#" MasterPageFile="~/Airline_Master.Master" AutoEventWireup="true" CodeBehind="CancelTicket.aspx.cs" Inherits="Airline_Reservation_System.WebForm14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div>
        
        <asp:GridView ID="GridView1" runat="server" AllowPaging="true" DataKeyNames="PassengerId">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:BoundField HeaderText="AutoId" DataField="PassengerId" />
                <asp:BoundField HeaderText="PassengerName" DataField="PassengerName" />
                 <asp:BoundField HeaderText="PassengerAge" DataField="Age" />
                
                <asp:BoundField HeaderText="Gender" DataField="Gender" />
                <asp:BoundField HeaderText="BookingStatus" DataField="BookingStatus" />--%>
          
            </Columns>
        </asp:GridView>
        
        <center><asp:Button ID="btnCancel" runat="server" Text="Cancel Ticket" OnClick="btnCancel_Click"></asp:Button></center>
    </div>

</asp:Content>
