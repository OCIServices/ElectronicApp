using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using ElectronicApp.Supporting_Classes;
using System.Text;
using System.Collections;

namespace ElectronicApp.NebraskaApp.Controls
{
    public partial class DynamicTableControl : System.Web.UI.UserControl
    {
       // private static ArrayList RowIdList;
               
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LastControlId = 1;
                ArrayList idList = new ArrayList(1);
                idList.Add(0);
                RowIdList = idList;
                CreateRows();
            }
            Debug.WriteLine("loaded: " + this.ID.ToString());
        }

        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);
            CreateRows();
        }

        public ArrayList RowIdList
        {
            get
            {
                object v =  ViewState["RowIdList"];
                return v != null ? (ArrayList)v : null;
            }
            set { ViewState["RowIdList"] = value; }
        }

        public int LastControlId
        {
            get
            {
                object v = ViewState["LastRowId"];
                return v != null ? (int)v : 0;
            }
            set
            {
                ViewState["LastRowId"] = value;
            }
        }

        private Hashtable myRows = new Hashtable();

        public Hashtable MyRows
        {
            get { return myRows; }
            set { myRows = value; }
        }

        private void CreateRows()
        {
            ArrayList ids = RowIdList;
            if (ids != null)
            {
                foreach (int id in ids)
                {
                    RowControl row = CreateRow(id);
                    row.setPersonDropDown();
                    PlaceHolder1.Controls.Add(row);
                }
            }
        }

        private RowControl CreateRow(int id)
        {
            RowControl rval = (RowControl)LoadControl("~/NebraskaApp/Controls/RowControl.ascx");
            rval.ID = "r_" + id;
            myRows[id] = rval;
            return rval;
        }



        //public event EventHandler InsertAbove;
        //public event EventHandler InsertBellow;
        //public event EventHandler Remove;

        protected void InserAboveClick(object sender, EventArgs e)
        {
            if (RowIdList.Count < 10)
            {
                int id = GetNewId();
                RowControl r = CreateRow(id);
                r.setPersonDropDown();
                int index = this.PlaceHolder1.Controls.Count;
                RowIdList.Insert(index, id);
                this.PlaceHolder1.Controls.AddAt(-1, r);
            }

        }

        protected void InserAboveClick(HealthStatement myStatement)
        {
            if (RowIdList.Count < 10)
            {
                int id = GetNewId();
                RowControl r = CreateRow(id);
                r.setPersonDropDown();
                int index = this.PlaceHolder1.Controls.Count;
                RowIdList.Insert(index, id);
                this.PlaceHolder1.Controls.AddAt(-1, r);
            }

        }

        private int GetNewId()
        {
            int id = LastControlId++;
            return id;
        }

       /* protected void InsertBellowClick(object sender, EventArgs e)
        {
            if (InsertBellow != null)
            {
                InsertBellow(this, e);
            }
        }*/

        protected void RemoveClick(object sender, EventArgs e)
        {
            if (RowIdList.Count > 1)
            {
                int index = this.PlaceHolder1.Controls.Count;
                PlaceHolder1.Controls.RemoveAt(index - 1);
                RowIdList.RemoveAt(index - 1);
            }
        }

        public string Text
        {
            get
            {
                return "";
            }
        }

        public void SetQuestion(string myQuestion)
        {
            Question.Text = myQuestion;
        }
    }
}