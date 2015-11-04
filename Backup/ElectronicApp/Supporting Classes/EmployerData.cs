using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicApp.Supporting_Classes
{
    public class EmployerData
    {
        private string _Employer;
        private string _Phone;
        private string _Address;
        private string _City;
        private string _State;
        private string _ZIP;
        private string _FAX;

        public string FAX
        {
            get { return _FAX; }
            set { _FAX = value; }
        }

        public string ZIP
        {
            get { return _ZIP; }
            set { _ZIP = value; }
        }

        public string State
        {
            get { return _State; }
            set { _State = value; }
        }

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        
        public string Employer
        {
            get { return _Employer; }
            set { _Employer = value; }
        }
    }
}
