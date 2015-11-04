<%@ Page Language="C#" Theme="FormPage" AutoEventWireup="true" CodeBehind="Wizard.aspx.cs" Inherits="ElectronicApp.NebraskaApp.Wizard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolKit" %>
<%@ Reference Control="~/SignatureControl/ctlSignature.ascx" %>
<%@ Register TagPrefix="uc" TagName="Signature"  Src="~/SignatureControl/ctlSignature.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>e-Enroll :: Basic Information</title>
    <style type="text/css">
    #UserWizard1  {margin-left: 31px; margin-right: 0px; width: 90%;}
    
    .buttons    { height:30px; margin-right:40px; margin-top:22px; width:70px; }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
    <%--<asp:ScriptManager runat="server"></asp:ScriptManager>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>--%>
        <div id="FormContainer">
        
                
                <div id="FormTop"><h1 id="header" runat="server"><span class="red">Basic</span> Information</h1></div>
           <div id="FormMid">
                        <asp:Wizard id="UserWizard1" 
                            OnActiveStepChanged="UserWizard1_ActiveStepChanged" runat="server"
                            DisplaySideBar="false" FinishDestinationPageUrl="~/NebraskaApp/thankyou.aspx"
                            OnNextButtonClick="UserWizard1_NextButtonClick" OnPreviousButtonClick="UserWizard1_PreviousButtonClick"
                            onfinishbuttonclick="UserWizard1_FinishButtonClick" FinishCompleteButtonStyle-CssClass="buttons"
                            StartNextButtonStyle-CssClass="buttons" StepNextButtonStyle-CssClass="buttons"
                            StepPreviousButtonStyle-CssClass="buttons" ActiveStepIndex="0">
        <StartNextButtonStyle CssClass="buttons"></StartNextButtonStyle>

        <FinishCompleteButtonStyle CssClass="buttons"></FinishCompleteButtonStyle>

        <StepNextButtonStyle CssClass="buttons"></StepNextButtonStyle>
                            <wizardsteps>
                            
                                <%-- TODO: Fix table control so a redirect to the HealthExplanations.aspx page is not required when
                                            somebody with a medical condition applies. --%>
                            
                            
                                <asp:WizardStep AllowReturn="false" StepType="Start" title="Basic Information" runat="server">
                                <!--Start Basic Info-->
                                    <script language="javascript" type="text/javascript" src="Validation/validationHelpers.js"></script>
                                    <script language="javascript" type="text/javascript" src="Validation/BasicInformation/ValidateBasicInformation.js"></script>
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
                                            width: 161px;
                                            height: 31px;
                                        }
                                    </style>

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
	                                            <asp:Label ID="Label3" runat="server" CssClass="labelRight" Text="Birth Date (mm/dd/yyyy)"></asp:Label>
                                            </td>
                                            <td class="style15">
	                                            <asp:TextBox ID="txtMonth" runat="server" Width="43px" Columns="2" MaxLength="2"></asp:TextBox>
	                                            </td>
                                            <td class="style16">
	                                            <asp:Label ID="Label4" runat="server" Text="/"></asp:Label>
	                                            </td>
                                            <td class="style17">
	                                            <asp:TextBox ID="txtDay" runat="server" Width="43px" Columns="2" MaxLength="2"></asp:TextBox>
	                                            </td>
                                            <td class="style18">
	                                            <asp:Label ID="Label5" runat="server" Text="/"></asp:Label>
                                            </td>
                                            <td class="style12">
	                                            <asp:TextBox ID="txtYear" runat="server" Width="43px" Columns="4" MaxLength="4"></asp:TextBox>
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
                                <!--End Basic Info-->
                                </asp:WizardStep>
                                
                                <asp:WizardStep title="Employee Data" runat="server">
                                    <!-- Start Employee Data Form -->
                                    <script language="javascript" type="text/javascript" src="Validation/validationHelpers.js"></script>

                                    <script language="javascript" type="text/javascript" src="Validation/EmployeeDataForm/ValidateForm1.js"></script>

                                    <script type="text/javascript">
	                                    function clear()
	                                    {
		                                    document.getElementById("Validation").style.display = "none";
	                                    }
                                    </script>

                                    <div id="Validation">
	                                    <p>Please Correct The Following Errors</p>
                                    	
	                                    <ul id="ErrorListLeft" class="ErrorsLeft"></ul>
                                    	
	                                    <ul id="ErrorListRight" class="ErrorsRight"></ul>
                                    </div>

                                    <div class="clearFloat"></div>

                                    <table style="width: 100%; height: 67px; margin-left: 0px; margin-right: 0px; border-collapse: separate;">
	                                    <tr>
		                                    <td class="style4">
			                                    &nbsp;
		                                    </td>
                                    		
		                                    <td class="style4">
			                                    <asp:Label ID="Label6" runat="server" CssClass="labelRight" Text="Employee Name*"></asp:Label>
		                                    </td>
                                    		
		                                    <td>
			                                    <asp:TextBox ID="txtEmployeeName" runat="server" Disabled Width="200px" ValidationGroup="EmployeeDataW"></asp:TextBox>
		                                    </td>
                                    		
		                                    <td></td>
                                    		
		                                    <td class="style3">
			                                    <asp:Label ID="Label7" runat="server" Text="Gender*" CssClass="labelRight"></asp:Label>
		                                    </td>
                                    		
		                                    <td class="style6">
			                                    <asp:DropDownList ID="cmbGender" runat="server" Width="200px" Height="22px" TabIndex="12">
				                                    <asp:ListItem>(Select)</asp:ListItem>
				                                    <asp:ListItem>Male</asp:ListItem>
				                                    <asp:ListItem>Female</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
                                    		
		                                    <td>
			                                    &nbsp;
		                                    </td>
	                                    </tr>
                                    	
	                                    <tr>
		                                    <td class="style4">
			                                    &nbsp;
		                                    </td>
                                    		
		                                    <td class="style1">
			                                    <asp:Label ID="Label8" runat="server" CssClass="labelRight" Text="Home Address*"></asp:Label>
		                                    </td>
                                    		
		                                    <td class="style2">
			                                    <asp:TextBox ID="txtAddress" runat="server" Width="200px" TabIndex="1"></asp:TextBox>
		                                    </td>
                                    		
		                                    <td class="style4">
			                                    &nbsp;
		                                    </td>
                                    			
		                                    <td class="style3">
			                                    <asp:Label ID="Label9" runat="server" Text="Height* (ex. 5'8&quot;)" CssClass="labelRight"></asp:Label>
		                                    </td>
                                    		
		                                    <td class="style6">
			                                    <asp:TextBox ID="txtHeight" runat="server" ValidationGroup="EmployeeData" Width="200px" TabIndex="12"></asp:TextBox>
		                                    </td>
                                    		
		                                    <td>
			                                    &nbsp;
		                                    </td>
	                                    </tr>
                                    	
	                                    <tr>
		                                    <td class="style4">
			                                    &nbsp;
		                                    </td>
                                    		
		                                    <td class="style1">
			                                    <asp:Label ID="Label10" runat="server" CssClass="labelRight" Text="City*"></asp:Label>
		                                    </td>
                                    		
		                                    <td class="style2">
			                                    <asp:TextBox ID="txtCity" runat="server" Width="200px" TabIndex="2"></asp:TextBox>
		                                    </td>
                                    		
		                                    <td class="style4">
			                                    &nbsp;
		                                    </td>
                                    			
		                                    <td class="style3">
			                                    <asp:Label ID="Label11" runat="server" Text="Weight* (in lbs.)" CssClass="labelRight"></asp:Label>
		                                    </td>
                                    		
		                                    <td class="style6">
			                                    <asp:TextBox ID="txtWeight" runat="server" Width="200px" TabIndex="13"></asp:TextBox>
		                                    </td>
                                    		
		                                    <td>
			                                    &nbsp;
		                                    </td>
	                                    </tr>
                                    	
	                                    <tr>
		                                    <td class="style4">
			                                    &nbsp;
		                                    </td>
                                    		
		                                    <td class="style1">
			                                    <asp:Label ID="Label12" runat="server" CssClass="labelRight" Text="State*"></asp:Label>
		                                    </td>
                                    		
		                                    <td class="style2">
			                                    <asp:TextBox ID="txtState" runat="server" Width="42px" TabIndex="4"></asp:TextBox>
		                                    </td>
                                    		
		                                    <td class="style4">
			                                    &nbsp;
		                                    </td>
                                    		
		                                    <td class="style3">
			                                    <asp:Label ID="Label13" runat="server" Text="Marital Status*" CssClass="labelRight"></asp:Label>
		                                    </td>
                                    		
		                                    <td class="style6">
			                                    <asp:DropDownList ID="cmbMaritalStatus" runat="server" Height="22px" Width="200px" TabIndex="14">
				                                    <asp:ListItem>(Select)</asp:ListItem>
				                                    <asp:ListItem>Single</asp:ListItem>
				                                    <asp:ListItem>Married</asp:ListItem>
				                                    <asp:ListItem>Divorced</asp:ListItem>
				                                    <asp:ListItem>Legally Separated</asp:ListItem>
				                                    <asp:ListItem>Widowed</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
                                    		
		                                    <td>
			                                    &nbsp;
		                                    </td>
	                                    </tr>
                                    	
	                                    <tr>
		                                    <td class="style4">
			                                    &nbsp;
		                                    </td>
                                    			
		                                    <td class="style1">
			                                    <asp:Label ID="Label14" runat="server" CssClass="labelRight" Text="Zip*"></asp:Label>
		                                    </td>
                                    		
		                                    <td class="style2">
			                                    <asp:TextBox ID="txtZip" runat="server" Width="83px" TabIndex="5"></asp:TextBox>
		                                    </td>
                                    		
		                                    <td class="style4">
			                                    &nbsp;
		                                    </td>
                                    		
		                                    <td class="style3">
			                                    <asp:Label ID="Label15" runat="server" Text="Number of Children*" CssClass="labelRight"></asp:Label>
		                                    </td>
                                    		
		                                    <td class="style6">
			                                    <asp:DropDownList ID="cmbChildren" runat="server" Height="22px" Width="200px" TabIndex="15">
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
			                                    &nbsp;
		                                    </td>
	                                    </tr>
                                    	
	                                    <tr>
		                                    <td class="style4">
			                                    &nbsp;
		                                    </td>
                                    			
		                                    <td class="style1">
			                                    <asp:Label ID="Label16" runat="server" CssClass="labelRight" Text="Work Phone*"></asp:Label>
		                                    </td>
                                    		
		                                    <td class="style2">
			                                    <asp:TextBox ID="txtWorkPhone" runat="server" Width="38px" TabIndex="6" MaxLength="3"></asp:TextBox>
			                                    <asp:Label ID="Label25" runat="server" Text="-"></asp:Label>
			                                    <asp:TextBox ID="txtWorkPhone0" runat="server" Width="38px" TabIndex="6" MaxLength="3"></asp:TextBox>
			                                    <asp:Label ID="Label26" runat="server" Text=" - "></asp:Label>
			                                    <asp:TextBox ID="txtWorkPhone1" runat="server" Width="38px" TabIndex="6" MaxLength="4"></asp:TextBox>
		                                    </td>
                                    		
		                                    <td class="style4">
			                                    &nbsp;
		                                    </td>
                                    			
		                                    <td class="style3">
			                                    <asp:Label ID="Label17" runat="server" Text="Primary Care Physician" CssClass="labelRight"></asp:Label>
		                                    </td>
                                    		
		                                    <td class="style6">
			                                    <asp:TextBox ID="txtPhysician" runat="server" Width="200px" TabIndex="16"></asp:TextBox>
		                                    </td>
                                    		
		                                    <td>
			                                    &nbsp;
		                                    </td>
	                                    </tr>
                                    	
	                                    <tr>
		                                    <td class="style4">
			                                    &nbsp;
		                                    </td>
                                    			
		                                    <td class="style1">
			                                    <asp:Label ID="Label18" runat="server" CssClass="labelRight" Text="Home Phone*"></asp:Label>
		                                    </td>
                                    		
		                                    <td class="style2">
			                                    <asp:TextBox ID="txtHomePhone" runat="server" Width="38px" TabIndex="6" MaxLength="3"></asp:TextBox>
			                                    <asp:Label ID="Label28" runat="server" Text="-"></asp:Label>
			                                    <asp:TextBox ID="txtHomePhone0" runat="server" Width="38px" TabIndex="6" MaxLength="3"></asp:TextBox>
			                                    <asp:Label ID="Label29" runat="server" Text=" - "></asp:Label>
			                                    <asp:TextBox ID="txtHomePhone1" runat="server" Width="38px" TabIndex="6" MaxLength="4"></asp:TextBox>
		                                    </td>
                                    		
		                                    <td class="style4">
			                                    &nbsp;
		                                    </td>
                                    		
		                                    <td class="style3">
			                                    <asp:Label ID="Label19" runat="server" Text="Job Title" CssClass="labelRight"></asp:Label>
		                                    </td>
                                    		
		                                    <td class="style6">
			                                    <asp:TextBox ID="txtTitle" runat="server" Width="200px" TabIndex="17"></asp:TextBox>
		                                    </td>
                                    		
		                                    <td>
			                                    &nbsp;
		                                    </td>
	                                    </tr>
                                    	
	                                    <tr>
		                                    <td class="style4">
			                                    &nbsp;
		                                    </td>
                                    			
		                                    <td class="style1">
			                                    <asp:Label ID="Label20" runat="server" CssClass="labelRight" Text="Email"></asp:Label>
		                                    </td>
                                    		
		                                    <td class="style2">
			                                    <asp:TextBox ID="txtEmail" runat="server" Width="200px" TabIndex="8"></asp:TextBox>
		                                    </td>
                                    		
		                                    <td class="style4">
			                                    &nbsp;
		                                    </td>
                                    			
		                                    <td class="style3">
			                                    <asp:Label ID="Label22" runat="server" Text="Date of Hire*" CssClass="labelRight"></asp:Label>
		                                    </td>
                                    		
		                                    <td class="style6">
			                                    <asp:TextBox ID="txtHireDate" runat="server" Width="200px" TabIndex="18"></asp:TextBox>
		                                    </td>
                                    		
		                                    <td>
			                                    &nbsp;
		                                    </td>
	                                    </tr>
                                    	
	                                    <tr>
		                                    <td class="style4">
			                                    &nbsp;
		                                    </td>
                                    			
		                                    <td class="style1">
			                                    <asp:Label ID="Label21" runat="server" CssClass="labelRight" Text="Social Security*"></asp:Label>
		                                    </td>
                                    		
		                                    <td class="style2">
			                                    <asp:TextBox ID="txtSoc" runat="server" Width="38px" TabIndex="9" EnableViewState="False" maxlength="3"></asp:TextBox>
			                                    <asp:Label ID="Label30" runat="server" Text="-"></asp:Label>
			                                    <asp:TextBox ID="txtSoc0" runat="server" Width="29px" TabIndex="9" EnableViewState="False" maxlength="2"></asp:TextBox>
			                                    <asp:Label ID="Label31" runat="server" Text="-"></asp:Label>
			                                    <asp:TextBox ID="txtSoc1" runat="server" Width="38px" TabIndex="9" EnableViewState="False" maxlength="4"></asp:TextBox>
		                                    </td>
                                    		
		                                    <td class="style4">
			                                    &nbsp;
		                                    </td>
                                    		
		                                    <td class="style3">
			                                    <asp:Label ID="Label222" runat="server" Text="Employment Status*" CssClass="labelRight"></asp:Label>
		                                    </td>
                                    		
		                                    <td class="style6">
			                                    <asp:DropDownList ID="cmbStatus" runat="server" Height="22px" Width="200px" TabIndex="19">
				                                    <asp:ListItem>(Select)</asp:ListItem>
				                                    <asp:ListItem>Full-Time</asp:ListItem>
				                                    <asp:ListItem>Part-Time</asp:ListItem>
				                                    <asp:ListItem>Retired</asp:ListItem>
				                                    <asp:ListItem>COBRA</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
                                    		
		                                    <td>
			                                    &nbsp;
		                                    </td>
	                                    </tr>
                                    	
	                                    <tr>
		                                    <td class="style4">
			                                    &nbsp;
		                                    </td>
                                    		
		                                    <td class="style1">
			                                    <asp:Label ID="Label23" runat="server" CssClass="labelRight" Text="Date of Birth*"></asp:Label>
		                                    </td>
                                    		
		                                    <td class="style2">
			                                    <asp:TextBox ID="txtDOB" ReadOnly runat="server" Disabled Width="200px" TabIndex="10" ValidationGroup="EmployeeData"></asp:TextBox>
		                                    </td>
                                    		
		                                    <td class="style4">
			                                    &nbsp;
		                                    </td>

		                                    <td class="style3">
			                                    <asp:Label ID="Label24" runat="server" Text="Hours Per Week" CssClass="labelRight"></asp:Label>
		                                    </td>
                                    		
		                                    <td class="style6">
			                                    <asp:TextBox ID="txtHours" runat="server" Width="47px" TabIndex="20"></asp:TextBox>
		                                    </td>
                                    		
		                                    <td>
			                                    &nbsp;
		                                    </td>
	                                    </tr>
                                    	
	                                    <tr>
		                                    <td class="style4">
			                                    &nbsp;
		                                    </td>
                                    			
		                                    <td class="style1">
			                                    &nbsp;
		                                    </td>
                                    		
		                                    <td class="style2">
			                                    &nbsp;
		                                    </td>
                                    			
		                                    <td class="style4">
			                                    &nbsp;
		                                    </td>
                                    			
		                                    <td class="style3">
			                                    <asp:Label ID="Label225" runat="server" Text="Salary / Wage" CssClass="labelRight"></asp:Label>
		                                    </td>
                                    		
		                                    <td class="style6">
			                                    <asp:TextBox ID="txtSalary" runat="server" Width="200px" TabIndex="21"></asp:TextBox>
		                                    </td>
                                    		
		                                    <td>
			                                    &nbsp;
		                                    </td>
	                                    </tr>
                                    	
	                                    <tr>
		                                    <td class="style4">
			                                    &nbsp;
		                                    </td>
                                    		
		                                    <td class="style1">
			                                    <asp:Label ID="Label226" runat="server" CssClass="labelRight" Text="Medicare Enrolled"></asp:Label>
		                                    </td>
                                    		
		                                    <td class="style2">
			                                    <asp:DropDownList ID="cmbMedicare" runat="server" Height="22px" Width="200px" TabIndex="11">
				                                    <asp:ListItem>no</asp:ListItem>
				                                    <asp:ListItem>yes</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
                                    		
		                                    <td class="style4">
			                                    &nbsp;
		                                    </td>
                                    		
		                                    <td class="style3">
			                                    <asp:Label ID="Label27" runat="server" Text="Social Security Disabled" CssClass="labelRight"></asp:Label>
		                                    </td>
                                    		
		                                    <td class="style3">
			                                    <asp:DropDownList ID="cmbDisabled" runat="server" Height="22px" Width="200px" TabIndex="22">
				                                    <asp:ListItem>no</asp:ListItem>
				                                    <asp:ListItem>yes</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
                                    		
		                                    <td class="style6">
			                                    &nbsp;
		                                    </td>
	                                    </tr>
                                    </table>

                                    <!-- End Employee Data Form -->
                                </asp:WizardStep>
                                
                                <asp:WizardStep title="Coverage Selection" runat="server">
                                <!-- Start Coverage Selection -->
                                
                                    <script language="javascript" type="text/javascript" src="Validation/CoverageSelectionForm/CoverageSelection.js"></script>
                                    <script language="javascript" type="text/javascript" src="Validation/CoverageSelectionForm/ValidateCoverage.js"></script>
                                    <script language="javascript" type="text/javascript" src="Validation/validationHelpers.js"></script>

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


                                    <asp:HiddenField ID="isMedical" runat="server" />
                                    <asp:HiddenField ID="isDental" runat="server" />
                                    <asp:HiddenField ID="isVision" runat="server" />
                                    <asp:HiddenField ID="isDisability" runat="server" />
                                    <asp:HiddenField ID="isLife" runat="server" />
                                    <asp:HiddenField ID="isWaiveAll" runat="server" Value="isWaiveAll" />
                                    <asp:HiddenField ID="isSingle" runat="server" />
                                    <asp:HiddenField ID="isChildren" runat="server" />

                                    <table  id="coverageSelection">
	                                    <tr>
		                                    <td class="style8" colspan="2">
			                                    <asp:Label ID="Label32" runat="server" Text="Indicate Coverage Choice:"></asp:Label>
		                                    </td>
                                    		
		                                    <td class="style9">
			                                    &nbsp;
		                                    </td>
	                                    </tr>
                                    	
	                                    <tr id="trMedical" runat="server">
		                                    <td class="style4" >
			                                    <asp:Label ID="Label33" runat="server" Text="Medical"></asp:Label>
		                                    </td>
                                    		
		                                    <td class="style2" >
			                                    <asp:DropDownList ID="cmbMedical" runat="server" Height="21px" Width="200px" OnChange="MedicalChanged(this)">
				                                    <asp:ListItem>(Select)</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
                                    		
		                                    <td class="waiverNotice"  runat="server" id="tdMedicalWaiver">
			                                    &nbsp;
		                                    </td>
	                                    </tr>
                                    	
	                                    <tr id="trDental" runat="server">
		                                    <td class="style4">
			                                    <asp:Label ID="Label34" runat="server" Text="Dental"></asp:Label>
		                                    </td>
                                    		
		                                    <td class="style2">
			                                    <asp:DropDownList ID="cmbDental" runat="server" Height="21px" Width="200px" OnChange="DentalChanged(this)">
				                                    <asp:ListItem>(Select)</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
                                    		
		                                    <td class="waiverNotice" id="tdDentalWaiver" runat="server">
			                                    &nbsp;
		                                    </td>
	                                    </tr>
                                    	
	                                    <tr id="trVision" runat="server">
		                                    <td class="style4">
			                                    <asp:Label ID="Label35" runat="server" Text="Vision"></asp:Label>
		                                    </td>
                                    		
		                                    <td class="style2">
			                                    <asp:DropDownList ID="cmbVision" runat="server" Height="21px" Width="200px" onChange="VisionChanged(this)">
				                                    <asp:ListItem>(Select)</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
                                    		
		                                    <td class="waiverNotice" id="tdVisionWaiver" runat="server">
			                                    &nbsp;
		                                    </td>
	                                    </tr>
                                    	
	                                    <tr id="trDisability" runat="server">
		                                    <td class="style4">
			                                    <asp:Label ID="Label36" runat="server" Text="Disability"></asp:Label>
		                                    </td>
                                    		
		                                    <td class="style2">
			                                    <asp:DropDownList ID="cmbDisability" runat="server" Height="20px" Width="200px" onChange="DisabilityChanged(this)">
				                                    <asp:ListItem>(Select)</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
                                    		
		                                    <td class="waiverNotice" id="tdDisabilityWaiver" runat="server">
			                                    &nbsp;
		                                    </td>
	                                    </tr>
                                    	
	                                    <tr id="trLife" runat="server">
		                                    <td class="style4">
			                                    <asp:Label ID="Label37" runat="server" Text="Life"></asp:Label>
		                                    </td>
                                    		
		                                    <td class="style2">
			                                    <asp:DropDownList ID="cmbLife" runat="server" Height="21px" Width="200px" onChange="LifeChanged(this)">
				                                    <asp:ListItem>(Select)</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
                                    		
		                                    <td class="waiverNotice" id="tdLifeWaiver" runat="server">
			                                    &nbsp;
		                                    </td>
	                                    </tr>
                                    </table>
                                    
                                <!-- End Coverage Selection -->
                                </asp:WizardStep>
                                
                                <asp:WizardStep title="Dependent Data" runat="server">
                                <!--Start Dependent Data-->
                                    <script language="javascript" type="text/javascript" src="Validation/validationHelpers.js"></script>
                                    <script language="javascript" type="text/javascript" src="Validation/DependentData/ValidateDependentData.js"></script>
                                    <style type="text/css">
	                                    .style75
	                                    {
		                                    width: 108px;
	                                    }
	                                    .style82
	                                    {
		                                    width: 37px;
	                                    }
	                                    .style85
	                                    {
		                                    width: 61px;
	                                    }
	                                    .style87
	                                    {
		                                    width: 15px;
	                                    }
	                                    .style88
	                                    {
		                                    width: 33px;
	                                    }
	                                    .style89
	                                    {
		                                    width: 14px;
	                                    }
	                                    .style90
	                                    {
		                                    width: 36px;
	                                    }
	                                    .style91
	                                    {
		                                    width: 98px;
	                                    }
	                                    .style92
	                                    {
		                                    width: 7px;
	                                    }
	                                    .style93
	                                    {
		                                    width: 57px;
	                                    }
	                                    .style94
	                                    {
		                                    width: 108px;
		                                    font-weight: bold;
	                                    }
	                                    .style95
	                                    {
		                                    width: 108px;
		                                    font-weight: bold;
		                                    height: 24px;
	                                    }
	                                    .style96
	                                    {
		                                    width: 33px;
		                                    height: 24px;
	                                    }
	                                    .style97
	                                    {
		                                    width: 14px;
		                                    height: 24px;
	                                    }
	                                    .style98
	                                    {
		                                    width: 15px;
		                                    height: 24px;
	                                    }
	                                    .style99
	                                    {
		                                    width: 37px;
		                                    height: 24px;
	                                    }
	                                    .style100
	                                    {
		                                    width: 36px;
		                                    height: 24px;
	                                    }
	                                    .style101
	                                    {
		                                    width: 98px;
		                                    height: 24px;
	                                    }
	                                    .style102
	                                    {
		                                    width: 57px;
		                                    height: 24px;
	                                    }
	                                    .style103
	                                    {
		                                    width: 61px;
		                                    height: 24px;
	                                    }
	                                    .style104
	                                    {
		                                    width: 7px;
		                                    height: 24px;
	                                    }
                                    </style>
                                    <asp:HiddenField ID="isSpouse" runat="server" />    
                                    <asp:HiddenField ID="numChildren" runat="server" />                       
                                    <table id ="dependents" style="margin-left: 20px">
                                       <tr>
	                                       <td class="style75">
		                                       <asp:Label ID="Label38" runat="server" CssClass="tableTitle" 
			                                       Text="Name (First, MI, Last)"></asp:Label>
	                                       </td>
	                                       <td class="style88">
		                                       <asp:Label ID="Label39" runat="server" CssClass="tableTitle" Text="Gender"></asp:Label>
	                                       </td>
	                                       <td class="style89">
		                                       <asp:Label ID="Label40" runat="server" CssClass="tableTitle" Text="Height"></asp:Label>
	                                       </td>
	                                       <td class="style87">
		                                       <asp:Label ID="Label41" runat="server" CssClass="tableTitle" Text="Weight"></asp:Label>
	                                       </td>
	                                       <td class="style82">
		                                       <asp:Label ID="Label42" runat="server" CssClass="tableTitle" Text="DOB"></asp:Label>
	                                       </td>
	                                       <td class="style90">
		                                       <asp:Label ID="Label43" runat="server" CssClass="tableTitle" Text="SS#"></asp:Label>
	                                       </td>
	                                       <td class="style91">
		                                       <asp:Label ID="Label44" runat="server" CssClass="tableTitle" 
			                                       Text="Primary Physician"></asp:Label>
	                                       </td>
	                                       <td class="style93">
		                                       <asp:Label ID="Label45" runat="server" CssClass="tableTitle" 
			                                       Text="Full-Time Student"></asp:Label>
	                                       </td>
	                                       <td class="style85">
		                                       <asp:Label ID="Label46" runat="server" CssClass="tableTitle" 
			                                       Text="Medicare Enrolled"></asp:Label>
	                                       </td>
	                                       <td class="style92">
		                                       <asp:Label ID="Label47" runat="server" CssClass="tableTitle" Text="SS Enrolled"></asp:Label>
	                                       </td>
	                                    </tr>
                                       <tr id="trSpouseTitle" runat="server">
	                                       <td class="style94">
		                                       Spouse</td>
	                                       <td class="style88">
		                                       &nbsp;</td>
	                                       <td class="style89">
		                                       &nbsp;</td>
	                                       <td class="style87">
		                                       &nbsp;</td>
	                                       <td class="style82">
		                                       &nbsp;</td>
	                                       <td class="style90">
		                                       &nbsp;</td>
	                                       <td class="style91">
		                                       &nbsp;</td>
	                                       <td class="style93">
		                                       &nbsp;</td>
	                                       <td class="style85">
		                                       &nbsp;</td>
	                                       <td class="style92">
		                                       &nbsp;</td>
	                                    </tr>
	                                    <tr id="trSpouse" runat="server">
		                                    <td class="style75">
			                                    <asp:TextBox ID="spName" runat="server"  Height="17px" 
				                                    style="margin-right: 5px" Width="125px"></asp:TextBox>
		                                    </td>
		                                    <td class="style88">
			                                    <asp:DropDownList ID="spGender" runat="server"
				                                    Height="21px" Width="70px" size="1" style="margin-right: 5px">
				                                    <asp:ListItem>(Select)</asp:ListItem>
				                                    <asp:ListItem>male</asp:ListItem>
				                                    <asp:ListItem>female</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
		                                    <td class="style89">
			                                    <asp:TextBox ID="spHeight" runat="server"  Height="17px" 
				                                    Width="35px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style87">
			                                    <asp:TextBox ID="spWeight" runat="server"  Height="17px" 
				                                    Width="35px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style82">
			                                    <asp:TextBox ID="spDOB" runat="server"  Height="17px" 
				                                    Width="65px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style90">
			                                    <asp:TextBox ID="spSSN" runat="server" Height="17px" 
				                                    Width="75px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style91">
			                                    <asp:TextBox ID="spPhysician" runat="server"  Height="17px" 
				                                    Width="90px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style93">
			                                    <asp:DropDownList ID="spStudent" runat="server" 
				                                    Height="21px" Width="50px" style="margin-right: 5px">
				                                    <asp:ListItem></asp:ListItem>
				                                    <asp:ListItem>no</asp:ListItem>
				                                    <asp:ListItem>yes</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
		                                    <td class="style85">
			                                    <asp:DropDownList ID="spMedicare" runat="server" 
				                                    Height="21px" Width="50px" style="margin-right: 5px">
				                                    <asp:ListItem></asp:ListItem>
				                                    <asp:ListItem>no</asp:ListItem>
				                                    <asp:ListItem>yes</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
		                                    <td class="style92">
			                                    <asp:DropDownList ID="spSS" runat="server" 
				                                    Height="21px" Width="50px" style="margin-right: 5px">
				                                    <asp:ListItem></asp:ListItem>
				                                    <asp:ListItem>no</asp:ListItem>
				                                    <asp:ListItem>yes</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
	                                    </tr>
	                                    <tr id="trChildTitle" runat="server">
		                                    <td class="style95">
			                                    Children</td>
		                                    <td class="style96">
			                                    </td>
		                                    <td class="style97">
			                                    </td>
		                                    <td class="style98">
			                                    </td>
		                                    <td class="style99">
			                                    </td>
		                                    <td class="style100">
			                                    </td>
		                                    <td class="style101">
			                                    </td>
		                                    <td class="style102">
			                                    </td>
		                                    <td class="style103">
			                                    </td>
		                                    <td class="style104">
			                                    </td>
	                                    </tr>
	                                    <tr id="trChildOne" runat="server">
		                                    <td class="style94">
			                                    <asp:TextBox ID="ch1Name" runat="server"  Height="17px" 
				                                    style="margin-right: 5px" Width="125px"></asp:TextBox>
		                                    </td>
		                                    <td class="style88">
			                                    <asp:DropDownList ID="ch1Gender" runat="server"
				                                    Height="21px" Width="70px" size="1" style="margin-right: 5px">
				                                    <asp:ListItem>(Select)</asp:ListItem>
				                                    <asp:ListItem>male</asp:ListItem>
				                                    <asp:ListItem>female</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
		                                    <td class="style89">
			                                    <asp:TextBox ID="ch1Height" runat="server"  Height="17px" 
				                                    Width="35px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style87">
			                                    <asp:TextBox ID="ch1Weight" runat="server"  Height="17px" 
				                                    Width="35px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style82">
			                                    <asp:TextBox ID="ch1DOB" runat="server"  Height="17px" 
				                                    Width="65px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style90">
			                                    <asp:TextBox ID="ch1SSN" runat="server" Height="17px" 
				                                    Width="75px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style91">
			                                    <asp:TextBox ID="ch1Physician" runat="server"  Height="17px" 
				                                    Width="90px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style93">
			                                    <asp:DropDownList ID="ch1Student" runat="server" 
				                                    Height="21px" Width="50px" style="margin-right: 5px">
				                                    <asp:ListItem></asp:ListItem>
				                                    <asp:ListItem>no</asp:ListItem>
				                                    <asp:ListItem>yes</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
		                                    <td class="style85">
			                                    <asp:DropDownList ID="ch1Medicare" runat="server" 
				                                    Height="21px" Width="50px" style="margin-right: 5px">
				                                    <asp:ListItem></asp:ListItem>
				                                    <asp:ListItem>no</asp:ListItem>
				                                    <asp:ListItem>yes</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
		                                    <td class="style92">
			                                    <asp:DropDownList ID="ch1SS" runat="server" 
				                                    Height="21px" Width="50px" style="margin-right: 5px">
				                                    <asp:ListItem></asp:ListItem>
				                                    <asp:ListItem>no</asp:ListItem>
				                                    <asp:ListItem>yes</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
	                                    </tr>
	                                    <tr id="trChildTwo" runat="server">
		                                    <td class="style94">
			                                    <asp:TextBox ID="ch2Name" runat="server"  Height="19px" 
				                                    style="margin-right: 5px" Width="125px"></asp:TextBox>
		                                    </td>
		                                    <td class="style88">
			                                    <asp:DropDownList ID="ch2Gender" runat="server"
				                                    Height="21px" Width="70px" size="1" style="margin-right: 5px">
				                                    <asp:ListItem>(Select)</asp:ListItem>
				                                    <asp:ListItem>male</asp:ListItem>
				                                    <asp:ListItem>female</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
		                                    <td class="style89">
			                                    <asp:TextBox ID="ch2Height" runat="server"  Height="17px" 
				                                    Width="35px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style87">
			                                    <asp:TextBox ID="ch2Weight" runat="server"  Height="17px" 
				                                    Width="35px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style82">
			                                    <asp:TextBox ID="ch2DOB" runat="server"  Height="17px" 
				                                    Width="65px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style90">
			                                    <asp:TextBox ID="ch2SSN" runat="server" Height="17px" 
				                                    Width="75px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style91">
			                                    <asp:TextBox ID="ch2Physician" runat="server"  Height="17px" 
				                                    Width="90px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style93">
			                                    <asp:DropDownList ID="ch2Student" runat="server" 
				                                    Height="21px" Width="50px" style="margin-right: 5px">
				                                    <asp:ListItem></asp:ListItem>
				                                    <asp:ListItem>no</asp:ListItem>
				                                    <asp:ListItem>yes</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
		                                    <td class="style85">
			                                    <asp:DropDownList ID="ch2Medicare" runat="server" 
				                                    Height="21px" Width="50px" style="margin-right: 5px">
				                                    <asp:ListItem></asp:ListItem>
				                                    <asp:ListItem>no</asp:ListItem>
				                                    <asp:ListItem>yes</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
		                                    <td class="style92">
			                                    <asp:DropDownList ID="ch2SS" runat="server" 
				                                    Height="21px" Width="50px" style="margin-right: 5px">
				                                    <asp:ListItem></asp:ListItem>
				                                    <asp:ListItem>no</asp:ListItem>
				                                    <asp:ListItem>yes</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
	                                    </tr>
	                                    <tr id="trChildThree" runat="server">
		                                    <td class="style94">
			                                    <asp:TextBox ID="ch3Name" runat="server"  Height="17px" 
				                                    style="margin-right: 5px" Width="125px" ></asp:TextBox>
		                                    </td>
		                                    <td class="style88">
			                                    <asp:DropDownList ID="ch3Gender" runat="server"
				                                    Height="21px" Width="70px" size="1" style="margin-right: 5px">
				                                    <asp:ListItem>(Select)</asp:ListItem>
				                                    <asp:ListItem>male</asp:ListItem>
				                                    <asp:ListItem>female</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
		                                    <td class="style89">
			                                    <asp:TextBox ID="ch3Height" runat="server"  Height="17px" 
				                                    Width="35px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style87">
			                                    <asp:TextBox ID="ch3Weight" runat="server"  Height="17px" 
				                                    Width="35px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style82">
			                                    <asp:TextBox ID="ch3DOB" runat="server"  Height="17px" 
				                                    Width="65px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style90">
			                                    <asp:TextBox ID="ch3SSN" runat="server" Height="17px" 
				                                    Width="75px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style91">
			                                    <asp:TextBox ID="ch3Physician" runat="server"  Height="17px" 
				                                    Width="90px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style93">
			                                    <asp:DropDownList ID="ch3Student" runat="server" 
				                                    Height="21px" Width="50px" style="margin-right: 5px">
				                                    <asp:ListItem></asp:ListItem>
				                                    <asp:ListItem>no</asp:ListItem>
				                                    <asp:ListItem>yes</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
		                                    <td class="style85">
			                                    <asp:DropDownList ID="ch3Medicare" runat="server" 
				                                    Height="21px" Width="50px" style="margin-right: 5px">
				                                    <asp:ListItem></asp:ListItem>
				                                    <asp:ListItem>no</asp:ListItem>
				                                    <asp:ListItem>yes</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
		                                    <td class="style92">
			                                    <asp:DropDownList ID="ch3SS" runat="server" 
				                                    Height="21px" Width="50px" style="margin-right: 5px">
				                                    <asp:ListItem></asp:ListItem>
				                                    <asp:ListItem>no</asp:ListItem>
				                                    <asp:ListItem>yes</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
	                                    </tr>
	                                    <tr id="trChildFour" runat="server">
		                                    <td class="style94">
			                                    <asp:TextBox ID="ch4Name" runat="server"  Height="17px" 
				                                    style="margin-right: 5px" Width="125px"></asp:TextBox>
		                                    </td>
		                                    <td class="style88">
			                                    <asp:DropDownList ID="ch4Gender" runat="server"
				                                    Height="21px" Width="70px" size="1" style="margin-right: 5px">
				                                    <asp:ListItem>(Select)</asp:ListItem>
				                                    <asp:ListItem>male</asp:ListItem>
				                                    <asp:ListItem>female</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
		                                    <td class="style89">
			                                    <asp:TextBox ID="ch4Height" runat="server"  Height="17px" 
				                                    Width="35px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style87">
			                                    <asp:TextBox ID="ch4Weight" runat="server"  Height="17px" 
				                                    Width="35px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style82">
			                                    <asp:TextBox ID="ch4DOB" runat="server"  Height="17px" 
				                                    Width="65px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style90">
			                                    <asp:TextBox ID="ch4SSN" runat="server" Height="17px" 
				                                    Width="75px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style91">
			                                    <asp:TextBox ID="ch4Physician" runat="server"  Height="17px" 
				                                    Width="90px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style93">
			                                    <asp:DropDownList ID="ch4Student" runat="server" 
				                                    Height="21px" Width="50px" style="margin-right: 5px">
				                                    <asp:ListItem></asp:ListItem>
				                                    <asp:ListItem>no</asp:ListItem>
				                                    <asp:ListItem>yes</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
		                                    <td class="style85">
			                                    <asp:DropDownList ID="ch4Medicare" runat="server" 
				                                    Height="21px" Width="50px" style="margin-right: 5px">
				                                    <asp:ListItem></asp:ListItem>
				                                    <asp:ListItem>no</asp:ListItem>
				                                    <asp:ListItem>yes</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
		                                    <td class="style92">
			                                    <asp:DropDownList ID="ch4SS" runat="server" 
				                                    Height="21px" Width="50px" style="margin-right: 5px">
				                                    <asp:ListItem></asp:ListItem>
				                                    <asp:ListItem>no</asp:ListItem>
				                                    <asp:ListItem>yes</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
	                                    </tr>
	                                    <tr id="trChildFive" runat="server">
		                                    <td class="style94">
			                                    <asp:TextBox ID="ch5Name" runat="server"  Height="17px" 
				                                    style="margin-right: 5px" Width="125px"></asp:TextBox>
		                                    </td>
		                                    <td class="style88">
			                                    <asp:DropDownList ID="ch5Gender" runat="server"
				                                    Height="21px" Width="70px" size="1" style="margin-right: 5px">
				                                    <asp:ListItem>(Select)</asp:ListItem>
				                                    <asp:ListItem>male</asp:ListItem>
				                                    <asp:ListItem>female</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
		                                    <td class="style89">
			                                    <asp:TextBox ID="ch5Height" runat="server"  Height="17px" 
				                                    Width="35px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style87">
			                                    <asp:TextBox ID="ch5Weight" runat="server"  Height="17px" 
				                                    Width="35px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style82">
			                                    <asp:TextBox ID="ch5DOB" runat="server"  Height="17px" 
				                                    Width="65px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style90">
			                                    <asp:TextBox ID="ch5SSN" runat="server" Height="17px" 
				                                    Width="75px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style91">
			                                    <asp:TextBox ID="ch5Physician" runat="server"  Height="17px" 
				                                    Width="90px" style="margin-right: 5px"></asp:TextBox>
		                                    </td>
		                                    <td class="style93">
			                                    <asp:DropDownList ID="ch5Student" runat="server" 
				                                    Height="21px" Width="50px" style="margin-right: 5px">
				                                    <asp:ListItem></asp:ListItem>
				                                    <asp:ListItem>no</asp:ListItem>
				                                    <asp:ListItem>yes</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
		                                    <td class="style85">
			                                    <asp:DropDownList ID="ch5Medicare" runat="server" 
				                                    Height="21px" Width="50px" style="margin-right: 5px">
				                                    <asp:ListItem></asp:ListItem>
				                                    <asp:ListItem>no</asp:ListItem>
				                                    <asp:ListItem>yes</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
		                                    <td class="style92">
			                                    <asp:DropDownList ID="ch5SS" runat="server" 
				                                    Height="21px" Width="50px" style="margin-right: 5px">
				                                    <asp:ListItem></asp:ListItem>
				                                    <asp:ListItem>no</asp:ListItem>
				                                    <asp:ListItem>yes</asp:ListItem>
			                                    </asp:DropDownList>
		                                    </td>
	                                    </tr>
                                    </table>
                                   <!-- End Dependent Data-->
                                </asp:WizardStep>
                                
                                <asp:WizardStep title="Reasons for Declining Medical Coverage" runat="server">
                                <!--Start Decline of Medical-->
                                    <script language="javascript" type="text/javascript" src="Validation/DecliningForm/ValidateDecliningCoverage.js"></script>
                                    <script language="javascript" type="text/javascript" src="Validation/validationHelpers.js"></script>
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
                                    <p>You have choosen to DECLINE coverage for the following:</p>
                                    <table style="width: 100%; margin-left: 30px; margin-bottom: 32px;">
                                       <tr id="foo" runat="server">
	                                       <td class="style4" colspan="2">
		                                       &nbsp;</td>
                                       </tr>
                                       <tr id="tr1" runat="server">
	                                       <td class="style6">
		                                       <asp:Label ID="Label48" runat="server" Text="Medical:" CssClass="lblBold"></asp:Label>
		                                       </td>
	                                       <td id="tdMedical" runat="server" class="tdLight">
		                                       &nbsp;
		                                       </td>
                                       </tr>
                                       </table>
                                    <table style="width:100%; margin-left: 30px; margin-bottom: 24px;">
                                       <tr>
	                                       <td class="style1">
		                                       <asp:Label ID="Label49" runat="server" 
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
                                   <!-- End Decline Medical -->
                                </asp:WizardStep>
                                
                                <asp:WizardStep title="Reasons for Declining Dental Coverage" runat="server">
                                <!--Start Decline Dental-->
                                    <script language="javascript" type="text/javascript" src="Validation/DecliningForm/ValidateDecliningCoverage.js"></script>
                                    <script language="javascript" type="text/javascript" src="Validation/validationHelpers.js"></script>
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
                                    <p>You have choosen to DECLINE coverage for the following:</p>
                                    <table style="width: 100%; margin-left: 30px; margin-bottom: 32px;">
                                       <tr id="Tr2" runat="server">
	                                       <td class="style4" colspan="2">
		                                       &nbsp;</td>
                                       </tr>
                                       <tr id="tr3" runat="server">
	                                       <td class="style5">
		                                       <asp:Label ID="Label50" runat="server" Text="Dental:" CssClass="lblBold"></asp:Label>
		                                       </td>
	                                       <td id="tdDental" runat="server" class="tdLight">
		                                       &nbsp;
	                                       </td>
                                       </tr>
                                       </table>
                                    <table style="width:100%; margin-left: 30px; margin-bottom: 24px;">
                                       <tr>
	                                       <td class="style1">
		                                       <asp:Label ID="Label51" runat="server" 
			                                       Text="Declining Coverage for the following Reason(s):"></asp:Label>
	                                       </td>
	                                       <td class="style3">
		                                       &nbsp;</td>
	                                       <td>
		                                       &nbsp;</td>
                                       </tr>
                                       <tr>
	                                       <td class="style2">
		                                       <asp:RadioButton ID="RadioButton1" runat="server" Text=" Spouse's Employer Plan" 
			                                       GroupName="Dental" />
	                                       </td>
	                                       <td class="style3">
		                                       <asp:RadioButton GroupName="Dental" ID="RadioButton2" runat="server" Text=" Individual Plan" />
	                                       </td>
	                                       <td>
		                                       &nbsp;</td>
                                       </tr>
                                       <tr>
	                                       <td class="style2">
		                                       <asp:RadioButton GroupName="Dental" ID="RadioButton3" runat="server" Text=" Covered by Medicare" />
	                                       </td>
	                                       <td class="style3">
		                                       <asp:RadioButton GroupName="Dental" ID="RadioButton4" runat="server" Text=" VA Eligibility" />
	                                       </td>
	                                       <td>
		                                       &nbsp;</td>
                                       </tr>
                                       <tr>
	                                       <td class="style2">
		                                       <asp:RadioButton GroupName="Dental" ID="RadioButton5" runat="server" Text=" COBRA from prior employer" />
	                                       </td>
	                                       <td class="style3">
		                                       <asp:RadioButton GroupName="Dental" ID="RadioButton6" runat="server" Text=" Tri-Care" />
	                                       </td>
	                                       <td>
		                                       &nbsp;</td>
                                       </tr>
                                       <tr>
	                                       <td class="style2">
		                                       <asp:RadioButton GroupName="Dental" ID="RadioButton7" runat="server" 
			                                       Text=" I (we) have no other coverage at this time" />
	                                       </td>
	                                       <td class="style3">
		                                       <asp:RadioButton GroupName="Dental" ID="RadioButton8" runat="server" Text=" Medicaid" />
	                                       </td>
	                                       <td>
		                                       &nbsp;</td>
                                       </tr>
                                       <tr>
	                                       <td class="style2">
		                                       <asp:RadioButton GroupName="Dental" ID="RadioButton9" runat="server" Text="Disability" />
	                                       </td>
	                                       <td class="style3">
		                                       <asp:RadioButton GroupName="Dental" ID="RadioButton10" runat="server" Text=" Other, explain:" />
	                                       </td>
	                                       <td>
		                                       <asp:TextBox ID="TextBox1" runat="server" Width="190px"></asp:TextBox>
	                                       </td>
                                       </tr>
                                    </table>
                                    <p style="width: 683px">I understand that by waiving coverage at this time, I will not be allowed to participate unless I experience a life change event, at the next open enrollment period or as a late enrollee, if applicable.  I also understand that pre-existing limitations may apply.</p>
                                   <!-- End Decline Dental -->
                                </asp:WizardStep>
                                
                                <asp:WizardStep title="Reasons for Declining Vision Coverage" runat="server">
                                <!--Start Decline Vision-->
                                    <script language="javascript" type="text/javascript" src="Validation/DecliningForm/ValidateDecliningCoverage.js"></script>
                                    <script language="javascript" type="text/javascript" src="Validation/validationHelpers.js"></script>
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
                                    <p>You have choosen to DECLINE coverage for the following:</p>
                                    <table style="width: 100%; margin-left: 30px; margin-bottom: 32px;">
                                       <tr id="Tr4" runat="server">
	                                       <td class="style4" colspan="2">
		                                       &nbsp;</td>
                                       </tr>
                                       <tr id="tr5" runat="server">
	                                       <td class="style6">
		                                       <asp:Label ID="Label52" runat="server" Text="Vision:" CssClass="lblBold"></asp:Label>
		                                       </td>
	                                       <td id="tdVision" runat="server" class="tdLight">
		                                       &nbsp;
		                                       </td>
                                       </tr>
                                       </table>
			                                     <table style="width:100%; margin-left: 30px; margin-bottom: 24px;">
                                       <tr>
	                                       <td class="style1">
		                                       <asp:Label ID="Label53" runat="server" 
			                                       Text="Declining Coverage for the following Reason(s):"></asp:Label>
	                                       </td>
	                                       <td class="style3">
		                                       &nbsp;</td>
	                                       <td>
		                                       &nbsp;</td>
                                       </tr>
                                       <tr>
	                                       <td class="style2">
		                                       <asp:RadioButton ID="RadioButton11" runat="server" Text=" Spouse's Employer Plan" 
			                                       GroupName="Dental" />
	                                       </td>
	                                       <td class="style3">
		                                       <asp:RadioButton GroupName="Dental" ID="RadioButton12" runat="server" Text=" Individual Plan" />
	                                       </td>
	                                       <td>
		                                       &nbsp;</td>
                                       </tr>
                                       <tr>
	                                       <td class="style2">
		                                       <asp:RadioButton GroupName="Dental" ID="RadioButton13" runat="server" Text=" Covered by Medicare" />
	                                       </td>
	                                       <td class="style3">
		                                       <asp:RadioButton GroupName="Dental" ID="RadioButton14" runat="server" Text=" VA Eligibility" />
	                                       </td>
	                                       <td>
		                                       &nbsp;</td>
                                       </tr>
                                       <tr>
	                                       <td class="style2">
		                                       <asp:RadioButton GroupName="Dental" ID="RadioButton15" runat="server" Text=" COBRA from prior employer" />
	                                       </td>
	                                       <td class="style3">
		                                       <asp:RadioButton GroupName="Dental" ID="RadioButton16" runat="server" Text=" Tri-Care" />
	                                       </td>
	                                       <td>
		                                       &nbsp;</td>
                                       </tr>
                                       <tr>
	                                       <td class="style2">
		                                       <asp:RadioButton GroupName="Dental" ID="RadioButton17" runat="server" 
			                                       Text=" I (we) have no other coverage at this time" />
	                                       </td>
	                                       <td class="style3">
		                                       <asp:RadioButton GroupName="Dental" ID="RadioButton18" runat="server" Text=" Medicaid" />
	                                       </td>
	                                       <td>
		                                       &nbsp;</td>
                                       </tr>
                                       <tr>
	                                       <td class="style2">
		                                       <asp:RadioButton GroupName="Dental" ID="RadioButton19" runat="server" Text="Disability" />
	                                       </td>
	                                       <td class="style3">
		                                       <asp:RadioButton GroupName="Dental" ID="RadioButton20" runat="server" Text=" Other, explain:" />
	                                       </td>
	                                       <td>
		                                       <asp:TextBox ID="TextBox2" runat="server" Width="190px"></asp:TextBox>
	                                       </td>
                                       </tr>
                                    </table>
                                    <p style="width: 683px">I understand that by waiving coverage at this time, I will not be allowed to participate unless I experience a life change event, at the next open enrollment period or as a late enrollee, if applicable.  I also understand that pre-existing limitations may apply.</p>
                                <!--End Decline Vision-->
                                </asp:WizardStep>
                                
                                <asp:WizardStep title="Reasons for Declining Life Coverage" runat="server">
                                <!--Start Decline Life-->
                                    <script language="javascript" type="text/javascript" src="Validation/DecliningForm/ValidateDecliningCoverage.js"></script>
                                    <script language="javascript" type="text/javascript" src="Validation/validationHelpers.js"></script>
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
                                    <p>You have choosen to DECLINE coverage for the following:</p>
                                    <table style="width: 100%; margin-left: 30px; margin-bottom: 32px;">
                                       <tr id="Tr6" runat="server">
	                                       <td class="style4" colspan="2">
		                                       &nbsp;</td>
                                       </tr>
                                       <tr id="tr7" runat="server">
	                                       <td class="style6">
		                                       <asp:Label ID="Label54" runat="server" Text="Life:" CssClass="lblBold"></asp:Label>
		                                       </td>
	                                       <td id="tdLife" runat="server" class="tdLight">
		                                       &nbsp;
		                                       </td>
                                       </tr>
                                       </table>
			                                     <table style="width:100%; margin-left: 30px; margin-bottom: 24px;">
                                       <tr>
	                                       <td class="style1">
		                                       <asp:Label ID="Label55" runat="server" 
			                                       Text="Declining Coverage for the following Reason(s):"></asp:Label>
	                                       </td>
	                                       <td class="style3">
		                                       &nbsp;</td>
	                                       <td>
		                                       &nbsp;</td>
                                       </tr>
                                       <tr>
	                                       <td class="style2">
		                                       <asp:RadioButton ID="RadioButton21" runat="server" Text=" Spouse's Employer Plan" 
			                                       GroupName="Dental" />
	                                       </td>
	                                       <td class="style3">
		                                       <asp:RadioButton GroupName="Dental" ID="RadioButton22" runat="server" Text=" Individual Plan" />
	                                       </td>
	                                       <td>
		                                       &nbsp;</td>
                                       </tr>
                                       <tr>
	                                       <td class="style2">
		                                       <asp:RadioButton GroupName="Dental" ID="RadioButton23" runat="server" Text=" Covered by Medicare" />
	                                       </td>
	                                       <td class="style3">
		                                       <asp:RadioButton GroupName="Dental" ID="RadioButton24" runat="server" Text=" VA Eligibility" />
	                                       </td>
	                                       <td>
		                                       &nbsp;</td>
                                       </tr>
                                       <tr>
	                                       <td class="style2">
		                                       <asp:RadioButton GroupName="Dental" ID="RadioButton25" runat="server" Text=" COBRA from prior employer" />
	                                       </td>
	                                       <td class="style3">
		                                       <asp:RadioButton GroupName="Dental" ID="RadioButton26" runat="server" Text=" Tri-Care" />
	                                       </td>
	                                       <td>
		                                       &nbsp;</td>
                                       </tr>
                                       <tr>
	                                       <td class="style2">
		                                       <asp:RadioButton GroupName="Dental" ID="RadioButton27" runat="server" 
			                                       Text=" I (we) have no other coverage at this time" />
	                                       </td>
	                                       <td class="style3">
		                                       <asp:RadioButton GroupName="Dental" ID="RadioButton28" runat="server" Text=" Medicaid" />
	                                       </td>
	                                       <td>
		                                       &nbsp;</td>
                                       </tr>
                                       <tr>
	                                       <td class="style2">
		                                       <asp:RadioButton GroupName="Dental" ID="RadioButton29" runat="server" Text="Disability" />
	                                       </td>
	                                       <td class="style3">
		                                       <asp:RadioButton GroupName="Dental" ID="RadioButton30" runat="server" Text=" Other, explain:" />
	                                       </td>
	                                       <td>
		                                       <asp:TextBox ID="TextBox3" runat="server" Width="190px"></asp:TextBox>
	                                       </td>
                                       </tr>
                                    </table>
                                    <p style="width: 683px">I understand that by waiving coverage at this time, I will not be allowed to participate unless I experience a life change event, at the next open enrollment period or as a late enrollee, if applicable.  I also understand that pre-existing limitations may apply.</p>
                                <!--End Decline Life-->
                                </asp:WizardStep>
                                
                                <asp:WizardStep title="Reasons for Declining Disability Coverage" runat="server">
                                <!--Start Decline Disability-->
                                    <script language="javascript" type="text/javascript" src="Validation/DecliningForm/ValidateDecliningCoverage.js"></script>
                                    <script language="javascript" type="text/javascript" src="Validation/validationHelpers.js"></script>
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
                                    <p>You have choosen to DECLINE coverage for the following:</p>
                                    <table style="width: 100%; margin-left: 30px; margin-bottom: 32px;">
                                       <tr id="Tr8" runat="server">
                                           <td class="style4" colspan="2">
	                                           &nbsp;</td>
                                       </tr>
                                       <tr id="tr9" runat="server">
                                           <td class="style6">
	                                           <asp:Label ID="Label56" runat="server" Text="Disability:" CssClass="lblBold"></asp:Label>
	                                           </td>
                                           <td id="tdDisability" runat="server" class="tdLight">
	                                           &nbsp;
	                                           </td>
                                       </tr>
                                       </table>
		                                         <table style="width:100%; margin-left: 30px; margin-bottom: 24px;">
                                       <tr>
                                           <td class="style1">
	                                           <asp:Label ID="Label57" runat="server" 
		                                           Text="Declining Coverage for the following Reason(s):"></asp:Label>
                                           </td>
                                           <td class="style3">
	                                           &nbsp;</td>
                                           <td>
	                                           &nbsp;</td>
                                       </tr>
                                       <tr>
                                           <td class="style2">
	                                           <asp:RadioButton ID="RadioButton31" runat="server" Text=" Spouse's Employer Plan" 
		                                           GroupName="Dental" />
                                           </td>
                                           <td class="style3">
	                                           <asp:RadioButton GroupName="Dental" ID="RadioButton32" runat="server" Text=" Individual Plan" />
                                           </td>
                                           <td>
	                                           &nbsp;</td>
                                       </tr>
                                       <tr>
                                           <td class="style2">
	                                           <asp:RadioButton GroupName="Dental" ID="RadioButton33" runat="server" Text=" Covered by Medicare" />
                                           </td>
                                           <td class="style3">
	                                           <asp:RadioButton GroupName="Dental" ID="RadioButton34" runat="server" Text=" VA Eligibility" />
                                           </td>
                                           <td>
	                                           &nbsp;</td>
                                       </tr>
                                       <tr>
                                           <td class="style2">
	                                           <asp:RadioButton GroupName="Dental" ID="RadioButton35" runat="server" Text=" COBRA from prior employer" />
                                           </td>
                                           <td class="style3">
	                                           <asp:RadioButton GroupName="Dental" ID="RadioButton36" runat="server" Text=" Tri-Care" />
                                           </td>
                                           <td>
	                                           &nbsp;</td>
                                       </tr>
                                       <tr>
                                           <td class="style2">
	                                           <asp:RadioButton GroupName="Dental" ID="RadioButton37" runat="server" 
		                                           Text=" I (we) have no other coverage at this time" />
                                           </td>
                                           <td class="style3">
	                                           <asp:RadioButton GroupName="Dental" ID="RadioButton38" runat="server" Text=" Medicaid" />
                                           </td>
                                           <td>
	                                           &nbsp;</td>
                                       </tr>
                                       <tr>
                                           <td class="style2">
	                                           <asp:RadioButton GroupName="Dental" ID="RadioButton39" runat="server" Text="Disability" />
                                           </td>
                                           <td class="style3">
	                                           <asp:RadioButton GroupName="Dental" ID="RadioButton40" runat="server" Text=" Other, explain:" />
                                           </td>
                                           <td>
	                                           <asp:TextBox ID="TextBox4" runat="server" Width="190px"></asp:TextBox>
                                           </td>
                                       </tr>
                                    </table>
                                    <p style="width: 683px">I understand that by waiving coverage at this time, I will not be allowed to participate unless I experience a life change event, at the next open enrollment period or as a late enrollee, if applicable.  I also understand that pre-existing limitations may apply.</p>
                                <!--End Decline Disability-->
                                </asp:WizardStep>
                                
                                <asp:WizardStep title="Other Coverage" runat="server">
                                <!--Start Other Coverage-->
                                    <script language="javascript" type="text/javascript" src="Validation/OtherCoverage/ValidateOtherCoverage.js"></script>
                                    <script language="javascript" type="text/javascript" src="Validation/validationHelpers.js"></script>
                                    
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
                                    <asp:HiddenField ID="myIsLife" runat="server" />
                                    <table style="margin-left: 30px; margin-bottom: 4px;">
                                       <tr>
	                                       <td class="style1">
		                                       <asp:Label ID="Label58" runat="server" 
			                                       Text="Do you or any of your dependents have Medicare Coverage?" 
			                                       CssClass="tableTitle"></asp:Label>
	                                       </td>
	                                       <td>
		                                       <asp:DropDownList ID="DropDownList1" runat="server" Width="78px" 
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
                                    		   
		                                       <asp:Label ID="Label59" runat="server" Text="Name:"></asp:Label>
	                                       </td>
	                                       <td class="style19">
                                    		   
		                                       <asp:TextBox ID="txtMedicareName" runat="server" Width="307px"></asp:TextBox>
	                                       </td>
	                                       <td class="style10">
                                    		   
		                                       <asp:Label ID="Label60" runat="server" Text="ID#"></asp:Label>
	                                       </td>
	                                       <td class="style9">
		                                       <asp:TextBox ID="txtMedicareID" runat="server" style="margin-left: 0px"></asp:TextBox>
	                                       </td>
                                       </tr>
                                       </table>
                                    <table id="tableMedicare2">
                                       <tr>
	                                       <td class="style42">
                                    		   
		                                       <asp:Label ID="Label61" runat="server" Text="Effective Date  (Part A)"></asp:Label>
	                                       </td>
	                                       <td class="style13">
                                    		   
		                                       <asp:TextBox ID="txtMedicareA" runat="server" Width="71px"></asp:TextBox>
	                                       </td>
	                                       <td class="style31">
                                    		   
		                                       <asp:Label ID="Label62" runat="server" Text="(Part B)"></asp:Label>
	                                       </td>
	                                       <td class="style15">
		                                       <asp:TextBox ID="txtMedicareB" runat="server" style="margin-right: 10px" 
			                                       Width="71px"></asp:TextBox>
	                                       </td>
	                                       <td class="style41">
		                                       <asp:Label ID="Label63" runat="server" Text="(Part C)"></asp:Label>
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
		                                       <asp:Label ID="Label64" runat="server" 
                                    			   
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
		                                       <asp:Label ID="Label65" runat="server" 
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
		                                       <asp:CheckBox ID="CheckBox1" runat="server" Text=" Disability" />
	                                       </td>
                                       </tr>
                                       </table>
                                    <table style="margin-left: 45px;">
                                       <tr>
	                                       <td>
		                                       <asp:Label ID="Label66" runat="server" Text="Name of covered person(s)"></asp:Label>
	                                       </td>
                                       </tr>
                                       <tr>
	                                       <td>
		                                       <asp:TextBox ID="txtConcurentName" runat="server" Width="436px"></asp:TextBox>
	                                       </td>
                                       </tr>
                                       <tr>
	                                       <td>
		                                       <asp:Label ID="Label67" runat="server" 
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
		                                       <asp:Label ID="Label68" runat="server" Text="Insurance Company/HMO Name"></asp:Label>
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
		                                       <asp:Label ID="Label69" runat="server" Text="Policy Number:"></asp:Label>
	                                       </td>
	                                       <td class="style36">
		                                       <asp:TextBox ID="txtConcurrentPolicy" runat="server" Width="144px"></asp:TextBox>
	                                       </td>
	                                       <td class="style37">
		                                       <asp:Label ID="Label70" runat="server" Text="Effective Date:"></asp:Label>
	                                       </td>
	                                       <td class="style38">
		                                       <asp:TextBox ID="txtConcurrentEff" runat="server" Width="173px"></asp:TextBox>
	                                       </td>
                                       </tr>
                                       <tr>
	                                       <td class="style35">
		                                       <asp:Label ID="Label71" runat="server" Text="End Date:"></asp:Label>
	                                       </td>
	                                       <td class="style36">
		                                       <asp:TextBox ID="txtConcurrentEnd" runat="server" Width="144px"></asp:TextBox>
	                                       </td>
	                                       <td class="style37">
		                                       <asp:Label ID="Label72" runat="server" Text="Coverage Type:"></asp:Label>
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
		                                       <asp:Label ID="Label73" runat="server" 
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
		                                       <asp:Label ID="Label74" runat="server" Text="Name of covered person(s)"></asp:Label>
	                                       </td>
                                       </tr>
                                       <tr>
	                                       <td>
		                                       <asp:TextBox ID="txtPreviousName" runat="server" Width="436px"></asp:TextBox>
	                                       </td>
                                       </tr>
                                       <tr>
	                                       <td>
		                                       <asp:Label ID="Label75" runat="server" 
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
		                                       <asp:Label ID="Label76" runat="server" Text="Insurance Company/HMO Name"></asp:Label>
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
		                                       <asp:Label ID="Label77" runat="server" Text="Policy Number:"></asp:Label>
	                                       </td>
	                                       <td class="style36">
		                                       &nbsp;
		                                       <asp:TextBox ID="txtPolicy" runat="server" Width="144px"></asp:TextBox>
	                                       </td>
	                                       <td class="style37">
		                                       &nbsp;
		                                       <asp:Label ID="Label78" runat="server" Text="Effective Date:"></asp:Label>
	                                       </td>
	                                       <td class="style38">
		                                       <asp:TextBox ID="txtPreviousEff" runat="server" Width="173px"></asp:TextBox>
	                                       </td>
                                       </tr>
                                       <tr>
	                                       <td class="style35">
		                                       &nbsp;
		                                       <asp:Label ID="Label79" runat="server" Text="End Date:"></asp:Label>
	                                       </td>
	                                       <td class="style36">
		                                       &nbsp;
		                                       <asp:TextBox ID="txtPreviousEnd" runat="server" Width="144px"></asp:TextBox>
	                                       </td>
	                                       <td class="style37">
		                                       &nbsp;
		                                       <asp:Label ID="Label80" runat="server" Text="Coverage Type:"></asp:Label>
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
		                                       <asp:Label ID="Label81" runat="server" 
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
		                                       <asp:Label ID="Label82" runat="server" CssClass="tableTitle" 
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
		                                       &nbsp;<asp:Label ID="Label83" runat="server" Text="Address"></asp:Label>
	                                       </td>
	                                       <td class="style40">
		                                       <asp:Label ID="Label84" runat="server" Text="Percentage"></asp:Label>
	                                       </td>
	                                       <td class="style41">
		                                       <asp:Label ID="Label85" runat="server" Text="Relationship"></asp:Label>
	                                       </td>
	                                       <td >
		                                       <asp:Label ID="Label86" runat="server" Text="SSN"></asp:Label>
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
		                                       <asp:Label ID="Label87" runat="server" CssClass="tableTitle" 
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
		                                       <asp:Label ID="Label88" runat="server" Text="Address"></asp:Label>
	                                       </td>
	                                       <td class="style40">
		                                       <asp:Label ID="Label89" runat="server" Text="Percentage"></asp:Label>
	                                       </td>
	                                       <td class="style41">
		                                       <asp:Label ID="Label90" runat="server" Text="Relationship"></asp:Label>
	                                       </td>
	                                       <td class="style44">
		                                       <asp:Label ID="Label91" runat="server" Text="SSN"></asp:Label>
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
                                    <script type="text/javascript">
                                        document.getElementById("Medicare").style.display = "none";
                                        document.getElementById("ConcurrentCoverage").style.display = "none";
                                        document.getElementById("PreviousCoverage").style.display = "none";
                                        if (document.getElementById("UserWizard1_myIsLife").value == "0") {
	                                        document.getElementById("tableLife").style.display = "none";
                                        }
                                        else {
	                                        document.getElementById("tableLife").style.display = "";
                                        }
                                    </script>
                                <!--End Other Coverage-->
                                </asp:WizardStep>
                                
                                <asp:WizardStep title="Health Information" runat="server">
                                <!--Start Health Information-->
                                    <script language="javascript" type="text/javascript" src="Validation/validationHelpers.js"></script>
                                    <script language="javascript" type="text/javascript" src="Validation/HealthInformation/ValidateHealthInformation.js"></script>
                                    <script type="text/javascript">
                                    function toggleDueDate() {
	                                    if (document.getElementById("UserWizard1_CheckBoxList1_8").checked) {
		                                    document.getElementById("trDueDate").style.display = "";
	                                    }
	                                    else if (!document.getElementById("UserWizard1_CheckBoxList1_8").checked) {
	                                    document.getElementById("trDueDate").style.display = "none";
	                                    }
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
                                    <div id="Health1">
                                       <table style="margin-left: 40px;">
	                                       <tr>
		                                       <td class="style3">
			                                       <asp:Label ID="Label92" runat="server" CssClass="tableTitle" Text="Section 1"></asp:Label>
		                                       </td>
	                                       </tr>
	                                       <tr>
		                                       <td class="style4">
			                                       <asp:Label ID="Label93" runat="server" 
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
				                                       <asp:ListItem>11. Digestive/Intestinal Disorder</asp:ListItem>
				                                       <asp:ListItem>12. Drug or Alchohol Abuse</asp:ListItem>
				                                       <asp:ListItem>13. Eating Disorder</asp:ListItem>
				                                       <asp:ListItem>14. Endocrine/Pancreatic Disorder</asp:ListItem>
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
				                                       <asp:ListItem>28. Stroke/Nervous System/Brain Disorder</asp:ListItem>
				                                       <asp:ListItem>29. Tumor</asp:ListItem>
				                                       <asp:ListItem>30. Tobacco Product Use</asp:ListItem>
				                                       <asp:ListItem>31. Vascular (blood vessel) Disorder</asp:ListItem>
			                                       </asp:CheckBoxList>
		                                       </td>
	                                       </tr>
	                                       <tr id="trDueDate">
		                                       <td class="style11">
			                                       &nbsp;
			                                       <asp:Label ID="Label94" runat="server" Text="Pregnancy Due Date:"></asp:Label>
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
                                    			   
			                                       <asp:Label ID="Label95" runat="server" CssClass="tableTitle" Text="Section 2"></asp:Label>
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
			                                       <asp:Label ID="Label96" runat="server" Text="Have you or any person named in this application recieved inpatient or outpatient services in the last three (3) years (excluding routine tests, physicals or innoculations)?"></asp:Label>
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
			                                       <asp:Label ID="Label97" runat="server" Text="Do you or any person named in this application have tests, treatments, hospitalization or surgery planned or recommended in the future?"></asp:Label>
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
                                    			   
			                                       <asp:Label ID="Label98" runat="server" Text="Do you or any person named in this application take any medicine, prescription drugs or require shots/injections?"></asp:Label>
                                    			   
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
			                                       <asp:Label ID="Label99" runat="server" Text="Do you or any person named in this application have any other medical conditions which have not yet been previously mentioned?"></asp:Label>
		                                       </td>
	                                       </tr>
                                       </table>
                                    </div>
                                    <script type="text/javascript">
                                    document.getElementById("trDueDate").style.display = "none";
                                    //document.getElementById("CheckBoxList1_8").onClick="toggleDueDate()";
                                    </script>
                                <!--End Health Information-->
                                </asp:WizardStep>
                                
                                <asp:WizardStep title="Health Explanations" runat="server">
                                    <!--Start Health Explanations-->
                                        <script language="javascript" type="text/javascript" src="Validation/validationHelpers.js"></script>
                                        <script language="javascript" type="text/javascript" src="Validation/HealthExplanations/validateExplanationsGrid.js"></script>
                                        <style type="text/css">
	                                    #test
	                                    {
		                                    width: 731px;
		                                    margin-left: 17px;
		                                    margin-top: 0px;
		                                    margin-bottom: 0px;
	                                    }
	                                    #Table2
	                                    {
		                                    margin-left: 20px;
	                                    }
	                                    #Table4
	                                    {
		                                    margin-left: 25px;
	                                    }
	                                    #test1
	                                    {
		                                    margin-left: 20px;
	                                    }
	                                    .ModalBackground 
                                        {
                                            background-color:Gray;
                                            filter:alpha(opacity=70);
                                            opacity:0.7;
                                        }
                                        .detailsgrid
                                        {
                                	        background-color: #FFFFFF;
                                	        border: 1px solid;
                                	        padding-bottom: 20px;
                                	        padding-top: 15px;
                                	        padding-left: 20px;
                                	        padding-right: 20px;
                                        }
                                    </style><table style="width: 100%; margin-left: 15px;">
                                       <tr>
	                                       <td>
		                                       <asp:Label ID="Label100" runat="server" CssClass="tableTitle" Text="Section 3"></asp:Label>
	                                       </td>
	                                       <td>
		                                       &nbsp;</td>
	                                       <td>
		                                       &nbsp;</td>
                                       </tr>
                                       <tr>
	                                       <td>
		                                       &nbsp;</td>
	                                       <td>
		                                       &nbsp;</td>
	                                       <td>
		                                       &nbsp;</td>
                                       </tr>
                                    </table>
                                    <br />
                                    
                                    <AjaxToolKit:ToolkitScriptManager ID="ScriptManager1" runat="server">
                                    </AjaxToolKit:ToolkitScriptManager>
                                    
                                    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                                        <ContentTemplate>
                                    
                                    <asp:HiddenField ID="isEditOrAdd" Value="none" runat="server" />
                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                                        DataObjectTypeName="ElectronicApp.Supporting_Classes.HealthStatement" 
                                        SelectMethod="getStatements" DeleteMethod="DeleteEntry"
                                        TypeName="ElectronicApp.Supporting_Classes.HealthStatementData"
                                        EnableViewState="False" UpdateMethod="UpdateEntry" InsertMethod="InsertEntry">
                                    </asp:ObjectDataSource>
                                    
                                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server"
                                        DataObjectTypeName="ElectronicApp.Supporting_Classes.HealthStatement"
                                        InsertMethod="InsertEntry" SelectMethod="getStatementByRowID"
                                        TypeName="ElectronicApp.Supporting_Classes.HealthStatementData"
                                        DeleteMethod="DeleteEntry" UpdateMethod="UpdateEntry" OnSelecting="ObjectDataSource2_Selecting">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="GridView1" 
                                                Name="RowID" PropertyName="SelectedValue" DefaultValue="0" Type="Int32" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                    
                                    <asp:LinkButton ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add"></asp:LinkButton>
                                    <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" 
                                        AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" 
                                                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="RowID" 
                                                AllowPaging="True">
                                        <EmptyDataTemplate>No conditions listed. Please click Add to add explanations for each condition.</EmptyDataTemplate>
                                        <Columns>
                                            <asp:CommandField ShowDeleteButton="true" ShowSelectButton="true" />
                                            <asp:TemplateField><ItemTemplate><asp:LinkButton ID="btnEdit" OnClick="btnEdit_Click" runat="server" Text="Edit" CommandName="Select" /></ItemTemplate></asp:TemplateField>
                                            <asp:BoundField DataField="Question" HeaderText="Question" 
                                                SortExpression="Question" />
                                            <asp:BoundField DataField="Name" HeaderText="Person Name" SortExpression="Name" />
                                            <asp:BoundField DataField="Condition" HeaderText="Condition" 
                                                SortExpression="Condition" />
                                            <asp:BoundField DataField="DateDiagnosed" HeaderText="Date Diagnosed" 
                                                SortExpression="DateDiagnosed" />
                                            <asp:BoundField DataField="DateLastTreated" HeaderText="Date Last Treated" 
                                                SortExpression="DateLastTreated" />
                                            <asp:BoundField DataField="TreatmentType" HeaderText="Type of Treatment and Names of Medications (e.g. Oral, Injectable, Infusion, Inhaled, or Transdermal)" 
                                                SortExpression="TreatmentType" />
                                            <asp:CheckBoxField DataField="IsMedication" HeaderText="Ongoing Medication?" 
                                                SortExpression="IsMedication"  />
                                            <asp:BoundField DataField="Recovery" HeaderText="Degree of Recovery" 
                                                SortExpression="Recovery" />
                                        </Columns>
                                    </asp:GridView>
                                    
                                    <asp:Panel ID="pnlPopup" runat="server" CssClass="detailsgrid" Width="500px" style="display: none;">
                                        <asp:Button ID="btnShowPopup" runat="server" style="display:none" />
                                        <ajaxToolKit:ModalPopupExtender ID="mdlPopup" runat="server" TargetControlID="btnShowPopup" popupControlID="pnlPopup" CancelControlID="btnClose" BackgroundCssClass="ModalBackground" />
                                        <asp:HiddenField ID="indexes" runat="server" />
                                        <table border="0" width="100%" cellpadding="2px" class="detail">
                                            <tr>
                                                <td width="30%">Question</td>
                                                <td width="70%"><asp:DropDownList runat="server" ID="cmbQuestion"></asp:DropDownList></td>
                                            </tr>
                                            
                                            <tr>
                                                <td width="30%">Person</td>
                                                <td width="70%"><asp:DropDownList runat="server" ID="cmbPersonName"></asp:DropDownList></td>
                                            </tr>
                                            
                                            <tr>
                                                <td width="30%">Condition</td>
                                                <td width="70%"><asp:TextBox ID="txtCondition" runat="server"></asp:TextBox></td>
                                            </tr>
                                            
                                            <tr>
                                                <td width="30%">Date Diagnosed</td>
                                                <td width="70%"><asp:TextBox ID="txtDateDiagnosed" runat="server"></asp:TextBox></td>
                                            </tr>
                                            
                                            <tr>
                                                <td width="30%">Date Last Treated</td>
                                                <td width="70%"><asp:TextBox ID="txtDateLastTreated" runat="server"></asp:TextBox></td>
                                            </tr>
                                            
                                            <tr>
                                                <td width="30%">Medications</td>
                                                <td width="70%"><asp:TextBox Height="5em" Rows="4" ID="txtMeds" runat="server"></asp:TextBox></td>
                                            </tr>
                                            
                                            <tr>
                                                <td width="30%">Ongoing Medication?</td>
                                                <td width="70%"><asp:CheckBox ID="chkOngoing" runat="server" Text="Yes" /></td>
                                            </tr>
                                            
                                            <tr>
                                                <td width="30%">Degree of Recovery</td>
                                                <td width="70%"><asp:TextBox ID="txtDegreeOfRecovery" runat="server"></asp:TextBox></td>
                                            </tr>
                                            
                                        </table>
                                        
                                        <%--<asp:DetailsView ID="dvCondition" runat="server" 
                                            DataSourceID="ObjectDataSource2" CssClass="detailsgrid" GridLines="None" 
                                            DefaultMode="Insert" AutoGenerateRows="False" style="display: none;" 
                                            Width="100%">
                                            <Fields>
                                                <asp:BoundField DataField="RowID" HeaderText="RowID" SortExpression="RowID" />
                                                <asp:BoundField DataField="Question" HeaderText="Question" 
                                                    SortExpression="Question" />
                                                <asp:BoundField DataField="Recovery" HeaderText="Recovery" 
                                                    SortExpression="Recovery" />
                                                <asp:CheckBoxField DataField="IsMedication" HeaderText="IsMedication" 
                                                    SortExpression="IsMedication" />
                                                <asp:BoundField DataField="TreatmentType" HeaderText="TreatmentType" 
                                                    SortExpression="TreatmentType" />
                                                <asp:BoundField DataField="DateLastTreated" HeaderText="DateLastTreated" 
                                                    SortExpression="DateLastTreated" />
                                                <asp:BoundField DataField="DateDiagnosed" HeaderText="DateDiagnosed" 
                                                    SortExpression="DateDiagnosed" />
                                                <asp:BoundField DataField="Condition" HeaderText="Condition" 
                                                    SortExpression="Condition" />
                                                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                                <asp:BoundField DataField="QuestionNum" HeaderText="QuestionNum" 
                                                    SortExpression="QuestionNum" />
                                            </Fields>
                                        </asp:DetailsView>--%>
                                        <asp:LinkButton ID="btnClose" Text="Close" runat="server" />
                                        <asp:LinkButton ID="btnSave" Text="Save" OnClick="btnSave_Click" runat="server" />
                                    </asp:Panel>
                                    
                                    
                                    
                                    <asp:HiddenField ID="NumExplanationsRequired" runat="server" Value="100" />
                                    <asp:PlaceHolder runat="server" ID="c_placeHolder"></asp:PlaceHolder>
                                    <br />
                                    <asp:Label ID="c_resultLabel" runat="server"></asp:Label><br />
                                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                    
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                                    


                                    <br />
                                    </asp:WizardStep>
                                
                                <asp:WizardStep title="Processing Application" runat="server">
                                <!--Start Processing-->
                                    <style type="text/css">
                                    .style4
                                    {
	                                    width: 333px;
                                    }
                                    .style5
                                    {
	                                    width: 445px;
                                    }
                                    </style>
                                    <div id="Div1">
                                     <div id ="myMessage">
	                                       <br />
	                                       <h2><p><span class="red">You Are Almost Done</span></p></h2>
	                                       <br />
		                                       <p style="width: 648px; margin-left: 5px; margin-right: 0px">
			                                       Please Press next to review and sign your application. After the page loads 
			                                       please review the application for accuracy.</p>
			                                       <p style="width: 648px; margin-left: 5px; margin-right: 0px">After you have reviewed your application you will be asked to sign the application using your mouse.</p>
			                                     <br />  
                                    			 
                                    		   
		                                       <br />
		                                       <br />
		                                       <%--<asp:Button ID="Button1" runat="server" CssClass="btnLogin" Height="30px" 
			                                       onclick="btnNext_Click" style="margin-right: 40px; margin-top: 22px;" 
			                                       Text="Next" Width="70px" />--%>
		                                       <br />
		                                       <br />
		                                    <div class="clearFloat"></div>
	                                       </div>
                                <!--End Processing-->
                                </asp:WizardStep>
                                
                                <asp:WizardStep AllowReturn="false" title="Review Application" runat="server">
                                <!--Start Review-->
                                    <style type="text/css">
	                                    #frame1
	                                    {
		                                    margin-left: 22px;
	                                    }
	                                    .style1
	                                    {
	                                    }
	                                    .style2
	                                    {
		                                    width: 103px;
	                                    }
                                    </style>
                                    <br />
                                    <h2 style="margin-left: 25px">Please review your application for accuracy</h2>
                                    <p>Press next at bottom of the page to proceed with signing your application</p>
                                    <br />
                                    <iframe id="frame1" src=""  runat="server" width="750px" height="800px" > </iframe>
                                <!--End Review-->
                                </asp:WizardStep>
                                
                                <asp:WizardStep title="Sign Application" runat="server">
                                <!--Start Sign Application-->
                                    <style type="text/css">
	                                    .flatbutton
	                                    {
		                                    margin-left: 0px;
		                                    height: 26px;
	                                    }
	                                    .style1
	                                    {
		                                    width: 40px;
	                                    }
	                                    .style2
	                                    {
		                                    width: 160px;
	                                    }
	                                    .style3
	                                    {
		                                    width: 42px;
	                                    }
	                                    .style6
	                                    {
		                                    width: 413px;
	                                    }

                                    </style>  
                                    <table style="width: 100%; margin-left: 37px; margin-top: 0px;">
                                       <tr>
	                                       <td class="style6">
		                                       <h4>By Signing Below you Agree to the following Authorization Terms:</h4></td>
	                                       <td>
		                                       <a href="AuthorizationAndCert.aspx" target="_blank">Read Authorization Agreement</a>
	                                       </td>
	                                       <td>
		                                       &nbsp;
	                                       </td>
                                       </tr>
                                       </table>

			                                    <%--table style="width: 100%; margin-left: 51px; margin-top: 11px;">
                                       <tr>
	                                       <td class="style5">
		                                       <asp:CheckBox ID="CheckBox1" runat="server" 
			                                       Text=" I have read and agree to terms contained in the Authorization Agreement" />
	                                       </td>
	                                       <td>
		                                       &nbsp;
	                                       </td>
	                                       <td>
		                                       &nbsp;
	                                       </td>
                                       </tr>
                                       </table--%>
                                       <br />
                                       <br />
                                       <div class="terms">
                                       <h4 style="margin-left: 41px">Please Read Before Signing:</h4>
                                       <br />
                                       <p style="width: 717px; font-weight: normal; color: #000000; margin-left: 17px;">I certify that I am legally authorized to apply for coverage for myself and all other persons named in this application. I further certify that, after this application was completed, I
                                    carefully and fully read it, that the statements and answers set forth are full, true and correct to the best of my knowledge and belief, and that no information required to be given,
                                    either expressly or by implication, has been knowingly withheld. </p>
                                    <p style="width: 717px; font-weight: normal; color: #000000; margin-left: 17px;">I understand that the Carrier will rely on the completeness and truthfulness of the information given and the
                                    statements made, and that if I have made any false statements or misrepresentations, or have failed to disclose or concealed any material fact, the Carrier will be entitled to
                                    declare any contract or coverage issued pursuant to this application void and to refuse allowance on benefits to any person thereunder, which means that any claims incurred will
                                    become my liability. </p>
                                    <p style="width: 717px; font-weight: normal; color: #000000; margin-left: 17px;">If the group policy does not require my contribution, I understand that I cannot decline any coverage unless the policy indicates otherwise. If the group policy
                                    requires my contribution, I authorize my employer to deduct from my pay. I understand an agent or broker cannot guarantee coverage, revise rates, benefits or provisions without written approval from the Carrier.</p>
                                    </div>
                                    <br />
                                    <br />
			                                    <table style="width:100%; margin-left: 52px;">
				                                    <tr>
					                                    <td class="style1">
			                                    <div id="sign">
			                                    <uc:Signature id="ctlMySignature" PenColor="black"  PenWidth="2" BackColor="White" SignWidth="500" SignHeight="100" style="overflow:hidden"
			                                    SavePath="~/Signatures/" SignatureCodePath="~/SignatureControl/" SignatureFileFormat="Gif" Runat="server"></uc:Signature>
        					                            
					                                    </div></td>
					                                    <td>
						                                    &nbsp;</td>
				                                    </tr>
				                                    </table>
                                    				

                                    <table style="margin-left: 432px;">
				                                    <tr>
					                                    <td class="style3">
                                    			
		                                    <input type="button" class="flatbutton" value="  Accept  " onclick="SaveSignature(); EnableSaveButton(true);"/></td>
					                                    <td class="style2">
		                                    <input type="button" class="flatbutton" value="  Re-Sign " onclick="ClearSignature(); EnableSaveButton(false);"/></td>
				                                    </tr>
				                                    </table>
			                                    <br />
			                                    <br />

			                                    <!--input type="button" class="flatbutton" value="  Clear " onclick="ClearSignature(); EnableSaveButton(true);"/-->&nbsp;&nbsp;

		                                    <%-- <asp:Button disabled="disabled" Runat="server" ID="btnSave" Height="30px" 
			                                    style="margin-right: 40px; margin-top: 22px;" Text=" Submit Application " onclick="Submit_Click" CssClass="btnLogin"/>--%>
		                                    <br />
                                    <script type="text/javascript" language="javascript">

                                      // This is an extra method called after signing or clear sign
                                      // you can optionally call this. See the onclick events of Preview and Re-Sign button
                                      function EnableSaveButton(enable)
                                      {
	                                    var btnSave = document.getElementById("UserWizard1_FinishNavigationTemplateContainerID_FinishButton");
                                    	
	                                    if(enable)
	                                      btnSave.disabled = "";
	                                    else
	                                      btnSave.disabled = "disabled";
                                      }
                                      
                                    </script>


                                <!--End Sign Application-->
                                </asp:WizardStep>
                                
                            </wizardsteps>

                            <StepPreviousButtonStyle CssClass="buttons"></StepPreviousButtonStyle>
                        </asp:Wizard>
                <div class="clearFloat"></div>
        </div>
        <div id="FormBottom"></div>
                    
            
        </div>
        
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>
