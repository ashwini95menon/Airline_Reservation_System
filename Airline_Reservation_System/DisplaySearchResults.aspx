<%@ Page Title="" Language="C#" MasterPageFile="~/Airline_Master.Master" AutoEventWireup="true" CodeBehind="DisplaySearchResults.aspx.cs" Inherits="Airline_Reservation_System.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style6 {
            width: 159px;
            height: 52%;
        }
        .auto-style7 {
            width: 159px;
            height: 75%;
        }
        .auto-style10 {
            width: 20%;
            height: 198px;
        }
        .auto-style11 {
            width: 40%;
            height: 198px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        
    <table style="width:100%; padding-left: 10px; height: 407px; margin-bottom: 20px;">

        <tr >

            <td id="filters" class="auto-style10" style="border:solid">
                <table style="margin-left:5px; height: 267px;">
                    <tr id="filterByAirline">
                        <td class="auto-style6" style="padding-left: 5px">
                            <asp:Label ID="lblFilterAirline" runat="server" Text="Airline"></asp:Label><br />
                            <asp:DropDownList ID="getAirline" runat="server" OnSelectedIndexChanged="getAirline_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="filterByPrice">
                        <td class="auto-style7" style="padding-left: 10px">
                            <asp:Label ID="lblFilterPrice" runat="server" Text="Enter Price Range"></asp:Label><br /> 
                            <asp:TextBox ID="txtPriceRange" runat="server" TextMode="Number" placeholder="Minimum 1000" OnTextChanged="txtPriceRange_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
            <td id="repeaterOneWay" class="auto-style11" style="border:solid">

                 <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                        <HeaderTemplate>
                            <table style="width: 342px; border:solid ; border-color:white">
                            <tr>
                               
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                          

                            <tr style="border:solid;border-color:white">
                                <td>
                                    <%# Eval("FlightId") %>
                                </td>
                                <td>
                                    <%# Eval("FlightName") %>
                                </td>
                                <td>
                                    <%# Eval("Fare") %>
                                </td>
                            </tr>
                            <tr style="border:solid;border-color:white">
                                <td>
                                    <%# Eval("DepartureTime") %><br />
                                    <%# Eval("Source") %>
                                </td>
                                <td>
                                    <%# Eval("ArrivalTime") %><br />
                                    <%# Eval("Destination") %>
                                </td>
                                <td>
                                    <asp:LinkButton ID="btnDetails" runat="server"
                                        style="text-decoration:none;border:solid">View Details</asp:LinkButton><br />
                                    <asp:LinkButton runat="server" style="text-decoration:none;border:solid" CommandName="BookNow"
                                  CommandArgument='<%# Eval("FlightId") %>' ID="BookNow">
                                   Select Flight</asp:LinkButton>
                                </td>
                            </tr>
                            
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <br />
                 &nbsp;&nbsp;&nbsp;<asp:Label ID="lblErrorFlightNotSelected" runat="server" ForeColor="Red"></asp:Label>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Button ID="btnBook" runat="server" OnClick="Button1_Click" Text="Book Now" />

            </td>

            <td id="repeaterRoundTrip" class="auto-style11"  style="border:solid">

                <asp:Repeater ID="Repeater2" runat="server" OnItemCommand="Repeater2_ItemCommand">
                        <HeaderTemplate>
                            <table style="width: 342px">
                            <tr>
                                <%--<td>FLIGHT ID</td>
                                <td>FLIGHT NAME</td>
                                <td>SOURCE</td>
                                <td>DESTINATION</td>
                                 <td>DEPARTURE TIME</td> 
                                <td>ARRIVAL TIME</td>
                                <td>FARE</td>--%>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%--<tr>
                                <td><%# Eval("FlightId") %></td>
                                <td><%# Eval("FlightName") %></td>
                                <td><%# Eval("Source") %></td>
                                <td><%# Eval("Destination") %></td> 
                                <td><%# Eval("DepartureTime") %></td> 
                                <td><%# Eval("ArrivalTime") %></td>
                                 <td><%# Eval("Fare") %></td>
                                <td>
                                    <asp:LinkButton ID="btnDetails" runat="server"
                                        style="text-decoration:none;border:solid">View Details</asp:LinkButton></td> 
                                <td>
                                 <asp:LinkButton runat="server" style="text-decoration:none;border:solid" CommandName="BookNow"
                                  CommandArgument='<%# Eval("FlightId") %>' ID="BookNow">
                                   Select Flight</asp:LinkButton>
                                 
                                </td>

                                
                            </tr>--%>
                            <tr style="border:solid;border-color:white">
                                <td>
                                    <%# Eval("FlightId") %>
                                </td>
                                <td>
                                    <%# Eval("FlightName") %>
                                </td>
                                <td>
                                    <%# Eval("Fare") %>
                                </td>
                            </tr>
                            <tr style="border:solid;border-color:white">
                                <td>
                                    <%# Eval("DepartureTime") %><br />
                                    <%# Eval("Source") %>
                                </td>
                                <td>
                                    <%# Eval("ArrivalTime") %><br />
                                    <%# Eval("Destination") %>
                                </td>
                                <td>
                                    <asp:LinkButton ID="btnDetails" runat="server"
                                        style="text-decoration:none;border:solid">View Details</asp:LinkButton><br />
                                    <asp:LinkButton runat="server" style="text-decoration:none;border:solid" CommandName="BookNow"
                                  CommandArgument='<%# Eval("FlightId") %>' ID="BookNow">
                                   Select Flight</asp:LinkButton>
                                </td>
                            </tr>
                            
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>

            </td>


        </tr>

        </table>
                  
</asp:Content>
