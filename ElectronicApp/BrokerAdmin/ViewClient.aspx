<%@ Page Language="C#" Theme="FormPage" AutoEventWireup="true" CodeBehind="ViewClient.aspx.cs" Inherits="ElectronicApp.BrokerAdmin.ViewClient" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">

    <title>View Client Applications</title>

    <style type="text/css">
        .style2
        {
            height: 6px;
            width: 1459px;
        }
        .style3
        {
            height: 5px;
            width: 1459px;
        }
        .style4
        {
            width: 58px; 
            font-weight: bold;
        }
        .style5
        {
            height: 6px;
            width: 58px;
            font-weight: bold;
        }
        .style6
        {
            height: 5px;
            width: 58px;
            font-weight: bold;
        }
        .style7
        {
            width: 1459px;
        }
        .style8
        {
            width: 58px;
            font-weight: bold;
        }
        .style9
        {
            width: 133px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div id="FormContainer">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div id="FormTop"><h1 id="header" runat = "server"><span class="red">Client Submissions</span> </h1></div>
                    <div id="FormMid">
                    
                    <br />
                    <p><span style="float: left;"><a href="Welcome.aspx">< Back</a></span><span style="float: right; margin-right: 31px;"><a href="EditClient.aspx">Edit Client Information ></a></span></p>
                    
                    <br />
                    <br />
                    <br />
                    
                    <table style="border: 1px solid; padding-right: 5px; margin-right: 31px; margin-left: 31px; margin-bottom: 0px;">
                           <tr>
                               <td class="style8">
                                   <asp:label ID="Label3" CssClass="labelRight" runat="server" Text="Name:"></asp:label>                       </td>
                               <td class="style7" runat="server" id="BrokerName">
                                   </td>
                           </tr>
                           <tr>
                               <td class="style4">
                                   <asp:label ID="Label1" CssClass="labelRight" runat="server" Text="Phone:"></asp:label>
                               </td>
                               <td class="style7" runat="server" id="BrokerPhone"></td>
                           </tr>
                           <tr>
                               <td class="style5"><asp:label ID="Label5" CssClass="labelRight" runat="server" Text="Fax:"></asp:label></td>
                               <td class="style2" runat="server" id="BrokerFax"></td>
                           </tr>
                           <tr>
                               <td class="style6"><asp:label ID="Label4" CssClass="labelRight" runat="server" Text = "Address:"></asp:label></td>
                               <td class="style3" runat="server" id="BrokerAddress"></td>
                           </tr>
                       </table>
                       <p><asp:LinkButton OnClick="showlink_Click" ID="showlink" runat="server">show password</asp:LinkButton></p>
                       
                       <div id="passinfo" runat="server" style="margin-left: 31px; display: none;">
                       <table>
                           <tr>
                                <td>Username</td>
                                <td><asp:Label ID="username" runat="server"></asp:Label></td>
                           </tr>
                           <tr>
                                <td>Password</td>
                                <td><asp:TextBox ID="password" runat="server"></asp:TextBox></td>
                           </tr>
                           <tr>
                                <td>&nbsp;</td>
                                <td><asp:Label runat="server" Visible="false" ForeColor="Red" ID="errors" Text=""></asp:Label></td>
                           </tr>
                           <tr>
                                <td>&nbsp;</td>
                                <td><asp:LinkButton runat="server" ID="savepasswd" Text="Save Password" OnClick="savepasswd_Click"></asp:LinkButton></td>
                           </tr>
                       </table>
                       </div>
                        <table style="margin-left: 29px; margin-right: 13px; margin-top: 17px; width: 349px;">
                           <tr>
                                <td class="style9">
                                    <asp:Label ID="Label6" runat="server" Font-Bold="True"
                            Text="Submission Count: " Font-Size="14px"></asp:Label></td>
                        <td><asp:Label ID="lblsubcount" runat="server" Font-Bold="True" Font-Size="14px"></asp:Label></td>
                        </tr>
                        <tr><td colspan="2">
                            <asp:Label ID="Label7" runat="server" Font-Size="12px" 
                                Text="*click column headers to sort data"></asp:Label>
                            </td></tr>
                        </table>
                    
                    <br />
                    
                    <table border="1" cellpadding="5" style="border-collapse: collapse; margin-left: 31px; margin-bottom: 0px; width: 50%;" runat="server" id="clients">
                    </table>
                    
                    <div class="clearFloat">
                    </div>
                    </div>
                    <div id="FormBottom"></div>
                </ContentTemplate>
            </asp:UpdatePanel>
            
            
        </div>
    </form>
</body>
</html>