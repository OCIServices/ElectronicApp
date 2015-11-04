<%@ Page Language="C#" Theme="FormPage" AutoEventWireup="true" CodeBehind="OtherCoverage.aspx.cs" Inherits="ElectronicApp.NebraskaApp.OtherCoverage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript" src="Validation/OtherCoverage/ValidateOtherCoverage.js"></script>
    <script language="javascript" type="text/javascript" src="Validation/validationHelpers.js"></script>
    <script type="text/javascript">
    function PageInit()
    {
        document.getElementById("Medicare").style.display = "none";
        document.getElementById("ConcurrentCoverage").style.display = "none";
        document.getElementById("PreviousCoverage").style.display = "none";
        if (document.getElementById("isLife").value == "0") {
            document.getElementById("tableLife").style.display = "none";
        }
        else {
            document.getElementById("tableLife").style.display = "";
        }
    }
    </script>
    <style type="text/css">
        .style1
        {
            width: 380px;
        }
        .style2
        {
            width: 552px;
        }
        .style3
        {
            width: 91px;
        }
        .style4
        {
            width: 407px;
        }
        #tableMedicare
        {
            width: 653px;
            margin-left: 30px;
        }
        .style9
        {
            width: 136px;
        }
        .style10
        {
            width: 34px;
        }
        .style13
        {
            width: 85px;
        }
        .style15
        {
            width: 74px;
        }
        #tableMedicare2
        {
            margin-left: 40px;
            margin-bottom: 10px;
        }
        #tableMedicare1
        {
            margin-left: 40px;
            margin-top: 11px;
        }
        .style18
        {
            width: 53px;
        }
        .style19
        {
            width: 321px;
        }
        .style22
        {
            width: 252px;
        }
        .style31
        {
            width: 61px;
        }
        .style32
        {
            width: 50px;
        }
        .style33
        {
            width: 72px;
        }
        .style34
        {
            width: 57px;
        }
        .style35
        {
            width: 94px;
        }
        .style36
        {
            width: 163px;
        }
        .style37
        {
            width: 110px;
        }
        .style38
        {
            width: 146px;
        }
        .style39
        {
            width: 59px;
        }
        .style40
        {
            width: 60px;
        }
        .style41
        {
            width: 63px;
        }
        .style42
        {
            width: 143px;
        }
    </style>
