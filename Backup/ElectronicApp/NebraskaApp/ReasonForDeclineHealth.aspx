<%@ Page Language="C#" Theme="FormPage" AutoEventWireup="true" CodeBehind="ReasonForDeclineHealth.aspx.cs" Inherits="ElectronicApp.NebraskaApp.ReasonForDeclineHealth" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <script language="javascript" type="text/javascript" src="Validation/DecliningForm/ValidateDecliningCoverage.js"></script>
    <script language="javascript" type="text/javascript" src="Validation/validationHelpers.js"></script>
    <title>Reason For Declining Coverage</title>
    <style type="text/css">
        .style1
        {
        	font-weight:bold;
            width: 327px;
        }
        .style2
        {
            width: 327px;
        }
        .style3
        {
            width: 120px;
        }
        .style4
        {
        }
        .style5
        {
            width: 64px;
        }
        .style6
        {
            width: 64px;
            height: 24px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
       <div id="FormContainer">
        <div id="FormTop"><h1><span class="red">Reason</span> For Declining Medical Coverage</h1>
            <p>&nbsp;</p></div>
           <div id="FormMid">
               <p>You have choosen to DECLINE coverage for the following:</p>
               <table style="width: 100%; margin-left: 30px; margin-bottom: 32px;">
                   <tr id="foo" runat="server">
                       <td class="style4" colspan="2">
                           &nbsp;</td>
                   </tr>
                   <tr id="trMedical" runat="server">
                       <td class="style6">
                           <asp:Label ID="Label3" runat="server" Text="Medical:" CssClass="lblBold"></asp:Label>
                           </td>
                       <td id="tdMedical" runat="server" class="tdLight">
                           &nbsp;
                           </td>
                   </tr>
                   </table>
              <table style="width:100%; margin-left: 30px; margin-bottom: 24px;">
                   <tr>
                       <td class="style1">
                           <asp:Label ID="Label1" runat="server" 
                               Text="Declining Coverage for the following Reason(s):"></asp:Label>
                       </td>
                       <td class="style3">
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                   </tr>
                   <tr>
                       <td class="style2">
                           <asp:RadioButton ID="ckSpouse" runat="server" Text=" Spouse's Employer Plan" 
                               GroupName="Dental" />
                       </td>
                       <td class="style3">
                           <asp:RadioButton GroupName="Dental" ID="ckIndividualPlan" runat="server" Text=" Individual Plan" />
                       </td>
                       <td>
                           &nbsp;</td>
                   </tr>
                   <tr>
                       <td class="style2">
                           <asp:RadioButton GroupName="Dental" ID="ckMedicare" runat="server" Text=" Covered by Medicare" />
                       </td>
                       <td class="style3">
                           <asp:RadioButton GroupName="Dental" ID="ckVA" runat="server" Text=" VA Eligibility" />
                       </td>
                       <td>
                           &nbsp;</td>
                   </tr>
                   <tr>
                       <td class="style2">
                           <asp:RadioButton GroupName="Dental" ID="ckCobra" runat="server" Text=" COBRA from prior employer" />
                       </td>
                       <td class="style3">
                           <asp:RadioButton GroupName="Dental" ID="ckTriCare" runat="server" Text=" Tri-Care" />
                       </td>
                       <td>
                           &nbsp;</td>
                   </tr>
                   <tr>
                       <td class="style2">
                           <asp:RadioButton GroupName="Dental" ID="ckNoCoverage" runat="server" 
                               Text=" I (we) have no other coverage at this time" />
                       </td>
                       <td class="style3">
                           <asp:RadioButton GroupName="Dental" ID="ckMedicaid" runat="server" Text=" Medicaid" />
                       </td>
                       <td>
                           &nbsp;</td>
                   </tr>
                   <tr>
                       <td class="style2">
                           <asp:RadioButton GroupName="Dental" ID="ckDisability" runat="server" Text="Disability" />
                       </td>
                       <td class="style3">
                           <asp:RadioButton GroupName="Dental" ID="ckOther" runat="server" Text=" Other, explain:" />
                       </td>
                       <td>
                           <asp:TextBox ID="txtExplanation" runat="server" Width="190px"></asp:TextBox>
                       </td>
                   </tr>
               </table>
               <p style="width: 683px">I understand that by waiving coverage at this time, I will not be allowed to participate unless I experience a life change event, at the next open enrollment period or as a late enrollee, if applicable.  I also understand that pre-existing limitations may apply.</p>
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
