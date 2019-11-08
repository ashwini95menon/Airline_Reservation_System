using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Airline_Reservation_System
{
    public partial class WebForm3 : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblNoOfPassengers.Text = Session["nop"].ToString();

            string adultcount = Session["NoOfAdults"].ToString();
            string childcount = Session["NoOfChildren"].ToString();
            int adultcountvalue = int.Parse(adultcount);
            int childcountvalue = int.Parse(childcount);
           // LabelNew.Text = countvalue.ToString();
            int adultsum = adultcountvalue*3;
            int childsum = childcountvalue*3;



            //for (int i = 1; i <= countvalue; i++)
            //{
            //    LabelNew.Text = countvalue.ToString();

            //    TextBox tb = new TextBox();   //Create the object of TexBox Class
            //    tb.ID = i.ToString();                // assign the loop value to textbox object for dynamically adding Textbox ID
            //    Form.Controls.Add(tb);
            //}

            TextBox[] textBoxes = new TextBox[adultsum];
            TextBox[] textBoxes1 = new TextBox[childsum];
            Label[] labels = new Label[adultsum];
            Label[] labels1 = new Label[childsum];

            //for adults we are creating the textboxes 

            for (int i = 1; i <=adultcountvalue; i++)
            {
                labels[i] = new Label();
                phRecords.Controls.Add(labels[i]);

                labels[i].Text = "Adult  :" + i;


                for (int j = 1; j <= 3; j++)
                {
                    labels[j] = new Label();
                    phRecords.Controls.Add(labels[j]);
                    
                    labels[j].Text = "  Name";

                    if (j == 2)
                    {
                        labels[j].Text = "  Age";
                    }

                    if (j == 3)
                    {
                        labels[j].Text = "  Gender";
                    }
                    
                    textBoxes[j] = new TextBox();
                    

                    phRecords.Controls.Add(textBoxes[j]);
              
                }
                phRecords.Controls.Add(new LiteralControl("<br />"));
                phRecords.Controls.Add(new LiteralControl("<br />"));

             
               
                
            }

            for (int i = 1; i <= childcountvalue; i++)
            {
                labels1[i] = new Label();
                phRecords.Controls.Add(labels1[i]);

                labels1[i].Text = "Child  :" + i;


                for (int j = 1; j <= 3; j++)
                {
                    labels1[j] = new Label();
                    phRecords.Controls.Add(labels1[j]);

                    labels1[j].Text = "  Name";

                    if (j == 2)
                    {
                        labels1[j].Text = "  Age";
                    }

                    if (j == 3)
                    {
                        labels1[j].Text = "  Gender";
                    }

                    textBoxes1[j] = new TextBox();


                    phRecords.Controls.Add(textBoxes1[j]);

                }
                phRecords.Controls.Add(new LiteralControl("<br />"));
                phRecords.Controls.Add(new LiteralControl("<br />"));

               


            }


            
        }
    }
}