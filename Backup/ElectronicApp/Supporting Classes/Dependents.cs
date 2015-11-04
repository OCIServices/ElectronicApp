using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicApp.Supporting_Classes
{
    public class Dependents
    {
        private List<Dependent> myDependents;

        public Dependents()
        {
            myDependents = new List<Dependent>();
        }

        public void addDependent(Dependent myDependent)
        {
            myDependents.Add(myDependent);
        }

        public Dependent getSpouse()
        {
            Dependent spouse = null;
            foreach (Dependent d in myDependents)
            {
                if (d.IsSpouse)
                {
                    spouse = d;
                    break;
                }
            }
            return spouse;
        }

        public List<Dependent> getDependents()
        {
            List<Dependent> dependents = new List<Dependent>();
            foreach (Dependent d in myDependents)
            {
                if (!d.IsSpouse)
                {
                    dependents.Add(d);
                }
            }
            return dependents;
        }
    }
}
