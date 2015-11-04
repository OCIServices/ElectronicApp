<%@ Page Language="C#" Theme="FormPage" AutoEventWireup="true" CodeBehind="DependentData.aspx.cs" Inherits="ElectronicApp.NebraskaApp.DependentData" EnableSessionState="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
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
</head>
<body>
 <form id="form1" runat="server">
    <div id="FormContainer">
        <div id="FormTop"><h1><span class="red">Dependant</span> Information</h1></div>
           <div id="FormMid">   
               <asp:HiddenField ID="isSpouse" runat="server" />    
               <asp:HiddenField ID="numChildren" runat="server" />                       
               <table id ="dependents" style="margin-left: 20px">
                   <tr>
                       <td class="style75">
                           <asp:Label ID="Label1" runat="server" CssClass="tableTitle" 
                               Text="Name (First, MI, Last)"></asp:Label>
                       </td>
                       <td class="style88">
                           <asp:Label ID="Label2" runat="server" CssClass="tableTitle" Text="Gender"></asp:Label>
                       </td>
                       <td class="style89">
                           <asp:Label ID="Label3" runat="server" CssClass="tableTitle" Text="Height"></asp:Label>
                       </td>
                       <td class="style87">
                           <asp:Label ID="Label4" runat="server" CssClass="tableTitle" Text="Weight"></asp:Label>
                       </td>
                       <td class="style82">
                           <asp:Label ID="Label5" runat="server" CssClass="tableTitle" Text="DOB"></asp:Label>
                       </td>
                       <td class="style90">
                           <asp:Label ID="Label6" runat="server" CssClass="tableTitle" Text="SS#"></asp:Label>
                       </td>
                       <td class="style91">
                           <asp:Label ID="Label7" runat="server" CssClass="tableTitle" 
                               Text="Primary Physician"></asp:Label>
                       </td>
                       <td class="style93">
                           <asp:Label ID="Label8" runat="server" CssClass="tableTitle" 
                               Text="Full-Time Student"></asp:Label>
                       </td>
                       <td class="style85">
                           <asp:Label ID="Label9" runat="server" CssClass="tableTitle" 
                               Text="Medicare Enrolled"></asp:Label>
                       </td>
                       <td class="style92">
                           <asp:Label ID="Label10" runat="server" CssClass="tableTitle" Text="SS Enrolled"></asp:Label>
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
