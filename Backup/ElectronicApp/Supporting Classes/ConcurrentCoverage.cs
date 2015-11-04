using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicApp.Supporting_Classes
{
    public class ConcurrentCoverage
    {
        private string _Name;
        private string _Employer;
        private string _InsuranceCompanyName;
        private string _InsuranceCompanyAddress;
        private string _PolicyNo;
        private string _EffectiveDate;
        private string _EndDate;
        private bool _isEmployee;
        private bool _isEmployeeSpouse;
        private bool _isEmployeeChild;
        private bool _isEmployeeSpouseChild;
        private bool _isMedical;
        private bool _isDental;
        private bool _isLife;
        private bool _isVision;
        private bool _isDisability;

        public ConcurrentCoverage()
        {
             _Name = "";
             _Employer = "";
             _InsuranceCompanyName = "";
             _InsuranceCompanyAddress = "";
             _PolicyNo = "";
             _EffectiveDate ="";
             _EndDate = "";
             _isEmployee= false;
             _isEmployeeSpouse = false;
             _isEmployeeChild = false;
             _isEmployeeSpouseChild = false;
             _isMedical = false;
             _isDental = false;
             _isLife = false;
             _isVision = false;
             _isDisability = false;
        }

        public bool IsDisability
        {
            get { return _isDisability; }
            set { _isDisability = value; }
        }

        public bool IsVision
        {
            get { return _isVision; }
            set { _isVision = value; }
        }

        public bool IsLife
        {
            get { return _isLife; }
            set { _isLife = value; }
        }

        public bool IsDental
        {
            get { return _isDental; }
            set { _isDental = value; }
        }

        public bool IsMedical
        {
            get { return _isMedical; }
            set { _isMedical = value; }
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

        public string PolicyNo
        {
            get { return _PolicyNo; }
            set { _PolicyNo = value; }
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


        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
    }
}
