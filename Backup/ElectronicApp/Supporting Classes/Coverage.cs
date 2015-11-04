using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicApp.Supporting_Classes
{
    public class Coverage
    {
        private string _PlanSelected;
        private List<CoverageItem> _CoverageItems;
        private bool _isWaiveAll;



        public Coverage()
        {
            _CoverageItems = new List<CoverageItem>();
            _PlanSelected = "";
            _isWaiveAll = false;
        }



        public Coverage( bool isWaveAll)
        {
            _CoverageItems = new List<CoverageItem>();
            _PlanSelected = "";
            _isWaiveAll = isWaveAll;
        }

        public bool IsWaiveAll
        {
            get { return _isWaiveAll; }
            set { _isWaiveAll = value; }
        }


        public bool isWaiving()
        {
            bool rval = false;
            foreach (CoverageItem ci in _CoverageItems)
            {
                if (ci.WaiveChildren || ci.WaiveEmployee || ci.WaiveSpouse)
                {
                    rval = true;
                }
            }
            return rval;
        }

        public bool isWaiving(string CoverageType)
        {
            bool rval = false;
            if (_isWaiveAll)
            {
                foreach (CoverageItem ci in _CoverageItems)
                {
                    if (ci.CoverageType.Equals(CoverageType, StringComparison.CurrentCultureIgnoreCase))
                    {
                        rval = true;
                        break;
                    }
                }
            }
            else
            {
                foreach (CoverageItem ci in _CoverageItems)
                {
                    if ((ci.CoverageType.Equals(CoverageType, StringComparison.CurrentCultureIgnoreCase) &&
                                            (ci.WaiveChildren || ci.WaiveEmployee || ci.WaiveSpouse)))
                    {
                        rval = true;
                        break;
                    }
                }
            }
            return rval;
        }

        public List<CoverageItem> CoverageItems
        {
            get { return _CoverageItems; }
            set { _CoverageItems = value; }
        }
        public string PlanSelected
        {
            get { return _PlanSelected; }
            set { _PlanSelected = value; }
        }

        public void addCoverageItem(CoverageItem coverageItem)
        {
            _CoverageItems.Add(coverageItem);
        }

        public CoverageItem getCoverageItem(string coverageType)
        {
            CoverageItem rval = null;
            foreach (CoverageItem ci in _CoverageItems)
            {
                if(ci.CoverageType.Equals(coverageType,StringComparison.CurrentCultureIgnoreCase))
                {
                    rval = ci;
                    break;
                }
            }
            return rval;
        }

        public string getWhoIsWaiving(string coverageType)
        {
            CoverageItem c = getCoverageItem(coverageType);
            string rval = "";
            if (this.IsWaiveAll && c != null)
            {
                rval = "Yourself and any Dependents if applicable";
            }
            else if( c != null)
            {
                if (c.WaiveEmployee)
                {
                    rval += "Yourself";
                }
                if (c.WaiveSpouse)
                {
                    rval += " Spouse";
                }
                if (c.WaiveChildren)
                {
                    rval += " Child(ren)";
                }
                rval = rval.Trim().Replace(" ", ", ");
            }
            return rval;
        }

        public bool isSpouseCovered()
        {
            bool rval = false;
            foreach (CoverageItem c in CoverageItems)
            {
                if (c.CoverageSelected.IndexOf("Spouse",StringComparison.CurrentCultureIgnoreCase) != -1)
                {
                    rval = true;
                    break;
                }
            }
            return rval;
        }

        public bool isChildCovered()
        {
            bool rval = false;
            foreach (CoverageItem c in CoverageItems)
            {
                if (c.CoverageSelected.IndexOf("Child(ren)", StringComparison.CurrentCultureIgnoreCase) != -1)
                {
                    rval = true;
                    break;
                }
            }
            return rval;
        }
    }
}