</head>
<body onload="PageInit()">
    <form id="form1" runat="server">
    <asp:HiddenField ID="isLife" runat="server" />
    <div id="FormContainer">
    <div id="FormTop"><h1><span class="red">Other</span> Coverage & Beneficiaries</h1></div>
           <div id="FormMid">
               <table style="margin-left: 30px; margin-bottom: 4px;">
                   <tr>
                       <td class="style1">
                           <asp:Label ID="Label2" runat="server" 
                               Text="Do you or any of your dependents have Medicare Coverage?" 
                               CssClass="tableTitle"></asp:Label>
                       </td>
                       <td>
                           <asp:DropDownList ID="cmbMedicare" runat="server" Width="78px" 
                               onchange="cmbMedicareChanged(this)" Height="24px">
                               <asp:ListItem>(Select)</asp:ListItem>
                               <asp:ListItem>no</asp:ListItem>
                               <asp:ListItem>yes</asp:ListItem>
                           </asp:DropDownList>
                       </td>
                   </tr>
               </table>
               <div id="Medicare">
              
               <table id="tableMedicare1">
                   <tr>
                       <td class="style18">
                           
                           <asp:Label ID="Label7" runat="server" Text="Name:"></asp:Label>
                       </td>
                       <td class="style19">
                           
                           <asp:TextBox ID="txtMedicareName" runat="server" Width="307px"></asp:TextBox>
                       </td>
                       <td class="style10">
                           
                           <asp:Label ID="Label8" runat="server" Text="ID#"></asp:Label>
                       </td>
                       <td class="style9">
                           <asp:TextBox ID="txtMedicareID" runat="server" style="margin-left: 0px"></asp:TextBox>
                       </td>
                   </tr>
                   </table>
               <table id="tableMedicare2">
                   <tr>
                       <td class="style42">
                           
                           <asp:Label ID="Label9" runat="server" Text="Effective Date  (Part A)"></asp:Label>
                       </td>
                       <td class="style13">
                           
                           <asp:TextBox ID="txtMedicareA" runat="server" Width="71px"></asp:TextBox>
                       </td>
                       <td class="style31">
                           
                           <asp:Label ID="Label10" runat="server" Text="(Part B)"></asp:Label>
                       </td>
                       <td class="style15">
                           <asp:TextBox ID="txtMedicareB" runat="server" style="margin-right: 10px" 
                               Width="71px"></asp:TextBox>
                       </td>
                       <td class="style41">
                           <asp:Label ID="Label11" runat="server" Text="(Part C)"></asp:Label>
                       </td>
                       <td>
                           <asp:TextBox ID="txtMedicareC" runat="server" Width="71px"></asp:TextBox>
                       </td>
                   </tr>
                   </table>
                    </div>
               <table style="margin-left: 30px; margin-bottom: 4px; margin-top: 4px;">
                   <tr>
                       <td class="style2">
                           <asp:Label ID="Label4" runat="server" 
                               
                               Text="Will you, your spouse or your dependents keep other coverage in addition to this coverage?" 
                               CssClass="tableTitle"></asp:Label>
                       </td>
                       <td>
                           
                           <asp:DropDownList ID="cmbConcurrentCoverage" runat="server" Width="78px" 
                               onchange="cmbConcurrentChanged(this)" Height="24px">
                               <asp:ListItem>(Select)</asp:ListItem>
                               <asp:ListItem>no</asp:ListItem>
                               <asp:ListItem>yes</asp:ListItem>
                           </asp:DropDownList>
                       </td>
                   </tr>
               </table>
               <div id="ConcurrentCoverage">
               <table id="tableConcurrent" style="width: 534px; margin-left: 40px;">
                   <tr>
                       <td class="style22">
                           &nbsp;
                           <asp:Label ID="Label12" runat="server" 
                               Text="Check ALL coverage types that apply"></asp:Label>
                           :</td>
                   </tr>
                   </table>


               <table id="tableConcurrent1" 
                   style="width: 361px; margin-left: 40px; margin-top: 10px; margin-bottom: 10px;">
                   <tr>
                       <td class="style33">
                           &nbsp;
                           <asp:CheckBox ID="ckMedical" runat="server" Text=" Medical" />
                       </td>
                       <td class="style31">
                           <asp:CheckBox ID="ckDental" runat="server" Text=" Dental" />
                       </td>
                       <td class="style34">

                           <asp:CheckBox ID="ckVision" runat="server" Text=" Vision" />
                       </td>
                       <td class="style32">
                           <asp:CheckBox ID="ckLife" runat="server" Text=" Life" />
                       </td>
                       <td class="style15">
                           <asp:CheckBox ID="ckDisability" runat="server" Text=" Disability" />
                       </td>
                   </tr>
                   </table>
               <table style="margin-left: 45px;">
                   <tr>
                       <td>
                           <asp:Label ID="Label13" runat="server" Text="Name of covered person(s)"></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:TextBox ID="txtConcurentName" runat="server" Width="436px"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label ID="Label14" runat="server" 
                               Text="Employer (if applicable)"></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:TextBox ID="txtConcurrentEmployer" runat="server" Width="295px"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label ID="Label15" runat="server" Text="Insurance Company/HMO Name"></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:TextBox ID="txtConcurrentProvider" runat="server" Width="295px"></asp:TextBox>
                       </td>
                   </tr>
               </table>
               <table style="margin-left: 45px; margin-top: 10px; margin-bottom: 10px;">
                   <tr>
                       <td class="style35">
                           <asp:Label ID="Label16" runat="server" Text="Policy Number:"></asp:Label>
                       </td>
                       <td class="style36">
                           <asp:TextBox ID="txtConcurrentPolicy" runat="server" Width="144px"></asp:TextBox>
                       </td>
                       <td class="style37">
                           <asp:Label ID="Label17" runat="server" Text="Effective Date:"></asp:Label>
                       </td>
                       <td class="style38">
                           <asp:TextBox ID="txtConcurrentEff" runat="server" Width="173px"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td class="style35">
                           <asp:Label ID="Label18" runat="server" Text="End Date:"></asp:Label>
                       </td>
                       <td class="style36">
                           <asp:TextBox ID="txtConcurrentEnd" runat="server" Width="144px"></asp:TextBox>
                       </td>
                       <td class="style37">
                           <asp:Label ID="Label19" runat="server" Text="Coverage Type:"></asp:Label>
                       </td>
                       <td class="style38">
                           <asp:DropDownList ID="cmbConcurrentType" runat="server" Height="21px" 
                               Width="175px">
                               <asp:ListItem>(Select)</asp:ListItem>
                               <asp:ListItem>Employee</asp:ListItem>
                               <asp:ListItem>Employee/Child(ren)</asp:ListItem>
                               <asp:ListItem>Employee/Spouse</asp:ListItem>
                               <asp:ListItem>Employee/Spouse/Child(ren)</asp:ListItem>
                           </asp:DropDownList>
                       </td>
                   </tr>
                   <tr>
                       <td class="style35">
                           &nbsp;
                       </td>
                       <td class="style36">
                           (if you currently have coverage in force enter &quot;current&quot;).</td>
                       </td>
                       <td class="style37">
                           &nbsp;
                       </td>
                       <td class="style38">
                           &nbsp;</td>
                   </tr>
               </table>
               </div>
               <table style="margin-left: 30px; margin-top: 4px; margin-bottom: 4px;">
                   <tr>
                       <td class="style4">
                           <asp:Label ID="Label6" runat="server" 
                               Text="Within the last 18 months, did you have health insurance coverage?" 
                               CssClass="tableTitle"></asp:Label>
                       </td>
                       <td class="style3">
                           
                           <asp:DropDownList ID="cmbPreviousCoverage" runat="server" Width="78px" 
                               onchange="cmbPreviousChanged(this)" Height="24px">
                               <asp:ListItem>(Select)</asp:ListItem>
                               <asp:ListItem>no</asp:ListItem>
                               <asp:ListItem>yes</asp:ListItem>
                           </asp:DropDownList>
                       </td>
                   </tr>
                   </table>
                  <div id="PreviousCoverage">
                   <table style="margin-left: 45px;">
                   <tr>
                       <td>
                           <asp:Label ID="Label1" runat="server" Text="Name of covered person(s)"></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:TextBox ID="txtPreviousName" runat="server" Width="436px"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label ID="Label3" runat="server" 
                               Text="Employer (if applicable)"></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:TextBox ID="txtPreviousEmployer" runat="server" Width="295px"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:Label ID="Label5" runat="server" Text="Insurance Company/HMO Name"></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:TextBox ID="txtPreviousProvider" runat="server" Width="295px"></asp:TextBox>
                       </td>
                   </tr>
               </table>

               <table style="margin-left: 45px; margin-top: 10px;">
                   <tr>
                       <td class="style35">
                           &nbsp;
                           <asp:Label ID="Label20" runat="server" Text="Policy Number:"></asp:Label>
                       </td>
                       <td class="style36">
                           &nbsp;
                           <asp:TextBox ID="txtPolicy" runat="server" Width="144px"></asp:TextBox>
                       </td>
                       <td class="style37">
                           &nbsp;
                           <asp:Label ID="Label21" runat="server" Text="Effective Date:"></asp:Label>
                       </td>
                       <td class="style38">
                           <asp:TextBox ID="txtPreviousEff" runat="server" Width="173px"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td class="style35">
                           &nbsp;
                           <asp:Label ID="Label22" runat="server" Text="End Date:"></asp:Label>
                       </td>
                       <td class="style36">
                           &nbsp;
                           <asp:TextBox ID="txtPreviousEnd" runat="server" Width="144px"></asp:TextBox>
                       </td>
                       <td class="style37">
                           &nbsp;
                           <asp:Label ID="Label23" runat="server" Text="Coverage Type:"></asp:Label>
                       </td>
                       <td class="style38">
                           <asp:DropDownList ID="cmbPreviousType" runat="server" Height="21px" 
                               Width="175px">
                               <asp:ListItem>(Select)</asp:ListItem>
                               <asp:ListItem>Employee</asp:ListItem>
                               <asp:ListItem>Employee/Child(ren)</asp:ListItem>
                               <asp:ListItem>Employee/Spouse</asp:ListItem>
                               <asp:ListItem>Employee/Spouse/Child(ren)</asp:ListItem>
                           </asp:DropDownList>
                       </td>
                   </tr>
                   <tr>
                       <td class="style35">
                           &nbsp;
                       </td>
                       <td class="style36">
                           (if you currently have coverage in force enter &quot;current&quot;).</td>
                       <td class="style37">
                           &nbsp;
                       </td>
                       <td class="style38">
                           &nbsp;</td>
                   </tr>
               </table>
               </div>
               <div id ="tableLife">
               <table style="margin-left: 30px; margin-top: 10px; margin-bottom: 4px;">
                   <tr>
                       <td >
                           <asp:Label ID="Label24" runat="server" 
                               Text="Designated Benficiaries - Group Term Life and/or Voluntary Life" 
                               CssClass="tableTitle"></asp:Label>
                           &nbsp;
                           &nbsp;
                       </td>
                       <td class="style41">
                           &nbsp;</td>
                       <td >
                           &nbsp;</td>
                   </tr>
                   </table>

               <table style="margin-left: 45px;">
                   <tr>
                       <td  colspan="3">
                           <asp:Label ID="Label34" runat="server" CssClass="tableTitle" 
                               Text="Primary Beneficiaries"></asp:Label>
                       </td>
                       <td >
                           &nbsp;</td>
                       <td >
                           &nbsp;</td>
                   </tr>
                   <tr>
                       <td >
                           Name</td>
                       <td class="style39">
                           &nbsp;<asp:Label ID="Label25" runat="server" Text="Address"></asp:Label>
                       </td>
                       <td class="style40">
                           <asp:Label ID="Label26" runat="server" Text="Percentage"></asp:Label>
                       </td>
                       <td class="style41">
                           <asp:Label ID="Label27" runat="server" Text="Relationship"></asp:Label>
                       </td>
                       <td >
                           <asp:Label ID="Label28" runat="server" Text="SSN"></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td >
                           <asp:TextBox ID="txtPrimary1Name" runat="server" Width="155px"></asp:TextBox>
                       </td>
                       <td class="style39">
                           <asp:TextBox ID="txtPrimary1Addr" runat="server" Width="174px"></asp:TextBox>
                       </td>
                       <td class="style40">
                           <asp:TextBox ID="txtPrimary1Perc" runat="server" Width="73px"></asp:TextBox>
                       </td>
                       <td class="style41">
                           <asp:TextBox ID="txtPrimary1Relation" runat="server" Width="105px"></asp:TextBox>
                       </td>
                       <td >
                           <asp:TextBox ID="txtPrimary1SSN" runat="server" Width="85px"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td >
                           <asp:TextBox ID="txtPrimary2Name" runat="server" Width="155px"></asp:TextBox>
                       </td>
                       <td class="style39">
                           <asp:TextBox ID="txtPrimary2Addr" runat="server" Width="174px"></asp:TextBox>
                       </td>
                       <td class="style40">
                           <asp:TextBox ID="txtPrimary2Perc" runat="server" Width="73px"></asp:TextBox>
                       </td>
                       <td class="style41">
                           <asp:TextBox ID="txtPrimary2Relation" runat="server" Width="105px"></asp:TextBox>
                       </td>
                       <td >
                           <asp:TextBox ID="txtPrimary2SSN" runat="server" Width="85px"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td >
                           &nbsp;</td>
                       <td class="style39">
                           &nbsp;</td>
                       <td class="style40">
                           &nbsp;</td>
                       <td class="style41">
                           &nbsp;</td>
                       <td >
                           &nbsp;</td>
                   </tr>
                   <tr>
                       <td >
                           <asp:Label ID="Label29" runat="server" CssClass="tableTitle" 
                               Text="Contigent Beneficiaries"></asp:Label>
                       </td>
                       <td class="style39">
                           &nbsp;</td>
                       <td class="style40">
                           &nbsp;</td>
                       <td class="style41">
                           &nbsp;</td>
                       <td >
                           &nbsp;</td>
                   </tr>
                   <tr>
                       <td class="style45">
                           Name</td>
                       <td class="style39">
                           <asp:Label ID="Label30" runat="server" Text="Address"></asp:Label>
                       </td>
                       <td class="style40">
                           <asp:Label ID="Label31" runat="server" Text="Percentage"></asp:Label>
                       </td>
                       <td class="style41">
                           <asp:Label ID="Label32" runat="server" Text="Relationship"></asp:Label>
                       </td>
                       <td class="style44">
                           <asp:Label ID="Label33" runat="server" Text="SSN"></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td class="style45">
                           <asp:TextBox ID="txtSecondary1Name" runat="server" Width="155px"></asp:TextBox>
                       </td>
                       <td class="style39">
                           <asp:TextBox ID="txtSecondary1Addr" runat="server" Width="174px"></asp:TextBox>
                       </td>
                       <td class="style40">
                           <asp:TextBox ID="txtSecondary1Perc" runat="server" Width="73px"></asp:TextBox>
                       </td>
                       <td class="style41">
                           <asp:TextBox ID="txtSecondary1Relation" runat="server" Width="105px"></asp:TextBox>
                       </td>
                       <td class="style44">
                           <asp:TextBox ID="txtSecondary1SSN" runat="server" Width="85px"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td class="style45">
                           <asp:TextBox ID="txtSecondary2Name" runat="server" Width="155px"></asp:TextBox>
                       </td>
                       <td class="style39">
                           <asp:TextBox ID="txtSecondary2Addr" runat="server" Width="174px"></asp:TextBox>
                       </td>
                       <td class="style40">
                           <asp:TextBox ID="txtSecondary2Perc" runat="server" Width="73px"></asp:TextBox>
                       </td>
                       <td class="style41">
                           <asp:TextBox ID="txtSecondary2Relation" runat="server" Width="105px"></asp:TextBox>
                       </td>
                       <td class="style44">
                           <asp:TextBox ID="txtSecondary2SSN" runat="server" Width="85px"></asp:TextBox>
                       </td>
                   </tr>
               </table>
               </div>
                   <asp:Button ID="btnNext" runat="server" Height="30px" 
                   style="margin-right: 40px; margin-top: 22px;" Text="Next" Width="70px" onclick="btnNext_Click" 
                   CssClass="btnLogin" />
               <div class="clearFloat"></div>
           
           </div>
           <div id="FormBottom"></div> 
    </div>  
    </form>
</body>
</html>
