using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ElectronicApp.Supporting_Classes;
using ElectronicApp.NebraskaApp.Controls;
using System.Text;

namespace ElectronicApp.NebraskaApp
{
    public partial class HealthExplanations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HealthInformationAnswers myAnswers = (HealthInformationAnswers)Session["HealthInformationAnswers"];
               
                    int i = 0;
                    int size = myAnswers.MyAnswers.Count;
                    ArrayList idList = new ArrayList(size);
                    foreach (System.Web.UI.WebControls.ListItem li in myAnswers.MyAnswers)
                    {
                        idList.Add(new KeyValuePair<int, string>(i, li.Text));
                        i += 1;
                    }
                    ControlIdList = idList;
                    CreateControls();
                    LastControlId = size - 1;
           }
            btnNext.Attributes.Add("onClick", "return valSubmit();");
        }

        public ArrayList ControlIdList
        {
            get
            {
                object v = ViewState["ControlIdList"];
                return v != null ? (ArrayList)v : null;
            }
            set
            {
                ViewState["ControlIdList"] = value;
            }
        }

        public int LastControlId
        {
            get
            {
                object v = ViewState["LastControlId"];
                return v != null ? (int)v : 0;
            }
            set
            {
                ViewState["LastControlId"] = value;
            }
        }

        private Hashtable m_controls = new Hashtable();

        private void CreateControls()
        {
            ArrayList ids = ControlIdList;
            if (ids != null)
            {
                foreach (KeyValuePair<int, string> id in ids)
                {
                    DynamicTableControl control = CreateControl(id);
                    c_placeHolder.Controls.Add(control);
                }
            }
        }

        private DynamicTableControl CreateControl(KeyValuePair<int, string> id)
        {
            DynamicTableControl result = (DynamicTableControl)LoadControl("Controls/DynamicTableControl.ascx");
            result.ID = "c_" + id.Key;
            result.SetQuestion(id.Value);

            int index = id.Key;
            m_controls[index] = result;
            return result;
        }

        private void DisplayResult()
        {
            StringBuilder sb = new StringBuilder();
            bool first = true;
            foreach (KeyValuePair<int, string> id in ControlIdList)
            {
                if (!first)
                {
                    sb.Append(", ");
                }
                else
                {
                    first = false;
                }
                DynamicTableControl control = (DynamicTableControl)m_controls[id.Key];
                sb.Append(control.Text);
            }
            c_resultLabel.Text = sb.ToString();
        }

        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);
            CreateControls();
        }

        private int GetNewId()
        {
            int id = LastControlId++;
            return id;
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            HealthStatements myStatements = new HealthStatements();
            foreach (KeyValuePair<int, string> id in ControlIdList)
            {
                DynamicTableControl control = (DynamicTableControl)m_controls[id.Key];
                foreach (int id2 in control.RowIdList)
                {
                    RowControl r = (RowControl)control.MyRows[id2];
                    HealthStatement myStatement = r.getHealthStatement();
                    myStatement.QuestionNum = id.Value.Split('.')[0];
                    myStatement.Question = id.Value;
                    myStatement.RowID = id2;
                    myStatements.addStatement(myStatement);
                }
            }
            
            if (Session["HealthStatements"] != null)
            {
                Session.Add("HealthStatements", myStatements);
            }
            else
            {
                Session["HealthStatements"] = myStatements;
            }

            Response.Redirect("Processing.aspx", false);
        }

       
    }
}
