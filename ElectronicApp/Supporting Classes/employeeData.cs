using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicApp.Supporting_Classes
{
    public class employeeData
    {
        private string _EmployeeName;
        private string _HomeAddress;
        private string _WorkPhone;
        private string _HomePhone;
        private string _City;
        private string _State;
        private string _Zip;
        private string _Email;
        private string _DOB;
        private string _Soc;
        private string _Height;
        private string _Weight;
        private string _PrimaryPhysician;
        private string _JobTitle;
        private string _DOH;
        private string _AvgHours;
        private string _Salary;
        private string _EmploymentStatus;
        private string _MaritalStatus;
        private string _Gender;
        private bool _Medicare;
        private bool _Disabled;
        private int _NumChildren;
        private bool _WaiveAll;
        private bool _isChildren;      
        private bool _isSingle;

        public employeeData()
        {
            _EmployeeName="";
            _HomeAddress="";
            _WorkPhone="";
            _HomePhone="";
            _City="";
            _State="";
            _Zip="";
            _Email="";
            _DOB="";
            _Soc="";
            _Height="";
            _Weight="";
            _PrimaryPhysician="";
            _JobTitle="";
            _DOH="";
            _AvgHours="";
            _Salary="";
            _EmploymentStatus="";
            _MaritalStatus="";
            _Gender="";
            _Medicare=false;
            _Disabled=false;
            _NumChildren = 0;
            _WaiveAll = false;
            _isChildren = false;
            _isSingle = true;
        }

        public bool IsChildren
        {
            get { return _isChildren; }
            set { _isChildren = value; }
        }

        public bool IsSingle
        {
            get { return _isSingle; }
            set { _isSingle = value; }
        }

        public bool WaiveAll
        {
            get { return _WaiveAll; }
            set { _WaiveAll = value; }
        }


        public int NumChildren
        {
            get { return _NumChildren; }
            set
            {
                if (value > 0)
                {
                    _isChildren = true;
                }
                else
                {
                    _isChildren = false;
                }
                _NumChildren = value;
            }
        }

        public bool Disabled
        {
            get { return _Disabled; }
            set { _Disabled = value; }
        }

        public bool Medicare
        {
            get { return _Medicare; }
            set { _Medicare = value; }
        }

        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }

        public string MaritalStatus
        {
            get { return _MaritalStatus; }
            set 
            {
                if(value.ToString().Equals("Married",StringComparison.CurrentCultureIgnoreCase))
                {
                    _isSingle = false;
                }
                else
                {
                    _isSingle = true;
                }

                _MaritalStatus = value; 
            }
        }

        public string EmploymentStatus
        {
            get { return _EmploymentStatus; }
            set { _EmploymentStatus = value; }
        }

        public string Salary
        {
            get { return _Salary; }
            set { _Salary = value; }
        }

        public string AvgHours
        {
            get { return _AvgHours; }
            set { _AvgHours = value; }
        }

        public string DOH
        {
            get { return _DOH; }
            set { _DOH = value; }
        }

        public string JobTitle
        {
            get { return _JobTitle; }
            set { _JobTitle = value; }
        }

        public string PrimaryPhysician
        {
            get { return _PrimaryPhysician; }
            set { _PrimaryPhysician = value; }
        }

        public string Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }


        public string Height
        {
            get { return _Height; }
            set { _Height = value; }
        }

        public string Soc
        {
            get { return _Soc; }
            set { _Soc = value; }
        }


        public string DOB
        {
            get { return _DOB; }
            set { _DOB = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string Zip
        {
            get { return _Zip; }
            set { _Zip = value; }
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

        public string HomePhone
        {
            get { return _HomePhone; }
            set { _HomePhone = value; }
        }

        public string WorkPhone
        {
            get { return _WorkPhone; }
            set { _WorkPhone = value; }
        }

        public string HomeAddress
        {
            get { return _HomeAddress; }
            set { _HomeAddress = value; }
        }

        public string EmployeeName
        {
            get { return _EmployeeName; }
            set { _EmployeeName = value; }
        }
    }
}
