using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;


namespace ElectronicApp.Supporting_Classes
{
    public class HealthStatement
    {
        private string _Question;      
        private string _QuestionNum;
        private string _Name;
        private string _Condition;
        private string _DateDiagnosed;
        private string _DateLastTreated;
        private string _TreatmentType;
        private bool _isMedication;
        private string _Recovery;
        private int _RowID;

        public int RowID
        {
            get { return _RowID; }
            set { _RowID = value; }
        }


        public HealthStatement()
        {
            _Question = "";
            _QuestionNum = "";
            _Name = "";
            _Condition = "";
            _DateDiagnosed = "";
            _DateLastTreated = "";
            _TreatmentType = "";
            _isMedication = false;
            _Recovery = "";
            _RowID = 0;
        }

        public string Question
        {
            get { return _Question; }
            set { _Question = value; }
        }  

        public string Recovery
        {
            get { return _Recovery; }
            set { _Recovery = value; }
        }

        public bool IsMedication
        {
            get { return _isMedication; }
            set { _isMedication = value; }
        }

        public string TreatmentType
        {
            get { return _TreatmentType; }
            set { _TreatmentType = value; }
        }

        public string DateLastTreated
        {
            get { return _DateLastTreated; }
            set { _DateLastTreated = value; }
        }

        public string DateDiagnosed
        {
            get { return _DateDiagnosed; }
            set { _DateDiagnosed = value; }
        }

        public string Condition
        {
            get { return _Condition; }
            set { _Condition = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string QuestionNum
        {
            get { return _QuestionNum; }
            set { _QuestionNum = value; }
        }
        
    }

    public class HealthStatementData
    {
        public int NextIndex
        {
            get
            {
                HealthStatements s = (HealthStatements)System.Web.HttpContext.Current.Session["HealthStatements"];
                return s.MyHealthStatements.Count;
            }
        }

        public List<HealthStatement> getStatements()
        {
            HealthStatements s = (HealthStatements)System.Web.HttpContext.Current.Session["HealthStatements"];

            try
            {
                return s.getList();
            }

            catch (NullReferenceException nre)
            {
                s.MyHealthStatements = new List<HealthStatement>();
                return s.getList();
            }
        }

        public HealthStatement getStatementByRowID(int RowID)
        {
            HealthStatements s = (HealthStatements)System.Web.HttpContext.Current.Session["HealthStatements"];

            return s.getStatementByRowID(RowID);
        }

        public int UpdateEntry(HealthStatement s)
        {
            HealthStatement toUpdate = null;
            HealthStatements ss = (HealthStatements)System.Web.HttpContext.Current.Session["HealthStatements"];

            foreach (HealthStatement hs in ss.MyHealthStatements)
            {
                if (hs.RowID == s.RowID)
                {
                    toUpdate = hs;
                    break;
                }
            }

            if ( toUpdate == null )
            {
                return 0;
            }
            else
            {
                toUpdate.Condition = s.Condition;
                toUpdate.DateDiagnosed = s.DateDiagnosed;
                toUpdate.DateLastTreated = s.DateLastTreated;
                toUpdate.IsMedication = s.IsMedication;
                toUpdate.Name = s.Name;
                toUpdate.Question = s.Question;
                toUpdate.QuestionNum = s.QuestionNum;
                toUpdate.Recovery = s.Recovery;
                toUpdate.TreatmentType = s.TreatmentType;

                System.Web.HttpContext.Current.Session["HealthStatements"] = ss;

                return 1;
            }
        }

        public int DeleteEntry(HealthStatement s)
        {
            HealthStatements hs = (HealthStatements)System.Web.HttpContext.Current.Session["HealthStatements"];
            HealthStatement ToDelete = null;

            foreach (HealthStatement ss in hs.MyHealthStatements)
            {
                if (ss.RowID == s.RowID)
                {
                    ToDelete = ss;
                    break;
                }
            }

            if (ToDelete != null)
            {
                hs.MyHealthStatements.Remove(ToDelete);

                System.Web.HttpContext.Current.Session["HealthStatements"] = hs;

                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int InsertEntry(HealthStatement s)
        {
            HealthStatements hs = (HealthStatements)System.Web.HttpContext.Current.Session["HealthStatements"];

            s.RowID = NextIndex;

            hs.MyHealthStatements.Add(s);

            System.Web.HttpContext.Current.Session["HealthStatements"] = hs;

            if (hs.MyHealthStatements.Contains(s))
            {
                return 1;
            }

            else
            {
                return 0;
            }
            
        }
    }
}
