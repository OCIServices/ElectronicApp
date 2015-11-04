using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicApp.Supporting_Classes
{
    public class LifeBeneficiaries
    {
        private string _Primary1Name;
        private string _Primary1Percent;
        private string _Primary1Relationship;
        private string _Primary1SSN;
        private string _Primary2Name;
        private string _Primary2Percent;
        private string _Primary2Relationship;
        private string _Primary2SSN;
        private string _Secondary1Name;
        private string _Secondary1Percent;
        private string _Secondary1Relationship;
        private string _Secondary1SSN;
        private string _Secondary2Name;
        private string _Secondary2Percent;
        private string _Secondary2Relationship;
        private string _Secondary2SSN;

        public LifeBeneficiaries()
        {
             _Primary1Name = "";
             _Primary1Percent = "";
             _Primary1Relationship = "";
             _Primary1SSN = "";
             _Primary2Name = "";
             _Primary2Percent = "";
             _Primary2Relationship = "";
             _Primary2SSN = "";
             _Secondary1Name = "";
             _Secondary1Percent = "";
             _Secondary1Relationship = "";
             _Secondary1SSN = "";
             _Secondary2Name = "";
             _Secondary2Percent = "";
             _Secondary2Relationship = "";
             _Secondary2SSN = "";   
        }

        public string Primary1SSN
        {
            get { return _Primary1SSN; }
            set { _Primary1SSN = value; }
        }

        public string Primary1Name
        {
            get { return _Primary1Name; }
            set { _Primary1Name = value; }
        }

        public string Primary1Percent
        {
            get { return _Primary1Percent; }
            set { _Primary1Percent = value; }
        }


        public string Primary1Relationship
        {
            get { return _Primary1Relationship; }
            set { _Primary1Relationship = value; }
        }

        public string Primary2SSN
        {
            get { return _Primary2SSN; }
            set { _Primary2SSN = value; }
        }

        public string Primary2Name
        {
            get { return _Primary2Name; }
            set { _Primary2Name = value; }
        }

        public string Primary2Percent
        {
            get { return _Primary2Percent; }
            set { _Primary2Percent = value; }
        }


        public string Primary2Relationship
        {
            get { return _Primary2Relationship; }
            set { _Primary2Relationship = value; }
        }

        public string Secondary1SSN
        {
            get { return _Secondary1SSN; }
            set { _Secondary1SSN = value; }
        }

        public string Secondary1Name
        {
            get { return _Secondary1Name; }
            set { _Secondary1Name = value; }
        }

        public string Secondary1Percent
        {
            get { return _Secondary1Percent; }
            set { _Secondary1Percent = value; }
        }


        public string Secondary1Relationship
        {
            get { return _Secondary1Relationship; }
            set { _Secondary1Relationship = value; }
        }

        public string Secondary2SSN
        {
            get { return _Secondary2SSN; }
            set { _Secondary2SSN = value; }
        }

        public string Secondary2Name
        {
            get { return _Secondary2Name; }
            set { _Secondary2Name = value; }
        }

        public string Secondary2Percent
        {
            get { return _Secondary2Percent; }
            set { _Secondary2Percent = value; }
        }


        public string Secondary2Relationship
        {
            get { return _Secondary2Relationship; }
            set { _Secondary2Relationship = value; }
        }
    }
}
