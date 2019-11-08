<%@ Page Title="" Language="C#" MasterPageFile="~/Airline_Master.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="Airline_Reservation_System.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    
   <script type="text/javascript">

       function validate1() {
           var Firstname = document.getElementById('<%=txtFirstname.ClientID %>').value;
           if (Firstname == "") {
               alert("Enter First Name");
               return false;
           }
           var username = /^[a-zA-Z\s]+$/
           var namematch = Firstname.match(username);
           if (namematch == null) {
               alert("Firstname is incorrect");
               return false;
           }
       }


       function validate2() {
           var Lastname = document.getElementById('<%=txtLastname.ClientID %>').value;
           if (Lastname == "") {
               alert("Enter Last Name");
               return false;
           }
           var username1 = /^[a-zA-Z\s]+$/
           var lastnamematch = Lastname.match(username1);
           if (lastnamematch == null) {
               alert("last name is incorrect");
               return false;
           }
       }





       function validate3() {
           var Password = document.getElementById('<%=txtPassword.ClientID %>').value;


           if (Password == "") {
               alert("Enter Password");
               return false;
           }

           var passnumber = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,16}$/
           var passwordcheck = Password.match(passnumber);
           if (passwordcheck == null) {
               alert("Password must be at least 4 characters, no more than 16 characters, and must include at least one upper case letter, one lower case letter, and one numeric digit.");
               return false;
           }

       }

       function validate4() {
           var ConfirmPassword = document.getElementById('<%=txtConfirmPassword.ClientID %>').value;

                  if (ConfirmPassword == "") {
                      alert("Enter Password Again");
                      return false;
                  }

                  if (ConfirmPassword != Password) {
                      alert("Confirm Password should be same as Password");
                      return false;
                  }

                  else {
                      alert("Goood same ");
                      return true;
                  }
              }


              function validate5() {
                  var Mobilenumber = document.getElementById('<%=txtMobileNumber.ClientID %>').value;
           if (Mobilenumber == "") {
               alert("Enter Mobile Number");
               return false;
           }
           var number = /^[0-9]{10}$/
           var phonenumber = Mobilenumber.match(number);
           if (phonenumber == null) {
               alert("Please Enter 10 digit Mobile Number");
               return false;
           }
       }
       function validate6() {
           var Email = document.getElementById('<%=txtEmailId.ClientID %>').value;
           if (Email == "") {
               alert("Enter Email");
               return false;
           }

           var emailPat = /^\w+[\w-\.]*\@\w+((-\w+)|(\w*))\.[a-z]{2,3}$/

           var EmailmatchArray = Email.match(emailPat);
           if (EmailmatchArray == null) {
               alert("Your email address seems incorrect. Please try again.");
               return false;
           }
       }

       function validate7() {
           var State = document.getElementById('<%=txtState.ClientID %>').value;
           if (State == "") {
               alert("Enter State");
               return false;
           }
           var statename = /^[a-zA-Z\s]+$/
           var statematch = State.match(statename);
           if (statematch == null) {
               alert("Enter only alphabets [a-z][A-Z]");
               return false;
           }
       }

       function validate8() {
           var city = document.getElementById('<%=txtcity.ClientID %>').value;
           if (city == "") {
               alert("Enter City");
               return false;
           }
           var cityname = /^[a-zA-Z\s]+$/
           var citymatch = city.match(cityname);
           if (citymatch == null) {
               alert("Enter only alphabets [a-z][A-Z]");
               return false;
           }
       }


       function validate9() {
           var Pincode = document.getElementById('<%=txtpincode.ClientID %>').value;
           if (Pincode == "") {
               alert("Enter Pin code");
               return false;
           }
           var number = /^\[0-9]{6}$/

           var pincode1 = Pincode.match(number);
           if (pincode1 == null) {

               alert("Please Enter 6 digit Pincode");
               return false;
           }


       }

       function validate10() {
           var dob = document.getElementById('<%=txtDob.ClientID %>').value;
           var year = dob.substr(0, 4);
           var month = dob.substr(5, 2);
           var day = dob.substr(8, 2);
           var y = parseInt(year);
           var m = parseInt(month);
           m = m - 1;
           var d = parseInt(day);
           var today = new Date();
           var currentD = parseInt(today.getDate());
           var currentY = parseInt(today.getFullYear());
           var currentM = parseInt(today.getMonth());

           var d1 = new Date(y, m, d);
           var d2 = new Date(currentY, currentM, currentD);
           var diff = d2 - d1;
           var div = parseFloat(1000 * 60 * 60 * 24);
           days = parseFloat(diff / div);
           var years = parseFloat(days / 365.2422);

           if (years < 18)
               alert("Age should be greater than 18 years");



       }





   </script>
