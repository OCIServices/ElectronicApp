<%@ Page Language="C#" AutoEventWireup="true" Theme="FormPage" CodeBehind="BasicInformation.aspx.cs" Inherits="ElectronicApp.NebraskaApp.BasicInformation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <script language="javascript" type="text/javascript" src="Validation/validationHelpers.js"></script>
    <script language="javascript" type="text/javascript" src="Validation/BasicInformation/ValidateBasicInformation.js"></script>
    <title>Basic Information</title>
    <style type="text/css">
        .style4
        {
        }
        .style5
        {
            width: 95px;
            height: 32px;
        }
        .style11
        {
            width: 227px;
            height: 31px;
        }
        .style12
        {
            height: 31px;
        }
        .style13
        {
            height: 31px;
        }
        .style14
        {
            height: 32px;
        }
        .style15
        {
            width: 60px;
            height: 31px;
        }
        .style16
        {
            height: 31px;
            width: 12px;
        }
        .style17
        {
            width: 48px;
            height: 31px;
        }
        .style18
        {
            height: 31px;
            width: 15px;
        }
        .style21
        {
            width: 168px;
            height: 31px;
        }
        .style22
        {
            width: 171px;
            height: 31px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <div id="FormContainer">
        <div id="FormTop"><h1><span class="red">Basic</span> Information</h1></div>
           <div id="FormMid"> 
               <table style="width: 90%; margin-left: 30px; margin-right: 0px;">
                   <tr>
                       <td class="style22">
                           &nbsp;
                           <asp:Label ID="Label1" runat="server" CssClass="labelRight" Text="First Name"></asp:Label>
                       </td>
                       <td class="style11">
                           &nbsp;
                           <asp:TextBox ID="txtFirstName" runat="server" Width="200px"></asp:TextBox>
                       </td>
                       <td class="style12">
                           &nbsp;
                           <asp:Label ID="Label2" runat="server" CssClass="labelRight" Text="Last Name"></asp:Label>
                       </td>
                       <td class="style13">
                           <asp:TextBox ID="txtLastName" runat="server" Width="200px"></asp:TextBox>
                       </td>
                   </tr>
                   </table>
               <table style="width: 67%; margin-left: 30px; margin-right: 0px;">
                   <tr>
                       <td class="style21">
                           &nbsp;
                           <asp:Label ID="Label3" runat="server" CssClass="labelRight" Text="Birth Date (mm/dd/yyyy)"></asp:Label>
                       &nbsp;</td>
                       <td class="style15">
                           &nbsp;
                           <asp:TextBox ID="txtMonth" runat="server" Width="43px" Columns="2" 
                               MaxLength="2"></asp:TextBox>
                           </td>
                       <td class="style16">
                           <asp:Label ID="Label4" runat="server" Text="/"></asp:Label>
                           </td>
                       <td class="style17">
                           <asp:TextBox ID="txtDay" runat="server" Width="43px" Columns="4" MaxLength="4"></asp:TextBox>
                           </td>
                       <td class="style18">
                           &nbsp;
                           <asp:Label ID="Label5" runat="server" Text="/"></asp:Label>
                       </td>
                       <td class="style12">
                           <asp:TextBox ID="txtYear" runat="server" Width="43px"></asp:TextBox>
                       </td>
                   </tr>
                   </table>  
                   <br />
               <p style="margin-left: 17px">You can Choose to decline all coverage offered to you by your employer now by selecting 'Yes' below.  If you choose to decline all coverage, you will not able to participate in your employer&#39;s health plan except in one of the following situations:</p>
               <ul style="margin-left: 79px; margin-top: 11px; margin-bottom: 26px">
                <li>You experience a life change event</li>
                <li>The next open enrollment period</li>
                <li>As a late enrollee (if applicable)</li>
               </ul>
               <table style="width: 90%; margin-left: 40px; margin-right: 0px;">
                   <tr>
                       <td class="style5">
                           &nbsp;
                           <asp:DropDownList ID="cmbWaive" runat="server" onchange="cmbWaiverChange()" Height="21px" Width="78px">
                               <asp:ListItem>(Select)</asp:ListItem>
                               <asp:ListItem>No</asp:ListItem>
                               <asp:ListItem>Yes</asp:ListItem>
                           </asp:DropDownList>
                       </td>
                       <td class="style14">
                            Do you want to <strong>DECLINE ALL COVERAGE</strong> offered to you at this time?
                       </td>
                   </tr>
                   <tr>
                       <td class="style4" colspan="2">
                            <p>&nbsp;</p>
                       </td>
                   </tr>
                   </table>
                   
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

