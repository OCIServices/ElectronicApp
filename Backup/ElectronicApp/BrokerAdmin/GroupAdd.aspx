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
                
                <h2><p><span class="red">Contact Information</span></p></h2>
                <p><asp:Label ID="lblErrorContactInfo" Visible="false" ForeColor="Red" Text="ERROR" runat="server"></asp:Label></p>
                <table border="0" cellpadding="5" style="border-collapse: collapse; margin-left: 31px; margin-bottom: 0px;" runat="server" id="clients">
                <!--Form to add client data.-->
                    <tr>
                        <td class="style8"><asp:Label CssClass="labelRight" runat="server" Text="Group Name"></asp:Label> </td>
                        <td class="style7">
                            <asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8"><asp:Label ID="Label1" CssClass="labelRight" runat="server" Text="Tax ID"></asp:Label> </td>
                        <td class="style7">
                            <asp:TextBox ID="txtTaxID" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8"><asp:Label ID="Label2" CssClass="labelRight" runat="server" Text="Phone"></asp:Label> </td>
                        <td class="style7">
                            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8"><asp:Label ID="Label3" CssClass="labelRight" runat="server" Text="Fax"></asp:Label> </td>
                        <td class="style7">
                            <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8"><asp:Label ID="Label4" CssClass="labelRight" runat="server" Text="Address"></asp:Label> </td>
                        <td class="style7">
                            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8"><asp:Label ID="Label5" CssClass="labelRight" runat="server" Text="City"></asp:Label> </td>
                        <td class="style7">
                            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8"><asp:Label ID="Label6" CssClass="labelRight" runat="server" Text="State"></asp:Label> </td>
                        <td class="style7">
                            <asp:TextBox ID="txtState" runat="server" MaxLength="2"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style8"><asp:Label ID="Label7" CssClass="labelRight" runat="server" Text="Zip"></asp:Label> </td>
                        <td class="style7">
                            <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                
                <br /><br />
                <h2><p><span class="red">Coverage Information</span></p></h2>
                <p><asp:Label ID="lblErrorCoverages" Visible="false" ForeColor="Red" Text="ERROR" runat="server"></asp:Label></p>
                <p>
                    <table border="0" cellpadding="5" style="border-collapse: collapse; margin-left: 31px; margin-bottom: 0px;" runat="server" id="Table1">
                    <!--Form to add client data.-->
                        <tr>
                            <td class="style8"><asp:Label ID="Label8" CssClass="labelRight" runat="server" Text="Coverages"></asp:Label> </td>
                            <td class="style7">
                                <asp:CheckBox ID="chkMedical" runat="server" />Medical<br />
                                <asp:CheckBox ID="chkDental" runat="server" />Dental<br />
                                <asp:CheckBox ID="chkLife" runat="server" />Life<br />
                                <asp:CheckBox ID="chkVision" runat="server" />Vision<br />
                                <asp:CheckBox ID="chkDisability" runat="server" />Disability
                            </td>
                        </tr>
                     </table>
                 </p>
                 
                 <br /><br />
                <h2><p><span class="red">Carrier Selection</span></p></h2>
                <p><asp:Label ID="lblErrorCarriers" Visible="false" ForeColor="Red" Text="ERROR" runat="server"></asp:Label></p>
                
                <p>
                    
                    <table border="0" cellpadding="5" style="border-collapse: collapse; margin-left: 31px; margin-bottom: 0px;" runat="server" id="Table2">
                    <!--Form to add client data.-->
                        <tr>
                            <td class="style8"><asp:Label ID="Label9" CssClass="labelRight" runat="server" Text="Carriers"></asp:Label> </td>
                            <td class="style7">
                                <asp:ListBox ID="lstAvail" runat="server" Width="250px" Height="175px">
                                </asp:ListBox>
                            </td>
                            <td class="style7">
                                <asp:Button ID="btnAddSel" runat="server" Text="&gt;&gt;" Width="100px" 
                                    Height="50px" onclick="btnAddSel_Click" /><br /><br />
                                <asp:Button ID="btnRemoveSel"
                                    runat="server" Text="&lt;&lt;" Height="50px" Width="100px" 
                                    onclick="btnRemoveSel_Click" />
                            </td>
                            <td class="style7">
                                <asp:ListBox ID="lstSel" runat="server" Width="250px" Height="175px"></asp:ListBox>
                            </td>
                            
                        </tr>
                     </table>                     
                 </p>
                 
                 <br /><br />
                <h2>&nbsp;<p><span class="red">Login Credentials</span></p></h2>
                <p><asp:Label ID="lblErrorCredentials" Visible="false" ForeColor="Red" Text="ERROR" runat="server"></asp:Label></p>
                <p><asp:Label ID="lblErrorTaken" Visible="false" ForeColor="Red" Text="ERROR" runat="server"></asp:Label></p>
                <p><asp:Label ID="lblErrorCals" Visible="false" ForeColor="Red" Text="ERROR" runat="server"></asp:Label></p>
                <p>
                    <table border="0" cellpadding="5" style="border-collapse: collapse; margin-left: 31px; margin-bottom: 0px;" runat="server" id="Table3">
                    <!--Form to add client data.-->
                        <tr>
                            <td class="style8"><asp:Label ID="Label10" CssClass="labelRight" runat="server" Text="Login"></asp:Label> </td>
                            <td class="style7" colspan="2">
                                <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style8"><asp:Label ID="Label11" CssClass="labelRight" runat="server" Text="Password"></asp:Label> </td>
                            <td class="style7" colspan="2">
                                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style8"><asp:Label ID="Label13" CssClass="labelRight" runat="server" Text="Password(Verify)"></asp:Label> </td>
                            <td class="style7" colspan="2">
                                <asp:TextBox ID="txtPassword2" TextMode="Password" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        
                        <tr>
                            <td class="style8"><asp:Label ID="Label12" CssClass="labelRight" runat="server" Text="Enrollment Period"></asp:Label> </td>
                            <td class="style7">
                                <asp:Calendar ID="calBeginPeriod"  runat="server"></asp:Calendar>
                           </td>
                           <td class="style7">
                                <asp:Calendar ID="calEndPeriod" runat="server"></asp:Calendar>
                            </td>
                        </tr>
                     </table>
                 </p>
                 <p><asp:Button ID="btnAdd" runat="server" BackColor="#CCCCCC" 
                 BorderColor="#CCCCCC" style="margin-left: 58px" 
                 Text="Add Group" Width="154px" Font-Bold="False" ForeColor="Black" 
                 Height="26px" onclick="btnAdd_Click" />
               
               
              
                
                        </p>
                <div class="clearFloat">
                </div>
                </div>
                <div id="FormBottom">
                    
                    </div>
            </div>
        </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>