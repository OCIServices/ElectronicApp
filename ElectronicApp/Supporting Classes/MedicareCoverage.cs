using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicApp.Supporting_Classes
{
    public class MedicareCoverage
    {
        private string _Name;
        private string _ID;
        private string _effDateA;
        private string _effDateB;
        private string _effDateC;

        public MedicareCoverage()
        {
            _Name = "";
            _ID = "";
            _effDateA = "";
            _effDateB = "";
            _effDateC = "";
        }

        public MedicareCoverage(string name, string id, string effDataA, string effDateB, string effDateC)
        {
            _Name = name;
            _ID = id;
            _effDateA = effDataA;
            _effDateB = effDateB;
            _effDateC = effDateC;
        }

        public string EffDateC
        {
            get { return _effDateC; }
            set { _effDateC = value; }
        }



        public string EffDateB
        {
            get { return _effDateB; }
            set { _effDateB = value; }
        }

        public string EffDateA
        {
            get { return _effDateA; }
            set { _effDateA = value; }
        }

        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

    }
}
