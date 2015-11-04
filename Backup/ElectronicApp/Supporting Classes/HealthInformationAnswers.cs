using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ElectronicApp.Supporting_Classes
{
    public class HealthInformationAnswers
    {
        List<ListItem> _myAnswers;
        private bool _Q32;
        private bool _Q33;
        private bool _Q34;
        private bool _Q35;
        private string _DueData;

        public string DueData
        {
            get { return _DueData; }
            set { _DueData = value; }
        }

        public HealthInformationAnswers()
        {
            _myAnswers = new List<ListItem>();
            _Q32 = false;
            _Q33 = false;
            _Q34 = false;
            _Q35 = false;
            _DueData = "";
        }
        
        public List<ListItem> MyAnswers
        {
            get { return _myAnswers; }
            set { _myAnswers = value; }
        }

        public void addAnswer(ListItem li)
        {
            _myAnswers.Add(li);
        }

        public bool Q35
        {
            get { return _Q35; }
            set { _Q35 = value; }
        }

        public bool Q34
        {
            get { return _Q34; }
            set { _Q34 = value; }
        }

        public bool Q33
        {
            get { return _Q33; }
            set { _Q33 = value; }
        }

        public bool Q32
        {
            get { return _Q32; }
            set { _Q32 = value; }
        }
    }
}
