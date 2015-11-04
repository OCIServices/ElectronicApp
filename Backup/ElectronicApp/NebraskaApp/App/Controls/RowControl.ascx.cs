using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ElectronicApp.Supporting_Classes;

namespace ElectronicApp.NebraskaApp.Controls
{
    public partial class RowControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string getName()
        {
            return txtPersonName.Text;
        }

        public HealthStatement getHealthStatement()
        {
            HealthStatement myStatement = new HealthStatement();
            myStatement.QuestionNum = QuestionNumber.Value;
            myStatement.Name = txtPersonName.SelectedItem.Text;
            myStatement.Condition = txtCondition.Text;
            myStatement.DateDiagnosed = txtDiagnosed.Text;
            myStatement.DateLastTreated = txtTreated.Text;
            myStatement.TreatmentType = txtMed.Text;

            if (txtOngoing.SelectedValue.Equals("yes", StringComparison.CurrentCultureIgnoreCase))
            {
                myStatement.IsMedication = true;
            }
            else
            {
                myStatement.IsMedication = false;
            }

            myStatement.Recovery = txtRecovery.Text;
            
            return myStatement;
        }

        public void setPersonDropDown()
        {
            employeeData myData = (employeeData)Session["EmployeeData"];
            Coverage myCoverage = (Coverage)Session["Coverage"];
            txtPersonName.Items.Add("(Select)");
            txtPersonName.Items.Add(myData.EmployeeName);
            if (myData.IsChildren || !myData.IsSingle)
            {
                Dependents myDependents = (Dependents)Session["Dependents"];
                if (!myData.IsSingle && myCoverage.isSpouseCovered())
                {
                    txtPersonName.Items.Add(myDependents.getSpouse().Name);
                }
                if (myCoverage.isChildCovered())
                {
                    foreach (Dependent d in myDependents.getDependents())
                    {
                        txtPersonName.Items.Add(d.Name);
                    }
                }
            }
        }

        public void setQuestionNum(string num)
        {
            QuestionNumber.Value = num;
        }

        //public void restoreRowValues(HealthStatement myHelathStatement)
        //{
        //    QuestionNumber.Value = myHelathStatement.QuestionNum;
        //    txtPersonName.SelectedItem.Text = myHelathStatement.Name;
        //    txtCondition.Text = myHelathStatement.Condition;
        //    txtDiagnosed.Text = myHelathStatement.DateDiagnosed;
        //    txtTreated.Text =  myHelathStatement.DateLastTreated;
        //    txtMed.Text = myHelathStatement.TreatmentType;


        //    //if (txtOngoing.SelectedValue.Equals("yes", StringComparison.CurrentCultureIgnoreCase))
        //    //{
        //    //    myStatement.IsMedication = true;
        //    //}
        //    //else
        //    //{
        //    //    myStatement.IsMedication = false;
        //    //}

        //   // myStatement.Recovery = txtRecovery.Text;
        //}
    }
}