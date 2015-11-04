using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicApp.Supporting_Classes
{
    public class DeclineReason
    {
        private bool _SpousePlan;

        public bool SpousePlan
        {
            get { return _SpousePlan; }
            set { _SpousePlan = value; }
        }
        private bool _Medicare;

        public bool Medicare
        {
            get { return _Medicare; }
            set { _Medicare = value; }
        }
        private bool _COBRA;

        public bool COBRA
        {
            get { return _COBRA; }
            set { _COBRA = value; }
        }
        private bool _NoCoverage;

        public bool NoCoverage
        {
            get { return _NoCoverage; }
            set { _NoCoverage = value; }
        }
        private bool _Disability;

        public bool Disability
        {
            get { return _Disability; }
            set { _Disability = value; }
        }
        private bool _Individual;

        public bool Individual
        {
            get { return _Individual; }
            set { _Individual = value; }
        }
        private bool _VA;

        public bool VA
        {
            get { return _VA; }
            set { _VA = value; }
        }
        private bool _TriCare;

        public bool TriCare
        {
            get { return _TriCare; }
            set { _TriCare = value; }
        }
        private bool _Medicaid;

        public bool Medicaid
        {
            get { return _Medicaid; }
            set { _Medicaid = value; }
        }
        private bool _Other;

        public bool Other
        {
            get { return _Other; }
            set { _Other = value; }
        }
        private string _Explanation;

        public string Explanation
        {
            get { return _Explanation; }
            set { _Explanation = value; }
        }

        public DeclineReason()
        {
            _SpousePlan = false;
            _Medicare = false;
            _COBRA = false;
            _NoCoverage = false;
            _Disability = false;
            _Individual = false;
            _VA = false;
            _TriCare = false;
            _Medicaid = false;
            _Other = false;
            _Explanation = "";


        }
    }
}
