<%@ Page Theme="FormPage" Language="C#" AutoEventWireup="true" CodeBehind="GroupAdd.aspx.cs" Inherits="ElectronicApp.BrokerAdmin.GroupAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">

    <script language="javascript" type="text/javascript" src="../Validation/validationHelpers.js"></script>
    <title>Add New Group</title>

    <style type="text/css">
        .style7
        {
            width: 1400px;
        }
        .style8
        {
            width: 117px;
            font-weight: bold;
        }
        .style10
        {
            width: 241px;
            font-weight: bold;
        }
        .style11
        {
            width: 933px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    
            <div id="FormContainer">
                <div id="FormTop"><h1 id="header" runat = "server"><span class="red">Welcome</span> </h1></div>
                <div id="FormMid">
                <br />
                <br />
                
                <h2><p><span class="red">Contact Information</span></p>
                    <h2>
                    </h2>
                    <p>
                        <asp:Label ID="lblErrorContactInfo" runat="server" ForeColor="Red" Text="ERROR" 
                            Visible="false"></asp:Label>
                    </p>
                    <table ID="clients" runat="server" border="0" cellpadding="5" 
                        style="border-collapse: collapse; margin-left: 31px; margin-bottom: 0px;">
                        <!--Form to add client data.-->
                        <tr>
                            <td class="style8">
                                <asp:Label runat="server" CssClass="labelRight" Text="Group Name"></asp:Label>
                            </td>
                            <td class="style7">
                                <asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style8">
                                <asp:Label ID="Label1" runat="server" CssClass="labelRight" Text="Tax ID"></asp:Label>
                            </td>
                            <td class="style7">
                                <asp:TextBox ID="txtTaxID" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style8">
                                <asp:Label ID="Label2" runat="server" CssClass="labelRight" Text="Phone"></asp:Label>
                            </td>
                            <td class="style7">
                                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style8">
                                <asp:Label ID="Label3" runat="server" CssClass="labelRight" Text="Fax"></asp:Label>
                            </td>
                            <td class="style7">
                                <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style8">
                                <asp:Label ID="Label4" runat="server" CssClass="labelRight" Text="Address"></asp:Label>
                            </td>
                            <td class="style7">
                                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style8">
                                <asp:Label ID="Label5" runat="server" CssClass="labelRight" Text="City"></asp:Label>
                            </td>
                            <td class="style7">
                                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style8">
                                <asp:Label ID="Label6" runat="server" CssClass="labelRight" Text="State"></asp:Label>
                            </td>
                            <td class="style7">
                                <asp:TextBox ID="txtState" runat="server" MaxLength="2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style8">
                                <asp:Label ID="Label7" runat="server" CssClass="labelRight" Text="Zip"></asp:Label>
                            </td>
                            <td class="style7">
                                <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <h2>
                        <p>
                            <span class="red">Coverage Information</span></p>
                        <h2>
                        </h2>
                        <p>
                            <asp:Label ID="lblErrorCoverages" runat="server" ForeColor="Red" Text="ERROR" 
                                Visible="false"></asp:Label>
                        </p>
                        <p>
                            <table ID="Table1" runat="server" border="0" cellpadding="5" 
                                style="border-collapse: collapse; margin-left: 31px; margin-bottom: 0px;">
                                <!--Form to add client data.-->
                                <tr>
                                    <td class="style8">
                                        <asp:Label ID="Label8" runat="server" CssClass="labelRight" Text="Coverages"></asp:Label>
                                    </td>
                                    <td class="style7">
                                        <asp:CheckBox ID="chkMedical" runat="server" />
                                        Medical<br />
                                        <asp:CheckBox ID="chkDental" runat="server" />
                                        Dental<br />
                                        <asp:CheckBox ID="chkLife" runat="server" />
                                        Life<br />
                                        <asp:CheckBox ID="chkVision" runat="server" />
                                        Vision<br />
                                        <asp:CheckBox ID="chkDisability" runat="server" />
                                        Disability
                                    </td>
                                </tr>
                                </table>
                                <p>
                                    <asp:Label ID="errorEligible" runat="server" Text="please enter number of eligible employees" ForeColor="#CC0000" 
                                        Visible="false"></asp:Label>
                                </p>
                                <table style="width: 1001px; margin-left: 31px">
                                <tr>
                                    <td class="style10">
                                        <asp:Label ID = "lblEligible" Text= "Number of Eligible Employees" runat="server"></asp:Label></td>
                                    <td class="style11">
                                         <asp:TextBox ID="txtEligible" runat="server" CausesValidation="True"></asp:TextBox>
                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                             ControlToValidate="txtEligible" 
                                             ErrorMessage="Number Of Eligible employees must be a number" 
                                             ValidationExpression="\d+"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                            </table>
                            <p>
                            </p>
                            <br />
                            <br />
                            <h2>
                                <p>
                                    <span class="red">Carrier Selection</span></p>
                                <h2>
                                </h2>
                                <p>
                                    <asp:Label ID="lblErrorCarriers" runat="server" ForeColor="Red" Text="ERROR" 
                                        Visible="false"></asp:Label>
                                </p>
                                <p>
                                    <table ID="Table2" runat="server" border="0" cellpadding="5" 
                                        style="border-collapse: collapse; margin-left: 31px; margin-bottom: 0px;">
                                        <!--Form to add client data.-->
                                        <tr>
                                            <td class="style8">
                                                <asp:Label ID="Label9" runat="server" CssClass="labelRight" Text="Carriers"></asp:Label>
                                            </td>
                                            <td class="style7">
                                                <asp:ListBox ID="lstAvail" runat="server" Height="175px" Width="250px">
                                                </asp:ListBox>
                                            </td>
                                            <td class="style7">
                                                <asp:Button ID="btnAddSel" runat="server" Height="50px" 
                                                    onclick="btnAddSel_Click" Text="&gt;&gt;" Width="100px" />
                                                <br />
                                                <br />
                                                <asp:Button ID="btnRemoveSel" runat="server" Height="50px" 
                                                    onclick="btnRemoveSel_Click" Text="&lt;&lt;" Width="100px" />
                                            </td>
                                            <td class="style7">
                                                <asp:ListBox ID="lstSel" runat="server" Height="175px" Width="250px">
                                                </asp:ListBox>
                                            </td>
                                        </tr>
                                    </table>
                                </p>
                                <br />
                                <br />
                                <h2>
                                    &nbsp;<p>
                                        <span class="red">Login Credentials</span></p>
                                    <h2>
                                    </h2>
                                    <p>
                                        <asp:Label ID="lblErrorCredentials" runat="server" ForeColor="Red" Text="ERROR" 
                                            Visible="false"></asp:Label>
                                    </p>
                                    <p>
                                        <asp:Label ID="lblErrorTaken" runat="server" ForeColor="Red" Text="ERROR" 
                                            Visible="false"></asp:Label>
                                    </p>
                                    <p>
                                        <asp:Label ID="lblErrorCals" runat="server" ForeColor="Red" Text="ERROR" 
                                            Visible="false"></asp:Label>
                                    </p>
                                    <p>
                                        <table ID="Table3" runat="server" border="0" cellpadding="5" 
                                            style="border-collapse: collapse; margin-left: 31px; margin-bottom: 0px;">
                                            <!--Form to add client data.-->
                                            <tr>
                                                <td class="style8">
                                                    <asp:Label ID="Label10" runat="server" CssClass="labelRight" Text="Login"></asp:Label>
                                                </td>
                                                <td class="style7" colspan="2">
                                                    <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style8">
                                                    <asp:Label ID="Label11" runat="server" CssClass="labelRight" Text="Password"></asp:Label>
                                                </td>
                                                <td class="style7" colspan="2">
                                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style8">
                                                    <asp:Label ID="Label13" runat="server" CssClass="labelRight" 
                                                        Text="Password(Verify)"></asp:Label>
                                                </td>
                                                <td class="style7" colspan="2">
                                                    <asp:TextBox ID="txtPassword2" runat="server" TextMode="Password"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style8">
                                                    &nbsp;</td>
                                                <td class="style7">
                                                    &nbsp;</td>
                                                <td class="style7">
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </p>
                                    <p>
                                        <asp:Button ID="btnAdd" runat="server" BackColor="#CCCCCC" 
                                            BorderColor="#CCCCCC" Font-Bold="False" ForeColor="Black" Height="26px" 
                                            onclick="btnAdd_Click" style="margin-left: 58px" Text="Add Group" 
                                            Width="154px" />
                                    </p>
                                    <div class="clearFloat">
                                    </div>
                                    <h2>
                                    </h2>
                                    <h2>
                                    </h2>
                                    <h2>
                                    </h2>
                                    <h2>
                                    </h2>
                                    <h2>
                                    </h2>
                                    <h2>
                                    </h2>
                                    <h2>
                                    </h2>
                                    <h2>
                                    </h2>
                                </h2>
                            </h2>
                        </p>
                    </h2>
                    </h2>
                </div>
                <div id="FormBottom">
                    
                    </div>
            </div>
        </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>