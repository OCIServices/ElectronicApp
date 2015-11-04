<%@ Page Language="C#" Theme="FormPage" AutoEventWireup="true" CodeBehind="HealthInformation.aspx.cs" Inherits="ElectronicApp.NebraskaApp.HealthInformation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Health Information</title>
    <script language="javascript" type="text/javascript" src="Validation/validationHelpers.js"></script>
    <script language="javascript" type="text/javascript" src="Validation/HealthInformation/ValidateHealthInformation.js"></script>
    <script type="text/javascript">
    function toggleDueDate() {
        if (document.getElementById("CheckBoxList1_8").checked) {
            document.getElementById("trDueDate").style.display = "";
        }
        else if (!document.getElementById("CheckBoxList1_8").checked) {
        document.getElementById("trDueDate").style.display = "none";
        }
    }
    function pageInit() {
        document.getElementById("trDueDate").style.display = "none";
        //document.getElementById("CheckBoxList1_8").onClick="toggleDueDate()";
    }
    </script>
    <style type="text/css">
        .style1
        {
            width: 367px;
        }
        .style2
        {
            width: 275px;
        }
        .style3
        {
            height: 22px;
            width: 645px;
        }
        .style4
        {
            width: 645px;
        }
        .style5
        {
            width: 81px;
        }
        .style6
        {
            width: 15px;
        }
        .style7
        {
            width: 81px;
            height: 37px;
        }
        .style8
        {
            width: 15px;
            height: 37px;
        }
        .style9
        {
            height: 37px;
            width: 609px;
        }
        .style10
        {
            width: 609px;
        }
        .style11
        {
            width: 142px;
        }
        .style12
        {
            width: 213px;
        }
    </style>
