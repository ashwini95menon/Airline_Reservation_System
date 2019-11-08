<%@ Page Title="" Language="C#" MasterPageFile="~/Airline_Master.Master" AutoEventWireup="true" CodeBehind="BookFlightPage.aspx.cs" Inherits="Airline_Reservation_System.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 83%;
            height: 67px;
        }
        .auto-style3 {
            width: 936px;
            height: 180px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <%-- <div>
        
        <div id="nav">
        
                <h3> These are the Flight Details...</h3>
        </div>    
            
            <div id="main">
                
                 <h3> These are the Passenger Details...</h3>
           
           
        </div>

          <div id="price">
                
                 <h3>Grand Total is:   .</h3>
           
           
        </div>
    </div>
            --%>

     <%-- <div>
        
        <div id="nav">
        
                <h3> These are the Flight Details...</h3>
        </div>    
            
            <div id="main">
                
                 <h3> These are the Passenger Details...</h3>
           
           
        </div>

          <div id="price">
                
                 <h3>Grand Total is:   .</h3>
           
           
        </div>
    </div>
            --%>
  
    <div style="border-color: inherit; float:left; width:64%; margin-right:1px; height: 145px; border-width: thin; border-style: solid">
          Flight Details
        
          <br />
          <br />
        
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Label ID="lblSourceBookDetails" runat="server" Text="Source"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -----------------&gt;&nbsp;&nbsp;&nbsp;
          <asp:Label ID="lblDestinationBookDetails" runat="server" Text="Destination"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Label ID="lblDateOfJourneyBookDetails" runat="server" Text="DateOfJourney"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Label ID="lblClassBookDetails" runat="server" Text="Class"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
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
                       Total Number Of Passengers :&nbsp;&nbsp;&nbsp;
                       <asp:Label ID="lblNoOfPassengers" runat="server" Text="NoOfPassengers"></asp:Label>
                       <br />
                       <asp:PlaceHolder ID="phRecords" runat="server">     </asp:PlaceHolder>
                       <br />
                       <br />
                       <br />
                       <br />
                       <br />
                       <br />
                       <br />
                       <br />
                       <br />
                        <input type="checkbox" /><a href="../pdfs/terms-and-conditions-template.pdf">Terms & Conditionsions</a><br />
           <input type="button" name="Proceed to Pay" style="width: 295px" value="Proceed to Pay" />

                   </td>
              
               </tr>
           </table>
             
       

   
    

      
</asp:Content>
