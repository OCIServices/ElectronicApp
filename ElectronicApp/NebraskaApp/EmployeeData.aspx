<%@ Page Language="C#" Theme="FormPage" AutoEventWireup="true" CodeBehind="EmployeeData.aspx.cs" Inherits="ElectronicApp.NebraskaApp.WebForm1" enableViewState ="false" EnableSessionState="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Step 1 - Employee Information</title>
    <script language="javascript" type="text/javascript" src="Validation/validationHelpers.js"></script>
    <script language="javascript" type="text/javascript" src="Validation/EmployeeDataForm/ValidateForm1.js"></script>
    <script type="text/javascript">
    function clear()
    {
        document.getElementById("Validation").style.display = "none";
    }
    </script>
    <style type="text/css">

    </style>
</head>
<body onload="clear()">
    <form id="form1" runat="server" onkeypress="return event.keyCode!=13">
     <div id="FormContainer">
        <div id="FormTop"><h1><span class="red">Employee</span> Information</h1></div>
           <div id="FormMid"> 
           <div id="Validation">
           <p>Please Correct The Following Errors</p>
                <ul id="ErrorListLeft" class="ErrorsLeft">
                </ul>
                <ul id="ErrorListRight" class="ErrorsRight">
                </ul>
           </div>
           <div class="clearFloat"></div>
            <table style="width: 90%; height: 67px; margin-left: 28px; margin-right: 0px;">
                <tr>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style4">
                        <asp:Label ID="Label1" runat="server" CssClass="labelRight" 
                            Text="Employee Name*"></asp:Label>
                         </td>
                         <td>
                        <asp:TextBox ID="txtEmployeeName" runat="server" Disabled Width="200px" 
                            ValidationGroup="EmployeeDataW"></asp:TextBox>
                         </td>
                         <td>
                         </td>
                    <td class="style3">
                        <asp:Label ID="Label4" runat="server" Text="Gender*" CssClass="labelRight"></asp:Label>
                    </td>
                    <td class="style6">
                        <asp:DropDownList ID="cmbGender" runat="server" Width="200px" Height="22px" 
                            TabIndex="12">
                            <asp:ListItem>(Select)</asp:ListItem>
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style4">&nbsp;</td>
                    <td class="style1">
                        <asp:Label ID="Label2" runat="server" CssClass="labelRight" Text="Home Address*"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtAddress" runat="server" Width="200px" TabIndex="1"></asp:TextBox>
                    </td>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style3">
                        <asp:Label ID="Label5" runat="server" Text="Height* (ex. 5'8&quot;)" 
                            CssClass="labelRight"></asp:Label>
                    </td>
                    <td class="style6">
                        <asp:TextBox ID="txtHeight" runat="server" ValidationGroup="EmployeeData" 
                            Width="200px" TabIndex="12"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style1">
                        <asp:Label ID="Label3" runat="server" CssClass="labelRight" Text="City*"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtCity" runat="server" Width="200px" TabIndex="2"></asp:TextBox>
                    </td>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style3">
                        <asp:Label ID="Label6" runat="server" Text="Weight* (in lbs.)" 
                            CssClass="labelRight"></asp:Label>
                    </td>
                    <td class="style6">
                        <asp:TextBox ID="txtWeight" runat="server" Width="200px" TabIndex="13"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style1">
                        <asp:Label ID="Label9" runat="server" CssClass="labelRight" Text="State*"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtState" runat="server" Width="42px" TabIndex="4"></asp:TextBox>
                    </td>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style3">
                        <asp:Label ID="Label7" runat="server" Text="Marital Status*" CssClass="labelRight"></asp:Label>
                    </td>
                    <td class="style6">
                        <asp:DropDownList ID="cmbMaritalStatus" runat="server" Height="22px" Width="200px" 
                            TabIndex="14">
                            <asp:ListItem>(Select)</asp:ListItem>
                            <asp:ListItem>Single</asp:ListItem>
                            <asp:ListItem>Married</asp:ListItem>
                            <asp:ListItem>Divorced</asp:ListItem>
                            <asp:ListItem>Legally Separated</asp:ListItem>
                            <asp:ListItem>Widowed</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style1">
                        <asp:Label ID="Label10" runat="server" CssClass="labelRight" Text="Zip*"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtZip" runat="server" Width="83px" TabIndex="5"></asp:TextBox>
                    </td>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style3">
                        <asp:Label ID="Label8" runat="server" Text="Number of Children*" 
                            CssClass="labelRight"></asp:Label>
                    </td>
                    <td class="style6">
                        <asp:DropDownList ID="cmbChildren" runat="server" Height="22px" Width="200px" 
                            TabIndex="15">
                            <asp:ListItem>(Select)</asp:ListItem>
                            <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style1">
                        <asp:Label ID="Label11" runat="server" CssClass="labelRight" Text="Work Phone*"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtWorkPhone" runat="server" Width="38px" TabIndex="6" 
                            MaxLength="3"></asp:TextBox>
                        <asp:Label ID="Label25" runat="server" Text="-"></asp:Label>
                        <asp:TextBox ID="txtWorkPhone0" runat="server" Width="38px" TabIndex="6" 
                            MaxLength="3"></asp:TextBox>
                        <asp:Label ID="Label26" runat="server" Text=" - "></asp:Label>
                        <asp:TextBox ID="txtWorkPhone1" runat="server" Width="38px" TabIndex="6" 
                            MaxLength="4"></asp:TextBox>
                    </td>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style3">
                        <asp:Label ID="Label16" runat="server" Text="Primary Care Physician" 
                            CssClass="labelRight"></asp:Label>
                    </td>
                    <td class="style6">
                        <asp:TextBox ID="txtPhysician" runat="server" Width="200px" TabIndex="16"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style1">
                        <asp:Label ID="Label12" runat="server" CssClass="labelRight" Text="Home Phone*"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtHomePhone" runat="server" Width="38px" TabIndex="6" MaxLength="3"></asp:TextBox>
                        <asp:Label ID="Label28" runat="server" Text="-"></asp:Label>
                        <asp:TextBox ID="txtHomePhone0" runat="server" Width="38px" TabIndex="6" MaxLength="3"></asp:TextBox>
                        <asp:Label ID="Label29" runat="server" Text=" - "></asp:Label>
                        <asp:TextBox ID="txtHomePhone1" runat="server" Width="38px" TabIndex="6" MaxLength="4"></asp:TextBox>
                    </td>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style3">
                        <asp:Label ID="Label18" runat="server" Text="Job Title" CssClass="labelRight"></asp:Label>
                    </td>
                    <td class="style6">
                        <asp:TextBox ID="txtTitle" runat="server" Width="200px" TabIndex="17"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style1">
                        <asp:Label ID="Label13" runat="server" CssClass="labelRight" Text="Email"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtEmail" runat="server" Width="200px" TabIndex="8"></asp:TextBox>
                    </td>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style3">
                        <asp:Label ID="Label22" runat="server" Text="Date of Hire*" 
                            CssClass="labelRight"></asp:Label>
                    </td>
                    <td class="style6">
                        <asp:TextBox ID="txtHireDate" runat="server" Width="200px" TabIndex="18"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style1">
                        <asp:Label ID="Label14" runat="server" CssClass="labelRight" 
                            Text="Social Security*"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtSoc" runat="server" Width="38px" TabIndex="9" 
                            EnableViewState="False" maxlength="3"></asp:TextBox>
                        <asp:Label ID="Label30" runat="server" Text="-"></asp:Label>
                        <asp:TextBox ID="txtSoc0" runat="server" Width="29px" TabIndex="9" 
                            EnableViewState="False" maxlength="2"></asp:TextBox>
                        <asp:Label ID="Label31" runat="server" Text="-"></asp:Label>
                        <asp:TextBox ID="txtSoc1" runat="server" Width="38px" TabIndex="9" 
                            EnableViewState="False" maxlength="4"></asp:TextBox>
                    </td>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style3">
                        <asp:Label ID="Label17" runat="server" Text="Employment Status*" 
                            CssClass="labelRight"></asp:Label>
                    </td>
                    <td class="style6">
                        <asp:DropDownList ID="cmbStatus" runat="server" Height="22px" Width="200px" 
                            TabIndex="19">
                            <asp:ListItem>(Select)</asp:ListItem>
                            <asp:ListItem>Full-Time</asp:ListItem>
                            <asp:ListItem>Part-Time</asp:ListItem>
                            <asp:ListItem>Retired</asp:ListItem>
                            <asp:ListItem>COBRA</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style1">
                        <asp:Label ID="Label15" runat="server" CssClass="labelRight" 
                            Text="Date of Birth*"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:TextBox ID="txtDOB" ReadOnly runat="server" Disabled Width="200px" TabIndex="10" 
                            ValidationGroup="EmployeeData"></asp:TextBox>
                    </td>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style3">
                        <asp:Label ID="Label19" runat="server" Text="Hours Per Week" 
                            CssClass="labelRight"></asp:Label>
                    </td>
                    <td class="style6">
                        <asp:TextBox ID="txtHours" runat="server" Width="47px" TabIndex="20"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style1">
                        &nbsp;</td>
                    <td class="style2">
                        &nbsp;</td>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style3">
                        <asp:Label ID="Label20" runat="server" Text="Salary / Wage" 
                            CssClass="labelRight"></asp:Label>
                    </td>
                    <td class="style6">
                        <asp:TextBox ID="txtSalary" runat="server" Width="200px" TabIndex="21"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style1">
                        <asp:Label ID="Label24" runat="server" CssClass="labelRight" 
                            Text="Medicare Enrolled"></asp:Label>
                    </td>
                    <td class="style2">
                        <asp:DropDownList ID="cmbMedicare" runat="server" Height="22px" Width="200px" 
                            TabIndex="11">
                            <asp:ListItem>no</asp:ListItem>
                            <asp:ListItem>yes</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style3">
                        <asp:Label ID="Label23" runat="server" Text="Social Security Disabled" 
                            CssClass="labelRight"></asp:Label>
                    </td>
                    
                    <td class="style3">
                        <asp:DropDownList ID="cmbDisabled" runat="server" Height="22px" Width="200px" 
                            TabIndex="22">
                            <asp:ListItem>no</asp:ListItem>
                            <asp:ListItem>yes</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="style6">
                        &nbsp;</td>
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
