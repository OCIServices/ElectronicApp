using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ElectronicApp.Supporting_Classes
{
    public static class HealthStatementHeaderRow
    {
        private static TableCell[] myCells;
        private static TableRow myRow;

        static HealthStatementHeaderRow()
        {
            myCells = new TableCell[8];
            myRow = new TableRow();
            int i;
            for (i = 0; i < myCells.Length; i++)
            {
                myCells[i] = new TableCell();
            }
     
        }
        public static TableRow getRow()
        {
            TableRow myRow = new TableRow();
            myCells = new TableCell[7];
            int i = 0;
            for (i = 0; i < myCells.Length; i++)
            {
                myCells[i] = new TableCell();
            }

            //Name Cell
            
            myCells[0].Text = "Person Name";
            myCells[0].Width = Unit.Pixel(102);
            myRow.Cells.AddAt(-1, myCells[0]);

            //Condition Cell
            
            myCells[1].Text = "Condition";
            myCells[1].Width = Unit.Pixel(125);
            myRow.Cells.AddAt(-1, myCells[1]);

            //Date Diagnosed
            
            myCells[2].Text = "Date Diagnosed";
            myCells[2].Width = Unit.Pixel(70);
            myRow.Cells.AddAt(-1, myCells[2]);

            //Date Last Treated
           myCells[3].Text = "Date Last Treated";
            myCells[3].Width = Unit.Pixel(70);
            myRow.Cells.AddAt(-1, myCells[3]);

            //Type of Treatment
            
            myCells[4].Text = "Type of Treatment and Names of Medication (e.g. Oral,  Injectable, infusion, inhaled or transdermal)";
            myCells[4].Width = Unit.Pixel(206);
            myRow.Cells.AddAt(-1, myCells[4]);

            //Mediaction Ongoing
            
            myCells[5].Text = "Medication Ongoing?";
            myCells[5].Width = Unit.Pixel(66);
            myRow.Cells.AddAt(-1, myCells[5]);

            //Recovery
            
            myCells[6].Text = "Degree of Recovery";
            myCells[6].Width = Unit.Pixel(206);
            myRow.Cells.AddAt(-1, myCells[6]);

            return myRow;
        }
    }
}