</asp:Content>






<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
          <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <ContentTemplate>    
        
        <table class="auto-style2">
            <tr>
                <td class="auto-style3">&nbsp; &nbsp;<asp:Label ID="lblfirstname" runat="server" Text="FirstName"></asp:Label>
                </td>
                <td>&nbsp;&nbsp; &nbsp;<asp:TextBox ID="txtFirstname" runat="server" onchange="validate1()" ></asp:TextBox>
                &nbsp;&nbsp;
                    </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp; &nbsp;<asp:Label ID="lblLastname" runat="server" Text="LastName"></asp:Label>
                </td>
                <td>&nbsp;&nbsp; &nbsp;<asp:TextBox ID="txtLastname" runat="server" onchange="validate2()" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;&nbsp;
                    <asp:Label ID="lblDob" runat="server" Text="DateOfBirth"></asp:Label>
                </td>
                <td>&nbsp;&nbsp; &nbsp;<asp:TextBox ID="txtDob" runat="server" TextMode="Date" onchange="validate10()" ></asp:TextBox>
                &nbsp;&nbsp;
                    </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;&nbsp; Password&nbsp;</td>
                <td>&nbsp;&nbsp; &nbsp;<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="16" onchange="validate3()"></asp:TextBox>
                &nbsp;&nbsp;
                    </td>
            </tr>
            <tr>
                <td class="auto-style3">Confirm Password</td>
                <td>&nbsp;&nbsp; &nbsp;<asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"  onchange="validate4()"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="Password do not match"></asp:CompareValidator>
                    </td>
            </tr>
            <tr>
                <td class="auto-style3">Mobile Number</td>
                <td>&nbsp;&nbsp; &nbsp;<asp:TextBox ID="txtMobileNumber" runat="server" MaxLength="10" onchange="validate5()" ></asp:TextBox>
                </td>
            </tr>

            <tr>
   
    
               
  
                <td class="auto-style3">Email Id</td>
                <td>&nbsp;&nbsp; &nbsp;<asp:TextBox ID="txtEmailId" runat="server" onchange="validate6()" OnTextChanged="txtEmailId_TextChanged" AutoPostBack="true"></asp:TextBox>
&nbsp;&nbsp;
                    <asp:Label ID="lblEmailId" runat="server" Text="visible" ></asp:Label>
                    </td>

       
            </tr>
            <tr>
                <td class="auto-style3">State</td>
                <td>&nbsp;&nbsp; &nbsp;<asp:TextBox ID="txtState" runat="server" onchange="validate7()" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">City</td>
                <td>&nbsp;&nbsp; &nbsp;<asp:TextBox ID="txtcity" runat="server" onchange="validate8()"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">PinCode</td>
                <td class="auto-style5">&nbsp;&nbsp; &nbsp;<asp:TextBox ID="txtpincode" runat="server" Minlength ="6" MaxLength ="6"   onchange="validate9()"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnRegister" runat="server" Text="Register"  />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                </td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                </td>
            </tr>
        </table>
        &nbsp;</p>
          </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>


