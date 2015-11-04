using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ElectronicApp.Supporting_Classes;

namespace ElectronicApp.NebraskaApp
{
    public partial class HealthInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnNext.Attributes.Add("onClick", "return valSubmit();");
            CheckBoxList1.Attributes.Add("onClick", "toggleDueDate();");
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            bool hasCondition = false;
            HealthInformationAnswers myAnswers = new HealthInformationAnswers();
            foreach (ListItem li in CheckBoxList1.Items)
            {
                if (li.Selected)
                {
                    myAnswers.addAnswer(li);
                    hasCondition = true;
                }
            }
            foreach (ListItem li in CheckBoxList3.Items)
            {
                if (li.Selected)
                {
                    myAnswers.addAnswer(li);
                    hasCondition = true;
                }
            }

            if (txtDueDate.Text != "")
            {
                myAnswers.DueData = txtDueDate.Text;
            }
            else
            {
                myAnswers.DueData = "";
            }

            if (Q32.Text.ToLower().Equals("yes"))
            {
                ListItem li = new ListItem("32. Have you or any of your dependents recieved inpatiant or outpatient services in the last 3 years (excluding routine tests, physicals or inoculations)?", "Q32", true);
                li.Selected = true;
                myAnswers.addAnswer(li);
                myAnswers.Q32 = true;
                hasCondition = true;
            }

            if (Q33.Text.ToLower().Equals("yes"))
            {
                ListItem li = new ListItem("33. Do you or any person named in this application have tests, treatments, hospitalization or surgery planned or recommended in the future?", "Q33", true);
                li.Selected = true;
                myAnswers.addAnswer(li);
                myAnswers.Q33 = true;
                hasCondition = true;
            }

            if (Q34.Text.ToLower().Equals("yes"))
            {
                ListItem li = new ListItem("34. Do you or any person named in this application take any medicine, prescription drugs or require shots/injections?", "Q34", true);
                li.Selected = true;
                myAnswers.addAnswer(li);
                myAnswers.Q34 = true;
                hasCondition = true;
            }
            if (Q35.Text.ToLower().Equals("yes"))
            {
                ListItem li = new ListItem("35. Do you or any person named in this application have any other medical conditions which have not yet been previously mentioned?", "Q35", true);
                li.Selected = true;
                myAnswers.addAnswer(li);
                myAnswers.Q35 = true;
                hasCondition = true;
            }

            Session.Add("HealthInformationAnswers", myAnswers);

            if (hasCondition)
            {
                Response.Redirect("HealthExplanations.aspx");
            }
            else
            {
                if (Session["HealthStatements"] != null)
                {
                    Session.Remove("HealthStatements");
                }
                Response.Redirect("Processing.aspx");
            }
        }


    }
}
