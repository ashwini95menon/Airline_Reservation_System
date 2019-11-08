using Airline_Reservation_System_Dll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Airline_Reservation_System
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        
            protected void Page_Load(object sender, EventArgs e)
        {
          
            lblSourceBookDetails.Text = Session["source"].ToString();
            lblDestinationBookDetails.Text = Session["destination"].ToString();
            lblDateOfJourneyBookDetails.Text = Session["dateOfJourney"].ToString();
            lblClassBookDetails.Text = Session["travelClass"].ToString();
            lblPriceBookDetails.Text = Session["Fare"].ToString();

           

            if(Session["tripType"].ToString().Equals("Round Trip"))
            {
                lblDateOfJourneyBookDetails.Visible = true;
                lblDateOfReturnJourneyBookDetails.Text = Session["dateOfReturn"].ToString();

            }

            //calculate fare for round trip
            if(Session["tripType"].ToString().Equals("Round Trip"))
            {
                float fareOneWay = Convert.ToSingle(Session["Fare"]);
                float fareRoundTrip = Convert.ToSingle(Session["FareRoundTrip"]);
                float fare = fareOneWay + fareRoundTrip;
                float finalFare = fare-(0.1f * fare);
                Session["Fare"] = finalFare;
            }

            lblPriceBookDetails.Text = Session["Fare"].ToString();

            string adultcount = Session["numberOfAdults"].ToString();
            string childcount = Session["numberOfChildren"].ToString();
            string infantcount = Session["numberOfInfants"].ToString();
            int adultcountvalue = int.Parse(adultcount);
            int childcountvalue = int.Parse(childcount);
            int infantcountvalue = int.Parse(infantcount);
            int adultsum = adultcountvalue * 3;
            int childsum = childcountvalue * 3;
            int infantsum = infantcountvalue * 3;

          
           


           

            TextBox[] textBoxes = new TextBox[adultsum - adultcountvalue];
            TextBox[] textBoxes1 = new TextBox[childsum-childcountvalue];
            TextBox[] textBoxes2 = new TextBox[infantsum - infantcountvalue];
            
            DropDownList[] adultGender = new DropDownList[adultcountvalue];
            DropDownList[] childGender = new DropDownList[childcountvalue];
            DropDownList[] infantGender = new DropDownList[infantcountvalue];


            Label[] labels = new Label[adultsum];
            Label[] labels1 = new Label[childsum];
            Label[] labels2 = new Label[infantsum];
           

            //for adults we are creating the textboxes 

            for (int i = 0; i < adultcountvalue; i++)
            {
                labels[i] = new Label();
                phRecords.Controls.Add(labels[i]);

                labels[i].Text = "Adult  :" + (i + 1);


                for (int j = 0; j < 3; j++)
                {
                    int count = 0;
                    int count2 = 0;
                    labels[j] = new Label();
                    phRecords.Controls.Add(labels[j]);
                    RequiredFieldValidator rfv = new RequiredFieldValidator();
                    if (j == 0)
                    {
                        labels[j].Text = "  Name";
                        textBoxes[count2] = new TextBox();
                        phRecords.Controls.Add(textBoxes[count2]);
                        textBoxes[count2].ID = "MyName" + (i + 1);

                        rfv.ControlToValidate = "MyName" + (i + 1);
                        rfv.ErrorMessage = "Name cannot be empty";
                        rfv.Display = ValidatorDisplay.Dynamic;
                        phRecords.Controls.Add(rfv);

                        RegularExpressionValidator regex = new RegularExpressionValidator();
                        regex.ErrorMessage = "Format is incorrect";
                        regex.ControlToValidate = "MyName" + (i + 1);
                        regex.ValidationExpression = "^[a-zA-Z]+$";
                        regex.Display = ValidatorDisplay.Dynamic;
                        regex.SetFocusOnError = false;

                        phRecords.Controls.Add(regex);

                    }

                    if (j == 1)
                    {
                        labels[j].Text = "  Age";
                        textBoxes[count2] = new TextBox();
                        phRecords.Controls.Add(textBoxes[count2]);


                        textBoxes[count2].ID = "MyId" + (i + 1);

                        rfv.ErrorMessage = "Age cannnot be Empty";
                        rfv.ControlToValidate = "MyId" + (i + 1);
                        rfv.Display = ValidatorDisplay.Dynamic;
                        phRecords.Controls.Add(textBoxes[count2]);
                        phRecords.Controls.Add(rfv);

                        RangeValidator range = new RangeValidator();
                        range.ErrorMessage = "not valid";
                        range.ControlToValidate = "MyId" + (i + 1);
                        range.Display = ValidatorDisplay.Dynamic;
                        range.Type = ValidationDataType.Integer;
                        range.SetFocusOnError = true;
                        range.MinimumValue = "12";
                        range.MaximumValue = "120";
                        phRecords.Controls.Add(range);
                        count2++;
                    }

                    if (j == 2)
                    {
                        labels[j].Text = "  Gender";
                        adultGender[count] = new DropDownList();
                        adultGender[count].Items.Insert(0, new ListItem("M"));
                        adultGender[count].Items.Insert(1, new ListItem("F"));
                        phRecords.Controls.Add(adultGender[count]);
                        count++;


                    }






                }
                phRecords.Controls.Add(new LiteralControl("<br />"));
                phRecords.Controls.Add(new LiteralControl("<br />"));




            }

            for (int i = 0; i < childcountvalue; i++)
            {
                labels1[i] = new Label();
                phRecords.Controls.Add(labels1[i]);

                labels1[i].Text = "Child  :" + (i + 1);


                for (int j = 0; j < 3; j++)
                {
                    int count = 0;
                    int count2 = 0;
                    labels1[j] = new Label();
                    phRecords.Controls.Add(labels1[j]);
                    RequiredFieldValidator rfv2 = new RequiredFieldValidator();
                    if (j == 0)
                    {
                        labels1[j].Text = " Name";
                        textBoxes1[count2] = new TextBox();
                        phRecords.Controls.Add(textBoxes1[count2]);
                        textBoxes1[count2].ID = "ChildName" + (i + 1);

                        rfv2.ControlToValidate = "ChildName" + (i + 1);
                        rfv2.ErrorMessage = "Name cannot be empty";
                        rfv2.Display = ValidatorDisplay.Dynamic;
                        phRecords.Controls.Add(rfv2);

                        RegularExpressionValidator regex = new RegularExpressionValidator();
                        regex.ErrorMessage = "Format is incorrect";
                        regex.ControlToValidate = "ChildName" + (i + 1);
                        regex.ValidationExpression = "^[a-zA-Z]+$";
                        regex.Display = ValidatorDisplay.Dynamic;
                        regex.SetFocusOnError = false;

                        phRecords.Controls.Add(regex);

                    }

                    if (j == 1)
                    {
                        labels1[j].Text = "  Age";
                        textBoxes1[count2] = new TextBox();
                        phRecords.Controls.Add(textBoxes1[count2]);


                        textBoxes1[count2].ID = "ChildId" + (i + 1);

                        rfv2.ErrorMessage = "Age cannnot be Empty";
                        rfv2.ControlToValidate = "ChildId" + (i + 1);
                        rfv2.Display = ValidatorDisplay.Dynamic;
                        phRecords.Controls.Add(textBoxes1[count2]);
                        phRecords.Controls.Add(rfv2);

                        RangeValidator range = new RangeValidator();
                        range.ErrorMessage = "not valid";
                        range.ControlToValidate = "ChildId" + (i + 1);
                        range.Display = ValidatorDisplay.Dynamic;
                        range.Type = ValidationDataType.Integer;
                        range.SetFocusOnError = true;
                        range.MinimumValue = "3";
                        range.MaximumValue = "11";
                        phRecords.Controls.Add(range);
                        count2++;
                    }

                    if (j == 2)
                    {
                        labels1[j].Text = "  Gender";
                        childGender[count] = new DropDownList();
                        childGender[count].Items.Insert(0, new ListItem("M"));
                        childGender[count].Items.Insert(1, new ListItem("F"));
                        phRecords.Controls.Add(childGender[count]);
                        count++;


                    }




                }
                phRecords.Controls.Add(new LiteralControl("<br />"));
                phRecords.Controls.Add(new LiteralControl("<br />"));


                

            }

            for (int i = 0; i < infantcountvalue; i++)
            {
                labels2[i] = new Label();
                phRecords.Controls.Add(labels[i]);

                labels2[i].Text = "Infant  :" + (i + 1);


                for (int j = 0; j < 3; j++)
                {
                    int count = 0;
                    int count2 = 0;
                    labels2[j] = new Label();
                    phRecords.Controls.Add(labels2[j]);
                    RequiredFieldValidator rfv3= new RequiredFieldValidator();
                    if (j == 0)
                    {
                        labels2[j].Text = " Name";
                        textBoxes2[count2] = new TextBox();
                        phRecords.Controls.Add(textBoxes2[count2]);
                        textBoxes2[count2].ID = "IName" + (i + 1);

                        rfv3.ControlToValidate = "IName" + (i + 1);
                        rfv3.ErrorMessage = "Name cannot be empty";
                        rfv3.Display = ValidatorDisplay.Dynamic;
                        phRecords.Controls.Add(rfv3);

                        RegularExpressionValidator regex = new RegularExpressionValidator();
                        regex.ErrorMessage = "Format is incorrect";
                        regex.ControlToValidate = "IName" + (i + 1);
                        regex.ValidationExpression = "^[a-zA-Z]+$";
                        regex.Display = ValidatorDisplay.Dynamic;
                        regex.SetFocusOnError = false;

                        phRecords.Controls.Add(regex);

                    }

                    if (j == 1)
                    {
                        labels2[j].Text = "  Age";
                        textBoxes2[count2] = new TextBox();
                        phRecords.Controls.Add(textBoxes2[count2]);


                        textBoxes2[count2].ID = "IId" + (i + 1);

                        rfv3.ErrorMessage = "Age cannnot be Empty";
                        rfv3.ControlToValidate = "IId" + (i + 1);
                        rfv3.Display = ValidatorDisplay.Dynamic;
                        phRecords.Controls.Add(textBoxes[count2]);
                        phRecords.Controls.Add(rfv3);

                        RangeValidator range = new RangeValidator();
                        range.ErrorMessage = "not valid";
                        range.ControlToValidate = "IId" + (i + 1);
                        range.Display = ValidatorDisplay.Dynamic;
                        range.Type = ValidationDataType.Integer;
                        range.SetFocusOnError = true;
                        range.MinimumValue = "0";
                        range.MaximumValue = "2";
                        phRecords.Controls.Add(range);
                        count2++;
                    }

                    if (j == 2)
                    {
                        labels2[j].Text = "  Gender";
                        infantGender[count] = new DropDownList();
                        infantGender[count].Items.Insert(0, new ListItem("M"));
                        infantGender[count].Items.Insert(1, new ListItem("F"));
                        phRecords.Controls.Add(infantGender[count]);
                        count++;


                    }






                }
                phRecords.Controls.Add(new LiteralControl("<br />"));
                phRecords.Controls.Add(new LiteralControl("<br />"));




            }




        }

            protected void btnProceedToPay_Click(object sender, EventArgs e)
            {
                string allTextBoxValues = "";
                string allDropDownValues = "";
                foreach (Control c in phRecords.Controls)
                {
                    if (c is TextBox)
                    {
                        allTextBoxValues += ((TextBox)c).Text + ",";
                    }
                    if (c is DropDownList)
                    {
                        allDropDownValues += ((DropDownList)c).SelectedItem.Text + ",";
                    }
                }


                string[] allPassengersNameAndAge = allTextBoxValues.Split(',');
                string[] allPassengersGender = allDropDownValues.Split(',');
                int n = Convert.ToInt32(Session["numberOfAdults"]) + Convert.ToInt32(Session["numberOfChildren"]) + Convert.ToInt32(Session["numberOfInfants"]);
                string[] PassengerName=new string[n];
                string[] PassengerAge = new string[n];
                string[] PassengerGender = new string[n];
                int count1=0;
                int count2=0;

                for (int i = 0; i < allPassengersNameAndAge.Length-1;i++ )
                {
                    if (i % 2 == 0)
                    {
                        PassengerName[count1]=allPassengersNameAndAge[i];
                        count1=count1++;
                    }
                    else
                    {
                        PassengerAge[count2]=allPassengersNameAndAge[i];
                        count2 = count2++;
                    }
                        
                }

                for (int i = 0; i < allPassengersGender.Length-1; i++)
                {

                    PassengerGender[i]=allPassengersGender[i];
                }


                //Session["PassengerName"] = PassengerName;
                //Session["PassengerAge"] = PassengerAge;
                //Session["PassengerGender"] = PassengerGender;
                
                string referenceId = DateTime.Now.ToString();
                referenceId = "O"+ referenceId + "101";
                Session["referenceId"] = referenceId;


                BookFlightDLL book = new BookFlightDLL ();





                int rowsAffected = book.updateBookedTicketBeforePayment
                                                                       (
                                                                           Session["selectedFlightId"].ToString(),
                                                                           Session["travelClass"].ToString(),
                                                                           Session["dateOfJourney"].ToString(),
                                                                           DateTime.Now.ToString("yyyy-MM-dd"),
                                                                           Convert.ToInt32(Session["numberOfAdults"]),
                                                                           Convert.ToInt32(Session["numberOfChildren"]),
                                                                           Session["Fare"].ToString(),
                                                                           "101",
                                                                           referenceId,
                                                                           "Pending",
                                                                           "Pending",
                                                                           Convert.ToInt32(Session["AdultPrice"]),
                                                                           Convert.ToInt32(Session["ChildPrice"]));

                for(int i=0;i<PassengerName.Length;i++)
                {
                    rowsAffected = book.updatePassengersBeforePayment(i+1, referenceId, PassengerName[i],
                                                                    Convert.ToInt32(PassengerAge[i]),
                                                                    Convert.ToChar(PassengerGender[i]),
                                                                    "Pending");

                }


                if (Session["tripType"].ToString().Equals("Round Trip"))
                {
                    string referenceIdRoundTrip = DateTime.Now.ToString();
                    referenceIdRoundTrip = "R" + referenceId + (Session["user"].ToString());
                    Session["referenceIdRoundTrip"] = referenceId;


                    BookFlightDLL bookRoundTrip = new BookFlightDLL();





                    rowsAffected = bookRoundTrip.updateBookedTicketBeforePayment
                                                                       (
                                                                           Session["selectedFlightIdRoundTrip"].ToString(),
                                                                           Session["travelClass"].ToString(),
                                                                           Session["dateOfReturn"].ToString(),
                                                                           DateTime.Now.ToString("yyyy-MM-dd"),
                                                                           Convert.ToInt32(Session["numberOfAdults"]),
                                                                           Convert.ToInt32(Session["numberOfChildren"]),
                                                                           Session["Fare"].ToString(),
                                                                           "101",
                                                                           referenceId,
                                                                           "Pending",
                                                                           "Pending",
                                                                           Convert.ToInt32(Session["AdultPriceRoundTrip"]),
                                                                           Convert.ToInt32(Session["ChildPriceRoundTrip"]));

                for(int i=0;i<PassengerName.Length;i++)
                {
                    rowsAffected = book.updatePassengersBeforePayment(i+1, referenceIdRoundTrip, PassengerName[i],
                                                                    Convert.ToInt32(PassengerAge[i]),
                                                                    Convert.ToChar(PassengerGender[i]),
                                                                    "Pending");

                }
                }

                Response.Redirect("Payment.aspx");

            }
        }
    
}