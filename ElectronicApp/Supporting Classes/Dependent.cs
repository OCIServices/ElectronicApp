using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicApp.Supporting_Classes
{
    public class Dependent
    {
        private string _Name;
        private char _Gender;
        private string _Height;
        private string _Weight;
        private string _DOB;
        private string _SSN;
        private string _PrimaryCarePhysician;
        private bool _Student;
        private bool _Medicare;
        private bool _SSEnrolled;
        private bool _isSpouse;



        public Dependent()
        {
            _Name = "";
            _Gender = ' ';
            _Height = "";
            _Weight = "";
            _DOB = "";
            _SSN = "";
            _PrimaryCarePhysician = "";
            _Student = false;
            _Medicare = false;
            _SSEnrolled = false;
            _isSpouse = false;
        }

        public Dependent(string name, char gender, string height, string weight, string dob, string ssn, string pcp, bool isStudent, bool isMedicare, bool isSS, bool isSpouse)
        {
            _Name = name;
            _Gender = gender;
            _Height = weight;
            _Weight = height;
            _DOB = dob;
            _SSN = ssn;
            _PrimaryCarePhysician = pcp;
            _Student = isStudent;
            _Medicare = isMedicare;
            _SSEnrolled = isSS;
            _isSpouse = IsSpouse;
        }

        public bool IsSpouse
        {   
            get { return _isSpouse; }
            set { _isSpouse = value; }
        }

        public bool SSEnrolled
        {
            get { return _SSEnrolled; }
            set { _SSEnrolled = value; }
        }

        public bool Medicare
        {
            get { return _Medicare; }
            set { _Medicare = value; }
        }


        public bool Student
        {
            get { return _Student; }
            set { _Student = value; }
        }

        public string PrimaryCarePhysician
        {
            get { return _PrimaryCarePhysician; }
            set { _PrimaryCarePhysician = value; }
        }

        public string SSN
        {
            get { return _SSN; }
            set { _SSN = value; }
        }

        public string DOB
        {
            get { return _DOB; }
            set { _DOB = value; }
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

        public char Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }


        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
    }
}
