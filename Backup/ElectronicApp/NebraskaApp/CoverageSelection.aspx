<%@ Page Language="C#" Theme="FormPage" AutoEventWireup="true" CodeBehind="CoverageSelection.aspx.cs" Inherits="ElectronicApp.NebraskaApp.CoverageSelection" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <script language="javascript" type="text/javascript" src="Validation/CoverageSelectionForm/CoverageSelection.js"></script>
    <script language="javascript" type="text/javascript" src="Validation/CoverageSelectionForm/ValidateCoverage.js"></script>
    <script language="javascript" type="text/javascript" src="Validation/validationHelpers.js"></script>
    <title>Untitled Page</title>
    <style type="text/css">      
        .style2
        {
            width: 211px;
        }
        .style4
        {
            width: 62px;
        }
        .style8
        {
            height: 30px;
            font-weight: bold;
        }
        .style9
        {
            height: 30px;
            font-weight: bold;
            width: 330px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="isMedical" runat="server" />
        <asp:HiddenField ID="isDental" runat="server" />
        <asp:HiddenField ID="isVision" runat="server" />
        <asp:HiddenField ID="isDisability" runat="server" />
        <asp:HiddenField ID="isLife" runat="server" />
        
        <asp:HiddenField ID="isWaiveAll" runat="server" Value="isWaiveAll" />
        
        <asp:HiddenField ID="isSingle" runat="server" />
        <asp:HiddenField ID="isChildren" runat="server" />
        
       <div id="FormContainer">
        <div id="FormTop"><h1><span class="red">Coverage</span> Selection</h1></div>
           <div id="FormMid"> 
              <div id="Coverage">
               <table  id="coverageSelection">
                   <tr>
                       <td class="style8" colspan="2">
                           <asp:Label ID="Label7" runat="server" Text="Indicate Coverage Choice:"></asp:Label>
                       </td>
                       <td class="style9">
                           &nbsp;</td>
                   </tr>
                   <tr id="trMedical" runat="server">
                       <td class="style4" >
                           <asp:Label ID="Label2" runat="server" Text="Medical"></asp:Label>
                       </td>
                       <td class="style2" >
                           <asp:DropDownList ID="cmbMedical" runat="server" Height="21px" Width="200px" 
                               OnChange="MedicalChanged(this)">
                               <asp:ListItem>(Select)</asp:ListItem>
                           </asp:DropDownList>
                       </td>
                       <td class="waiverNotice"  runat="server" id="tdMedicalWaiver">
                           &nbsp;</td>
                   </tr>
                   <tr id="trDental" runat="server">
                       <td class="style4">
                           <asp:Label ID="Label3" runat="server" Text="Dental"></asp:Label>
                       </td>
                       <td class="style2">
                           <asp:DropDownList ID="cmbDental" runat="server" Height="21px" Width="200px"  
                               OnChange="DentalChanged(this)">
                               <asp:ListItem>(Select)</asp:ListItem>
                           </asp:DropDownList>
                       </td>
                       <td class="waiverNotice" id="tdDentalWaiver" runat="server">
                           &nbsp;</td>
                   </tr>
                   <tr id="trVision" runat="server">
                       <td class="style4">
                           <asp:Label ID="Label4" runat="server" Text="Vision"></asp:Label>
                       </td>
                       <td class="style2">
                           <asp:DropDownList ID="cmbVision" runat="server" Height="21px" Width="200px" 
                               onChange="VisionChanged(this)">
                                <asp:ListItem>(Select)</asp:ListItem>
                           </asp:DropDownList>
                       </td>
                       <td class="waiverNotice" id="tdVisionWaiver" runat="server">
                           &nbsp;</td>
                   </tr>
                   <tr id="trDisability" runat="server">
                       <td class="style4">
                           <asp:Label ID="Label8" runat="server" Text="Disability"></asp:Label>
                       </td>
                       <td class="style2">
                           <asp:DropDownList ID="cmbDisability" runat="server" Height="20px" Width="200px" 
                               onChange="DisabilityChanged(this)">
                               <asp:ListItem>(Select)</asp:ListItem>
                           </asp:DropDownList>
                       </td>
                       <td class="waiverNotice" id="tdDisabilityWaiver" runat="server">
                           &nbsp;</td>
                   </tr>
                   <tr id="trLife" runat="server">
                       <td class="style4">
                           <asp:Label ID="Label6" runat="server" Text="Life"></asp:Label>
                       </td>
                       <td class="style2">
                           <asp:DropDownList ID="cmbLife" runat="server" Height="21px" Width="200px" 
                               onChange="LifeChanged(this)">
                                <asp:ListItem>(Select)</asp:ListItem>
                           </asp:DropDownList>
                       </td>
                       <td class="waiverNotice" id="tdLifeWaiver" runat="server">
                           &nbsp;</td>
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
