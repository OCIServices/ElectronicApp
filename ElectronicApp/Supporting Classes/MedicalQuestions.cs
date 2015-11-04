using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ElectronicApp.Supporting_Classes
{
    public class MedicalQuestions
    {
        private List<ListItem> _myAnswers;
        private string _dueDate;
        private bool _Q32;
        private bool _Q33;
        private bool _Q34;
        private bool _Q35;

        public MedicalQuestions()
        {
            _myAnswers = new List<ListItem>();
            _dueDate = "";
            _Q32 = false;
            _Q33 = false;
            _Q34 = false;
            _Q35 = false;
        }

        public List<ListItem> MyAnswers
        {
            get { return _myAnswers; }
            set { _myAnswers = value; }
        }
        public string DueDate
        {
            get { return _dueDate; }
            set { _dueDate = value; }
        }
        public bool Q32
        {
            get { return _Q32; }
            set { _Q32 = value; }
        }
        public bool Q33
        {
            get { return _Q33; }
            set { _Q33 = value; }
        }
        public bool Q34
        {
            get { return _Q34; }
            set { _Q34 = value; }
        }
        public bool Q35
        {
            get { return _Q35; }
            set { _Q35 = value; }
        }

    }
}
