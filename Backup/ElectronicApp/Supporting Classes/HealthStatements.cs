using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicApp.Supporting_Classes
{
    public class HealthStatements
    {
        List<HealthStatement> myHealthStatements;

        public HealthStatements()
        {
            myHealthStatements = new List<HealthStatement>();
           // this.addStatement(new HealthStatement());
        }

        public List<HealthStatement> MyHealthStatements
        {
            get { return myHealthStatements; }
            set { myHealthStatements = value; }
        }

        public void addStatement(HealthStatement myStatement)
        {
            myHealthStatements.Add(myStatement);
        }

        public HealthStatements getStatements()
        {
            return this;
        }

        public List<HealthStatement> getList()
        {
            return MyHealthStatements.ToList<HealthStatement>();
        }

        public HealthStatements getStatementsByQuestion(string QuestionNum)
        {
                HealthStatements myStatements = new HealthStatements();
            myStatements.myHealthStatements = (from s in myHealthStatements
                                               where s.QuestionNum.Equals(QuestionNum)
                                               select s).ToList<HealthStatement>();

            return myStatements;
        }

        public HealthStatement getStatementByRowID(int RowID)
        {
            List<HealthStatement> myStatement = (from s in MyHealthStatements where s.RowID==RowID select s).ToList<HealthStatement>();
            
            if (myStatement.Count <= 0)
            {
                myStatement = null;
                return null;
            }
            else
            {
                return myStatement[0];
            }
        }

        public HealthStatement getStatementsByQuestion(string QuestionNum, int RowID)
        {

            List<HealthStatement> myStatement = (from s in myHealthStatements
                               where s.QuestionNum.Equals(QuestionNum)
                               where s.RowID == RowID
                               select s).ToList<HealthStatement>();
            if (myStatement.Count <= 0)
            {
                myStatement = null;
                return null;
            }
            else
            {
                return myStatement[0];
            }
        }
        

    }
}
