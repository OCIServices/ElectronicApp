using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicApp.Supporting_Classes
{
    public class PreviousCoverage
    {
        private string _Names;
        private string _Employer;
        private string _InsuranceCompanyName;
        private string _InsuranceCompanyAddress;
        private string _Policy;
        private string _EffectiveDate;
        private string _EndDate;
        private bool _isEmployee;
        private bool _isEmployeeSpouse;
        private bool _isEmployeeChild;
        private bool _isEmployeeSpouseChild;

        public PreviousCoverage()
        {
             _Names = "";
             _Employer = "";
             _InsuranceCompanyName = "";
             _InsuranceCompanyAddress = "";
             _Policy = "";
             _EffectiveDate ="";
             _EndDate = "";
             _isEmployee= false;
             _isEmployeeSpouse = false;
             _isEmployeeChild = false;
             _isEmployeeSpouseChild = false;
        }

        public bool IsEmployeeSpouseChild
        {
            get { return _isEmployeeSpouseChild; }
            set { _isEmployeeSpouseChild = value; }
        }

        public bool IsEmployeeChild
        {
            get { return _isEmployeeChild; }
            set { _isEmployeeChild = value; }
        }


        public bool IsEmployeeSpouse
        {
            get { return _isEmployeeSpouse; }
            set { _isEmployeeSpouse = value; }
        }

        public bool IsEmployee
        {
            get { return _isEmployee; }
            set { _isEmployee = value; }
        }

        public string EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }

        public string EffectiveDate
        {
            get { return _EffectiveDate; }
            set { _EffectiveDate = value; }
        }

        public string Policy
        {
            get { return _Policy; }
            set { _Policy = value; }
        }



        public string InsuranceCompanyAddress
        {
            get { return _InsuranceCompanyAddress; }
            set { _InsuranceCompanyAddress = value; }
        }

        public string InsuranceCompanyName
        {
            get { return _InsuranceCompanyName; }
            set { _InsuranceCompanyName = value; }
        }

        public string Employer
        {
            get { return _Employer; }
            set { _Employer = value; }
        }

        public string Names
        {
            get { return _Names; }
            set { _Names = value; }
        }
    }
}
