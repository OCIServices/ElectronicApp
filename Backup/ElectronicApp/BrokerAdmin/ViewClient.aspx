<%@ Page Language="C#" Theme="FormPage" AutoEventWireup="true" CodeBehind="ViewClient.aspx.cs" Inherits="ElectronicApp.BrokerAdmin.ViewClient" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">

    <title>View Client Applications</title>

    <style type="text/css">
        .style1
        {
            width: 109px;
        }
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
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div id="FormContainer">
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
            
            <br />
            <br />
            <br />
            
            <table border="1" cellpadding="5" style="border-collapse: collapse; margin-left: 31px; margin-bottom: 0px; width: 50%;" runat="server" id="clients">
            </table>
            
            <div class="clearFloat">
            </div>
            </div>
            <div id="FormBottom"></div>
        </div>
    </form>
</body>
</html>