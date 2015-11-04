using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ElectronicApp.Supporting_Classes;

namespace ElectronicApp.NebraskaApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnNext.Attributes.Add("onClick", "return valSubmit();");
            if (!IsPostBack)
            {
                if (Session["EmployeeData"] != null)
                {
                    employeeData myData = (employeeData)Session["EmployeeData"];

                        txtEmployeeName.Text = myData.EmployeeName;
                        txtAddress.Text = myData.HomeAddress;
                        txtCity.Text = myData.City;
                        txtState.Text = myData.State;
                        txtZip.Text = myData.Zip;
                        if (myData.HomePhone != "" && myData.WorkPhone != "")
                        {
                            txtHomePhone.Text = myData.HomePhone.Split('-')[0];
                            txtHomePhone0.Text = myData.HomePhone.Split('-')[1];
                            txtHomePhone1.Text = myData.HomePhone.Split('-')[2];
                            txtWorkPhone.Text = myData.WorkPhone.Split('-')[0];
                            txtWorkPhone0.Text = myData.WorkPhone.Split('-')[1];
                            txtWorkPhone1.Text = myData.WorkPhone.Split('-')[2];
                        }
                        txtEmail.Text = myData.Email;
                        txtDOB.Text = myData.DOB;
                        txtHeight.Text = myData.Height;
                        txtWeight.Text = myData.Weight;
                        //txtSoc.Text = myData.Soc;
                        txtTitle.Text = myData.JobTitle;
                        txtHireDate.Text = myData.DOH;
                        txtHours.Text = myData.AvgHours;
                        txtSalary.Text = myData.Salary;
                        cmbStatus.SelectedValue = myData.EmploymentStatus;
                        cmbMaritalStatus.SelectedValue = myData.MaritalStatus;
                        cmbChildren.SelectedValue = myData.NumChildren.ToString();
                        txtPhysician.Text = myData.PrimaryPhysician;

                        if (myData.Medicare)
                        {
                            cmbMedicare.SelectedValue = "yes";
                        }
                        else
                        {
                            cmbMedicare.SelectedValue = "no";
                        }
                        if (myData.Disabled)
                        {
                            cmbDisabled.SelectedValue = "yes";
                        }
                        else
                        {
                            cmbDisabled.SelectedValue = "no";
                        }
                        if (myData.Gender.Equals("male"))
                        {
                            cmbGender.SelectedValue = "Male";
                        }
                        else if (myData.Gender.Equals("female"))
                        {
                            cmbGender.SelectedValue = "Female";
                        }
   
                }

            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] != null && Session["ClientID"] != null && Session["EmployeeData"] != null)
            {
                employeeData myData = (employeeData)Session["EmployeeData"];
            
   
                myData.HomeAddress = txtAddress.Text;
                myData.City = txtCity.Text;
                myData.State = txtState.Text;
                myData.Zip = txtZip.Text;
                myData.HomePhone = txtHomePhone.Text + "-" + txtHomePhone0.Text + "-" + txtHomePhone1.Text;
                myData.WorkPhone = txtWorkPhone.Text + "-" + txtWorkPhone0.Text + "-" + txtWorkPhone1.Text;
                myData.Email = txtEmail.Text;
               // myData.DOB = txtDOB.Text;
                myData.Height = txtHeight.Text;
                myData.Weight = txtWeight.Text;
                myData.Soc = txtSoc.Text + "-" + txtSoc0.Text + "-" +txtSoc1.Text;
                myData.JobTitle = txtTitle.Text;
                myData.DOH = txtHireDate.Text;
                myData.AvgHours = txtHours.Text;
                myData.Salary = txtSalary.Text;
                myData.EmploymentStatus = cmbStatus.SelectedValue;
                myData.MaritalStatus = cmbMaritalStatus.SelectedValue;
                myData.NumChildren = int.Parse(cmbChildren.SelectedValue);
                myData.PrimaryPhysician = txtPhysician.Text;

                if (cmbMedicare.SelectedValue.ToUpper() == "YES")
                {
                    myData.Medicare = true;
                }
                else
                {
                    myData.Medicare = false;
                }
                if (cmbDisabled.SelectedValue.ToUpper() == "YES")
                {
                    myData.Disabled = true;
                }
                else
                {
                    myData.Disabled = false;
                }

                if (cmbGender.SelectedValue.ToUpper() == "MALE")
                {
                    myData.Gender = "male";
                }
                else
                {
                    myData.Gender = "female";
                }
                          
            Session["EmployeeData"] = myData;
            Response.Redirect("CoverageSelection.aspx",false); 
        }
        else
        {
            Response.Redirect("~/Default.aspx?timeout=1", false);
        }
      }

    }
}