</head>
<body onload="pageInit()">
    <form id="form1" runat="server">
    <div id="FormContainer">
        <div id="FormTop"><h1><span class="red">Health</span> Information</h1></div>
           <div id="FormMid"> 
           <div id="Health1">
               <table style="margin-left: 40px;">
                   <tr>
                       <td class="style3">
                           <asp:Label ID="Label1" runat="server" CssClass="tableTitle" Text="Section 1"></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td class="style4">
                           <asp:Label ID="Label2" runat="server" 
                               Text="Please provide the health history of you and any person named in this application who has been diagnosed or treated in the last 10 years by placing an &quot;X&quot; in the following boxes. Please further explain your selections in Section 3 - Health Statement Table. "></asp:Label>
                       </td>
                   </tr>
                   </table>
               <table style="width: 100%; margin-left: 45px; margin-top: 4px;">
                   <tr>
                       <td class="style1" colspan="2">
                           <asp:CheckBoxList ID="CheckBoxList1" runat="server" Width="363px" 
                               CellPadding="2" CellSpacing="2">
                               <asp:ListItem>1. AIDS/HIV</asp:ListItem>
                               <asp:ListItem>2. Allergy/Asthma</asp:ListItem>
                               <asp:ListItem>3. Arthritis</asp:ListItem>
                               <asp:ListItem>4. Bladder/Urinary Disorder</asp:ListItem>
                               <asp:ListItem>5. Blood, Bleeding or Clotting Disorder</asp:ListItem>
                               <asp:ListItem>6. Bone/Joint/Muscular Disorder</asp:ListItem>
                               <asp:ListItem>7. Cancer</asp:ListItem>
                               <asp:ListItem>8. Cyst</asp:ListItem>
                               <asp:ListItem>9. Current Pregnancy</asp:ListItem>
                               <asp:ListItem>10. Diabetes</asp:ListItem>
                               <asp:ListItem>11. Digestive/Intestianl Disorder</asp:ListItem>
                               <asp:ListItem>12. Drug or Alchohol Abuse</asp:ListItem>
                               <asp:ListItem>13. Eating Disorder</asp:ListItem>
                               <asp:ListItem>14. Endocerine/Pancreatic Disorder</asp:ListItem>
                               <asp:ListItem>15. Eye, Ear, Nose, Throat Disorder (Exluding glasses)</asp:ListItem>
                           </asp:CheckBoxList>
                       </td>

                       <td class="style2">
                           <asp:CheckBoxList ID="CheckBoxList3" runat="server" CellPadding="2" 
                               CellSpacing="2" Width="334px">
                               <asp:ListItem>16. Heart/Circulatory Disorder</asp:ListItem>
                               <asp:ListItem>17. High Blood Pressure</asp:ListItem>
                               <asp:ListItem>18. High Cholesterol</asp:ListItem>
                               <asp:ListItem>19. Infertility</asp:ListItem>
                               <asp:ListItem>20. Kidney Disorder (dialysys or failure)</asp:ListItem>
                               <asp:ListItem>21. Liver (cirrhosis, hepititis B, C, D or E</asp:ListItem>
                               <asp:ListItem>22. Mental or Nervous Disorder</asp:ListItem>
                               <asp:ListItem>23. Migraine Headaches</asp:ListItem>
                               <asp:ListItem>24. Neck, Back or Spine Disorder</asp:ListItem>
                               <asp:ListItem>25. Organ Transplant</asp:ListItem>
                               <asp:ListItem>26. Respiratory/Lung Disorder</asp:ListItem>
                               <asp:ListItem>27. Skin Disorder</asp:ListItem>
                               <asp:ListItem>28. Stroker/Nervous System/Brain Disorder</asp:ListItem>
                               <asp:ListItem>29. Tumor</asp:ListItem>
                               <asp:ListItem>30. Tobacco Product Use</asp:ListItem>
                               <asp:ListItem>31. Vascular (blood vessel) Disorder</asp:ListItem>
                           </asp:CheckBoxList>
                       </td>
                   </tr>
                   <tr id="trDueDate">
                       <td class="style11">
                           &nbsp;
                           <asp:Label ID="Label8" runat="server" Text="Pregnancy Due Date:"></asp:Label>
                       </td>
                       <td class="style12">
                           <asp:TextBox ID="txtDueDate" runat="server"></asp:TextBox>
                       </td>
                       <td class="style2">
                           &nbsp;
                       </td>
                       <td>
                           &nbsp;
                       </td>
                   </tr>
                   <tr>
                       <td class="style11">
                           &nbsp;</td>
                       <td class="style12">
                           &nbsp;</td>
                       <td class="style2">
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                   </tr>
               </table>
               <table style="width: 672px; margin-left: 40px;">
                   <tr>
                       <td>
                           
                           <asp:Label ID="Label3" runat="server" CssClass="tableTitle" Text="Section 2"></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           
                           Please answer yes or no to the following Questions.&nbsp; Please further explain 
                           your &quot;yes&quot; selections in Section 3 - Health Statement Table.</td>
                   </tr>
                   <tr>
                       <td>
                       </td>
                   </tr>
               </table>
               <table style="width: 717px; margin-left: 40px; margin-top: 4px;" 
                   cellpadding="2" cellspacing="2">
                   <tr>
                       <td class="style7" valign="top">
                           <asp:DropDownList ID="Q32" runat="server" Height="22px" Width="75px">
                               <asp:ListItem>(Select)</asp:ListItem>
                               <asp:ListItem>no</asp:ListItem>
                               <asp:ListItem>yes</asp:ListItem>
                           </asp:DropDownList>
                       </td>
                       <td class="style8" valign="top">
                           32.</td>
                       <td class="style9" valign="top">
                           <asp:Label ID="Label4" runat="server" Text="Have you or any person named in this application received inpatient or outpatient services in the last three (3) years (excluding routine tests, physicals or innoculations)?"></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td class="style5" valign="top">
                           <asp:DropDownList ID="Q33" runat="server" Width="75px">
                               <asp:ListItem>(Select)</asp:ListItem>
                               <asp:ListItem>no</asp:ListItem>
                               <asp:ListItem>yes</asp:ListItem>
                           </asp:DropDownList>
                       </td>
                       <td class="style6" valign="top">
                           33.</td>
                       <td valign="top" class="style10">
                           <asp:Label ID="Label5" runat="server" Text="Do you or any person named in this application have tests, treatments, hospitalization or surgery planned or recommended in the future?"></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td class="style5" valign="top">
                           <asp:DropDownList ID="Q34" runat="server" Width="75px">
                               <asp:ListItem>(Select)</asp:ListItem>
                               <asp:ListItem>no</asp:ListItem>
                               <asp:ListItem>yes</asp:ListItem>
                           </asp:DropDownList>
                       </td>
                       <td class="style6" valign="top">
                           34.</td>
                       <td valign="top" class="style10">
                           
                           <asp:Label ID="Label6" runat="server" Text="Do you or any person named in this application take any medicine, prescription drugs or require shots/injections?"></asp:Label>
                           
                       </td>
                   </tr>
                   <tr>
                       <td class="style5" valign="top">
                           <asp:DropDownList ID="Q35" runat="server" Width="75px">
                               <asp:ListItem>(Select)</asp:ListItem>
                               <asp:ListItem>no</asp:ListItem>
                               <asp:ListItem>yes</asp:ListItem>
                           </asp:DropDownList>
                       </td>
                       <td class="style6" valign="top">
                           35.</td>
                       <td valign="top" class="style10">
                           <asp:Label ID="Label7" runat="server" Text="Do you or any person named in this application have any other medical conditions which have not yet been previously mentioned?"></asp:Label>
                       </td>
                   </tr>
               </table>
                 <asp:Button ID="btnNext" runat="server" Height="30px" 
                   style="margin-right: 40px; margin-top: 22px;" Text="Next" Width="70px" onclick="btnNext_Click" 
                   CssClass="btnLogin" />
               <div class="clearFloat"></div>
               </div>
           </div>
        <div id ="FormBottom"></div>
       </div>
    </form>
</body>
</html>
