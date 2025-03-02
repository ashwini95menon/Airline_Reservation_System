<%@ Page Title="" Language="C#" MasterPageFile="~/Airline_Master.Master" AutoEventWireup="true" CodeBehind="BookFlight.aspx.cs" Inherits="Airline_Reservation_System.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

     <div style="border-color: inherit; float:left; width:64%; margin-right:1px; height: 145px; border-width: thin; border-style: solid">
          Flight Details 
          <br />
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Label ID="lblDateOfJourneyBookDetails" runat="server" Text="DateOfJourney"></asp:Label>
          <br />
        
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Label ID="lblSourceBookDetails" runat="server" Text="Source"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -----------------&gt;&nbsp;&nbsp;&nbsp;
          <asp:Label ID="lblDestinationBookDetails" runat="server" Text="Destination"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Label ID="lblClassBookDetails" runat="server" Text="Class"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
          <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;-----------------<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Label ID="lblDateOfReturnJourneyBookDetails" runat="server" Text="DateOfReturnJourney" Visible="False"></asp:Label>
        
    </div> 
  
    <div style="border-color: inherit; width:28%; margin-right:1px; height: 147px; border-width: thin; border-style: solid; margin-left:67%">
       Grand Total
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblPriceBookDetails" runat="server" Text="Price"></asp:Label>
    </div>
   
  
     
           <table class="auto-style2" style=" border-style: solid; border-color: inherit; border-width: medium; margin-top: 0px;" border="1" align="center" >
               <tr>
                   <td class="auto-style3">PASSENGER DETAILS&nbsp;
                       <br />
                       <br />
                       <br />
                       <asp:PlaceHolder ID="phRecords" runat="server">     </asp:PlaceHolder>
                       <br />
                       <br />
                       <br />
                       <br />
                       <br />
                       <br />
                       <br />
                       <asp:Label ID="lblError" runat="server"></asp:Label>
                       <br />
                       <br />
                        <input type="checkbox" /><a href="../pdfs/terms-and-conditions-template.pdf">Terms & Conditions</a><br />
                       <%--<input type="button" name="Proceed to Pay" style="width: 295px" value="Proceed to Pay" />--%>
                       <asp:Button ID="btnProceedToPay" runat="server" Text="Proceed to pay" OnClick="btnProceedToPay_Click" />
                   </td>
              
               </tr>
           </table>
             
       




</asp:Content>


    

  
   
