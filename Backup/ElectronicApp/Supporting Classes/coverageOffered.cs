using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicApp.Supporting_Classes
{
    public class coverageOffered
    {
        private string[] _plansOffered;
        private bool _isMedical;
        private bool _isDental;
        private bool _isVision;
        private bool _isLife;
        private bool _isDisability;

        public coverageOffered(string[] plansOffered, bool isMedical, bool isDental, bool isVision, bool isLife, bool isDisability)
        {
            _plansOffered = plansOffered;
            _isMedical = isMedical;
            _isDental = isDental;
            _isVision = isVision;
            _isLife = isLife;
            _isDisability = isDisability;
        }

        public bool IsDisability
        {
            get { return _isDisability; }
            set { _isDisability = value; }
        }

        public bool IsLife
        {
            get { return _isLife; }
            set { _isLife = value; }
        }

        public bool IsVision
        {
            get { return _isVision; }
            set { _isVision = value; }
        }

        public bool IsMedical
        {
            get { return _isMedical; }
            set { _isMedical = value; }
        }


        public bool IsDental
        {
            get { return _isDental; }
            set { _isDental = value; }
        }

        public string[] getPlansOffered()
        {
            return this._plansOffered;
        }
    }
}
