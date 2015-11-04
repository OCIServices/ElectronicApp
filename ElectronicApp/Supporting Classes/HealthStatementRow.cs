using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ElectronicApp.Supporting_Classes
{
    public static class HealthStatementRow
    {
        private static List<TextBox> myTxts;
        private static List<TableCell> myCells;
        private static int cells = 8;
        private static int boxes = 6;

        static HealthStatementRow()
        {
            
           
        }

        public static TableRow getRow(string rowID, string number)
        {
            myCells = new List<TableCell>();
            myTxts = new List<TextBox>();
            int i;
            for (i = 0; i < cells; i++)
            {
                myCells.Add(new TableCell());
            }
            for (i = 0; i < boxes; i++)
            {
                myTxts.Add(new System.Web.UI.WebControls.TextBox());
            }
            TableRow myRow = new TableRow();
            myRow.ID = rowID;          
            //Name Cell
            myTxts[0].Width = Unit.Pixel(102);
            myCells[0].Controls.Add(myTxts[0]);
            myCells[0].Width = Unit.Pixel(102);
            myCells[0].ID = "Name";
            myRow.Cells.AddAt(-1, myCells[0]);

            //Condition Cell
            TableCell myCondition = new TableCell();

            myTxts[1].Width = Unit.Pixel(125);
            myCells[1].Controls.Add(myTxts[1]);
            myCells[1].Width = Unit.Pixel(125);
            myCells[1].ID = "Condition";
            myRow.Cells.AddAt(-1, myCells[1]);

            //Date Diagnosed
            myTxts[2].Width = Unit.Pixel(70);
            myCells[2].Controls.Add(myTxts[2]);
            myCells[2].Width = Unit.Pixel(70);
            myCells[2].ID = "Diagnosed";
            myRow.Cells.AddAt(-1, myCells[2]);

            //Date Last Treated
            myTxts[3].Width = Unit.Pixel(70);
            myCells[3].Controls.Add(myTxts[3]);
            myCells[3].Width = Unit.Pixel(70);
            myCells[3].ID = "Treated";
            myRow.Cells.AddAt(-1, myCells[3]);

            //Type of Treatment
            myTxts[4].Width = Unit.Pixel(206);
            myCells[4].Controls.Add(myTxts[4]);
            myCells[4].Width = Unit.Pixel(206);
            myRow.Cells.AddAt(-1, myCells[4]);

            //Mediaction Ongoing
            DropDownList myList = new DropDownList();
            myList.Width = Unit.Pixel(66);
            myList.Items.Add(new ListItem("Select", "Select"));
            myList.Items.Add(new ListItem("no", "no"));
            myList.Items.Add(new ListItem("yes", "yes"));
            myCells[5].Controls.Add(myList);
            myCells[5].Width = Unit.Pixel(66);
            myRow.Cells.AddAt(-1, myCells[5]);

            //Recovery
            myTxts[5].Width = Unit.Pixel(70);
            myCells[6].Controls.Add(myTxts[5]);
            myCells[6].Width = Unit.Pixel(70);
            myRow.Cells.AddAt(-1, myCells[6]);

            HiddenField qNum = new HiddenField();
            qNum.Value = number;
            myCells[7].Width = Unit.Pixel(0);
            myCells[7].Controls.Add(qNum);
            myRow.Cells.AddAt(-1, myCells[7]);

           return myRow;
        }
        }
    }
