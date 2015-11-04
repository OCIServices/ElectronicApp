using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicApp.Supporting_Classes
{
    public class CoverageItem
    {
        private string _CoverageType;
        private string _CoverageSelected;
        private bool _WaiveSpouse;
        private bool _WaiveChildren;
        private bool _WaiveEmployee;

        public CoverageItem()
        {
            _CoverageSelected = "";
            _CoverageType = "";
            _WaiveSpouse = false;
            _WaiveChildren = false;
            _WaiveEmployee = false;
        }

        public CoverageItem(string CoverageType, string SelectedCoverage, bool isSingle, bool isChildren)
        {
            //CoverageItem this = new CoverageItem();
            this.CoverageType = CoverageType;
            if (CoverageType.Equals("Disability"))
            {
                if (SelectedCoverage.ToLower().Equals("waive"))
                {
                    this.WaiveEmployee = true;
                }
                this.CoverageSelected = SelectedCoverage;
            }
            else if (!isSingle)
            {
                /**
                 * Determine if there is an implied waver for any coverage for married/no children
                 **/
                if (!isChildren)
                {
                    if (SelectedCoverage.ToLower().Equals("employee"))
                    {
                        this.CoverageSelected = SelectedCoverage;
                        this.WaiveSpouse = true;
                    }
                    else if (SelectedCoverage.ToLower().Equals("employee/spouse"))
                    {
                        this.CoverageSelected = SelectedCoverage;
                    }
                    else if (SelectedCoverage.ToLower().Equals("waive"))
                    {
                        this.CoverageSelected = SelectedCoverage;
                        this.WaiveSpouse = true;
                        this.WaiveEmployee = true;
                    }

                }
                /**
                * Determine if there is an implied waver for any coverage for married/children
                **/
                else
                {
                    if (SelectedCoverage.ToLower().Equals("employee"))
                    {
                        this.CoverageSelected = SelectedCoverage;
                        this.WaiveSpouse = true;
                        this.WaiveChildren = true;
                    }
                    else if (SelectedCoverage.ToLower().Equals("employee/spouse"))
                    {
                        this.CoverageSelected = SelectedCoverage;
                        this.WaiveChildren = true;
                    }
                    else if (SelectedCoverage.ToLower().Equals("employee/child(ren)"))
                    {
                        this.CoverageSelected = SelectedCoverage;
                        this.WaiveSpouse = true;
                    }
                    else if (SelectedCoverage.ToLower().Equals("employee/spouse/child(ren)"))
                    {
                        this.CoverageSelected = SelectedCoverage;
                    }
                    else if (SelectedCoverage.ToLower().Equals("waive"))
                    {
                        this.CoverageSelected = SelectedCoverage;
                        this.WaiveSpouse = true;
                        this.WaiveEmployee = true;
                        this.WaiveChildren = true;
                    }
                }
            }
            else
            {
                /**
                 * Determine if there is an implied waver for any coverage for single/no children
                 **/
                if (!isChildren)
                {
                    if (SelectedCoverage.ToLower().Equals("employee"))
                    {
                        this.CoverageSelected = SelectedCoverage;
                    }
                    else if (SelectedCoverage.ToLower().Equals("waive"))
                    {
                        this.CoverageSelected = SelectedCoverage;
                        this.WaiveEmployee = true;
                    }

                }
                /**
                * Determine if there is an implied waver for any coverage for single/children
                **/
                else
                {
                    if (SelectedCoverage.ToLower().Equals("employee"))
                    {
                        this.CoverageSelected = SelectedCoverage;
                        this.WaiveChildren = true;
                    }
                    else if (SelectedCoverage.ToLower().Equals("employee/child(ren)"))
                    {
                        this.CoverageSelected = SelectedCoverage;
                    }
                    else if (SelectedCoverage.ToLower().Equals("waive"))
                    {
                        this.CoverageSelected = SelectedCoverage;
                        this.WaiveEmployee = true;
                        this.WaiveChildren = true;
                    }
                }
            }
        }

        public bool WaiveEmployee
        {
            get { return _WaiveEmployee; }
            set { _WaiveEmployee = value; }
        }

        public bool WaiveChildren
        {
            get { return _WaiveChildren; }
            set { _WaiveChildren = value; }
        }

        public bool WaiveSpouse
        {
            get { return _WaiveSpouse; }
            set { _WaiveSpouse = value; }
        }

        public string CoverageSelected
        {
            get { return _CoverageSelected; }
            set { _CoverageSelected = value; }
        }

        public string CoverageType
        {
            get { return _CoverageType; }
            set { _CoverageType = value; }
        }
    }
}
